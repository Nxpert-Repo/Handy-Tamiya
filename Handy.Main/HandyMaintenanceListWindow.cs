using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Handy.Lib;
using System.IO;
using System.Reflection;

namespace Handy
{
    public partial class HandyMaintenanceListWindow : BaseWindow
    {
        #region Variables
        
        public CommonEnum.Buttons ExitButton = CommonEnum.Buttons.Exit;
        private string CurrentWindow = string.Empty;
        private TextBox focusedTextbox = null;

        #endregion Variables
        
        #region Constructor

        public HandyMaintenanceListWindow(string _Process)
        {
            InitializeComponent();
            CommonInterfaceFunctions.WLANAddSignalQualityHandler(base.pcbSignal, true);
            this.CurrentWindow = _Process;
        }

        #endregion Constructor

        #region Functions

        private void SetWindow()
        {
            if (CurrentWindow.Equals(CommonEnum.GetStringValue(CommonEnum.MaintenanceProcess.DatabaseSettings), StringComparison.CurrentCultureIgnoreCase))
            {
                TabMaintence.SelectedIndex = 0;
                MaintenanceBase.ListTextControls(this.TabMaintence.TabPages[1].Controls);
                MaintenanceBase.SetDatabaseStringInstances();
                this.txtDataSource.Text = MaintenanceBase.strDatasource;
                this.txtDatabase.Text = MaintenanceBase.strDatabase;
                this.txtUser.Text = MaintenanceBase.strDBUser;
                this.txtPassword.Text = "**********"; //Hiding Password// CommonFunctions.strDBPassword;
                this.txtDataSource.Focus();
                base.SetWindowTitle("Database Settings");
                base.SetActiveButtons(BaseButtons.Save, BaseButtons.Cancel);
            }
            else if (CurrentWindow.Equals(CommonEnum.GetStringValue(CommonEnum.MaintenanceProcess.HostName), StringComparison.CurrentCultureIgnoreCase))
            {
                TabMaintence.SelectedIndex = 1;
                MaintenanceBase.ListTextControls(this.TabMaintence.TabPages[2].Controls);
                string[] param = new string[4];
                Logger.GetTextData(Logger.HandyPath, Logger.HandyHostFile, param);
                if(param!=null)
                {
                    if(param.Length>=4)
                    {
                        txtHostName.Text = param[0];
                        txtIP.Text = param[1];
                    }
                }
                txtHostName.Focus();
                base.SetWindowTitle("Host Name");
                base.SetActiveButtons(BaseButtons.Save, BaseButtons.Cancel);
            }
            else if (CurrentWindow.Equals(CommonEnum.GetStringValue(CommonEnum.MaintenanceProcess.HandyInfo), StringComparison.CurrentCultureIgnoreCase))
            {
                TabMaintence.SelectedIndex = 2;

                string[] HandyInfo = new string[3];
                HandyInfo = CommonFunctions.HandyInfo;

                Version HandyAssemblyVersion = Assembly.GetExecutingAssembly().GetName().Version;

                txtTerminalNumber.Text = HandyInfo[0];
                lblModel.Text = HandyInfo[1];
                lblSerialNumber.Text = HandyInfo[2];
                lblBuildNumber.Text = string.Format("{0}.{1}.{2}.{3}", HandyAssemblyVersion.Major.ToString(), HandyAssemblyVersion.Minor.ToString(), HandyAssemblyVersion.Build.ToString(), HandyAssemblyVersion.Revision.ToString());
                //lblBuildNumber.Text = "v" + Handy.Properties.Resources.Version + " Build " + Handy.Properties.Resources.Build;
                this.panelSpecialChar.Visible = false;
                base.SetWindowTitle("Handy Info");
                base.SetActiveButtons(BaseButtons.Save, BaseButtons.Cancel);
            }
            else if (CurrentWindow.Equals(CommonEnum.GetStringValue(CommonEnum.MaintenanceProcess.FTP), StringComparison.CurrentCultureIgnoreCase))
            {
                TabMaintence.SelectedIndex = 3;
                string[] param = new string[3];
                Logger.GetTextData(Logger.HandyPath, Logger.HandyFTPSettingFile, param);
                if (param != null)
                {
                    if (param.Length >= 1)
                    {
                        this.txtFTPSERVER.Text = param[0];
                        this.txtFTPUSER.Text = param[1];
                        CommonFunctions.strFTPPassword = param[2];
                        this.txtFTPPASS.Text = "**********";
                    }
                }
                this.txtFTPSERVER.Focus();
                this.panelSpecialChar.Visible = true;
                base.SetWindowTitle("FTP Settings");
                base.SetActiveButtons(BaseButtons.Save, BaseButtons.Cancel);
            }
            else if (CurrentWindow.Equals(CommonEnum.GetStringValue(CommonEnum.MaintenanceProcess.LogFiles), StringComparison.CurrentCultureIgnoreCase))
            {
                this.TabMaintence.SelectedIndex = 4;
                #region commented code
                /***THI Code
                //Text File
                //this.lblTagFileSize.Text = Logger.GetTextFileSize(Logger.HandyPath, Logger.HandyTaggingFile);
                //this.lblMovementFileSize.Text = Logger.GetTextFileSize(Logger.HandyPath, Logger.HandyMovementFile);
                //this.lblMITFileSize.Text = Logger.GetTextFileSize(Logger.HandyPath, Logger.HandyMITFile);
                //this.lblArchivedFileSize.Text = Logger.GetDirectorySize(Logger.HandyArchivedPath, "KB");
                //DB File
                //int DBCount = 0;
                //if (LocatorTaggingBase.TaggingMobileDBList() != null) //20130405 Allen Modify: change CommonFunctions.TaggingMobileDBList() to LocatorTaggingBase.TaggingMobileDBList()
                //    DBCount = LocatorTaggingBase.TaggingMobileDBList().Rows.Count;  //20130405 Allen Modify: change CommonFunctions.TaggingMobileDBList() to LocatorTaggingBase.TaggingMobileDBList()
                //this.lblDBTagRecord.Text = DBCount.ToString();
                //if (LocatorTaggingBase.TaggingMobileDBList() != null)  //20130405 Allen Modify: change CommonFunctions.TaggingMobileDBList() to LocatorTaggingBase.TaggingMobileDBList()
                    //DBCount = InventoryBase.MobileInventoryDisplayList(CommonEnum.UploadStats.All).Rows.Count; //20130405 Allen Modify: change CommonFunctions.MITMobileDBList() to InventoryBase.MITMobileDBList()
                //this.lblDBInvRecord.Text = DBCount.ToString();
                //if (StockMovementBase.StockMovementMobileDBList() != null) //20130405 Allen Modify: change CommonFunctions.StockMovementMobileDBList() to StockMovementBase.StockMovementMobileDBList()
                //    DBCount = StockMovementBase.StockMovementMobileDBList().Rows.Count; //20130405 Allen Modify: change CommonFunctions.StockMovementMobileDBList() to StockMovementBase.StockMovementMobileDBList()
                //this.lblDBMovedRecord.Text = DBCount.ToString();
                 ****/
                #endregion
                this.SetInventoryCountDisplay();
                this.optInventory.Focus();
                this.panelSpecialChar.Visible = false;
                base.SetWindowTitle("Log Files");
                base.SetActiveButtons(BaseButtons.Clear, BaseButtons.Cancel);
            }
            
        }

