using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using System.Data;
using Handy.Lib;

namespace Handy
{
    public partial class StockReclassWindow : BaseWindow
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
        private ActivateWindow ActivatedWindow = ActivateWindow.Opening;
        private enum ActivateWindow
        {
            Opening,
            Reclass,
            Save,
            Ok,
        }

        #endregion

        #region Constructor
        public StockReclassWindow(Symbol.Barcode.Reader BCReader, Symbol.Barcode.ReaderData BCData)
        {
            InitializeComponent();
            base.SetBarcodeReader(BCReader, BCData);
            base.SetWindowTitle("Stock Packing Opening");
            base.SetActiveButtons(BaseButtons.Open, BaseButtons.Cancel);
            CommonInterfaceFunctions.WLANAddSignalQualityHandler(base.pcbSignal, true);            
        }
        #endregion

        #region Functions

        private void SetDesignWindow()
        {
            if(CommonFunctions.CurrentFunction.Equals(CommonEnum.Function.StockReclass))
            {
                this.ActivatedWindow = ActivateWindow.Reclass;
                CommonFunctions.IsReclass = true;
                base.SetWindowTitle("Stock Re-Classing");
                base.SetActiveButtons(BaseButtons.Reclass, BaseButtons.Cancel);    
            }
            else if (CommonFunctions.CurrentFunction.Equals(CommonEnum.Function.StockPackingOpennig))
            {
                this.ActivatedWindow = ActivateWindow.Opening;
                CommonFunctions.IsReclass = false;
                base.SetWindowTitle("Stock Packing Opening");
                base.SetActiveButtons(BaseButtons.Open, BaseButtons.Cancel);
            }
        }
        
        private void GetStockReclassRRInfo()
        {
            CommonFunctions.StockClassNew = string.Empty;
            this.txtNewClass.Text = string.Empty;
            if (CommonFunctions.IsStockReclassRRInfoGenerated())
            {
                StockReclassBase.GetStockClassList();
                StockReclassBase.GetCustomerList();

                if (this.Reprint)
                {
                    CommonFunctions.MessageShow(String.Format(CommonMsg.Warning.d_ReprintOutdated, CommonFunctions.TagNo), CommonEnum.NotificationType.Warning);
                    this.ClearAll();
                    return;
                }
                //Commmon
                this.TagNo.Text = CommonFunctions.TagNo;
                this.Dimension.Text = CommonFunctions.Dimension;
                this.Specs.Text = CommonFunctions.Specs;
                this.Class.Text = CommonFunctions.StockClass;
                this.RRNo.Text = CommonFunctions.RRNoDisplay;
                //
                this.AvailableQty.Text = CommonFunctions.AvailableQty.ToString("#");
                this.UnitAvailable.Text = CommonFunctions.Unit;
                this.LocatorCode.Text = CommonFunctions.LocatorCode;
                this.LocatorCodeDesc.Text = CommonFunctions.LocatorDesc;
                //
                this.ExitButton = CommonEnum.Buttons.Cancel;
                this.AllowSave = true;
                //
                this.timerMultilined.Enabled = true;
                this.timerMultilined2.Enabled = true;
            }
            else
            {
                this.ClearAll();
                this.TagNo.Focus();
                this.TagNo.SelectAll();
                this.AllowSave = false;
                base.BarcodeReader_Start();
            }
        }

