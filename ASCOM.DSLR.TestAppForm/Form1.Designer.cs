namespace ASCOM.DSLR
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
            this.buttonChoose = new System.Windows.Forms.Button();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.labelDriverId = new System.Windows.Forms.Label();
            this.btnTakeImage = new System.Windows.Forms.Button();
            this.cmdExposure = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonChoose
            // 
            this.buttonChoose.Location = new System.Drawing.Point(618, 19);
            this.buttonChoose.Margin = new System.Windows.Forms.Padding(6);
            this.buttonChoose.Name = "buttonChoose";
            this.buttonChoose.Size = new System.Drawing.Size(144, 44);
            this.buttonChoose.TabIndex = 0;
            this.buttonChoose.Text = "Choose";
            this.buttonChoose.UseVisualStyleBackColor = true;
            this.buttonChoose.Click += new System.EventHandler(this.buttonChoose_Click);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(618, 75);
            this.buttonConnect.Margin = new System.Windows.Forms.Padding(6);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(144, 44);
            this.buttonConnect.TabIndex = 1;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // labelDriverId
            // 
            this.labelDriverId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelDriverId.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ASCOM.DSLR.Properties.Settings.Default, "DriverId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.labelDriverId.Location = new System.Drawing.Point(24, 77);
            this.labelDriverId.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelDriverId.Name = "labelDriverId";
            this.labelDriverId.Size = new System.Drawing.Size(580, 39);
            this.labelDriverId.TabIndex = 2;
            this.labelDriverId.Text = global::ASCOM.DSLR.Properties.Settings.Default.DriverId;
            this.labelDriverId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelDriverId.Click += new System.EventHandler(this.labelDriverId_Click);
            // 
            // btnTakeImage
            // 
            this.btnTakeImage.Enabled = false;
            this.btnTakeImage.Location = new System.Drawing.Point(618, 131);
            this.btnTakeImage.Margin = new System.Windows.Forms.Padding(6);
            this.btnTakeImage.Name = "btnTakeImage";
            this.btnTakeImage.Size = new System.Drawing.Size(150, 44);
            this.btnTakeImage.TabIndex = 3;
            this.btnTakeImage.Text = "Take Image";
            this.btnTakeImage.UseVisualStyleBackColor = true;
            this.btnTakeImage.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmdExposure
            // 
            this.cmdExposure.FormattingEnabled = true;
            this.cmdExposure.Items.AddRange(new object[] {
            "0.00025",
            "0.5",
            "5",
            "31"});
            this.cmdExposure.Location = new System.Drawing.Point(376, 138);
            this.cmdExposure.Name = "cmdExposure";
            this.cmdExposure.Size = new System.Drawing.Size(218, 33);
            this.cmdExposure.TabIndex = 4;
            this.cmdExposure.Text = "0.5";
            this.cmdExposure.SelectedIndexChanged += new System.EventHandler(this.cmdExposure_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(205, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Exposure Test:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 202);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdExposure);
            this.Controls.Add(this.btnTakeImage);
            this.Controls.Add(this.labelDriverId);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.buttonChoose);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "ASCOM DLSR TestAPP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonChoose;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Label labelDriverId;
        private System.Windows.Forms.Button btnTakeImage;
        private System.Windows.Forms.ComboBox cmdExposure;
        private System.Windows.Forms.Label label1;
    }
}

