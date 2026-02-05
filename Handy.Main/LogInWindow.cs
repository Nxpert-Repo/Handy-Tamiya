using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Reflection;
using DataHelper;
using Handy.Lib;
using CEDataHelper;

namespace Handy
{
    public partial class LogInWindow : BaseWindow, IDisposable
    {
        #region Variables

        #endregion

        #region Constructor

        public LogInWindow(BarcodeReader BCReader, ReaderData BCData)
        {
            InitializeComponent();
            base.SetBarcodeReader(BCReader, BCData);
            CommonInterfaceFunctions.SetBatteryLifeInterface(this.pcbLogInBaterryLife);
            //base.SetWindowTitle("Coil Defragging");
            base.SetActiveButtons(BaseButtons.Login, BaseButtons.Cancel);
            CommonInterfaceFunctions.WLANAddSignalQualityHandler(this.pcbLoginSignal, true);
        }

        #endregion

        #region Functions

        private void SetGenericDisplay()
        {
            this.lblTerminalNumber.BackColor = Color.WhiteSmoke;
            this.lblTermalBorder.BackColor = Color.DarkCyan;
            this.NotifyUser.BackColor = Color.DarkRed;
            this.StatusBackground.BackColor = Color.DarkRed;            
        }

        private void GetCompanyInfoText()
        {
            string[] param = new string[7];
            param = Logger.GetTextData(Logger.HandyPath, Logger.HandyCompanyInfoFile, param, false, true, false, '|');
            if (param != null)
            {
                if (Handy.Properties.Resources.Version != param[6])
                {
                    lblHandyVersion.ForeColor = Color.Red;
                    lblHandyVersion.Text = "Version : " + Handy.Properties.Resources.Version + "  " + "Build : " + CommonInterfaceFunctions.AssymblyVersion;

                }
                else
                {
                    lblHandyVersion.BackColor = Color.Transparent;
                    lblHandyVersion.Text = "Version : " + Handy.Properties.Resources.Version + "  " + "Build : " + CommonInterfaceFunctions.AssymblyVersion;
                }
            }

            this.NotifyUser.Text = ((Logger.isFileExist(Logger.HandyPath, Logger.HandyCompanyInfoFile)) 
                ? ((Logger.isFileExist(Logger.HandyPath, Logger.HandyUSERFile)) 
                ? "" : Handy.Properties.Resources.DownloadUserFile) : Handy.Properties.Resources.DownloadCompanyInfo);
            param = null; //releasing
        }

        public bool IsAppConfigExist()
        {
            bool ret = false;
            string appPath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            string configFile = System.IO.Path.Combine(appPath, "App.config");
            string configFileBak = System.IO.Path.Combine(appPath, "App.bak.config");
            string[] param = new string[1];
            param[0] = Handy.Properties.Resources.App_bak_config;
            if (!System.IO.File.Exists(configFile))
            {
                if (System.IO.File.Exists(configFileBak))
                {
                    System.IO.File.Move(configFileBak, configFile);
                }
                else
                {
                    Logger.WriteTextData(appPath, "App.config", param, false, false);
                }
            }
            appPath = null; //releasing
            configFile = null; //releasing
            configFileBak = null; //releasing
            param = null; // releasing
            return ret;
        }

        private void tmr_Tick(object sender, EventArgs e)
        {            
            lblTerminalNumber.Text = (CommonFunctions.ConvertStringDecimal(lblTerminalNumber.Text) - 1).ToString();
            Point p = pcbLogInBaterryLife.Location;
            pcbLogInBaterryLife.Location = pcbLoginSignal.Location;
            pcbLoginSignal.Location = p;
            pcbLoginSignal.Image = CommonFunctions.pbSignalStatus.Image;
        }        

        private void GetAssymbleVersion()
        {
            Version HandyAssemblyVersion = Assembly.GetExecutingAssembly().GetName().Version;
            CommonInterfaceFunctions.MajorVersion = HandyAssemblyVersion.Major.ToString();
            CommonInterfaceFunctions.MinorVersion = HandyAssemblyVersion.Minor.ToString();
            CommonInterfaceFunctions.BuilVersion = HandyAssemblyVersion.Build.ToString();
            CommonInterfaceFunctions.RevisionVersion = HandyAssemblyVersion.Revision.ToString();
        }

        #endregion

        #region Overrides

        protected override void BaseWindow_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1: // Keyence
                case Keys.F14:
                    this.LogInButton_Click(this, e);
                    break;
                case Keys.F4: // Keyence
                case Keys.F15:
                    this.DialogResult = DialogResult.Abort;
                    break;
                case Keys.Back: // Keyence
                case Keys.F7:
                    {
                        this.NotifyUser.Text = "";
                    }
                    break;
                case Keys.Down:
                    {
                        this.PINText.Focus();
                        this.PINText.SelectAll();
                    }
                    break;
                case Keys.Up:
                    {
                        this.UserIDText.Focus();
                        this.UserIDText.SelectAll();
                    }
                    break;
                case Keys.Enter:
                    {
                        NotifyUser.Text = Handy.Properties.Resources.Downloading;
                        CommonFunctions.DownloadUser();                        
                        this.GetCompanyInfoText();
                    }
                    break;
            }

