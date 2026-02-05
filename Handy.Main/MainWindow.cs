using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using System.Reflection;
using Handy.Lib;

namespace Handy
{
    public partial class MainWindow : BaseWindow
    {
        #region Variables

        private delegate void InvokeDelegate();
        private bool isReaderInitiated = false;
        //public EventHandler wlanStatusNotifyHandler = null;

        #endregion

        #region Constructor

        public MainWindow()
        {
            InitializeComponent();
            base.SetWindowTitle("nxpertone");
            base.SetActiveButtons(BaseButtons.Select, BaseButtons.Exit);
            CommonInterfaceFunctions.WLANInitializeAdapter();
            
        }

        #endregion

        #region Functions
        /// <summary>
        /// Sleeps 100ms and closes the MainWindow
        /// </summary>
        public void InvokeMethod()
        {
            Thread.Sleep(100);
            this.Close();
        }
        /// <summary>
        /// Event handler when user selects menu item. Activates a particular function based on the selected item. 
        /// </summary>
        /// <param name="sender">The object that sends the event.</param>
        /// <param name="e">The data for the event.</param>
        private void SelectButton(object sender, EventArgs e)
        {
            if (lvFunctionList.FocusedItem != null)
            {
                if (!string.IsNullOrEmpty(lvFunctionList.FocusedItem.SubItems[1].Text))
                {
                    switch (lvFunctionList.FocusedItem.SubItems[1].Text.Trim())
                    {  
                        //case ("JOB START"):
                        //    JobStartWindow _JobStartForm = new JobStartWindow(base.BCReader, base.BCData);
                        //    _JobStartForm.ShowDialog();
                        //    break;
                        case ("LOCATOR TAGGING"):
                            CommonFunctions.CurrentFunction = CommonEnum.Function.MaterialTransfer;
                            LocatorTaggingWindow _TaggingForm = new LocatorTaggingWindow(BCReader, BCData);
                            _TaggingForm.ShowDialog();
                            break;
                        //case ("COIL DEFRAGGING"):
                        //    CoilDefraggingWindow _CoilDefragForm = new CoilDefraggingWindow(BCReader, BCData);
                        //    _CoilDefragForm.ShowDialog();
                        //    break;
                        case ("STOCKMOVEMENT(BATCH)"):
                            //MaterialTransferWindow _DeliveryPreparationForm = new MaterialTransferWindow(BCReader, BCData);
                            //_DeliveryPreparationForm.ShowDialog();
                            StockMovementWindow materialTrans = new StockMovementWindow(BCReader, BCData);
                            materialTrans.ShowDialog();
                            break;
                        case ("MATERIAL ISSUANCE"):
                            //IssuanceWindow _UltimateDeliveryCheclistForm = new IssuanceWindow(BCReader, BCData);
                            MaterialIssuanceWindow _UltimateDeliveryCheclistForm = new MaterialIssuanceWindow(BCReader, BCData);
                            _UltimateDeliveryCheclistForm.ShowDialog();
                            break;
                        case ("INVTY PROCESSING"):
                            InventoryProcessingWindow _InventoryProcessing = new InventoryProcessingWindow(BCReader, BCData);
                            _InventoryProcessing.ShowDialog();
                            break;
                        case ("BARCODE TEST"):
                            BarcodeTestWindow _BarcodeTest = new BarcodeTestWindow(BCReader, BCData);
                            _BarcodeTest.ShowDialog();
                            break;
                        case ("MAINTENANCE"):
                            HandyMaintenanceWindow MaintenanceWindow = new HandyMaintenanceWindow();
                            MaintenanceWindow.ShowDialog();
                            break;
                        case ("MATERIAL TRANSFER"):                        
                            MaterialTransferWindow MatTransWindow = new MaterialTransferWindow(BCReader,BCData);
                            MatTransWindow.ShowDialog();
                            break;
                        case ("LOG-OUT"):
                            LogInWindow LogIn = new LogInWindow(BCReader, BCData);
                            if (LogIn.ShowDialog() == DialogResult.Abort)
                            {
                                this.BeginInvoke(new InvokeDelegate(InvokeMethod));
                            }
                            else
                            {
                                try
                                {
                                    this.lvFunctionList.Focus(); 
                                }
                                catch { }
                            }
                            break;
                        case ("INVTY GENERATION"):
                            InventoryGenerationWindow _InventoryReferenceGenerationForm = new InventoryGenerationWindow();
                            _InventoryReferenceGenerationForm.ShowDialog();
                            break;
                        //case ("STOCK RECLASS"):
                        //    CommonFunctions.CurrentFunction = CommonEnum.Function.StockReclass;
                        //    StockReclassWindow _StockReclassWindow = new StockReclassWindow(BCReader, BCData);
                        //    _StockReclassWindow.ShowDialog();
                        //    break;
                        //case ("STOCK PACKING OPENING"):
                        //    CommonFunctions.CurrentFunction = CommonEnum.Function.StockPackingOpennig;
                        //    StockReclassWindow _StockPackingOpeningWindow = new StockReclassWindow(BCReader, BCData);
                        //    _StockPackingOpeningWindow.ShowDialog();
                        //    break;
                        case ("STOCK CARD"):
                            StockCardWindow _StockCardWindow = new StockCardWindow(BCReader, BCData);

                            _StockCardWindow.ShowDialog();
                            break;
                        case ("DELIVERY PREP"):
                            DeliveryPreparationWindow _DeliveryPreparationWindow = new DeliveryPreparationWindow(BCReader, BCData);

                            _DeliveryPreparationWindow.ShowDialog();
                            break;

                    }

                    CommonInterfaceFunctions.WLANAddSignalQualityHandler(base.pcbSignal, true);
                    CommonInterfaceFunctions.SetBatteryLifeInterface(base.pcbBatteryLife);
                }
            }
        }