        private void SaveButton(object sender, EventArgs e)
        {
            if (CommonFunctions.IsReclass)
            {
                //Stock Reclass Operation
                if (this.lstClassList.Visible.Equals(true))
                {
                    this.GetSelectedRow(this.lstClassList, false);
                    if (string.IsNullOrEmpty(CommonFunctions.StockClassNew))
                    {
                        CommonFunctions.MessageShow(String.Format(CommonMsg.Warning.d_SelectClass), CommonEnum.NotificationType.Warning);
                        return;
                    }

                    if (CommonFunctions.IsBalanceClass && this.lstCustomerList.Visible.Equals(false))
                    {
                        CommonFunctions.CustomerCode = string.Empty;
                        this.DisplayCustomerList(true);
                        return;
                    }

                    if(CommonFunctions.IsBalanceClass && this.lstCustomerList.Visible.Equals(true))
                    {
                        this.GetSelectedRow(this.lstCustomerList, false);
                        if (string.IsNullOrEmpty(CommonFunctions.CustomerCode))
                        {
                            CommonFunctions.MessageShow(CommonMsg.Warning.d_SelectCustomer, CommonEnum.NotificationType.Warning);
                            return;
                        }
                    }

                    StockReclassBase.ServerActualProcessStockReclass();
                    #region Validate Result
                    if (CommonFunctions.NewLocSeqNo.Equals("S"))
                    {
                        CommonFunctions.ScannedLabelForRepriting(true, false, this.LocatorCode.Text, string.Format("SR-H{0}", CommonFunctions.HandyNo));
                        this.ClearAll();
                        this.txtNewClass.Text = StockReclassBase.GetNewClass();
                        this.TagNo.Focus();
                        base.BarcodeReader_Start();
                        this.AllowSave = false;
                        this.DisplayClassList(false);
                        this.DisplayCustomerList(false);
                        this.timerMultilined.Enabled = true;
                        this.timerMultilined2.Enabled = true;
                    }
                    #endregion
                }
                else
                {
                    if (this.isValidReclassing())
                    {
                        this.DisplayClassList(true);
                    }
                }
            }
            else
            { 
                //Stock OPENING Operation
                if (this.isValidReclassing())
                {
                    this.GetClassOpening();
                    StockReclassBase.ServerActualProcessStockReclass();
                    #region Validate Result
                    if (CommonFunctions.NewLocSeqNo.Equals("S"))
                    {
                        this.ClearAll();
                        this.txtNewClass.Text = StockReclassBase.GetNewClass();
                        this.TagNo.Focus();
                        base.BarcodeReader_Start();
                        this.AllowSave = false;
                        this.DisplayClassList(false);
                        this.timerMultilined.Enabled = true;
                        this.timerMultilined2.Enabled = true;
                    }
                    #endregion
                }
            }

        }

        private void CancelButton(object sender, EventArgs e)
        {
            if (ExitButton == CommonEnum.Buttons.Cancel)
            {
                if (this.lstCustomerList.Visible.Equals(true) && CommonFunctions.IsBalanceClass)
                {
                    if (DialogResult.No == CommonFunctions.MessageShow(CommonMsg.Warning.d_NotifyNotSave, CommonEnum.NotificationType.Warning, CommonEnum.MessageButtons.YesNo))
                    {
                        return;
                    }
                    else
                    {
                        this.DisplayCustomerList(false);
                    }
                }

                if (this.lstClassList.Visible.Equals(true))
                {
                    this.DisplayClassList(false);
                    return;
                }
                if (!string.IsNullOrEmpty(CommonFunctions.StockClassCode))
                {
                    if (DialogResult.No == CommonFunctions.MessageShow(CommonMsg.Warning.d_NotifyNotSave, CommonEnum.NotificationType.Warning, CommonEnum.MessageButtons.YesNo))
                    {
                        return;
                    }
                }
                this.ClearAll();
                this.ExitButton = CommonEnum.Buttons.Exit;
                this.AllowSave = false;
                this.TagNo.Focus();
                base.BarcodeReader_Start();
            }
            else
            {
                this.ClosingWindow();
                this.Close();
            }
        }

        private void ClosingWindow()
        {
            try
            {
                this.timerMultilined.Enabled = false;
                this.timerMultilined2.Enabled = false;
                this.timerMultilined.Dispose();
                this.timerMultilined2.Dispose();
            }
            catch { }

            CommonFunctions.LocatorCode = string.Empty;
            CommonFunctions.LocatorDesc = string.Empty;
            this.ClearAll();
        }

