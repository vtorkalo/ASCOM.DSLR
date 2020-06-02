using ASCOM.DSLR.Enums;
using ASCOM.DSLR.Interfaces;
using Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Nikon;
using ASCOM.Utilities;
using System.Threading.Tasks;

namespace ASCOM.DSLR.Classes
{
    public class NikonSdkCamera : BaseCamera, IDslrCamera
    {

        private List<NikonManager> _nikonManagers;
        private NikonManager manager;
        private NikonDevice device;

        AutoResetEvent _waitForDevice = new AutoResetEvent(false);
        AutoResetEvent _waitForCaptureComplete = new AutoResetEvent(false);

        private double _duration;
        private DateTime _startTime;

        public string Model
        {
            get
            {
                string model = string.Empty;
                if (_cameraModel != null)
                {
                    model = _cameraModel.Name;
                }

                return model;
            }
        }

        public NikonSdkCamera(List<CameraModel> cameraModelsHistory) : base(cameraModelsHistory)
        {
            // Initialize Nikon manager
            _nikonManagers = new List<NikonManager>();

            manager = new NikonManager("Type0003.md3");
            manager.DeviceAdded += new DeviceAddedDelegate(manager_DeviceAdded);
            manager.DeviceRemoved += new DeviceRemovedDelegate(manager_DeviceRemoved);
        }

        void manager_DeviceAdded(NikonManager sender, NikonDevice device)
        {
            this.device = device;

            // Set the device name
            _cameraModel.Name = device.Name;

            // Hook up device capture events

            device.ImageReady += new ImageReadyDelegate(device_ImageReady);
            device.CaptureComplete += new CaptureCompleteDelegate(device_CaptureComplete);
            Logger.WriteDebugMessage("Setting compression to RAW");
            var compression = this.device.GetEnum(eNkMAIDCapability.kNkMAIDCapability_CompressionLevel);
            for (int i = 0; i < compression.Length; i++)
            {
                var val = compression.GetEnumValueByIndex(i);
                if (val.ToString() == "RAW")
                {
                    compression.Index = i;
                    this.device.SetEnum(eNkMAIDCapability.kNkMAIDCapability_CompressionLevel, compression);
                    break;
                }

            }

            GetShutterSpeeds();
            GetCapabilities();

            /* Setting SaveMedia when supported, to save images via SDRAM and not to the internal memory card */
            if (Capabilities.ContainsKey(eNkMAIDCapability.kNkMAIDCapability_SaveMedia) && Capabilities[eNkMAIDCapability.kNkMAIDCapability_SaveMedia].CanSet())
            {
                this.device.SetUnsigned(eNkMAIDCapability.kNkMAIDCapability_SaveMedia, (uint)eNkMAIDSaveMedia.kNkMAIDSaveMedia_SDRAM);
            }
            else
            {
                Logger.WriteTraceMessage("Setting SaveMedia Capability not available. This has to be set manually or is not supported by this model.");
            }

        }

        private Dictionary<eNkMAIDCapability, NkMAIDCapInfo> Capabilities = new Dictionary<eNkMAIDCapability, NkMAIDCapInfo>();

        private void GetCapabilities()
        {
            Logger.WriteDebugMessage("Getting Nikon capabilities");
            Capabilities.Clear();
            foreach (NkMAIDCapInfo info in device.GetCapabilityInfo())
            {
                Capabilities.Add(info.ulID, info);

                var description = info.GetDescription();
                var canGet = info.CanGet();
                var canGetArray = info.CanGetArray();
                var canSet = info.CanSet();
                var canStart = info.CanStart();

                Logger.WriteDebugMessage(description);
                Logger.WriteDebugMessage("\t Id: " + info.ulID.ToString());
                Logger.WriteDebugMessage("\t CanGet: " + canGet.ToString());
                Logger.WriteDebugMessage("\t CanGetArray: " + canGetArray.ToString());
                Logger.WriteDebugMessage("\t CanSet: " + canSet.ToString());
                Logger.WriteDebugMessage("\t CanStart: " + canStart.ToString());

                if (info.ulID == eNkMAIDCapability.kNkMAIDCapability_ShutterSpeed && !canSet)
                {
                    throw new NikonException("Cannot set shutterspeeds. Please make sure the camera dial is set to a position where bublb mode is possible and the mirror lock is turned off");
                }
            }
        }

