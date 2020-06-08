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
    public class NikonSDKCamera : BaseCamera, IDslrCamera
    {

        public NikonSDKCamera(List<CameraModel> cameraModelsHistory) : base(cameraModelsHistory)
        {
        }

        public ConnectionMethod IntegrationApi => ConnectionMethod.Nikon;

        public bool SupportsViewView => throw new System.NotImplementedException();

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