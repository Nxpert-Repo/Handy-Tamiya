using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Reflection;
using System.Threading;
using System.Net;
using Handy.Lib;
//using Symbol.Fusion;
//using Symbol.Fusion.WLAN;
//using Symbol.Exceptions;
using System.Runtime.InteropServices;
//using Symbol.ResourceCoordination;

namespace Handy
{
    //Nilo Added Functions 09/24/2012
    //Common GUI base functions
    //Format Header Footer
    //Add Footer Event
    //Signal Strength Checking
    //

    public class CommonInterfaceFunctions
    {
        #region Format Form Images

        public static void FormatBackPicture(PictureBox PicBox, Bitmap Img)
        {
            PictureBox pictureBox = PicBox;
            pictureBox.Height = 320;
            pictureBox.Width = 320;
            pictureBox.Location = new Point(0, 0);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Image = Img;
        }

        public static void FormatHeaderPicture(PictureBox PicBox, Bitmap Img)
        {
            PictureBox HeaderPictureBox = PicBox;
            HeaderPictureBox.Height = 32;
            HeaderPictureBox.Width = 320;
            HeaderPictureBox.Location = new Point(0, -1);
            HeaderPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            HeaderPictureBox.BackColor = System.Drawing.Color.White;
            HeaderPictureBox.Image = Img;
        }

        public static void FormatFooterPicture(PictureBox PicBox, Bitmap Img)
        {
            PictureBox FooterPictureBox = PicBox;
            FooterPictureBox.Height = 32;
            FooterPictureBox.Width = 320;
            FooterPictureBox.Location = new Point(0, 288);
            FooterPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            FooterPictureBox.BackColor = System.Drawing.Color.White;
            FooterPictureBox.Image = Img;
        }

        #endregion

        #region Signal Stregth

        #region Variables
        /// <summary>
        /// Config object for Version and Diagnostics
        /// </summary>
        private static Config Config = null;
        /// <summary>
        /// WLAN object for WLAN operations
        /// </summary>
        private static WLAN Wlan = null;
        /// <summary>
        /// Variable storage for WLAN adpater
        /// </summary>
        private static Adapter _Adapter = null;
        private static string adapterPowerState = "";
        /// <summary>
        /// The event handler for SignalQuality changes
        /// </summary>
        public static Adapter.SignalQualityHandler SignalQualityHandler = null;
        private static bool UseNewSignal = false;
        #endregion

        #region Public Function
        public static void WLANInitializeAdapter()
        {
            Cursor SavedCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            Int32 res;
            _Adapter = new Adapter();

            try
            {
                // open WLAN
                res = Bt.CommLib.Wlan.btWLANOpen();
                if (res == Bt.LibDef.BT_OK || res == Bt.LibDef.BT_ERR_COMM_ALREADY_OPEN)
                {
                    //CommonFunctions.MessageShow("WLAN Ok");
                    uint status = 0;
                    res = Bt.CommLib.Wlan.btWLANGetStatus(ref status);
                    if (res == Bt.LibDef.BT_OK)
                    {
                        //switch (status)
                        //{
                        //    case Bt.LibDef.BT_WLAN_STS_ADHOC_WAITING:
                        //        CommonFunctions.MessageShow("WLAN waiting"); break;
                        //    case Bt.LibDef.BT_WLAN_STS_CONNECTED:
                        //        CommonFunctions.MessageShow("WLAN connected"); break;
                        //    case Bt.LibDef.BT_WLAN_STS_DISABLE:
                        //        CommonFunctions.MessageShow("WLAN disabled"); break;
                        //    case Bt.LibDef.BT_WLAN_STS_DISCONNECTED:
                        //        CommonFunctions.MessageShow("WLAN disconnected"); break;
                        //    case Bt.LibDef.BT_WLAN_STS_LINKLOST:
                        //        CommonFunctions.MessageShow("WLAN link lost"); break;
                        //    case Bt.LibDef.BT_WLAN_STS_PROCESSING:
                        //        CommonFunctions.MessageShow("WLAN processing"); break;
                        //}
                        if (status == Bt.LibDef.BT_WLAN_STS_CONNECTED)
                        {
                            Adapter_SignalQualityChanged(null, null);
                        }
                    }
                    SignalQualityHandler = new Adapter.SignalQualityHandler(Adapter_SignalQualityChanged);
                }
                else
                {
                    CommonFunctions.MessageShow("WLAN Open Error");
                }
            }
            catch 
            {
                CommonFunctions.MessageShow("WLAN Initialization Exception");
            }

            StringBuilder mac = new StringBuilder();
            Bt.CommLib.Wlan.btWLANGetMacAddr(mac);
            CommonFunctions.HandyMacAddress = mac.ToString();
            Cursor.Current = SavedCursor;
        }