        private void GetShutterSpeeds()
        {
            Logger.WriteDebugMessage("Getting Nikon shutter speeds");
            _shutterSpeeds.Clear();
            var shutterSpeeds = device.GetEnum(eNkMAIDCapability.kNkMAIDCapability_ShutterSpeed);
            Logger.WriteDebugMessage("Available Shutterspeeds: " + shutterSpeeds.Length);
            bool bulbFound = false;
            for (int i = 0; i < shutterSpeeds.Length; i++)
            {
                try
                {
                    var val = shutterSpeeds.GetEnumValueByIndex(i).ToString();
                    Logger.WriteDebugMessage("Found Shutter speed: " + val);
                    if (val.Contains("/"))
                    {
                        var split = val.Split('/');
                        var convertedSpeed = double.Parse(split[0], CultureInfo.InvariantCulture) / double.Parse(split[1], CultureInfo.InvariantCulture);

                        _shutterSpeeds.Add(i, convertedSpeed);
                    }
                    else if (val.ToLower() == "bulb")
                    {
                        Logger.WriteDebugMessage("Bulb index: " + i);
                        _bulbShutterSpeedIndex = i;
                        bulbFound = true;
                    }
                    else if (val.ToLower() == "time")
                    {
                        //currently unused
                    }
                    else
                    {
                        _shutterSpeeds.Add(i, double.Parse(val));
                    }
                }
                catch (Exception ex)
                {
                    Logger.WriteErrorMessage("Unexpected Shutter Speed: " + ex.Message);
                }
            }
            if (!bulbFound)
            {
                Logger.WriteErrorMessage("No Bulb speed found!");
                throw new NikonException("Failed to find the 'Bulb' exposure mode");
            }
        }


        void device_ImageReady(NikonDevice sender, NikonImage image)
        {

            if (!Directory.Exists(StorePath))
            {
                Directory.CreateDirectory(StorePath);
            }
     
            string filename = "image" + ((image.Type == NikonImageType.Jpeg) ? ".jpg" : ".nef");

            string downloadedFilePath = Path.Combine(StorePath, filename);

            using (FileStream s = new FileStream(downloadedFilePath, FileMode.Create, FileAccess.Write))
            {
                s.Write(image.Buffer, 0, image.Buffer.Length);
            }

            string newFilePath = RenameFile(downloadedFilePath, _duration, _startTime);
            ImageReady?.Invoke(this, new ImageReadyEventArgs(newFilePath));

            if ((File.Exists(newFilePath)) && (SaveFile == false))
            {
                File.Delete(newFilePath);
            }

        }

        void manager_DeviceRemoved(NikonManager sender, NikonDevice device)
        {
            this.device = null;

        }

        void device_CaptureComplete(NikonDevice sender, int data)
        {
            // Signal the the capture completed
            _waitForCaptureComplete.Set();
        }

        public bool SupportsViewView { get { return false; } }

        public ConnectionMethod IntegrationApi => ConnectionMethod.Nikon;

        public event EventHandler<ImageReadyEventArgs> ImageReady;
        public event EventHandler<LiveViewImageReadyEventArgs> LiveViewImageReady;
        public event EventHandler<ExposureFailedEventArgs> ExposureFailed;

        public void AbortExposure()
        {
              device.StopBulbCapture();
        }

        public void ConnectCamera()
        {

            string architecture =  IntPtr.Size == 4 /* 32bit */ ? "x86" : "x64";

            var md3Folder = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "SDK", architecture, "Nikon");

            foreach (string file in Directory.GetFiles(md3Folder, "*.md3", SearchOption.AllDirectories))
            {
                NikonManager mgr = new NikonManager(file);
                mgr.DeviceAdded += new DeviceAddedDelegate(manager_DeviceAdded);
                _nikonManagers.Add(mgr);
            }

   

        }

        public void DisconnectCamera()
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public override CameraModel ScanCameras()
        {
            throw new System.NotImplementedException();
        }

