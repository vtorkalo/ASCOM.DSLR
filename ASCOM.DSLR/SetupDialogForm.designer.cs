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
            this.cbTraceLevel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.cmdOK.Location = new System.Drawing.Point(280, 391);
            this.cmdOK.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(58, 26);
            this.cmdOK.TabIndex = 3;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(352, 391);
            this.cmdCancel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(58, 27);
            this.cmdCancel.TabIndex = 4;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // gbCameraSettings
            // 
            this.gbCameraSettings.Controls.Add(this.tableLayoutPanel1);
            this.gbCameraSettings.Location = new System.Drawing.Point(14, 13);
            this.gbCameraSettings.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gbCameraSettings.Name = "gbCameraSettings";
            this.gbCameraSettings.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gbCameraSettings.Size = new System.Drawing.Size(394, 339);
            this.gbCameraSettings.TabIndex = 0;
            this.gbCameraSettings.TabStop = false;
            this.gbCameraSettings.Text = "Camera settings";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.11715F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.88285F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
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
            this.tableLayoutPanel1.Controls.Add(this.cbTraceLevel, 1, 12);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 12);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(14, 18);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(364, 309);
            this.tableLayoutPanel1.TabIndex = 33;
            // 
            // cbLiveViewZoom
            // 
            this.cbLiveViewZoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLiveViewZoom.FormattingEnabled = true;
            this.cbLiveViewZoom.Location = new System.Drawing.Point(131, 48);
            this.cbLiveViewZoom.Margin = new System.Windows.Forms.Padding(2);
            this.cbLiveViewZoom.Name = "cbLiveViewZoom";
            this.cbLiveViewZoom.Size = new System.Drawing.Size(136, 21);
            this.cbLiveViewZoom.TabIndex = 3;
            // 
            // lblLiveViewZoom
            // 
            this.lblLiveViewZoom.AutoSize = true;
            this.lblLiveViewZoom.Location = new System.Drawing.Point(2, 46);
            this.lblLiveViewZoom.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLiveViewZoom.Name = "lblLiveViewZoom";
            this.lblLiveViewZoom.Size = new System.Drawing.Size(83, 13);
            this.lblLiveViewZoom.TabIndex = 55;
            this.lblLiveViewZoom.Text = "Live View Zoom";
            this.lblLiveViewZoom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblIso
            // 
            this.lblIso.AutoSize = true;
            this.lblIso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIso.Location = new System.Drawing.Point(2, 249);
            this.lblIso.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIso.Name = "lblIso";
            this.lblIso.Size = new System.Drawing.Size(125, 27);
            this.lblIso.TabIndex = 44;
            this.lblIso.Text = "ISO";
            this.lblIso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbSavePath
            // 
            this.tbSavePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSavePath.Enabled = false;
            this.tbSavePath.Location = new System.Drawing.Point(131, 202);
            this.tbSavePath.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbSavePath.Name = "tbSavePath";
            this.tbSavePath.Size = new System.Drawing.Size(136, 20);
            this.tbSavePath.TabIndex = 11;
            // 
            // lblSavePhotosTo
            // 
            this.lblSavePhotosTo.AutoSize = true;
            this.lblSavePhotosTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSavePhotosTo.Location = new System.Drawing.Point(2, 199);
            this.lblSavePhotosTo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSavePhotosTo.Name = "lblSavePhotosTo";
            this.lblSavePhotosTo.Size = new System.Drawing.Size(125, 50);
            this.lblSavePhotosTo.TabIndex = 39;
            this.lblSavePhotosTo.Text = "Save photos to...";
            this.lblSavePhotosTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkEnableBin
            // 
            this.chkEnableBin.AutoSize = true;
            this.chkEnableBin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkEnableBin.Location = new System.Drawing.Point(2, 124);
            this.chkEnableBin.Margin = new System.Windows.Forms.Padding(2);
            this.chkEnableBin.Name = "chkEnableBin";
            this.chkEnableBin.Size = new System.Drawing.Size(125, 21);
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
            this.cbIntegrationApi.Location = new System.Drawing.Point(131, 2);
            this.cbIntegrationApi.Margin = new System.Windows.Forms.Padding(2);
            this.cbIntegrationApi.Name = "cbIntegrationApi";
            this.cbIntegrationApi.Size = new System.Drawing.Size(136, 21);
            this.cbIntegrationApi.TabIndex = 1;
            this.cbIntegrationApi.SelectedIndexChanged += new System.EventHandler(this.cbIntegrationApi_SelectedIndexChanged);
            // 
            // cbShutterPort
            // 
            this.cbShutterPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbShutterPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbShutterPort.FormattingEnabled = true;
            this.cbShutterPort.Location = new System.Drawing.Point(131, 98);
            this.cbShutterPort.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbShutterPort.Name = "cbShutterPort";
            this.cbShutterPort.Size = new System.Drawing.Size(136, 21);
            this.cbShutterPort.TabIndex = 6;
            // 
            // lbImageMode
            // 
            this.lbImageMode.AutoSize = true;
            this.lbImageMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbImageMode.Location = new System.Drawing.Point(2, 147);
            this.lbImageMode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbImageMode.Name = "lbImageMode";
            this.lbImageMode.Size = new System.Drawing.Size(125, 27);
            this.lbImageMode.TabIndex = 8;
            this.lbImageMode.Text = "Image mode";
            this.lbImageMode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbBinningMode
            // 
            this.cbBinningMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbBinningMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBinningMode.FormattingEnabled = true;
            this.cbBinningMode.Location = new System.Drawing.Point(131, 124);
            this.cbBinningMode.Margin = new System.Windows.Forms.Padding(2);
            this.cbBinningMode.Name = "cbBinningMode";
            this.cbBinningMode.Size = new System.Drawing.Size(136, 21);
            this.cbBinningMode.TabIndex = 8;
            // 
            // lbIntegrationApi
            // 
            this.lbIntegrationApi.AutoSize = true;
            this.lbIntegrationApi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbIntegrationApi.Location = new System.Drawing.Point(2, 3);
            this.lbIntegrationApi.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lbIntegrationApi.Name = "lbIntegrationApi";
            this.lbIntegrationApi.Size = new System.Drawing.Size(125, 19);
            this.lbIntegrationApi.TabIndex = 18;
            this.lbIntegrationApi.Text = "Connection method";
            this.lbIntegrationApi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbIso
            // 
            this.cbIso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbIso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIso.FormattingEnabled = true;
            this.cbIso.Location = new System.Drawing.Point(131, 252);
            this.cbIso.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbIso.Name = "cbIso";
            this.cbIso.Size = new System.Drawing.Size(136, 21);
            this.cbIso.TabIndex = 13;
            this.cbIso.SelectedIndexChanged += new System.EventHandler(this.cbIso_SelectedIndexChanged);
            // 
            // tbBackyardEosPort
            // 
            this.tbBackyardEosPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbBackyardEosPort.Location = new System.Drawing.Point(131, 73);
            this.tbBackyardEosPort.Margin = new System.Windows.Forms.Padding(2);
            this.tbBackyardEosPort.Name = "tbBackyardEosPort";
            this.tbBackyardEosPort.Size = new System.Drawing.Size(136, 20);
            this.tbBackyardEosPort.TabIndex = 4;
            this.tbBackyardEosPort.Visible = false;
            // 
            // lblBackyardEosPort
            // 
            this.lblBackyardEosPort.AutoSize = true;
            this.lblBackyardEosPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBackyardEosPort.Location = new System.Drawing.Point(2, 71);
            this.lblBackyardEosPort.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBackyardEosPort.Name = "lblBackyardEosPort";
            this.lblBackyardEosPort.Size = new System.Drawing.Size(125, 24);
            this.lblBackyardEosPort.TabIndex = 32;
            this.lblBackyardEosPort.Text = "Port";
            this.lblBackyardEosPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBackyardEosPort.Visible = false;
            // 
            // chkUseExternalShutter
            // 
            this.chkUseExternalShutter.AutoSize = true;
            this.chkUseExternalShutter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkUseExternalShutter.Location = new System.Drawing.Point(2, 98);
            this.chkUseExternalShutter.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.chkUseExternalShutter.Name = "chkUseExternalShutter";
            this.chkUseExternalShutter.Size = new System.Drawing.Size(125, 21);
            this.chkUseExternalShutter.TabIndex = 5;
            this.chkUseExternalShutter.Text = "Use external shutter";
            this.chkUseExternalShutter.UseVisualStyleBackColor = true;
            this.chkUseExternalShutter.CheckedChanged += new System.EventHandler(this.chkUseExternalShutter_CheckedChanged);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBrowse.Location = new System.Drawing.Point(271, 202);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(91, 44);
            this.btnBrowse.TabIndex = 12;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // chkEnableLiveView
            // 
            this.chkEnableLiveView.AutoSize = true;
            this.chkEnableLiveView.Enabled = false;
            this.chkEnableLiveView.Location = new System.Drawing.Point(131, 27);
            this.chkEnableLiveView.Margin = new System.Windows.Forms.Padding(2);
            this.chkEnableLiveView.Name = "chkEnableLiveView";
            this.chkEnableLiveView.Size = new System.Drawing.Size(100, 17);
            this.chkEnableLiveView.TabIndex = 2;
            this.chkEnableLiveView.Text = "Live view mode";
            this.chkEnableLiveView.UseVisualStyleBackColor = true;
            this.chkEnableLiveView.CheckedChanged += new System.EventHandler(this.chkEnableLiveView_CheckedChanged);
            // 
            // chkSaveFile
            // 
            this.chkSaveFile.Checked = true;
            this.chkSaveFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSaveFile.Location = new System.Drawing.Point(131, 176);
            this.chkSaveFile.Margin = new System.Windows.Forms.Padding(2);
            this.chkSaveFile.Name = "chkSaveFile";
            this.chkSaveFile.Size = new System.Drawing.Size(136, 21);
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
            this.cbImageMode.Location = new System.Drawing.Point(131, 150);
            this.cbImageMode.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbImageMode.Name = "cbImageMode";
            this.cbImageMode.Size = new System.Drawing.Size(136, 21);
            this.cbImageMode.TabIndex = 9;
            this.cbImageMode.SelectedIndexChanged += new System.EventHandler(this.cbImageMode_SelectedIndexChanged);
            // 
            // cbTraceLevel
            // 
            this.cbTraceLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTraceLevel.FormattingEnabled = true;
            this.cbTraceLevel.Location = new System.Drawing.Point(132, 279);
            this.cbTraceLevel.Name = "cbTraceLevel";
            this.cbTraceLevel.Size = new System.Drawing.Size(134, 21);
            this.cbTraceLevel.TabIndex = 14;
            this.cbTraceLevel.SelectedIndexChanged += new System.EventHandler(this.cbTraceLevel_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 276);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 62;
            this.label1.Text = "Camera Log Level";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // chkTrace
            // 
            this.chkTrace.AutoSize = true;
            this.chkTrace.Location = new System.Drawing.Point(31, 354);
            this.chkTrace.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.chkTrace.Name = "chkTrace";
            this.chkTrace.Size = new System.Drawing.Size(110, 17);
            this.chkTrace.TabIndex = 1;
            this.chkTrace.Text = "ASCOM Trace on";
            this.chkTrace.UseVisualStyleBackColor = true;
            this.chkTrace.CheckedChanged += new System.EventHandler(this.chkTrace_CheckedChanged);
            // 
            // picASCOM
            // 
            this.picASCOM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.picASCOM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picASCOM.Image = global::ASCOM.DSLR.Properties.Resources.ASCOM;
            this.picASCOM.Location = new System.Drawing.Point(14, 381);
            this.picASCOM.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.picASCOM.Name = "picASCOM";
            this.picASCOM.Size = new System.Drawing.Size(32, 36);
            this.picASCOM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picASCOM.TabIndex = 13;
            this.picASCOM.TabStop = false;
            this.picASCOM.Click += new System.EventHandler(this.BrowseToAscom);
            // 
            // btnAbout
            // 
            this.btnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbout.Location = new System.Drawing.Point(58, 392);
            this.btnAbout.Margin = new System.Windows.Forms.Padding(2);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(66, 26);
            this.btnAbout.TabIndex = 2;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // SetupDialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 431);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.chkTrace);
            this.Controls.Add(this.gbCameraSettings);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.picASCOM);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(431, 454);
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
    }
}