        public static void WLANAddSignalQualityHandler(PictureBox pbSignalStatusDisplay)
        {
            WLANAddSignalQualityHandler(pbSignalStatusDisplay, false);
        }


        /// <summary>
        /// Attaches Signal Handler in _Adapter. Saves signal status in common variables namespace.
        /// </summary>
        /// <param name="pbSignalStatusDisplay">Signal status image.</param>
        /// <param name="NewSignal">true if new signal, false otherwise.</param>
        public static void WLANAddSignalQualityHandler(PictureBox pbSignalStatusDisplay, bool NewSignal)
        {
            UseNewSignal = NewSignal;

            try
            {
                if (CommonFunctions.pbSignalStatus == null && pbSignalStatusDisplay != null)
                {
                    // attach signal handler
                    if (_Adapter != null && SignalQualityHandler != null)
                    {
                        _Adapter.SignalQualityChanged += SignalQualityHandler;
                    }
                }
                else                
                {
                    // detach and reattach signal handler
                    WLANRemoveSignalQualityHandler();
                    if (_Adapter != null && SignalQualityHandler != null)
                    {
                        _Adapter.SignalQualityChanged += SignalQualityHandler;
                    }
                }
                CommonFunctions.pbSignalStatus = pbSignalStatusDisplay;
            }
            catch (Exception ex)
            {
                CommonFunctions.MessageShow(ex.Message, CommonEnum.NotificationType.Error);
            }
        }

        public static void WLANRemoveSignalQualityHandler()
        {
            try
            {
                if (CommonFunctions.pbSignalStatus != null && SignalQualityHandler != null)
                {
                    _Adapter.SignalQualityChanged -= SignalQualityHandler;
                    CommonFunctions.pbSignalStatus = null;
                }
                else
                {
                    //CommonFunctions.MessageShow("Signal Status Object is null", CommonEnum.NotificationType.Error);
                }
            }
            catch (Exception ex)
            {
                string message = CommonFunctions.pbSignalStatus.ToString();
                CommonFunctions.MessageShow("Unable to access Wireless LAN Adapter" + "\n" + ex.Message, CommonEnum.NotificationType.Error);
                //CommonFunctions.MessageShow(message, CommonEnum.NotificationType.Error);
            }
        }

        public static void WLANDispose()
        {
            try
            {
                // Add SignalQualityChanged event handler
                Wlan.Dispose();
                if (CommonFunctions.pbSignalStatus == null)
                {
                    //Do nothing
                }
                else
                {
                    CommonFunctions.pbSignalStatus.Dispose();
                }
                Config.Dispose();
            }
            catch { }
        }

        #endregion

        #region Private Fuction

