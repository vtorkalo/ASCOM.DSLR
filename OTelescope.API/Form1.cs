using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace OTelescope.SampleAPI
{
    public partial class Form1 : Form
    {
        private OTelescopeTcpClient _backyardTcpClient;
        private OTelescopeTcpClient BackyardTcpClient
        {
            get
            {
                if (_backyardTcpClient != null)
                    return _backyardTcpClient;

                try
                {
                    _backyardTcpClient = new OTelescopeTcpClient(1491);
                }
                catch (Exception ex)
                {
                    _backyardTcpClient = null;
                }

                return _backyardTcpClient;
            }
        }

        public Form1()
        {
            InitializeComponent();

            // This is a neet way to start a background thread to make basic 
            // status calls such as getting the status.  Calling these in a 
            // Background thread ensures your application remains responsive while
            // these calls are made.  If you make these calls in a forground thread
            // you app will temporarily freeze while the call is made.  This fixes that.
            ThreadPool.QueueUserWorkItem(state =>
            {
                while (true)
                {
                    try
                    {
                        if (BackyardTcpClient == null)
                            continue;

                        // These calls are made in the current background thread to ensure
                        // the calling app foreground UI thread remains responsive.
                        var status = BackyardTcpClient.SendCommand("getstatus", verbose: false);
                        var ready = BackyardTcpClient.SendCommand("getispictureready", verbose: false);
                        var filepath = ready.Equals(bool.TrueString)
                            ? BackyardTcpClient.SendCommand("getpicturepath", verbose: false)
                            : "";

                        // Now we need to make sure we update the UI only within the UI Thread.
                        this.DoInUiThread(() =>
                        {
                            textStatus.Text = status;
                            txtIsPictureReady.Text = ready;
                            txtPicturePath.Text = filepath;
                        });
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        // Some breathing room;
                        Thread.Sleep(500);
                    }
                }

            });
        }

   

        /// <summary>
        /// Making sure we are closing the TcpClient when the are
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(CancelEventArgs e)
        {
            if (BackyardTcpClient != null)
                BackyardTcpClient.Dispose();
        }

        private void btnTakePicture_Click(object sender, EventArgs e)
        {
            var duration = numericUpDownDuration.Value.ToString(CultureInfo.InvariantCulture);
            var iso = comboBoxIso.Text;
            var bin = 1;
            var quality = comboBoxImageQuality.Text.ToLowerInvariant();

            txtLastError.Text = "";
            BackyardTcpClient.SendCommand(string.Format("takepicture quality:{0} duration:{1} iso:{2} bin:{3}", quality, duration, iso, bin));
        }

        private void btnGetLastError_Click(object sender, EventArgs e)
        {
            txtLastError.Text = BackyardTcpClient.SendCommand("getlasterror");
        }

        private void btnGetStatus_Click(object sender, EventArgs e)
        {
            textStatus.Text = BackyardTcpClient.SendCommand("getstatus");
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            BackyardTcpClient.SendCommand("abort");
        }

        private void btnGetPicturePath_Click(object sender, EventArgs e)
        {
            txtPicturePath.Text = BackyardTcpClient.SendCommand("getpicturepath");
        }

        private void btnGetIsPictureReady_Click(object sender, EventArgs e)
        {
            txtIsPictureReady.Text = BackyardTcpClient.SendCommand("getispictureready");
        }


        private void btnConnect_Click(object sender, EventArgs e)
        {
            BackyardTcpClient.SendCommand("connect");

        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            BackyardTcpClient.SendCommand("disconnect");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtCameraPixelSize.Text = BackyardTcpClient.SendCommand("getcamerapixelsize");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtCameraModel.Text = BackyardTcpClient.SendCommand("getcameramodel");
        }

        private void btnThemeOn_Click(object sender, EventArgs e)
        {
            BackyardTcpClient.SendCommand("toggletheme on");
        }

        private void btnThemeOff_Click(object sender, EventArgs e)
        {
            BackyardTcpClient.SendCommand("toggletheme off");
        }

        private void btnDitherOn_Click(object sender, EventArgs e)
        {
            BackyardTcpClient.SendCommand("toggledither on");
        }

        private void btnDitherOff_Click(object sender, EventArgs e)
        {
            BackyardTcpClient.SendCommand("toggledither off");
        }
    }
}

