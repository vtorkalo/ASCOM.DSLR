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
        private double _flashSyncSpeed;
        private int _bulbShutterSpeedIndex;
        private int _flashSyncSpeedIndex;


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
                Logger.WriteTraceMessage("Retuning MODEL NAME" + Name);
                return Name;

            }
        }


        public event EventHandler<ImageReadyEventArgs> ImageReady;
        public event EventHandler<LiveViewImageReadyEventArgs> LiveViewImageReady;
        public event EventHandler<ExposureFailedEventArgs> ExposureFailed;

        public void AbortExposure()
        {
            if (Connected)
            {
                _camera.StopBulbCapture();
            }
        }

        private CancellationTokenSource _cancelConnectCameraSource;
        public void ConnectCamera()
        {
            if (!Connected)
            {
                _cancelConnectCameraSource?.Dispose();
                _cancelConnectCameraSource = new CancellationTokenSource();
                var connected = Connect(_cancelConnectCameraSource.Token);
                Task.WhenAll(connected).Wait();
                Connected = connected.Result;


            }
        }

        public void DisconnectCamera()
        {
            Disconnect();
        }

        public void Dispose()
        {
            Disconnect();
        }

        public override CameraModel ScanCameras()
        {
            var cameraModel = GetCameraModel(Model);

            return cameraModel;
        }

        public void StartExposure(double Duration, bool Light)
        {
            _startTime = DateTime.Now;
            _duration = Duration;

            if (Connected)
            {
                Logger.WriteTraceMessage("Prepare start of exposure: ");
                _downloadExposure = new TaskCompletionSource<object>();

                if (Duration <= 30.0)
                {
                    Logger.WriteTraceMessage("Exposuretime <= 30. Setting automatic shutter speed.");
                    var speed = _shutterSpeeds.Aggregate((x, y) => Math.Abs(x.Value - Duration) < Math.Abs(y.Value - Duration) ? x : y);
                    SetCameraShutterSpeed(speed.Key);

                    Logger.WriteTraceMessage("Start capture");
                    _camera.Capture();
                }
                else
                {
                    Logger.WriteTraceMessage("Use Bulb capture");
                    Task.Run(() => BulbCapture(Duration));
                }
            }
        }

        private void BulbCapture(double exposureTime)
        {
            // Lock camera so we can change it to 'manual exposure'
            eNkMAIDCapability lockCameraCap = eNkMAIDCapability.kNkMAIDCapability_LockCamera;
            _camera.SetBoolean(lockCameraCap, true);

            // Set camera to manual exposure
            eNkMAIDCapability exposureModeCap = eNkMAIDCapability.kNkMAIDCapability_ExposureMode;
            NikonEnum exposureMode = _camera.GetEnum(exposureModeCap);
            exposureMode.Index = (int)eNkMAIDExposureMode.kNkMAIDExposureMode_Manual;
            _camera.SetEnum(exposureModeCap, exposureMode);

            // Set shutter speed to 'bulb'
            eNkMAIDCapability shutterSpeedCap = eNkMAIDCapability.kNkMAIDCapability_ShutterSpeed;
            NikonEnum shutterSpeed = _camera.GetEnum(shutterSpeedCap);
            for (int i = 0; i < shutterSpeed.Length; i++)
            {
                if (shutterSpeed.GetEnumValueByIndex(i).ToString().ToLower() == "bulb")
                {
                    Console.WriteLine("Index " + i.ToString());
                    shutterSpeed.Index = i;
                    _camera.SetEnum(shutterSpeedCap, shutterSpeed);
                    break;
                }
            }

            // Capture - and ignore the 'BulbReleaseBusy' exception. This is expected.
            try
            {
                _camera.Capture();
            }
            catch (NikonException ex)
            {
                if (ex.ErrorCode != eNkMAIDResult.kNkMAIDResult_BulbReleaseBusy)
                {
                    throw;
                }
            }

            // What for 5 seconds - or however long you want to capture
            Thread.Sleep(TimeSpan.FromSeconds(exposureTime));

            // Stop bulb capture (Note: must be compiled with 'unsafe code' enabled)
            NkMAIDTerminateCapture terminate = new NkMAIDTerminateCapture();
            terminate.ulParameter1 = 0;
            terminate.ulParameter2 = 0;
            unsafe
            {
                IntPtr terminate_pointer = new IntPtr(&terminate);

                _camera.Start(
                    eNkMAIDCapability.kNkMAIDCapability_TerminateCapture,
                    eNkMAIDDataType.kNkMAIDDataType_GenericPtr,
                    terminate_pointer);
            }

            // Unlock camera
            _camera.SetBoolean(lockCameraCap, false);
        }

        private void BulbCapture(double exposureTime, Action capture, Action stopCapture)
        {
          
            SetCameraToManual();

            SetCameraShutterSpeed(_bulbShutterSpeedIndex);

            try
            {
                Logger.WriteTraceMessage("Starting bulb capture");
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
            Task.Run(async () => {
                await Wait(TimeSpan.FromSeconds(exposureTime));

                stopCapture();

                Logger.WriteTraceMessage("Restore previous shutter speed");
                // Restore original shutter speed
                SetCameraShutterSpeed(_prevShutterSpeed);
            });
        }

        private void StartBulbCapture()
        {

            _camera.StartBulbCapture();
        }

        private void StopBulbCapture()
        {
            _camera.StopBulbCapture();
        }



        private void SetCameraToManual()
        {
            Logger.WriteTraceMessage("Set camera to manual exposure");
            if (Capabilities.ContainsKey(eNkMAIDCapability.kNkMAIDCapability_ExposureMode) && Capabilities[eNkMAIDCapability.kNkMAIDCapability_ExposureMode].CanSet())
            {
                var exposureMode = _camera.GetEnum(eNkMAIDCapability.kNkMAIDCapability_ExposureMode);
                var foundManual = false;
                for (int i = 0; i < exposureMode.Length; i++)
                {
                    if ((uint)exposureMode[i] == (uint)eNkMAIDExposureMode.kNkMAIDExposureMode_Manual)
                    {
                        exposureMode.Index = i;
                        foundManual = true;
                        _camera.SetEnum(eNkMAIDCapability.kNkMAIDCapability_ExposureMode, exposureMode);
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
                Logger.WriteTraceMessage("Cannot set to manual mode. Skipping...");
            }
        }


        private int _prevShutterSpeed;
        private void SetCameraShutterSpeed(int index)
        {
            if (Capabilities.ContainsKey(eNkMAIDCapability.kNkMAIDCapability_ShutterSpeed) && Capabilities[eNkMAIDCapability.kNkMAIDCapability_ShutterSpeed].CanSet())
            {
                Logger.WriteTraceMessage("Setting shutter speed to index: " + index);
                var shutterspeed = _camera.GetEnum(eNkMAIDCapability.kNkMAIDCapability_ShutterSpeed);
                _prevShutterSpeed = shutterspeed.Index;
                shutterspeed.Index = index;
                _camera.SetEnum(eNkMAIDCapability.kNkMAIDCapability_ShutterSpeed, shutterspeed);
            }
            else
            {
                Logger.WriteTraceMessage("Cannot set camera shutter speed. Skipping...");
            }
        }


        public void StopExposure()
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> Connect(CancellationToken token)
        {
            Task.Run(async () => {
                var connected = false;
                try
                {
                    _nikonManagers.Clear();

                    string architecture = (IntPtr.Size == 4) ? "x86" : "x64";

                    var md3Folder = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "SDK", architecture, "Nikon");

                    Logger.WriteTraceMessage("md3Folder: " + md3Folder);

                    foreach (string file in Directory.GetFiles(md3Folder, "*.md3", SearchOption.AllDirectories))
                    {
                        Logger.WriteTraceMessage("Processing md3: " + file);
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
            }).Wait();
            return true;
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
            NikonManager tmpManager = _activeNikonManager;

            var connected = false;
            try
            {

                _activeNikonManager = sender;
                _activeNikonManager.DeviceRemoved += Mgr_DeviceRemoved;

                Logger.WriteTraceMessage("NikonManager starting device init: " + _activeNikonManager.Name);
                Init(device);
                Name = _camera.Name;

                if (Name == "")
                {
                    _activeNikonManager = tmpManager;
                }

                connected = true;

            }
            catch (Exception ex)
            {
                Logger.WriteTraceMessage(ex.ToString());
            }
            finally
            {
                Connected = connected;
                _cameraConnected.TrySetResult(Connected);
            }
        }

        private void Mgr_DeviceRemoved(NikonManager sender, NikonDevice device)
        {
            Disconnect();
        }

        public void Disconnect()
        {
            Connected = false;
            _camera = null;
            _activeNikonManager?.Shutdown();
            _nikonManagers?.Clear();
        }

        public void Init(NikonDevice cam)
        {
            Logger.WriteTraceMessage("Initializing Nikon camera '" + cam.Name + "'");
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

            //Ensure camera is in Manual mode
            /*var exposureMode = _camera.GetEnum(eNkMAIDCapability.kNkMAIDCapability_ExposureMode);
            if (exposureMode.Index != (int)eNkMAIDExposureMode.kNkMAIDExposureMode_Manual)
            {
                Logger.WriteTraceMessage("Camera not set to Manual mode. Switching now.");
                exposureMode.Index = (int)eNkMAIDExposureMode.kNkMAIDExposureMode_Manual;
                _camera.SetEnum(eNkMAIDCapability.kNkMAIDCapability_ExposureMode, exposureMode);
            }*/
            //Changed to function
            SetCameraToManual();


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
                using (FileStream stream = new FileStream(StorePath + "/" + file, FileMode.Create, FileAccess.Write))
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

            ImageReady?.Invoke(this, new ImageReadyEventArgs(newFilePath));

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
                    if (val.StartsWith("x"))
                    {
                        //Flash sync shutter speed detected.
                        //This is a dynamic shutter speed (Its value can change at runtime) that depends on the
                        //"Flash sync speed" capability setting found under option "e1" in the Nikon in-camera menu.
                        _flashSyncSpeedIndex = i;
                        var split = val.Substring(2).Split('/');
                        _flashSyncSpeed = double.Parse(split[0], CultureInfo.InvariantCulture) / double.Parse(split[1], CultureInfo.InvariantCulture);
                        Logger.WriteTraceMessage("Flash sync speed index: " + _flashSyncSpeedIndex.ToString() + " (Current value: " + _flashSyncSpeed + ")");
                    }
                    else if (val.Contains("/"))
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
            }
        }

        private bool _connected;

        public bool Connected
        {
            get
            {
                return _connected;
            }
            set
            {
                _connected = value;
            }
        }


        public static async Task<TimeSpan> Wait(TimeSpan t, CancellationToken token = new CancellationToken())
        {
            TimeSpan elapsed = new TimeSpan(0);
            do
            {
                var delta = await Delay(100, token);
                elapsed += delta;
            } while (elapsed < t);
            return elapsed;
        }

        public static async Task<TimeSpan> Delay(int milliseconds, CancellationToken token)
        {
            var t = new TimeSpan(0, 0, 0, 0, milliseconds);
            return await Delay(Convert.ToInt32(t), token);
        }

               
    }


}