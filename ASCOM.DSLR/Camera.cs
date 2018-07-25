using ASCOM.DeviceInterface;
using ASCOM.DSLR.Classes;
using ASCOM.DSLR.Enums;
using ASCOM.DSLR.Interfaces;
using ASCOM.Utilities;
using System;
using System.Collections;
using System.Linq;

namespace ASCOM.DSLR
{
    public class ApiContainer
    {
        private ApiContainer()
        {

        }
        private static IDslrCamera _dslrCamera;
        public static IDslrCamera DslrCamera
        {
            get
            {
                if (_dslrCamera != null && _dslrCamera.IntegrationApi != _cameraSettings.IntegrationApi)
                {
                    _dslrCamera.Dispose();
                    _dslrCamera = null;
                }

                if (_dslrCamera == null)
                {
                    CreateCamera();
                }
                return _dslrCamera;
            }
        }

        public static TraceLogger TraceLogger { get; set; }

        private static void CreateCamera()
        {
            if (_cameraSettings.IntegrationApi == ConnectionMethod.CanonSdk)
            {
                _dslrCamera = new CanonSdkCamera(_cameraSettings.CameraModelsHistory);
                _dslrCamera.IsLiveViewMode = _cameraSettings.LiveViewCaptureMode;
                _dslrCamera.LiveViewZoom = _cameraSettings.LiveViewZoom;
            }
            else if (_cameraSettings.IntegrationApi == ConnectionMethod.BackyardEOS)
            {
                _dslrCamera = new BackyardEosCamera(_cameraSettings.BackyardEosPort, _cameraSettings.CameraModelsHistory);
            }
            else if (_cameraSettings.IntegrationApi == ConnectionMethod.Nikon)
            {
                _dslrCamera = new DigiCamControlCamera(TraceLogger, _cameraSettings.CameraModelsHistory);
            }
            else if (_cameraSettings.IntegrationApi == ConnectionMethod.Pentax)
            {
                _dslrCamera = new PentaxCamera(_cameraSettings.CameraModelsHistory);
            }
        }

        private static CameraSettings _cameraSettings { get; set; }

        public static void SetSettings(CameraSettings settings)
        {
            _cameraSettings = settings;
            _dslrCamera?.Dispose();
            _dslrCamera = null;
        }
    }

    public partial class Camera
    {
        private CameraSettingsProvider _settingsProvider;

        private ImageDataProcessor _imageDataProcessor;
        private CameraStates _cameraState = CameraStates.cameraIdle;

        public Camera()
        {
            _settingsProvider = new CameraSettingsProvider();
            _imageDataProcessor = new ImageDataProcessor();

            ReadProfile();

            tl = new TraceLogger("", "DSLR");
            tl.Enabled = CameraSettings.TraceLog;
            connectedState = false;
            ApiContainer.TraceLogger = tl;

            BinX = 1;
            BinY = 1;
        }

        private void _dslrCamera_ImageReady(object sender, ImageReadyEventArgs args)
        {
            try
            {
                tl.LogMessage("Image downloaded", args.RawFileName);
                try
                {
                    tl.LogMessage("RAW Reading", "Raw reading started");
                    PrepareCameraImageArray(args.RawFileName);
                    tl.LogMessage("RAW Reading", "Raw reading finished");
                }
                catch (Exception ex)
                {
                    LogError("RAW reading error", ex);
                    throw new NotConnectedException("Raw reading error");
                }

                _cameraState = CameraStates.cameraIdle;
                cameraImageReady = true;
            }
            finally
            {
                UnsubscribeCameraEvents();
            }
        }

        protected void Init()
        {

        }

        #region ICamera Implementation

        private DateTime exposureStart = DateTime.MinValue;
        private double cameraLastExposureDuration = 0.0;
        private bool cameraImageReady = false;
        private Array cameraImageArray;

        public void StartExposure(double Duration, bool Light)
        {
            cameraImageReady = false;
            if (Duration < 0.0) throw new InvalidValueException("StartExposure", Duration.ToString(), "0.0 upwards");
            cameraLastExposureDuration = Duration;
            exposureStart = DateTime.Now;
            _cameraState = CameraStates.cameraExposing;

            if (ApiContainer.DslrCamera.IsLiveViewMode)
            {
                LvExposure(Duration);
            }
            else
            {
                ShutterExposure(Duration, Light);
            }
        }

        private void ShutterExposure(double Duration, bool Light)
        {
            SetCameraSettings(ApiContainer.DslrCamera, CameraSettings);
            SubscribeCameraEvents();

            try
            {
                tl.LogMessage("StartExposure", Duration.ToString() + " " + Light.ToString());
                ApiContainer.DslrCamera.StartExposure(Duration, Light);
            }
            catch (Exception ex)
            {
                LogError("Exposure failed", ex);
                throw new NotConnectedException(ErrorMessages.NotConnected);
            }
        }

