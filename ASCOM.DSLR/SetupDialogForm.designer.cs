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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupDialogForm));
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.gbCameraSettings = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
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
            this.cbTraceLevel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbLiveViewZoom = new System.Windows.Forms.ComboBox();
            this.lblLiveViewZoom = new System.Windows.Forms.Label();
            this.txtMAXADU = new System.Windows.Forms.TextBox();
            this.chkMAXADU = new System.Windows.Forms.CheckBox();
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
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOK.Location = new System.Drawing.Point(561, 739);
            this.cmdOK.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(116, 50);
            this.cmdOK.TabIndex = 3;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(705, 739);
            this.cmdCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(116, 52);
            this.cmdCancel.TabIndex = 4;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // gbCameraSettings
            // 
            this.gbCameraSettings.Controls.Add(this.tableLayoutPanel1);
            this.gbCameraSettings.Location = new System.Drawing.Point(28, 25);
            this.gbCameraSettings.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.gbCameraSettings.Name = "gbCameraSettings";
            this.gbCameraSettings.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.gbCameraSettings.Size = new System.Drawing.Size(788, 607);
            this.gbCameraSettings.TabIndex = 0;
            this.gbCameraSettings.TabStop = false;
            this.gbCameraSettings.Text = "Camera settings";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.11715F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.88285F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tableLayoutPanel1.Controls.Add(this.lblIso, 0, 13);
            this.tableLayoutPanel1.Controls.Add(this.tbSavePath, 1, 12);
            this.tableLayoutPanel1.Controls.Add(this.lblSavePhotosTo, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.chkEnableBin, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.cbIntegrationApi, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbShutterPort, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.lbImageMode, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.cbBinningMode, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.lbIntegrationApi, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbIso, 1, 13);
            this.tableLayoutPanel1.Controls.Add(this.tbBackyardEosPort, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblBackyardEosPort, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.chkUseExternalShutter, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.btnBrowse, 2, 12);
            this.tableLayoutPanel1.Controls.Add(this.chkEnableLiveView, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkSaveFile, 1, 11);
            this.tableLayoutPanel1.Controls.Add(this.cbImageMode, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.cbTraceLevel, 1, 14);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 14);
            this.tableLayoutPanel1.Controls.Add(this.cbLiveViewZoom, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblLiveViewZoom, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtMAXADU, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.chkMAXADU, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(28, 35);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 15;
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(728, 560);
            this.tableLayoutPanel1.TabIndex = 33;
            // 
            // lblIso
            // 
            this.lblIso.AutoSize = true;
            this.lblIso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIso.Location = new System.Drawing.Point(4, 471);
            this.lblIso.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIso.Name = "lblIso";
            this.lblIso.Size = new System.Drawing.Size(241, 45);
            this.lblIso.TabIndex = 44;
            this.lblIso.Text = "ISO";
            this.lblIso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbSavePath
            // 
            this.tbSavePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSavePath.Enabled = false;
            this.tbSavePath.Location = new System.Drawing.Point(253, 380);
            this.tbSavePath.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tbSavePath.Name = "tbSavePath";
            this.tbSavePath.Size = new System.Drawing.Size(260, 31);
            this.tbSavePath.TabIndex = 11;
            // 
            // lblSavePhotosTo
            // 
            this.lblSavePhotosTo.AutoSize = true;
            this.lblSavePhotosTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSavePhotosTo.Location = new System.Drawing.Point(4, 374);
            this.lblSavePhotosTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSavePhotosTo.Name = "lblSavePhotosTo";
            this.lblSavePhotosTo.Size = new System.Drawing.Size(241, 97);
            this.lblSavePhotosTo.TabIndex = 39;
            this.lblSavePhotosTo.Text = "Save photos to...";
            this.lblSavePhotosTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkEnableBin
            // 
            this.chkEnableBin.AutoSize = true;
            this.chkEnableBin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkEnableBin.Location = new System.Drawing.Point(4, 244);
            this.chkEnableBin.Margin = new System.Windows.Forms.Padding(4);
            this.chkEnableBin.Name = "chkEnableBin";
            this.chkEnableBin.Size = new System.Drawing.Size(241, 33);
            this.chkEnableBin.TabIndex = 7;
            this.chkEnableBin.Text = "Enable binning";
            this.chkEnableBin.UseVisualStyleBackColor = true;
            this.chkEnableBin.CheckedChanged += new System.EventHandler(this.chkEnableBin_CheckedChanged);
            // 
            // cbIntegrationApi
            // 
            this.cbIntegrationApi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbIntegrationApi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIntegrationApi.FormattingEnabled = true;
            this.cbIntegrationApi.Location = new System.Drawing.Point(253, 4);
            this.cbIntegrationApi.Margin = new System.Windows.Forms.Padding(4);
            this.cbIntegrationApi.Name = "cbIntegrationApi";
            this.cbIntegrationApi.Size = new System.Drawing.Size(260, 33);
            this.cbIntegrationApi.TabIndex = 1;
            this.cbIntegrationApi.SelectedIndexChanged += new System.EventHandler(this.cbIntegrationApi_SelectedIndexChanged);
            // 
            // cbShutterPort
            // 
            this.cbShutterPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbShutterPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbShutterPort.FormattingEnabled = true;
            this.cbShutterPort.Location = new System.Drawing.Point(253, 201);
            this.cbShutterPort.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cbShutterPort.Name = "cbShutterPort";
            this.cbShutterPort.Size = new System.Drawing.Size(260, 33);
            this.cbShutterPort.TabIndex = 6;
            // 
            // lbImageMode
            // 
            this.lbImageMode.AutoSize = true;
            this.lbImageMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbImageMode.Location = new System.Drawing.Point(4, 281);
            this.lbImageMode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbImageMode.Name = "lbImageMode";
            this.lbImageMode.Size = new System.Drawing.Size(241, 45);
            this.lbImageMode.TabIndex = 8;
            this.lbImageMode.Text = "Image mode";
            this.lbImageMode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbBinningMode
            // 
            this.cbBinningMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbBinningMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBinningMode.FormattingEnabled = true;
            this.cbBinningMode.Location = new System.Drawing.Point(253, 244);
            this.cbBinningMode.Margin = new System.Windows.Forms.Padding(4);
            this.cbBinningMode.Name = "cbBinningMode";
            this.cbBinningMode.Size = new System.Drawing.Size(260, 33);
            this.cbBinningMode.TabIndex = 8;
            // 
            // lbIntegrationApi
            // 
            this.lbIntegrationApi.AutoSize = true;
            this.lbIntegrationApi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbIntegrationApi.Location = new System.Drawing.Point(4, 6);
            this.lbIntegrationApi.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.lbIntegrationApi.Name = "lbIntegrationApi";
            this.lbIntegrationApi.Size = new System.Drawing.Size(241, 29);
            this.lbIntegrationApi.TabIndex = 18;
            this.lbIntegrationApi.Text = "Connection method";
            this.lbIntegrationApi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbIso
            // 
            this.cbIso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbIso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIso.FormattingEnabled = true;
            this.cbIso.Location = new System.Drawing.Point(253, 477);
            this.cbIso.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cbIso.Name = "cbIso";
            this.cbIso.Size = new System.Drawing.Size(260, 33);
            this.cbIso.TabIndex = 13;
            this.cbIso.SelectedIndexChanged += new System.EventHandler(this.cbIso_SelectedIndexChanged);
            // 
            // tbBackyardEosPort
            // 
            this.tbBackyardEosPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbBackyardEosPort.Location = new System.Drawing.Point(253, 160);
            this.tbBackyardEosPort.Margin = new System.Windows.Forms.Padding(4);
            this.tbBackyardEosPort.Name = "tbBackyardEosPort";
            this.tbBackyardEosPort.Size = new System.Drawing.Size(260, 31);
            this.tbBackyardEosPort.TabIndex = 4;
            this.tbBackyardEosPort.Visible = false;
            // 
            // lblBackyardEosPort
            // 
            this.lblBackyardEosPort.AutoSize = true;
            this.lblBackyardEosPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBackyardEosPort.Location = new System.Drawing.Point(4, 156);
            this.lblBackyardEosPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBackyardEosPort.Name = "lblBackyardEosPort";
            this.lblBackyardEosPort.Size = new System.Drawing.Size(241, 39);
            this.lblBackyardEosPort.TabIndex = 32;
            this.lblBackyardEosPort.Text = "Port";
            this.lblBackyardEosPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBackyardEosPort.Visible = false;
            // 
            // chkUseExternalShutter
            // 
            this.chkUseExternalShutter.AutoSize = true;
            this.chkUseExternalShutter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkUseExternalShutter.Location = new System.Drawing.Point(4, 201);
            this.chkUseExternalShutter.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.chkUseExternalShutter.Name = "chkUseExternalShutter";
            this.chkUseExternalShutter.Size = new System.Drawing.Size(241, 33);
            this.chkUseExternalShutter.TabIndex = 5;
            this.chkUseExternalShutter.Text = "Use external shutter";
            this.chkUseExternalShutter.UseVisualStyleBackColor = true;
            this.chkUseExternalShutter.CheckedChanged += new System.EventHandler(this.chkUseExternalShutter_CheckedChanged);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBrowse.Location = new System.Drawing.Point(521, 380);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(203, 85);
            this.btnBrowse.TabIndex = 12;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // chkEnableLiveView
            // 
            this.chkEnableLiveView.AutoSize = true;
            this.chkEnableLiveView.Location = new System.Drawing.Point(253, 45);
            this.chkEnableLiveView.Margin = new System.Windows.Forms.Padding(4);
            this.chkEnableLiveView.Name = "chkEnableLiveView";
            this.chkEnableLiveView.Size = new System.Drawing.Size(192, 29);
            this.chkEnableLiveView.TabIndex = 2;
            this.chkEnableLiveView.Text = "Live view mode";
            this.chkEnableLiveView.UseVisualStyleBackColor = true;
            this.chkEnableLiveView.CheckedChanged += new System.EventHandler(this.chkEnableLiveView_CheckedChanged);
            // 
            // chkSaveFile
            // 
            this.chkSaveFile.Checked = true;
            this.chkSaveFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSaveFile.Location = new System.Drawing.Point(253, 330);
            this.chkSaveFile.Margin = new System.Windows.Forms.Padding(4);
            this.chkSaveFile.Name = "chkSaveFile";
            this.chkSaveFile.Size = new System.Drawing.Size(260, 40);
            this.chkSaveFile.TabIndex = 10;
            this.chkSaveFile.Text = "Store in the Location";
            this.chkSaveFile.UseVisualStyleBackColor = true;
            this.chkSaveFile.CheckedChanged += new System.EventHandler(this.chkSaveFile_CheckedChanged);
            // 
            // cbImageMode
            // 
            this.cbImageMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbImageMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbImageMode.FormattingEnabled = true;
            this.cbImageMode.Location = new System.Drawing.Point(253, 287);
            this.cbImageMode.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cbImageMode.Name = "cbImageMode";
            this.cbImageMode.Size = new System.Drawing.Size(260, 33);
            this.cbImageMode.TabIndex = 9;
            this.cbImageMode.SelectedIndexChanged += new System.EventHandler(this.cbImageMode_SelectedIndexChanged);
            // 
            // cbTraceLevel
            // 
            this.cbTraceLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTraceLevel.FormattingEnabled = true;
            this.cbTraceLevel.Location = new System.Drawing.Point(255, 522);
            this.cbTraceLevel.Margin = new System.Windows.Forms.Padding(6);
            this.cbTraceLevel.Name = "cbTraceLevel";
            this.cbTraceLevel.Size = new System.Drawing.Size(254, 33);
            this.cbTraceLevel.TabIndex = 14;
            this.cbTraceLevel.SelectedIndexChanged += new System.EventHandler(this.cbTraceLevel_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 516);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 25);
            this.label1.TabIndex = 62;
            this.label1.Text = "Camera Log Level";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cbLiveViewZoom
            // 
            this.cbLiveViewZoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLiveViewZoom.FormattingEnabled = true;
            this.cbLiveViewZoom.Location = new System.Drawing.Point(253, 82);
            this.cbLiveViewZoom.Margin = new System.Windows.Forms.Padding(4);
            this.cbLiveViewZoom.Name = "cbLiveViewZoom";
            this.cbLiveViewZoom.Size = new System.Drawing.Size(258, 33);
            this.cbLiveViewZoom.TabIndex = 3;
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
            // txtMAXADU
            // 
            this.txtMAXADU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMAXADU.Enabled = false;
            this.txtMAXADU.Location = new System.Drawing.Point(252, 122);
            this.txtMAXADU.Name = "txtMAXADU";
            this.txtMAXADU.Size = new System.Drawing.Size(262, 31);
            this.txtMAXADU.TabIndex = 63;
            this.txtMAXADU.Text = "32767";
            // 
            // chkMAXADU
            // 
            this.chkMAXADU.AutoSize = true;
            this.chkMAXADU.Location = new System.Drawing.Point(3, 122);
            this.chkMAXADU.Name = "chkMAXADU";
            this.chkMAXADU.Size = new System.Drawing.Size(223, 29);
            this.chkMAXADU.TabIndex = 64;
            this.chkMAXADU.Text = "Max ADU Override";
            this.chkMAXADU.UseVisualStyleBackColor = true;
            this.chkMAXADU.CheckedChanged += new System.EventHandler(this.chxMAXADU_CheckedChanged);
            // 
            // chkTrace
            // 
            this.chkTrace.AutoSize = true;
            this.chkTrace.Location = new System.Drawing.Point(56, 658);
            this.chkTrace.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.chkTrace.Name = "chkTrace";
            this.chkTrace.Size = new System.Drawing.Size(212, 29);
            this.chkTrace.TabIndex = 1;
            this.chkTrace.Text = "ASCOM Trace on";
            this.chkTrace.UseVisualStyleBackColor = true;
            this.chkTrace.CheckedChanged += new System.EventHandler(this.chkTrace_CheckedChanged);
            // 
            // picASCOM
            // 
            this.picASCOM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picASCOM.Image = global::ASCOM.DSLR.Properties.Resources.ASCOM;
            this.picASCOM.Location = new System.Drawing.Point(29, 720);
            this.picASCOM.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.picASCOM.Name = "picASCOM";
            this.picASCOM.Size = new System.Drawing.Size(64, 69);
            this.picASCOM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picASCOM.TabIndex = 13;
            this.picASCOM.TabStop = false;
            this.picASCOM.Click += new System.EventHandler(this.BrowseToAscom);
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(117, 741);
            this.btnAbout.Margin = new System.Windows.Forms.Padding(4);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(132, 50);
            this.btnAbout.TabIndex = 2;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // SetupDialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(840, 809);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.chkTrace);
            this.Controls.Add(this.gbCameraSettings);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.picASCOM);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(836, 808);
            this.Name = "SetupDialogForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ASCOM DSLR Setup Form";
            this.Load += new System.EventHandler(this.SetupDialogForm_Load);
            this.gbCameraSettings.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picASCOM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.ComboBox cbTraceLevel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMAXADU;
        private System.Windows.Forms.CheckBox chkMAXADU;
    }
}
