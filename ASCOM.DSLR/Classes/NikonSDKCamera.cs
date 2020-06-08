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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace ASCOM.DSLR.Classes
{


    public class NikonSDKCamera : BaseCamera, IDslrCamera
    {
        List<NikonManager> _nikonManagers;
        private NikonManager _activeNikonManager;

        private TaskCompletionSource<object> _downloadExposure;
        private TaskCompletionSource<bool> _cameraConnected;

        private NikonDevice _camera;

        private Dictionary<int, double> _shutterSpeeds = new Dictionary<int, double>();
        private int _bulbShutterSpeedIndex;


        public NikonSDKCamera(List<CameraModel> cameraModelsHistory) : base(cameraModelsHistory)
        {

            _nikonManagers = new List<NikonManager>();

        }


        public ConnectionMethod IntegrationApi => ConnectionMethod.Nikon;

        public bool SupportsViewView { get { return false; } }

        public string Model
        {
            get
            {
                return Name;
            }
        }


        public event EventHandler<ImageReadyEventArgs> ImageReady;
        public event EventHandler<LiveViewImageReadyEventArgs> LiveViewImageReady;
        public event EventHandler<ExposureFailedEventArgs> ExposureFailed;

        public void AbortExposure()
        {
            throw new System.NotImplementedException();
        }

        public void ConnectCamera()
        {
            throw new System.NotImplementedException();
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

        public void StartExposure(double Duration, bool Light)
        {
            throw new System.NotImplementedException();
        }

        public void StopExposure()
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> Connect(CancellationToken token)
        {
            return await Task.Run(() => {
                var connected = false;
                try
                {
                     _nikonManagers.Clear();

                    string architecture = (IntPtr.Size == 4) ? "x86" : "x64";

                    var md3Folder = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "SDK", architecture, "Nikon");

                    foreach (string file in Directory.GetFiles(md3Folder, "*.md3", SearchOption.AllDirectories))
                    {
                        NikonManager mgr = new NikonManager(file);
                        mgr.DeviceAdded += Mgr_DeviceAdded;
                        _nikonManagers.Add(mgr);
                    }

                    _cameraConnected = new TaskCompletionSource<bool>();
                    var d = DateTime.Now;

                    do
                    {
                        token.ThrowIfCancellationRequested();
                        Thread.Sleep(500);
                    } while (!_cameraConnected.Task.IsCompleted);

                    connected = _cameraConnected.Task.Result;
                }
                catch (OperationCanceledException)
                {
                    _activeNikonManager = null;
                }
                finally
                {
                    CleanupUnusedManagers(_activeNikonManager);
                }

                return connected;
            });
        }

        private void CleanupUnusedManagers(NikonManager activeManager)
        {
            foreach (NikonManager mgr in _nikonManagers)
            {
                if (mgr != activeManager)
                {
                    mgr.Shutdown();
                }
            }
            _nikonManagers.Clear();
        }

        private void Mgr_DeviceAdded(NikonManager sender, NikonDevice device)
        {
            var connected = false;
            try
            {
                _activeNikonManager = sender;
                _activeNikonManager.DeviceRemoved += Mgr_DeviceRemoved;

                Init(device);

                connected = true;
                Name = _camera.Name;
            }
            catch (Exception ex)
            {
                Logger.WriteTraceMessage(ex.ToString());
            }
            finally
            {
                //Connected = connected;

                _cameraConnected.TrySetResult(connected);
            }
        }

        private void Mgr_DeviceRemoved(NikonManager sender, NikonDevice device)
        {
            Disconnect();
        }

        public void Disconnect()
        {
            _activeNikonManager?.Shutdown();
            _nikonManagers?.Clear();
        }

        public void Init(NikonDevice cam)
        {
            Logger.WriteTraceMessage("Initializing Nikon camera");
            _camera = cam;
            _camera.ImageReady += Camera_ImageReady;
            _camera.CaptureComplete += _camera_CaptureComplete;

            //Set to shoot in RAW
            Logger.WriteTraceMessage("Setting compression to RAW");
            var compression = _camera.GetEnum(eNkMAIDCapability.kNkMAIDCapability_CompressionLevel);
            for (int i = 0; i < compression.Length; i++)
            {
                var val = compression.GetEnumValueByIndex(i);
                if (val.ToString() == "RAW")
                {
                    compression.Index = i;
                    _camera.SetEnum(eNkMAIDCapability.kNkMAIDCapability_CompressionLevel, compression);
                    break;
                }
            }

            GetShutterSpeeds();
            GetCapabilities();

            /* Setting SaveMedia when supported, to save images via SDRAM and not to the internal memory card */
            if (Capabilities.ContainsKey(eNkMAIDCapability.kNkMAIDCapability_SaveMedia) && Capabilities[eNkMAIDCapability.kNkMAIDCapability_SaveMedia].CanSet())
            {
                _camera.SetUnsigned(eNkMAIDCapability.kNkMAIDCapability_SaveMedia, (uint)eNkMAIDSaveMedia.kNkMAIDSaveMedia_SDRAM);
            }
            else
            {
                Logger.WriteTraceMessage("Setting SaveMedia Capability not available. This has to be set manually or is not supported by this model.");
            }
        }


        private void _camera_CaptureComplete(NikonDevice sender, int data)
        {
            Logger.WriteTraceMessage("Capture complete");
        }

        private void Camera_ImageReady(NikonDevice sender, NikonImage image)
        {
            Logger.WriteTraceMessage("Image ready");
            Save(image.Buffer, "image" + ((image.Type == NikonImageType.Jpeg) ? ".jpg" : ".nef"));
            Logger.WriteTraceMessage("Setting Download Exposure Taks to complete");
            _downloadExposure.TrySetResult(null);
        }

        private DateTime _startTime;
        private double _duration;

        void Save(byte[] buffer, string file)
        {
            Logger.WriteTraceMessage("Saving: " + StorePath);

            if (!Directory.Exists(StorePath))
            {
                Directory.CreateDirectory(StorePath);
            }
            try
            {
                using (FileStream stream = new FileStream(StorePath, FileMode.Create, FileAccess.Write))
                {
                    stream.Write(buffer, 0, buffer.Length);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteTraceMessage("Failed to save file: " + StorePath + ", " + ex.Message);
            }


            string downloadedFilePath = Path.Combine(StorePath, file);
            SensorTemperature = GetSensorTemperature(downloadedFilePath);

            string newFilePath = RenameFile(downloadedFilePath, _duration, _startTime);

            if ((File.Exists(newFilePath)) && (SaveFile == false))
            {
                File.Delete(newFilePath);
            }
        }

        private Dictionary<eNkMAIDCapability, NkMAIDCapInfo> Capabilities = new Dictionary<eNkMAIDCapability, NkMAIDCapInfo>();

        private void GetShutterSpeeds()
        {
            Logger.WriteTraceMessage("Getting Nikon shutter speeds");
            _shutterSpeeds.Clear();
            var shutterSpeeds = _camera.GetEnum(eNkMAIDCapability.kNkMAIDCapability_ShutterSpeed);
            Logger.WriteTraceMessage("Available Shutterspeeds: " + shutterSpeeds.Length);
            bool bulbFound = false;
            for (int i = 0; i < shutterSpeeds.Length; i++)
            {
                try
                {
                    var val = shutterSpeeds.GetEnumValueByIndex(i).ToString();
                    Logger.WriteTraceMessage("Found Shutter speed: " + val);
                    if (val.Contains("/"))
                    {
                        var split = val.Split('/');
                        var convertedSpeed = double.Parse(split[0], CultureInfo.InvariantCulture) / double.Parse(split[1], CultureInfo.InvariantCulture);

                        _shutterSpeeds.Add(i, convertedSpeed);
                    }
                    else if (val.ToLower() == "bulb")
                    {
                        Logger.WriteTraceMessage("Bulb index: " + i);
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
                    Logger.WriteTraceMessage("Unexpected Shutter Speed: " + ex.ToString());
                }
            }
            if (!bulbFound)
            {
                Logger.WriteTraceMessage("No Bulb speed found!");
                throw new NikonException("Failed to find the 'Bulb' exposure mode");
            }
        }


        private void GetCapabilities()
        {
            Logger.WriteTraceMessage("Getting Nikon capabilities");
            Capabilities.Clear();
            foreach (NkMAIDCapInfo info in _camera.GetCapabilityInfo())
            {
                Capabilities.Add(info.ulID, info);

                var description = info.GetDescription();
                var canGet = info.CanGet();
                var canGetArray = info.CanGetArray();
                var canSet = info.CanSet();
                var canStart = info.CanStart();

                Logger.WriteTraceMessage(description);
                Logger.WriteTraceMessage("\t Id: " + info.ulID.ToString());
                Logger.WriteTraceMessage("\t CanGet: " + canGet.ToString());
                Logger.WriteTraceMessage("\t CanGetArray: " + canGetArray.ToString());
                Logger.WriteTraceMessage("\t CanSet: " + canSet.ToString());
                Logger.WriteTraceMessage("\t CanStart: " + canStart.ToString());

                if (info.ulID == eNkMAIDCapability.kNkMAIDCapability_ShutterSpeed && !canSet)
                {
                    throw new NikonException("Cannot set shutterspeeds. Please make sure the camera dial is set to a position where bublb mode is possible and the mirror lock is turned off");
                }
            }
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            private set
            {
                _name = value;
                //RaisePropertyChanged();
            }
        }








    }





}