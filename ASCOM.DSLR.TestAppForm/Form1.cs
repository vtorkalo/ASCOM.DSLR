using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Media.Imaging;

namespace ASCOM.DSLR
{
    public partial class Form1 : Form
    {

        private ASCOM.DriverAccess.Camera driver;

        public Form1()
        {
            InitializeComponent();
            SetUIState();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsConnected)
                driver.Connected = false;

            Properties.Settings.Default.Save();
        }

        private void buttonChoose_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.DriverId = ASCOM.DriverAccess.Camera.Choose(Properties.Settings.Default.DriverId);
            SetUIState();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (IsConnected)
            {
                driver.Connected = false;
                btnTakeImage.Enabled = false;
            }
            else
            {
                driver = new ASCOM.DriverAccess.Camera(Properties.Settings.Default.DriverId);
                driver.Connected = true;
                btnTakeImage.Enabled = true;
            }
            SetUIState();
        }

        private void SetUIState()
        {
            buttonConnect.Enabled = !string.IsNullOrEmpty(Properties.Settings.Default.DriverId);
            buttonChoose.Enabled = !IsConnected;
            buttonConnect.Text = IsConnected ? "Disconnect" : "Connect";

        }

        private bool IsConnected
        {
            get
            {
                return ((this.driver != null) && (driver.Connected == true));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            double exposuretime =  Convert.ToDouble(cmdExposure.SelectedItem.ToString());
            if (IsConnected)
            {
                driver.StartExposure(exposuretime, true);
                
                while (!driver.ImageReady)
                { System.Threading.Thread.Sleep(1000); }

                Int32[,] _imagearray = (Int32[,])driver.ImageArray;


                //var buffer = new byte[_imagearray.GetLength(0) * _imagearray.GetLength(1) * System.Runtime.InteropServices.Marshal.SizeOf(typeof(Int16))];
                //Buffer.BlockCopy(_imagearray, 0, buffer, 0, buffer.Length);

                //var flatarray = FlipAndConvert2d(_imagearray);


               // CreateBitmap(_imagearray.GetLength(0), _imagearray.GetLength(1), flatarray).Save("C:\\temp\\test11.png");

                //byte[] flatarraybyte = new byte[flatarray.Length * 2];
               // Buffer.BlockCopy(flatarray, 0, flatarraybyte, 0, flatarray.Length * 2);


                Bitmap RawIMG = createImage(_imagearray);

                RawIMG.Save("C:\\temp\\test.png");

                pictTestfrm.Image = RawIMG;

                //Bitmap _bit = ByteToImage(_imagearray.GetLength(0), _imagearray.GetLength(1),flatarraybyte);

                //     pictTestfrm.Image = RawIMG;


            }
        }


        // Create the Bitmap object and populate its pixel data with the stored pixel values.
        private Bitmap CreateBitmap(int width, int height, ushort[] pixels16)
        {
            

            Bitmap bmp = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            BitmapData bmd = bmp.LockBits(new Rectangle(0, 0, width, height),
                System.Drawing.Imaging.ImageLockMode.ReadOnly, bmp.PixelFormat);

            // This 'unsafe' part of the code populates the bitmap bmp with data stored in pixel16.
            // It does so using pointers, and therefore the need for 'unsafe'. 
            unsafe
            {
                int pixelSize = 3;
                int i, j, j1, i1;
                byte b;
                ushort sVal;
                double lPixval;

                for (i = 0; i < bmd.Height; ++i)
                {
                    byte* row = (byte*)bmd.Scan0 + (i * bmd.Stride);
                    i1 = i * bmd.Height;

                    for (j = 0; j < bmd.Width; ++j)
                    {
                        sVal = (ushort)(pixels16[i1 + j]);
                        lPixval = (sVal / 255.0); // Convert to a 255 value range
                        if (lPixval > 255) lPixval = 255;
                        if (lPixval < 0) lPixval = 0;
                        b = (byte)(lPixval);
                        j1 = j * pixelSize;
                        row[j1] = b;            // Red
                        row[j1 + 1] = b;            // Green
                        row[j1 + 2] = b;            // Blue
                    }
                }
            }
            bmp.UnlockBits(bmd);

            return bmp;
        }


        private Bitmap ByteToImage(int w, int h, byte[] pixels)
            {
                var bmp = new Bitmap(w, h, PixelFormat.Format16bppRgb555);
                byte bpp = 2;
                var BoundsRect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                BitmapData bmpData = bmp.LockBits(BoundsRect,
                                                ImageLockMode.WriteOnly,
                                                bmp.PixelFormat);
                // copy line by line:
                for (int y = 0; y < h; y++)
                System.Runtime.InteropServices.Marshal.Copy(pixels, y * w * bpp, bmpData.Scan0 + bmpData.Stride * y, w * bpp);
                bmp.UnlockBits(bmpData);

                return bmp;
            }


        private static ushort[] FlipAndConvert2d(Array input)
        {
                Int32[,] arr = (Int32[,])input;
                int width = arr.GetLength(0);
                int height = arr.GetLength(1);

                int length = width * height;
                ushort[] flatArray = new ushort[length];
                ushort value;

                unsafe
                {
                    fixed (Int32* ptr = arr)
                    {
                        int idx = 0, row = 0;
                        for (int i = 0; i < length; i++)
                        {
                            value = (ushort)ptr[i];

                            idx = ((i % height) * width) + row;
                            if ((i % (height)) == (height - 1)) row++;

                            ushort b = value;
                            flatArray[idx] = b;
                        }
                    }
                }
                return flatArray;
        }

     Bitmap createImage(Int32[,] Iarray)
        {
            Bitmap bmp = new Bitmap(Iarray.GetLength(0), Iarray.GetLength(1), System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            int r = 0;
            int g = 0;
            int g1 = 0;
            int b = 0;

            for (int y = 0; y < Iarray.GetLength(1); y++)
            {

                                
                for (int x = 0; x < Iarray.GetLength(0); x++)
                {

                    Color Color = Color.FromArgb(Iarray[x, y]);
                    bmp.SetPixel(x, y, Color);

                }

   
            }

            return bmp;

        }


        Bitmap createImage(Int32[,,] Iarray)
        {
            int r = 0;
            int g = 0;
            int b = 0;
            Bitmap bmp = new Bitmap(Iarray.GetLength(0), Iarray.GetLength(1), System.Drawing.Imaging.PixelFormat.Format32bppRgb);

            for (int y = 0; y < Iarray.GetLength(1); y++)
            {
                for (int x = 0; x < Iarray.GetLength(0); x++)
                {
                    b = Iarray[x, y, 0]/255;
                    b = (b > 255)?255 : b;
                    g = Iarray[x, y, 1]/255;
                    g = (g > 255) ? 255 : g;
                    r = Iarray[x, y, 2]/255;
                    r = (r > 255) ? 255 : r;
                    Color Color = Color.FromArgb(r,g, b);
                    bmp.SetPixel(x, y, Color);
                }
            }
            return bmp;
        }


        private void labelDriverId_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmdExposure.DropDownStyle = ComboBoxStyle.DropDownList;


        }

        private void cmdExposure_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
