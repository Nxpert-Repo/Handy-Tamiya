using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Handy.Lib;

namespace Handy
{
    public partial class BarcodeTestWindow : BaseWindow
    {
        #region Variables

        private CommonEnum.Buttons ExitButton = CommonEnum.Buttons.Exit;
        
        #endregion

        #region Constructor

        public BarcodeTestWindow(BarcodeReader BCReader, ReaderData BCData)
        {
            InitializeComponent();
            base.SetBarcodeReader(BCReader, BCData);
            base.SetWindowTitle("Barcode Test");
            base.SetActiveButtons(BaseButtons.Clear, BaseButtons.Cancel);
            CommonInterfaceFunctions.WLANAddSignalQualityHandler(base.pcbSignal, true);            
        }

        #endregion

        #region Functions

        private void CancelButton(object sender, EventArgs e)
        {
            if (ExitButton == CommonEnum.Buttons.Cancel)
            {
                ClearAll();
                ExitButton = CommonEnum.Buttons.Exit;
                base.BarcodeReader_Start();
            }
            else
            {
                base.GetRawBarcodeValue = false;
                ClearAll();
                Close();
            }
        }

        private void ClearAll()
        {
            TextBarcodeContent.Text = "";
        }

        #endregion 

        #region Overrides

        protected override void BaseWindow_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                case Keys.F14:
                    {
                        ClearAll();
                        ExitButton = CommonEnum.Buttons.Exit;
                        base.BarcodeReader_Start();
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

        protected override void BarcodeReader_AnalyzeType(object Sender, EventArgs e)
        {
            base.GetRawBarcodeValue = true;

            base.BarcodeReader_AnalyzeType(Sender, e);

            try
            {
                if (base.BarcodeValue == null)
                {
                    //Do nothing
                }
                else
                {
                    
                    string BarcodeType = base.BarcodeValue.Type.ToString();
                    string barcodeDesc = "";
                    string BarcodeContent = string.Empty;
                    if (int.Parse(BarcodeType) == (int)CommonEnum.BarcodeType.QRCode)
                    {
                        barcodeDesc = "QRCode";
                        string[] Split = BarcodeValue.Text.Split(new Char[] { '*' });
                        if (Split.Length == 7)
                        {
                            BarcodeContent = string.Format("RR No: {0}-{1}-{2}-{3}", Split[0].Trim(), Split[1].Trim(), Split[2].Trim(), Split[3].Trim());
                            BarcodeContent += "\n" + "Stock Code: " + Split[4].Trim();
                            BarcodeContent += "\n" + "Quantity: " + Split[5].Trim();
                            BarcodeContent += "\n" + "Printed Date: " + Split[6].Trim();
                        }
                        else if (base.BarcodeValue.Length == 6) //Locator Code
                        {
                            BarcodeContent = "Locator Code: " + base.BarcodeValue;
                        }
                        else
                        {
                            BarcodeContent = base.BarcodeValue.Text;
                        }

                    }
                    else if (int.Parse(BarcodeType) == (int)CommonEnum.BarcodeType.Code39)
                    {
                        barcodeDesc = "Code39";
                        string[] Split = base.BarcodeValue.Text.Split(new Char[] { '*' });
                        if (Split.Length == 1)
                        {
                            if (base.BarcodeValue.Length == 10)
                            {
                                //Jobsheet
                                BarcodeContent = "Job Sheet :" + base.BarcodeValue.Text;
                            }
                            else if (base.BarcodeValue.Length == 11)
                            {
                                //Jobsheet
                                BarcodeContent = "Job Sheet :" + base.BarcodeValue.Text;
                            }
                            else if (base.BarcodeValue.Length == 12) //WRIS No
                            {
                                BarcodeContent = "WRIS :" + base.BarcodeValue.Text;
                            }
                            else if (base.BarcodeValue.Length == 13) //WRIS No with Extended 1 char
                            {
                                BarcodeContent = "WRIS :" + base.BarcodeValue.Text;
                            }
                            else
                            {
                                BarcodeContent = base.BarcodeValue.Text;
                            }

                        }
                        else
                        {
                            BarcodeContent = base.BarcodeValue.Text;
                        }
                    }
                    else
                    {
                        BarcodeContent = base.BarcodeValue.Text;
                    }

                    TextBarcodeContent.Text = string.Format("{0}\nBarcode Type: {1}", BarcodeContent, barcodeDesc);                    
                    TextBarcodeContent.ForeColor = (TextBarcodeContent.ForeColor == Color.Blue) ? Color.Black : Color.Blue;
                    base.BarcodeReader_Start();
                    base.BarcodeValue = null;
                }
            }
            catch(Exception err)
            {
                CommonFunctions.MessageShow(err.Message, CommonEnum.NotificationType.Error);
            }

        }

        #endregion

        //Events

        private void BarcodeTestWindow_Load(object sender, EventArgs e)
        {
            CommonFunctions.CurrentFunction = CommonEnum.Function.BarcodeTest;
            TextBarcodeContent.ForeColor = Color.Blue;
        }
    }
}