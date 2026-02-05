using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Net;
using System.IO;
using System.Xml;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Collections;
using System.Threading;

namespace HandyUpdater
{
    public partial class UpdaterWindow : Form
    {
        #region Private Data
        // Form size
        // Http request/response
        private HttpWebRequest m_req;
        private HttpWebResponse m_resp;
        private FileStream m_fs;

        // Data buffer for stream operations
        private byte[] dataBuffer;
        private const int DataBlockSize = 65536;

        // Configuration
        private XmlDocument xmlConfig;

        private string m_Status;
        private string UpdateUrl;
        private int pbVal, maxVal;

        private string HandyAppPath = @"\Application\handy\";
        private string LocalDownloadDir = @"\Application\Downloads\";
        private string LocalDownloadFile;
        private string ListDownloadFile = "UpdateList.txt";
        DataTable dtDownloadFile;
        private int CountDownloads = 0;

        #endregion

        public UpdaterWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Form load event handler. Here we read configuration
        /// </summary>
        private void UpdaterWindow_Load(object sender, EventArgs e)
        {
            if (GetCurrentDirectory() != "\\Temp")
            {
                this.StartSeparateInstance();
                return;
            }
            lblStatus.Text = "";
            xmlConfig = new XmlDocument();
            try
            {
                xmlConfig.Load(GetCurrentDirectory() + @"\UpdateConfig.xml");
            }
            catch (Exception ex)
            {
                ShowMessageBox("Failed to read updater configuration: " + ex.ToString());
                this.Close();
            }
        }

        /// <summary>
        /// Delegate for updating the file download progress
        /// </summary>
        public void UpdateProgressValue(object sender, EventArgs e)
        {
            pbProgress.Value = pbVal;
            Application.DoEvents();
        }

        /// <summary>
        /// Delegate for setting the progress bar size
        /// </summary>
        public void SetProgressMax(object sender, EventArgs e)
        {
            pbProgress.Maximum = maxVal;
            Application.DoEvents();
        }

        private DialogResult ShowMessageBox(string msg)
        {
            return ShowMessageBox(msg, "", MessageBoxButtons.OK);
        }

        // Helper procedure
        private DialogResult ShowMessageBox(string msg, string caption)
        {
            return ShowMessageBox(msg, caption, MessageBoxButtons.OK);
        }

        private DialogResult ShowMessageBox(string msg, string caption, MessageBoxButtons buttons)
        {
            DialogResult res = MessageBox.Show(msg, caption, buttons, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
            return res;
        }

        // Helper procedure
        
        private string GetCurrentDirectory()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);
        }

        #region Additional Functions for Multiple File Download : added by Nilo 01082013

