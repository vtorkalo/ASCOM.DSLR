using ASCOM.Astrometry.AstroUtils;
using ASCOM.DeviceInterface;
using ASCOM.DSLR.Classes;
using ASCOM.DSLR.Enums;
using ASCOM.DSLR.Interfaces;
using ASCOM.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

        private static void CreateCamera()
        {
            if (_cameraSettings.IntegrationApi == Enums.IntegrationApi.CanonSdk)
            {
                _dslrCamera = new CanonSdkCamera();
                _dslrCamera.InitApi();
            }
            else if (_cameraSettings.IntegrationApi == Enums.IntegrationApi.BackyardEOS)
            {
                _dslrCamera = new BackyardEosCamera(_cameraSettings.BackyardEosPort);
            }
        }

        private static CameraSettings _cameraSettings { get; set; }

        public static void SetSettings(CameraSettings settings)
        {
            _cameraSettings = settings;
        }
    }

    public partial class Camera
    {
        private CameraSettingsProvider _settingsProvider;

        private LibRawWrapper _libRawWrapper;
        private CameraStates _cameraState = CameraStates.cameraIdle;

        public Camera()
        {
            _settingsProvider = new CameraSettingsProvider();
            ReadProfile();

            _libRawWrapper = new LibRawWrapper();

            tl = new TraceLogger("", "DSLR");
            tl.Enabled = CameraSettings.TraceLog;
            connectedState = false;
        }

        private void _dslrCamera_ImageReady(object sender, ImageReadyEventArgs args)
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
            UnsubscribeCameraEvents();
        }

        protected void Init()
        {

        }

        #region ICamera Implementation

        private DateTime exposureStart = DateTime.MinValue;
        private double cameraLastExposureDuration = 0.0;
        private bool cameraImageReady = false;

        private Array cameraImageArray;

        //private Array cameraImageArrayColor;

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

        public short Gain { get; set; }

        public short GainMax { get { return ApiContainer.DslrCamera.MaxIso; } }

        public short GainMin { get { return ApiContainer.DslrCamera.MinIso; } }

        public ArrayList Gains { get { return new ArrayList(ApiContainer.DslrCamera.IsoValues); } }

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
                        maxValue = CameraSettings.EnableBinning && CameraSettings.BinningMode == BinningMode.Sum ?
                            (int) Math.Pow(2, 14) * MaxBinX * MaxBinY
                         : (int)Math.Pow(2, 14);
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

        public short ReadoutMode { get { throw new PropertyNotImplementedException(); } set { throw new PropertyNotImplementedException(); } }

        public ArrayList ReadoutModes { get { return new ArrayList(); } }

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
                switch (CameraSettings.CameraMode)
                {
                    case Enums.CameraMode.RGGB:
                        sensorType = CameraSettings.EnableBinning ? SensorType.Monochrome : SensorType.RGGB;
                        break;
                    case Enums.CameraMode.Color16:
                    case Enums.CameraMode.ColorJpg:
                        sensorType = SensorType.Color;
                        break;
                    default:
                        sensorType = SensorType.RGGB;
                        break;
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

        public void StartExposure(double Duration, bool Light)
        {
            cameraImageReady = false;

            if (Duration < 0.0) throw new InvalidValueException("StartExposure", Duration.ToString(), "0.0 upwards");

            cameraLastExposureDuration = Duration;
            exposureStart = DateTime.Now;
            tl.LogMessage("StartExposure", Duration.ToString() + " " + Light.ToString());
            _cameraState = CameraStates.cameraExposing;
            SetCameraSettings(ApiContainer.DslrCamera, CameraSettings);

            ApiContainer.DslrCamera.ImageReady += _dslrCamera_ImageReady;
            ApiContainer.DslrCamera.ExposureFailed += DslrCamera_ExposureFailed;

            try
            {
                ApiContainer.DslrCamera.StartExposure(Duration, Light);
            }
            catch (Exception ex)
            {
                LogError("Exposure failed", ex);
                throw new NotConnectedException(ErrorMessages.NotConnected);
            }
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
                case Enums.CameraMode.RGGB:
                case Enums.CameraMode.Color16:
                    camera.ImageFormat = Enums.ImageFormat.RAW;
                    break;
                case Enums.CameraMode.ColorJpg:
                    camera.ImageFormat = Enums.ImageFormat.JPEG;
                    break;
            }
        }

        private void PrepareCameraImageArray(string rawFileName)
        {

            if (CameraSettings.CameraMode == Enums.CameraMode.Color16)
            {
                cameraImageArray = _libRawWrapper.ReadAndDebayerRaw(rawFileName);
            }
            else if (CameraSettings.CameraMode == Enums.CameraMode.ColorJpg)
            {
                cameraImageArray = _libRawWrapper.ReadJpeg(rawFileName);
            }
            else if (CameraSettings.CameraMode == Enums.CameraMode.RGGB)
            {
                cameraImageArray = _libRawWrapper.ReadRaw(rawFileName);
            }

            if (BinX > 1 || BinY > 1)
            {
                cameraImageArray = Binning(cameraImageArray, BinX, BinY);
            }
            cameraImageArray = CutArray(cameraImageArray);

            cameraImageReady = true;
            _cameraState = CameraStates.cameraIdle;
        }

        private bool IsCutRequired(int dataXsize, int dataYsize)
        {
            bool sizeMatches = StartX == 0 && StartY == 0 && NumX == CameraXSize && NumY == CameraYSize
                && dataXsize == CameraXSize && dataYsize == CameraYSize;

            bool cut = !(sizeMatches || NumX == 0 || NumY == 0);
            return cut;
        }

        private Array CutArray(Array data)
        {
            Array result = null;
            int rank = data.Rank;

            if (IsCutRequired(data.GetLength(0), data.GetLength(1)))
            {
                int startXCorrected = StartX % 2 == 0 ? StartX : StartX - 1;
                int startYCorrected = StartY % 2 == 0 ? StartY : StartY - 1;

                result = rank == 3 ? Array.CreateInstance(typeof(int), NumX, NumY, 3)
                                   : Array.CreateInstance(typeof(int), NumX, NumY);

                for (int x = 0; x < NumX; x++)
                    for (int y = 0; y < NumY; y++)
                    {
                        int dataX = startXCorrected + x;
                        int dataY = startYCorrected + y;
                        if (rank == 3)
                        {
                            for (int r = 0; r < 3; r++)
                            {
                                result.SetValue(data.GetValue(dataX, dataY, r), x, y, r);
                            }
                        }
                        else
                        {
                            result.SetValue(data.GetValue(dataX, dataY), x, y);
                        }
                    }
            }
            else
            {
                result = data;
            }
            return result;
        }

        public int GetMedian(IEnumerable<int> sourceNumbers)
        {
            int[] sortedPNumbers = sourceNumbers.OrderBy(n => n).ToArray();

            int size = sortedPNumbers.Length;
            int mid = size / 2;
            int median = (size % 2 != 0) ? sortedPNumbers[mid] : (sortedPNumbers[mid] + sortedPNumbers[mid - 1]) / 2;
            return median;
        }

        public int GetSum(IEnumerable<int> sourceNumbers, int binx, int biny)
        {
            int binCount = binx * biny;
            var sum = sourceNumbers.Sum();

            if (binCount>4)
            {
                sum = sum >> 2;
            }
            
            return sum;
        }

        private Array Binning(Array data, int binx, int biny)
        {
            int width = data.GetLength(0);
            int height = data.GetLength(1);
            int binWidth = width / binx;
            int binHeight = height / biny;

            var result = Array.CreateInstance(typeof(int), binWidth, binHeight);

            for (int x = 0; x < binWidth; x++)
                for (int y = 0; y < binHeight; y++)
                {
                    var binBlockData = new List<int>();
                    for (int x2 = x * binx; x2 < x * binx + binx; x2++)
                        for (int y2 = y * biny; y2 < y * biny + biny; y2++)
                        {
                            binBlockData.Add((int)data.GetValue(x2, y2));
                        }

                    int value = 0;
                    switch(CameraSettings.BinningMode)
                    {
                        case BinningMode.Sum:
                            value = GetSum(binBlockData, binx, biny);
                            break;
                        case BinningMode.Median:
                            value = GetMedian(binBlockData);
                            break;
                    }
                    result.SetValue(value, x, y);
                }

            return result;
        }

        public void AbortExposure()
        {
            ApiContainer.DslrCamera.AbortExposure();
        }

        public void StopExposure()
        {
            ApiContainer.DslrCamera.StopExposure();
        }

        #endregion
    }
}
