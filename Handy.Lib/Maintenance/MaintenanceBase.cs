using System;
using System.Collections.Generic;
using System.Data;
using DataHelper;
using CEDataHelper;
using System.Data.SqlServerCe;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Net;
using System.Drawing;

namespace Handy.Lib
{
    public class MaintenanceBase
    {

        #region Maintainance

        private static bool _OfflineMode = false;
        public static bool OfflineMode
        {
            get
            {
                return _OfflineMode;
            }
            set
            {
                if (_OfflineMode == value)
                    return;
                _OfflineMode = value;
            }
        }

        private static string _strDatasource = string.Empty;
        public static string strDatasource
        {
            get
            {
                return _strDatasource;
            }
            set
            {
                if (_strDatasource == value)
                    return;
                _strDatasource = value;
            }
        }

        private static string _strDatabase = string.Empty;
        public static string strDatabase
        {
            get
            {
                return _strDatabase;
            }
            set
            {
                if (_strDatabase == value)
                    return;
                _strDatabase = value;
            }
        }

        private static string _strDBUser = string.Empty;
        public static string strDBUser
        {
            get
            {
                return _strDBUser;
            }
            set
            {
                if (_strDBUser == value)
                    return;
                _strDBUser = value;
            }
        }

        private static string _strDBPassword = string.Empty;
        public static string strDBPassword
        {
            get
            {
                return _strDBPassword;
            }
            set
            {
                if (_strDBPassword == value)
                    return;
                _strDBPassword = value;
            }
        }

        private static int _SelectedControl = 0;
        public static int SelectedControl
        {
            get
            {
                return _SelectedControl;
            }
            set
            {
                if (_SelectedControl == value)
                    return;
                _SelectedControl = value;
            }
        }

        //Host Name
        private static string _strIP = string.Empty;
        public static string strIP
        {
            get
            {
                return _strIP;
            }
            set
            {
                if (_strIP == value)
                    return;
                _strIP = value;
            }
        }

        private static string _strHostName = string.Empty;
        public static string strHostName
        {
            get
            {
                return _strHostName;
            }
            set
            {
                if (_strHostName == value)
                    return;
                _strHostName = value;
            }
        }

        private static List<TextBox> ControlList = new List<TextBox>();

        public static void ListTextControls(Control.ControlCollection _Controls)
        {
            MaintenanceBase.SelectedControl = 0;
            if (ControlList != null)
                ControlList.Clear();

            foreach (Control _control in _Controls)
            {
                if (_control is TextBox)
                {
                    ControlList.Add((TextBox)_control);
                }
            }

            if (ControlList != null)
            {
                if (ControlList.Count > 0)
                {
                    ControlList.Sort(new Comparison<TextBox>(CompareTabIndex));
                }
            }
        }

        public static void FocusTextControl(CommonEnum.TextFocus Focus)
        {
            if (ControlList == null)
                return;
            switch (Focus)
            {
                case CommonEnum.TextFocus.Next:
                    {
                        if (MaintenanceBase.SelectedControl >= ControlList.Count)
                            MaintenanceBase.SelectedControl = 0;
                        if (ControlList.Count > 0)
                        {
                            ControlList[MaintenanceBase.SelectedControl].Focus();
                            ControlList[MaintenanceBase.SelectedControl].SelectAll();
                            ++MaintenanceBase.SelectedControl;
                        }
                    }
                    break;
                case CommonEnum.TextFocus.Previous:
                    {
                        --MaintenanceBase.SelectedControl;
                        if (MaintenanceBase.SelectedControl < 0)
                            MaintenanceBase.SelectedControl = 0;
                        if (ControlList.Count > 0)
                        {
                            ControlList[MaintenanceBase.SelectedControl].Focus();
                            ControlList[MaintenanceBase.SelectedControl].SelectAll();
                        }
                    }
                    break;
            }
        }

        private static int CompareTabIndex(TextBox T1, TextBox T2)
        {
            return T1.TabIndex.CompareTo(T2.TabIndex);
        }