        private void StartSeparateInstance()
        { 
            try
            {
                //start moving updater files
                if (Logger.isFileExist("\\Temp"+ @"\", "Handy Updater.exe"))
                {
                    System.IO.File.Delete("\\Temp\\Handy Updater.exe");
                }
                System.IO.File.Copy(GetCurrentDirectory() + @"\" + "Handy Updater.exe", "\\Temp\\Handy Updater.exe");

                if (Logger.isFileExist("\\Temp" + @"\", "UpdateConfig.xml"))
                {
                    System.IO.File.Delete("\\Temp\\UpdateConfig.xml");
                }
                System.IO.File.Copy(GetCurrentDirectory() + @"\" + "UpdateConfig.xml", "\\Temp\\UpdateConfig.xml");

                //start executing new instance
                string HandyUpdater = "\\Temp\\Handy Updater.exe";

                int nSize = HandyUpdater.Length * 2 + 2;
                IntPtr pData = LocalAlloc(0x40, nSize);
                Marshal.Copy(Encoding.Unicode.GetBytes(HandyUpdater), 0, pData, nSize - 2);
                SHELLEXECUTEEX see = new SHELLEXECUTEEX();
                see.cbSize = 60;
                see.dwHotKey = 0;
                see.fMask = 0;
                see.hIcon = IntPtr.Zero;
                see.hInstApp = IntPtr.Zero;
                see.hProcess = IntPtr.Zero; ;
                see.lpClass = IntPtr.Zero;
                see.lpDirectory = IntPtr.Zero;
                see.lpIDList = IntPtr.Zero;
                see.lpParameters = IntPtr.Zero;
                see.lpVerb = IntPtr.Zero;
                see.nShow = 1;
                see.lpFile = pData;
                ShellExecuteEx(see);
                LocalFree(pData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Close();
        }

        private void StartDownloading(String _DownloadFile)
        {
            HttpWebRequest request;
            HttpWebResponse response = null;

            try
            {
                request = (HttpWebRequest)WebRequest.Create(UpdateUrl + _DownloadFile);
                request.Timeout = 480000;
                request.AllowWriteStreamBuffering = false;
                response = (HttpWebResponse)request.GetResponse();
                Stream s = response.GetResponseStream();
                //Write to disk
                FileStream fs = new FileStream(LocalDownloadFile, FileMode.Create);
                byte[] read = new byte[256];
                int count = s.Read(read, 0, read.Length);
                int dot = 0;
                string sdot = ".";
                while (count > 0)
                {
                    fs.Write(read, 0, count);
                    count = s.Read(read, 0, read.Length);
                    //pbVal += Convert.ToInt32((Convert.ToDouble(pbVal) / Convert.ToDouble(count)) * 100);
                    SetStatus("Please wait. Downloading " + _DownloadFile+ " " +sdot);
                    sdot = "..";
                    ++dot;
                    if (dot > 3)
                        sdot = "...";
                    else
                        sdot = ".";
                }
                //Close everything
                fs.Close();
                s.Close();
                response.Close();
            }
            catch (System.Net.WebException ex)
            {
                ShowMessageBox(ex.Message);
                if (response != null)
                    response.Close();
            }

        }

        private bool StartCheckDownloadFile()
        {
            if (dtDownloadFile != null)
            {
                foreach (DataRow dr in dtDownloadFile.Rows)
                {
                    LocalDownloadFile = LocalDownloadDir + dr["COLUMN_1"].ToString().Trim();
                    if (!Logger.isFileExist(LocalDownloadDir, dr["COLUMN_1"].ToString().Trim()))
                    {
                        return false;
                    }
                }
            }
            else
                return false;

            return true;
        }

        private void StartOverwriteFile()
        {
            if (dtDownloadFile != null)
            {
                foreach (DataRow dr in dtDownloadFile.Rows)
                {
                    LocalDownloadFile = LocalDownloadDir + dr["COLUMN_1"].ToString().Trim();
                    if (Logger.isFileExist(LocalDownloadDir, dr["COLUMN_1"].ToString().Trim()))
                    {
                        if(Logger.isFileExist(HandyAppPath, dr["COLUMN_1"].ToString().Trim()))
                        {
                            System.IO.File.Delete(HandyAppPath + dr["COLUMN_1"].ToString().Trim());
                        }
                        System.IO.File.Move(LocalDownloadFile,HandyAppPath + dr["COLUMN_1"].ToString().Trim());
                    }
                }
            }
        }
        
        #endregion

        private void btnUpdate_Click(object sender, System.EventArgs e)
        {   
            // Create asynchronous web request
            lblStatus.Text = "Downloading updates. Please wait...";
            lblCheckUpdate.Enabled = false;
            pbProgress.Visible = true;
            //Download update list
            LocalDownloadFile = LocalDownloadDir + ListDownloadFile;
            //create download directory
            if (!System.IO.Directory.Exists(LocalDownloadDir))
            {
                System.IO.Directory.CreateDirectory(LocalDownloadDir);
            }
            StartDownloading(ListDownloadFile);
            Cursor.Current = Cursors.WaitCursor;
            if(Logger.isFileExist(LocalDownloadDir,ListDownloadFile))
            {
                dtDownloadFile = Logger.GetTextDataTable(LocalDownloadFile);
                if (dtDownloadFile != null)
                {
                    pbVal = 0;
                    int ctr = 1;
                    foreach (DataRow dr in dtDownloadFile.Rows)
                    {
                        pbVal = Convert.ToInt32(Convert.ToDouble(ctr) / Convert.ToDouble(dtDownloadFile.Rows.Count) * 100);
                        pbProgress.Invoke(new EventHandler(UpdateProgressValue));
                        LocalDownloadFile = LocalDownloadDir + dr["COLUMN_1"].ToString().Trim();
                        this.StartDownloading(dr["COLUMN_1"].ToString().Trim());
                        ++ctr;
                    }
                    SetStatus("Deploying downloaded updates. Please wait.");
                    Thread.Sleep(5000); //allow cpu to breath
                    if (this.StartCheckDownloadFile())
                    {
                        this.StartOverwriteFile();
                    }
                    lblStatus.Text = "Update is complete.";
                    ShowMessageBox("Update is complete.");
                }
                Logger.isFileCleared(LocalDownloadDir,ListDownloadFile);
            }
            pbProgress.Visible = false;
            Cursor.Current = Cursors.Default;
            ////Oldcode
            //m_req = (HttpWebRequest)HttpWebRequest.Create(UpdateUrl+DownloadFile[CountDownloads]);
            //m_req.BeginGetResponse(new AsyncCallback(ResponseReceived), null);
            //btnCheck.Enabled = false;
            //Cursor.Current = Cursors.WaitCursor;
        }

        // Delegate for setting status line
        private void SetStatus(object sender, System.EventArgs e)
        {
            lblStatus.Text = m_Status;
            Application.DoEvents();
        }

        // Setting status via Control.Invoke. We need this when changing status text from 
        // inside async call callback
        private void SetStatus(string Status)
        {
            m_Status = Status;
            lblStatus.Invoke(new EventHandler(SetStatus));
        }

        // Get the assembly version for the specified assembly (config file)
        // Use web service to query update availability
        private void btnCheck_Click(object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            SetStatus("Checking for updates");
            Assembly a = null;
            AssemblyName name = new AssemblyName();

            // If assembly does not exists, presume the version to be 0.0.0.0
            name.Version = new Version("0.0.0.0");

            // Try obtaining assembly version
            //string sPath = GetCurrentDirectory() + @"\" + xmlConfig["updateinfo"]["checkassembly"].GetAttribute("name");
            //Nilo Revise Harcoded for Handy V3.exe
            //Do not used this lock up the handy application to be overwritten
            string sPath = "x";// @"\Application\handy\Handy V3.exe";
            try
            {
                if (File.Exists(sPath))
                {
                    a = Assembly.LoadFrom(sPath);
                    name = a.GetName();
                }
            }
            catch (Exception)
            {
            }

            // Release assembly, so that its file is not locked anymore
            a = null;

            // Use web service to inquire as of update availability

            try
            {

                HandyUpdater.UpdaterWebReference.UpdaterWebService _service = new HandyUpdater.UpdaterWebReference.UpdaterWebService();
                _service.Url = xmlConfig["updateinfo"]["service"].GetAttribute("url");
                string appName = xmlConfig["updateinfo"]["remoteapp"].GetAttribute("name").ToUpper();
                HandyUpdater.UpdaterWebReference.UpdateInfo info = _service.GetUpdateInfo(appName, name.Version.Major, name.Version.Minor, name.Version.Build, name.Version.Revision);
                if (info != null)
                {
                    // If there is an updated version allow user to proceed with update
                    if (info.IsAvailable)
                    {
                        lblStatus.Text = "Update is available";
                        //lblStatus.Text += "\nCurrent Version: " + name.Version.ToString();
                        lblStatus.Text += "\nUpdate Version: " + info.newVersion;
                        lblCheckUpdate.Text = "Update";
                        UpdateUrl = info.Url;
                    }
                    else
                    {
                        lblStatus.Text = "There are no updates available";
                    }
                }
                else
                {
                    lblStatus.Text = "There are no updates available";
                }
            }
            catch (Exception ex)
            {                
                SetStatus(ex.Message);
            }

            Cursor.Current = Cursors.Default;
        }

        // When cab download is finished, launch it. This will cause
        // wceload.exe to initiate installation process
        private void AllDone(object sender, System.EventArgs e)
        {
            lblCheckUpdate.Enabled = true;
            lblCheckUpdate.Text = "Check";
            Cursor.Current = Cursors.Default;
            pbProgress.Visible = false;

            try
            {
                string docname = @"\Application\Downloads\Handy.cab";

                int nSize = docname.Length * 2 + 2;
                IntPtr pData = LocalAlloc(0x40, nSize);
                Marshal.Copy(Encoding.Unicode.GetBytes(docname), 0, pData, nSize - 2);
                SHELLEXECUTEEX see = new SHELLEXECUTEEX();
                see.cbSize = 60;
                see.dwHotKey = 0;
                see.fMask = 0;
                see.hIcon = IntPtr.Zero;
                see.hInstApp = IntPtr.Zero;
                see.hProcess = IntPtr.Zero; ;
                see.lpClass = IntPtr.Zero;
                see.lpDirectory = IntPtr.Zero;
                see.lpIDList = IntPtr.Zero;
                see.lpParameters = IntPtr.Zero;
                see.lpVerb = IntPtr.Zero;
                see.nShow = 1;
                see.lpFile = pData;
                ShellExecuteEx(see);
                LocalFree(pData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Close();
        }

        // Asynchronous routine to process the http web request
        void ResponseReceived(IAsyncResult res)
        {
            // Try getting the web response. If there was an error (404 or other),
            // web exception will be thrown here
            try
            {
                 m_resp = (HttpWebResponse)m_req.EndGetResponse(res);
            }
            catch (WebException ex/*ex*/)
            {
                ShowMessageBox(ex.Message, "Error", MessageBoxButtons.OK);
                return;
            }
            dataBuffer = new byte[DataBlockSize];
            // Prepare the propgres bar
            maxVal = (int)m_resp.ContentLength;
            pbProgress.Invoke(new EventHandler(SetProgressMax));

            //create download directory
            if (!System.IO.Directory.Exists(LocalDownloadDir))
            {
                System.IO.Directory.CreateDirectory(LocalDownloadDir);
            }

            //create cab file
            m_fs = new FileStream(LocalDownloadFile, FileMode.Create);

            // Start reading from network stream asynchronously
            m_resp.GetResponseStream().BeginRead(dataBuffer, 0, DataBlockSize, new AsyncCallback(OnDataRead), this);
        }

        // Asynchronous network stream reading
        void OnDataRead(IAsyncResult res)
        {
            // Get bytecount of the received chunk
            int nBytes = m_resp.GetResponseStream().EndRead(res);
            // Dump it to the output stream
            m_fs.Write(dataBuffer, 0, nBytes);
            // Update prgress bar
            pbVal += nBytes;
            pbProgress.Invoke(new EventHandler(UpdateProgressValue));
            if (nBytes > 0)
            {
                // If read was successful, continue reading asynchronously as there is more data
                m_resp.GetResponseStream().BeginRead(dataBuffer, 0, DataBlockSize, new AsyncCallback(OnDataRead), this);
            }
            else
            {
                // Otherwise close the stream and proceed with installation
                pbVal = 0;
                pbProgress.Invoke(new EventHandler(UpdateProgressValue));
                m_fs.Close();
                m_fs = null;
                this.Invoke(new EventHandler(this.AllDone));
            }
        }

        public Process[] StartProcesses( ProcessStartInfo[] infos, bool waitForExit )
        {
            ArrayList processesBuffer = new ArrayList();
            foreach( ProcessStartInfo info in infos )
            {
                Process process = Process.Start( info );
                
                if( waitForExit )
                {
                    process.WaitForExit();
                }
                processesBuffer.Add( process );
            }

            return (Process[])processesBuffer.ToArray( typeof(Process) );
        }

        #region PInvoke
        class SHELLEXECUTEEX
        {
            public UInt32 cbSize;
            public UInt32 fMask;
            public IntPtr hwnd;
            public IntPtr lpVerb;
            public IntPtr lpFile;
            public IntPtr lpParameters;
            public IntPtr lpDirectory;
            public int nShow;
            public IntPtr hInstApp;

            // Optional members 
            public IntPtr lpIDList;
            public IntPtr lpClass;
            public IntPtr hkeyClass;
            public UInt32 dwHotKey;
            public IntPtr hIcon;
            public IntPtr hProcess;
        }

        [DllImport("coredll")]
        extern static int ShellExecuteEx(SHELLEXECUTEEX ex);

        [DllImport("coredll")]
        extern static IntPtr LocalAlloc(int flags, int size);

        [DllImport("coredll")]
        extern static void LocalFree(IntPtr ptr);


        #endregion

        private void UpdaterWindow_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F14:
                    {
                        if (lblCheckUpdate.Enabled == true)
                        {
                            if (lblCheckUpdate.Text == "Check")
                                btnCheck_Click(this, e);
                            else
                                btnUpdate_Click(this, e);
                        }
                    }
                    break;
                case Keys.F15:
                    Close();
                    break;
            }
        }

    }
}