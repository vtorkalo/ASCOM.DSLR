using ASCOM.DSLR.Enums;
using ASCOM.DSLR.Interfaces;
using EDSDKLib.API.Base;
using EOSDigital.API;
using EOSDigital.SDK;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace ASCOM.DSLR.Classes
{
    public class CanonSdkCamera : BaseCanonCamera, IDslrCamera, IDisposable
    {
        public CanonSdkCamera()
        {
            APIHandler = new CanonAPI();
            APIHandler.CameraAdded += APIHandler_CameraAdded;
            ErrorHandler.SevereErrorHappened += ErrorHandler_SevereErrorHappened;
            ErrorHandler.NonSevereErrorHappened += ErrorHandler_NonSevereErrorHappened;
        }


        CanonAPI APIHandler;

        EOSDigital.API.Camera _mainCamera;
        EOSDigital.API.Camera MainCamera
        {
            get
            {
                if (_mainCamera == null)
                {
                    ScanCameras();
                }
                return _mainCamera;
            }
        }

        List<EOSDigital.API.Camera> CamList;

        private void CloseCamera()
        {
            CloseSession();
            _mainCamera?.Dispose();
            APIHandler?.Dispose();
        }

        private void APIHandler_CameraAdded(CanonAPI sender)
        {
        }

        public override CameraModel ScanCameras()
        {
            CamList = APIHandler.GetCameraList();
            if (!CamList.Any())
            {
                throw new NotConnectedException(ErrorMessages.NotConnected);
            }
            _mainCamera = CamList.First();
            var cameraModel = GetCameraModel(_mainCamera.DeviceName);
            return cameraModel;
        }


        private void MainCamera_StateChanged(EOSDigital.API.Camera sender, StateEventID eventID, int parameter)
        {

        }

        private void MainCamera_ProgressChanged(object sender, int progress)
        {

        }

        private DateTime _startTime;

        private void MainCamera_DownloadReady(EOSDigital.API.Camera sender, DownloadInfo Info)
        {
            _duration = Math.Round(_duration, 6);
            if (!Directory.Exists(StorePath))
            {
                Directory.CreateDirectory(StorePath);
            }
            sender.DownloadFile(Info, StorePath);

            string downloadedFilePath = Path.Combine(StorePath, Info.FileName);
            SensorTemperature = GetSensorTemperature(downloadedFilePath);

            string newFilePath = RenameFile(Info, downloadedFilePath);
            ImageReady?.Invoke(this, new ImageReadyEventArgs(newFilePath));
        }

        private string RenameFile(DownloadInfo Info, string downloadedFilePath)
        {
            string newFileName = GetFileName();
            string newFilePath = Path.Combine(StorePath, Info.FileName);
            File.Move(downloadedFilePath, newFilePath);
            return newFilePath;
        }

        private string GetFileName()
        {
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ",";
            return string.Format("IMG_{0}s_{1}iso_{2}C_{3}", _duration.ToString(nfi), Iso, SensorTemperature, _startTime.ToString("yyyy_MM_dd_HH_mm_ss"));
        }

        private void ErrorHandler_NonSevereErrorHappened(object sender, ErrorCode ex)
        {
            ExposureFailed?.Invoke(this, new ExposureFailedEventArgs(ErrorMessages.CameraError, ex.ToString()));
        }

        private void ErrorHandler_SevereErrorHappened(object sender, Exception ex)
        {
            ExposureFailed?.Invoke(this, new ExposureFailedEventArgs(ex.Message, ex.StackTrace));
        }

        private void CloseSession()
        {
            if (_mainCamera != null && _mainCamera.SessionOpen)
            {
                _mainCamera.ProgressChanged -= MainCamera_ProgressChanged;
                _mainCamera.StateChanged -= MainCamera_StateChanged;
                _mainCamera.DownloadReady -= MainCamera_DownloadReady;
                _mainCamera.CloseSession();
            }
        }

        private void OpenSession()
        {
            ScanCameras();
            if (!MainCamera.SessionOpen)
            {
                MainCamera.OpenSession();
                MainCamera.ProgressChanged += MainCamera_ProgressChanged;
                MainCamera.StateChanged += MainCamera_StateChanged;
                MainCamera.DownloadReady += MainCamera_DownloadReady;
                TvList = MainCamera.GetSettingsList(PropertyID.Tv);
                ISOList = MainCamera.GetSettingsList(PropertyID.ISO);
            }
        }


        public string Model
        {
            get
            {
                return MainCamera.DeviceName;
            }
        }        

        public IntegrationApi IntegrationApi => IntegrationApi.CanonSdk;

        public ImageFormat ImageFormat { get; set; }

        public event EventHandler<ImageReadyEventArgs> ImageReady;
        public event EventHandler<ExposureFailedEventArgs> ExposureFailed;

        public void AbortExposure()
        {
            _canceledFlag.IsCanceled = true;
        }

        private void InitSettings()
        {
            MainCamera.SetSetting(PropertyID.SaveTo, (int)SaveTo.Host);
            MainCamera.SetCapacity(1024, int.MaxValue);

            switch (ImageFormat)
            {
                case ImageFormat.RAW:
                    MainCamera.SetSetting(PropertyID.ImageQuality, (int)ImageQuality.RAW);
                    break;
                case ImageFormat.JPEG:
                    MainCamera.SetSetting(PropertyID.ImageQuality, (int)ImageQuality.LargeJpegFine);
                    break;
            }

            CameraValue selectedIsoValue = GetSelectedIsoValue();
            MainCamera.SetSetting(PropertyID.ISO, selectedIsoValue.IntValue);
        }

        private CameraValue GetSelectedIsoValue()
        {
            var selectedIsoValue = ISOList.SingleOrDefault(v => v.DoubleValue == Iso && v.DoubleValue > 0);
            if (selectedIsoValue == null)
            {
                var nearest = ISOValues.Values.Where(v => v.DoubleValue < short.MaxValue && v.DoubleValue > 0)
                    .Select(v => new { value = v, difference = Math.Abs(v.DoubleValue - Iso) }).OrderBy(d => d.difference).First().value;

                selectedIsoValue = nearest;
            }

            var isoValue = ISOValues.GetValue((double)Iso);

            return selectedIsoValue;
        }

        private CameraValue GetSelectedTv(double Duration)
        {
            var nearestTv = TvList.Select(t => new { Tv = t, delta = Math.Abs(t.DoubleValue - Duration) }).OrderBy(d => d.delta);
            var tvCameraValue = nearestTv.First().Tv;
            return tvCameraValue;
        }

        private CanceledFlag _canceledFlag = new CanceledFlag();

        private double _duration;

        public void StartExposure(double Duration, bool Light)
        {
            OpenSession();
            InitSettings();

            _duration = Duration;
            _startTime = DateTime.Now;
            _canceledFlag.IsCanceled = false;

            if (Duration >= 1)
            {
                MainCamera.SetSetting(PropertyID.Tv, TvValues.GetValue("Bulb").IntValue);
                MainCamera.TakePhotoBulbAsync((int)(Duration * 1000), _canceledFlag);
            }
            else
            {
                CameraValue tvCameraValue = GetSelectedTv(Duration);
                MainCamera.SetSetting(PropertyID.Tv, tvCameraValue.IntValue);
                MainCamera.TakePhoto();
            }
        }

        public void StopExposure()
        {
            AbortExposure();
        }

        public void Dispose()
        {
            CloseCamera();
        }

        public void ConnectCamera()
        {

        }

        public void DisconnectCamera()
        {

        }
    }
}