        private void SetInventoryCountDisplay()
        {
            int[] Counts = new int[3];
            Counts = InventoryBase.ListCount(CommonEnum.Function.Inventory);
            this.lblDBInvRecord.Text = string.Format("{0}", Counts[0] + Counts[1]);
            //Releasing
            Counts = null;
        }

        private void SelectButton(object sender, EventArgs e)
        {
            if (CurrentWindow.Equals(CommonEnum.GetStringValue(CommonEnum.MaintenanceProcess.DatabaseSettings), StringComparison.CurrentCultureIgnoreCase))
            {
                if (isInputValid())
                    this.UpdateConfigurations();
            }
            else if (CurrentWindow.Equals(CommonEnum.GetStringValue(CommonEnum.MaintenanceProcess.HostName), StringComparison.CurrentCultureIgnoreCase))
            {
                this.UpdateHostName();
            }
            else if (CurrentWindow.Equals(CommonEnum.GetStringValue(CommonEnum.MaintenanceProcess.HandyInfo), StringComparison.CurrentCultureIgnoreCase))
            {
                this.UpdateHandyInfo();
            }
            else if (CurrentWindow.Equals(CommonEnum.GetStringValue(CommonEnum.MaintenanceProcess.FTP), StringComparison.CurrentCultureIgnoreCase))
            {
                if (string.IsNullOrEmpty(this.txtFTPSERVER.Text.Trim()) || string.IsNullOrEmpty(this.txtFTPUSER.Text.Trim()) || string.IsNullOrEmpty(this.txtFTPPASS.Text.Trim()))
                {
                    CommonFunctions.MessageShow(CommonMsg.Error.d_AllfieldsRequired, CommonEnum.NotificationType.Warning);
                    return;
                }
                //Start Updating
                this.UpdateFTPSettings();
            }
            else if (CurrentWindow.Equals(CommonEnum.GetStringValue(CommonEnum.MaintenanceProcess.LogFiles), StringComparison.CurrentCultureIgnoreCase))
            {
                if (this.ClearLogFile())
                {
                    CommonFunctions.MessageShow(CommonMsg.Success.d_S, CommonEnum.NotificationType.Success);
                }
            }
        }