        #endregion

        #region Override

        protected override void BaseWindow_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                case Keys.F14:
                    SelectButton(this, e);
                    base.BaseWindow_KeyUp(sender, e);
                    break;
                case Keys.F4:
                case Keys.F15:
                    Close();
                    break;
                case Keys.F2:
                //case Keys.F1:
                    HandyMaintenanceWindow MaintenanceWindow = new HandyMaintenanceWindow();
                    MaintenanceWindow.Show();
                    break;
                case Keys.Down:
                    try
                    {
                        this.lvFunctionList.Focus();
                    }
                    catch { }
                    break;
                case Keys.F3:
                case Keys.D0:
                    KTestWindow testwindow = new KTestWindow(BCReader, BCData);
                    testwindow.Show();
                    break;

            }
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

        private void MainForm_Load(object sender, EventArgs e)
        {
            #region InitReader

            this.isReaderInitiated = base.BarcodeReader_Initialize();

            if (!(isReaderInitiated))// If the reader has not been initialized
            {
                // Display a message & exit the application.
                CommonFunctions.MessageShow("", Handy.Properties.Resources.AppExitMsg, CommonEnum.NotificationType.Information);

                //Application.Exit();
                this.BeginInvoke(new InvokeDelegate(InvokeMethod));
            }
            else
            {
                LogInWindow LogIn = new LogInWindow(base.BCReader, base.BCData);
                if (LogIn.ShowDialog() == DialogResult.Abort)
                {
                    this.BeginInvoke(new InvokeDelegate(InvokeMethod));
                }
                else
                {
                    CommonInterfaceFunctions.WLANAddSignalQualityHandler(base.pcbSignal, true);
                }
            }

            #endregion

            lvFunctionList.Focus();
            if (lvFunctionList.Items != null)
            {
                if (!string.IsNullOrEmpty(lvFunctionList.Items[0].SubItems[1].Text))
                {
                    lvFunctionList.Items[0].Selected = true;
                    lvFunctionList.Items[0].Focused = true;
                }
            }
        }

        private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Logger.isFileExist(Logger.HandyPath, Logger.HandyMacFile))
                Logger.isFileCleared(Logger.HandyPath, Logger.HandyMacFile);

            if (isReaderInitiated)
                base.BarcodeReader_Terminate();
            CommonInterfaceFunctions.WLANDispose();
        }
    }
}
