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
            this.buttonBrowseFile = new DevExpress.XtraEditors.SimpleButton();
            this.textBoxPath = new System.Windows.Forms.RichTextBox();
            this.vScrollBar2 = new System.Windows.Forms.VScrollBar();
            this.textBoxHexaView = new System.Windows.Forms.RichTextBox();
            this.textSize = new System.Windows.Forms.RichTextBox();
            this.textBoxChecksum = new System.Windows.Forms.RichTextBox();
            this.comboBoxChecksumMethod = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxChecksumMethod.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonBrowseFile
            // 
            this.buttonBrowseFile.Location = new System.Drawing.Point(12, 25);
            this.buttonBrowseFile.Name = "buttonBrowseFile";
            this.buttonBrowseFile.Size = new System.Drawing.Size(103, 45);
            this.buttonBrowseFile.TabIndex = 5;
            this.buttonBrowseFile.Text = "Browse file";
            this.buttonBrowseFile.Click += new System.EventHandler(this.onButtonBrowseFileClock);
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(121, 25);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(576, 45);
            this.textBoxPath.TabIndex = 8;
            this.textBoxPath.Text = "";
            // 
            // vScrollBar2
            // 
            this.vScrollBar2.Location = new System.Drawing.Point(680, 73);
            this.vScrollBar2.Name = "vScrollBar2";
            this.vScrollBar2.Size = new System.Drawing.Size(17, 383);
            this.vScrollBar2.TabIndex = 10;
            // 
            // textBoxHexaView
            // 
            this.textBoxHexaView.Enabled = false;
            this.textBoxHexaView.Location = new System.Drawing.Point(121, 76);
            this.textBoxHexaView.Name = "textBoxHexaView";
            this.textBoxHexaView.Size = new System.Drawing.Size(556, 380);
            this.textBoxHexaView.TabIndex = 11;
            this.textBoxHexaView.Text = "";
            // 
            // textSize
            // 
            this.textSize.Location = new System.Drawing.Point(12, 143);
            this.textSize.Name = "textSize";
            this.textSize.Size = new System.Drawing.Size(103, 45);
            this.textSize.TabIndex = 12;
            this.textSize.Text = "";
            // 
            // textBoxChecksum
            // 
            this.textBoxChecksum.Location = new System.Drawing.Point(12, 222);
            this.textBoxChecksum.Name = "textBoxChecksum";
            this.textBoxChecksum.Size = new System.Drawing.Size(103, 45);
            this.textBoxChecksum.TabIndex = 13;
            this.textBoxChecksum.Text = "";
            // 
            // comboBoxChecksumMethod
            // 
            this.comboBoxChecksumMethod.EditValue = "MD5";
            this.comboBoxChecksumMethod.Location = new System.Drawing.Point(12, 95);
            this.comboBoxChecksumMethod.Name = "comboBoxChecksumMethod";
            this.comboBoxChecksumMethod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxChecksumMethod.Properties.Items.AddRange(new object[] {
            "MD5",
            "SUM",
            "CRC32"});
            this.comboBoxChecksumMethod.Size = new System.Drawing.Size(100, 20);
            this.comboBoxChecksumMethod.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 538);
            this.Controls.Add(this.comboBoxChecksumMethod);
            this.Controls.Add(this.textBoxChecksum);
            this.Controls.Add(this.textSize);
            this.Controls.Add(this.textBoxHexaView);
            this.Controls.Add(this.vScrollBar2);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.buttonBrowseFile);
            this.Name = "Form1";
            this.Text = "OTA checksum tool";
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxChecksumMethod.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton buttonBrowseFile;
        private System.Windows.Forms.RichTextBox textBoxPath;
        private System.Windows.Forms.VScrollBar vScrollBar2;
        private System.Windows.Forms.RichTextBox textBoxHexaView;
        private System.Windows.Forms.RichTextBox textSize;
        private System.Windows.Forms.RichTextBox textBoxChecksum;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxChecksumMethod;
    }
}