        private void ClearAll()
        {
            this.txtNewClass.ScrollBars = ScrollBars.None;
            this.Class.ScrollBars = ScrollBars.None;
            //Commmon
            this.TagNo.Text = "";
            this.Dimension.Text = "";
            this.Specs.Text = "";
            this.Class.Text = "";
            this.txtNewClass.Text = "";
            this.RRNo.Text = "";
            //
            this.AvailableQty.Text = "";
            this.UnitAvailable.Text = "";
            this.LocatorCode.Text = "";
            this.LocatorCodeDesc.Text = "";
            CommonFunctions.ClearStrings();
            base.BarcodeReader_Start();
        }

        private void DisplayClassList(bool Visible)
        {
            //setting position
            this.panelClassList.Location = new System.Drawing.Point(6, 126);
            this.panelClassList.Size = new System.Drawing.Size(304, 142);
            this.panelClassList.Visible = Visible;
            if (Visible.Equals(true))
            {
                this.GetClassList();
                this.GetSelectedRow(this.lstClassList, true);
                this.KeyPreview = true;
                this.ActivatedWindow = ActivateWindow.Save;
                base.SetActiveButtons(BaseButtons.Save, BaseButtons.Cancel);
                this.lstClassList.Focus();
            }
            else
            {
                this.KeyPreview = false;
                this.TagNo.Focus();
                if (CommonFunctions.CurrentFunction.Equals(CommonEnum.Function.StockReclass))
                {
                    this.ActivatedWindow = ActivateWindow.Reclass;
                    base.SetActiveButtons(BaseButtons.Reclass, BaseButtons.Cancel);
                }
                else if (CommonFunctions.CurrentFunction.Equals(CommonEnum.Function.StockPackingOpennig))
                {
                    this.ActivatedWindow = ActivateWindow.Opening;
                    base.SetActiveButtons(BaseButtons.Open, BaseButtons.Cancel);
                }
            }
        }

        private void DisplayCustomerList(bool Visible)
        {
            //setting position
            CommonFunctions.CustomerCode = string.Empty;
            this.panelCustomerList.Location = new System.Drawing.Point(3, 36);
            this.panelCustomerList.Size = new System.Drawing.Size(314, 248);
            this.panelCustomerList.Visible = Visible;

            if (Visible.Equals(true))
            {
                this.GetCustomerList();
                this.GetSelectedRow(this.lstCustomerList, true);
                this.KeyPreview = true;
                this.ActivatedWindow = ActivateWindow.Save;
                base.SetActiveButtons(BaseButtons.Select, BaseButtons.Cancel);
                this.lstCustomerList.Focus();
            }
            else
            {
                this.KeyPreview = false;
                this.TagNo.Focus();
                if (CommonFunctions.CurrentFunction.Equals(CommonEnum.Function.StockReclass))
                {
                    this.ActivatedWindow = ActivateWindow.Reclass;
                    base.SetActiveButtons(BaseButtons.Reclass, BaseButtons.Cancel);
                }
                else if (CommonFunctions.CurrentFunction.Equals(CommonEnum.Function.StockPackingOpennig))
                {
                    this.ActivatedWindow = ActivateWindow.Opening;
                    base.SetActiveButtons(BaseButtons.Open, BaseButtons.Cancel);
                }
            }
        }