        private void LvExposure(double duration)
        {
            ApiContainer.DslrCamera.LiveViewImageReady += DslrCamera_LiveViewImageReady;
            ApiContainer.DslrCamera.StartExposure(duration, true);            
        }

        private void DslrCamera_LiveViewImageReady(object sender, LiveViewImageReadyEventArgs e)
        {
            cameraImageArray = _imageDataProcessor.ReadBitmap(e.Data);

            cameraImageArray = _imageDataProcessor.ToMonochrome(cameraImageArray, _imageDataProcessor.From8To16Bit);
            cameraImageArray = _imageDataProcessor.CutArray(cameraImageArray, StartX, StartY, NumX, NumY, CameraXSize, CameraYSize);
            ApiContainer.DslrCamera.LiveViewImageReady -= DslrCamera_LiveViewImageReady;

            _cameraState = CameraStates.cameraIdle;
            cameraImageReady = true;
        }

        private void SubscribeCameraEvents()
        {
            ApiContainer.DslrCamera.ImageReady += _dslrCamera_ImageReady;
            ApiContainer.DslrCamera.ExposureFailed += DslrCamera_ExposureFailed;
        }

        private void UnsubscribeCameraEvents()
        {
            ApiContainer.DslrCamera.ImageReady -= _dslrCamera_ImageReady;
            ApiContainer.DslrCamera.ExposureFailed -= DslrCamera_ExposureFailed;
        }

        private void DslrCamera_ExposureFailed(object sender, ExposureFailedEventArgs e)
        {
            _cameraState = CameraStates.cameraError;
            LogError(e.Message, e.StackTrace);
            UnsubscribeCameraEvents();
        }

        private void LogError(string message, Exception e)
        {
            LogError(message, e.StackTrace);
        }

        private void LogError(string message, string stacktrace)
        {
            tl.LogIssue(message, stacktrace);
            _cameraState = CameraStates.cameraError;
        }

        private void SetCameraSettings(IDslrCamera camera, CameraSettings settings)
        {
            camera.Iso = Gain > 0 ? Gain : settings.Iso;
            camera.StorePath = settings.StorePath;

            switch (CameraSettings.CameraMode)
            {
                case CameraMode.RGGB:
                case CameraMode.Color16:
                    camera.ImageFormat = ImageFormat.RAW;
                    break;
                case CameraMode.ColorJpg:
                    camera.ImageFormat = ImageFormat.JPEG;
                    break;
            }

            camera.UseExternalShutter = settings.UseExternalShutter;
            camera.ExternalShutterPort = settings.ExternalShutterPortName;
        }

        private void PrepareCameraImageArray(string rawFileName)
        {

            if (CameraSettings.CameraMode == Enums.CameraMode.Color16)
            {
                cameraImageArray = _imageDataProcessor.ReadAndDebayerRaw(rawFileName);
            }
            else if (CameraSettings.CameraMode == Enums.CameraMode.ColorJpg)
            {
                cameraImageArray = _imageDataProcessor.ReadJpeg(rawFileName);
            }
            else if (CameraSettings.CameraMode == Enums.CameraMode.RGGB)
            {
                cameraImageArray = _imageDataProcessor.ReadRaw(rawFileName);
            }
            if (BinX > 1 || BinY > 1)
            {
                cameraImageArray = _imageDataProcessor.Binning(cameraImageArray, BinX, BinY, CameraSettings.BinningMode);
            }

            cameraImageArray = _imageDataProcessor.CutArray(cameraImageArray, StartX, StartY, NumX, NumY, CameraXSize, CameraYSize);
        }

        public void AbortExposure()
        {
            ApiContainer.DslrCamera.AbortExposure();
        }

        public void StopExposure()
        {
            ApiContainer.DslrCamera.StopExposure();
        }

        public short BayerOffsetX { get { return 0; } }

        public short BayerOffsetY { get { return 0; } }

        public short BinX
        {
            get; set;
        }

        public short BinY
        {
            get; set;
        }

        public double CCDTemperature
        {
            get
            {
                return ApiContainer.DslrCamera.SensorTemperature;
            }
        }

        public CameraStates CameraState
        {
            get
            {
                return _cameraState;
            }
        }

        public int CameraXSize
        {
            get
            {
                return ApiContainer.DslrCamera.FrameWidth;
            }
        }

        public int CameraYSize
        {
            get
            {
                return ApiContainer.DslrCamera.FrameHeight;
            }
        }

        public bool CanAbortExposure { get { return true; } }

        public bool CanAsymmetricBin { get { return false; } }

