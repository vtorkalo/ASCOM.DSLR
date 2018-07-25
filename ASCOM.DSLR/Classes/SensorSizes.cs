using System;
using System.Collections.Generic;

namespace ASCOM.DSLR.Classes
{

    [Serializable]
    public class CameraModel
    {
        public string Name;
        public double SensorWidth;
        public double SensorHeight;
        public int ImageWidth;
        public int ImageHeight;
    }   
}