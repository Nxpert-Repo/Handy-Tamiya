using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using Handy.Lib;

namespace Handy
{
    public partial class StockMovementWindow : BaseWindow
    {
        private static string TempReaderData = string.Empty;

        //public BarcodeReader BCReader;
        //private readonly ReaderData BCData;
        private CommonEnum.Buttons ExitButton = CommonEnum.Buttons.Exit;

        //private EventHandler BCReadNotifyHandler;

        public StockMovementWindow(BarcodeReader BCReader, ReaderData BCData)
        {
            InitializeComponent();
            base.SetBarcodeReader(BCReader, BCData);
            base.SetWindowTitle("Stock Movement");
            base.SetActiveButtons(BaseButtons.Save, BaseButtons.Cancel);
            CommonInterfaceFunctions.WLANAddSignalQualityHandler(base.pcbSignal, true);

            base.BarcodeReader_Start();
            this.BCReadNotifyHandler = new EventHandler(Reader_ReadNotify);
            this.AttachReadNotify(BCReadNotifyHandler);
        }

        private void HandleData(ReaderData BarcodeValue)
        {
            switch (CommonFunctions.IdentifyBarcode(BarcodeValue.Text, BarcodeValue.Type.ToString()))
            {
                case CommonEnum.LabelType.Item2D:
                    {
                        if (!string.IsNullOrEmpty(CommonFunctions.LocatorCode))
                        {
                            CommonFunctions.ScannedLabelForReprinting(false, false, CommonFunctions.LocatorCode, string.Format("SM-H{0}", CommonFunctions.HandyNo));
                            GetStockMovementRRInfo();
                        }
                        else
                        {
                            CommonFunctions.MessageShow(string.Empty
                                                        , CommonMsg.Warning.ScanLocator
                                                        , CommonEnum.NotificationType.Warning);
                            ClearAll();
                            base.BarcodeReader_Start();
                        }
                    }
                    break;
                case CommonEnum.LabelType.ItemLinear:
                    {
                        if (!string.IsNullOrEmpty(CommonFunctions.LocatorCode))
                            GetStockMovementRRInfo();
                        else
                        {

                            CommonFunctions.MessageShow(string.Empty
                                                        , CommonMsg.Warning.ScanLocator
                                                        , CommonEnum.NotificationType.Warning);
                            ClearAll();
                            base.BarcodeReader_Start();
                        }
                    }
                    break;
                case CommonEnum.LabelType.Invalid:
                    {
                        ClearAll();
                        LocatorCodeDesc.Text = "";
                        LocatorCode.Text = "";
                        LocatorCode.Focus();
                        LocatorCode.SelectAll();
                        base.BarcodeReader_Start();
                    }
                    break;
                case CommonEnum.LabelType.LocatorCode:
                    {
                        ClearAll();
                        LocatorCode.Text = CommonFunctions.LocatorCode;
                        LocatorCodeDesc.Text = CommonFunctions.LocatorDesc;
                        StockCode.Focus();
                        base.BarcodeReader_Start();
                    }
                    break;
                case CommonEnum.LabelType.ServerNotFound:
                    {
                        ClearAll();
                        LocatorCodeDesc.Text = "";
                        LocatorCode.Text = "";
                        LocatorCode.Focus();
                        base.BarcodeReader_Start();
                    }
                    break;
                default:
                    {
                        ClearAll();
                        LocatorCodeDesc.Text = "";
                        LocatorCode.Text = "";
                        LocatorCode.Focus();
                        base.BarcodeReader_Start();
                    }
                    break;
            }
        }

        private void GetStockMovementRRInfo()
        {
            if (CommonFunctions.IsStockMovementRRInfoGenerated())
            {
                StockCode.Text = CommonFunctions.TagNo;                
                RRNo.Text = CommonFunctions.RRNoDisplay;

                //
                AvailableQty.Text = CommonFunctions.AvailableQty.ToString();
                TransferredQty.Text = CommonFunctions.AvailableQty.ToString();
                UnitAvailable.Text = CommonFunctions.Unit;
                UnitTransferred.Text = CommonFunctions.Unit;                

                //
                ExitButton = CommonEnum.Buttons.Cancel;
                TransferredQty.ReadOnly = false;
                TransferredQty.Focus();
                TransferredQty.SelectAll();
            }
            else
            {
                ClearAll();
                StockCode.Focus();
                StockCode.SelectAll();
                TransferredQty.ReadOnly = true;
                base.BarcodeReader_Start();
            }
        }
        
        private void SaveButton(object sender, EventArgs e)
        {
            if (CommonFunctions.isInputValid(TransferredQty.Text, CommonFunctions.ConvertStringDecimal(CommonFunctions.BarcodeQuantity), true))
            {
                CommonFunctions.InputQty = CommonFunctions.ConvertStringDecimal(TransferredQty.Text);
                
                    StockMovementBase.ServerActualProcessStockMovement();
                    //Nilo Added to berify if scanned label is updated <06/07/2012>
                    CommonFunctions.ScannedLabelForReprinting(false, true, "", "SM-H" + CommonFunctions.HandyNo);
                    //Commmon

                    ClearAll();
                    ExitButton = CommonEnum.Buttons.Exit;
                    StockCode.Focus();
                    base.BarcodeReader_Start();            
            }
            else
            {
                TransferredQty.Focus();
                TransferredQty.SelectAll();
            }
        }

