using ASCOM.DSLR.Enums;
using ASCOM.DSLR.Interfaces;
using EOSDigital.API;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ASCOM.DSLR.Classes
{
    public abstract class BaseCamera
    {
        public BaseCamera(List<CameraModel> cameraModelsHistory)
        {
            _cameraModelsHistory = cameraModelsHistory;
        }

        protected CameraModel _cameraModel;
        protected List<CameraModel> _cameraModelsHistory;

        public CameraModel CameraModel
        {
            get
            {
                if (_cameraModel == null)
                {
                    _cameraModel = ScanCameras();
                }

                return _cameraModel;
            }
        }
        
        public CameraValue[] TvList;
        public CameraValue[] ISOList;

        public bool IsLiveViewMode { get; set; }

        protected string RenameFile(string downloadedFilePath, double duration, DateTime startTime)
        {
            var fileInfo = new FileInfo(downloadedFilePath);
            string newFileName = GetFileName(duration, startTime);
            string newFilePath = Path.ChangeExtension(Path.Combine(StorePath, newFileName), fileInfo.Extension);
            File.Move(downloadedFilePath, newFilePath);
            return newFilePath;
        }
        public LiveViewZoom LiveViewZoom { get; set; }

        protected string GetFileName(double duration, DateTime startTime)
        {
            duration = Math.Round(duration, 6);
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ",";
            return string.Format("IMG_{0}s_{1}iso_{2}C_{3}", duration.ToString(nfi), Iso, SensorTemperature, startTime.ToString("yyyy-MM-dd--HH-mm-ss"));
        }

        protected double GetSensorTemperature(string filePath)
        {
            double sensorTemperature = 0;
            var exifToolWrapper = new ExifToolWrapper();
            exifToolWrapper.Run(filePath);

            var exifRecord = exifToolWrapper.SingleOrDefault(e => e.name == "Camera Temperature").value;

            if (!string.IsNullOrEmpty(exifRecord))
            {
                exifRecord = Regex.Replace(exifRecord, "[^0-9.-]", "");
                int temperature;
                if (!string.IsNullOrEmpty(exifRecord) && int.TryParse(exifRecord, out temperature))
                {
                    sensorTemperature = temperature;
                }
            }

            return sensorTemperature;
        }

        public string StorePath { get; set; }
        public double SensorTemperature { get; protected set; }

        public abstract CameraModel ScanCameras();

        public CameraModel GetCameraModel(string cameraDescription)
        {
            var cameraModel = _cameraModelsHistory.FirstOrDefault(c => c.Name == cameraDescription); //try get sensor params from history
            if (cameraModel == null)
            {
                var cameraModelDetector = new CameraModelDetector(new ImageDataProcessor());
                cameraModel = cameraModelDetector.GetCameraModel((IDslrCamera)this, StorePath);//make test shot to determine height/width
            }

            return cameraModel;
        }

        public short Iso
        {
            get; set;
        }

        public virtual short MinIso
        {
            get
            {
                return IsoValues.Min();
            }
        }

        public virtual short MaxIso
        {
            get
            {
                return IsoValues.Max();
            }
        }

        public ImageFormat ImageFormat { get; set; }

        public List<short> IsoValues
        {
            get
            {
                List<short> result = null;

                if (ISOList != null && ISOList.Any())
                {
                    result = ISOList.Select(i => (short)i.DoubleValue).Where(i => i > 0).ToList();
                }
                else
                {
                    result = ISOValues.Values.Where(v => v.DoubleValue < short.MaxValue && v.DoubleValue > 0).Select(v => (short)v.DoubleValue).ToList();
                }

                return result;
            }
        }

        public int LvFrameWidth { get; protected set; }

        public int LvFrameHeight { get; protected set; }

        public int FrameWidth
        {
            get
            {
                return !IsLiveViewMode ? CameraModel.ImageWidth : LvFrameWidth;
            }
        }

        public int FrameHeight
        {
            get
            {
                return !IsLiveViewMode ? CameraModel.ImageHeight : LvFrameHeight;
            }
        }

        public double SensorSizeX
        {
            get
            {
                return CameraModel.SensorWidth;
            }
        }

        public double SensorSizeY
        {
            get
            {
                return CameraModel.SensorHeight;
            }
        }

        public double PixelSizeX
        {
            get
            {
                double pixelSize = SensorSizeX / FrameWidth * 1000;
                return pixelSize;
            }
        }

        public double PixelSizeY
        {
            get
            {
                double pixelSize = SensorSizeY / FrameHeight * 1000;
                return pixelSize;
            }
        }

        public bool UseExternalShutter { get; set; }
        public string ExternalShutterPort { get; set; }
    }
}
