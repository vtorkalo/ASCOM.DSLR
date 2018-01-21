using ASCOM.DSLR.Enums;
using ASCOM.DSLR.Interfaces;
using CameraControl.Devices;
using CameraControl.Devices.Classes;
using CameraControl.Devices.Wifi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ASCOM.DSLR.Classes
{
    public class DigiCamControlCamera : BaseCanonCamera, IDslrCamera
    {
        public string Model
        {
            get
            {
                string model = string.Empty;
                if (_cameraModel != null)
                {
                    model = _cameraModel.Names.First();
                }

                return model;
            }
        }

        public CameraDeviceManager DeviceManager { get; set; }

        public IntegrationApi IntegrationApi => IntegrationApi.DigiCamControl;

        public event EventHandler<ImageReadyEventArgs> ImageReady;
        public event EventHandler<ExposureFailedEventArgs> ExposureFailed;

        public DigiCamControlCamera()
        {
            DeviceManager = new CameraDeviceManager();
            DeviceManager.CameraSelected += DeviceManager_CameraSelected;
            DeviceManager.CameraConnected += DeviceManager_CameraConnected;
            DeviceManager.PhotoCaptured += DeviceManager_PhotoCaptured;
            DeviceManager.CameraDisconnected += DeviceManager_CameraDisconnected;

            // For experimental Canon driver support- to use canon driver the canon sdk files should be copied in application folder
            DeviceManager.UseExperimentalDrivers = true;
            DeviceManager.DisableNativeDrivers = false;
            Log.LogError += Log_LogError;
            Log.LogDebug += Log_LogError;
            Log.LogInfo += Log_LogError;

            DeviceManager.ConnectToCamera();
        }

        public void AbortExposure()
        {
            _canceled.IsCanceled = true;
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

        public override CameraModel ScanCameras()
        {
            var cameraDevice= DeviceManager.SelectedCameraDevice;
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
                    if (value >0)
                    {
                        value = 1 / value;
                    }
                }
            }

            return value;
        }

        private string GetNearesetValue(PropertyValue<long> propertyValue, double value)
        {
            string nearest = propertyValue.Values.Select(v =>
            {
                double doubleValue = ParseValue(v);
                return new
                {
                    ValueStr = v,
                    DoubleValue = doubleValue,
                    Difference = Math.Abs(doubleValue - value)
                };
            }).Where(i=>i.DoubleValue>0).OrderBy(i => i.Difference).First().ValueStr;

            return nearest;
        }



        DigiCamCanceledFlag _canceled = new DigiCamCanceledFlag();
        private double _duration;
        private DateTime _startTime;

        public void StartExposure(double Duration, bool Light)
        {
            DeviceManager.ConnectToCamera();
            _canceled.IsCanceled = false;
            DeviceManager.SelectedCameraDevice.IsoNumber.Value = GetNearesetValue(DeviceManager.SelectedCameraDevice.IsoNumber, Iso);
            _startTime = DateTime.Now;
            _duration = Duration;

            if (Duration>1)
            {
                ThreadPool.QueueUserWorkItem(state =>
                {
                    BulbExposure((int)(Duration * 1000), _canceled);
                });
            }
            else
            {
                DeviceManager.SelectedCameraDevice.ShutterSpeed.Value = GetNearesetValue(DeviceManager.SelectedCameraDevice.ShutterSpeed, Duration);
                DeviceManager.SelectedCameraDevice.CapturePhoto();
            }
        }


        private void BulbExposure(int bulbTime, DigiCamCanceledFlag canceledFlag)
        {
            DeviceManager.SelectedCameraDevice.StartBulbMode();
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

            DeviceManager.SelectedCameraDevice.EndBulbMode();
        }

        public void StopExposure()
        {
            AbortExposure();            
        }
        
 
        private void Log_LogError(LogEventArgs e)
        {
            if (e.Exception != null)
            {
                ExposureFailed?.Invoke(this, new ExposureFailedEventArgs(e.Exception.Message, e.Exception.StackTrace));
            }
        }
    
        private void PhotoCaptured(PhotoCapturedEventArgs eventArgs)
        {
            string fileName = GetFileNameForDownload(eventArgs);
            if (!Directory.Exists(Path.GetDirectoryName(fileName)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(fileName));
            }

            eventArgs.CameraDevice.TransferFile(eventArgs.Handle, fileName);

            SensorTemperature = GetSensorTemperature(fileName);

            string newFilePath = RenameFile(fileName, _duration, _startTime); ;
            ImageReady?.Invoke(this, new ImageReadyEventArgs(newFilePath));


            eventArgs.CameraDevice.IsBusy = false;
          //  DeviceManager.DisconnectCamera(DeviceManager.SelectedCameraDevice);
        }

        private string GetFileNameForDownload(PhotoCapturedEventArgs eventArgs)
        {
            string fileName = Path.Combine(StorePath, Path.GetFileName(eventArgs.FileName));
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
            PhotoCaptured(eventArgs);
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