        private void CancelButton(object sender, EventArgs e)
        {
            if (ExitButton == CommonEnum.Buttons.Cancel)
            {
                ExitButton = CommonEnum.Buttons.Exit;
            }
            else
                Close();
        }

        private void FocusControl(CommonEnum.TextFocus Focus)
        {
            if (CurrentWindow.Equals(CommonEnum.GetStringValue(CommonEnum.MaintenanceProcess.DatabaseSettings), StringComparison.CurrentCultureIgnoreCase))
            {
                MaintenanceBase.FocusTextControl(Focus);
            }
            else if(CurrentWindow.Equals(CommonEnum.GetStringValue(CommonEnum.MaintenanceProcess.HostName), StringComparison.CurrentCultureIgnoreCase))
            {
                MaintenanceBase.FocusTextControl(Focus);
            }

        }

        private bool UpdateConfigurations()
        {
            bool ret = false;

            string appPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            string configFile = Path.Combine(appPath, "App.config");
            string configFileBak = Path.Combine(appPath, "App.bak.config");
            string configFileBak2 = Path.Combine(appPath, "App.Bak.config");
            string[] param = new string[1];
            param[0] = string.Format(Handy.Properties.Resources.App_config, txtDataSource.Text.Trim(), txtDatabase.Text.Trim(), txtUser.Text.Trim(), txtPassword.Text.Trim().StartsWith("***") ? MaintenanceBase.strDBPassword : txtPassword.Text.Trim());
            if (System.IO.File.Exists(configFile))
            {
                if (File.Exists(configFileBak))
                    File.Delete(configFileBak);
                else if (File.Exists(configFileBak2))
                    File.Delete(configFileBak2);
                System.IO.File.Move(configFile, configFileBak);
                ret = Logger.WriteTextData(appPath, "App.config", param, false, false);
            }
            if (ret)
                CommonFunctions.MessageShow(CommonMsg.Success.d_SystemConfig, CommonEnum.NotificationType.Success);
            else
                CommonFunctions.MessageShow(CommonMsg.Error.d_SystemConfig, CommonEnum.NotificationType.Error);
            return ret;
        }

        private bool UpdateHostName()
        {
            if (string.IsNullOrEmpty(txtHostName.Text.Trim()) && string.IsNullOrEmpty(txtIP.Text.Trim()))
            {
                CommonFunctions.MessageShow(CommonMsg.Error.d_AllfieldsRequired, CommonEnum.NotificationType.Warning);
                return false;
            }

            MaintenanceBase.strHostName = txtHostName.Text;
            MaintenanceBase.strIP = txtIP.Text;

            if (MaintenanceBase.AddRegKey())
            { 
                CommonFunctions.MessageShow(CommonMsg.Success.d_SetRegistryKey, CommonEnum.NotificationType.Success);
                return true;
            }
            else
            {
                CommonFunctions.MessageShow(CommonMsg.Error.d_SetRegistryKey, CommonEnum.NotificationType.Error);
                return false;
            }
        }

        private void UpdateHandyInfo()
        {
            CommonFunctions.HandyNo = txtTerminalNumber.Text;
            CommonFunctions.GenerateHandyInfo(txtTerminalNumber.Text);
            CommonFunctions.MessageShow(string.Format(CommonMsg.Success.d_TerminalNumberUpdate, txtTerminalNumber.Text), CommonEnum.NotificationType.Success);
        }