        private Dictionary<int, double> _shutterSpeeds = new Dictionary<int, double>();
        private int _bulbShutterSpeedIndex;

        public void StartExposure(double Duration, bool Light)
        {
                double exposureTime = Duration;
                Logger.WriteDebugMessage("Prepare start of exposure: ");

                if (exposureTime <= 30.0)
                {
                    Logger.WriteDebugMessage("Exposuretime <= 30. Setting automatic shutter speed.");
                    var speed = _shutterSpeeds.Aggregate((x, y) => Math.Abs(x.Value - exposureTime) < Math.Abs(y.Value - exposureTime) ? x : y);
                    SetCameraShutterSpeed(speed.Key);

                    Logger.WriteDebugMessage("Start capture");
                    device.Capture();
                }
                else
                {
                    exposureTime = Duration * 1000;
                    BulbCapture(Convert.ToInt16(exposureTime), StartBulbCapture, StopBulbCapture);
                }
        }

        private void StartBulbCapture()
        {
            device.StartBulbCapture();
        }

        private void StopBulbCapture()
        {
            device.StopBulbCapture();
        }

        private void SetCameraShutterSpeed(int index)
        {
            if (Capabilities.ContainsKey(eNkMAIDCapability.kNkMAIDCapability_ShutterSpeed) && Capabilities[eNkMAIDCapability.kNkMAIDCapability_ShutterSpeed].CanSet())
            {
                Logger.WriteDebugMessage("Setting shutter speed to index: " + index);
                var shutterspeed = device.GetEnum(eNkMAIDCapability.kNkMAIDCapability_ShutterSpeed);
                _prevShutterSpeed = shutterspeed.Index;
                shutterspeed.Index = index;
                device.SetEnum(eNkMAIDCapability.kNkMAIDCapability_ShutterSpeed, shutterspeed);
            }
            else
            {
                Logger.WriteDebugMessage("Cannot set camera shutter speed. Skipping...");
            }
        }

        private void BulbCapture(int exposureTime, Action capture, Action stopCapture)
        {
            SetCameraToManual();

            SetCameraShutterSpeed(_bulbShutterSpeedIndex);

            try
            {
                Logger.WriteDebugMessage("Starting bulb capture");
                capture();
            }
            catch (NikonException ex)
            {
                if (ex.ErrorCode != eNkMAIDResult.kNkMAIDResult_BulbReleaseBusy)
                {
                    throw;
                }
            }

            /*Stop Exposure after exposure time */
            int seconds =  exposureTime / 1000;
            int milliseconds = exposureTime % 1000;

            Thread.Sleep(milliseconds);
            for (int i = 1; i <= seconds; i++)
            {
                Thread.Sleep(1000);
            }

            stopCapture();

            Logger.WriteDebugMessage("Restore previous shutter speed");
            // Restore original shutter speed
            SetCameraShutterSpeed(_prevShutterSpeed);

        }

    private int _prevShutterSpeed;

    private void SetCameraToManual()
        {
            Logger.WriteDebugMessage("Set camera to manual exposure");
            if (Capabilities.ContainsKey(eNkMAIDCapability.kNkMAIDCapability_ExposureMode) && Capabilities[eNkMAIDCapability.kNkMAIDCapability_ExposureMode].CanSet())
            {
                var exposureMode = device.GetEnum(eNkMAIDCapability.kNkMAIDCapability_ExposureMode);
                var foundManual = false;
                for (int i = 0; i < exposureMode.Length; i++)
                {
                    if ((uint)exposureMode[i] == (uint)eNkMAIDExposureMode.kNkMAIDExposureMode_Manual)
                    {
                        exposureMode.Index = i;
                        foundManual = true;
                        device.SetEnum(eNkMAIDCapability.kNkMAIDCapability_ExposureMode, exposureMode);
                        break;
                    }
                }

                if (!foundManual)
                {
                    throw new NikonException("Failed to find the 'Manual' exposure mode");
                }
            }
            else
            {
                Logger.WriteDebugMessage("Cannot set to manual mode. Skipping...");

            }
        }

        public void StopExposure()
        {
            AbortExposure();
        }

    }



}