        public static bool AddRegKey()
        {
            bool UpdateReg = false;
            try
            {
                TextParameterInfo[] TextParamInfo = new TextParameterInfo[4];
                string[] param = new string[4];
                string[] parsedIP = _strIP.Split('.');

                if (Logger.isFileExist(Logger.HandyPath, Logger.HandyHostFile))
                {
                    Logger.GetTextData(Logger.HandyPath, Logger.HandyHostFile, param);
                    TextParamInfo[0] = new TextParameterInfo("HOST_NEW", param[0]);
                    TextParamInfo[1] = new TextParameterInfo("IP_NEW", param[1]);
                    TextParamInfo[2] = new TextParameterInfo("HOST_OLD", param[2]);
                    TextParamInfo[3] = new TextParameterInfo("IP_OLD", param[3]);

                    if (!string.IsNullOrEmpty(_strHostName) && !string.IsNullOrEmpty(_strIP))
                    {
                        //Updating Host File
                        TextParamInfo[0] = new TextParameterInfo("HOST_NEW", _strHostName);
                        TextParamInfo[1] = new TextParameterInfo("IP_NEW", _strIP);
                        TextParamInfo[2] = new TextParameterInfo("HOST_OLD", _strHostName);
                        TextParamInfo[3] = new TextParameterInfo("IP_OLD", _strIP);
                        UpdateReg = Logger.WriteTextData(Logger.HandyPath, Logger.HandyHostFile, TextParamInfo);
                        //Counter checking IP
                        if (parsedIP.Length != 4)
                        {
                            UpdateReg = false;
                            CommonFunctions.MessageShow("Invalid IP address format", CommonEnum.NotificationType.Warning);
                        }
                    }
                }
                else
                {
                    TextParamInfo[0] = new TextParameterInfo("HOST_NEW", _strHostName);
                    TextParamInfo[1] = new TextParameterInfo("IP_NEW", _strIP);
                    TextParamInfo[2] = new TextParameterInfo("HOST_OLD", _strHostName);
                    TextParamInfo[3] = new TextParameterInfo("IP_OLD", _strIP);
                    UpdateReg = Logger.WriteTextData(Logger.HandyPath, Logger.HandyHostFile, TextParamInfo);
                    //Counter checking IP
                    if (parsedIP.Length != 4)
                    {
                        UpdateReg = false;
                    }
                }

                if (string.IsNullOrEmpty(_strIP))
                    parsedIP = param[1].Split('.');
                //if (UpdateReg)
                //{
                Microsoft.Win32.RegistryKey key;
                key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Comm").CreateSubKey("Tcpip").CreateSubKey("Hosts").CreateSubKey(_strHostName);
                key.SetValue("ipaddr", new byte[] { Convert.ToByte(parsedIP[0]), Convert.ToByte(parsedIP[1]), Convert.ToByte(parsedIP[2]), Convert.ToByte(parsedIP[3]) } , Microsoft.Win32.RegistryValueKind.Binary);
                key.SetValue("ExpireTime", new byte[] { 160, 160, 160, 160, 160, 160, 160 }, Microsoft.Win32.RegistryValueKind.Binary);
                key.Close();
                //}
                return true;
            }
            catch (Exception ex)
            {
                CommonFunctions.MessageShow("Unable to set hostname."+"\n"+ex.Message, CommonEnum.NotificationType.Warning);
                return false;
            }

        }

        public static void SetDatabaseStringInstances()
        {
            try
            {
                string connection = HandyConfiguration.Settings["ERPDB"];
                string[] parsed = new string[4];
                //Data Source=NILO-PC; Initial Catalog=ERP_THI;Persist Security Info=True;User ID=sa;Password=systemadmin
                parsed = connection.Split(';');
                _strDatasource = parsed[0].Replace(@"Data Source=", "").Trim();
                _strDatabase = parsed[1].Replace(@"Initial Catalog=", "").Trim();
                _strDBUser = parsed[3].Replace(@"User ID=", "").Trim();
                _strDBPassword = parsed[4].Replace(@"Password=", "").Trim(); ; // hide password

            }
            catch (Exception ex)
            {
                CommonFunctions.MessageShow(ex.ToString(), CommonEnum.NotificationType.Error);
            }
        }

