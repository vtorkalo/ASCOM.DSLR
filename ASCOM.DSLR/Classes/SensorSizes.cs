using System.Collections.Generic;

namespace ASCOM.DSLR.Classes
{

    public class CameraModel
    {
        public string[] Names;
        public double SensorWidth;
        public double SensorHeight;
        public int ImageWidth;
        public int ImageHeight;
    }

    public class SensorSizes
    {
        public static List<CameraModel> Models = new List<CameraModel>
        {
         new CameraModel
{
Names = new string[]{"EOS 300D", "Digital Rebel", "Kiss Digital", "300D"},
SensorWidth = 22.7,
SensorHeight = 15.1,
ImageWidth = 3072,
ImageHeight = 2048,
},
new CameraModel
{
Names = new string[]{"EOS 350D", "Digital Rebel XT", "Kiss Digital N", "350D", "XT"},
SensorWidth = 22.2,
SensorHeight = 14.8,
ImageWidth = 3456,
ImageHeight = 2304,
},
new CameraModel
{
Names = new string[]{"EOS 400D", "Digital Rebel XTi", "Kiss Digital X", "400D", "XTi"},
SensorWidth = 22.2,
SensorHeight = 14.8,
ImageWidth = 3888,
ImageHeight = 2592,
},
new CameraModel
{
Names = new string[]{"EOS 450D", "Rebel XSi", "Kiss X2", "450D"},
SensorWidth = 22.2,
SensorHeight = 14.8,
ImageWidth = 4272,
ImageHeight = 2848,
},
new CameraModel
{
Names = new string[]{"EOS 500D", "Rebel T1i", "Kiss X3", "500D"},
SensorWidth = 22.3,
SensorHeight = 14.9,
ImageWidth = 4752,
ImageHeight = 3168,
},
new CameraModel
{
Names = new string[]{"EOS 550D", "Rebel T2i", "Kiss X4", "550D"},
SensorWidth = 22.3,
SensorHeight = 14.9,
ImageWidth = 5184,
ImageHeight = 3456,
},
new CameraModel
{
Names = new string[]{"EOS 600D", "Rebel T3i", "Kiss X5", "600D"},
SensorWidth = 22.3,
SensorHeight = 14.9,
ImageWidth = 5184,
ImageHeight = 3456,
},
new CameraModel
{
Names = new string[]{"EOS 650D", "Rebel T4i", "Kiss X6i", "650D"},
SensorWidth = 22.3,
SensorHeight = 14.9,
ImageWidth = 5184,
ImageHeight = 3456,
},
new CameraModel
{
Names = new string[]{"EOS 700D", "Rebel T5i", "Kiss X7i", "700D"},
SensorWidth = 22.3,
SensorHeight = 14.9,
ImageWidth = 5184,
ImageHeight = 3456,
},
new CameraModel
{
Names = new string[]{"EOS 750D", "Rebel T6i", "Kiss X8i", "750D"},
SensorWidth = 22.3,
SensorHeight = 14.9,
ImageWidth = 6000,
ImageHeight = 4000,
},
new CameraModel
{
Names = new string[]{"EOS 760D", "Rebel T6s", "8000D", "760D"},
SensorWidth = 22.3,
SensorHeight = 14.9,
ImageWidth = 6000,
ImageHeight = 4000,
},
new CameraModel
{
Names = new string[]{"EOS 800D", "Rebel T7i", "Kiss X9i", "800D"},
SensorWidth = 22.3,
SensorHeight = 14.9,
ImageWidth = 6000,
ImageHeight = 4000,
},
new CameraModel
{
Names = new string[]{"EOS 100D", "Rebel SL1", "Kiss X7", "100D"},
SensorWidth = 22.3,
SensorHeight = 14.9,
ImageWidth = 5184,
ImageHeight = 3456,
},
new CameraModel
{
Names = new string[]{"EOS 200D", "Rebel SL2", "Kiss X8", "200D"},
SensorWidth = 22.3,
SensorHeight = 14.9,
ImageWidth = 6000,
ImageHeight = 4000,
},
new CameraModel
{
Names = new string[]{"EOS 1000D", "Rebel XS", "Kiss F", "1000D"},
SensorWidth = 22.2,
SensorHeight = 14.8,
ImageWidth = 3888,
ImageHeight = 2592,
},
new CameraModel
{
Names = new string[]{"EOS 1100D", "Rebel T3", "Kiss X50", "1100D"},
SensorWidth = 22.2,
SensorHeight = 14.7,
ImageWidth = 4272,
ImageHeight = 2848,
},
new CameraModel
{
Names = new string[]{"EOS 1200D", "Rebel T5", "Kiss X70", "1200D"},
SensorWidth = 22.3,
SensorHeight = 14.9,
ImageWidth = 5184,
ImageHeight = 3456,
},
new CameraModel
{
Names = new string[]{"EOS 1300D", "Rebel T6", "Kiss X80", "1300D"},
SensorWidth = 22.3,
SensorHeight = 14.9,
ImageWidth = 5184,
ImageHeight = 3456,
},
new CameraModel
{
Names = new string[]{"EOS 77D", "EOS 9000D", "77D"},
SensorWidth = 22.3,
SensorHeight = 14.9,
ImageWidth = 6000,
ImageHeight = 4000,
},
new CameraModel
{
Names = new string[]{"EOS 30D", "30D"},
SensorWidth = 22.5,
SensorHeight = 15,
ImageWidth = 3504,
ImageHeight = 2336,
},
new CameraModel
{
Names = new string[]{"EOS 40D", "40D"},
SensorWidth = 22.2,
SensorHeight = 14.8,
ImageWidth = 3888,
ImageHeight = 2592,
},
new CameraModel
{
Names = new string[]{"EOS 50D", "50D"},
SensorWidth = 22.3,
SensorHeight = 14.9,
ImageWidth = 4752,
ImageHeight = 3168,
},
new CameraModel
{
Names = new string[]{"EOS 60D", "60D"},
SensorWidth = 22.3,
SensorHeight = 14.9,
ImageWidth = 5184,
ImageHeight = 3456,
},
new CameraModel
{
Names = new string[]{"EOS 60Da", "60Da"},
SensorWidth = 22.3,
SensorHeight = 14.9,
ImageWidth = 5184,
ImageHeight = 3456,
},
new CameraModel
{
Names = new string[]{"EOS 70D", "70D"},
SensorWidth = 22.5,
SensorHeight = 15,
ImageWidth = 5472,
ImageHeight = 3648,
},
new CameraModel
{
Names = new string[]{"EOS 77D", "77D"},
SensorWidth = 22.3,
SensorHeight = 14.9,
ImageWidth = 6000,
ImageHeight = 4000,
},
new CameraModel
{
Names = new string[]{"EOS 80D", "80D"},
SensorWidth = 22.3,
SensorHeight = 14.9,
ImageWidth = 6000,
ImageHeight = 4000,
},
new CameraModel
{
Names = new string[]{"EOS 7D", "7D"},
SensorWidth = 22.3,
SensorHeight = 14.9,
ImageWidth = 5184,
ImageHeight = 3456,
},
new CameraModel
{
Names = new string[]{"EOS 7D Mark II", "7D Mark II", "7D-MkII"},
SensorWidth = 22.4,
SensorHeight = 15,
ImageWidth = 5472,
ImageHeight = 3648,
},
new CameraModel
{
Names = new string[]{"EOS 5D", "5D"},
SensorWidth = 35.8,
SensorHeight = 23.9,
ImageWidth = 4368,
ImageHeight = 2912,
},
new CameraModel
{
Names = new string[]{"EOS 5D Mark II", "5D Mark II", "5D-MkII"},
SensorWidth = 36,
SensorHeight = 24,
ImageWidth = 5616,
ImageHeight = 3744,
},
new CameraModel
{
Names = new string[]{"EOS 5D Mark III", "5D Mark III", "5D-MkIII"},
SensorWidth = 36,
SensorHeight = 24,
ImageWidth = 5760,
ImageHeight = 3840,
},
new CameraModel
{
Names = new string[]{"EOS 5D Mark IV", "5D Mark IV", "5D-MkIV"},
SensorWidth = 36,
SensorHeight = 24,
ImageWidth = 6720,
ImageHeight = 4480,
},
new CameraModel
{
Names = new string[]{"EOS 5Ds", "5Ds"},
SensorWidth = 36,
SensorHeight = 24,
ImageWidth = 8688,
ImageHeight = 5792,
},
new CameraModel
{
Names = new string[]{"EOS 5Ds R", "5Ds R"},
SensorWidth = 36,
SensorHeight = 24,
ImageWidth = 8688,
ImageHeight = 5792,
},
new CameraModel
{
Names = new string[]{"EOS 6D", "6D"},
SensorWidth = 35.8,
SensorHeight = 23.9,
ImageWidth = 5472,
ImageHeight = 3648,
},
new CameraModel
{
Names = new string[]{"EOS 6D Mark II", "6D Mark II", "6D-MkII"},
SensorWidth = 36,
SensorHeight = 24,
ImageWidth = 6240,
ImageHeight = 4160,
},
new CameraModel
{
Names = new string[]{"EOS-1D Mark III", "1D Mark III", "1D-MkIII"},
SensorWidth = 28.1,
SensorHeight = 18.7,
ImageWidth = 3888,
ImageHeight = 2592,
},
new CameraModel
{
Names = new string[]{"EOS-1Ds Mark III", "1Ds Mark III", "1Ds-MkIII"},
SensorWidth = 36,
SensorHeight = 24,
ImageWidth = 5616,
ImageHeight = 3744,
},
new CameraModel
{
Names = new string[]{"EOS-1D Mark IV", "1D Mark IV", "1D-MkIV"},
SensorWidth = 27.9,
SensorHeight = 18.6,
ImageWidth = 4896,
ImageHeight = 3264,
},
new CameraModel
{
Names = new string[]{"EOS-1D X", "1D X"},
SensorWidth = 36,
SensorHeight = 24,
ImageWidth = 5184,
ImageHeight = 3456,
},
new CameraModel
{
Names = new string[]{"EOS-1D X Mark II", "1D X Mark II", "1DX-MkII"},
SensorWidth = 36,
SensorHeight = 24,
ImageWidth = 5472,
ImageHeight = 3648,
},
new CameraModel
{
Names = new string[]{"EOS-1D C", "1D C"},
SensorWidth = 36,
SensorHeight = 24,
ImageWidth = 5184,
ImageHeight = 3456,
}


        };

    }
}