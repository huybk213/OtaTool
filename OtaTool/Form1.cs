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
using System.Text.Json;
using System.Security.Cryptography;

namespace OtaTool
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        //string config.file;
        string binaryFileName;
        //string lastPath = Directory.GetCurrentDirectory();

        public class ApplicationConfig
        {
            public string directory { get; set; }
            public string file { get; set; }
        }

        ApplicationConfig config = new ApplicationConfig();

        public Form1()
        {
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            Trace.AutoFlush = true;
            Trace.Indent();
            Trace.WriteLine("Exiting Main");
            Trace.WriteLine("Application started");
            InitializeComponent();
            config.directory = Directory.GetCurrentDirectory();
            loadDefaultDirectory();
        }

        private void loadDefaultDirectory()
        {
            if (config.directory.Contains("\\Debug"))
            {
                config.directory = config.directory.Substring(0, config.directory.LastIndexOf("\\Debug"));
            }
            config.directory += "\\setting.ini";
            Trace.WriteLine("lastPath " + config.directory);

            string configIni;
            if (File.Exists(config.directory))
            {
                //config.file = File.ReadAllText(lastPath);
                configIni = File.ReadAllText(config.directory);
                try
                {
                    var jsonConfig = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(configIni);
                    if (jsonConfig != null)
                    {
                        if (jsonConfig.ContainsKey("file"))
                        {
                            string file;
                            jsonConfig.TryGetValue("file", out file);
                            config.file = file;
                            this.textBoxPath.Text = file;
                            Trace.Write("Last file is {0}", config.file);
                        }
                    }
                    else
                    {
                        config.file = Directory.GetCurrentDirectory();
                    }
                }
                catch
                {
                    File.Delete(config.directory);
                }
            }
            else
            {
                config.file = Directory.GetCurrentDirectory();
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
            if (browseFirmwareFile(config.file, ref binaryFileName))
            {
                //otaTransfer.state = (byte)otaState_t.OTA_READ_DISK_FILE;
            }

            if (binaryFileName.Length > 0)
            {
                this.textBoxPath.Text = binaryFileName;
                //if (!binaryFileName.Contains(config.file))
                {
                    // Get CRC
                    var checksum = 0;
                    string checkSumInString = "0";
                    if (String.Compare(this.comboBoxChecksumMethod.Text.ToString(), "SUM") == 0)
                    {
                        byte[] firmwareData= File.ReadAllBytes(binaryFileName);
                        foreach (byte b in firmwareData)
                        {
                            checksum += b;
                        }
                        checkSumInString = checksum.ToString();
                        Trace.WriteLine("File sum " + checksum);
                    }
                    else if (String.Compare(this.comboBoxChecksumMethod.Text.ToString(), "MD5") == 0)
                    {
                        using (var md5 = MD5.Create())
                        {
                            using (var stream = File.OpenRead(binaryFileName))
                            {
                                byte[] md5Val = md5.ComputeHash(stream);
                                checkSumInString = BitConverter.ToString(md5Val);
                            }
                        }
                    }
                    this.textBoxChecksum.Enabled = true;
                    this.textBoxChecksum.Text = checkSumInString;
                    this.textBoxChecksum.Enabled = false;
                    config.file = binaryFileName;
                    config.file.Substring(config.file.LastIndexOf('\\'));
                    string output = JsonSerializer.Serialize<ApplicationConfig>(config);

                    File.WriteAllText(config.directory, output);
                    // Trace.WriteLine("File directory " + config.file);
                    Trace.WriteLine(File.ReadAllText(config.directory));
                }
            }
        }
    }
}
