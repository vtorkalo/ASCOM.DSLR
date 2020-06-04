using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Drawing;

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
                { }

                var aaa = driver.ImageArray;

                Int32[,] bbb = (Int32[,])aaa;

                Bitmap RawIMG = createImage(driver.CameraXSize, bbb);

                SDK_LiveViewUpdated(RawIMG);

                RawIMG.Save("C:\\temp\\test.png");

                //pictTestfrm.Image = RawIMG;
                

            }
        }


        private void SDK_LiveViewUpdated(Bitmap img)
        {
            float w;
            float h;
                 using (Graphics g = pictTestfrm.CreateGraphics())
                {
                    float LVBratio = pictTestfrm.Width / (float)pictTestfrm.Height;
                    float LVration = img.Width / (float)img.Height;
                    if (LVBratio < LVration)
                    {
                        w = pictTestfrm.Width;
                        h = (int)(pictTestfrm.Width / LVration);
                    }
                    else
                    {
                        w = (int)(pictTestfrm.Height * LVration);
                        h = pictTestfrm.Height;
                    }
                    g.DrawImage(img, 0, 0, w, h);
                }
                img.Dispose();
         }
  


        Bitmap createImage(int width, Int32[,] Iarray)
        {
            Bitmap bmp = new Bitmap(Iarray.GetLength(1), Iarray.GetLength(0), System.Drawing.Imaging.PixelFormat.Format16bppRgb555);

            for (int y = 0; y < Iarray.GetLength(0); y++)
            {
                for (int x = 0; x < width; x++)
                {
                    bmp.SetPixel(x, y, Color.FromArgb(Iarray[x,y]));
                }
            }
            return bmp;
        }


        Bitmap createImage(int width, Int32[,,] Iarray)
        {
           Bitmap bmp = new Bitmap(Iarray.GetLength(0), Iarray.GetLength(1), System.Drawing.Imaging.PixelFormat.Format16bppRgb565);

            for (int y = 0; y < Iarray.GetLength(1); y++)
            {
                for (int x = 0; x < Iarray.GetLength(0); x++)
                {
                    for (int w = 0; w < Iarray.GetLength(2); w++)
                    {
                        bmp.SetPixel(x, y, Color.FromArgb(Iarray[x, y, w]));
                    }
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
