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

    public partial class MaterialAdjustmentWindow : Form
    {
        private static string TempReaderData = string.Empty;

        public BarcodeReader BCReader = null;
        private ReaderData BCData = null;
        private CommonEnum.Buttons ExitButton = CommonEnum.Buttons.Exit;

        private EventHandler BCReadNotifyHandler = null;

        public MaterialAdjustmentWindow(BarcodeReader BCReader, ReaderData BCData)
        {
            InitializeComponent();
            this.BCReader = BCReader;
            this.BCData = BCData;

            this.StartRead();

            this.BCReadNotifyHandler = new EventHandler(Reader_ReadNotify);
            this.AttachReadNotify(BCReadNotifyHandler);
        }

        private void MaterialAdjustmentWindow_Closing(object sender, CancelEventArgs e)
        {
            ClearAll();

            CommonInterfaceFunctions.WLANRemoveSignalQualityHandler();

            CommonFunctions.LocatorCode = string.Empty;
            CommonFunctions.LocatorDesc = string.Empty;
            StopRead();
            DetachReadNotify();
        }

        private void HandleData(ReaderData BarcodeValue)
        {
            switch (CommonFunctions.IdentifyBarcode(BarcodeValue.Text, BarcodeValue.Type.ToString()))
            {
                case CommonEnum.LabelType.Item2D:
                    {
                        CommonFunctions.ScannedLabelForReprinting(false, false, CommonFunctions.LocatorCode, string.Format("MA-H{0}", CommonFunctions.HandyNo));
                        GetMaterialAdjustmentRRInfo();
                    }
                    break;
                case CommonEnum.LabelType.ItemLinear:
                    {
                        GetMaterialAdjustmentRRInfo();
                    }
                    break;
                case CommonEnum.LabelType.Invalid:
                    {
                        ClearAll();
                        TagNo.Focus();
                        TagNo.SelectAll();
                        StartRead();
                    }
                    break;
                case CommonEnum.LabelType.ServerNotFound:
                    {
                        ClearAll();
                        TagNo.Focus();
                        TagNo.SelectAll();
                        StartRead();
                    }
                    break;
                default:
                    {
                        ClearAll();
                        TagNo.Focus();
                        TagNo.SelectAll();
                        StartRead();
                    }
                    break;
            }
        }

        private void GetMaterialAdjustmentRRInfo()
        {
            if (CommonFunctions.IsMaterialAdjustmentRRInfoGenerated())
            {

                //Nilo Added to berify if scanned label is updated <06/07/2012>
                CommonFunctions.ScannedLabelForReprinting(false, true, "", "MA-H" + CommonFunctions.HandyNo);

                // Commmon
                TagNo.Text = CommonFunctions.TagNo;
                Dimension.Text = CommonFunctions.Dimension;
                Specs.Text = CommonFunctions.Specs;
                //Mill.Text = CommonFunctions.Mill;
                //Works.Text = CommonFunctions.Works;
                Class.Text = CommonFunctions.StockClass;
                RRNo.Text = CommonFunctions.RRNoDisplay;

                //
                ReceivedQty.Text = CommonFunctions.ReceivedQty.ToString("#");
                ReservedQty.Text = CommonFunctions.ReservedQty.ToString("#");
                AvailableQty.Text = CommonFunctions.AvailableQty.ToString("#");
                ActualQty.Text = CommonFunctions.ExpectedActualQty.ToString("#");
                UnitReceived.Text = CommonFunctions.Unit;
                UnitReserved.Text = CommonFunctions.Unit;
                UnitAvailable.Text = CommonFunctions.Unit;
                UnitActual.Text = CommonFunctions.Unit;
                VarianceQty.Text = "";
                VarianceDesc.Text = "";

                //
                ExitButton = CommonEnum.Buttons.Cancel;

                ActualQty.Focus();
                ActualQty.SelectAll();
            }
            else
            {
                ClearAll();
                TagNo.Focus();
                TagNo.SelectAll();
                StartRead();
            }
        }

        private void MaterialAdjustmentWindow_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                //Nilo Added : Label Indicator <05/25/2012>
                case Keys.F2:
                case Keys.ControlKey:
                    CommonFunctions.MessageShow(string.Format(CommonMsg.Info.ScannedLabelCount, CommonFunctions.getBatchNo(false))
                                                , CommonEnum.NotificationType.Information); //GET COUNT OF BATCH SCANNED
                    break;
                case Keys.Back:
                case Keys.Space:
                    CommonFunctions.getBatchNo(true);
                    CommonFunctions.MessageShow(CommonMsg.Info.RefreshCount, CommonEnum.NotificationType.Information); //REFRESH COUNT
                    // NEW BATCH NO
                    break;
                //end
                case Keys.F1:
                case Keys.F14:
                    if (SaveButtonLabel.Enabled == true)
                        SaveButton(this, e);
                    break;
                case Keys.F4:
                case Keys.F15:
                    CancelButton(this, e);
                    break;
            }
        }

        private void SaveButton(object sender, EventArgs e)
        {
            if (!(CommonFunctions.ConvertStringDecimal(ActualQty.Text) == CommonFunctions.ExpectedActualQty))
                if (CommonFunctions.isInputValid(ActualQty.Text, CommonFunctions.ExpectedActualQty, false))
                {
                    MaterialAdjustmentBase.ServerActualProcessMaterialAdjustment();
                    TagNo.Focus();
                    TagNo.SelectAll();
                    ClearAll();
                }
                else
                {
                    ActualQty.Focus();
                    ActualQty.SelectAll();
                }
            else
                ClearAll();
        }

        private void CancelButton(object sender, EventArgs e)
        {
            if (ExitButton == CommonEnum.Buttons.Cancel)
            {
                ClearAll();
                ExitButton = CommonEnum.Buttons.Exit;
                TagNo.Focus();
                StartRead();
            }
            else
                Close();
        }

        private void ClearAll()
        {
            //Commmon
            TagNo.Text = "";
            Dimension.Text = "";
            Specs.Text = "";
            //Mill.Text = "";
            //Works.Text = "";
            Class.Text = "";
            RRNo.Text = "";

            //
            ReceivedQty.Text = "";
            ReservedQty.Text = "";
            AvailableQty.Text = "";
            ActualQty.Text = "";
            UnitReceived.Text = "";
            UnitReserved.Text = "";
            UnitAvailable.Text = "";
            UnitActual.Text = "";
            VarianceQty.Text = "";
            VarianceDesc.Text = "";

            CommonFunctions.ClearStrings();
            RRNo.Focus();
            StartRead();

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
                ReaderData TheReaderData = this.BCReader.GetNextReaderData();


                switch (TheReaderData.Result)
                {
                    case Results.SUCCESS:
                        {
                            HandleData(TheReaderData);
                            this.StartRead();
                        }
                        break;

                    case Results.E_SCN_READTIMEOUT:
                        {
                            this.StartRead();
                        }
                        break;

                    case Results.CANCELED:

                        break;

                    case Results.E_SCN_DEVICEFAILURE:

                        this.StopRead();
                        this.StartRead();
                        break;

                    default:

                        string sMsg = "Read Failed\n"
                            + "Result = "
                            + (TheReaderData.Result).ToString();

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

        private void StartRead()
        {
            // If we have both a reader and a reader data
            if ((BCReader != null) &&
                (BCData != null))

                try
                {
                    if (!BCData.IsPending)
                    {
                        // Submit a read.
                        BCReader.Actions.Read(BCData);
                    }
                }
                catch { }
                //catch (Symbol.Exceptions.OperationFailureException ex)
                //{
                //    CommonFunctions.MessageShow(Handy.Properties.Resources.StartRead + "\n" +
                //        Handy.Properties.Resources.OperationFailure + "\n" + ex.Message +
                //        "\n" +
                //        Handy.Properties.Resources.Result + " = " + (Symbol.Results)((uint)ex.Result), CommonEnum.NotificationType.Error);
                //}
                //catch (Symbol.Exceptions.InvalidRequestException ex)
                //{
                //    CommonFunctions.MessageShow(Handy.Properties.Resources.StartRead + "\n" +
                //        Handy.Properties.Resources.InvalidRequest + "\n" +
                //        ex.Message, CommonEnum.NotificationType.Error);

                //}
                //catch (Symbol.Exceptions.InvalidIndexerException ex)
                //{
                //    CommonFunctions.MessageShow(Handy.Properties.Resources.StartRead + "\n" +
                //        Handy.Properties.Resources.InvalidIndexer + "\n" +
                //        ex.Message, CommonEnum.NotificationType.Error);

                //};
        }

        private void StopRead()
        {
            //If we have a reader
            if (BCReader != null)
            {
                try
                {
                    // Flush (Cancel all pending reads).
                    if (BCReader.Info.SoftTrigger == true)
                    {
                        BCReader.Info.SoftTrigger = false;
                    }
                    BCReader.Actions.Flush();
                }
                catch {}
                //catch (Symbol.Exceptions.OperationFailureException ex)
                //{
                //    CommonFunctions.MessageShow(Handy.Properties.Resources.StopRead + "\n" +
                //        Handy.Properties.Resources.OperationFailure + "\n" + ex.Message +
                //        "\n" +
                //        Handy.Properties.Resources.Result + " = " + (Symbol.Results)((uint)ex.Result), CommonEnum.NotificationType.Error);
                //}
                //catch (Symbol.Exceptions.InvalidRequestException ex)
                //{
                //    CommonFunctions.MessageShow(Handy.Properties.Resources.StopRead + "\n" +
                //        Handy.Properties.Resources.InvalidRequest + "\n" +
                //        ex.Message, CommonEnum.NotificationType.Error);
                //}
                //catch (Symbol.Exceptions.InvalidIndexerException ex)
                //{
                //    CommonFunctions.MessageShow(Handy.Properties.Resources.StopRead + "\n" +
                //        Handy.Properties.Resources.InvalidIndexer + "\n" +
                //        ex.Message, CommonEnum.NotificationType.Error);
                //};
            }
        }

        #endregion

        private void ActualQty_TextChanged(object sender, EventArgs e)
        {
            if (CommonFunctions.ConvertStringDecimal(ActualQty.Text) == CommonFunctions.ExpectedActualQty || string.IsNullOrEmpty(ActualQty.Text))
            {
                SaveButtonLabel.Enabled = false;
                VarianceQty.Text = "";
                VarianceDesc.Text = "";
            }
            else
            {
                SaveButtonLabel.Enabled = true;
                VarianceQty.Text = CommonFunctions.GetVarianceQty(CommonFunctions.ConvertStringDecimal(ActualQty.Text), CommonFunctions.ExpectedActualQty).ToString("f2").Trim();
                VarianceDesc.Text = CommonFunctions.VarianceDesc;
            }
        }

        private void MaterialAdjustmentWindow_Load(object sender, EventArgs e)
        {
            CommonInterfaceFunctions.WLANAddSignalQualityHandler(this.pbSignalStrength);
            TagNo.Focus();
        }

        # region removed

        //private void PressF4()
        //{
        //    const byte VK_F4 = 0x73;
        //    const int KEYEVENTF_KEYUP = 0x2;
        //    const int KEYEVENTF_KEYDOWN = 0x0;
        //    keybd_event(VK_F4, 0, KEYEVENTF_KEYDOWN, 0);
        //    keybd_event(VK_F4, 0, KEYEVENTF_KEYUP, 0);
        //}

        //[DllImport("coredll.dll", SetLastError = true)]
        //static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        #endregion
    }
}