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
            this.chkEnableBin = new System.Windows.Forms.CheckBox();
            this.tbBackyardEosPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSavePath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.cbIso = new System.Windows.Forms.ComboBox();
            this.cbIntegrationApi = new System.Windows.Forms.ComboBox();
            this.lbIntegrationApi = new System.Windows.Forms.Label();
            this.chkTrace = new System.Windows.Forms.CheckBox();
            this.cbImageMode = new System.Windows.Forms.ComboBox();
            this.lbImageMode = new System.Windows.Forms.Label();
            this.picASCOM = new System.Windows.Forms.PictureBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.cbBinningMode = new System.Windows.Forms.ComboBox();
            this.lblBinningMode = new System.Windows.Forms.Label();
            this.gbCameraSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picASCOM)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOK.Location = new System.Drawing.Point(495, 499);
            this.cmdOK.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(88, 37);
            this.cmdOK.TabIndex = 0;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(495, 545);
            this.cmdCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(88, 38);
            this.cmdCancel.TabIndex = 1;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // gbCameraSettings
            // 
            this.gbCameraSettings.Controls.Add(this.lblBinningMode);
            this.gbCameraSettings.Controls.Add(this.cbBinningMode);
            this.gbCameraSettings.Controls.Add(this.chkEnableBin);
            this.gbCameraSettings.Controls.Add(this.tbBackyardEosPort);
            this.gbCameraSettings.Controls.Add(this.label3);
            this.gbCameraSettings.Controls.Add(this.label2);
            this.gbCameraSettings.Controls.Add(this.label1);
            this.gbCameraSettings.Controls.Add(this.tbSavePath);
            this.gbCameraSettings.Controls.Add(this.btnBrowse);
            this.gbCameraSettings.Controls.Add(this.cbIso);
            this.gbCameraSettings.Controls.Add(this.cbIntegrationApi);
            this.gbCameraSettings.Controls.Add(this.lbIntegrationApi);
            this.gbCameraSettings.Controls.Add(this.chkTrace);
            this.gbCameraSettings.Controls.Add(this.cbImageMode);
            this.gbCameraSettings.Controls.Add(this.lbImageMode);
            this.gbCameraSettings.Location = new System.Drawing.Point(18, 18);
            this.gbCameraSettings.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbCameraSettings.Name = "gbCameraSettings";
            this.gbCameraSettings.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbCameraSettings.Size = new System.Drawing.Size(573, 448);
            this.gbCameraSettings.TabIndex = 8;
            this.gbCameraSettings.TabStop = false;
            this.gbCameraSettings.Text = "Camera settings";
            // 
            // chkEnableBin
            // 
            this.chkEnableBin.AutoSize = true;
            this.chkEnableBin.Location = new System.Drawing.Point(387, 47);
            this.chkEnableBin.Name = "chkEnableBin";
            this.chkEnableBin.Size = new System.Drawing.Size(140, 24);
            this.chkEnableBin.TabIndex = 24;
            this.chkEnableBin.Text = "Enable binning";
            this.chkEnableBin.UseVisualStyleBackColor = true;
            this.chkEnableBin.CheckedChanged += new System.EventHandler(this.chkEnableBin_CheckedChanged);
            // 
            // tbBackyardEosPort
            // 
            this.tbBackyardEosPort.Location = new System.Drawing.Point(190, 273);
            this.tbBackyardEosPort.Name = "tbBackyardEosPort";
            this.tbBackyardEosPort.Size = new System.Drawing.Size(120, 26);
            this.tbBackyardEosPort.TabIndex = 23;
            this.tbBackyardEosPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbBackyardEosPort_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 276);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "BackyardEOS Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 180);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "ISO";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 135);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Save photos to...";
            // 
            // tbSavePath
            // 
            this.tbSavePath.Enabled = false;
            this.tbSavePath.Location = new System.Drawing.Point(190, 130);
            this.tbSavePath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbSavePath.Name = "tbSavePath";
            this.tbSavePath.Size = new System.Drawing.Size(181, 26);
            this.tbSavePath.TabIndex = 16;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(382, 127);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(123, 35);
            this.btnBrowse.TabIndex = 15;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // cbIso
            // 
            this.cbIso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIso.FormattingEnabled = true;
            this.cbIso.Location = new System.Drawing.Point(190, 175);
            this.cbIso.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbIso.Name = "cbIso";
            this.cbIso.Size = new System.Drawing.Size(181, 28);
            this.cbIso.TabIndex = 14;
            // 
            // cbIntegrationApi
            // 
            this.cbIntegrationApi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIntegrationApi.FormattingEnabled = true;
            this.cbIntegrationApi.Location = new System.Drawing.Point(190, 225);
            this.cbIntegrationApi.Name = "cbIntegrationApi";
            this.cbIntegrationApi.Size = new System.Drawing.Size(180, 28);
            this.cbIntegrationApi.TabIndex = 12;
            this.cbIntegrationApi.SelectedIndexChanged += new System.EventHandler(this.cbIntegrationApi_SelectedIndexChanged);
            // 
            // lbIntegrationApi
            // 
            this.lbIntegrationApi.AutoSize = true;
            this.lbIntegrationApi.Location = new System.Drawing.Point(35, 230);
            this.lbIntegrationApi.Name = "lbIntegrationApi";
            this.lbIntegrationApi.Size = new System.Drawing.Size(148, 20);
            this.lbIntegrationApi.TabIndex = 11;
            this.lbIntegrationApi.Text = "Connection method";
            // 
            // chkTrace
            // 
            this.chkTrace.AutoSize = true;
            this.chkTrace.Location = new System.Drawing.Point(9, 414);
            this.chkTrace.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkTrace.Name = "chkTrace";
            this.chkTrace.Size = new System.Drawing.Size(97, 24);
            this.chkTrace.TabIndex = 9;
            this.chkTrace.Text = "Trace on";
            this.chkTrace.UseVisualStyleBackColor = true;
            // 
            // cbImageMode
            // 
            this.cbImageMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbImageMode.FormattingEnabled = true;
            this.cbImageMode.Location = new System.Drawing.Point(189, 45);
            this.cbImageMode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbImageMode.Name = "cbImageMode";
            this.cbImageMode.Size = new System.Drawing.Size(181, 28);
            this.cbImageMode.TabIndex = 10;
            // 
            // lbImageMode
            // 
            this.lbImageMode.AutoSize = true;
            this.lbImageMode.Location = new System.Drawing.Point(35, 45);
            this.lbImageMode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbImageMode.Name = "lbImageMode";
            this.lbImageMode.Size = new System.Drawing.Size(98, 20);
            this.lbImageMode.TabIndex = 8;
            this.lbImageMode.Text = "Image mode";
            // 
            // picASCOM
            // 
            this.picASCOM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picASCOM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picASCOM.Image = global::ASCOM.DSLR.Properties.Resources.ASCOM;
            this.picASCOM.Location = new System.Drawing.Point(27, 489);
            this.picASCOM.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picASCOM.Name = "picASCOM";
            this.picASCOM.Size = new System.Drawing.Size(48, 56);
            this.picASCOM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picASCOM.TabIndex = 13;
            this.picASCOM.TabStop = false;
            this.picASCOM.Click += new System.EventHandler(this.BrowseToAscom);
            // 
            // cbBinningMode
            // 
            this.cbBinningMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBinningMode.FormattingEnabled = true;
            this.cbBinningMode.Location = new System.Drawing.Point(189, 88);
            this.cbBinningMode.Name = "cbBinningMode";
            this.cbBinningMode.Size = new System.Drawing.Size(181, 28);
            this.cbBinningMode.TabIndex = 25;
            this.cbBinningMode.SelectedIndexChanged += new System.EventHandler(this.cbBinningMode_SelectedIndexChanged);
            // 
            // lblBinningMode
            // 
            this.lblBinningMode.AutoSize = true;
            this.lblBinningMode.Location = new System.Drawing.Point(35, 96);
            this.lblBinningMode.Name = "lblBinningMode";
            this.lblBinningMode.Size = new System.Drawing.Size(106, 20);
            this.lblBinningMode.TabIndex = 26;
            this.lblBinningMode.Text = "Binning mode";
            this.lblBinningMode.Click += new System.EventHandler(this.lblBinningMode_Click);
            // 
            // SetupDialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 596);
            this.Controls.Add(this.gbCameraSettings);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.picASCOM);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupDialogForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DSLR Setup";
            this.gbCameraSettings.ResumeLayout(false);
            this.gbCameraSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picASCOM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.GroupBox gbCameraSettings;
        private System.Windows.Forms.ComboBox cbImageMode;
        private System.Windows.Forms.CheckBox chkTrace;
        private System.Windows.Forms.Label lbImageMode;
        private System.Windows.Forms.ComboBox cbIntegrationApi;
        private System.Windows.Forms.Label lbIntegrationApi;
        private System.Windows.Forms.PictureBox picASCOM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSavePath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.ComboBox cbIso;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TextBox tbBackyardEosPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkEnableBin;
        private System.Windows.Forms.ComboBox cbBinningMode;
        private System.Windows.Forms.Label lblBinningMode;
    }
}