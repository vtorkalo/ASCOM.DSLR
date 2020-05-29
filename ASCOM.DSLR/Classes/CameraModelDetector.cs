using ASCOM.DSLR.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ASCOM.Utilities;
using Logging;

namespace ASCOM.DSLR.Classes
{
    public class CameraModelDetector
    {
        private ImageDataProcessor _imageDataProcessor;
        private int[,] _imageData;
        private bool boolCameraError = false;
        ExposureFailedEventArgs exposureFailedEventArgs;


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
            camera.ExposureFailed += Camera_ExposureFailed;
            camera.StorePath = storePath;
            camera.Iso = 200;
            camera.ImageFormat = Enums.ImageFormat.RAW;
            camera.IsLiveViewMode = false;
            boolCameraError = false;

            camera.StartExposure(1, true);

            // modified to checked if the signal was set as opposed to a timeout occured

            //TESTING without the if. Looks like it is working for Nikon without IF statement


            oSignalEvent.WaitOne(60 * 1000);
            oSignalEvent.Reset();

            if (_imageData != null)
            {
                result = new CameraModel();
                result.ImageWidth = _imageData.GetLength(0);
                result.ImageHeight = _imageData.GetLength(1);
                result.SensorWidth = 22.5;
                result.SensorHeight = 15;
                result.Name = model;
            }


            /*if (oSignalEvent.WaitOne(60 * 1000))
            {
                oSignalEvent.Reset();

                if (!boolCameraError && (_imageData != null))
                {
                    result = new CameraModel();
                    result.ImageWidth = _imageData.GetLength(0);
                    result.ImageHeight = _imageData.GetLength(1);
                    result.SensorWidth = 22.5;
                    result.SensorHeight = 15;
                    result.Name = model;
                }
                else
                {
                    Logger.WriteTraceMessage("CameraModelDetector.GetCameraModel: Camera Exposure failed, msg = " + exposureFailedEventArgs.Message + "'");

                    throw new DriverException("Camera Exposure failed, msg'" + exposureFailedEventArgs.Message + "'");
                }
            }
            else
            {
                // TODO: figure out how to handle this better....  This will just throw an exception to the user and close the app
                Logger.WriteTraceMessage("CameraModelDetector.GetCameraModel: timeout waiting for setup exposure");

                throw new DriverException("Timeout waiting for setup exposure");

            }*/

            return result;
        }

        private void Camera_ImageReady(object sender, ImageReadyEventArgs e)
        {
            Logger.WriteTraceMessage("CameraModelDetector.Camera_ImageReady: filename = '" + e.RawFileName.ToString() + "'");

            var fileName = e.RawFileName;
            _imageData = _imageDataProcessor.ReadRaw(fileName);
            oSignalEvent.Set();
        }

        private void Camera_ExposureFailed(object sender, ExposureFailedEventArgs e)
        {
            Logger.WriteTraceMessage("CameraModelDetector.Camera_Exposurefailed: message = '" + e.Message + "'");

            exposureFailedEventArgs = e;
            boolCameraError = true;
            oSignalEvent.Set();
        }
    }
}