            base.BaseWindow_KeyUp(sender, e);
        }

        protected override void lblBtnRight_Click(object sender, EventArgs e)
        {
            KeyEventArgs KeyArgs = new KeyEventArgs(Keys.F15);
            this.BaseWindow_KeyUp(sender, KeyArgs);
        }

        protected override void lblBtnLeft_Click(object sender, EventArgs e)
        {
            KeyEventArgs KeyArgs = new KeyEventArgs(Keys.F14);
            this.BaseWindow_KeyUp(sender, KeyArgs);
        }

        protected override void BarcodeReader_AnalyzeType(object Sender, EventArgs e)
        {
            base.GetRawBarcodeValue = true;

            base.BarcodeReader_AnalyzeType(Sender, e);

            if (base.BarcodeValue == null)
            {
                //Do nothing
            }
            else
            {
                UserIDText.Text = base.BarcodeTextData;
                PINText.Text = CommonFunctions.GetUserPIN(base.BarcodeTextData);
                NotifyUser.Text = "";
                PINText.Focus();
                PINText.SelectAll();
            }

            base.BarcodeValue = null;
            base.GetRawBarcodeValue = false;
        }

        #endregion

        private void LogInForm_Load(object sender, EventArgs e)
        {
            this.SetGenericDisplay();
            this.IsAppConfigExist();


            CESQLDataHelper DBCe = new CESQLDataHelper();   
            CommonFunctions.CreateMobileDatabase();

            CommonFunctions.HandyInstalledPath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            this.GetAssymbleVersion();
            //Get Handy Info
            if (!Logger.isFileExist(Logger.HandyPath, Logger.HandyInfoFile))
            {
                CommonFunctions.GenerateHandyInfo("0");
            }
            string[] HandyInfo = new string[3];
            HandyInfo = CommonFunctions.HandyInfo;
            lblTerminalNumber.Text = HandyInfo[0];
            //
            GetCompanyInfoText();
            //Nilo Added 09282012 for license reistriction
            CommonFunctions.HandyNo = HandyInfo[0];
            CommonFunctions.HandySerialNo = CommonFunctions.SerialNumber;
            CommonFunctions.HandyIPAddress = CommonFunctions.HandyIPAddress;
            CommonFunctions.HandyModel = Handy.Lib.Resource.ProductModel;
            CommonFunctions.HandyStatus = "A";
            this.UserIDText.Focus();
            base.BarcodeReader_Start();
            HandyInfo = null; //releasing

            lblTerminalNumber.Text = "999";
            tmr.Interval = 1000;
            tmr.Enabled = true; 
        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            
            switch (CommonFunctions.VerifyUser(UserIDText.Text.Trim(), PINText.Text.Trim(), false))
            {
                case CommonEnum.Result.Retry:
                    {
                        this.PINText.Text = string.Empty;
                        this.UserIDText.Focus();
                        this.UserIDText.SelectAll();
                        this.NotifyUser.Text = Handy.Properties.Resources.Retry;
                    }
                    break;
                case CommonEnum.Result.EnterUser:
                    {
                        this.NotifyUser.Text = Handy.Properties.Resources.EnterID;
                        this.UserIDText.Focus();
                    }
                    break;
                case CommonEnum.Result.EnterPIN:
                    {
                        this.PINText.Focus();
                        this.NotifyUser.Text = Handy.Properties.Resources.EnterPIN;
                    }
                    break;
                case CommonEnum.Result.ServerNotFound:
                    {
                        this.UserIDText.Focus();
                        this.NotifyUser.Text = Handy.Properties.Resources.ServerNotFound;
                    }
                    break;
                case CommonEnum.Result.OK:
                    {
                        CommonFunctions.Username = UserIDText.Text;
                        this.Close();
                    }
                    break;
                case CommonEnum.Result.InvalidPIN:
                    {
                        this.NotifyUser.Text = Handy.Properties.Resources.InvalidPIN;
                        this.PINText.Focus();
                        this.PINText.SelectAll();
                    }
                    break;
                case CommonEnum.Result.InvalidUser:
                default:
                    {
                        this.NotifyUser.Text = Handy.Properties.Resources.InvalidUser;
                        this.PINText.Text = "";
                        this.UserIDText.Focus();
                        this.UserIDText.SelectAll();
                    }
                    break;
            }
                
        }

        private void UserIDText_TextChanged(object sender, EventArgs e)
        {
            NotifyUser.Text = "";
        }

        private void PINText_TextChanged(object sender, EventArgs e)
        {
            NotifyUser.Text = "";
        }

        private void NotifyUser_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(NotifyUser.Text))
            {
                this.NotifyUser.Visible = true;
                this.StatusBackground.Visible = true;
            }
            else
            {
                this.NotifyUser.Visible = false;
                this.StatusBackground.Visible = false;
            }
        }        
    }
}
