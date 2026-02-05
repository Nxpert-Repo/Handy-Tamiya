using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Handy
{
    public partial class TestWindow : Handy.BaseWindow
    {
        public TestWindow(BarcodeReader BCReader, ReaderData BCData)
        {
            InitializeComponent();
            BaseWindow.EnableMultiScan = true;  // enable multicode scanning
            base.BarcodeReader_Initialize();
            base.SetBarcodeReader(this.BCReader, this.BCData);
            base.SetWindowTitle("Test Window");
            base.SetActiveButtons(BaseButtons.Ok, BaseButtons.Cancel);
        }

        private void DisplayBarcodeInfo(String Type)
        {
            this.txtBarcodeType.Text = Type;
            this.txtBarcodeContent.Text = base.BarcodeTextData;
        }

        protected override void BaseWindow_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {

                case Keys.F1:  // Keyence 
                case Keys.F14: // Motorola
                    Handy.Lib.CommonFunctions.MessageShow("Start Scan!", Handy.Lib.CommonEnum.NotificationType.Success);
                    base.BarcodeReader_Start();
                    break;
                case Keys.F4:  // Keyence
                case Keys.F15: // Motorola
                    base.BarcodeReader_Stop();
                    if (!base.CloseWindow)
                        Handy.Lib.CommonFunctions.MessageShow("Cancel!", Handy.Lib.CommonEnum.NotificationType.Success);
                    Close();
                    break;
            }

            base.BaseWindow_KeyUp(sender, e);
        }

        protected override void BarcodeReader_AnalyzeType(object Sender, EventArgs e)
        {
            base.BarcodeReader_AnalyzeType(Sender, e);

            switch (base.ScannedBarcodeType)
            {
                case Handy.Lib.CommonEnum.LabelType.LocatorCode:
                    Handy.Lib.CommonFunctions.MessageShow("Locator!", Handy.Lib.CommonEnum.NotificationType.Success);
                    this.DisplayBarcodeInfo("Locator");
                    break;
                case Handy.Lib.CommonEnum.LabelType.Item2D:
                    Handy.Lib.CommonFunctions.MessageShow("Item!", Handy.Lib.CommonEnum.NotificationType.Success);
                    this.DisplayBarcodeInfo("Item");
                    break;
                case Handy.Lib.CommonEnum.LabelType.ItemLinear:
                    Handy.Lib.CommonFunctions.MessageShow("Item Linear!", Handy.Lib.CommonEnum.NotificationType.Success);
                    this.DisplayBarcodeInfo("Item [Linear]");
                    break;
                case Handy.Lib.CommonEnum.LabelType.JobSheetNo:
                    Handy.Lib.CommonFunctions.MessageShow("Job Sheet!", Handy.Lib.CommonEnum.NotificationType.Success);
                    this.DisplayBarcodeInfo("Job Sheet");
                    break;
                case Handy.Lib.CommonEnum.LabelType.WIP:
                    Handy.Lib.CommonFunctions.MessageShow("WIP!", Handy.Lib.CommonEnum.NotificationType.Success);
                    this.DisplayBarcodeInfo("WIP");
                    break;
                case Handy.Lib.CommonEnum.LabelType.WRISNo:
                    Handy.Lib.CommonFunctions.MessageShow("WRIS!", Handy.Lib.CommonEnum.NotificationType.Success);
                    this.DisplayBarcodeInfo("Other");
                    break;
                case Handy.Lib.CommonEnum.LabelType.Invalid:
                default:
                    Handy.Lib.CommonFunctions.MessageShow("Other", Handy.Lib.CommonEnum.NotificationType.Success);
                    this.DisplayBarcodeInfo("Not Recognized Type");
                    break;

            }
            base.ScannedBarcodeType = Handy.Lib.CommonEnum.LabelType.Null;
        }

        private void TestWindow_Closed(object sender, EventArgs e)
        {
            BaseWindow.EnableMultiScan = false;
        }
    }
}