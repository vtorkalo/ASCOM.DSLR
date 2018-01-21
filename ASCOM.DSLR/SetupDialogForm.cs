using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using ASCOM.Utilities;
using ASCOM.DSLR;
using ASCOM.DeviceInterface;
using ASCOM.DSLR.Classes;
using ASCOM.DSLR.Enums;
using System.IO;
using System.Linq;
using EOSDigital.API;
using System.Threading;

namespace ASCOM.DSLR
{
    [ComVisible(false)]					
    public partial class SetupDialogForm : Form
    {
        public SetupDialogForm(CameraSettings settings)
        {
            Settings = settings;
            InitializeComponent();
            InitUI();
        }

        private void cmdOK_Click(object sender, EventArgs e) // OK button event handler
        {
            Settings.TraceLog = chkTrace.Checked;
            Settings.CameraMode = (CameraMode)cbImageMode.SelectedItem;
            Settings.IntegrationApi = (IntegrationApi)cbIntegrationApi.SelectedItem;

            if (Directory.Exists(tbSavePath.Text))
            {
                Settings.StorePath = tbSavePath.Text;
            }
            Settings.Iso = (short)cbIso.SelectedValue;

            if (!string.IsNullOrEmpty(tbBackyardEosPort.Text))
            {
                Settings.BackyardEosPort = int.Parse(tbBackyardEosPort.Text);
            }
            Settings.EnableBinning = chkEnableBin.Checked;
            Settings.BinningMode = (BinningMode)cbBinningMode.SelectedItem;
        }

        private void cmdCancel_Click(object sender, EventArgs e) // Cancel button event handler
        {
            Close();
        }

        private void BrowseToAscom(object sender, EventArgs e) // Click on ASCOM logo event handler
        {
            try
            {
                System.Diagnostics.Process.Start("http://ascom-standards.org/");
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }

        public CameraSettings Settings { get; private set; }

        private void InitUI()
        {
            chkTrace.Checked = Settings.TraceLog;

            cbImageMode.Items.Clear();
            cbImageMode.Items.Add(CameraMode.RGGB);
            cbImageMode.Items.Add(CameraMode.Color16);
            cbImageMode.Items.Add(CameraMode.ColorJpg);
            cbImageMode.SelectedItem = Settings.CameraMode;

            chkEnableBin.Checked = Settings.EnableBinning;
            EnableBinChanged();

            cbIntegrationApi.Items.Add(IntegrationApi.CanonSdk);
            cbIntegrationApi.Items.Add(IntegrationApi.BackyardEOS);
            cbIntegrationApi.Items.Add(IntegrationApi.DigiCamControl);
            cbIntegrationApi.SelectedItem = Settings.IntegrationApi;
            ConnectionMethodChanged();

            cbBinningMode.Items.Add(BinningMode.Sum);
            cbBinningMode.Items.Add(BinningMode.Median);
            cbBinningMode.SelectedItem = Settings.BinningMode;

            var isoValues = ISOValues.Values.Where(v => v.DoubleValue <= short.MaxValue && v.DoubleValue>0).Select(v => (short)v.DoubleValue);
            cbIso.DisplayMember = "display";
            cbIso.ValueMember = "value";
            cbIso.DataSource = isoValues.Select(v => new { value = v, display = v.ToString() }).ToArray();
            cbIso.SelectedValue = Settings.Iso;

            tbSavePath.Text = Settings.StorePath;

            tbBackyardEosPort.Text = Settings.BackyardEosPort.ToString();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(tbSavePath.Text))
            {
                folderBrowserDialog.SelectedPath = tbSavePath.Text;
            }

            var thread = new Thread(new ParameterizedThreadStart(param => 
            {
                if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
                {
                    Invoke((Action)delegate { tbSavePath.Text = folderBrowserDialog.SelectedPath; });
                }
            }));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void tbBackyardEosPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void chkEnableBin_CheckedChanged(object sender, EventArgs e)
        {
            EnableBinChanged();
        }

        private void EnableBinChanged()
        {
            if (chkEnableBin.Checked)
            {
                cbImageMode.SelectedItem = CameraMode.RGGB;
                cbImageMode.Enabled = false;
                cbBinningMode.Enabled = true;
            }
            else
            {
                cbImageMode.Enabled = true;
                cbBinningMode.Enabled = false;
            }
        }

        private void lblBinningMode_Click(object sender, EventArgs e)
        {

        }

        private void cbBinningMode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbIntegrationApi_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConnectionMethodChanged();
        }

        private void ConnectionMethodChanged()
        {
            tbBackyardEosPort.Enabled = (IntegrationApi)cbIntegrationApi.SelectedItem == IntegrationApi.BackyardEOS;
        }
    }
}