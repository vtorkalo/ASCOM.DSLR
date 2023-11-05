using ASCOM.DSLR.Enums;
using ASCOM.DSLR.Interfaces;
using ASCOM.Utilities;
using CameraControl.Devices;
using CameraControl.Devices.Classes;
using CameraControl.Plugins.ExternalDevices;
using Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
//using System.Windows.Forms;

namespace ASCOM.DSLR.Classes
{
    public class DigiCamControlCamera : BaseCamera, IDslrCamera
    {
        public string Model
        {
            get
            {
                string model = string.Empty;
                if (_cameraModel != null)
                {
                    Logger.WriteTraceMessage("Model");
                    model = _cameraModel.Name;
                }

                return model;
            }
        }


        public CameraDeviceManager DeviceManager { get; set; }

        public ConnectionMethod IntegrationApi => ConnectionMethod.NikonLegacy;

        public bool SupportsViewView { get { return false; } }

        public event EventHandler<ImageReadyEventArgs> ImageReady;
        public event EventHandler<ExposureFailedEventArgs> ExposureFailed;
        public event EventHandler<LiveViewImageReadyEventArgs> LiveViewImageReady;

        private TraceLogger _tl;


        public DigiCamControlCamera(TraceLogger tl, List<CameraModel> cameraModelHistory) : base(cameraModelHistory)
        {
            Logger.WriteTraceMessage("DigiCamControlCamera");
            _tl = tl;
            DeviceManager = new CameraDeviceManager();
            DeviceManager.CameraSelected += DeviceManager_CameraSelected;
            DeviceManager.CameraConnected += DeviceManager_CameraConnected;
            DeviceManager.PhotoCaptured += DeviceManager_PhotoCaptured;
            DeviceManager.CameraDisconnected += DeviceManager_CameraDisconnected;

            // For experimental Canon driver support- to use canon driver the canon sdk files should be copied in application folder
            DeviceManager.UseExperimentalDrivers = true;
            DeviceManager.DisableNativeDrivers = false;
            DeviceManager.DetectWebcams = false;
            DeviceManager.LoadWiaDevices = true;
            Log.LogError += Log_LogError;
            Log.LogDebug += Log_LogError;
            Log.LogInfo += Log_LogError;

        }

        public void AbortExposure()
        {
            _canceled.IsCanceled = true;
        }

        private void LogProperties(PropertyValue<long> properties)
        {
            StringBuilder propsStr = new StringBuilder(properties.Name + ": ");
            foreach (var p in properties.Values)
            {
                propsStr.Append(p);
                propsStr.Append(":");
            }
            _tl.LogMessage("Property values", propsStr.ToString());
        }

        public void ConnectCamera()
        {
            Logger.WriteTraceMessage("ConnectCamera");
            DeviceManager.ConnectToCamera();
            var camera = DeviceManager.SelectedCameraDevice;
            LogCameraInfo(camera);
  
        }

  

        private void LogCameraInfo(ICameraDevice camera)
        {
            _tl.LogMessage("DeviceName", camera.DeviceName);

            if (camera.IsoNumber != null) LogProperties(camera.IsoNumber);
            if (camera.ShutterSpeed != null) LogProperties(camera.ShutterSpeed);
            if (camera.FNumber != null) LogProperties(camera.FNumber);
            if (camera.Mode != null) LogProperties(camera.Mode);
            if (camera.FocusMode != null) LogProperties(camera.FocusMode);
            if (camera.CompressionSetting != null) LogProperties(camera.CompressionSetting);



            foreach (var p in camera.Properties)
            {
                LogProperties(p);
            }

            foreach (var p in camera.AdvancedProperties)
            {
                LogProperties(p);
            }
        }

        public void DisconnectCamera()
        {
            foreach (var device in DeviceManager.ConnectedDevices.ToList())
            {
                DeviceManager.DisconnectCamera(device);
            }
        }

        public void Dispose()
        {
            DisconnectCamera();
        }

        public override CameraModel ScanCameras()
        {
            Logger.WriteTraceMessage("ScanCamera");
            var cameraDevice = DeviceManager.SelectedCameraDevice;
            var cameraModel = GetCameraModel(cameraDevice.DeviceName);

            return cameraModel;
        }

        private double ParseValue(string valueStr)
        {
            valueStr = valueStr.Replace(',', '.');
            double value = 0;
            if (!double.TryParse(valueStr, out value))
            {
                if (valueStr.Contains("/"))
                {
                    value = ParseValue(valueStr.Split('/').Last());
                    if (value > 0)
                    {
                        value = 1 / value;
                    }
                }
            }

            return value;
        }

        private string GetNearesetValue(PropertyValue<long> propertyValue, double value)
        {
            Logger.WriteTraceMessage("GetNearesetValue: " + value.ToString());
            string nearest = propertyValue.Values.Select(v =>
            {

                double doubleValue = ParseValue(v);
                return new
                {
                    ValueStr = v,
                    DoubleValue = doubleValue,
                    Difference = Math.Abs(doubleValue - value)
                };
            }).Where(i => i.DoubleValue > 0).OrderBy(i => i.Difference).First().ValueStr;

            return nearest;
        }


        DigiCamCanceledFlag _canceled = new DigiCamCanceledFlag();
        private double _duration;
        private DateTime _startTime;