        public bool CanFastReadout { get { return false; } }

        public bool CanGetCoolerPower { get { return false; } }

        public bool CanPulseGuide { get { return false; } }

        public bool CanSetCCDTemperature { get { return false; } }

        public bool CanStopExposure { get { return false; } }

        public bool CoolerOn { get { return false; } set { } }

        public double CoolerPower { get { return 0; } }

        public double ElectronsPerADU { get { return 1; } }

        public double ExposureMax { get { return double.MaxValue; } }

        public double ExposureMin { get { return 0; } }

        public double ExposureResolution { get { return 0.01; } }

        public bool FastReadout { get { return false; } set { } }

        public double FullWellCapacity { get { return short.MaxValue; } }

        public short Gain
        {
            get
            {
                return ApiContainer.DslrCamera.Iso;
            }
            set
            {
                ApiContainer.DslrCamera.Iso = value;
            }
        }

        public short GainMax { get { return ApiContainer.DslrCamera.MaxIso; } }

        public short GainMin { get { return ApiContainer.DslrCamera.MinIso; } }

        public ArrayList Gains
        {
            get
            {
                var iso = ApiContainer.DslrCamera.IsoValues.Select(i => "ISO" + i.ToString()).ToArray();
                return new ArrayList(iso);
            }
        }

        public bool HasShutter { get { return true; } }

        public double HeatSinkTemperature { get { return 20; } }

        public object ImageArray
        {
            get
            {            
                return cameraImageArray;                
            }
        }

        public object ImageArrayVariant
        {
            get
            {
                return cameraImageArray;
            }
        }

        public bool ImageReady
        {
            get
            {
                if (_cameraState == CameraStates.cameraError)
                {
                    throw new NotConnectedException(ErrorMessages.NotConnected);
                }
                return cameraImageReady;
            }
        }

        public bool IsPulseGuiding
        {
            get
            {
                return false;
            }
        }

        public double LastExposureDuration
        {
            get
            {
                if (!cameraImageReady)
                {
                    throw new ASCOM.InvalidOperationException("Call to LastExposureDuration before the first image has been taken!");
                }
                return cameraLastExposureDuration;
            }
        }

        public string LastExposureStartTime
        {
            get
            {
                if (!cameraImageReady)
                {
                    throw new ASCOM.InvalidOperationException("Call to LastExposureStartTime before the first image has been taken!");
                }

                string exposureStartString = exposureStart.ToString("yyyy-MM-ddTHH:mm:ss");
                return exposureStartString;
            }
        }

        public int MaxADU
        {
            get
            {
                int maxValue = 0;
                switch (CameraSettings.CameraMode)
                {
                    case Enums.CameraMode.RGGB:
                    case Enums.CameraMode.Color16:
                        maxValue = short.MaxValue;
                        break;

                    case Enums.CameraMode.ColorJpg:
                        maxValue = byte.MaxValue;
                        break;
                }

                return maxValue;
            }
        }

        public short MaxBinX
        {
            get
            {
                return (short)(CameraSettings.EnableBinning ? 4 : 1);
            }
        }

        public short MaxBinY { get { return MaxBinX; } }

        public int StartX { get; set; }

        public int StartY { get; set; }

        public int NumX { get; set; }

        public int NumY { get; set; }

        public short PercentCompleted { get { return 100; } }

        public double PixelSizeX
        {
            get
            {
                return ApiContainer.DslrCamera.PixelSizeX * BinX;
            }
        }

        public double PixelSizeY
        {
            get
            {
                return ApiContainer.DslrCamera.PixelSizeY * BinY;
            }
        }

        public void PulseGuide(GuideDirections Direction, int Duration) { }

        public short ReadoutMode { get; set; }

        public ArrayList ReadoutModes
        {
            get
            {
                return new ArrayList();
            }
        }

        public string SensorName
        {
            get
            {
                return ApiContainer.DslrCamera.Model;
            }
        }

        public SensorType SensorType
        {
            get
            {
                SensorType sensorType;

                if (CameraSettings.LiveViewCaptureMode)
                {
                    sensorType = SensorType.Monochrome;
                }
                else
                {
                    switch (CameraSettings.CameraMode)
                    {
                        case CameraMode.RGGB:
                            sensorType = CameraSettings.EnableBinning ? SensorType.Monochrome : SensorType.RGGB;
                            break;
                        case CameraMode.Color16:
                        case CameraMode.ColorJpg:
                            sensorType = SensorType.Color;
                            break;
                        default:
                            sensorType = SensorType.RGGB;
                            break;
                    }
                }

                return sensorType;
            }
        }

        public double SetCCDTemperature
        {
            get
            {
                return CCDTemperature;
            }
            set
            {
            }
        }

       

        #endregion
    }
}
