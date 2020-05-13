using ASCOM.DSLR.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ASCOM.DSLR.Classes
{
    public class CameraModelDetector
    {
        private ImageDataProcessor _imageDataProcessor;

        ManualResetEvent oSignalEvent = new ManualResetEvent(false);

        public CameraModelDetector(ImageDataProcessor imageDataProcessor)
        {
            _imageDataProcessor = imageDataProcessor;
        }

        public CameraModel GetCameraModel(IDslrCamera camera, string storePath)
        {
            CameraModel result = null;

            _imageData = null;
            camera.ConnectCamera();
            var model = camera.Model;
            camera.ImageReady += Camera_ImageReady;
            camera.StorePath = storePath;
            camera.Iso = 200;
            camera.ImageFormat = Enums.ImageFormat.RAW;
            camera.IsLiveViewMode = false;
            camera.StartExposure(1, true);

            // modified to checked if the signal was set as opposed to a timeout occured

            if (oSignalEvent.WaitOne(60 * 1000))
            {
                oSignalEvent.Reset();

                if (_imageData != null)
                {
                    result = new CameraModel();
                    result.ImageWidth = _imageData.GetLength(0);
                    result.ImageHeight = _imageData.GetLength(1);

                    // TODO: figure out how to determine the SensorWidth and SensorHeight properly versus hard coding here

                    result.SensorWidth = 22.5;
                    result.SensorHeight = 15;
                    result.Name = model;
                }
            }
            else
            {
                // TODO: figure out how to handle this error (i.e. the picture was not taken)
            }

            return result;
        }

        private int[,] _imageData;

        private void Camera_ImageReady(object sender, ImageReadyEventArgs e)
        {
            var fileName = e.RawFileName;
            _imageData = _imageDataProcessor.ReadRaw(fileName);
            oSignalEvent.Set();
        }
    }
}
