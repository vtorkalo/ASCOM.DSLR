namespace OTelescope.SampleAPI
{
    partial class Form1
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
            this.btnTakePicture = new System.Windows.Forms.Button();
            this.numericUpDownDuration = new System.Windows.Forms.NumericUpDown();
            this.btnAbort = new System.Windows.Forms.Button();
            this.comboBoxIso = new System.Windows.Forms.ComboBox();
            this.btnGetLastError = new System.Windows.Forms.Button();
            this.txtLastError = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGetStatus = new System.Windows.Forms.Button();
            this.textStatus = new System.Windows.Forms.TextBox();
            this.btnGetIsPictureReady = new System.Windows.Forms.Button();
            this.btnGetPicturePath = new System.Windows.Forms.Button();
            this.txtPicturePath = new System.Windows.Forms.TextBox();
            this.txtIsPictureReady = new System.Windows.Forms.TextBox();
            this.comboBoxImageQuality = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.txtCameraPixelSize = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtCameraModel = new System.Windows.Forms.TextBox();
            this.btnThemeOn = new System.Windows.Forms.Button();
            this.btnDitherOn = new System.Windows.Forms.Button();
            this.btnThemeOff = new System.Windows.Forms.Button();
            this.btnDitherOff = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDuration)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTakePicture
            // 
            this.btnTakePicture.Location = new System.Drawing.Point(12, 12);
            this.btnTakePicture.Name = "btnTakePicture";
            this.btnTakePicture.Size = new System.Drawing.Size(108, 109);
            this.btnTakePicture.TabIndex = 0;
            this.btnTakePicture.Text = "Take Picture";
            this.btnTakePicture.UseVisualStyleBackColor = true;
            this.btnTakePicture.Click += new System.EventHandler(this.btnTakePicture_Click);
            // 
            // numericUpDownDuration
            // 
            this.numericUpDownDuration.Location = new System.Drawing.Point(196, 48);
            this.numericUpDownDuration.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDownDuration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownDuration.Name = "numericUpDownDuration";
            this.numericUpDownDuration.Size = new System.Drawing.Size(67, 20);
            this.numericUpDownDuration.TabIndex = 1;
            this.numericUpDownDuration.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnAbort
            // 
            this.btnAbort.Location = new System.Drawing.Point(419, 12);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(108, 109);
            this.btnAbort.TabIndex = 2;
            this.btnAbort.Text = "Abort";
            this.btnAbort.UseVisualStyleBackColor = true;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // comboBoxIso
            // 
            this.comboBoxIso.FormattingEnabled = true;
            this.comboBoxIso.Items.AddRange(new object[] {
            "100",
            "400",
            "800",
            "1600"});
            this.comboBoxIso.Location = new System.Drawing.Point(196, 74);
            this.comboBoxIso.Name = "comboBoxIso";
            this.comboBoxIso.Size = new System.Drawing.Size(67, 21);
            this.comboBoxIso.TabIndex = 3;
            this.comboBoxIso.Text = "1600";
            // 
            // btnGetLastError
            // 
            this.btnGetLastError.Location = new System.Drawing.Point(12, 227);
            this.btnGetLastError.Name = "btnGetLastError";
            this.btnGetLastError.Size = new System.Drawing.Size(108, 21);
            this.btnGetLastError.TabIndex = 4;
            this.btnGetLastError.Text = "Get last error";
            this.btnGetLastError.UseVisualStyleBackColor = true;
            this.btnGetLastError.Click += new System.EventHandler(this.btnGetLastError_Click);
            // 
            // txtLastError
            // 
            this.txtLastError.Location = new System.Drawing.Point(126, 228);
            this.txtLastError.Name = "txtLastError";
            this.txtLastError.Size = new System.Drawing.Size(382, 20);
            this.txtLastError.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(126, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Duration";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "ISO";
            // 
            // btnGetStatus
            // 
            this.btnGetStatus.Location = new System.Drawing.Point(12, 199);
            this.btnGetStatus.Name = "btnGetStatus";
            this.btnGetStatus.Size = new System.Drawing.Size(108, 21);
            this.btnGetStatus.TabIndex = 8;
            this.btnGetStatus.Text = "Get status";
            this.btnGetStatus.UseVisualStyleBackColor = true;
            this.btnGetStatus.Click += new System.EventHandler(this.btnGetStatus_Click);
            // 
            // textStatus
            // 
            this.textStatus.Location = new System.Drawing.Point(126, 200);
            this.textStatus.Name = "textStatus";
            this.textStatus.Size = new System.Drawing.Size(382, 20);
            this.textStatus.TabIndex = 9;
            // 
            // btnGetIsPictureReady
            // 
            this.btnGetIsPictureReady.Location = new System.Drawing.Point(12, 145);
            this.btnGetIsPictureReady.Name = "btnGetIsPictureReady";
            this.btnGetIsPictureReady.Size = new System.Drawing.Size(108, 21);
            this.btnGetIsPictureReady.TabIndex = 10;
            this.btnGetIsPictureReady.Text = "Is Picture ready";
            this.btnGetIsPictureReady.UseVisualStyleBackColor = true;
            this.btnGetIsPictureReady.Click += new System.EventHandler(this.btnGetIsPictureReady_Click);
            // 
            // btnGetPicturePath
            // 
            this.btnGetPicturePath.Location = new System.Drawing.Point(12, 172);
            this.btnGetPicturePath.Name = "btnGetPicturePath";
            this.btnGetPicturePath.Size = new System.Drawing.Size(108, 21);
            this.btnGetPicturePath.TabIndex = 11;
            this.btnGetPicturePath.Text = "Get picture path";
            this.btnGetPicturePath.UseVisualStyleBackColor = true;
            this.btnGetPicturePath.Click += new System.EventHandler(this.btnGetPicturePath_Click);
            // 
            // txtPicturePath
            // 
            this.txtPicturePath.Location = new System.Drawing.Point(126, 173);
            this.txtPicturePath.Name = "txtPicturePath";
            this.txtPicturePath.Size = new System.Drawing.Size(382, 20);
            this.txtPicturePath.TabIndex = 12;
            // 
            // txtIsPictureReady
            // 
            this.txtIsPictureReady.Location = new System.Drawing.Point(126, 145);
            this.txtIsPictureReady.Name = "txtIsPictureReady";
            this.txtIsPictureReady.Size = new System.Drawing.Size(382, 20);
            this.txtIsPictureReady.TabIndex = 13;
            // 
            // comboBoxImageQuality
            // 
            this.comboBoxImageQuality.FormattingEnabled = true;
            this.comboBoxImageQuality.Items.AddRange(new object[] {
            "JPG",
            "RAW"});
            this.comboBoxImageQuality.Location = new System.Drawing.Point(195, 21);
            this.comboBoxImageQuality.Name = "comboBoxImageQuality";
            this.comboBoxImageQuality.Size = new System.Drawing.Size(67, 21);
            this.comboBoxImageQuality.TabIndex = 14;
            this.comboBoxImageQuality.Text = "JPG";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(126, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Quality";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(305, 12);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(108, 51);
            this.btnConnect.TabIndex = 16;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(305, 70);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(108, 51);
            this.btnDisconnect.TabIndex = 17;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // txtCameraPixelSize
            // 
            this.txtCameraPixelSize.Location = new System.Drawing.Point(126, 293);
            this.txtCameraPixelSize.Name = "txtCameraPixelSize";
            this.txtCameraPixelSize.Size = new System.Drawing.Size(382, 20);
            this.txtCameraPixelSize.TabIndex = 19;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 292);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 21);
            this.button1.TabIndex = 18;
            this.button1.Text = "Get pixel size";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 265);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 21);
            this.button2.TabIndex = 20;
            this.button2.Text = "Get camera model";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtCameraModel
            // 
            this.txtCameraModel.Location = new System.Drawing.Point(126, 265);
            this.txtCameraModel.Name = "txtCameraModel";
            this.txtCameraModel.Size = new System.Drawing.Size(382, 20);
            this.txtCameraModel.TabIndex = 21;
            // 
            // btnThemeOn
            // 
            this.btnThemeOn.Location = new System.Drawing.Point(12, 330);
            this.btnThemeOn.Name = "btnThemeOn";
            this.btnThemeOn.Size = new System.Drawing.Size(73, 33);
            this.btnThemeOn.TabIndex = 22;
            this.btnThemeOn.Text = "Theme ON";
            this.btnThemeOn.UseVisualStyleBackColor = true;
            this.btnThemeOn.Click += new System.EventHandler(this.btnThemeOn_Click);
            // 
            // btnDitherOn
            // 
            this.btnDitherOn.Location = new System.Drawing.Point(12, 369);
            this.btnDitherOn.Name = "btnDitherOn";
            this.btnDitherOn.Size = new System.Drawing.Size(73, 33);
            this.btnDitherOn.TabIndex = 23;
            this.btnDitherOn.Text = "Dither ON";
            this.btnDitherOn.UseVisualStyleBackColor = true;
            this.btnDitherOn.Click += new System.EventHandler(this.btnDitherOn_Click);
            // 
            // btnThemeOff
            // 
            this.btnThemeOff.Location = new System.Drawing.Point(84, 330);
            this.btnThemeOff.Name = "btnThemeOff";
            this.btnThemeOff.Size = new System.Drawing.Size(36, 33);
            this.btnThemeOff.TabIndex = 24;
            this.btnThemeOff.Text = "OFF";
            this.btnThemeOff.UseVisualStyleBackColor = true;
            this.btnThemeOff.Click += new System.EventHandler(this.btnThemeOff_Click);
            // 
            // btnDitherOff
            // 
            this.btnDitherOff.Location = new System.Drawing.Point(84, 369);
            this.btnDitherOff.Name = "btnDitherOff";
            this.btnDitherOff.Size = new System.Drawing.Size(36, 33);
            this.btnDitherOff.TabIndex = 25;
            this.btnDitherOff.Text = "OFF";
            this.btnDitherOff.UseVisualStyleBackColor = true;
            this.btnDitherOff.Click += new System.EventHandler(this.btnDitherOff_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 443);
            this.Controls.Add(this.btnDitherOff);
            this.Controls.Add(this.btnThemeOff);
            this.Controls.Add(this.btnDitherOn);
            this.Controls.Add(this.btnThemeOn);
            this.Controls.Add(this.txtCameraModel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtCameraPixelSize);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxImageQuality);
            this.Controls.Add(this.txtIsPictureReady);
            this.Controls.Add(this.txtPicturePath);
            this.Controls.Add(this.btnGetPicturePath);
            this.Controls.Add(this.btnGetIsPictureReady);
            this.Controls.Add(this.textStatus);
            this.Controls.Add(this.btnGetStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLastError);
            this.Controls.Add(this.btnGetLastError);
            this.Controls.Add(this.comboBoxIso);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.numericUpDownDuration);
            this.Controls.Add(this.btnTakePicture);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDuration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTakePicture;
        private System.Windows.Forms.NumericUpDown numericUpDownDuration;
        private System.Windows.Forms.Button btnAbort;
        private System.Windows.Forms.ComboBox comboBoxIso;
        private System.Windows.Forms.Button btnGetLastError;
        private System.Windows.Forms.TextBox txtLastError;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGetStatus;
        private System.Windows.Forms.TextBox textStatus;
        private System.Windows.Forms.Button btnGetIsPictureReady;
        private System.Windows.Forms.Button btnGetPicturePath;
        private System.Windows.Forms.TextBox txtPicturePath;
        private System.Windows.Forms.TextBox txtIsPictureReady;
        private System.Windows.Forms.ComboBox comboBoxImageQuality;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.TextBox txtCameraPixelSize;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtCameraModel;
        private System.Windows.Forms.Button btnThemeOn;
        private System.Windows.Forms.Button btnDitherOn;
        private System.Windows.Forms.Button btnThemeOff;
        private System.Windows.Forms.Button btnDitherOff;
    }
}

