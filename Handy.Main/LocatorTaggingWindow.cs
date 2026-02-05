using System;
using System.Data;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using Handy.Lib;
//using Symbol.Imaging2;

namespace Handy
{
    public partial class LocatorTaggingWindow : BaseWindow
    {
        #region Variables

        public CommonEnum.Buttons ExitButton = CommonEnum.Buttons.Exit;
        private bool Reprint = false;
        private bool AllowSave = false;
        enum TxtScroll
        {
            Up,
            Down
        }
        TxtScroll Scroll = TxtScroll.Up;
        
        #endregion
         
        #region Constructor

        public LocatorTaggingWindow(BarcodeReader BCReader, ReaderData BCData)
        {
            InitializeComponent();
            base.SetBarcodeReader(BCReader, BCData);
            base.SetWindowTitle("Locator Tagging");
            base.SetActiveButtons(BaseButtons.Save, BaseButtons.Cancel);
            CommonInterfaceFunctions.WLANAddSignalQualityHandler(base.pcbSignal, true);
        }

        #endregion

        #region Functions
        
        private void GetLocatorTaggingRRInfo()
        {
            if(LocatorTaggingBase.IsLocatorTaggingInfoGenerated())
            {
                if (this.Reprint)
                {
                    CommonFunctions.MessageShow(String.Format(CommonMsg.Warning.d_ReprintOutdated, CommonFunctions.BarcodeRRNo
                                                                                                 , CommonFunctions.BarcodeRRSeq
                                                                                                 , CommonFunctions.BarcodeRRLotSeq
                                                                                                 , CommonFunctions.BarcodeRRLocSeq)
                                                              , CommonEnum.NotificationType.Warning);
                    this.ClearAll();
                }
                else
                {
                    //Commmon
                    this.StockCode.Text = CommonFunctions.BarcodeStockCode;
                    this.TagNo.Text = CommonFunctions.TagNo;
                  //  this.Specs.Text = CommonFunctions.Specs;
                   // this.Expiry.Text = CommonFunctions.StockSpecs;
                    this.Expiry.Text = CommonFunctions.Expiry.ToShortDateString();
                    this.RRNo.Text = CommonFunctions.RRNoDisplay;

                    this.AvailableQty.Text = CommonFunctions.AvailableQty.ToString("#,##0");
                    this.TaggingQty.Text = CommonFunctions.AvailableQty.ToString("#,##0");
                    //this.lblTaggingQuantityDisplay.Text = CommonFunctions.AvailableQty.ToString("#");
                    CommonFunctions.InputQty = CommonFunctions.AvailableQty;
                    this.UnitUntagged.Text = CommonFunctions.Unit;
                    this.UnitTagging.Text = CommonFunctions.Unit;
                    this.OldLocatorCode.Text = CommonFunctions.OldLocatorCode;
                    this.OldLocatorCodeDesc.Text = CommonFunctions.OldLocatorDesc;
                    //
                    this.ExitButton = CommonEnum.Buttons.Cancel;
                    this.AllowSave = true;
                    //this.TaggingQty.Focus();
                    //this.TaggingQty.SelectAll();
                    this.timerMultilined.Enabled = true;
                }
            }
            else
            {
                this.ClearAll();
                //this.TagNo.Focus();
                //this.TagNo.SelectAll();
                this.AllowSave = false;
                base.BarcodeReader_Start();
            }
        }

