namespace ASCOM.DSLR
{
    partial class SetupDialogForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.gbCameraSettings = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbLiveViewZoom = new System.Windows.Forms.ComboBox();
            this.lblLiveViewZoom = new System.Windows.Forms.Label();
            this.lblIso = new System.Windows.Forms.Label();
            this.tbSavePath = new System.Windows.Forms.TextBox();
            this.lblSavePhotosTo = new System.Windows.Forms.Label();
            this.chkEnableBin = new System.Windows.Forms.CheckBox();
            this.cbIntegrationApi = new System.Windows.Forms.ComboBox();
            this.cbShutterPort = new System.Windows.Forms.ComboBox();
            this.lbImageMode = new System.Windows.Forms.Label();
            this.cbBinningMode = new System.Windows.Forms.ComboBox();
            this.lbIntegrationApi = new System.Windows.Forms.Label();
            this.cbIso = new System.Windows.Forms.ComboBox();
            this.tbBackyardEosPort = new System.Windows.Forms.TextBox();
            this.lblBackyardEosPort = new System.Windows.Forms.Label();
            this.chkUseExternalShutter = new System.Windows.Forms.CheckBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.chkEnableLiveView = new System.Windows.Forms.CheckBox();
            this.chkSaveFile = new System.Windows.Forms.CheckBox();
            this.cbImageMode = new System.Windows.Forms.ComboBox();
            this.chkTrace = new System.Windows.Forms.CheckBox();
            this.picASCOM = new System.Windows.Forms.PictureBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btnAbout = new System.Windows.Forms.Button();
            this.gbCameraSettings.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picASCOM)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOK.Location = new System.Drawing.Point(559, 760);
            this.cmdOK.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(117, 50);
            this.cmdOK.TabIndex = 0;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(703, 760);
            this.cmdCancel.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(117, 52);
            this.cmdCancel.TabIndex = 1;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // gbCameraSettings
            // 
            this.gbCameraSettings.Controls.Add(this.tableLayoutPanel1);
            this.gbCameraSettings.Controls.Add(this.chkTrace);
            this.gbCameraSettings.Location = new System.Drawing.Point(28, 25);
            this.gbCameraSettings.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.gbCameraSettings.Name = "gbCameraSettings";
            this.gbCameraSettings.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.gbCameraSettings.Size = new System.Drawing.Size(789, 690);
            this.gbCameraSettings.TabIndex = 8;
            this.gbCameraSettings.TabStop = false;
            this.gbCameraSettings.Text = "Camera settings";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.11715F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.88285F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 153F));
            this.tableLayoutPanel1.Controls.Add(this.cbLiveViewZoom, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblLiveViewZoom, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblIso, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.tbSavePath, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.lblSavePhotosTo, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.chkEnableBin, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.cbIntegrationApi, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbShutterPort, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbImageMode, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.cbBinningMode, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.lbIntegrationApi, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbIso, 1, 11);
            this.tableLayoutPanel1.Controls.Add(this.tbBackyardEosPort, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblBackyardEosPort, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.chkUseExternalShutter, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnBrowse, 2, 10);
            this.tableLayoutPanel1.Controls.Add(this.chkEnableLiveView, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkSaveFile, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.cbImageMode, 1, 7);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(27, 35);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 13;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(728, 540);
            this.tableLayoutPanel1.TabIndex = 33;
            // 
            // cbLiveViewZoom
            // 
            this.cbLiveViewZoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLiveViewZoom.FormattingEnabled = true;
            this.cbLiveViewZoom.Location = new System.Drawing.Point(280, 82);
            this.cbLiveViewZoom.Margin = new System.Windows.Forms.Padding(4);
            this.cbLiveViewZoom.Name = "cbLiveViewZoom";
            this.cbLiveViewZoom.Size = new System.Drawing.Size(276, 33);
            this.cbLiveViewZoom.TabIndex = 56;
            // 
            // lblLiveViewZoom
            // 
            this.lblLiveViewZoom.AutoSize = true;
            this.lblLiveViewZoom.Location = new System.Drawing.Point(4, 78);
            this.lblLiveViewZoom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLiveViewZoom.Name = "lblLiveViewZoom";
            this.lblLiveViewZoom.Size = new System.Drawing.Size(164, 25);
            this.lblLiveViewZoom.TabIndex = 55;
            this.lblLiveViewZoom.Text = "Live View Zoom";
            this.lblLiveViewZoom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblIso
            // 
            this.lblIso.AutoSize = true;
            this.lblIso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIso.Location = new System.Drawing.Point(5, 399);
            this.lblIso.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblIso.Name = "lblIso";
            this.lblIso.Size = new System.Drawing.Size(266, 45);
            this.lblIso.TabIndex = 44;
            this.lblIso.Text = "ISO";
            this.lblIso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbSavePath
            // 
            this.tbSavePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSavePath.Enabled = false;
            this.tbSavePath.Location = new System.Drawing.Point(281, 343);
            this.tbSavePath.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbSavePath.Name = "tbSavePath";
            this.tbSavePath.Size = new System.Drawing.Size(288, 31);
            this.tbSavePath.TabIndex = 40;
            // 
            // lblSavePhotosTo
            // 
            this.lblSavePhotosTo.AutoSize = true;
            this.lblSavePhotosTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSavePhotosTo.Location = new System.Drawing.Point(5, 337);
            this.lblSavePhotosTo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblSavePhotosTo.Name = "lblSavePhotosTo";
            this.lblSavePhotosTo.Size = new System.Drawing.Size(266, 62);
            this.lblSavePhotosTo.TabIndex = 39;
            this.lblSavePhotosTo.Text = "Save photos to...";
            this.lblSavePhotosTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkEnableBin
            // 
            this.chkEnableBin.AutoSize = true;
            this.chkEnableBin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkEnableBin.Location = new System.Drawing.Point(4, 207);
            this.chkEnableBin.Margin = new System.Windows.Forms.Padding(4);
            this.chkEnableBin.Name = "chkEnableBin";
            this.chkEnableBin.Size = new System.Drawing.Size(268, 33);
            this.chkEnableBin.TabIndex = 24;
            this.chkEnableBin.Text = "Enable binning";
            this.chkEnableBin.UseVisualStyleBackColor = true;
            this.chkEnableBin.CheckedChanged += new System.EventHandler(this.chkEnableBin_CheckedChanged);
            // 
            // cbIntegrationApi
            // 
            this.cbIntegrationApi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbIntegrationApi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIntegrationApi.FormattingEnabled = true;
            this.cbIntegrationApi.Location = new System.Drawing.Point(280, 4);
            this.cbIntegrationApi.Margin = new System.Windows.Forms.Padding(4);
            this.cbIntegrationApi.Name = "cbIntegrationApi";
            this.cbIntegrationApi.Size = new System.Drawing.Size(290, 33);
            this.cbIntegrationApi.TabIndex = 31;
            this.cbIntegrationApi.SelectedIndexChanged += new System.EventHandler(this.cbIntegrationApi_SelectedIndexChanged);
            // 
            // cbShutterPort
            // 
            this.cbShutterPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbShutterPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbShutterPort.FormattingEnabled = true;
            this.cbShutterPort.Location = new System.Drawing.Point(281, 164);
            this.cbShutterPort.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbShutterPort.Name = "cbShutterPort";
            this.cbShutterPort.Size = new System.Drawing.Size(288, 33);
            this.cbShutterPort.TabIndex = 35;
            // 
            // lbImageMode
            // 
            this.lbImageMode.AutoSize = true;
            this.lbImageMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbImageMode.Location = new System.Drawing.Point(5, 244);
            this.lbImageMode.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbImageMode.Name = "lbImageMode";
            this.lbImageMode.Size = new System.Drawing.Size(266, 45);
            this.lbImageMode.TabIndex = 8;
            this.lbImageMode.Text = "Image mode";
            this.lbImageMode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbBinningMode
            // 
            this.cbBinningMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbBinningMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBinningMode.FormattingEnabled = true;
            this.cbBinningMode.Location = new System.Drawing.Point(280, 207);
            this.cbBinningMode.Margin = new System.Windows.Forms.Padding(4);
            this.cbBinningMode.Name = "cbBinningMode";
            this.cbBinningMode.Size = new System.Drawing.Size(290, 33);
            this.cbBinningMode.TabIndex = 38;
            // 
            // lbIntegrationApi
            // 
            this.lbIntegrationApi.AutoSize = true;
            this.lbIntegrationApi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbIntegrationApi.Location = new System.Drawing.Point(5, 6);
            this.lbIntegrationApi.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.lbIntegrationApi.Name = "lbIntegrationApi";
            this.lbIntegrationApi.Size = new System.Drawing.Size(266, 29);
            this.lbIntegrationApi.TabIndex = 30;
            this.lbIntegrationApi.Text = "Connection method";
            this.lbIntegrationApi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbIso
            // 
            this.cbIso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbIso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIso.FormattingEnabled = true;
            this.cbIso.Location = new System.Drawing.Point(281, 405);
            this.cbIso.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbIso.Name = "cbIso";
            this.cbIso.Size = new System.Drawing.Size(288, 33);
            this.cbIso.TabIndex = 43;
            // 
            // tbBackyardEosPort
            // 
            this.tbBackyardEosPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbBackyardEosPort.Location = new System.Drawing.Point(280, 123);
            this.tbBackyardEosPort.Margin = new System.Windows.Forms.Padding(4);
            this.tbBackyardEosPort.Name = "tbBackyardEosPort";
            this.tbBackyardEosPort.Size = new System.Drawing.Size(290, 31);
            this.tbBackyardEosPort.TabIndex = 33;
            this.tbBackyardEosPort.Visible = false;
            // 
            // lblBackyardEosPort
            // 
            this.lblBackyardEosPort.AutoSize = true;
            this.lblBackyardEosPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBackyardEosPort.Location = new System.Drawing.Point(4, 119);
            this.lblBackyardEosPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBackyardEosPort.Name = "lblBackyardEosPort";
            this.lblBackyardEosPort.Size = new System.Drawing.Size(268, 39);
            this.lblBackyardEosPort.TabIndex = 32;
            this.lblBackyardEosPort.Text = "Port";
            this.lblBackyardEosPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBackyardEosPort.Visible = false;
            // 
            // chkUseExternalShutter
            // 
            this.chkUseExternalShutter.AutoSize = true;
            this.chkUseExternalShutter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkUseExternalShutter.Location = new System.Drawing.Point(5, 164);
            this.chkUseExternalShutter.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.chkUseExternalShutter.Name = "chkUseExternalShutter";
            this.chkUseExternalShutter.Size = new System.Drawing.Size(266, 33);
            this.chkUseExternalShutter.TabIndex = 34;
            this.chkUseExternalShutter.Text = "Use external shutter";
            this.chkUseExternalShutter.UseVisualStyleBackColor = true;
            this.chkUseExternalShutter.CheckedChanged += new System.EventHandler(this.chkUseExternalShutter_CheckedChanged);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBrowse.Location = new System.Drawing.Point(579, 343);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(144, 50);
            this.btnBrowse.TabIndex = 41;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // chkEnableLiveView
            // 
            this.chkEnableLiveView.AutoSize = true;
            this.chkEnableLiveView.Location = new System.Drawing.Point(280, 45);
            this.chkEnableLiveView.Margin = new System.Windows.Forms.Padding(4);
            this.chkEnableLiveView.Name = "chkEnableLiveView";
            this.chkEnableLiveView.Size = new System.Drawing.Size(192, 29);
            this.chkEnableLiveView.TabIndex = 57;
            this.chkEnableLiveView.Text = "Live view mode";
            this.chkEnableLiveView.UseVisualStyleBackColor = true;
            this.chkEnableLiveView.CheckedChanged += new System.EventHandler(this.chkEnableLiveView_CheckedChanged);
            // 
            // chkSaveFile
            // 
            this.chkSaveFile.Location = new System.Drawing.Point(280, 293);
            this.chkSaveFile.Margin = new System.Windows.Forms.Padding(4);
            this.chkSaveFile.Name = "chkSaveFile";
            this.chkSaveFile.Size = new System.Drawing.Size(286, 40);
            this.chkSaveFile.TabIndex = 59;
            this.chkSaveFile.Text = "Store in the Location";
            this.chkSaveFile.UseVisualStyleBackColor = true;
            this.chkSaveFile.CheckedChanged += new System.EventHandler(this.chkSaveFile_CheckedChanged);
            // 
            // cbImageMode
            // 
            this.cbImageMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbImageMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbImageMode.FormattingEnabled = true;
            this.cbImageMode.Location = new System.Drawing.Point(281, 250);
            this.cbImageMode.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbImageMode.Name = "cbImageMode";
            this.cbImageMode.Size = new System.Drawing.Size(288, 33);
            this.cbImageMode.TabIndex = 37;
            this.cbImageMode.SelectedIndexChanged += new System.EventHandler(this.cbImageMode_SelectedIndexChanged);
            // 
            // chkTrace
            // 
            this.chkTrace.AutoSize = true;
            this.chkTrace.Location = new System.Drawing.Point(11, 648);
            this.chkTrace.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.chkTrace.Name = "chkTrace";
            this.chkTrace.Size = new System.Drawing.Size(129, 29);
            this.chkTrace.TabIndex = 9;
            this.chkTrace.Text = "Trace on";
            this.chkTrace.UseVisualStyleBackColor = true;
            // 
            // picASCOM
            // 
            this.picASCOM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.picASCOM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picASCOM.Image = global::ASCOM.DSLR.Properties.Resources.ASCOM;
            this.picASCOM.Location = new System.Drawing.Point(28, 740);
            this.picASCOM.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.picASCOM.Name = "picASCOM";
            this.picASCOM.Size = new System.Drawing.Size(64, 70);
            this.picASCOM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picASCOM.TabIndex = 13;
            this.picASCOM.TabStop = false;
            this.picASCOM.Click += new System.EventHandler(this.BrowseToAscom);
            // 
            // btnAbout
            // 
            this.btnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbout.Location = new System.Drawing.Point(116, 762);
            this.btnAbout.Margin = new System.Windows.Forms.Padding(4);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(133, 50);
            this.btnAbout.TabIndex = 14;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Visible = false;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // SetupDialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 840);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.gbCameraSettings);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.picASCOM);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupDialogForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DSLR Setup";
            this.Load += new System.EventHandler(this.SetupDialogForm_Load);
            this.gbCameraSettings.ResumeLayout(false);
            this.gbCameraSettings.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picASCOM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.GroupBox gbCameraSettings;
        private System.Windows.Forms.CheckBox chkTrace;
        private System.Windows.Forms.Label lbImageMode;
        private System.Windows.Forms.PictureBox picASCOM;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.CheckBox chkEnableBin;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox tbSavePath;
        private System.Windows.Forms.Label lblSavePhotosTo;
        private System.Windows.Forms.ComboBox cbImageMode;
        private System.Windows.Forms.CheckBox chkUseExternalShutter;
        private System.Windows.Forms.ComboBox cbShutterPort;
        private System.Windows.Forms.ComboBox cbBinningMode;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.ComboBox cbIso;
        private System.Windows.Forms.Label lblBackyardEosPort;
        private System.Windows.Forms.ComboBox cbIntegrationApi;
        private System.Windows.Forms.TextBox tbBackyardEosPort;
        private System.Windows.Forms.Label lbIntegrationApi;
        private System.Windows.Forms.Label lblIso;
        private System.Windows.Forms.ComboBox cbLiveViewZoom;
        private System.Windows.Forms.Label lblLiveViewZoom;
        private System.Windows.Forms.CheckBox chkEnableLiveView;
        private System.Windows.Forms.CheckBox chkSaveFile;
    }
}