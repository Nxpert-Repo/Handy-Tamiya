using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using Handy.Lib;

namespace Handy
{
    public partial class InventoryGenerationWindow : BaseWindow
    {
        #region Variables

        private Int32 Counts = 0;
        private DataTable dtlocalMachineryList = new DataTable();
        private DataTable dtDisplaySelected = new DataTable();
        private CommonEnum.Warehouse WarehouseSelected;
        private CommonEnum.InventoryGenerationDisplay InventoryGenerationDisplay;
        private ActivateWindow ActivatedWindow = ActivateWindow.Generate;
        private enum ActivateWindow
        {
            Save,
            Generate,
            Renew,
            Ok,
            View,
            List,
            StockSelection,
            Login
        }

        #endregion

        #region Constructor

        public InventoryGenerationWindow()
        {            
            InitializeComponent();
            //base.SetBarcodeReader(BCReader, BCData);
            base.SetWindowTitle("Inventory Generation");
            base.SetActiveButtons(BaseButtons.List, BaseButtons.Cancel);       
            CommonInterfaceFunctions.WLANAddSignalQualityHandler(base.pcbSignal, true);
        }

        #endregion

        #region Overrides

        protected override void BaseWindow_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.F1:
                    case Keys.F14:
                        if (ActivatedWindow == ActivateWindow.Generate)
                            this.Generate(this, e);
                        else if (this.ActivatedWindow == ActivateWindow.Renew || this.ActivatedWindow == ActivateWindow.StockSelection)
                            this.Renew(this, e);
                        else if (this.ActivatedWindow == ActivateWindow.Login)
                            this.LogInButton_Click(this, e);
                        break;
                    case Keys.F4:
                    case Keys.F15:
                        this.CancelButton(this, e);
                        break;

                    case Keys.Down:
                        if (panelRenewLogIn.Visible == true)
                        {
                            this.PINText.Focus();
                            this.PINText.SelectAll();
                        }
                        else if (panelMachineryListView.Visible == true)
                        {
                            listView1.Focus();
                        }
                        break;

                    case Keys.Up:
                        if (panelRenewLogIn.Visible == true)
                        {
                            this.UserIDText.Focus();
                            this.UserIDText.SelectAll();
                        }
                        else if (panelMachineryListView.Visible == true)
                        {
                            listView1.Focus();
                        }
                        break;