        private void SaveButton_LocTag(object sender, EventArgs e)
        {            
            CommonFunctions.InputQty = CommonFunctions.ConvertStringDecimal(TaggingQty.Text.Replace(",", ""));
                if (CommonFunctions.InputQty > 0)
                {
                    if (CommonFunctions.LocatorQty > 0)
                    {
                        //Save to local for processing
                        StockMovementBase.MobiledbStockMovementProcess();
                       
                    }
                    else
                    {
                        //Save to local for processing
                        //LocatorTaggingBase.ProcessLocatorCode();
                        LocatorTaggingBase.MobiledbLocatorTaggingProcess();
                    }

                    Audio.PlayOKBeep();
                    CommonFunctions.MessageShow(String.Format("{0}\n{1}", CommonMsg.Success.ItemTagged, CommonFunctions.NewRRInfo(CommonFunctions.LocatorCode, CommonFunctions.InputQty, false)), CommonEnum.NotificationType.Default);

                    //Listing
                    LocatorTaggingBase.MobiledbLocatorTaggedListProcess(false);
                    //Save to server via thread
                    LocatorTaggingBase.TaggingThreadProcess();

                    ClearAll();
                    ExitButton = CommonEnum.Buttons.Exit;
                    //TagNo.Focus();
                    base.BarcodeReader_Start();
                    if (CommonFunctions.LocatorCode.ToString() != string.Empty)
                    {
                        LocatorCode.Text = CommonFunctions.LocatorCode.ToString();
                        LocatorCodeDesc.Text = CommonFunctions.LocatorDesc.ToString();
                    }
                    this.AllowSave = false;
                }
                else
                {
                    CommonFunctions.MessageShow(CommonMsg.Warning.d_QuantityInvalid, CommonEnum.NotificationType.Warning);
                }

                LocatorCode.Focus();
                LocatorCode.SelectAll();

            #region Old Saving Routine
            //CommonFunctions.InputQty = CommonFunctions.ConvertStringDecimal(TaggingQty.Text);

            //if (CommonFunctions.InputQty > 0)
            //{
            //    bool IsTagging = true;

            //    if (CommonFunctions.LocatorQty > 0)
            //    {
            //        StockMovementBase.ServerActualProcessStockMovement();
            //        IsTagging = false;
            //    }
            //    else
            //    {
            //        LocatorTaggingBase.ServerActualProcessLocatorTagging();
            //        IsTagging = true;
            //    }

            //    //Listing transactions
            //    if (!CommonFunctions.NewLocSeqNo.Equals("E") && !CommonFunctions.NewLocSeqNo.Equals("N"))
            //    {
            //        if (!string.IsNullOrEmpty(TagNo.Text.Trim()) && !(TagNo.Text.Trim().Equals("-")))
            //        {
            //            //Commented for the mean time by nilo the deletion of list
            //            //if (IsTagging)
            //            //{
            //            //    CommonFunctions.CeExecuteNonQuery(CommonQueryStrings.Mobile.Delete.LocatorTagging);   
            //            //}
            //            //else
            //            //{
            //            //    CommonFunctions.CeExecuteNonQuery(CommonQueryStrings.Mobile.Delete.StockMovement);
            //            //}

            //            #region Text file writting

            //            //TextParameterInfo[] TextParamInfo = new TextParameterInfo[14];
            //            //TextParamInfo[0] = new TextParameterInfo("LocatorCode", CommonFunctions.LocatorCode);
            //            //TextParamInfo[1] = new TextParameterInfo("RRNoDisplay", CommonFunctions.RRNoDisplay);
            //            //TextParamInfo[2] = new TextParameterInfo("BarcodeStockCode", CommonFunctions.BarcodeStockCode);
            //            //TextParamInfo[3] = new TextParameterInfo("InputQty", CommonFunctions.InputQty.ToString());
            //            //TextParamInfo[4] = new TextParameterInfo("BarcodeQuantity", CommonFunctions.BarcodeQuantity);
            //            //TextParamInfo[5] = new TextParameterInfo("BarcodePrintedDate", CommonFunctions.BarcodePrintedDate);
            //            //TextParamInfo[6] = new TextParameterInfo("Usercode", CommonFunctions.Username);
            //            //TextParamInfo[7] = new TextParameterInfo("Available", CommonFunctions.AvailableQty.ToString());
            //            //TextParamInfo[8] = new TextParameterInfo("Reserved", CommonFunctions.ReservedQty.ToString());
            //            //TextParamInfo[9] = new TextParameterInfo("Issued", "");
            //            //TextParamInfo[10] = new TextParameterInfo("Remark", "Unsent");
            //            //TextParamInfo[11] = new TextParameterInfo("Sent", "1");
            //            //TextParamInfo[12] = new TextParameterInfo("LocatorDesc", CommonFunctions.LocatorDesc);
            //            //TextParamInfo[13] = new TextParameterInfo("Tag-No", TagNo.Text);
            //            //LocatorTaggingBase.TextfileLocatorTagging(TextParamInfo);

            //            #endregion

            //            #region Mobile database listing

            //            LocatorTaggingBase.MobiledbLocatorTaggedListProcess();

            //            #endregion
            //        }

            //        //11/07/2012 Nilo transfered inside the condition.
            //        //Clear only if transation was saved.
            //        ClearAll();
            //        ExitButton = CommonEnum.Buttons.Exit;
            //        TagNo.Focus();
            //        base.BarcodeReader_Start();
            //        this.AllowSave = false;
            //    }
            //}
            //else
            //{ 
            //    CommonFunctions.MessageShow(CommonMsg.Warning.d_QuantityInvalid, CommonEnum.NotificationType.Warning);
            //}
            #endregion
        }
        /// <summary>
        /// Added by DEV1521-FRANCIS
        /// Date: 06/13/2018
        /// Copied from StockMovement Module to merge both modules Locator Tagging & Stock Movement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_StckMov(object sender, EventArgs e)
        {
            if (CommonFunctions.isInputValid(TaggingQty.Text, CommonFunctions.ConvertStringDecimal(CommonFunctions.BarcodeQuantity), true))
            {
                CommonFunctions.InputQty = CommonFunctions.ConvertStringDecimal(TaggingQty.Text);

                StockMovementBase.ServerActualProcessStockMovement();
                //Nilo Added to berify if scanned label is updated <06/07/2012>
                CommonFunctions.ScannedLabelForReprinting(false, true, "", "SM-H" + CommonFunctions.HandyNo);
                //Commmon

                ClearAll();
                ExitButton = CommonEnum.Buttons.Exit;
                //StockCode.Focus();
                base.BarcodeReader_Start();
            }
        
            //else
            //{
                LocatorCode.Focus();
                LocatorCode.SelectAll();
            //}
        }
        private void CancelButton(object sender, EventArgs e)
        {
            if (ExitButton == CommonEnum.Buttons.Cancel)
            {
                if (CommonFunctions.InputQty != 0)
                {
                    if (DialogResult.No == CommonFunctions.MessageShow(CommonMsg.Warning.d_NotifyNotSave, CommonEnum.NotificationType.Warning, CommonEnum.MessageButtons.YesNo))
                    {
                        return;
                    }
                }
                ClearAll();
                ExitButton = CommonEnum.Buttons.Exit;
                base.BarcodeReader_Start();
                this.AllowSave = false;
                //TagNo.Focus();
            }
            else
                Close();
        }

