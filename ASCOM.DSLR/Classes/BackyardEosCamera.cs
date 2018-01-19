using ASCOM.DSLR.Enums;
using ASCOM.DSLR.Interfaces;
using OTelescope.SampleAPI;
using System;
using System.Threading;

namespace ASCOM.DSLR.Classes
{
    public class BackyardEosCamera : BaseCanonCamera, IDslrCamera
    {
        private bool _waitingForImage = false;
        private int _port;

        public BackyardEosCamera(int port)
        {
            _port = port;
            _backyardTcpClient = new OTelescopeTcpClient(_port);
        }

        private OTelescopeTcpClient _backyardTcpClient;



        public event EventHandler<ImageReadyEventArgs> ImageReady;
        public event EventHandler<ExposureFailedEventArgs> ExposureFailed;

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
        }

        public void InitApi()
        {

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

        private DateTime _exposureStartTime;
        private const int timeout = 60;
        private double _lastDuration;


        public void StartExposure(double Duration, bool Light)
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
            var command = string.Format("takepicture quality:{0} duration:{1} iso:{2} bin:1", quality, Duration, Iso);
            string reply = _backyardTcpClient.SendCommand(command);
            _exposureStartTime = DateTime.Now;
            _lastDuration = Duration;

            _waitingForImage = true;

            ThreadPool.QueueUserWorkItem(state =>
            {

                string lastFileName = string.Empty;
                while (true)
                {
                    try
                    {
                        var status = _backyardTcpClient.SendCommand("getstatus");
                        if (status == "error")
                        {
                            _waitingForImage = false;
                            CallExposureFailed(ErrorMessages.CameraError);
                            break;
                        }
                        if (status == "busy")
                        {
                            var currentTime = DateTime.Now;
                            var diff = currentTime - _exposureStartTime;
                            if (diff.TotalSeconds > _lastDuration + timeout)
                            {
                                CallExposureFailed(ErrorMessages.ConnectionTimeout);
                                break;
                            }
                        }

                        var readyStr = _backyardTcpClient.SendCommand("getispictureready");
                        bool ready = readyStr.Equals(bool.TrueString);
                        if (ready)
                        {
                            var filepath = _backyardTcpClient.SendCommand("getpicturepath").Trim();

                            if (ImageReady != null && _waitingForImage && !string.IsNullOrEmpty(filepath) && filepath != lastFileName)
                            {
                                ImageReady(this, new ImageReadyEventArgs(filepath));
                                lastFileName = filepath;
                                _waitingForImage = false;
                                FileDownloaded(filepath);
                                break;
                            }
                        }
                        Thread.Sleep(1000);
                    }
                    catch (Exception e)
                    {
                        CallExposureFailed(e.Message, e.StackTrace);
                        break;
                    }
                }

            });
        }

        private void CallExposureFailed(string message, string stackTrace = null)
        {
            if (ExposureFailed != null)
            {
                ExposureFailed(this, new ExposureFailedEventArgs(message, stackTrace));
            }
        }

        public void StopExposure()
        {
            AbortExposure();
        }

        public string Model
        {
            get
            {
                return _backyardTcpClient.SendCommand("getcameramodel");
            }
        }

        public IntegrationApi IntegrationApi => IntegrationApi.BackyardEOS;

        public ImageFormat ImageFormat { get; set; }
    }
}
