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

namespace ASCOM.DSLR.Classes
{
    public class NikonSdkCamera  : BaseCamera, IDslrCamera
    {

        public ConnectionMethod IntegrationApi => ConnectionMethod.Nikon;
        
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

        public bool SupportsViewView => throw new System.NotImplementedException();

        public NikonSdkCamera(TraceLogger tl, List<CameraModel> cameraModelHistory) : base(cameraModelHistory)
        {
        }

        private List<NikonManager> _nikonManagers;
        private NikonManager _activeNikonManager;

        public event EventHandler<ImageReadyEventArgs> ImageReady;
        public event EventHandler<LiveViewImageReadyEventArgs> LiveViewImageReady;
        public event EventHandler<ExposureFailedEventArgs> ExposureFailed;

        public void LoadManagers() {

            _nikonManagers.Clear();

            string architecture = "x64";

            var md3Folder = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "External", architecture, "Nikon");

            foreach (string file in Directory.GetFiles(md3Folder, "*.md3", SearchOption.AllDirectories))
            {
                NikonManager mgr = new NikonManager(file);
                //mgr.DeviceAdded += Mgr_DeviceAdded;
                _nikonManagers.Add(mgr);
            }


        }

        public override CameraModel ScanCameras()
        {
            throw new System.NotImplementedException();
        }

        public void StartExposure(double Duration, bool Light)
        {
            throw new System.NotImplementedException();
        }

        public void AbortExposure()
        {
            throw new System.NotImplementedException();
        }

        public void StopExposure()
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
    }




}
