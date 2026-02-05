using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Globalization;
using System.Windows.Forms;
using Handy.Lib;

namespace Handy
{
    public partial class JobStartWindow : BaseWindow
    {
        #region Variables

        private bool Reprint = false;
        public CommonEnum.Buttons ExitButton = CommonEnum.Buttons.Exit;
        
        enum TxtScroll
        {
            Up,
            Down
        }
        TxtScroll Scroll = TxtScroll.Up;

        #endregion

        #region Constructor

        public JobStartWindow(Symbol.Barcode.Reader BCReader, Symbol.Barcode.ReaderData BCData)
        {
            InitializeComponent();
            base.SetBarcodeReader(BCReader, BCData);
            base.SetWindowTitle("Job Start");
            base.SetActiveButtons(BaseButtons.Start, BaseButtons.Cancel);
            CommonInterfaceFunctions.WLANAddSignalQualityHandler(base.pcbSignal, true);
        }

        #endregion

        #region Functions

        private void GetJobStartRRInfo()
        {
            if (CommonFunctions.IsJobStartRRInfoGenerated()) 
            {
                if (this.Reprint)
                {
                    base.BarcodeReader_Stop();
                    CommonFunctions.MessageShow(String.Format(CommonMsg.Warning.d_ReprintOutdated, CommonFunctions.TagNo), CommonEnum.NotificationType.Warning);
                    this.ClearAll();
                }
                else
                {

                    //Commmon
                    TagNo.Text = CommonFunctions.TagNo;
                    Dimension.Text = CommonFunctions.Dimension;
                    Specs.Text = CommonFunctions.Specs;
                    Class.Text = CommonFunctions.StockClass;
                    RRNo.Text = CommonFunctions.RRNoDisplay;
                    Weight.Text = CommonFunctions.BarcodeQuantity;
                    UnitWeight.Text = CommonFunctions.Unit;
                    CommonFunctions.GetLocatorInfo(CommonFunctions.OldLocatorCode);
                    LocatorCode.Text = CommonFunctions.LocatorCode;
                    LocatorCodeDesc.Text = CommonFunctions.LocatorDesc;
                    ExitButton = CommonEnum.Buttons.Cancel;
                    TagNo.Focus();
                    this.timerMultilined.Enabled = true;
                }
            }
            else
            {
                ClearAll();
                TagNo.Focus();
                TagNo.SelectAll();
            }

            base.BarcodeReader_Start();
        }

        private void SaveButton(object sender, EventArgs e)
        {
            base.BarcodeReader_Stop();

            if (!string.IsNullOrEmpty(CommonFunctions.BarcodeJobSheetNo))
            {
                if (JobStartBase.IsJobSheetUpdated())
                {
                    ClearAll();
                    ExitButton = CommonEnum.Buttons.Exit;
                    JobSheetNo.Text = "";
                    JobSheetNo.Focus();
                }
            }

            base.BarcodeReader_Start();
        }

        private void CancelButton(object sender, EventArgs e)
        {
            if (ExitButton == CommonEnum.Buttons.Cancel)
            {
                if (DialogResult.No == CommonFunctions.MessageShow(CommonMsg.Warning.d_NotifyNotSave, CommonEnum.NotificationType.Warning, CommonEnum.MessageButtons.YesNo))
                {
                    return;
                }
                ClearAll();
                ExitButton = CommonEnum.Buttons.Exit;
                TagNo.Focus();
                base.BarcodeReader_Start();
            }
            else
                Close();
        }

        private void ClearAll()
        {
            Class.ScrollBars = ScrollBars.None;
            //
            TagNo.Text = "";
            Dimension.Text = "";
            Weight.Text = "";
            Specs.Text = "";
            Class.Text = "";
            RRNo.Text = "";
            //
            Weight.Text = "";
            UnitWeight.Text = "";
            LocatorCode.Text = "";
            LocatorCodeDesc.Text = "";
            CommonFunctions.ClearStrings();
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

        #endregion

        #region Override

        protected override void BarcodeReader_AnalyzeType(object Sender, EventArgs e)
        {

            base.BarcodeReader_AnalyzeType(Sender, e);

            switch (base.ScannedBarcodeType)
            {
                case CommonEnum.LabelType.JobSheetNo:
                    {
                        ClearAll();
                        JobSheetNo.Text = CommonFunctions.BarcodeJobSheetNo;
                        TagNo.Focus();
                        base.BarcodeReader_Start();
                    }
                    break;
                case CommonEnum.LabelType.Item2D:
                    {
                        if (!string.IsNullOrEmpty(CommonFunctions.BarcodeJobSheetNo))
                        {
                            if (CommonFunctions.IsConnected())
                            {
                                if (CommonFunctions.ScannedLabelForRepriting(false, false, this.LocatorCode.Text, string.Format("JS-H{0}", CommonFunctions.HandyNo)))
                                    this.Reprint = true;
                                this.GetJobStartRRInfo();
                                this.Reprint = false;
                            }
                        }
                        else
                        {
                            CommonFunctions.MessageShow(string.Empty
                                                        , CommonMsg.Warning.ScanJS
                                                        , CommonEnum.NotificationType.Warning
                                                        , CommonEnum.MessageButtons.CloseOnly);
                            ClearAll();
                            base.BarcodeReader_Start();
                        }
                    }
                    break;
                case CommonEnum.LabelType.Invalid:
                    {
                        ClearAll();
                        base.BarcodeReader_Start();
                    }
                    break;
                case CommonEnum.LabelType.ServerNotFound:
                    {
                        ClearAll();
                        JobSheetNo.Text = "";
                        JobSheetNo.Focus();
                        base.BarcodeReader_Start();
                    }
                    break;
            }

            base.ScannedBarcodeType = Handy.Lib.CommonEnum.LabelType.Null;
        }

        protected override void BaseWindow_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F14:
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

        #endregion

        //Events

        private void JobStartWindow_Load(object sender, EventArgs e)
        {
            CommonFunctions.CurrentFunction = CommonEnum.Function.JobStart;
            JobSheetNo.Focus();
        }

        private void JobStartWindow_Closing(object sender, CancelEventArgs e)
        {
            this.timerMultilined.Enabled = false;
            ClearAll();
            CommonFunctions.BarcodeJobSheetNo = string.Empty;
            CommonFunctions.LocatorCode = string.Empty;
            CommonFunctions.LocatorDesc = string.Empty;
            try
            {
                this.timerMultilined.Dispose();
            }
            catch { }
        }

        private void timerMultilined_Tick(object sender, EventArgs e)
        {
            this.IsMultilined(this.Class, this.Class.Text);
        }
    }
}
