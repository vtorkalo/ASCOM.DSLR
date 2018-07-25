using ASCOM.DSLR.Enums;
using ASCOM.DSLR.Interfaces;
using OTelescope.SampleAPI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ASCOM.DSLR.Classes
{
    public class BackyardEosCamera : BaseCamera, IDslrCamera
    {
        private bool _waitingForImage = false;
        private int _port;
        private DateTime _exposureStartTime;
        private const int timeout = 60;
        private double _lastDuration;
        private string _lastFileName;

        public BackyardEosCamera(int port, List<CameraModel> cameraModelsHistory) :base(cameraModelsHistory)
        {
            _port = port;
            _backyardTcpClient = new OTelescopeTcpClient(_port);
        }

        private OTelescopeTcpClient _backyardTcpClient;

        public event EventHandler<ImageReadyEventArgs> ImageReady;
        public event EventHandler<ExposureFailedEventArgs> ExposureFailed;
        public event EventHandler<LiveViewImageReadyEventArgs> LiveViewImageReady;

        public string Model
        {
            get
            {
                return _backyardTcpClient.SendCommand("getcameramodel");
            }
        }

        public ConnectionMethod IntegrationApi => ConnectionMethod.BackyardEOS;

        public bool SupportsViewView { get { return false; } }
        
        public void AbortExposure()
        {
            _backyardTcpClient.SendCommand("abort");
        }

        public void ConnectCamera()
        {

        }

        public void DisconnectCamera()
        {
        }

        public void Dispose()
        {
            _backyardTcpClient?.Dispose();
        }

        public override CameraModel ScanCameras()
        {
            _backyardTcpClient.SendCommand("connect");
            var modelStr = _backyardTcpClient.SendCommand("getcameramodel");
            if (!string.IsNullOrEmpty(modelStr))
            {
                _cameraModel = GetCameraModel(modelStr);
            }
            if (_cameraModel == null)
            {
                throw new NotConnectedException(ErrorMessages.NotConnected);
            }
            return _cameraModel;
        }

        public void StartExposure(double Duration, bool Light)
        {
            string quality = GetQualityStr();
            var command = string.Format("takepicture quality:{0} duration:{1} iso:{2} bin:1", quality, Duration, Iso);
            _backyardTcpClient.SendCommand(command);

            MarkWaitingForExposure(Duration);

            ThreadPool.QueueUserWorkItem(state =>
            {
                CheckDownload();
            });
        }

        private string GetQualityStr()
        {
            string quality = null;
            switch (ImageFormat)
            {
                case ImageFormat.RAW:
                    quality = "raw";
                    break;
                case ImageFormat.JPEG:
                    quality = "jpg";
                    break;
            }

            return quality;
        }

        private void MarkWaitingForExposure(double Duration)
        {
            _exposureStartTime = DateTime.Now;
            _lastDuration = Duration;
            _waitingForImage = true;
        }

        private bool IsTimeout(string status)
        {
            var timeElapsed = DateTime.Now - _exposureStartTime;
            bool isTimeout = status == "busy" && timeElapsed.TotalSeconds > _lastDuration + timeout;

            return isTimeout;
        }

        private bool CheckStatus()
        {
            bool isOk = true;
            var status = _backyardTcpClient.SendCommand("getstatus");
            if (status == "error")
            {                
                CallExposureFailed(ErrorMessages.CameraError);
                isOk = false;
            }
            else if (IsTimeout(status))
            {
                CallExposureFailed(ErrorMessages.ConnectionTimeout);
                isOk = false;
            }

            return isOk;
        }

        private bool TryDownload()
        {
            bool downloaded = false;
            var readyStr = _backyardTcpClient.SendCommand("getispictureready");
            bool ready = readyStr.Equals(bool.TrueString);
            if (ready)
            {
                var filepath = _backyardTcpClient.SendCommand("getpicturepath").Trim();

                if (ImageReady != null && _waitingForImage && !string.IsNullOrEmpty(filepath) && filepath != _lastFileName)
                {
                    ImageReady(this, new ImageReadyEventArgs(filepath));
                    _lastFileName = filepath;
                    _waitingForImage = false;
                    SensorTemperature = GetSensorTemperature(filepath);
                    downloaded = true;
                }
            }

            return downloaded;
        }
        

        private void CheckDownload()
        {            
            while (true)
            {
                try
                {
                    if (!CheckStatus() || TryDownload())
                    {
                        break;
                    }

                    Thread.Sleep(1000);
                }
                catch (Exception e)
                {
                    CallExposureFailed(e.Message, e.StackTrace);
                    break;
                }
            }
        }

        private void CallExposureFailed(string message, string stackTrace = null)
        {
            _waitingForImage = false;
            ExposureFailed?.Invoke(this, new ExposureFailedEventArgs(message, stackTrace));
        }

        public void StopExposure()
        {
            AbortExposure();
        }
    }
}
