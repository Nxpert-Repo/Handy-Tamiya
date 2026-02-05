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
    public partial class InventoryProcessingWindow : BaseWindow 
    {
        #region Variable

        private CommonEnum.Buttons ExitButton = CommonEnum.Buttons.Exit;
        private string PopupMsg = "Item Scanned";
        bool IsAllowSave = false;
        private DataTable dtInventoryList = new DataTable();
        private ActivateWindow ActivatedWindow = ActivateWindow.Generate;
        private enum ActivateWindow
        {
            Save,
            Generate,
            Renew,
            Ok,
            View,
            ViewNotYetApproved,
            List
        }

        #endregion 

        #region Constructor

        public InventoryProcessingWindow(BarcodeReader BCReader, ReaderData BCData)
        {
            InitializeComponent();
            base.SetBarcodeReader(BCReader, BCData);
            base.SetWindowTitle("Inventory Processing");
            base.SetActiveButtons(BaseButtons.List, BaseButtons.Cancel);
            CommonInterfaceFunctions.WLANAddSignalQualityHandler(base.pcbSignal, true);
        }

        #endregion 

        #region Override

        protected override void BarcodeReader_AnalyzeType(object Sender, EventArgs e)
        {
            base.BarcodeReader_AnalyzeType(Sender, e);

            switch (base.ScannedBarcodeType)
            {
                case CommonEnum.LabelType.Null:
                    //Do Nothing
                    break;
                case CommonEnum.LabelType.Item2D:
                    {
                        if (!string.IsNullOrEmpty(CommonFunctions.LocatorCode))
                        {

                            Cursor.Current = Cursors.WaitCursor;
                            base.BarcodeReader_Stop();
                            this.GetInventoryScannedRRInfo();
                            base.BarcodeReader_Start();
                            Cursor.Current = Cursors.Default;
                        }
                        else
                        {
                            CommonFunctions.MessageShow(CommonMsg.Info.d_ScanLocator, CommonEnum.NotificationType.Information);
                            this.ClearAll();
                        }
                    }
                    break;
                case CommonEnum.LabelType.ItemLinear:
                    {
                        if (!string.IsNullOrEmpty(CommonFunctions.LocatorCode))
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            base.BarcodeReader_Stop();
                            this.GetInventoryScannedRRInfo();
                            base.BarcodeReader_Start();
                            Cursor.Current = Cursors.Default;
                        }
                        else
                        {
                            CommonFunctions.MessageShow(CommonMsg.Info.d_ScanLocator, CommonEnum.NotificationType.Information);
                            this.ClearAll();
                        }
                    }
                    break;
                case CommonEnum.LabelType.LocatorCode:
                    {
                        this.ClearAll();
                        base.BarcodeReader_Stop();
                        CommonFunctions.MessageShow(String.Format(CommonMsg.Info.InventoryLocator, CommonFunctions.LocatorDesc));
                        base.BarcodeReader_Start();
                        this.LocatorCode.Text = CommonFunctions.LocatorCode;
                        this.txtLocatorDesc.Text = CommonFunctions.LocatorDesc;
                        this.ActualQty.Focus();
                    }
                    break;
                case CommonEnum.LabelType.Invalid:
                    {
                        this.ClearAll();
                        this.ActualQty.Focus();
                        this.ActualQty.SelectAll();
                        ActualQty.Text = "";

                    }
                    break;
                case CommonEnum.LabelType.ServerNotFound:
                    {
                        this.ClearAll();
                        this.ActualQty.Focus();
                        this.ActualQty.SelectAll();
                    }
                    break;
                default:
                    {
                        this.ClearAll();     
                 
                        this.ActualQty.Focus();
                        this.ActualQty.SelectAll();
                        ActualQty.Text = "";
                    }
                    break;

            }

            base.ScannedBarcodeType = Handy.Lib.CommonEnum.LabelType.Null;
        }

        protected override void BaseWindow_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                case Keys.F14:
                    if (this.ActivatedWindow == ActivateWindow.Save)
                        this.SaveButton(this, e);
                    else if (this.ActivatedWindow == ActivateWindow.List)
                        this.ListButton(this, e);
                    break;
                case Keys.F4:
                case Keys.F15:
                    this.CancelButton(this, e);
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

        #region Functions

        private void GetInventoryScannedRRInfo()
        {
            this.ShowHideBalance(false);
            CommonFunctions.StockName = "";
            CommonFunctions.Specs = "";
            this.ShowHideSuccess(false);
            this.txtStockName.BackColor = System.Drawing.Color.White;
            this.ActivatedWindow = ActivateWindow.List;
            this.FormatPicture();

            if (InventoryBase.IsInventoryRRinfoGenerated())
            {
                //Display for Stock Name
                if (CommonFunctions.ValidityType == CommonEnum.GetStringValue(CommonEnum.ValidityType.Reprint))
                {
                    this.lblBalanceQty.Text = string.Format("{0:0.000000}", CommonFunctions.AvailableQty); // take note for change request
                    this.lblBalanceQty.BackColor = System.Drawing.Color.Yellow;
                    this.ShowHideBalance(true);
                    this.txtStockName.Text = CommonFunctions.StockName;
                    this.txtStockName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular);
                }
                else if (CommonFunctions.ValidityType == CommonEnum.GetStringValue(CommonEnum.ValidityType.Issued)
                       ||CommonFunctions.ValidityType == CommonEnum.GetStringValue(CommonEnum.ValidityType.Deleted))
                {
                    this.txtStockName.BackColor = System.Drawing.Color.Red;
                    this.txtStockName.Text = CommonMsg.Info.issueditem;
                    this.txtStockName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular);
                    CommonFunctions.StockName = CommonMsg.Info.issueditem;
                }
              
                else if (CommonFunctions.ValidityType == CommonEnum.GetStringValue(CommonEnum.ValidityType.Unchecked))
                {
                    string BarcodeStockCode = CommonFunctions.BarcodeStockCode.Substring(0, 1);
                    this.txtStockName.BackColor = System.Drawing.Color.Red;
                    this.txtStockName.Text = string.Format(CommonMsg.Info.UncheckedStockCodeOfMachinery, BarcodeStockCode);
                    this.txtStockName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
                    CommonFunctions.ValidityType = CommonFunctions.ValidityType == CommonEnum.GetStringValue(CommonEnum.ValidityType.Unchecked) ? CommonEnum.GetStringValue(CommonEnum.ValidityType.Mismatch) : CommonFunctions.ValidityType;
                    CommonFunctions.StockName = string.Format(CommonMsg.Info.UncheckedStockCodeOfMachinery, BarcodeStockCode);
                }
                else if (CommonFunctions.ValidityType == CommonEnum.GetStringValue(CommonEnum.ValidityType.Mismatch))
                {
                 
                    this.txtStockName.Text = string.Format(CommonMsg.Info.MismatchStockType, "");
                    this.txtStockName.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
                    CommonFunctions.StockName = string.Format(CommonMsg.Info.MismatchStockType, "");
                }
                else
                {
                    this.txtStockName.Text = CommonFunctions.StockName;
                    this.txtStockName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular);
                }

                this.RRNo.Text = CommonFunctions.RRNoDisplay;
                this.txtStockCode.Text = CommonFunctions.BarcodeStockCode;
                this.ActualQty.Text = CommonFunctions.BarcodeQuantity;
                this.txtSpecs.Text = CommonFunctions.Specs;
                this.ExitButton = CommonEnum.Buttons.Cancel;
                this.ActualQty.Focus();
                this.ActualQty.SelectAll();
                this.PopupMsg = "Item Scanned";
                this.SaveScanned();
               
            }
            else
            {
                CommonFunctions.RRNo = "";
                CommonFunctions.RRSeq = "";
                CommonFunctions.RRLotSeq = "";
                CommonFunctions.RRLocSeq = "";
            }
        }

       
        private void SaveScanned()
        {
            decimal Qty = CommonFunctions.ConvertStringDecimal(ActualQty.Text);

            if (CommonFunctions.isInputValid(ActualQty.Text, Qty, false))
            {
                #region Using Mobile DB

                string AddQuery = "";
                string UpdateQuery = "";
                CommonFunctions.SentDateTime = DateTime.Now.ToString();

                AddQuery = string.Format( CommonQueryStrings.Mobile.Insert.T_Inventory
                                        , CommonFunctions.BarcodeRRNo
                                        , CommonFunctions.BarcodeRRSeq
                                        , CommonFunctions.BarcodeRRLotSeq
                                        , CommonFunctions.BarcodeRRLocSeq
                                        , CommonFunctions.BarcodeStockCode
                                        , Qty
                                        , CommonFunctions.AvailableQty //BalanceQty
                                        , CommonFunctions.BarcodePrintedDate
                                        , Qty != CommonFunctions.ConvertStringDecimal(CommonFunctions.BarcodeQuantity) ? "T" : "F"
                                        , CommonFunctions.LocatorCode
                                        , CommonFunctions.LocatorDesc
                                        , CommonFunctions.Remark
                                        , CommonFunctions.SentDateTime
                                        , "0"
                                        , (CommonFunctions.ValidityType == CommonEnum.GetStringValue(CommonEnum.ValidityType.Deleted)) ? CommonEnum.GetStringValue(CommonEnum.ValidityType.Issued) : CommonFunctions.ValidityType
                                        , CommonFunctions.StockName.Trim()
                                        , CommonFunctions.Specs.Trim());

                 UpdateQuery = string.Format(CommonQueryStrings.Mobile.Update.T_Inventory
                                        , CommonFunctions.BarcodeRRNo
                                        , CommonFunctions.BarcodeRRSeq
                                        , CommonFunctions.BarcodeRRLotSeq
                                        , CommonFunctions.BarcodeRRLocSeq
                                        , CommonFunctions.BarcodeStockCode
                                        , Qty
                                        , CommonFunctions.AvailableQty //Balance Qty
                                        , CommonFunctions.BarcodePrintedDate
                                        , Qty != CommonFunctions.ConvertStringDecimal(CommonFunctions.BarcodeQuantity) ? "T" : "F"
                                        , CommonFunctions.LocatorCode
                                        , CommonFunctions.LocatorDesc
                                        , CommonFunctions.Remark
                                        , CommonFunctions.SentDateTime
                                        , "0"
                                        , (CommonFunctions.ValidityType == CommonEnum.GetStringValue(CommonEnum.ValidityType.Deleted)) ? CommonEnum.GetStringValue(CommonEnum.ValidityType.Issued) : CommonFunctions.ValidityType
                                        , CommonFunctions.StockName.Trim()
                                        , CommonFunctions.Specs.Trim());

                if (InventoryBase.MobileInventoryAddUpdateData(AddQuery, UpdateQuery))
                {
                    this.SetDisposablePendingTable();
                   // this.lblPending.Text = InventoryBase.ListCount(CommonEnum.Function.Inventory)[0].ToString(); //20130412 Allen Modify: changed CommonFunctions to InventoryBase
                    UpdatePending(CommonEnum.UploadStats.Pending);
                    this.ShowHideSuccess(true);

                    try
                    {
                        int intPending = Convert.ToInt32(this.lblPending.Text);
                        if (intPending > 0)
                        {
                            //if (intPending % 100 == 0 || (intPending > 100 && intPending % 25 == 0))//commented - marvie dev1646 - chnaging its limit to 50
                            //added -marvie -set limit to 50 
                                if (intPending % 50 == 0 || (intPending > 50 && intPending % 25 == 0))
                                CommonFunctions.MessageShow(String.Format(CommonMsg.Warning.d_PendingMaxCountWarning
                                                          , this.lblPending.Text)
                                                          , CommonEnum.NotificationType.Warning);
                        }
                    }
                    catch { }
                }
                else
                    CommonFunctions.MessageShow(CommonMsg.Error.d_Unsave);

                #endregion
            }

            this.ActualQty.Focus();
            this.ActualQty.SelectAll();
        }
        private void UpdatePending(CommonEnum.UploadStats UploadStatus)
        {
            int Count = 0; int Pending = 0;
            if (CommonFunctions.UseMobileDB)
            {
                this.dtInventoryList = InventoryBase.MobileInventoryDisplayList(UploadStatus); //20130405 Allen Modify: changed CommonFunctions to InventoryBase
            }
              else
            {
                this.dtInventoryList = Logger.GetTextDataTable(Logger.HandyPath, Logger.HandyMITFile, 2); //Second Column RR Number as Primary
            }
            if (dtInventoryList == null)
                return;
            Count = this.dtInventoryList.Rows.Count;
            int i = 0;
            if (Count > 0)
            {
                //populate
                foreach (DataRow row in dtInventoryList.Rows)
                {
                    if (Convert.ToInt16(row["COLUMN_7"]) == 0)
                        ++Pending;
                }
            }
            lblPending.Text=string.Format("{0}",Pending.ToString());
        }
        private void SaveButton(object sender, EventArgs e)
        {
            this.PopupMsg = "Item Saved";
            if (!string.IsNullOrEmpty(this.ActualQty.Text))
            {
                if (CommonFunctions.ConvertStringDecimal(this.ActualQty.Text) != CommonFunctions.ConvertStringDecimal(CommonFunctions.BarcodeQuantity))
                {
                    CommonFunctions.ValidityType = CommonEnum.GetStringValue(CommonEnum.ValidityType.Modified);
                    CommonFunctions.Remark = string.Format(CommonMsg.Info.InventoryModifiedQuantity, CommonFunctions.BarcodeQuantity);
                }
            }
            this.SaveScanned();
            this.ActivatedWindow = ActivateWindow.List;
            this.FormatPicture();
            this.ShowHideBalance(false);
        }

        private void ListButton(object sender, EventArgs e)
        {
            base.BarcodeReader_Stop();

            try
            {
                this.ClearAll();
                this.ShowHideBalance(false);
                InventoryListWindow _InventoryListWindow = new InventoryListWindow();
                _InventoryListWindow.ShowDialog();
                _InventoryListWindow.Dispose();
                this.SetDisposablePendingTable();
               // this.lblPending.Text = InventoryBase.ListCount(CommonEnum.Function.Inventory)[0].ToString(); //20130412 Allen Modify: changed CommonFunctions to InventoryBase
                UpdatePending(CommonEnum.UploadStats.Pending);
            }
            catch (Exception err)
            { 
                CommonFunctions.MessageShow(err.Message, CommonEnum.NotificationType.Warning); 
            }

            base.BarcodeReader_Start();
        }

        private void CancelButton(object sender, EventArgs e)
        {
            if (ExitButton == CommonEnum.Buttons.Cancel)
            {
                this.ClearAll();
                this.ExitButton = CommonEnum.Buttons.Exit;
                this.ActualQty.Focus();
            }
            else
            {
                string Pending = CommonFunctions.CEDataReader(CommonQueryStrings.Mobile.ViewFiltered.InventoryUnsentCount);
                if (!Pending.Trim().Equals("0"))
                {
                    if (DialogResult.Yes == CommonFunctions.MessageShow(CommonMsg.Warning.d_PendingWarning, CommonEnum.NotificationType.Question, CommonEnum.MessageButtons.YesNo))
                    {
                        CommonFunctions.LocatorCode = "";
                        CommonFunctions.LocatorDesc = "";
                        this.Close();
                    }
                }
                else
                {
                    CommonFunctions.LocatorCode =  "";
                    CommonFunctions.LocatorDesc = "";
                    this.Close();
                }
            }
        }

        private void ClearAll()
        {
            this.RRNo.Text = "";
            this.txtStockCode.Text = "";
            this.ActualQty.Text = "";
            this.txtStockName.Text = "";
            this.txtSpecs.Text = "";
            this.lblBalanceQty.Text = "";
            this.txtStockName.BackColor = System.Drawing.Color.White;
            this.lblBalanceQty.BackColor = System.Drawing.Color.Honeydew;
            this.ActivatedWindow = ActivateWindow.List;
            this.ActualQty.Focus();
            this.FormatPicture();
            CommonFunctions.ClearStrings();
        }

        private void FormatPicture()
        {
            if (this.ActivatedWindow == ActivateWindow.Save)
            {
                base.SetActiveButtons(BaseButtons.Save, BaseButtons.Cancel);
            }
            else if (this.ActivatedWindow == ActivateWindow.List)
            {
                this.ActualQty.Focus();
                this.ActualQty.SelectAll();
                base.SetActiveButtons(BaseButtons.List, BaseButtons.Cancel);
            }
        }

        private void SetDisposablePendingTable()
        {
            CommonFunctions.DisposableTable = new DataTable();
            CommonFunctions.DisposableTable.Columns.Add("RRNoDisplay", typeof(String));
            CommonFunctions.DisposableTable.AcceptChanges();
        }

        private void ShowHideSuccess(bool IsVisible)
        {
            if (IsVisible)
            {
                this.lblSaved.BackColor = System.Drawing.Color.White;
                this.lblSaved.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
                this.lblSaved.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                this.lblSaved.Location = new System.Drawing.Point(75, 37);
                this.lblSaved.Size = new System.Drawing.Size(169, 40);

                this.pcbSaved.Location = new System.Drawing.Point(1, 36);
                this.pcbSaved.Size = new System.Drawing.Size(85, 42);
                this.pcbSaved.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            }

            this.pcbSaved.Visible = IsVisible;
            this.lblSaved.Text = this.PopupMsg;
            this.lblSaved.Visible = IsVisible;
            this.timerHideMsg.Enabled = IsVisible;
        }

        private void ShowHideBalance(bool IsVisible)
        {
            this.lblSystem.Visible = IsVisible;
            this.lblBalanceQty.Visible = IsVisible;
        }
        #endregion Functions

        // Events

        private void InventoryProcessingWindow_Closing(object sender, CancelEventArgs e)
        {
            CommonFunctions.DisposeCommonObj();
            try { this.timerHideMsg.Dispose(); } catch { }
        }

        private void ActualQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumberFormatInfo numberFormatInfo = CultureInfo.CurrentCulture.NumberFormat;
            string decimalSeparator = numberFormatInfo.NumberDecimalSeparator;

            string keyInput = e.KeyChar.ToString();

            if ((!CommonFunctions.isDecimal()) && (Char.IsDigit(e.KeyChar) || e.KeyChar == '\b'))
            {
                e.Handled = false;
            }
            else if ((CommonFunctions.isDecimal()) && (Char.IsDigit(e.KeyChar) || keyInput.Equals(decimalSeparator) || e.KeyChar == '\b'))
            {
                if (ActualQty.Text.IndexOf('.') != -1)
                    if (Char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
                        e.Handled = false;
                    else
                        e.Handled = true;
                else
                    e.Handled = false;
            }
            else
                e.Handled = true;

        }

        private void InventoryProcessingWindow_Load(object sender, EventArgs e)
        {
            this.SetDisposablePendingTable();
        //    this.lblPending.Text = InventoryBase.ListCount(CommonEnum.Function.Inventory)[0].ToString(); //20130412 Allen Modify: changed CommonFunctions to InventoryBase
            UpdatePending(CommonEnum.UploadStats.Pending);
            this.ActivatedWindow = ActivateWindow.List;
            this.FormatPicture();

            if (CommonFunctions.InventoryMaster == null)
            {
                this.lblGeneratedWarehouse.Text = "No Reference";
            }
            else
            {
                //if (CommonFunctions.GeneratedWarehouse == CommonEnum.Warehouse.DefaultWarehouse)
                //{
                //    this.lblGeneratedWarehouse.Text = "Default Warehouse";
                //}
              
                //else if (CommonFunctions.GeneratedWarehouse == CommonEnum.Warehouse.IPMPSENMaterial)
                //{
                //    this.lblGeneratedWarehouse.Text = "IPM & PSEN Material Storage";
                //}
                //else if (CommonFunctions.GeneratedWarehouse == CommonEnum.Warehouse.WaferRoom)
                //{
                //    this.lblGeneratedWarehouse.Text = "Wafer Room";
                //}

                //else if (CommonFunctions.GeneratedWarehouse == CommonEnum.Warehouse.ProductionFactory1)
                //{
                //    this.lblGeneratedWarehouse.Text = "Production Factory 1";
                //}

                //else if (CommonFunctions.GeneratedWarehouse == CommonEnum.Warehouse.ProductionFactory2)
                //{
                //    this.lblGeneratedWarehouse.Text = "Production Factory 2";
                //}
                //else 
                if (CommonFunctions.GeneratedWarehouse == CommonEnum.Warehouse.StorageWarehouse)
                {
                    this.lblGeneratedWarehouse.Text = "Old Warehouse";
                }
            }
            
        }

        private void timerHideMsg_Tick(object sender, EventArgs e)
        {
            this.ShowHideSuccess(false);
        }

        private void ActualQty_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.ActualQty.Text))
            {
                if (CommonFunctions.ConvertStringDecimal(this.ActualQty.Text) != CommonFunctions.ConvertStringDecimal(CommonFunctions.BarcodeQuantity))
                {
                    this.ActivatedWindow = ActivateWindow.Save;
                    base.SetActiveButtons(BaseButtons.Save, BaseButtons.Cancel);
                }
            }
            else
            {
                this.ActivatedWindow = ActivateWindow.List;
                base.SetActiveButtons(BaseButtons.List, BaseButtons.Cancel);
            }
        }
    }
}