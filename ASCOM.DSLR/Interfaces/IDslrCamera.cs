using ASCOM.DeviceInterface;
using ASCOM.DSLR.Classes;
using ASCOM.DSLR.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ASCOM.DSLR.Interfaces
{
    public interface IDslrCamera : IDisposable
    {
        string Model { get; }
        int FrameWidth { get; }
        int FrameHeight { get; }

        void StartExposure(double Duration, bool Light);
        void AbortExposure();
        void StopExposure();

        List<short> IsoValues { get; }
        short MinIso { get; }
        short MaxIso { get; }

        short Iso { get; set; }

        double PixelSizeX { get; }
        double PixelSizeY { get; }
        double SensorSizeX { get; }
        double SensorSizeY { get; }

        double SensorTemperature { get; }
        void ConnectCamera();
        void DisconnectCamera();
        ImageFormat ImageFormat {get;set;}

        string StorePath { get; set; }
        CameraModel ScanCameras();

        bool UseExternalShutter { get; set; }
        string ExternalShutterPort { get; set; }

        bool SupportsViewView { get; }
        bool IsLiveViewMode { get; set; }

        LiveViewZoom LiveViewZoom { get; set; }

        event EventHandler<ImageReadyEventArgs> ImageReady;
        event EventHandler<LiveViewImageReadyEventArgs> LiveViewImageReady;

        event EventHandler<ExposureFailedEventArgs> ExposureFailed;
        ConnectionMethod IntegrationApi { get; }

        CameraModel CameraModel { get; }      
    }

    public class LiveViewImageReadyEventArgs : EventArgs
    {
        public LiveViewImageReadyEventArgs(Bitmap data)
        {
            Data = data;
        }
        public Bitmap Data { get; private set; }
    }

    public class ImageReadyEventArgs : EventArgs
    {
        public ImageReadyEventArgs(string fileName)
        {
            RawFileName = fileName;
        }
        public string RawFileName { get; private set; }
    }

    public class ExposureFailedEventArgs : EventArgs
    {
        public ExposureFailedEventArgs(string message, string stacktrace = null)
        {
            Message = message;
            StackTrace = stacktrace;
        }
        public string Message { get; private set; }
        public string StackTrace { get; private set; }
    }
}
