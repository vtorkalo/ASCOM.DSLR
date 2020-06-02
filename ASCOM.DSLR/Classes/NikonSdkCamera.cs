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

        private List<NikonManager> _nikonManagers;
        private NikonManager _activeNikonManager;

        public void LoadManagers() {

            _nikonManagers.Clear();

            string architecture = "x64";

            var md3Folder = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "External", architecture, "Nikon");

            foreach (string file in Directory.GetFiles(md3Folder, "*.md3", SearchOption.AllDirectories))
            {
                NikonManager mgr = new NikonManager(file);
                mgr.DeviceAdded += Mgr_DeviceAdded;
                _nikonManagers.Add(mgr);
            }


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
                Notification.ShowError(ex.Message);
                Logger.Error(ex);
            }
            finally
            {
                Connected = connected;
                RaiseAllPropertiesChanged();
                _cameraConnected.TrySetResult(connected);
            }
        }

        public override CameraModel ScanCameras()
        {
            ScanForCameras();
            _mainCamera = CamList.First();

            // TODO: handle exceptions here, this can fail!

            var cameraModel = GetCameraModel(_mainCamera.DeviceName);
            return cameraModel;
        }

        private void ScanForCameras()
        {
            CamList = APIHandler.GetCameraList();
            if (!CamList.Any())
            {
                throw new NotConnectedException(ErrorMessages.NotConnected);
            }
        }



    }




}
