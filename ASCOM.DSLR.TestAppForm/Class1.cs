using ASCOM.DSLR.Classes;
using ASCOM.DSLR.Enums;
using ASCOM.DSLR.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ASCOM.DSLR
{
    public class TestCamera : IDslrCamera
    {
        public string Model => "Some test model";

        public int FrameWidth => throw new NotImplementedException();

        public int FrameHeight => throw new NotImplementedException();

        public List<short> IsoValues => throw new NotImplementedException();

        public short MinIso => throw new NotImplementedException();

        public short MaxIso => throw new NotImplementedException();

        public short Iso { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public double PixelSizeX => throw new NotImplementedException();

        public double PixelSizeY => throw new NotImplementedException();

        public double SensorSizeX => throw new NotImplementedException();

        public double SensorSizeY => throw new NotImplementedException();

        public double SensorTemperature => throw new NotImplementedException();

        public ImageFormat ImageFormat { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string StorePath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool UseExternalShutter { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ExternalShutterPort { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool SupportsViewView => throw new NotImplementedException();

        public bool IsLiveViewMode { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public LiveViewZoom LiveViewZoom { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ConnectionMethod IntegrationApi => throw new NotImplementedException();

        public CameraModel CameraModel => throw new NotImplementedException();

        public event EventHandler<ImageReadyEventArgs> ImageReady;
        public event EventHandler<LiveViewImageReadyEventArgs> LiveViewImageReady;
        public event EventHandler<ExposureFailedEventArgs> ExposureFailed;

        public void AbortExposure()
        {
            throw new NotImplementedException();
        }

        public void ConnectCamera()
        {
           // throw new NotImplementedException();
        }

        public void DisconnectCamera()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public CameraModel ScanCameras()
        {
            throw new NotImplementedException();
        }

        public void StartExposure(double Duration, bool Light)
        {
            if (ImageReady != null)
            {
                Thread.Sleep(2000);
                ImageReady(this, new ImageReadyEventArgs(@"c:\git-vtorkalo\test.dng-0000.dng"));
            }
        }

        public void StopExposure()
        {
            throw new NotImplementedException();
        }
    }
}
