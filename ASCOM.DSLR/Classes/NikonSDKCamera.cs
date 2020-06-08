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

namespace ASCOM.DSLR.Classes
{


    class ObjectModel

    {


        public ObjectModel(NikonBase obj)
        {

            _caps = new ObservableCollection<CapModel>();
            _object = obj;
            _doThumbnail = false;
            _doPreview = false;
            _doLowResPreview = false;
            _videoFile = null;

            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(33.0);
            _timer.Tick += new EventHandler(_timer_Tick);

            NikonDevice device = _object as NikonDevice;

            if (device != null)
            {
                device.CapabilityChanged += new CapabilityChangedDelegate(device_CapabilityChanged);

                device.CaptureComplete += new CaptureCompleteDelegate(device_CaptureComplete);
                device.ImageReady += new ImageReadyDelegate(device_ImageReady);

                // Note: Disable thumbnails and previews by default

                //device.PreviewReady += device_PreviewReady;
                //device.LowResolutionPreviewReady += device_LowResolutionPreviewReady;
                //device.ThumbnailReady += device_ThumbnailReady;
                //_doPreview = true;
                //_doLowResPreview = true;
                //_doThumbnail = true;

                device.VideoFragmentReady += new VideoFragmentReadyDelegate(device_VideoFragmentReady);
                device.VideoRecordingInterrupted += new VideoRecordingInterruptedDelegate(device_VideoRecordingInterrupted);
            }

            //RefreshCaps();
        }


    }
    public class NikonSDKCamera : BaseCamera, IDslrCamera
    {
        List<NikonManager> _managers;
        ObservableCollection<ObjectModel> _objects;
        NikonBase _object;


        public NikonSDKCamera(List<CameraModel> cameraModelsHistory) : base(cameraModelsHistory)
        {
            _objects = new ObservableCollection<ObjectModel>();
            _managers = new List<NikonManager>();

            string[] md3s = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.md3", SearchOption.AllDirectories);

            if (md3s.Length == 0)
            {
                Logger.WriteTraceMessage("Couldn't find any MD3 files in " + Directory.GetCurrentDirectory());
                Logger.WriteTraceMessage("Download MD3 files from Nikons SDK website: https://sdk.nikonimaging.com/apply/");
            }

            foreach (string md3 in md3s)
            {
                const string requiredDllFile = "NkdPTP.dll";

                string requiredDllPath = Path.Combine(Path.GetDirectoryName(md3), requiredDllFile);

                if (!File.Exists(requiredDllPath))
                {
                    Logger.WriteTraceMessage("Warning: Couldn't find " + requiredDllFile + " in " + Path.GetDirectoryName(md3) + ". The library will not work properly without it!");
                }

                Logger.WriteTraceMessage("Opening " + md3);

                NikonManager manager = new NikonManager(md3);
                manager.DeviceAdded += new DeviceAddedDelegate(_manager_DeviceAdded);
                manager.DeviceRemoved += new DeviceRemovedDelegate(_manager_DeviceRemoved);

                _objects.Add(new ObjectModel(manager));
                _managers.Add(manager);
            }

        }

        void _manager_DeviceAdded(NikonManager sender, NikonDevice device)
        {
            _objects.Add(new ObjectModel(device));
            Logger.WriteTraceMessage("NewestIndex");
        }

        void _manager_DeviceRemoved(NikonManager sender, NikonDevice device)
        {
            ObjectModel deviceModelToRemove = null;

            foreach (ObjectModel deviceModel in _objects)
            {
                /*if (deviceModel.Object == device)
                {
                    deviceModelToRemove = deviceModel;
                }*/
            }
        }


        public ConnectionMethod IntegrationApi => ConnectionMethod.Nikon;

        public bool SupportsViewView { get { return false; } }

        string IDslrCamera.Model => throw new System.NotImplementedException();

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

        public NikonBase Object
        {
            get { return _object; }
        }

    }



}