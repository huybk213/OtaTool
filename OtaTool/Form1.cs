using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace OtaTool
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        string rememberLastDirectory;
        string binaryFileName;
        string lastPath = Directory.GetCurrentDirectory();
        public Form1()
        {
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            Trace.AutoFlush = true;
            Trace.Indent();
            Trace.WriteLine("Exiting Main");
            Trace.WriteLine("Application started");
            InitializeComponent();
            loadDefaultDirectory();
        }

        private void loadDefaultDirectory()
        {
            if (lastPath.Contains("\\Debug"))
            {
                lastPath = lastPath.Substring(0, lastPath.LastIndexOf("\\Debug"));
            }
            lastPath += "\\setting.ini";
            Trace.WriteLine("lastPath " + lastPath);

            if (File.Exists(lastPath))
            {
                rememberLastDirectory = File.ReadAllText(lastPath);
                this.textBoxPath.Text = rememberLastDirectory;
            }
            else
            {
                rememberLastDirectory = Directory.GetCurrentDirectory();
            }
        }

        private bool browseFirmwareFile(string folderPath, ref string lastPath)
        {
            lastPath = "";
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = folderPath;
            fileDialog.RestoreDirectory = true;
            fileDialog.Title = "Browse Firmware";
            fileDialog.DefaultExt = "bin";
            fileDialog.Filter = "bin files (*.bin)|*.bin|All files (*.*)|*.*";
            fileDialog.FilterIndex = 1;
            fileDialog.CheckFileExists = true;
            fileDialog.CheckPathExists = true;
            fileDialog.ShowDialog();

            lastPath = fileDialog.FileName;
            Trace.WriteLine(lastPath);
            if (lastPath.Length > 0)
            {
                lastPath = fileDialog.FileName;
                return true;
            }
            return false;
        }

        private void onButtonBrowseFileClock(object sender, EventArgs e)
        {
            if (browseFirmwareFile(rememberLastDirectory, ref binaryFileName))
            {
                //otaTransfer.state = (byte)otaState_t.OTA_READ_DISK_FILE;
            }

            if (binaryFileName.Length > 0)
            {
                this.textBoxPath.Text = binaryFileName;
                if (!binaryFileName.Contains(rememberLastDirectory))
                {
                    rememberLastDirectory = binaryFileName;
                    rememberLastDirectory.Substring(rememberLastDirectory.LastIndexOf('\\'));
                    File.WriteAllText(lastPath, rememberLastDirectory);
                    Trace.WriteLine("File directory " + rememberLastDirectory);
                }
            }
        }
    }
}