        private void IsMultilined(TextBox txtBox, String txtContent)
        {
            //Set Properties
            if (txtContent.Length > 25)
            {
                txtBox.ScrollBars = ScrollBars.Vertical;
                txtBox.Multiline = true;
                txtBox.WordWrap = true;
                this.timerMultilined.Enabled = true;

                //AutoScroll
                if (this.Scroll.Equals(TxtScroll.Up))
                {
                    this.Scroll = TxtScroll.Down;
                    txtBox.SelectionStart = txtBox.Text.Length;
                    txtBox.ScrollToCaret();
                    txtBox.Refresh();
                }
                else
                {
                    this.Scroll = TxtScroll.Up;
                    txtBox.SelectionStart = 0;
                    txtBox.ScrollToCaret();
                    txtBox.Refresh();
                }
            }
            else
            {
                txtBox.ScrollBars = ScrollBars.None;
                txtBox.Enabled = true;
                this.timerMultilined.Enabled = false;
            }
        }

        private void ClearAll()
        {
            //ExpiryDate.ScrollBars = ScrollBars.None;
            //Commmon
            //this.TagNo.Text = "";
            this.TagNo.Text = "";
           // this.Specs.Text = "";
            this.Expiry.Text = "";
            this.RRNo.Text = "";
            this.StockCode.Text = "";
            //
            this.AvailableQty.Text = "";
            this.TaggingQty.Text = "";
            //this.lblTaggingQuantityDisplay.Text = "";
            this.LocatorCodeDesc.Text = "";
            this.UnitUntagged.Text = "";
            this.UnitTagging.Text = "";
            this.LocatorCode.Text = "";
            this.OldLocatorCode.Text = "";
            this.OldLocatorCodeDesc.Text = "";
            CommonFunctions.ClearStrings();
        }

        #endregion

        #region Override

        protected override void BarcodeReader_AnalyzeType(object Sender, EventArgs e)
        {
            base.GetRawBarcodeValue = false;
            base.BarcodeReader_AnalyzeType(Sender, e);

            switch (base.ScannedBarcodeType)
            {
                case CommonEnum.LabelType.Item2D:
                    {
                        if (!string.IsNullOrEmpty(CommonFunctions.LocatorCode))
                        {
                            if (CommonFunctions.IsConnected())
                            {
                                // Transacting=false, ShowMsg=false
                                //if (CommonFunctions.ScannedLabelForReprinting(false, false, this.LocatorCode.Text, string.Format("LT-H{0}", CommonFunctions.HandyNo)))
                                //    this.Reprint = true;         
                                
                                    // ADDED BY DEV1521-FRANCIS 2018-06-20
                                    // TO REPLACE THE OLD BARCODE VALIDATION FOR REPRINTING
                                    this.Reprint = LocatorTaggingBase.isRRBarcodeOutdated();

                                    this.GetLocatorTaggingRRInfo();
                                    this.Reprint = false;
                                    this.TaggingQty.ReadOnly = true;
                                
                                this.LocatorCode.Focus();
                                this.LocatorCode.SelectAll();
                            }                            
                        }
                        else
                        {
                            CommonFunctions.MessageShow(CommonMsg.Warning.ScanLocator
                                                        , "Locator Tagging"
                                                        , CommonEnum.NotificationType.Warning);
                            ClearAll();
                            base.BarcodeReader_Start();
                            this.AllowSave = false;
                        }
                    }
                    break;
                case CommonEnum.LabelType.Invalid:
                    {
                        ClearAll();
                        base.BarcodeReader_Start();
                        this.AllowSave = false;
                    }
                    break;
                case CommonEnum.LabelType.LocatorCode:
                    {
                        ClearAll();
                        LocatorCode.Text = CommonFunctions.BarcodeLocatorCode;
                        LocatorCodeDesc.Text = CommonFunctions.LocatorDesc;

                        TaggingQty.ReadOnly = true;
                  
                        LocatorCode.Focus();
                        base.BarcodeReader_Start();
                        this.AllowSave = false;
                    }
                    break;
                case CommonEnum.LabelType.ServerNotFound:
                    {
                        ClearAll();
                        LocatorCodeDesc.Text = "";
                        LocatorCode.Text = "";
                        LocatorCode.Focus();
                        base.BarcodeReader_Start();
                        this.AllowSave = false;
                    }
                    break;
            }
            
            base.ScannedBarcodeType = Handy.Lib.CommonEnum.LabelType.Null;
        }