        private void StockMovementForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ClearAll();
            CommonFunctions.LocatorCode = string.Empty;
            CommonFunctions.LocatorDesc = string.Empty;
            //this.StopRead();
            this.DetachReadNotify();
        }

        private void StockMovementForm_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                //Nilo Added : Label Indicator <05/25/2012>
                case Keys.ControlKey:
                    CommonFunctions.MessageShow(string.Format(CommonMsg.Info.ScannedLabelCount, CommonFunctions.getBatchNo(false))
                                                , CommonEnum.NotificationType.Information); //GET COUNT OF BATCH SCANNED
                    break;
                case Keys.Space:
                    CommonFunctions.getBatchNo(true);
                    CommonFunctions.MessageShow(CommonMsg.Info.RefreshCount, CommonEnum.NotificationType.Information); //REFRESH COUNT
                    // NEW BATCH NO
                    break;
                //end
                case Keys.F1:
                case Keys.F14:
                    if (base.lblBtnLeft.Enabled == true && !e.Handled)
                    {
                        SaveButton(this, e);
                        e.Handled = true;
                    }
                    break;
                case Keys.F4:
                case Keys.F15:
                    if (base.lblBtnRight.Enabled == true)
                        CancelButton(this, e);
                    break;
            }
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
                
                StockCode.Focus();
                //StartRead();
            }
            else
                Close();

        }

        private void ClearAll()
        {
            //Commmon
            StockCode.Text = string.Empty;
            //Dimension.Text = "";
            //Specs.Text = "";
            //Mill.Text = "";
            //Works.Text = "";
            //Class.Text = "";
            RRNo.Text = string.Empty;

            //
            AvailableQty.Text = string.Empty;
            TransferredQty.Text = string.Empty;
            UnitAvailable.Text = string.Empty;
            UnitTransferred.Text = string.Empty;
            //OldLocatorCode.Text = "";
            //OldLocatorCodeDesc.Text = "";

            CommonFunctions.ClearStrings();
        }

        private void StockMovementForm_Load(object sender, EventArgs e)
        {
            LocatorCode.Focus();
        }

        private void TransQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumberFormatInfo numberFormatInfo = CultureInfo.CurrentCulture.NumberFormat;
            string decimalSeparator = numberFormatInfo.NumberDecimalSeparator;

            string keyInput = e.KeyChar.ToString();

            if ((!CommonFunctions.isDecimal()) && (Char.IsDigit(e.KeyChar) || e.KeyChar == '\b'))
                e.Handled = false;
            else if ((CommonFunctions.isDecimal()) && (Char.IsDigit(e.KeyChar) || keyInput.Equals(decimalSeparator) || e.KeyChar == '\b'))
                if (TransferredQty.Text.IndexOf('.') != -1)
                    //allows digit and backspace
                    if (Char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
                        e.Handled = false;
                    else
                        e.Handled = true;
                else
                    e.Handled = false;
            else
                e.Handled = true;
        }

        protected override void lblBtnRight_Click(object sender, EventArgs e)
        {
            KeyEventArgs KeyArgs = new KeyEventArgs(Keys.F4);
            this.StockMovementForm_KeyUp(sender, KeyArgs);
        }

        #region Barcode

        private void Reader_ReadNotify(object Sender, EventArgs e)
        {
            // Checks if the Invoke method is required because the ReadNotify delegate is called by a different thread
            if (this.InvokeRequired)
            {
                // Executes the ReadNotify delegate on the main thread
                this.Invoke(BCReadNotifyHandler, new object[] { Sender, e });
            }
            else
            {
                // Get ReaderData
                ReaderData TheReaderData = BCReader.GetNextReaderData();

                switch (TheReaderData.Result)
                {
                    case Results.SUCCESS:
                        {
                            HandleData(TheReaderData);
                        }
                        break;
                    case Results.E_SCN_READTIMEOUT:
                        {
                            //this.StartRead();
                        }
                        break;
                    case Results.CANCELED:
                        break;
                    case Results.E_SCN_DEVICEFAILURE:
                        //this.StopRead();
                        //this.StartRead();
                        break;
                    default:
                        string sMsg = "Read Failed\n" + "Result = " + (TheReaderData.Result).ToString();
                        CommonFunctions.MessageShow(sMsg, CommonEnum.NotificationType.Error, CommonEnum.MessageButtons.CloseOnly);
                        if (TheReaderData.Result == Results.E_SCN_READINCOMPATIBLE)
                        {
                            // If the failure is E_SCN_READINCOMPATIBLE, exit the application.
                            CommonFunctions.MessageShow(Handy.Properties.Resources.AppExitMsg, Handy.Properties.Resources.Failure, CommonEnum.NotificationType.Error, CommonEnum.MessageButtons.CloseOnly);
                            this.Close();
                            return;
                        }
                        break;
                }
            }
        }

        private void AttachReadNotify(System.EventHandler ReadNotifyHandler)
        {
            // If we have a reader
            if (BCReader != null)
            {
                // Attach the read notification handler.
                BCReader.ReadNotify += ReadNotifyHandler;
                BCReadNotifyHandler = ReadNotifyHandler;
            }
        }

        private void DetachReadNotify()
        {
            if ((BCReader != null) && (BCReadNotifyHandler != null))
            {
                // Detach the read notification handler.
                BCReader.ReadNotify -= BCReadNotifyHandler;
                BCReadNotifyHandler = null;
            }
        }

        // Commented by DEV1521-Francis 
        // Purpose: For Keyence device, we don't anymore use Symbol
        //private void StartRead()
        //{
        //    // If we have both a reader and a reader data
        //    if ((BCReader != null) &&
        //        (BCData != null))

        //        try
        //        {   // Submit a read.
        //            if (!BCData.IsPending)
        //                BCReader.Actions.Read(BCData);
        //        }

        //        catch (Symbol.Exceptions.OperationFailureException ex)
        //        {
        //            CommonFunctions.MessageShow(Handy.Properties.Resources.StartRead + "\n" +
        //                Handy.Properties.Resources.OperationFailure + "\n" + ex.Message +
        //                "\n" +
        //                Handy.Properties.Resources.Result + " = " + (Symbol.Results)((uint)ex.Result), CommonEnum.NotificationType.Error);
        //        }
        //        catch (Symbol.Exceptions.InvalidRequestException ex)
        //        {
        //            CommonFunctions.MessageShow(Handy.Properties.Resources.StartRead + "\n" +
        //                Handy.Properties.Resources.InvalidRequest + "\n" +
        //                ex.Message, CommonEnum.NotificationType.Error);

        //        }
        //        catch (Symbol.Exceptions.InvalidIndexerException ex)
        //        {
        //            CommonFunctions.MessageShow(Handy.Properties.Resources.StartRead + "\n" +
        //                Handy.Properties.Resources.InvalidIndexer + "\n" +
        //                ex.Message, CommonEnum.NotificationType.Error);
        //        };
        //}

        // Commented by DEV1521-Francis 
        // Purpose: For Keyence device, we don't anymore use Symbol
        //private void StopRead()
        //{
        //    //If we have a reader
        //    if (BCReader != null)
        //    {
        //        try
        //        {
        //            // Flush (Cancel all pending reads).
        //            if (BCReader.Info.SoftTrigger == true)
        //            {
        //                BCReader.Info.SoftTrigger = false;
        //            }
        //            BCReader.Actions.Flush();
        //        }

        //        catch (Symbol.Exceptions.OperationFailureException ex)
        //        {
        //            CommonFunctions.MessageShow(Handy.Properties.Resources.StopRead + "\n" +
        //                Handy.Properties.Resources.OperationFailure + "\n" + ex.Message +
        //                "\n" +
        //                Handy.Properties.Resources.Result + " = " + (Symbol.Results)((uint)ex.Result), CommonEnum.NotificationType.Error);
        //        }
        //        catch (Symbol.Exceptions.InvalidRequestException ex)
        //        {
        //            CommonFunctions.MessageShow(Handy.Properties.Resources.StopRead + "\n" +
        //                Handy.Properties.Resources.InvalidRequest + "\n" +
        //                ex.Message, CommonEnum.NotificationType.Error);
        //        }
        //        catch (Symbol.Exceptions.InvalidIndexerException ex)
        //        {
        //            CommonFunctions.MessageShow(Handy.Properties.Resources.StopRead + "\n" +
        //                Handy.Properties.Resources.InvalidIndexer + "\n" +
        //                ex.Message, CommonEnum.NotificationType.Error);

        //        };
        //    }
        //}

        #endregion       

        protected override void BarcodeReader_AnalyzeType(object Sender, EventArgs e)
        {
            base.GetRawBarcodeValue = false;
            base.BarcodeReader_AnalyzeType(Sender, e);
            
            switch (base.ScannedBarcodeType)
            {
                case CommonEnum.LabelType.LocatorCode:
                    {
                        LocatorCode.Text = CommonFunctions.BarcodeLocatorCode;
                        break;
                    }
                case CommonEnum.LabelType.Item2D:
                    {                                             
                        string query = string.Empty;                            
                        StockCode.Text = CommonFunctions.BarcodeStockCode;                            
                        RRNo.Text = CommonFunctions.BarcodeRRNo;
                        AvailableQty.Text = String.Format("{0:N2}", CommonFunctions.BarcodeQuantity);
                        //TransferredQty.Text = TransferredQty.Text.Equals(string.Empty) ? "1" : (int.Parse(TransferredQty.Text) + 1).ToString();
                        TransferredQty.Text = CommonFunctions.BarcodeQuantity;
                        UnitAvailable.Text = UnitTransferred.Text = CommonFunctions.BarcodeUnit;                        
                        //BCData.Dispose();                        
                        break;
                    }
            }            
        }        
    }
}