        public static bool FTPSendFiles(string IP, string User, string Pass)
        {

            Cursor.Current = Cursors.WaitCursor;
            CommonFunctions.HandyFTPSeqNo = "0000000";
            bool ret = false;
            CommonFunctions.PostProgress.Value = 0;
            try
            {
                if (!Logger.isFileExist(Logger.HandyPath, Logger.HandyFTPSeqFile))
                {
                    string[] param = new string[1];
                    param[0] = CommonFunctions.HandyFTPSeqNo;
                    Logger.WriteTextData(Logger.HandyPath, Logger.HandyFTPSeqFile, param);
                }
                else
                {
                    string[] param = new string[1];
                    param = Logger.GetTextData(Logger.HandyFTPSeqPathFile, param);
                    if (param != null)
                    {
                        try
                        {
                            int seq = Convert.ToInt16(param[0]) + 1;
                            CommonFunctions.HandyFTPSeqNo = seq.ToString("0000000");

                            string[] _param = new string[1];
                            _param[0] = CommonFunctions.HandyFTPSeqNo;
                            Logger.WriteTextData(Logger.HandyPath, Logger.HandyFTPSeqFile, _param);
                        }
                        catch { }
                    }
                }

                FTPClient.FTPConnection ftp = new FTPClient.FTPConnection();
                ftp.Open(IP, User, Pass, FTPClient.FTPMode.Passive);
                if (System.IO.Directory.Exists(Logger.HandyPath))
                {
                    string[] files = System.IO.Directory.GetFiles(Logger.HandyPath, "*.*");
                    int i = 0;
                    foreach (string file in files)
                    {
                        Thread.Sleep(100);
                        ftp.SendFile(file, file.Replace(Logger.HandyPath, @"\HANDY_" + CommonFunctions.HandyNo + @"\" + Handy.Lib.CommonFunctions.HandyFTPSeqNo + @"\"), FTPClient.FTPFileTransferType.Binary);
                        ++i;
                        CommonFunctions.PostProgress.Value = Convert.ToInt32((Convert.ToDecimal(i) / files.Length) * 100);
                    }
                }
                if (System.IO.Directory.Exists(Logger.HandyArchivedPath))
                {
                    CommonFunctions.PostProgress.Value = 0;
                    string[] files = System.IO.Directory.GetFiles(Logger.HandyArchivedPath, "*.*");
                    int i = 0;
                    foreach (string file in files)
                    {
                        Thread.Sleep(100);
                        ftp.SendFile(file, file.Replace(Logger.HandyArchivedPath, @"\HANDY_" + CommonFunctions.HandyNo + @"\" + Handy.Lib.CommonFunctions.HandyFTPSeqNo + @"\Archives\"), FTPClient.FTPFileTransferType.Binary);
                        ++i;
                        CommonFunctions.PostProgress.Value = Convert.ToInt32((Convert.ToDecimal(i) / files.Length) * 100);
                    }
                }
                ftp.Close();
                CommonFunctions.PostProgress.Value = 100;
                ret = true;
            }
            catch (Exception Ex)
            {
                CommonFunctions.MessageShow(Ex.Message, CommonEnum.NotificationType.Warning);
            }
            Cursor.Current = Cursors.Default;
            return ret;
        }

        #endregion
        public static bool UpdateHandyMonitoring()
        {
            bool ret = false;
            string SerialNo = "";
            try
            {
                try
                {
                    MaintenanceBase.SetDatabaseStringInstances();
                    SerialNo = "";
                }
                catch { }
                ret = CommonFunctions.ExecuteNonQuery(String.Format(CommonQueryStrings.StoredProc.spHandyUpdateMonitoringParametered
                                                    , CommonFunctions.HandyMacAddress
                                                    , CommonFunctions.HandyNo
                                                    , CommonFunctions.HandyIPAddress
                                                    , SerialNo
                                                    , "BT-W SERIES"
                                                    , ""
                                                    , MaintenanceBase.strDatasource
                                                    , MaintenanceBase.strDatabase
                                                    , "A"
                                                    , CommonFunctions.Username));

            }
            catch
            { ret = false; }
            return ret;
        }

    }
}
