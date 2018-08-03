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
            _imageData = null;
            camera.ConnectCamera();
            var model = camera.Model;
            camera.ImageReady += Camera_ImageReady;
            camera.StorePath = storePath;
            camera.Iso = 200;
            camera.StartExposure(1, true);

            oSignalEvent.WaitOne(60*1000); 
            oSignalEvent.Reset();

            CameraModel result = null;
            if (_imageData != null)
            {
                result = new CameraModel();
                result.ImageWidth = _imageData.GetLength(0);
                result.ImageHeight = _imageData.GetLength(1);
                result.SensorWidth = 22.5;
                result.SensorHeight = 15;
                result.Name = model;
            }

            return result;
        }

        private CameraModel cameraModel;
        private int[,] _imageData;

        private void Camera_ImageReady(object sender, ImageReadyEventArgs e)
        {
            var fileName = e.RawFileName;
            _imageData = _imageDataProcessor.ReadRaw(fileName);
            oSignalEvent.Set();
        }
    }
}