                    case Keys.D1:
                        if (panelMachineryListView.Visible == true)
                        {
                            this.GetSelectedRow();
                            listView1.Focus();
                        }
                        break;
                }
            }
            catch (Exception Err)
            {
                CommonFunctions.MessageShow(Err.Message, CommonEnum.NotificationType.Error);
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

        #region Functions

        #region Display

        private void SetWindowActivatedButton()
        {
            try
            {
                switch (this.ActivatedWindow)
                {
                    case ActivateWindow.Generate:
                        {
                            this.SetGenerationPanelPosition(true);
                            base.SetActiveButtons(BaseButtons.Generate, BaseButtons.Cancel);
                            break;
                        }
                    case ActivateWindow.Renew:
                        {
                            this.SetGenerationPanelPosition(true);
                            base.SetActiveButtons(BaseButtons.Renew, BaseButtons.Cancel);
                            break;
                        }
                    case ActivateWindow.StockSelection:
                        {
                            base.SetActiveButtons(BaseButtons.Renew, BaseButtons.Cancel);
                            break;
                        }
                    case ActivateWindow.Login:
                        {
                            base.SetActiveButtons(BaseButtons.Ok, BaseButtons.Cancel);
                            break;
                        }
                }
            }
            catch (Exception Err)
            {
                CommonFunctions.MessageShow(Err.Message, CommonEnum.NotificationType.Error);
            }
        }

        private void SetSelectedStockTypeOptionButtons()
        {
            try
            {
                //if (CommonFunctions.GeneratedWarehouse == CommonEnum.Warehouse.DefaultWarehouse)
                //{
                //     this.rdoWH1.Checked = true;
                //     this.rdoWH1.Focus();
                //    rdoWFR.Checked = false;
                //    rdoIPM.Checked = false;
                //    rdoPS1.Checked = false;
                //    rdoPS2.Checked = false;
                //}
                //else if (CommonFunctions.GeneratedWarehouse == CommonEnum.Warehouse.WaferRoom)
                //{
                //    this.rdoWH1.Checked = false;
                //    this.rdoWFR.Focus();
                //    rdoWFR.Checked = true;
                //    rdoIPM.Checked = false;
                //    rdoPS1.Checked = false;
                //    rdoPS2.Checked = false;
                //}
                //else if (CommonFunctions.GeneratedWarehouse == CommonEnum.Warehouse.IPMPSENMaterial)
                //{
                //    this.rdoWH1.Checked = false;
                //    rdoWFR.Checked = false;
                //    rdoIPM.Checked = true;
                //    this.rdoIPM.Focus();
                //    rdoPS1.Checked = false;
                //    rdoPS2.Checked = false;
                //}
                //else if (CommonFunctions.GeneratedWarehouse == CommonEnum.Warehouse.ProductionFactory1)
                //{
                //    this.rdoWH1.Checked = false;
                //    rdoWFR.Checked = false;
                //    rdoIPM.Checked = false;
                //    rdoPS1.Checked = true;
                //    this.rdoPS1.Focus();
                //    rdoPS2.Checked = false;
                //}
                //else if (CommonFunctions.GeneratedWarehouse == CommonEnum.Warehouse.ProductionFactory2)
                //{
                //    this.rdoWH1.Checked = false;
                //    rdoWFR.Checked = false;
                //    rdoIPM.Checked = false;
                //    rdoPS1.Checked = false;
                //    rdoPS2.Checked = true;
                //    this.rdoPS2.Focus();
                //}
            
            }
            catch (Exception Err)
            {
                CommonFunctions.MessageShow(Err.Message, CommonEnum.NotificationType.Error);
            }
        }

        private void DisplayGeneratedInventoryStockType()
        {
            try
            {
                
                this.DisplayGeneratedDetails();

                if (CommonFunctions.InventoryMaster == null)
                {
                    this.ActivatedWindow = ActivateWindow.Generate;
                }
                else
                {
                    this.ActivatedWindow = ActivateWindow.Renew;
                }

                this.SetWindowActivatedButton();
            }
            catch (Exception Err)
            {
                CommonFunctions.MessageShow(Err.Message, CommonEnum.NotificationType.Error);
            }
        }

        private void DisplayGeneratedDetails()
        {
            DisplayGeneratedDetails(false);
        }

        private void DisplayGeneratedDetails(bool Failed)
        {
            try
            {
                //this.lblWGenerated.Text = String.Format("Gen. Warehouse : {0}", (Failed) ? "" : InventoryBase.GetWarehouseString());
                this.lblWGenerated.Text = String.Format("Gen. Warehouse : {0}", (Failed) ? "" : comboBox1.SelectedItem.ToString().Substring(1, 3));
                this.lblDateGenerated.Text = String.Format("Date Generated : {0}", (Failed) ? "" : CommonFunctions.GeneratedDate);
                this.lblGeneratedby.Text = String.Format("Generated By : {0}", (Failed) ? "" : CommonFunctions.GeneratedBy);
                this.lblRows.Text = String.Format("Row(s) : {0}", (Failed) ? 0 : CommonFunctions.GeneratedRowCnt);
                this.labelnote.Visible = true;
            }
            catch (Exception Err)
            {
                CommonFunctions.MessageShow(Err.Message, CommonEnum.NotificationType.Error);
            }
        }

        #endregion

        #region Panel Position

        private void SetGenerationPanelPosition(bool IsVisible)
        {
            try
            {
                this.panelGenerationInfo.Location = new System.Drawing.Point(2, 37);
                this.panelGenerationInfo.Size = new System.Drawing.Size(313, 245);
                this.panelGenerationInfo.Visible = IsVisible;
                this.InventoryGenerationDisplay = CommonEnum.InventoryGenerationDisplay.panelGenerationInfo;
            }
            catch (Exception Err)
            {
                CommonFunctions.MessageShow(Err.Message, CommonEnum.NotificationType.Error);
            }
        }

     
        private void SetUserVerificationPosition(bool IsVisible)
        {
            try
            {
                this.panelRenewLogIn.Visible = IsVisible;
                this.UserIDText.Text = CommonFunctions.Username;
                this.PINText.Focus();
                this.panelRenewLogIn.Location = new System.Drawing.Point(0, 0);
                this.panelRenewLogIn.Size = new System.Drawing.Size(235, 200);
                this.labelverifyuser.Text = string.Format("Please verify user to reload inventory list");
                this.labelverifyuser.Visible = true;
                this.labelverifyuser.BringToFront();
                this.label1.Visible = this.comboBox1.Visible = false;
                this.InventoryGenerationDisplay = CommonEnum.InventoryGenerationDisplay.panelRenewLogIn;
            }
            catch (Exception Err)
            {
                CommonFunctions.MessageShow(Err.Message, CommonEnum.NotificationType.Error);
            }
        }

        #endregion

        #region Inventory Reference Generation

        private void Generate(object sender, EventArgs e)
        {
            #region Downloading Reference list
            this.GetSelectedWarehouseOptionButtons(); // DEV1521-FRANCIS SAYS "WA MANI GAMIT, SEE THE CODE"
            try
            {
                if (this.ActivatedWindow == ActivateWindow.Generate)
                {
                    this.Generate();
                }
                
                else if (this.ActivatedWindow == ActivateWindow.Renew)
                {
                    if (panelRenewLogIn.Visible == true)
                    {
                        this.WarehouseSelected = CommonEnum.Warehouse.StorageWarehouse;
                        CommonFunctions.GeneratedWarehouse = this.WarehouseSelected;
                    }
                    else
                    {
                       
                    }

                    
                    this.Generate();
                   

                }
            }
            catch (Exception Err)
            {
                CommonFunctions.MessageShow(Err.Message, CommonEnum.NotificationType.Error);
            }

            #endregion
        }
        private void GetSelectedWarehouseOptionButtons()
        {
            try
            {
                //if (rdoWH1.Checked)
                //{
                //    this.WarehouseSelected = CommonEnum.Warehouse.DefaultWarehouse;
                //}
                //else if (rdoWFR.Checked)
                //{
                //    this.WarehouseSelected = CommonEnum.Warehouse.WaferRoom;
                //}
                //else if (this.rdoIPM.Checked)
                //{
                //    this.WarehouseSelected = CommonEnum.Warehouse.IPMPSENMaterial;
                //}
                //else if (this.rdoPS1.Checked)
                //{
                //    this.WarehouseSelected = CommonEnum.Warehouse.ProductionFactory1;
                //}
                //else if (this.rdoPS2.Checked)
                //{
                //    this.WarehouseSelected = CommonEnum.Warehouse.ProductionFactory2;
                //}
                //else if (this.rbOldWh.Checked)
                //{
                //    this.WarehouseSelected = CommonEnum.Warehouse.StorageWarehouse;
                //}

                CommonFunctions.GeneratedWarehouse = this.WarehouseSelected;
            }
            catch (Exception Err)
            {
                CommonFunctions.MessageShow(Err.Message, CommonEnum.NotificationType.Error);
            }
        }

        private void Generate()
        {
            try
            {
                if (this.ActivatedWindow == ActivateWindow.Generate)
                {
                    if (DialogResult.No == CommonFunctions.MessageShow(CommonMsg.Info.InventoryGenerationInfo, CommonEnum.NotificationType.Question, CommonEnum.MessageButtons.YesNo))
                        return; //force exit
                }

                if (InventoryBase.MobiledbGenerateInventoryReferenceList(comboBox1.SelectedItem.ToString().Substring(1,3)))
                {
                    this.DisplayGeneratedInventoryStockType();
                }
                else
                {
                    if (CommonFunctions.InventoryMaster == null)
                    {
                        CommonFunctions.MessageShow(CommonMsg.Warning.d_UnableGenMITMaster, CommonEnum.NotificationType.Warning);
                        this.DisplayGeneratedDetails(true);
                        this.ActivatedWindow = ActivateWindow.Generate;
                    }
                    else
                    {
                        CommonFunctions.MessageShow(CommonMsg.Warning.d_UnableRefreshMITMaster, CommonEnum.NotificationType.Warning);
                        this.ActivatedWindow = ActivateWindow.Renew;
                    }

                    this.SetWindowActivatedButton();
                    this.labelnote.Visible = true;
                    this.labelnote.BackColor = System.Drawing.Color.Teal;
                }

                this.SetSelectedStockTypeOptionButtons();

            }
            catch (Exception Err)
            {
                CommonFunctions.MessageShow(Err.Message, CommonEnum.NotificationType.Error);
            }
        }

        private void Renew(object sender, EventArgs e)
        {
            try
            {
                if (CommonFunctions.InventoryMaster != null)
                {
                    if (CommonFunctions.InventoryMaster.Rows.Count > 0)
                    {
                        
                            this.SetUserVerificationPosition(true);
                            this.ActivatedWindow = ActivateWindow.Login;
                        this.SetWindowActivatedButton();                        
                    }
                }
            }
            catch (Exception Err)
            {
                CommonFunctions.MessageShow(Err.Message, CommonEnum.NotificationType.Error);
            }
        }

        private void RenewMachineryStockCode(object sender, EventArgs e)
        {
            try
            {
                InventoryBase.ClearSelectedFromMachinery();
                this.ActivatedWindow = ActivateWindow.Renew;
                this.Generate(this, e);
                this.SetWindowActivatedButton();
            }
            catch (Exception Err)
            {
                CommonFunctions.MessageShow(Err.Message, CommonEnum.NotificationType.Error);
            }
        }

        private void UpdateSelectedStockInitialTable()
        {
            try
            {
                int ItemCount = listView1.Items.Count;
                if (ItemCount > 0)
                {
                    int i = 0;
                    foreach (ListViewItem Item in listView1.Items)
                    {
                        if (Item != null)
                        {
                            string Query = string.Format(CommonQueryStrings.Mobile.Update.T_StockCodeInitial, Item.Checked == true ? "1" : "0", Item.Text);
                            CommonFunctions.CeExecuteNonQuery(Query);
                        }
                        ++i;
                    }
                }
            }
            catch (Exception Err)
            {
                CommonFunctions.MessageShow(Err.Message, CommonEnum.NotificationType.Error);
            }
        }

        #endregion

        #region Generic Grid

        private void GetSelectedRow()
        {
            try
            {
                if (listView1.Items.Count > 0)
                {
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        if (listView1.Items[i].Selected == true)
                        {
                            string item = listView1.Items[i].SubItems[1].Text.Trim();
                            string selected = listView1.Items[i].Checked == false ? "1" : "0";
                            listView1.Items[i].Checked = selected == "1" ? true : false;
                            string Query = string.Format(CommonQueryStrings.Mobile.Update.T_StockCodeInitial, selected, item);
                            CommonFunctions.CeExecuteNonQuery(Query);
                        }
                    }
                }
            }
            catch (Exception Err)
            {
                CommonFunctions.MessageShow(Err.Message, CommonEnum.NotificationType.Error);
            }
        }


        #endregion

        private void CancelButton(object sender, EventArgs e)
        {
            try
            {
                if (panelGenerationInfo.Visible == true)
                {
                    if (this.ActivatedWindow == ActivateWindow.Generate)
                    {
                        if (this.InventoryGenerationDisplay == CommonEnum.InventoryGenerationDisplay.panelMachineryListView)
                        {
                            this.SetGenerationPanelPosition(true);
                            this.labelnote.Visible = true;
                            this.SetSelectedStockTypeOptionButtons();
                            this.ActivatedWindow = ActivateWindow.Generate;
                            this.SetWindowActivatedButton();
                        }
                        else
                        {
                            this.Close();
                        }
                    }
                    else if (this.ActivatedWindow == ActivateWindow.StockSelection)
                    {
                        if (this.InventoryGenerationDisplay == CommonEnum.InventoryGenerationDisplay.panelMachineryListView)
                        {
                            this.SetSelectedStockTypeOptionButtons();
                            this.ActivatedWindow = ActivateWindow.Renew;
                            this.SetWindowActivatedButton();
                        }
                    }
                    else if (this.ActivatedWindow == ActivateWindow.Renew)
                    {
                            this.labelverifyuser.SendToBack();
                            this.label1.Visible = this.comboBox1.Visible = true;
                            this.labelverifyuser.Visible = false;
                            this.comboBox1.Visible = true;
                            this.Close();
                    }

                    else if (this.ActivatedWindow == ActivateWindow.Login)
                    {
                         if (this.InventoryGenerationDisplay == CommonEnum.InventoryGenerationDisplay.panelRenewLogIn)// && (rdoWH1.Checked == true))
                        {
                            this.SetUserVerificationPosition(false);
                            this.SetGenerationPanelPosition(true);
                            this.NotifyUser.Visible = false;
                            this.labelnote.Visible = true;
                            this.PINText.Text = "";
                            this.SetSelectedStockTypeOptionButtons();
                            this.ActivatedWindow = ActivateWindow.Renew;
                            this.SetWindowActivatedButton();
                        }
                    }
                    this.Close();
                }
                else
                {
                    this.Close();
                }
            }
            catch (Exception Err)
            {
                CommonFunctions.MessageShow(Err.Message, CommonEnum.NotificationType.Error);
            }
        }

        #endregion

        //Events

        private void InventoryReferenceGeneration_Closing(object sender, CancelEventArgs e)
        {
            try
            {
                CommonFunctions.DisposeCommonObj();
            }
            catch (Exception Err)
            {
                CommonFunctions.MessageShow(Err.Message, CommonEnum.NotificationType.Error);
            }
        }

        private void InventoryReferenceGeneration_Load(object sender, EventArgs e)
        {
            try
            {
                if (CommonFunctions.InventoryMaster != null)
                {
                    if (CommonFunctions.InventoryMaster.Rows.Count > 0)
                    {
                        this.DisplayGeneratedDetails();
                        this.SetSelectedStockTypeOptionButtons();
                        this.ActivatedWindow = ActivateWindow.Renew;
                    }
                    else
                    {
                        this.ActivatedWindow = ActivateWindow.Generate;
                    }
                }
                else
                {
                   
                    InventoryBase.ClearSelectedFromMachinery();
                    this.ActivatedWindow = ActivateWindow.Generate;
                }
                DataTable dt = CommonFunctions.GetData(@"SELECT '[' + Wmt_WarehouseCode + '] ' + Wmt_WarehouseDesc
                                                                        FROM T_WarehouseMaster
                                                                       WHERE Wmt_Status = 'A'");
                
                foreach (DataRow row in dt.Rows)                
                    this.comboBox1.Items.Add(row[0]);
                comboBox1.SelectedIndex = 0;
                comboBox1.Focus();                

                this.SetWindowActivatedButton();
                this.InventoryGenerationDisplay = CommonEnum.InventoryGenerationDisplay.panelGenerationInfo;
            }
            catch (Exception Err)
            {
                CommonFunctions.MessageShow(Err.Message, CommonEnum.NotificationType.Error);
            }
        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Adding Default Login
                if (UserIDText.Text.Trim().Equals("1") && PINText.Text.Trim().Equals("1"))
                {
                    CommonFunctions.Username = UserIDText.Text.Trim();
                    CommonFunctions.defaultPassword = PINText.Text.Trim();
                    CommonFunctions.defaultLogin = true;
                    this.Close();
                }
                else
                {
                    CommonFunctions.defaultLogin = false;
                }

                this.UserIDText.Text = UserIDText.Text.Trim();
                this.PINText.Text = PINText.Text.Trim();
                switch (CommonFunctions.VerifyUser(UserIDText.Text.Trim(), PINText.Text.Trim(),false))
                {
                    case CommonEnum.Result.Retry:
                        {
                            this.PINText.Text = string.Empty;
                            this.UserIDText.Focus();
                            this.UserIDText.SelectAll();
                            this.NotifyUser.Text = Handy.Properties.Resources.Retry;
                            this.NotifyUser.Visible = true;
                        }
                        break;
                    case CommonEnum.Result.EnterUser:
                        {
                            this.NotifyUser.Text = Handy.Properties.Resources.EnterID;
                            this.UserIDText.Focus();
                            this.NotifyUser.Visible = true;
                        }
                        break;
                    case CommonEnum.Result.EnterPIN:
                        {
                            this.PINText.Focus();
                            this.NotifyUser.Text = Handy.Properties.Resources.EnterPIN;
                            this.NotifyUser.Visible = true;
                        }
                        break;
                    case CommonEnum.Result.ServerNotFound:
                        {
                            this.PINText.Focus();
                            this.NotifyUser.Text = Handy.Properties.Resources.ServerNotFound; 
                            this.NotifyUser.Visible = true;
                        }
                        break;
                    case CommonEnum.Result.InvalidUser:
                        {
                            this.PINText.Text = "";
                            this.PINText.Focus();
                            this.UserIDText.SelectAll();
                            this.NotifyUser.Text = Handy.Properties.Resources.InvalidUser;
                            this.NotifyUser.Visible = true;
                        }
                        break;
                    case CommonEnum.Result.OK:
                        {
                            
                           
                                Cursor.Current = Cursors.WaitCursor; //20130709 added wait cursor

                                CommonFunctions.Username = UserIDText.Text;
                                this.panelRenewLogIn.Visible = false;
                                this.PINText.Text = string.Empty;

                                this.NotifyUser.Visible = false;
                                this.ActivatedWindow = ActivateWindow.Renew;
                                this.Generate(this, e);

                                Cursor.Current = Cursors.Default; //20130709 added default cursor
                                this.labelverifyuser.Visible = false;
                                this.comboBox1.Visible = true;
                                this.comboBox1.Focus();                                
                        }
                        break;
                    case CommonEnum.Result.InvalidPIN:
                        {
                            this.NotifyUser.Text = Handy.Properties.Resources.InvalidPIN;
                            this.NotifyUser.Visible = true;
                            this.PINText.Focus();
                            this.PINText.SelectAll();
                        }
                        break;
                    default:
                        {
                            this.NotifyUser.Text = Handy.Properties.Resources.InvalidPIN;
                            this.NotifyUser.Visible = true;
                            this.PINText.Text = "";
                            this.UserIDText.Focus();
                            this.UserIDText.SelectAll();
                        }
                        break;
                }
            }
            catch (Exception Err)
            {
                CommonFunctions.MessageShow(Err.Message, CommonEnum.NotificationType.Error);
            }
        }

        private void UserIDText_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.NotifyUser.Text = "";
                this.NotifyUser.Visible = false;
            }
            catch (Exception Err)
            {
                CommonFunctions.MessageShow(Err.Message, CommonEnum.NotificationType.Error);
            }
        }

        private void PINText_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.NotifyUser.Text = "";
                this.NotifyUser.Visible = false;
            }
            catch (Exception Err)
            {
                CommonFunctions.MessageShow(Err.Message, CommonEnum.NotificationType.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = comboBox1.SelectedItem.ToString().Substring(1, 3);
            if (str.Equals(CommonEnum.GetStringValue(CommonEnum.Warehouse.StorageWarehouse)))
            {                
                CommonFunctions.GeneratedWarehouse = CommonEnum.Warehouse.StorageWarehouse;
            }
            else if (str.Equals(CommonEnum.GetStringValue(CommonEnum.Warehouse.HRMiniWarehouse)))
            {
                CommonFunctions.GeneratedWarehouse = CommonEnum.Warehouse.HRMiniWarehouse;
            }
            else if (str.Equals(CommonEnum.GetStringValue(CommonEnum.Warehouse.GAMiniWarehouse)))
            {
                CommonFunctions.GeneratedWarehouse = CommonEnum.Warehouse.GAMiniWarehouse;
            }
            else if (str.Equals(CommonEnum.GetStringValue(CommonEnum.Warehouse.CentralWarehouse)))
            {
                CommonFunctions.GeneratedWarehouse = CommonEnum.Warehouse.CentralWarehouse;
            }
            else if (str.Equals(CommonEnum.GetStringValue(CommonEnum.Warehouse.CentralProcessing)))
            {
                CommonFunctions.GeneratedWarehouse = CommonEnum.Warehouse.CentralProcessing;
            }
            else if (str.Equals(CommonEnum.GetStringValue(CommonEnum.Warehouse.ProductionMiniWarehouse)))
            {
                CommonFunctions.GeneratedWarehouse = CommonEnum.Warehouse.ProductionMiniWarehouse;
            } 
        }        
    }
}