        private void GetClassList()
        {
            bool GreyBack = false;
            //clear recent
            lstClassList.Items.Clear();
            if (CommonFunctions.StockClassList == null)
                return;
            int Count = 0;
            DataTable DtStockClassList = CommonFunctions.StockClassList;
            Count = CommonFunctions.StockClassList.Rows.Count;
            int i = 0;
            if (Count > 0)
            {
                //populate
                foreach (DataRow row in DtStockClassList.Rows)
                {
                    ListViewItem listViewItem1 = new ListViewItem();
                    listViewItem1.Text = row["StockClassCode"].ToString().Trim();                          //STOCKCLASSCODE
                    listViewItem1.SubItems.Add(row["StockType"].ToString().Trim());                        //STOCKTYPE
                    listViewItem1.SubItems.Add(row["StockClassDesc"].ToString().Trim());    //STOCKCLASSDESC
                    this.lstClassList.Items.Add(listViewItem1);
                    if (GreyBack)
                    {
                        listViewItem1.ListView.Items[i].BackColor = Color.LightCyan;
                        listViewItem1.ListView.Items[i].ForeColor = Color.Black;
                        GreyBack = false;
                    }
                    else
                    {
                        listViewItem1.ListView.Items[i].BackColor = Color.White;
                        listViewItem1.ListView.Items[i].ForeColor = Color.Black;
                        GreyBack = true;
                    }
                    ++i;
                }
            }

            DtStockClassList.Dispose();

        }

        private void GetCustomerList()
        {
            bool GreyBack = false;
            //clear recent
            lstCustomerList.Items.Clear();
            if (CommonFunctions.CustomerList == null)
                return;
            int Count = 0;
            DataTable DtCustomerList = CommonFunctions.CustomerList;
            Count = CommonFunctions.CustomerList.Rows.Count;
            int i = 0;
            if (Count > 0)
            {
                //populate
                foreach (DataRow row in DtCustomerList.Rows)
                {
                    ListViewItem listViewItem1 = new ListViewItem();
                    listViewItem1.Text = row["CustomerCode"].ToString().Trim();                          
                    listViewItem1.SubItems.Add(row["CustomerName"].ToString().Trim());
                    this.lstCustomerList.Items.Add(listViewItem1);
                    if (GreyBack)
                    {
                        listViewItem1.ListView.Items[i].BackColor = Color.LightCyan;
                        listViewItem1.ListView.Items[i].ForeColor = Color.Black;
                        GreyBack = false;
                    }
                    else
                    {
                        listViewItem1.ListView.Items[i].BackColor = Color.White;
                        listViewItem1.ListView.Items[i].ForeColor = Color.Black;
                        GreyBack = true;
                    }
                    ++i;
                }
            }

            DtCustomerList.Dispose();
        }

        private void GetClassOpening()
        {
            if (CommonFunctions.StockClassList == null)
                return;
            int Count = 0;
            DataTable DtStockClassList = CommonFunctions.StockClassList;
            Count = CommonFunctions.StockClassList.Rows.Count;
            if (Count > 0)
            {
                //populate
                foreach (DataRow row in DtStockClassList.Rows)
                {
                    CommonFunctions.StockClassCodeNew = row["StockClassCode"].ToString().Trim();
                    CommonFunctions.StockClassNew = row["StockClassDesc"].ToString().Trim();
                }
            }

            DtStockClassList.Dispose();

        }