        protected override void BaseWindow_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                //Nilo Added 09/21/2012 Tagging List 
                case Keys.Enter:
                    //COMMENTED BY DEV1521-FRANCIS 
                    //Below code is only applicable for MMSTEEL
                    base.BarcodeReader_Stop();
                    LocatorTaggingListWindow _TaggingListForm = new LocatorTaggingListWindow();
                    _TaggingListForm.ShowDialog();
                    CommonInterfaceFunctions.WLANAddSignalQualityHandler(base.pcbSignal, true);
                    base.BarcodeReader_Start();
                    break;
                case Keys.F1:
                case Keys.F14:
                    if (this.AllowSave == true)
                    {
                        if (LocatorTaggingBase.IsRRTagged(CommonFunctions.BarcodeRRNo
                                                                 , CommonFunctions.BarcodeRRSeq
                                                                 , CommonFunctions.BarcodeRRLotSeq
                                                                 , CommonFunctions.BarcodeRRLocSeq))
                        {
                            if (StockMovementBase.isWarehouseCodeMatch())
                            {
                                SaveButton_LocTag(this, e);
                            }
                            else
                            {
                                CommonFunctions.MessageShow(CommonMsg.Warning.WarehouseMismatch, CommonEnum.NotificationType.Warning, CommonEnum.MessageButtons.Ok);
                            }
                        }
                        else
                            SaveButton_LocTag(this, e);
                    }
                    break;
                case Keys.F4:
                case Keys.F15:
                    CancelButton(this, e);
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

        //Events

        private void LocatorTaggingWindow_Load(object sender, EventArgs e)
        {
            LocatorCode.Focus();
            this.AllowSave = false;
            TaggingQty.ReadOnly = true;
            if (LocatorTaggingBase.CountTaggedList() > 300)
            {
                CommonFunctions.MessageShow(CommonMsg.Warning.d_TaglistExceeded, CommonEnum.NotificationType.Warning);
            }
            this.timerBackGroudTransaction.Enabled = true;

        }

        private void LocatorTaggingWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                this.timerMultilined.Enabled = false;
                this.timerMultilined.Dispose();
                this.timerBackGroudTransaction.Enabled = false;
                this.timerBackGroudTransaction.Dispose();
            }
            catch { }
            ClearAll();
            CommonFunctions.LocatorCode = string.Empty;
            CommonFunctions.LocatorDesc = string.Empty;
        }      

        private void timerMultilined_Tick(object sender, EventArgs e)
        {
            //this.IsMultilined(this.ExpiryDate, this.ExpiryDate.Text);
        }

        private void timerBackGroudTransaction_Tick(object sender, EventArgs e)
        {
            //START Back ground transactions : Interval before starting 3 seconds
            timerBackGroudTransaction.Enabled = false;
            LocatorTaggingBase.OnloadStartBackGroundTransactions();
        }

        private void StockCode_GotFocus(object sender, EventArgs e)
        {
            LocatorCode.Focus();
        }

        private void RRNo_GotFocus(object sender, EventArgs e)
        {
            LocatorCode.Focus();
        }

        private void AvailableQty_GotFocus(object sender, EventArgs e)
        {
            LocatorCode.Focus();
        }

        private void UnitTagging_GotFocus(object sender, EventArgs e)
        {
            LocatorCode.Focus();
        }

        private void UnitUntagged_GotFocus(object sender, EventArgs e)
        {
            LocatorCode.Focus();
        }

        private void LocatorCodeDesc_GotFocus(object sender, EventArgs e)
        {
            LocatorCode.Focus();
        }

        private void label5_ParentChanged(object sender, EventArgs e)
        {

        }        
     }
}
