using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Media.Imaging;
using ASCOM.DSLR.Classes;

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




        private async void button1_Click(object sender, EventArgs e)
        {
           
            double exposuretime =  Convert.ToDouble(cmdExposure.SelectedItem.ToString());
            if (IsConnected)
            {
                //driver.StartExposure(exposuretime, true);

                Cursor.Current = Cursors.WaitCursor;
                btnTakeImage.Enabled = false;

                await Task.Run(async () =>
                {
                    driver.StartExposure(exposuretime, true);
                    while (!driver.ImageReady)
                    {
                        await Task.Delay(20);
                    }
                });


                if (chkPreview.Checked)
                {
                    Bitmap RawIMG;

                    try
                    {
                        Int32[,] _imagearray = (Int32[,])driver.ImageArray;
                        RawIMG = Contrast(ColorBalance(createImage(_imagearray), 50, 50, 50), 15); //createImage(_imagearray);

                    }
                    catch
                    {
                        Int32[,,] _imagearray = (Int32[,,])driver.ImageArray;
                        RawIMG = Contrast(ColorBalance(createImage(_imagearray), 50, 50, 50), 15);

                    }

                    pictTestfrm.Image = RawIMG;
                }
       
                btnTakeImage.Enabled = true;
                Cursor.Current = Cursors.Default;

            }
        }



        Bitmap createImage(Int32[,] Iarray)
        {
            Bitmap bmp = new Bitmap(Iarray.GetLength(0), Iarray.GetLength(1), System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            int r = 0;
            int g = 0;
            int g1 = 0;
            int b = 0;
            int R = 0;
            int G = 0;
            int B = 0;

            int G1 = 0, G2 = 0, G3 = 0, G4 = 0;
            int B1 = 0, B2 = 0, B3 = 0, B4 = 0;
            int R1 = 0, R2 = 0, R3 = 0, R4 = 0;

            
            for (int y = 0; y < Iarray.GetLength(1); y++)
            {

                                
                for (int x = 0; x < Iarray.GetLength(0); x++)
                {

                    unsafe {
                        fixed (int* p = &Iarray[x, y])
                        {
                            int* p2 = p;

                            
                            r = *p2 / 255;
                            r = (r < 0) ? 0 : r;
                            r = (r > 255) ? 254 : r;
                            p2 += 1;

                            g = *p2 / 255;
                            g = (g < 0) ? 0 : g;
                            g = (g > 255) ? 254 : g;
                            p2 += 1;

                            g1 = *p2 / 255;
                            g1 = (g1 < 0) ? 0 : g1;
                            g1 = (g1 > 255) ? 254 : g1;
                            p2 += 1;


                            b = *p2/255;
                            b = (b < 0) ? 0 : b;
                            b = (b > 255) ? 254 : b;
                            


                        }

                        R = r;
                        G = (g + g1)/2;
                        B = b;
                    }


                    R = (R < 0) ? 0 : R;
                    R = (R > 255) ? 254 : R;

                    G = (G < 0) ? 0 : G;
                    G = (G > 255) ? 254 : G;

                    B = (B < 0) ? 0 : B;
                    B = (B > 255) ? 254 : B;

                    Color Color = Color.FromArgb(R, G, B);
                    bmp.SetPixel(x, y, Color);
                    R = 0;
                    G = 0;
                    B = 0;

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
                    b = (Iarray[x, y, 0] > 255) ? Iarray[x, y, 0] / 255 : Iarray[x, y, 0];
                    b = (b > 255)?254 : b;
                    g = (Iarray[x, y, 1] > 255) ? Iarray[x, y, 1] / 255 : Iarray[x, y, 1];
                    g = (g > 255) ? 254 : g;
                    r = (Iarray[x, y, 2] > 255) ? Iarray[x, y, 2] / 255 : Iarray[x, y, 2];
                    r = (r > 255) ? 254 : r;
                    Color Color = Color.FromArgb(r,g, b);
                    bmp.SetPixel(x, y, Color);
                }
            }

            return bmp;
        }


        Bitmap ColorBalance(Bitmap sourceBitmap, byte blueLevel, byte greenLevel, byte redLevel)
        {
            BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0,
                                        sourceBitmap.Width, sourceBitmap.Height),
                                        ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);


            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];


            System.Runtime.InteropServices.Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);


            sourceBitmap.UnlockBits(sourceData);


            float blue = 0;
            float green = 0;
            float red = 0;


            float blueLevelFloat = blueLevel;
            float greenLevelFloat = greenLevel;
            float redLevelFloat = redLevel;


            for (int k = 0; k + 4 < pixelBuffer.Length; k += 4)
            {
                blue = 255.0f / blueLevelFloat * (float)pixelBuffer[k];
                green = 255.0f / greenLevelFloat * (float)pixelBuffer[k + 1];
                red = 255.0f / redLevelFloat * (float)pixelBuffer[k + 2];

                if (blue > 255) { blue = 255; }
                else if (blue < 0) { blue = 0; }

                if (green > 255) { green = 255; }
                else if (green < 0) { green = 0; }

                if (red > 255) { red = 255; }
                else if (red < 0) { red = 0; }

                pixelBuffer[k] = (byte)blue;
                pixelBuffer[k + 1] = (byte)green;
                pixelBuffer[k + 2] = (byte)red;
            }


            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);


            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0,
                                        resultBitmap.Width, resultBitmap.Height),
                                       ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);


            System.Runtime.InteropServices.Marshal.Copy(pixelBuffer, 0, resultData.Scan0, pixelBuffer.Length);
            resultBitmap.UnlockBits(resultData);


            return resultBitmap;
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




        private void button1_Click_1(object sender, EventArgs e)
        {
            Bitmap RawIMG;

            ImageDataProcessor imgp = new ImageDataProcessor();


            Int32[,,] _imagearray = imgp.ReadAndDebayerRaw("C:\\temp\\IMG_0,00025s_200iso_0C_2020-06-14--18-06-36.nef");

            //RawIMG = Contrast(ColorBalance(createImage(_imagearray),50, 50, 50),15);
            RawIMG = createImage(_imagearray);
            RawIMG.Save("C:\\temp\\test.png");
            
            pictTestfrm.Image = RawIMG;


        }

        Bitmap Contrast(Bitmap sourceBitmap, int threshold)
        {
            BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0,
                                        sourceBitmap.Width, sourceBitmap.Height),
                                        ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);


            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];


            System.Runtime.InteropServices.Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);


            sourceBitmap.UnlockBits(sourceData);


            double contrastLevel = Math.Pow((100.0 + threshold) / 100.0, 2);


            double blue = 0;
            double green = 0;
            double red = 0;


            for (int k = 0; k + 4 < pixelBuffer.Length; k += 4)
            {
                blue = ((((pixelBuffer[k] / 255.0) - 0.5) *
                            contrastLevel) + 0.5) * 255.0;


                green = ((((pixelBuffer[k + 1] / 255.0) - 0.5) *
                            contrastLevel) + 0.5) * 255.0;


                red = ((((pixelBuffer[k + 2] / 255.0) - 0.5) *
                            contrastLevel) + 0.5) * 255.0;


                if (blue > 255)
                { blue = 255; }
                else if (blue < 0)
                { blue = 0; }


                if (green > 255)
                { green = 255; }
                else if (green < 0)
                { green = 0; }


                if (red > 255)
                { red = 255; }
                else if (red < 0)
                { red = 0; }


                pixelBuffer[k] = (byte)blue;
                pixelBuffer[k + 1] = (byte)green;
                pixelBuffer[k + 2] = (byte)red;
            }


            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);


            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0,
                                        resultBitmap.Width, resultBitmap.Height),
                                        ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);


            System.Runtime.InteropServices.Marshal.Copy(pixelBuffer, 0, resultData.Scan0, pixelBuffer.Length);
            resultBitmap.UnlockBits(resultData);


            return resultBitmap;
        }





    }
}