        private bool UpdateFTPSettings()
        {
            TextParameterInfo[] TextParamInfo = new TextParameterInfo[3];
            TextParamInfo[0] = new TextParameterInfo("FTPSERVER", this.txtFTPSERVER.Text.Trim());
            TextParamInfo[1] = new TextParameterInfo("FTPUSER", this.txtFTPUSER.Text.Trim());
            TextParamInfo[2] = new TextParameterInfo("FTPPASSWORD", this.txtFTPPASS.Text.Trim().StartsWith("***") ? CommonFunctions.strFTPPassword : this.txtFTPPASS.Text.Trim());
            Logger.WriteTextData(Logger.HandyPath, Logger.HandyFTPSettingFile, TextParamInfo);
            if (this.ckFTPSEND.Checked)
            {
                try
                {
                    this.ProgressFTP.Visible = true;
                    CommonFunctions.PostProgress = this.ProgressFTP;
                    MaintenanceBase.FTPSendFiles(this.txtFTPSERVER.Text.Trim(), this.txtFTPUSER.Text.Trim(), this.txtFTPPASS.Text.Trim().StartsWith("***") ? CommonFunctions.strFTPPassword : this.txtFTPPASS.Text.Trim());
                }
                catch (Exception ex)
                {
                    CommonFunctions.MessageShow(ex.Message, CommonEnum.NotificationType.Warning);
                    SetWindow();
                    this.ProgressFTP.Visible = false;
                    return false;
                }
            }
            SetWindow();
            CommonFunctions.MessageShow(CommonMsg.Success.d_FTPProcess, CommonEnum.NotificationType.Information);
            this.ProgressFTP.Visible = false;
            return true;
        }

        private bool ClearLogFile()
        {
            bool ret = false;
            #region Commented Code
            ////if (optTag.Checked)
            ////{
            ////    if (DialogResult.Yes != CommonFunctions.MessageShow(string.Format(CommonMsg.Warning.d_QClearFile, "Tagging"), CommonEnum.NotificationType.Question, CommonEnum.MessageButtons.YesNo))
            ////        return false;
            ////    if (Logger.isFileExist(Logger.HandyPath, Logger.HandyTaggingFile))
            ////        ret = Logger.isFileCleared(Logger.HandyPath, Logger.HandyTaggingFile);
            ////    if (CommonFunctions.UseMobileDB)
            ////    {
            ////        ret = CommonFunctions.TaggingMobileDBClear("DELETE T_Tagging");
            ////    }
            ////    if (!ret)
            ////        CommonFunctions.MessageShow(CommonMsg.Error.d_TagFileClear, CommonEnum.NotificationType.Error);
            ////}
            ////else if (optMovement.Checked)
            ////{

            ////    if (DialogResult.Yes != CommonFunctions.MessageShow(string.Format(CommonMsg.Warning.d_QClearFile, "Movement"), CommonEnum.NotificationType.Question, CommonEnum.MessageButtons.YesNo))
            ////        return false;
            ////    if (Logger.isFileExist(Logger.HandyPath, Logger.HandyMovementFile))
            ////        ret = Logger.isFileCleared(Logger.HandyPath, Logger.HandyMovementFile);
            ////    if (CommonFunctions.UseMobileDB)
            ////    {
            ////        ret = StockMovementBase.StockMovementMobileDBListClear("DELETE T_Movement"); //20130412 Allen Modify: changing CommonFunction to StockMovementBase  
            ////    }
            ////    if (!ret)
            ////        CommonFunctions.MessageShow(CommonMsg.Error.d_MovementFileClear, CommonEnum.NotificationType.Error);
            ////}
            ////else if (optArchive.Checked)
            ////{

            ////    if (DialogResult.Yes != CommonFunctions.MessageShow(string.Format(CommonMsg.Warning.d_QClearFile, "Archived"), CommonEnum.NotificationType.Question, CommonEnum.MessageButtons.YesNo))
            ////        return false;
            ////    if (Logger.isDirectoryExist(Logger.HandyArchivedPath))
            ////        ret = Logger.isDirectoryCleared(Logger.HandyArchivedPath);
            ////    if (!ret)
            ////        CommonFunctions.MessageShow(CommonMsg.Error.d_ArchiveFileClear, CommonEnum.NotificationType.Error);
            ////}
            #endregion
            if (optInventory.Checked)
            {
                if (DialogResult.Yes != CommonFunctions.MessageShow(string.Format(CommonMsg.Warning.d_QClearFile, "Inventory"), CommonEnum.NotificationType.Question, CommonEnum.MessageButtons.YesNo))
                    return false;
                if (Logger.isFileExist(Logger.HandyPath, Logger.HandyMITFile))
                    ret = Logger.isFileCleared(Logger.HandyPath, Logger.HandyMITFile);
                if (CommonFunctions.UseMobileDB)
                {
                    ret = CommonFunctions.MITMobileDBListClear(CommonQueryStrings.Mobile.Delete.T_Inventory); //20130418 Allen Transferred query to CommonQueryString Class
                }
                if (!ret)
                    CommonFunctions.MessageShow(CommonMsg.Error.d_MITFileClear, CommonEnum.NotificationType.Error);
                    
            }
            SetWindow();
            return ret;
        }

        #endregion Functions

        #region Overrides

