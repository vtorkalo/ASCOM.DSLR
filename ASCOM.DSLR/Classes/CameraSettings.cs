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
            Iso = 400;
            BackyardEosPort = 1491;
            EnableBinning = false;
        }

        public bool TraceLog { get; set; }

        public CameraMode CameraMode { get; set; }

        public IntegrationApi IntegrationApi { get; set; }

        public string StorePath { get; set; }

        public short Iso { get; set; }

        public int BackyardEosPort { get; set; }

        public bool EnableBinning { get; set; }
        public BinningMode BinningMode { get; set; }
    }
}
