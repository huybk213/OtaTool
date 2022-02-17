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

            public string hardwareVersion { get; set; }
            public string header { get; set; }

            public string method { get; set; }
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

        public class AutoClosingMessageBox
        {
            System.Threading.Timer _timeoutTimer;
            string _caption;
            AutoClosingMessageBox(string text, string caption, int timeout)
            {
                _caption = caption;
                _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                    null, timeout, System.Threading.Timeout.Infinite);
                using (_timeoutTimer)
                    MessageBox.Show(text, caption);
            }
            public static void Show(string text, string caption, int timeout)
            {
                new AutoClosingMessageBox(text, caption, timeout);
            }
            void OnTimerElapsed(object state)
            {
                IntPtr mbWnd = FindWindow("#32770", _caption); // lpClassName is #32770 for MessageBox
                if (mbWnd != IntPtr.Zero)
                    SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                _timeoutTimer.Dispose();
            }
            const int WM_CLOSE = 0x0010;
            [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
            static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
            [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
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

                        if (jsonConfig.ContainsKey("hardwareVersion"))
                        {
                            string hwVersion;
                            jsonConfig.TryGetValue("hardwareVersion", out hwVersion);
                            config.hardwareVersion = hwVersion;
                            this.textBoxHardwareVersion.Text = hwVersion;
                        }

                        if (jsonConfig.ContainsKey("header"))
                        {
                            string header;
                            jsonConfig.TryGetValue("header", out header);
                            config.header = header;
                            this.textBoxHeader.Text = header;
                        }

                        if (jsonConfig.ContainsKey("method"))
                        {
                            string method;
                            jsonConfig.TryGetValue("method", out method);
                            if (method != null)
                            {
                                config.method = method;
                                this.comboBoxChecksumMethod.Text = method;
                            }
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

        string convert(byte[] a)
        {
            return string.Join(" ", a.Select(b => string.Format("{0:X2} ", b)));
        }

        private void onButtonBrowseFileClick(object sender, EventArgs e)
        {
            if (browseFirmwareFile(config.file, ref binaryFileName))
            {
                //otaTransfer.state = (byte)otaState_t.OTA_READ_DISK_FILE;
            }

            if (binaryFileName.Length > 0)
            {
                buttonCalculate_Click(null, null);
            }
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            if (binaryFileName == null)
            {
                binaryFileName = this.textBoxPath.Text;
            }
            long otaFileSize = 0;
            if (binaryFileName != null
               && binaryFileName.Length > 0
               && File.Exists(binaryFileName))
            {
                this.textBoxPath.Text = binaryFileName;
                var fileSize = new System.IO.FileInfo(binaryFileName).Length;
                //if (!binaryFileName.Contains(config.file))
                {
                    // Get CRC
                    var checksum = 0;
                    string checkSumInString = "0";
                    byte[] firmwareData = File.ReadAllBytes(binaryFileName);
                    byte[] checksumInBytes;
                    
                    if (String.Compare(this.comboBoxChecksumMethod.Text.ToString(), "SUM") == 0)
                    {
                        foreach (byte b in firmwareData)
                        {
                            checksum += b;
                        }
                        checkSumInString = checksum.ToString();
                        checksumInBytes = BitConverter.GetBytes(checksum);
                        Trace.WriteLine("File sum " + checksum);
                    }
                    else if (String.Compare(this.comboBoxChecksumMethod.Text.ToString(), "MD5") == 0)
                    {
                        using (var md5 = MD5.Create())
                        {
                            checksumInBytes = md5.ComputeHash(firmwareData);
                            checkSumInString = convert(checksumInBytes);
                        }
                    }
                    else
                    {
                        int default_value = 0;
                        checksumInBytes = BitConverter.GetBytes(default_value);
                    }

                    // Check fimrware version, hardware version
                    if (this.textBoxFirmwareVersion.Text.Length != 3
                        || this.textBoxHardwareVersion.Text.Length != 3
                        || this.textBoxHeader.Text.Length != 3)
                    {
                        AutoClosingMessageBox.Show("Invalid format(001) (001) (EXP)", "OK", 2000);
                    }
                    else
                    {
                        // Ota filename =  file_fw_version_hw_version.bin
                        int indexOfBinFileExtension = binaryFileName.LastIndexOf(".bin");
                        var otaFile = binaryFileName;
                        if (indexOfBinFileExtension > 0)
                        {
                            otaFile = binaryFileName.Remove(indexOfBinFileExtension);
                            otaFile +=("_"
                                    + this.textBoxFirmwareVersion.Text
                                    + "_"
                                    + this.textBoxHardwareVersion.Text
                                    + "_ota.bin");
                        }
                        File.Delete(otaFile);
                        using (var fileStream = new FileStream(otaFile, FileMode.Append, FileAccess.Write, FileShare.None))
                        using (var bw = new BinaryWriter(fileStream))
                        {
                            // 3 bytes header + 3 bytes firmware + 3 bytes hardware + 4 bytes size + 1 byte release year + 1 date + 1 month
                            byte[] headerBytes = Encoding.ASCII.GetBytes(this.textBoxHeader.Text);
                            byte[] firmwareVersionBytes = Encoding.ASCII.GetBytes(this.textBoxFirmwareVersion.Text);
                            byte[] hardwareVersionBytes = Encoding.ASCII.GetBytes(this.textBoxHardwareVersion.Text);
                            UInt32 fileSize4Bytes = (UInt32)fileSize;
                            Char year = (char)(DateTime.Now.Year - 2000);
                            Char month = (char)(DateTime.Now.Month);
                            Char date = (char)(DateTime.Now.Day);
                            
                            bw.Write(headerBytes);
                            bw.Write(firmwareVersionBytes);
                            bw.Write(hardwareVersionBytes);
                            bw.Write(fileSize4Bytes);
                            bw.Write(year);
                            bw.Write(month);
                            bw.Write(date);
                            bw.Write(firmwareData);
                            bw.Write(checksumInBytes);
                            this.textBoxReleaseDate.Enabled = true;
                            this.textBoxReleaseDate.Text = "";
                            this.textBoxReleaseDate.Text = (DateTime.Now.Year-2000).ToString() 
                                                        + "/" + DateTime.Now.Month.ToString()
                                                        + "/" + DateTime.Now.Day.ToString();
                            this.textBoxReleaseDate.Enabled = false;
                        }
                        otaFileSize = new System.IO.FileInfo(otaFile).Length;
                        AutoClosingMessageBox.Show("Success", "OK", 1000);
                    }

                    //this.textBoxChecksum.Enabled = true;
                    this.textBoxChecksum.Text = checkSumInString;
                    this.textSize.Text = fileSize.ToString() + "/" + otaFileSize.ToString();
                }
            }
            else
            {
                AutoClosingMessageBox.Show("File not exist", "OK", 1000);
            }
        }

        private void onFormClosing(object sender, FormClosingEventArgs e)
        {
            config.file = binaryFileName;
            if (binaryFileName != null)
            {
                int lastIndexOff = config.file.LastIndexOf('\\');
                if (lastIndexOff > 0)
                {
                    config.file.Substring(config.file.LastIndexOf('\\'));
                }

                if (config.file != null)
                {
                    if (this.textBoxHardwareVersion.Text.Length == 3)
                    {
                        config.hardwareVersion = this.textBoxHardwareVersion.Text;
                    }

                    if (this.textBoxHeader.Text.Length == 3)
                    {
                        config.header = this.textBoxHeader.Text;
                    }

                    config.method = this.comboBoxChecksumMethod.Text;

                    string output = JsonSerializer.Serialize<ApplicationConfig>(config);

                    File.WriteAllText(config.directory, output);
                    Trace.WriteLine(File.ReadAllText(config.directory));
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonReload_Click(object sender, EventArgs e)
        {

        }

        static bool textBoxFirmwareBusy = false;
        private void textBoxFirmwareVersion_TextChanged(object sender, EventArgs e)
        {
            if (textBoxFirmwareBusy == false)
            {
                textBoxFirmwareBusy = true;
                string allowNumbericString = String.Empty;
                int byteCount = 0;
                foreach (char c in this.textBoxFirmwareVersion.Text)
                {
                    if (c >= '0' && c <= '9')
                    {
                        allowNumbericString += c.ToString();
                        byteCount++;
                        if (byteCount >= 3)
                        {
                            break;
                        }
                    }
                }

                this.textBoxFirmwareVersion.Text = allowNumbericString;
                this.textBoxFirmwareVersion.SelectionStart = this.textBoxFirmwareVersion.Text.Length;
                this.textBoxFirmwareVersion.SelectionLength = 0;
                textBoxFirmwareBusy = false;
            }
        }

        bool textBoxHardwareBusy = false;
        private void textBoxHardwareVersion_TextChanged(object sender, EventArgs e)
        {
            if (textBoxHardwareBusy == false)
            {
                textBoxHardwareBusy = true;
                string allowNumbericString = String.Empty;
                int byteCount = 0;
                foreach (char c in this.textBoxHardwareVersion.Text)
                {
                    if (c >= '0' && c <= '9')
                    {
                        allowNumbericString += c.ToString();
                        byteCount++;
                        if (byteCount >= 3)
                        {
                            break;
                        }
                    }
                }

                this.textBoxHardwareVersion.Text = allowNumbericString;
                this.textBoxHardwareVersion.SelectionStart = this.textBoxHardwareVersion.Text.Length;
                this.textBoxHardwareVersion.SelectionLength = 0;
                textBoxHardwareBusy = false;
            }
        }

        bool textBoxHeaderBusy = false;
        private void textBoxHeader_TextChanged(object sender, EventArgs e)
        {
            if (textBoxHeaderBusy == false)
            {
                textBoxHeaderBusy = true;
                string allowNumbericString = String.Empty;
                int byteCount = 0;
                foreach (char c in this.textBoxHeader.Text)
                {
                    allowNumbericString += c.ToString();
                    byteCount++;
                    if (byteCount >= 3)
                    {
                        break;
                    }
                }

                this.textBoxHeader.Text = allowNumbericString;
                this.textBoxHeader.SelectionStart = this.textBoxHeader.Text.Length;
                this.textBoxHeader.SelectionLength = 0;
                textBoxHeaderBusy = false;
            }
        }

        private void buttonShowFile_Click(object sender, EventArgs e)
        {
            string url = this.textBoxPath.Text;
            if (url.Contains("\\"))
            {
                url = url.Substring(0, url.LastIndexOf("\\"));
            }
            if (url != null && url.Length > 0)
            {
                try
                {
                    Process.Start("explorer.exe", @url);
                }
                catch 
                {
                    
                }
            }
        }
    }
}
