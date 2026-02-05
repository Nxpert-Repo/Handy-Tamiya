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
    public partial class MaterialTransferWindow : BaseWindow
    {

        #region Variables

        public CommonEnum.Buttons ExitButton = CommonEnum.Buttons.Exit;
        private bool TransNoScanned = false;
        #endregion

        #region Constructor

        public MaterialTransferWindow(BarcodeReader BCReader, ReaderData BCData)
        {
            InitializeComponent();
            base.SetBarcodeReader(BCReader, BCData);
            base.SetWindowTitle("Material Transfer");
            base.SetActiveButtons(BaseButtons.Save, BaseButtons.Cancel);
            CommonInterfaceFunctions.WLANAddSignalQualityHandler(base.pcbSignal, true);
            
        }

        #endregion

        #region Function

        private void GetFirstRow()
        {
            if (listView1.Items.Count > 0)
            {
           
            }
        }

        private void SaveButton(object sender, EventArgs e)
        {
             if (TransNoScanned)
            {
                CommonFunctions.TransferQty = CommonFunctions.ConvertStringDecimal(txttransqty.Text);

                try
                {
                    if (string.IsNullOrEmpty(CommonFunctions.BarcodeStockCode))
                    {
                        CommonFunctions.MessageShow(CommonMsg.Info.d_ScanItem, CommonEnum.NotificationType.Information);
                    }
                    else if (!CommonFunctions.isInputValid(CommonFunctions.IssuedQty.ToString(), Convert.ToDecimal(CommonFunctions.BarcodeQuantity), false))
                    { 
                        //Do Nothing
                    }
                    else
                    {
                        string filter;
                        //if (IsReserved)
                        //    filter = string.Format(CommonQueryStrings.Mobile.ViewFiltered.Issuance
                        //                         , CommonFunctions.BarcodeStockCode
                        //                         , CommonFunctions.RRNoDisplay);
                        //else
                        //    filter = string.Format("StockCode = '{0}' AND IssueStatus <> 'G'", CommonFunctions.BarcodeStockCode);

                        //this.SaveIssued(CommonFunctions.WRISTable, filter);
                        //this.ClearAll();    
                    }
                }
                catch (Exception er)
                { }
            }
            else
            {
                CommonFunctions.MessageShow(CommonMsg.Info.d_ScanSM, CommonEnum.NotificationType.Information);
               
            }

            this.lblRemark.Text = "Press [ Enter Key ] to issue scanned items.";
        

        }

        private void CancelButton(object sender, EventArgs e)
        {
            if (ExitButton == CommonEnum.Buttons.Cancel)
            {
                this.ClearAll();
                this.ExitButton = CommonEnum.Buttons.Exit;
                base.BarcodeReader_Start();
            }
            else
                this.Close();
        }

        private void ClosingWindow()
        {
            DeliveryPreparationBaseOld.CleanDPScannedList();
            CommonFunctions.CeExecuteNonQuery("DELETE ScanStatus");
            ClearAll();
            CommonFunctions.LocatorCode = string.Empty;
            CommonFunctions.LocatorDesc = string.Empty;
            CommonFunctions.BarcodeWRISNo = string.Empty;
            CommonFunctions.Customer = string.Empty;
            Close();
        }

        private void ClearAll()
        {
          
        }

       
        #endregion

        #region Override
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

        protected override void BaseWindow_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F14:
                    SaveButton(this, e);
                    break;
                case Keys.F1:
                    SaveButton(this, e);
                    break;
                case Keys.F15:
                    CancelButton(this, e);
                    break;

                case Keys.F4:
                    CancelButton(this, e);
                    break;
                case Keys.Down:
                  
                    GetSelectedRow(CommonFunctions.WRISTable, false);
                    listView1.Focus();
                    break;
                case Keys.Up:
                 
                    GetSelectedRow(CommonFunctions.WRISTable, false);
                    listView1.Focus();
                    break;
                case Keys.Left:
                    GetSelectedRow(CommonFunctions.WRISTable, false);
                    listView1.Focus();
                   
                    break;
                case Keys.Right:
                    GetSelectedRow(CommonFunctions.WRISTable, false);
                    listView1.Focus();
                   
                    break;
                case Keys.Enter:
                    Key_PostWRIS(this, e);                  
                    break;
                case Keys.ControlKey:
                    txttransqty.Focus();
                    txttransqty.SelectAll();
                  
                    break;
                default:
                  
                    break;
            }

            base.BaseWindow_KeyUp(sender, e);
        }

        private void Key_PostWRIS(object sender, EventArgs e)
        {
            if (CommonFunctions.IsConnected())
            {
                CommonFunctions.PostProgress = this.Progress;

              

                if (CommonFunctions.isWRISSplit)  //Reconnecting to server to get new splitted rows
                {
                    
                }
                else
                {
                    if (listView1.Items.Count <= 0)
                    {
                        this.TransferNo.Text = "";
                        this.TransNoScanned = false;
                    }
                }
                this.TransferNo.Text = "";
                this.ClearAll();
                this.ExitButton = CommonEnum.Buttons.Exit;
                this.txttransqty.Focus();
                this.txttransqty.SelectAll();
                base.BarcodeReader_Start();
                this.Progress.Visible = false;
            }
        }


        private void RefreshList(DataTable Table)
        {
            //clear recent
            this.listView1.Items.Clear();
            bool GreyBack = false;
            int i = 0;

            if (Table != null)
            {
                //cleaning table
                StockMovementBase.DatatableDelete(Table, string.Format("EXTUploadStatus = '{0}'", CommonEnum.GetStringValue(CommonEnum.UploadStats.Sent)));
                //Get
                //populate
                if (Table.Rows.Count > 0)
                {
                    foreach (DataRow row in Table.Rows)
                    {
                        ListViewItem lst = new ListViewItem();
                        bool IsGetWRISNo = false;
                        //Skipping Sent Flag
                        if (row["EXTUploadStatus"].ToString().Trim() != CommonEnum.GetStringValue(CommonEnum.UploadStats.Sent) || (row.RowState != DataRowState.Deleted))
                        {
                            #region Add Table to List

                            if (!IsGetWRISNo)
                            {
                                this.TransferNo.Text = CommonFunctions.TransferNo;
                                IsGetWRISNo = true;
                            }
                            lst.ImageIndex = (int)row["EXTUploadStatus"];        //Issued [Loca]
                            if ((int)row["EXTUploadStatus"] == Convert.ToInt16(CommonEnum.GetStringValue(CommonEnum.UploadStats.Saved)))
                                lst.ImageIndex = Convert.ToInt16(CommonEnum.GetStringValue(CommonEnum.UploadStats.Sent));  //Use flag as check
                            lst.Text = row["StockName"].ToString().Trim();
                            lst.SubItems.Add(row["WrdSeqNo"].ToString());
                            lst.SubItems.Add(row["WrdSplitNo"].ToString());
                            lst.SubItems.Add(row["Wrd_LastSplitSeqNo"].ToString());
                            lst.SubItems.Add(row["StockCode"].ToString());
                            lst.SubItems.Add(row["Specs"].ToString());
                            lst.SubItems.Add(row["SIQty"].ToString());
                            lst.SubItems.Add(String.Format("{0:0.00}", row["RequestQty"]));
                            lst.SubItems.Add(String.Format("{0:0.00}", row["ReservedQty"]));
                            lst.SubItems.Add(String.Format("{0:0.00}", row["IssuedQty"]));
                            lst.SubItems.Add(row["Wrd_RRNo"].ToString());
                            lst.SubItems.Add(row["Wrd_RRSeqNo"].ToString());
                            lst.SubItems.Add(row["Wrd_RRLotSeqNo"].ToString());
                            lst.SubItems.Add(row["Wrd_RRLoc"].ToString());
                            lst.SubItems.Add(row["StockType"].ToString());
                            lst.SubItems.Add(row["IssueStatus"].ToString());
                            lst.SubItems.Add(row["WrhStatus"].ToString());
                            lst.SubItems.Add(row["WrdStatus"].ToString());
                            lst.SubItems.Add(row["EXT_RRAvailable"].ToString());
                            lst.SubItems.Add(row["EXTUploadStatus"].ToString());
                            lst.SubItems.Add(row["EXT_Remark"].ToString());
                            lst.SubItems.Add(row["EXTBarcodeQty"].ToString());
                            lst.SubItems.Add(row["EXTBarcodePrintDate"].ToString());
                            lst.SubItems.Add(row["EXTLocator"].ToString());
                            this.listView1.Items.Add(lst);
                            if (GreyBack)
                            {
                                lst.ListView.Items[i].BackColor = Color.LightCyan;
                                lst.ListView.Items[i].ForeColor = Color.Black;
                                GreyBack = false;
                            }
                            else
                            {
                                lst.ListView.Items[i].BackColor = Color.White;
                                lst.ListView.Items[i].ForeColor = Color.Blue;
                                GreyBack = true;
                            }
                            ++i;

                            #endregion
                        }
                    }
                }
            }
        }


        public void GetSelectedRow(DataTable Table, bool FRow)
        {
            //Nilo Added 07/02/2012
            if (TransNoScanned && Table != null)
            {
                if (Table.Rows.Count > 0)
                {
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        if (FRow) i = 0; // First row

                        if ((listView1.Items[i].Selected == true || FRow) && (Table.Rows[i].RowState != DataRowState.Deleted))
                        {
                         
                            
                            if (!string.IsNullOrEmpty(listView1.Items[i].SubItems[10].Text.Trim()))
                                this.RRNo.Text = string.Format("{0}-{1}-{2}-{3}"
                                           , listView1.Items[i].SubItems[10].Text.Trim()
                                           , listView1.Items[i].SubItems[11].Text.Trim()
                                           , listView1.Items[i].SubItems[12].Text.Trim()
                                           , listView1.Items[i].SubItems[13].Text.Trim());

                            if (CommonFunctions.ConvertStringDecimal(listView1.Items[i].SubItems[8].Text.Trim()) > 0
                                && listView1.Items[i].SubItems[15].Text.Trim() == CommonEnum.GetStringValue(CommonEnum.IssueStat.Generate))
                            {
                              
                            }
                            else
                            {
                              
                            }

                            break;
                        }
                    }
                }
            }
            else
            {
               
                return;
            }
        }

        protected override void BarcodeReader_AnalyzeType(object Sender, EventArgs e)
        {
            base.BarcodeReader_AnalyzeType(Sender, e);

            switch (base.ScannedBarcodeType)
            {
                case CommonEnum.LabelType.Item2D:
                    {
                                      
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
                        TransferNo.Text = "";
                        TransferNo.Text = "";
                        TransferNo.Focus();
                        base.BarcodeReader_Start();
                    }
                    break;
                case CommonEnum.LabelType.TransferNo:
                    {
                        GetBatchMovement();
                    }
                    break;
            }

            base.ScannedBarcodeType = Handy.Lib.CommonEnum.LabelType.Null;
        }

        #endregion

        //Events

        private void MaterialTransferWindow_Load(object sender, EventArgs e)
        {
        
            CommonFunctions.CurrentFunction = CommonEnum.Function.MaterialTransfer;
       
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void label7_ParentChanged(object sender, EventArgs e)
        {

        }

        private void GetBatchMovement()
        {
            CommonFunctions.isSTMSplit = false;
            if (StockMovementBase.GetStockMovement())
            {
                this.TransferNo.Text = CommonFunctions.TransferNo;
                this.TransNoScanned = true;
                //Get List of RR unmatch to Current Proj No.
        //        IssuanceBase.GetRRListWithReservedProjNo();
                this.ClearAll(); //Calling funtion will refresh tables/list

            }
            else
            {
         //       this.WRISNo.Text = string.Empty;
                CommonFunctions.BarcodeWHReqControlNo = string.Empty;
                this.ClearAll();
            }
        }
    }
}