        // add Keyence specific code here to acquire WiFi signal
        // btWLANOpen/Close
        // btWLANGetStatus (Connected, Out of range, Connecting, Disconnecting, Disabled, Listening)
        // btWLANGetSignalLevel()
        // btWLANSetProperty/GetProperty
        // btWLANGetMacAddr()
        private static void Adapter_SignalQualityChanged(object sender, StatusChangeArgs e)
        {
            try
            {
                if (CommonFunctions.pbSignalStatus == null)
                {
                    //Do nothing
                }
                else
                {
                    // TO DO:
                    int res;
                    uint type, level = 0;
                    type = Bt.LibDef.BT_WLAN_TYPE_RSSI;
                    res = Bt.CommLib.Wlan.btWLANGetSignalLevel(type, ref level);

                    // Keyence signal level 0 - 3
                    string Signal = e.SignalQuality.ToString().Trim().ToUpper();
                    if      (level == 0) Signal = "NONE";
                    else if (level == 1) Signal = "FAIR";
                    else if (level == 2) Signal = "GOOD";
                    else                 Signal = "EXCELLENT";

                    CommonFunctions.pbSignalStatus.BackColor = Color.White;
                    if (Signal.Equals("NONE"))
                    {
                        CommonFunctions.SignalStat = CommonEnum.Signal.NONE;
                        CommonFunctions.pbSignalStatus.Image = Properties.Resources.Signal_None;
                    }
                    //else if (Signal.Equals("POOR"))
                    //{
                    //    CommonFunctions.SignalStat = CommonEnum.Signal.POOR;
                    //    CommonFunctions.pbSignalStatus.Image = Properties.Resources.Signal_Poor;
                    //}
                    else if (Signal.Equals("FAIR"))
                    {
                        CommonFunctions.SignalStat = CommonEnum.Signal.FAIR;
                        CommonFunctions.pbSignalStatus.Image = Properties.Resources.Signal_Fair;
                    }
                    else if (Signal.Equals("GOOD"))
                    {
                        CommonFunctions.SignalStat = CommonEnum.Signal.GOOD;
                        CommonFunctions.pbSignalStatus.Image = Properties.Resources.Signal_Good;
                    }
                    //else if (Signal.Equals("VERYGOOD"))
                    //{
                    //    CommonFunctions.SignalStat = CommonEnum.Signal.VERYGOOD;
                    //    CommonFunctions.pbSignalStatus.Image = Properties.Resources.Signal_VeryGood;
                    //}
                    else if (Signal.Equals("EXCELLENT"))
                    {
                        CommonFunctions.SignalStat = CommonEnum.Signal.EXCELLENT;
                        CommonFunctions.pbSignalStatus.Image = Properties.Resources.Signal_Excellent;
                    }

                    //Nilo Added 20130903 : Backgroud SQL Connection check
                    if(!Signal.Equals("NONE"))
                    {
                        BackGroudConnectionCheck();
                    }
                }
            }
            catch { }
        }
        #endregion

        #endregion

        #region Battery Life

        private struct SYSTEM_POWER_STATUS_EX2
        {
            public byte ACLineStatus;
            public byte BatteryFlag;
            public byte BatteryLifePercent;
            public byte Reserved1;
            public uint BatteryLifeTime;
            public uint BatteryFullLifeTime;
            public byte Reserved2;
            public byte BackupBatteryFlag;
            public byte BackupBatteryLifePercent;
            public byte Reserved3;
            public uint BackupBatteryLifeTime;
            public uint BackupBatteryFullLifeTime;
            public uint BatteryVoltage;
            public uint BatteryCurrent;
            public uint BatteryAverageCurrent;
            public uint BatteryAverageInterval;
            public uint BatterymAHourConsumed;
            public uint BatteryTemperature;
            public uint BackupBatteryVoltage;
            public byte BatteryChemistry;
        }

        private struct SYSTEM_POWER_STATUS_EX
        {
            public byte ACLineStatus;
            public byte BatteryFlag;
            public byte BatteryLifePercent;
            public byte Reserved1;
            public uint BatteryLifeTime;
            public uint BatteryFullLifeTime;
            public byte Reserved2;
            public byte BackupBatteryFlag;
            public byte BackupBatteryLifePercent;
            public byte Reserved3;
            public uint BackupBatteryLifeTime;
            public uint BackupBatteryFullLifeTime;
        }

        
        [DllImport("coredll.dll")]
        private static extern bool GetSystemPowerStatusEx(SYSTEM_POWER_STATUS_EX lpSystemPowerStatus,
            bool fUpdate);

        [DllImport("coredll.dll", SetLastError = true)]
        private static extern bool GetSystemPowerStatusEx2(SYSTEM_POWER_STATUS_EX2 lpSystemPowerStatus,
            Int32 dwLen, bool fUpdate);
        

        //[DllImport("kernel32.dll", SetLastError = true)]
        //private static extern bool GetSystemPowerStatus(out SYSTEM_POWER_STATUS_EX lpSystemPowerStatus);