        protected override void BaseWindow_KeyUp(object sender, KeyEventArgs e)
        { switch (e.KeyCode)
            {
                case Keys.F1:
                case Keys.F14:
                    {
                        SelectButton(this, e);
                        ExitButton = CommonEnum.Buttons.Exit;
                        CancelButton(this, e);
                    }
                    break;
                case Keys.F4:
                case Keys.F15:
                    CancelButton(this, e);
                    break;
                case Keys.Up:
                    FocusControl(CommonEnum.TextFocus.Previous);
                    break;
                case Keys.Down:
                    FocusControl(CommonEnum.TextFocus.Next);
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

        #endregion

        #region Validations

        private bool isInputValid()
        {
            if (string.IsNullOrEmpty(txtDataSource.Text))
            {
                CommonFunctions.MessageShow(CommonMsg.Warning.d_NoDataSource, CommonEnum.NotificationType.Warning);
                return false;
            }
            else if (string.IsNullOrEmpty(txtDatabase.Text))
            {
                CommonFunctions.MessageShow(CommonMsg.Warning.d_NoDatabase, CommonEnum.NotificationType.Warning);
                return false;
            }
            else if (string.IsNullOrEmpty(txtUser.Text))
            {
                CommonFunctions.MessageShow(CommonMsg.Warning.d_NoUser, CommonEnum.NotificationType.Warning);
                return false;
            }
            else if (string.IsNullOrEmpty(txtPassword.Text))
            {
                CommonFunctions.MessageShow(CommonMsg.Warning.d_NoPassword, CommonEnum.NotificationType.Warning);
                return false;
            }
            else
                return true;

        }

        #endregion Validations

        #region Events

        #region TextFocus

        private void txtDataSource_GotFocus(object sender, EventArgs e)
        {
            focusedTextbox = txtDataSource;
        }

        private void txtDatabase_GotFocus(object sender, EventArgs e)
        {
            focusedTextbox = txtDatabase;
        }

        private void txtUser_GotFocus(object sender, EventArgs e)
        {
            focusedTextbox = txtUser;
        }

        private void txtPassword_GotFocus(object sender, EventArgs e)
        {
            focusedTextbox = txtPassword;
        }

        private void txtHostName_GotFocus(object sender, EventArgs e)
        {
            focusedTextbox = txtHostName;
        }

        private void txtIP_GotFocus(object sender, EventArgs e)
        {
            focusedTextbox = txtIP;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            focusedTextbox.Focus();
            focusedTextbox.Text += "(";
        }

        private void btnExclamation_Click(object sender, EventArgs e)
        {
            focusedTextbox.Focus();
            focusedTextbox.Text += "!";
        }

        private void btnAt_Click(object sender, EventArgs e)
        {
            focusedTextbox.Focus();
            focusedTextbox.Text += "@";
        }

        private void btnSharp_Click(object sender, EventArgs e)
        {
            focusedTextbox.Focus();
            focusedTextbox.Text += "#";
        }

        private void btnDollar_Click(object sender, EventArgs e)
        {
            focusedTextbox.Focus();
            focusedTextbox.Text += "$";
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            focusedTextbox.Focus();
            focusedTextbox.Text += "%";
        }

        private void btnAmpersand_Click(object sender, EventArgs e)
        {
            focusedTextbox.Focus();
            focusedTextbox.Text += "&";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            focusedTextbox.Focus();
            focusedTextbox.Text += ")";
        }

        private void btnUnderscore_Click(object sender, EventArgs e)
        {
            focusedTextbox.Focus();
            focusedTextbox.Text += "_";
        }

        private void btnDash_Click(object sender, EventArgs e)
        {
            focusedTextbox.Focus();
            focusedTextbox.Text += "-";
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            focusedTextbox.Focus();
            focusedTextbox.Text += "+";
        }

        private void btnQuestion_Click(object sender, EventArgs e)
        {
            focusedTextbox.Focus();
            focusedTextbox.Text += "?";
        }

        private void btnSlash_Click(object sender, EventArgs e)
        {
            focusedTextbox.Focus();
            focusedTextbox.Text += @"\";
        }

        private void btnBackSlash_Click(object sender, EventArgs e)
        {
            focusedTextbox.Focus();
            focusedTextbox.Text += "/";
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            focusedTextbox.Focus();
            focusedTextbox.Text += "=";
        }

        #endregion TextFocus

        private void txtTerminalNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            //accepts only number
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b')
                e.Handled = false;
            else
                e.Handled = true;
        }

        #endregion Events

        private void HandyMaintenanceListWindow_Load(object sender, EventArgs e)
        {
            this.SetWindow();
        }

    }
}