        private void GetSelectedRow(ListView SelectList, bool SelectFirstRow)
        {
            if (SelectList.Items != null)
            {
                if (SelectList.Items.Count > 0)
                {
                    if (SelectFirstRow)
                    {
                        SelectList.Items[0].Selected = true;
                        if (SelectList.Name.Equals("lstClassList"))
                        {
                            CommonFunctions.StockClassCodeNew = SelectList.Items[0].SubItems[0].Text.Trim();
                            CommonFunctions.StockClassNew = SelectList.Items[0].SubItems[2].Text.Trim();
                        }
                        else if (SelectList.Name.Equals("lstCustomerList"))
                        {
                            CommonFunctions.CustomerCode = SelectList.Items[0].SubItems[0].Text.Trim();
                        }
                    }
                    else
                    {
                        for (int i = 0; i < SelectList.Items.Count; i++)
                        {
                            if (SelectList.Items[i].Selected == true)
                            {
                                if (SelectList.Name.Equals("lstClassList"))
                                {
                                    CommonFunctions.StockClassCodeNew = SelectList.Items[i].SubItems[0].Text.Trim();
                                    CommonFunctions.StockClassNew = SelectList.Items[i].SubItems[2].Text.Trim();
                                }
                                else if (SelectList.Name.Equals("lstCustomerList"))
                                {
                                    CommonFunctions.CustomerCode = SelectList.Items[i].SubItems[0].Text.Trim();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void IsMultilined(TextBox txtBox, String txtContent)
        {
            //Set Properties
            if (txtContent.Length > 25)
            {
                txtBox.ScrollBars = ScrollBars.Vertical;
                txtBox.Multiline = true;
                txtBox.WordWrap = true;
                if (txtBox.Name.Equals("txtNewClass"))
                    this.timerMultilined.Enabled = true;
                else
                    this.timerMultilined2.Enabled = true;
                
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

                if (txtBox.Name.Equals("txtNewClass"))
                    this.timerMultilined.Enabled = false;
                else
                    this.timerMultilined2.Enabled = false;
            }
        }

        #endregion

        #region Overrides

        protected override void BaseWindow_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F14:
                    if (AllowSave == true)
                        SaveButton(this, e);
                    break;
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

        protected override void BarcodeReader_AnalyzeType(object Sender, EventArgs e)
        {
            base.BarcodeReader_AnalyzeType(Sender, e);

            switch (base.ScannedBarcodeType)
            {
                case CommonEnum.LabelType.Item2D:
                    {
                        if (CommonFunctions.IsConnected())
                        {
                            if (CommonFunctions.ScannedLabelForRepriting(false, false, this.LocatorCode.Text, string.Format("SR-H{0}", CommonFunctions.HandyNo)))
                                this.Reprint = true;
                            this.GetStockReclassRRInfo();
                            this.Reprint = false;
                        }
                    }
                    break;
                case CommonEnum.LabelType.Invalid:
                    {
                        this.ClearAll();
                        base.BarcodeReader_Start();
                        this.AllowSave = false;
                    }
                    break;
                case CommonEnum.LabelType.LocatorCode:
                    {
                        this.ClearAll();
                        this.LocatorCode.Text = CommonFunctions.LocatorCode;
                        this.LocatorCodeDesc.Text = CommonFunctions.LocatorDesc;
                        this.TagNo.Focus();
                        base.BarcodeReader_Start();
                        this.AllowSave = false;
                    }
                    break;
                case CommonEnum.LabelType.ServerNotFound:
                    {
                        this.ClearAll();
                        this.LocatorCodeDesc.Text = "";
                        this.LocatorCode.Text = "";
                        this.LocatorCode.Focus();
                        base.BarcodeReader_Start();
                        this.AllowSave = false;
                    }
                    break;
            }

            base.ScannedBarcodeType = CommonEnum.LabelType.Null;
        }

        #endregion

        #region Validations

        private bool isValidReclassing()
        {
            bool ret = true;
            if (CommonFunctions.StockClassList.Equals(null))
            {
                ret = false;
            }
            else
            {
                if (CommonFunctions.StockClassList.Rows.Count.Equals(0))
                {
                    ret = false;
                }
            }

            if (ret.Equals(false))
            {
                ClearAll();
                ExitButton = CommonEnum.Buttons.Exit;
                TagNo.Focus();
                base.BarcodeReader_Start();
                AllowSave = false;
                string msg = string.Empty;
                if (CommonFunctions.IsReclass)
                {
                    msg = CommonMsg.Warning.d_NonReclass;
                }
                else if (!CommonFunctions.IsReclass)
                {
                    msg = CommonMsg.Warning.d_NonValidOpening;
                }
                CommonFunctions.MessageShow(String.Format(msg, CommonFunctions.StockClass), CommonEnum.NotificationType.Warning);
            }

            return ret;

        }

        #endregion

        //Events
        private void StockReclassWindow_Load(object sender, EventArgs e)
        {
            this.SetDesignWindow();
            this.TagNo.Focus();
            this.AllowSave = false;
        }

        private void timerMultilined2_Tick(object sender, EventArgs e)
        {
            this.IsMultilined(this.Class, this.Class.Text);
        }

    }
}