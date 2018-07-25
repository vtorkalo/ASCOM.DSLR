using ASCOM.DSLR.Classes;
using CameraControl.Plugins.ExternalDevices;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ASCOM.DSLR
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var p1 =(int) Math.Pow(2, 14);
            var a = p1 >> 6;



            var p = new ImageDataProcessor();

            var detector = new CameraModelDetector(p);
            var m = detector.GetCameraModel(new CanonSdkCamera());

            var data0 = p.ReadRaw(@"d:\ascomdev\git\ASCOM.DSLR\testdata\test.dng-0000.dng");
      

            


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static void SaveData(int[,] data, string name)
        {
            var width = data.GetLength(0);
            var height = data.GetLength(1);
            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format24bppRgb);


            //create random pixels
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    byte r= 0;
                    byte g = 0;
                    byte b =0;

                    if (x % 2 == 0 && y % 2 == 0)
                    {//R
                        r = (byte)(data[x, y] >> 4);
                    }
                    else if (x % 2 == 0 && y % 2 == 1)
                    {//G
                        g = (byte)(data[x, y] >> 4);
                    }

                    else if (x % 2 == 1 && y % 2 == 0)
                    {//G2
                        g= (byte)(data[x, y] >> 4);
                    }
                    else if (x % 2 == 1 && y % 2 == 1)
                    {//B
                        b = (byte)(data[x, y] >> 4);
                    }

                    var color = Color.FromArgb(g, r, b);

                    //set ARGB value
                    bmp.SetPixel(x, y, color);
                }
            }

            bmp.Save(@"D:\eos\"+ name);
        }

    }
}