        public static void SetBatteryLifeInterface(PictureBox pcBatteryLifeDisplay)
        {
            try
            {
                SYSTEM_POWER_STATUS_EX BatteryLife = new SYSTEM_POWER_STATUS_EX();
                //bool ret = CommonInterfaceFunctions.GetSystemPowerStatusEx2(BatteryLife, Marshal.SizeOf(BatteryLife), true);
                //if (ret)
                if (CommonInterfaceFunctions.GetSystemPowerStatusEx(BatteryLife, true))
                {
                    byte LifePercent = BatteryLife.BatteryLifePercent;
                    if (BatteryLife.ACLineStatus == 1)
                        pcBatteryLifeDisplay.Image = Properties.Resources.Battery_ACConnected;
                    else if (LifePercent > 85)
                        pcBatteryLifeDisplay.Image = Properties.Resources.Battery_High;
                    else if (LifePercent > 50)
                        pcBatteryLifeDisplay.Image = Properties.Resources.Battery_Medium;
                    else if (LifePercent > 25)
                        pcBatteryLifeDisplay.Image = Properties.Resources.Battery_Low;
                    else
                        pcBatteryLifeDisplay.Image = Properties.Resources.Battery_VeryLow;
                }
                else
                    pcBatteryLifeDisplay.Image = Properties.Resources.Battery_VeryLow;
            }
            catch(Exception e) { }
        }

        #endregion

        #region Backgroud Connection Check

        private static Thread InitializeConnection;
        private static bool IsThreadDone;

        private static void BackGroudConnectionCheck()
        {
            if (InitializeConnection == null || IsThreadDone)
            {
                InitializeConnection = null;
                InitializeConnection = new System.Threading.Thread(InitialConnection);
                InitializeConnection.Start();
            }
        }
        //Added for Assync Connection
        static void InitialConnection()
        {
            IsThreadDone = false;
            CommonFunctions.IsConnected(false);
            IsThreadDone = true;
        }

        #endregion

        // HandyAssemblyVersion.Major.ToString(), HandyAssemblyVersion.Minor.ToString(), HandyAssemblyVersion.Build.ToString(), HandyAssemblyVersion.Revision.ToString()));
        #region Application Build Checking
        
        //Version Variable
        private static string _AssemblyVersion;
        private static string _MajorVersion;
        private static string _MinorVersion;
        private static string _BuildVersion;
        private static string _RevisionVersion;

        #region Accessors

        public static string AssymblyVersion
        {
            get
            {
                _AssemblyVersion = string.Format("{0}.{1}.{2}.{3}", _MajorVersion.Trim(), _MinorVersion.Trim(), _BuildVersion.Trim(), _RevisionVersion.Trim());
                CommonFunctions.ApplicationVersion = _AssemblyVersion;
                return _AssemblyVersion;
            }
        }

        public static string MajorVersion
        {
            get
            {
                return _MajorVersion;
            }
            set
            {
                if (_MajorVersion == value)
                    return;
                _MajorVersion = value;
            }
        }

        public static string MinorVersion
        {
            get
            {
                return _MinorVersion;
            }
            set
            {
                if (_MinorVersion == value)
                    return;
                _MinorVersion = value;
            }
        }

        public static string BuilVersion
        {
            get
            {
                return _BuildVersion;
            }
            set
            {
                if(_BuildVersion == value)
                    return;
                _BuildVersion = value;
            }
        }

        public static string RevisionVersion
        {
            get
            {
                return _RevisionVersion;
            }
            set
            {
                if(_RevisionVersion == value)
                    return;
                _RevisionVersion = value;
            }
        }

        #endregion

        #endregion
    }
    public class Config
    {
        public void Dispose() { }
    }

    public class WLAN
    {
        public void Dispose() { }
    }

    public class Adapter
    {
        public delegate void SignalQualityHandler(object sender, StatusChangeArgs e);
        public SignalQualityHandler SignalQualityChanged;
    }

    public class StatusChangeArgs : EventArgs
    {
        public SignalQuality SignalQuality;
    }
    public enum SignalQuality
    {
        // Summary:
        //     No Signal
        NONE = 0,
        //
        // Summary:
        //     Poor Signal Quality
        POOR = 1,
        //
        // Summary:
        //     Fair Signal Quality
        FAIR = 2,
        //
        // Summary:
        //     Good Signal Quality
        GOOD = 3,
        //
        // Summary:
        //     Very Good Signal Quality
        VERYGOOD = 4,
        //
        // Summary:
        //     Excellent Signal Quality
        EXCELLENT = 5,
    }
}
