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
    public partial class PickListWindow : BaseWindow
    {
        #region Variables

        public CommonEnum.Buttons ExitButton = CommonEnum.Buttons.Exit;
        private bool WRISScanned = false;
        private bool RRScanned = false;

        #endregion

        #region constructor

        public PickListWindow(BarcodeReader BCReader, ReaderData BCData)
        {
            InitializeComponent();
            base.SetBarcodeReader(BCReader, BCData);
            base.SetWindowTitle("PICK LIST");
            base.SetActiveButtons(BaseButtons.Save, BaseButtons.Cancel);
            CommonInterfaceFunctions.WLANAddSignalQualityHandler(base.pcbSignal, true);
            CommonFunctions.CurrentFunction = CommonEnum.Function.Picklist;
        }

        #endregion constructor

        #region Override

        protected override void BarcodeReader_AnalyzeType(object Sender, EventArgs e)
        {
            base.BarcodeReader_AnalyzeType(Sender, e);

            switch (base.ScannedBarcodeType)
            {
                case CommonEnum.LabelType.Null:
                    //Do Nothing
                    break;
                case CommonEnum.LabelType.IssuanceNo:
                    {
                        this.WRISScanned = true;
                        this.GetWRISInfo();

                        this.listView1.Focus();
                        this.listView1.Items[0].Selected = true;
                    }
                    break;
                case CommonEnum.LabelType.Item2D:
                    {
                        this.RRScanned = true;
                        if (WRISScanned && PickListBase.isRRScanValid())
                        {
                            int selectedRow = PickListBase.fillRR();
                            

                            this.ClearAll();
                            this.listView1.Focus();
                            this.listView1.Items[selectedRow].Selected = true;
                            CommonFunctions.CommitPickList = true;
                        }
                    }
                    break;
                case CommonEnum.LabelType.ServerNotFound:
                    {
                        this.ClearAll();
                        this.WRISNo.Focus();
                        this.WRISNo.SelectAll();
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
                        this.SaveButton(this, e);
                    break;
                case Keys.F4:
                case Keys.F15:
                    this.CancelButton(this, e);
                    break;
                case Keys.Down:
                    //this.GetSelectedRow(CommonFunctions.PickListTable, false);
                    this.listView1.Focus();
                    break;
                case Keys.Up:
                    //this.GetSelectedRow(CommonFunctions.PickListTable, false);
                    this.listView1.Focus();
                    break;
                case Keys.Left:
                    //this.GetSelectedRow(CommonFunctions.PickListTable, false);
                    this.listView1.Focus();
                    break;
                case Keys.Right:
                    //this.GetSelectedRow(CommonFunctions.PickListTable, false);
                    this.listView1.Focus();
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

        private void GetWRISInfo()
        {  
            if (PickListBase.GeneratePicklist()) //20130415 Allen modify: changing CommonFunctions to PickListBase
            {
                this.WRISNo.Text = CommonFunctions.BarcodeWHReqControlNo;
                this.WRISScanned = true;
                // reloading the tables/list
                this.ClearAll(); //Calling funtion will refresh tables/list
            }
            else
            {
                this.WRISNo.Text = "";
                CommonFunctions.BarcodeWHReqControlNo = "";
                this.ClearAll();
            }
        }

        private void CommitPicklist()
        {
            if (WRISScanned && RRScanned)
            {
                PickListBase.Commit();

                PickListBase.GeneratePicklist(); 
                
                this.ClearAll(); //Calling funtion will refresh tables/list
                if (CommonFunctions.WRISTable.Rows.Count == 0)
                {
                    CommonFunctions.WRISTable = null;
                    this.WRISNo.Text = "";
                    this.SeqNo.Text = "";
                    this.SplitSeqNo.Text = "";
                }
                this.RRScanned = false;   
                this.ExitButton = CommonEnum.Buttons.Cancel; 
                CommonFunctions.MessageShow(string.Format(CommonMsg.Success.d_PicklistCommitted
                                                         , CommonFunctions.BarcodeWHReqControlNo)
                                                         , CommonEnum.NotificationType.Success
                                                         , CommonEnum.MessageButtons.Ok);
            }
            
            //if (PickListBase.GetGeneratePicklist()) 
            //{
            //    CommonFunctions.PickListTable = null;
            //    this.ExitButton = CommonEnum.Buttons.Cancel;
            //    this.WRISNo.Text = CommonFunctions.BarcodeWHReqControlNo;
            //    this.ClearAll(); //Calling funtion will refresh tables/list
            //    this.WRISScanned = false;
            //    this.WRISNo.Text = "";
            //    this.SeqNo.Text = "";
            //    this.SplitSeqNo.Text = "";
            //}            
        }
        
        private void RefreshList(DataTable Table)
        {
            //clear recent
            this.listView1.Items.Clear(); 
            bool GreyBack = false;
            if (Table == null)
                return;
            //Get
            //populate
            int i = 0;
            if (Table.Rows.Count > 0)
            {
                foreach (DataRow row in Table.Rows)
                {
                    ListViewItem lst = new ListViewItem();
                        #region Add Table to List

                        //lst.Text = row["WrdSplitNo"].ToString();
                        //lst.SubItems.Add(row["StockName"].ToString().Trim());
                        //lst.SubItems.Add(row["WrdSeqNo"].ToString());
                        //lst.SubItems.Add(row["Wrd_LastSplitSeqNo"].ToString());
                        //lst.SubItems.Add(row["StockCode"].ToString());
                        //lst.SubItems.Add(row["Specs"].ToString());
                        //lst.SubItems.Add(row["SIQty"].ToString());
                        //lst.SubItems.Add(String.Format("{0:0.00}", row["RequestQty"]));
                        //lst.SubItems.Add(String.Format("{0:0.00}", row["ReservedQty"]));
                        //lst.SubItems.Add(String.Format("{0:0.00}", row["IssuedQty"]));
                        //lst.SubItems.Add(row["Wrd_RRNo"].ToString());
                        //lst.SubItems.Add(row["Wrd_RRSeqNo"].ToString());
                        //lst.SubItems.Add(row["Wrd_RRLotSeqNo"].ToString());
                        //lst.SubItems.Add(row["Wrd_RRLoc"].ToString());
                        //lst.SubItems.Add(row["StockType"].ToString());
                        //lst.SubItems.Add(row["IssueStatus"].ToString());
                        //lst.SubItems.Add(row["WrhStatus"].ToString());
                        //lst.SubItems.Add(row["WrdStatus"].ToString());
                        //lst.SubItems.Add(row["EXTLocator"].ToString());
                        //lst.Text = row["ReqSeqNo"].ToString().Trim();
                        //lst.SubItems.Add(row["ReqSplitSeqNo"].ToString().Trim());
                        //lst.SubItems.Add(row["Stockcode"].ToString().Trim());
                        //lst.SubItems.Add(row["Stockname"].ToString().Trim());
                        lst.Text = row["Stockname"].ToString().Trim();
                        //lst.SubItems.Add(row["Specs"].ToString().Trim());
                        //lst.SubItems.Add(row["StockTypeCode"].ToString().Trim());
                        //lst.SubItems.Add(row["SiQuantity"].ToString().Trim());
                        lst.SubItems.Add(String.Format("{0:0.00}", row["RequestedQty"]));
                        lst.SubItems.Add(String.Format("{0:0.00}", row["ReservedQty"]));
                        //lst.SubItems.Add(String.Format("{0:0.00}", row["IssuedQty"]));
                        //lst.SubItems.Add(row["RRNo"].ToString().Trim());
                        //lst.SubItems.Add(row["RRSeqNo"].ToString().Trim());
                        //lst.SubItems.Add(row["RRLotSeqNo"].ToString().Trim());
                        //lst.SubItems.Add(row["RRlocseqno"].ToString().Trim());
                        //lst.SubItems.Add(row["IssueStatus"].ToString().Trim());
                        //lst.SubItems.Add(row["Status"].ToString().Trim());
                        this.listView1.Items.Add(lst);                        

                        if (row["IssueStatus"].ToString().Trim().Equals(CommonEnum.GetStringValue(CommonEnum.IssueStat.Skip)))
                            lst.ListView.Items[i].BackColor = Color.Red;
                        else if (GreyBack)
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

        public void GetSelectedRow(DataTable Table, bool FRow)
        {
            //Nilo Added 07/02/2012
            if (WRISScanned && Table != null)
            {
                if (Table.Rows.Count > 0)
                {
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        if (FRow) // First row
                            i = 0;

                        if (listView1.Items[i].Selected == true || FRow)
                        {
                            //this.SeqNo.Text = listView1.Items[i].SubItems[0].Text.Trim();
                            this.SeqNo.Text = Table.Rows[i][1].ToString().Trim();
                            //this.SplitSeqNo.Text = listView1.Items[i].SubItems[1].Text.Trim();
                            this.SplitSeqNo.Text = Table.Rows[i][2].ToString().Trim();
                            //this.RequestedQtyTxt.Text = String.Format("{0:0.00}", listView1.Items[i].SubItems[7].Text.Trim());
                            this.RequestedQtyTxt.Text = String.Format("{0:0.00}", Table.Rows[i][8].ToString().Trim());
                            //this.txtReserved.Text = String.Format("{0:0.00}", listView1.Items[i].SubItems[8].Text.Trim());
                            this.txtReserved.Text = String.Format("{0:0.00}", Table.Rows[i][9].ToString().Trim());
                            //if (!string.IsNullOrEmpty(listView1.Items[i].SubItems[10].Text.Trim()))
                            //    this.RRNoTxt.Text = string.Format("{0}-{1}-{2}-{3}"
                            //               , listView1.Items[i].SubItems[10].Text.Trim()
                            //               , listView1.Items[i].SubItems[11].Text.Trim()
                            //               , listView1.Items[i].SubItems[12].Text.Trim()
                            //               , listView1.Items[i].SubItems[13].Text.Trim());
                            if (!string.IsNullOrEmpty(Table.Rows[i][12].ToString().Trim()))
                                this.RRNoTxt.Text = string.Format("{0}-{1}-{2}-{3}"
                                           , Table.Rows[i][12].ToString().Trim()
                                           , Table.Rows[i][13].ToString().Trim()
                                           , Table.Rows[i][14].ToString().Trim()
                                           , Table.Rows[i][15].ToString().Trim());
                            else
                                this.RRNoTxt.Text = string.Empty;

                            //this.lblSpecs.Text = "Specs : " + listView1.Items[i].SubItems[4].Text.Trim();
                            this.lblSpecs.Text = "Specs : " + Table.Rows[i][6].ToString().Trim();
                            //if (listView1.Items[i].SubItems[14].Text.Trim().Equals(CommonEnum.GetStringValue(CommonEnum.IssueStat.Skip)))
                            if (Table.Rows[i][18].ToString().Trim().Equals(CommonEnum.GetStringValue(CommonEnum.IssueStat.Skip)))
                            {
                                this.RRNoTxt.Text = "SKIPPED";
                                this.RRNoTxt.ForeColor = Color.Red;
                            }
                            else
                            {
                                this.RRNoTxt.ForeColor = Color.Black;
                            }
                            break;
                        }
                    }
                }
            }
        }

        private void SaveButton(object sender, EventArgs e)
        {
            if (WRISScanned)
            {
                if (RRScanned)
                {
                    this.CommitPicklist();
                    return;
                }
                else
                {
                    CommonFunctions.MessageShow(CommonMsg.Info.d_ScanRR, CommonEnum.NotificationType.Warning);
                    return;
                }
            }
            else
            {
                CommonFunctions.MessageShow(CommonMsg.Info.d_ScanWRIS, CommonEnum.NotificationType.Warning);
                CommonFunctions.BarcodeWHReqControlNo = "";
                this.WRISNo.Text = "";
                this.ClearAll();
                return;
            }
        }

        private void CancelButton(object sender, EventArgs e)
        {
            if (ExitButton == CommonEnum.Buttons.Cancel)
            {
                this.ClearAll();
                ExitButton = CommonEnum.Buttons.Exit;
                base.BarcodeReader_Start();
            }
            else
                this.Close();
        }

        private void ClearAll()
        {
            this.RRNoTxt.Text = "";
            this.RequestedQtyTxt.Text = "";
            this.txtReserved.Text = "";
            this.lblSpecs.Text = "";
            this.SeqNo.Text = "";
            this.SplitSeqNo.Text = "";
            this.txtReserved.Enabled = true;
            CommonFunctions.BarcodeStockCode = "";
            //Reloading Grids
            this.RefreshList(CommonFunctions.WRISTable);   
            if (this.RRScanned)
            {
                this.GetSelectedRow(CommonFunctions.WRISTable, true);  
            }
                         
            CommonFunctions.ClearStrings();
            return;
        }

        #endregion Functions

        // Events

        private void PickListWindow_Closing(object sender, CancelEventArgs e)
        {
            try
            {
                CommonFunctions.DisposeCommonObj();
                CommonFunctions.PickListTable.Dispose();
            }
            catch { }
        }

        private void PickListWindow_Load(object sender, EventArgs e)
        {
            this.listView1.Focus();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GetSelectedRow(CommonFunctions.WRISTable, false);  
        }        
    }
}