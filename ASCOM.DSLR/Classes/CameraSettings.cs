using ASCOM.DSLR.Enums;
using System;
using System.Collections.Generic;
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
            SaveFile = true;
            IntegrationApi = ConnectionMethod.CanonSdk;
            Iso = 100;
            BackyardEosPort = 1491;
            LiveViewZoom = LiveViewZoom.Fit;
            BinningMode = BinningMode.Sum;
            CameraModelsHistory = new List<CameraModel>();
        }

        public bool TraceLog { get; set; }

        public CameraMode CameraMode { get; set; }

        public ConnectionMethod IntegrationApi { get; set; }

        public string StorePath { get; set; }

        public bool SaveFile { get; set; }

        public short Iso { get; set; }

        public int BackyardEosPort { get; set; }

        public bool LiveViewCaptureMode { get; set; }

        public LiveViewZoom LiveViewZoom { get; set; }

        public List<CameraModel> CameraModelsHistory { get; set; }

        public BinningMode BinningMode { get; set; }

        public bool EnableBinning { get; set; }

        public bool UseExternalShutter { get; set; }

        public string ExternalShutterPortName { get; set; }

    }
}