        public void StartExposure(double Duration, bool Light)
        {
            Logger.WriteTraceMessage("StartExposure");
            _canceled.IsCanceled = false;

            _startTime = DateTime.Now;
            _duration = Duration;
            var camera = DeviceManager.SelectedCameraDevice;
            Logger.WriteTraceMessage("Device Selected: " + camera.DeviceName);
            camera.IsoNumber.Value = GetNearesetValue(camera.IsoNumber, Iso);
            Logger.WriteTraceMessage("GetNearesetValue ISO: " + Iso.ToString());
            camera.CompressionSetting.Value = camera.CompressionSetting.Values.SingleOrDefault(v => v.ToUpper() == "RAW");
            Logger.WriteTraceMessage("SetRaw: ");
            bool canBulb = camera.GetCapability(CapabilityEnum.Bulb);
            Logger.WriteTraceMessage("CanBulb: " + canBulb.ToString());
            Logger.WriteTraceMessage("Exposure Duration: " + Duration.ToString());
            if (Duration > 30)
            {
                int durationMsec = (int)(Duration * 1000);
                if (UseExternalShutter)
                {
                    ThreadPool.QueueUserWorkItem(state =>
                    {
                        var _serialPortShutter = new SerialPortShutterRelease(ExternalShutterPort);
                        BulbExposure(durationMsec, _canceled, _serialPortShutter.OpenShutter, _serialPortShutter.CloseShutter);
        
                    });
                }
                else
                {
                    if (canBulb)
                    {
                        ThreadPool.QueueUserWorkItem(state =>
                        {
                            Logger.WriteTraceMessage("Start BulbExposure");
                            BulbExposure(durationMsec, _canceled, camera.StartBulbMode, camera.EndBulbMode);
                            Logger.WriteTraceMessage("End BulbExposure");
                        });
                    }
                }
            }
            else
            {
                if (Duration >= 1)
                {
                    camera.ShutterSpeed.Value = Duration + "s";
                }
                else {
                    camera.ShutterSpeed.Value = GetNearesetValue(camera.ShutterSpeed, Duration);
                }
                Logger.WriteTraceMessage("GetNearesetValue Shutter");
                DeviceManager.SelectedCameraDevice.CapturePhoto();
                Logger.WriteTraceMessage("CapturePhoto");
            }
        }


        private void BulbExposure(int bulbTime, DigiCamCanceledFlag canceledFlag, Action startBulb, Action endBulb)
        {
            startBulb();

            int seconds = bulbTime / 1000;
            int milliseconds = bulbTime % 1000;

            Thread.Sleep(milliseconds);
            for (int i = 1; i <= seconds; i++)
            {
                Thread.Sleep(1000);
                if (canceledFlag.IsCanceled)
                {
                    canceledFlag.IsCanceled = false;
                    break;
                }
            }
            endBulb();
        }

        public void StopExposure()
        {
            AbortExposure();
        }

        private void Log_LogError(LogEventArgs e)
        {
            //Investigate why error
            //_tl.LogMessage(e.Message.ToString(), e.Exception?.Message);
            //Logger.WriteTraceMessage(e.Message.ToString());
        }


        private void PhotoCaptured(PhotoCapturedEventArgs eventArgs)
        {
            _tl.LogMessage("Photo captured filename", eventArgs.FileName);

            string fileName = GetFileNameForDownload(eventArgs);
            if (!Directory.Exists(Path.GetDirectoryName(fileName)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(fileName));
            }

            eventArgs.CameraDevice.TransferFile(eventArgs.Handle, fileName);

            SensorTemperature = GetSensorTemperature(fileName);

            string newFilePath = RenameFile(fileName, _duration, _startTime);
            ImageReady?.Invoke(this, new ImageReadyEventArgs(newFilePath));

            if ((File.Exists(newFilePath)) && (SaveFile == false))
            {
                File.Delete(newFilePath);
            }

            eventArgs.CameraDevice.IsBusy = false;
        }

        private string GetFileNameForDownload(PhotoCapturedEventArgs eventArgs)
        {
            string fileName = Path.Combine(StorePath, Path.GetFileName(eventArgs.FileName));
            
            if (string.IsNullOrEmpty(Path.GetExtension(fileName)))
            {
                fileName = Path.ChangeExtension(fileName, "nef");
            }
            
            if (File.Exists(fileName))
                fileName =
                  StaticHelper.GetUniqueFilename(
                    Path.GetDirectoryName(fileName) + "\\" + Path.GetFileNameWithoutExtension(fileName) + "_", 0,
                    Path.GetExtension(fileName));

            return fileName;
        }

        void DeviceManager_CameraDisconnected(ICameraDevice cameraDevice)
        {
        }

        void DeviceManager_PhotoCaptured(object sender, PhotoCapturedEventArgs eventArgs)
        {
            //if (eventArgs.FileName.ToUpper().Contains(eventArgs.CameraDevice.CompressionSetting.Value))
            //{
              PhotoCaptured(eventArgs);
            //}
        }
    
            void DeviceManager_CameraConnected(ICameraDevice cameraDevice)
        {


        }

        void DeviceManager_CameraSelected(ICameraDevice oldcameraDevice, ICameraDevice newcameraDevice)
        {

        }
    }


    public class DigiCamCanceledFlag
    {
        public bool IsCanceled = false;
    }
}
