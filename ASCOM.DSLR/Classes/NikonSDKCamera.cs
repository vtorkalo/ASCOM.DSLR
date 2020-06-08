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
        
        NikonBase _object;
        NkMAIDCapInfo[] caps;


        public ObjectModel(NikonBase obj)
        {

            _object = obj;


            NikonDevice device = _object as NikonDevice;

            caps = device.GetCapabilityInfo();


            if (device != null)
            {
                device.CapabilityChanged += new CapabilityChangedDelegate(device_CapabilityChanged);
                device.CaptureComplete += new CaptureCompleteDelegate(device_CaptureComplete);
                device.ImageReady += new ImageReadyDelegate(device_ImageReady);
            }

            RefreshCaps();
        }


        void device_ImageReady(NikonDevice sender, NikonImage image)
        {
            Save(image.Buffer, "image" + ((image.Type == NikonImageType.Jpeg) ? ".jpg" : ".nef"));
        }

        public string ObjectName
        {
            get { return _object.Name; }
        }

        public bool SupportsCapture
        {
            get { return _object.SupportsCapability(eNkMAIDCapability.kNkMAIDCapability_Capture); }
        }

        public bool SupportsLiveView
        {
            get { return _object.SupportsCapability(eNkMAIDCapability.kNkMAIDCapability_LiveViewStatus); }
        }

        void Save(byte[] buffer, string file)
        {


            string path = Path.Combine(
                System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),
                file);

            Logger.WriteTraceMessage("Saving: " + path);

            try
            {
                using (FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    stream.Write(buffer, 0, buffer.Length);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteTraceMessage("Failed to save file: " + path + ", " + ex.Message);
            }
        }



        public NikonBase Object
        {
            get { return _object; }
        }


        void device_CapabilityChanged(NikonDevice sender, eNkMAIDCapability capability)
        {
            RefreshCaps();
        }


        void device_CaptureComplete(NikonDevice sender, int data)
        {
        }


        void RefreshCaps()
        {
           

            NkMAIDCapInfo[] caps = _object.GetCapabilityInfo();

            foreach (NkMAIDCapInfo cap in caps)
            {

                // Print ID, description and type
                Console.WriteLine(string.Format("{0, -14}: {1}", "Id", cap.ulID.ToString()));
                Console.WriteLine(string.Format("{0, -14}: {1}", "Description", cap.GetDescription()));
                Console.WriteLine(string.Format("{0, -14}: {1}", "Type", cap.ulType.ToString()));

                // Try to get the capability value
                string value = null;

                // First, check if the capability is readable
                if (cap.CanGet())
                {
                    // Choose which 'Get' function to use, depending on the type
                    switch (cap.ulType)
                    {
                        case eNkMAIDCapType.kNkMAIDCapType_Unsigned:
                            value = _object.GetUnsigned(cap.ulID).ToString();
                            break;

                        case eNkMAIDCapType.kNkMAIDCapType_Integer:
                            value = _object.GetInteger(cap.ulID).ToString();
                            break;

                        case eNkMAIDCapType.kNkMAIDCapType_String:
                            value = _object.GetString(cap.ulID);
                            break;

                        case eNkMAIDCapType.kNkMAIDCapType_Boolean:
                            value = _object.GetBoolean(cap.ulID).ToString();
                            break;

                            // Note: There are more types - adding the rest is left
                            //       as an exercise for the reader.
                    }


                }
            }
        }

    }


    public class NikonSDKCamera : BaseCamera, IDslrCamera
    {
        List<NikonManager> _managers;
        ObservableCollection<ObjectModel> _objects;


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
                if (deviceModel.Object == device)
                {
                    deviceModelToRemove = deviceModel;
                }
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

    }





}