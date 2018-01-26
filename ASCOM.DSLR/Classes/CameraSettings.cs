using ASCOM.DSLR.Enums;
using System;
using System.IO;

namespace ASCOM.DSLR.Classes
{
    [Serializable]
    public class CameraSettings
    {
        public CameraSettings()
        {
            TraceLog = true;
            CameraMode = CameraMode.RGGB;
            StorePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "ASCOM_DSLR");
            IntegrationApi = ConnectionMethod.CanonSdk;
            Iso = 400;
            BackyardEosPort = 1491;
            EnableBinning = false;
            ExternalShutterPortName = string.Empty;
            LiveViewZoom = LiveViewZoom.Fit;
            BinningMode = BinningMode.Sum;
        }

        public bool TraceLog { get; set; }

        public CameraMode CameraMode { get; set; }

        public ConnectionMethod IntegrationApi { get; set; }

        public string StorePath { get; set; }

        public short Iso { get; set; }

        public int BackyardEosPort { get; set; }

        public bool EnableBinning { get; set; }

        public BinningMode BinningMode { get; set; }

        public bool UseExternalShutter { get; set; }

        public string ExternalShutterPortName { get; set; }

        public bool LiveViewCaptureMode { get; set; }

        public LiveViewZoom LiveViewZoom { get; set; }
    }
}
