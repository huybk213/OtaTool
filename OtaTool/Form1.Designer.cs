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
            this.vScrollBar2 = new System.Windows.Forms.VScrollBar();
            this.textBoxHexaView = new System.Windows.Forms.RichTextBox();
            this.textSize = new System.Windows.Forms.RichTextBox();
            this.textBoxChecksum = new System.Windows.Forms.RichTextBox();
            this.comboBoxChecksumMethod = new DevExpress.XtraEditors.ComboBoxEdit();
            this.buttonBrowseFirmware = new System.Windows.Forms.Button();
            this.labelChecksumMethod = new System.Windows.Forms.Label();
            this.lableFileSize = new System.Windows.Forms.Label();
            this.labelCheckSumValue = new System.Windows.Forms.Label();
            this.buttonReload = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxChecksumMethod.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(203, 38);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(426, 30);
            this.textBoxPath.TabIndex = 8;
            this.textBoxPath.Text = "";
            // 
            // vScrollBar2
            // 
            this.vScrollBar2.Location = new System.Drawing.Point(770, 76);
            this.vScrollBar2.Name = "vScrollBar2";
            this.vScrollBar2.Size = new System.Drawing.Size(17, 383);
            this.vScrollBar2.TabIndex = 10;
            // 
            // textBoxHexaView
            // 
            this.textBoxHexaView.Enabled = false;
            this.textBoxHexaView.Location = new System.Drawing.Point(203, 76);
            this.textBoxHexaView.Name = "textBoxHexaView";
            this.textBoxHexaView.Size = new System.Drawing.Size(564, 380);
            this.textBoxHexaView.TabIndex = 11;
            this.textBoxHexaView.Text = "";
            // 
            // textSize
            // 
            this.textSize.Location = new System.Drawing.Point(89, 143);
            this.textSize.Name = "textSize";
            this.textSize.Size = new System.Drawing.Size(103, 23);
            this.textSize.TabIndex = 12;
            this.textSize.Text = "";
            // 
            // textBoxChecksum
            // 
            this.textBoxChecksum.Location = new System.Drawing.Point(89, 190);
            this.textBoxChecksum.Name = "textBoxChecksum";
            this.textBoxChecksum.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.textBoxChecksum.Size = new System.Drawing.Size(103, 45);
            this.textBoxChecksum.TabIndex = 13;
            this.textBoxChecksum.Text = "";
            // 
            // comboBoxChecksumMethod
            // 
            this.comboBoxChecksumMethod.EditValue = "MD5";
            this.comboBoxChecksumMethod.Location = new System.Drawing.Point(94, 97);
            this.comboBoxChecksumMethod.Name = "comboBoxChecksumMethod";
            this.comboBoxChecksumMethod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxChecksumMethod.Properties.Items.AddRange(new object[] {
            "MD5",
            "SUM",
            "CRC32"});
            this.comboBoxChecksumMethod.Size = new System.Drawing.Size(103, 20);
            this.comboBoxChecksumMethod.TabIndex = 14;
            // 
            // buttonBrowseFirmware
            // 
            this.buttonBrowseFirmware.Location = new System.Drawing.Point(635, 38);
            this.buttonBrowseFirmware.Name = "buttonBrowseFirmware";
            this.buttonBrowseFirmware.Size = new System.Drawing.Size(75, 30);
            this.buttonBrowseFirmware.TabIndex = 15;
            this.buttonBrowseFirmware.Text = "Browse file";
            this.buttonBrowseFirmware.UseVisualStyleBackColor = true;
            this.buttonBrowseFirmware.Click += new System.EventHandler(this.onButtonBrowseFileClick);
            // 
            // labelChecksumMethod
            // 
            this.labelChecksumMethod.AutoSize = true;
            this.labelChecksumMethod.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelChecksumMethod.Location = new System.Drawing.Point(2, 98);
            this.labelChecksumMethod.Name = "labelChecksumMethod";
            this.labelChecksumMethod.Size = new System.Drawing.Size(61, 19);
            this.labelChecksumMethod.TabIndex = 16;
            this.labelChecksumMethod.Text = "Method";
            // 
            // lableFileSize
            // 
            this.lableFileSize.AutoSize = true;
            this.lableFileSize.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lableFileSize.Location = new System.Drawing.Point(2, 147);
            this.lableFileSize.Name = "lableFileSize";
            this.lableFileSize.Size = new System.Drawing.Size(64, 19);
            this.lableFileSize.TabIndex = 17;
            this.lableFileSize.Text = "File size";
            // 
            // labelCheckSumValue
            // 
            this.labelCheckSumValue.AutoSize = true;
            this.labelCheckSumValue.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelCheckSumValue.Location = new System.Drawing.Point(2, 206);
            this.labelCheckSumValue.Name = "labelCheckSumValue";
            this.labelCheckSumValue.Size = new System.Drawing.Size(81, 19);
            this.labelCheckSumValue.TabIndex = 18;
            this.labelCheckSumValue.Text = "Checksum";
            // 
            // buttonReload
            // 
            this.buttonReload.Location = new System.Drawing.Point(716, 38);
            this.buttonReload.Name = "buttonReload";
            this.buttonReload.Size = new System.Drawing.Size(71, 30);
            this.buttonReload.TabIndex = 19;
            this.buttonReload.Text = "Reload";
            this.buttonReload.UseVisualStyleBackColor = true;
            this.buttonReload.Click += new System.EventHandler(this.buttonReload_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 538);
            this.Controls.Add(this.buttonReload);
            this.Controls.Add(this.labelCheckSumValue);
            this.Controls.Add(this.lableFileSize);
            this.Controls.Add(this.labelChecksumMethod);
            this.Controls.Add(this.buttonBrowseFirmware);
            this.Controls.Add(this.comboBoxChecksumMethod);
            this.Controls.Add(this.textBoxChecksum);
            this.Controls.Add(this.textSize);
            this.Controls.Add(this.textBoxHexaView);
            this.Controls.Add(this.vScrollBar2);
            this.Controls.Add(this.textBoxPath);
            this.Name = "Form1";
            this.Text = "OTA checksum tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.onFormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxChecksumMethod.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox textBoxPath;
        private System.Windows.Forms.VScrollBar vScrollBar2;
        private System.Windows.Forms.RichTextBox textBoxHexaView;
        private System.Windows.Forms.RichTextBox textSize;
        private System.Windows.Forms.RichTextBox textBoxChecksum;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxChecksumMethod;
        private System.Windows.Forms.Button buttonBrowseFirmware;
        private System.Windows.Forms.Label labelChecksumMethod;
        private System.Windows.Forms.Label lableFileSize;
        private System.Windows.Forms.Label labelCheckSumValue;
        private System.Windows.Forms.Button buttonReload;
    }
}

