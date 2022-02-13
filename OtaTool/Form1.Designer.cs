namespace OtaTool
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
            this.textBoxPath = new System.Windows.Forms.RichTextBox();
            this.textSize = new System.Windows.Forms.RichTextBox();
            this.textBoxChecksum = new System.Windows.Forms.RichTextBox();
            this.comboBoxChecksumMethod = new DevExpress.XtraEditors.ComboBoxEdit();
            this.buttonBrowseFirmware = new System.Windows.Forms.Button();
            this.labelChecksumMethod = new System.Windows.Forms.Label();
            this.lableFileSize = new System.Windows.Forms.Label();
            this.labelCheckSumValue = new System.Windows.Forms.Label();
            this.buttonReload = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxFirmwareVersion = new System.Windows.Forms.RichTextBox();
            this.textBoxHardwareVersion = new System.Windows.Forms.RichTextBox();
            this.textBoxHeader = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxReleaseDate = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxChecksumMethod.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxPath
            // 
            this.textBoxPath.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxPath.Location = new System.Drawing.Point(117, 18);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(480, 30);
            this.textBoxPath.TabIndex = 8;
            this.textBoxPath.Text = "";
            // 
            // textSize
            // 
            this.textSize.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textSize.Location = new System.Drawing.Point(497, 154);
            this.textSize.Name = "textSize";
            this.textSize.Size = new System.Drawing.Size(97, 23);
            this.textSize.TabIndex = 12;
            this.textSize.Text = "";
            // 
            // textBoxChecksum
            // 
            this.textBoxChecksum.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxChecksum.Location = new System.Drawing.Point(117, 58);
            this.textBoxChecksum.Name = "textBoxChecksum";
            this.textBoxChecksum.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.textBoxChecksum.Size = new System.Drawing.Size(480, 30);
            this.textBoxChecksum.TabIndex = 13;
            this.textBoxChecksum.Text = "";
            // 
            // comboBoxChecksumMethod
            // 
            this.comboBoxChecksumMethod.EditValue = "MD5";
            this.comboBoxChecksumMethod.Location = new System.Drawing.Point(497, 108);
            this.comboBoxChecksumMethod.Name = "comboBoxChecksumMethod";
            this.comboBoxChecksumMethod.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxChecksumMethod.Properties.Appearance.Options.UseFont = true;
            this.comboBoxChecksumMethod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxChecksumMethod.Properties.Items.AddRange(new object[] {
            "MD5",
            "SUM",
            "CRC32"});
            this.comboBoxChecksumMethod.Size = new System.Drawing.Size(97, 26);
            this.comboBoxChecksumMethod.TabIndex = 14;
            // 
            // buttonBrowseFirmware
            // 
            this.buttonBrowseFirmware.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonBrowseFirmware.Location = new System.Drawing.Point(23, 109);
            this.buttonBrowseFirmware.Name = "buttonBrowseFirmware";
            this.buttonBrowseFirmware.Size = new System.Drawing.Size(94, 49);
            this.buttonBrowseFirmware.TabIndex = 15;
            this.buttonBrowseFirmware.Text = "Browse file";
            this.buttonBrowseFirmware.UseVisualStyleBackColor = true;
            this.buttonBrowseFirmware.Click += new System.EventHandler(this.onButtonBrowseFileClick);
            // 
            // labelChecksumMethod
            // 
            this.labelChecksumMethod.AutoSize = true;
            this.labelChecksumMethod.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelChecksumMethod.Location = new System.Drawing.Point(405, 109);
            this.labelChecksumMethod.Name = "labelChecksumMethod";
            this.labelChecksumMethod.Size = new System.Drawing.Size(61, 19);
            this.labelChecksumMethod.TabIndex = 16;
            this.labelChecksumMethod.Text = "Method";
            // 
            // lableFileSize
            // 
            this.lableFileSize.AutoSize = true;
            this.lableFileSize.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lableFileSize.Location = new System.Drawing.Point(405, 158);
            this.lableFileSize.Name = "lableFileSize";
            this.lableFileSize.Size = new System.Drawing.Size(64, 19);
            this.lableFileSize.TabIndex = 17;
            this.lableFileSize.Text = "File size";
            // 
            // labelCheckSumValue
            // 
            this.labelCheckSumValue.AutoSize = true;
            this.labelCheckSumValue.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelCheckSumValue.Location = new System.Drawing.Point(23, 69);
            this.labelCheckSumValue.Name = "labelCheckSumValue";
            this.labelCheckSumValue.Size = new System.Drawing.Size(81, 19);
            this.labelCheckSumValue.TabIndex = 18;
            this.labelCheckSumValue.Text = "Checksum";
            // 
            // buttonReload
            // 
            this.buttonReload.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonReload.Location = new System.Drawing.Point(23, 180);
            this.buttonReload.Name = "buttonReload";
            this.buttonReload.Size = new System.Drawing.Size(94, 49);
            this.buttonReload.TabIndex = 19;
            this.buttonReload.Text = "Calculate";
            this.buttonReload.UseVisualStyleBackColor = true;
            this.buttonReload.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(149, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 19);
            this.label1.TabIndex = 22;
            this.label1.Text = "Header";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(149, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 19);
            this.label2.TabIndex = 21;
            this.label2.Text = "Hardware version";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(149, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 19);
            this.label3.TabIndex = 20;
            this.label3.Text = "Firmware version";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // textBoxFirmwareVersion
            // 
            this.textBoxFirmwareVersion.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxFirmwareVersion.Location = new System.Drawing.Point(283, 105);
            this.textBoxFirmwareVersion.Name = "textBoxFirmwareVersion";
            this.textBoxFirmwareVersion.Size = new System.Drawing.Size(70, 23);
            this.textBoxFirmwareVersion.TabIndex = 23;
            this.textBoxFirmwareVersion.Text = "";
            this.textBoxFirmwareVersion.TextChanged += new System.EventHandler(this.textBoxFirmwareVersion_TextChanged);
            // 
            // textBoxHardwareVersion
            // 
            this.textBoxHardwareVersion.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxHardwareVersion.Location = new System.Drawing.Point(283, 154);
            this.textBoxHardwareVersion.Name = "textBoxHardwareVersion";
            this.textBoxHardwareVersion.Size = new System.Drawing.Size(70, 23);
            this.textBoxHardwareVersion.TabIndex = 24;
            this.textBoxHardwareVersion.Text = "";
            this.textBoxHardwareVersion.TextChanged += new System.EventHandler(this.textBoxHardwareVersion_TextChanged);
            // 
            // textBoxHeader
            // 
            this.textBoxHeader.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxHeader.Location = new System.Drawing.Point(283, 195);
            this.textBoxHeader.Name = "textBoxHeader";
            this.textBoxHeader.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.textBoxHeader.Size = new System.Drawing.Size(70, 23);
            this.textBoxHeader.TabIndex = 25;
            this.textBoxHeader.Text = "";
            this.textBoxHeader.TextChanged += new System.EventHandler(this.textBoxHeader_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(23, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 19);
            this.label4.TabIndex = 26;
            this.label4.Text = "File";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(405, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 19);
            this.label5.TabIndex = 27;
            this.label5.Text = "Release";
            // 
            // textBoxReleaseDate
            // 
            this.textBoxReleaseDate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxReleaseDate.Location = new System.Drawing.Point(497, 195);
            this.textBoxReleaseDate.Name = "textBoxReleaseDate";
            this.textBoxReleaseDate.Size = new System.Drawing.Size(97, 23);
            this.textBoxReleaseDate.TabIndex = 28;
            this.textBoxReleaseDate.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 250);
            this.Controls.Add(this.textBoxReleaseDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxHeader);
            this.Controls.Add(this.textBoxHardwareVersion);
            this.Controls.Add(this.textBoxFirmwareVersion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonReload);
            this.Controls.Add(this.labelCheckSumValue);
            this.Controls.Add(this.lableFileSize);
            this.Controls.Add(this.labelChecksumMethod);
            this.Controls.Add(this.buttonBrowseFirmware);
            this.Controls.Add(this.comboBoxChecksumMethod);
            this.Controls.Add(this.textBoxChecksum);
            this.Controls.Add(this.textSize);
            this.Controls.Add(this.textBoxPath);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "OTA CRC TOOL";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.onFormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxChecksumMethod.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox textBoxPath;
        private System.Windows.Forms.RichTextBox textSize;
        private System.Windows.Forms.RichTextBox textBoxChecksum;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxChecksumMethod;
        private System.Windows.Forms.Button buttonBrowseFirmware;
        private System.Windows.Forms.Label labelChecksumMethod;
        private System.Windows.Forms.Label lableFileSize;
        private System.Windows.Forms.Label labelCheckSumValue;
        private System.Windows.Forms.Button buttonReload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox textBoxFirmwareVersion;
        private System.Windows.Forms.RichTextBox textBoxHardwareVersion;
        private System.Windows.Forms.RichTextBox textBoxHeader;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox textBoxReleaseDate;
    }
}

