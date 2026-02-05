using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using Handy.Lib;
using Handy.Lib.MaterialTransferAndIssuance;

namespace Handy
{
    public partial class IssuanceWindow : BaseWindow
    {
        #region Variables

        public CommonEnum.Buttons ExitButton = CommonEnum.Buttons.Exit;
        private bool WRISScanned = false;
        //private bool RRScanned = false;
        private bool IsReserved = false;
        private bool IsMismatch = false;

        #endregion

        #region constructor

        public IssuanceWindow(BarcodeReader BCReader, ReaderData BCData)
        {
            InitializeComponent();
            base.SetBarcodeReader(BCReader, BCData);
            base.SetWindowTitle("Material Issuance");
            //base.SetActiveButtons(BaseButtons.Save, BaseButtons.Cancel);
            base.SetRightButton(BaseButtons.Cancel);
            CommonInterfaceFunctions.WLANAddSignalQualityHandler(base.pcbSignal, true); 
        }

        #endregion constructor

        #region Override

        protected override void BarcodeReader_AnalyzeType(object Sender, EventArgs e)
        {
            base.BarcodeReader_AnalyzeType(Sender, e);

            if (base.ScannedBarcodeType.Equals(CommonEnum.LabelType.Item2D) ||
                base.ScannedBarcodeType.Equals(CommonEnum.LabelType.ItemLinear) ||
                base.ScannedBarcodeType.Equals(CommonEnum.LabelType.IssuanceNo))
            {
                switch (base.ScannedBarcodeType)
                {
                    case CommonEnum.LabelType.Null:
                        break;
                    case CommonEnum.LabelType.Item2D:
                        {
                            this.GetIssuanceRRInfo();
                            SaveButton(this, e);
                        }
                        break;
                    case CommonEnum.LabelType.ItemLinear:
                        {
                            this.GetIssuanceRRInfo();
                        }
                        break;
                    case CommonEnum.LabelType.Invalid:
                        {
                            this.ClearAll();
                            this.IssuedQty.Focus();
                            this.IssuedQty.SelectAll();
                        }
                        break;
                    case CommonEnum.LabelType.LocatorCode:
                        {
                            this.ClearAll();
                        }
                        break;
                    case CommonEnum.LabelType.IssuanceNo:
                        {
                            this.GetWRISInfo();
                            this.IssuedQty.Focus();
                            this.IssuedQty.SelectAll();
                        }
                        break;

                    case CommonEnum.LabelType.ServerNotFound:
                        {
                            this.ClearAll();
                            this.IssuedQty.Focus();
                            this.IssuedQty.SelectAll();
                        }
                        break;
                }
            }

            base.ScannedBarcodeType = Handy.Lib.CommonEnum.LabelType.Null;
        }

        protected override void BaseWindow_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F14:
                 // SaveButton(this, e);
                    //ShowSpecs(false);
                    break;
                case Keys.F1:
                  //SaveButton(this, e);
                    //ShowSpecs(false);
                    break;
                case Keys.F15:
                    CancelButton(this, e);
                    break;

                case Keys.F4:
                    CancelButton(this, e);
                    break;
                case Keys.Down:
                    //ShowSpecs(true);
                    GetSelectedRow(CommonFunctions.WRISTable,false);
                    listView1.Focus();
                    break;
                case Keys.Up:
                    //ShowSpecs(true);
                    GetSelectedRow(CommonFunctions.WRISTable, false);
                    listView1.Focus();
                    break;
                case Keys.Left:
                    GetSelectedRow(CommonFunctions.WRISTable, false);
                    listView1.Focus();
                    //ShowSpecs(false);
                    break;
                case Keys.Right:
                    GetSelectedRow(CommonFunctions.WRISTable, false);
                    listView1.Focus();
                    //ShowSpecs(false);
                    break;
                case Keys.Enter:
                    Key_PostWRIS(this, e); 
                    //ShowSpecs(false);
                    break;
                case Keys.ControlKey:
                    IssuedQty.Focus();
                    IssuedQty.SelectAll();
                    //ShowSpecs(false);
                    break;
                default:
                    //ShowSpecs(false);
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
            CommonFunctions.isWRISSplit = false;
            if (IssuanceBase.GetWRISList()) 
            {
                this.WRISNo.Text = CommonFunctions.BarcodeWHReqControlNo;
                this.WRISScanned = true;
                //Get List of RR unmatch to Current Proj No.
                IssuanceBase.GetRRListWithReservedProjNo(); 
                this.ClearAll(); //Calling funtion will refresh tables/list

            }
            else
            {
                this.WRISNo.Text = string.Empty;
                CommonFunctions.BarcodeWHReqControlNo = string.Empty;
                this.ClearAll();
            }
        }

        private void GetIssuanceRRInfo()
        {
            bool IsProjectNoValid = false;
            //this.RRScanned = true;
            if (WRISScanned)
            {
                DataTable temp = new DataTable();
                //Check retreived table if there is reserved then prioritize
                DataTable dtReserved = IssuanceBase.SelectedRowDisplayTable(CommonFunctions.WRISTable
                                                                          , string.Format("StockCode = '{0}' AND Wrd_RRNo+'-'+Wrd_RRSeqNo+'-'+Wrd_RRLotSeqNo+'-'+Wrd_RRLoc = '{1}' AND IssueStatus = 'G'"
                                                                          , CommonFunctions.BarcodeStockCode
                                                                          , CommonFunctions.RRNoDisplay));
                this.IssuedQty.Enabled = true;
                if (dtReserved.Rows.Count > 0)
                {
                    temp = dtReserved.Copy(); // setting table with the resevered data
                    IsReserved = true;
                }
                else
                {
                    //Compare to scanned Label
                    temp = IssuanceBase.SelectedRowDisplayTable(CommonFunctions.WRISTable
                                                              , string.Format("StockCode = '{0}' AND IssueStatus <> 'G'"
                                                              , CommonFunctions.BarcodeStockCode));
                    if (IssuanceBase.InvalidProjectNo())
                    {
                        IsProjectNoValid = true;
                    }
                }

                this.RefreshList(temp);
                this.GetSelectedRow(temp, true);
                if (temp.Rows.Count > 0 && !IsProjectNoValid)
                {

                    if (CommonFunctions.ConvertStringDecimal(temp.Rows[0]["RequestQty"].ToString()) > CommonFunctions.ConvertStringDecimal(CommonFunctions.BarcodeQuantity))
                    {
                        this.IssuedQty.Text = string.Format("{0:0.00}", CommonFunctions.BarcodeQuantity);
                    }
                    //if reserved verify the barcode quantity
                    else if (CommonFunctions.ConvertStringDecimal(temp.Rows[0]["RequestQty"].ToString()) > CommonFunctions.ConvertStringDecimal(CommonFunctions.BarcodeQuantity) && IsReserved)
                    {
                        CommonFunctions.MessageShow(string.Format(CommonMsg.Warning.d_RegenerateWRIS
                                                   , CommonFunctions.BarcodeWHReqControlNo
                                                   , CommonFunctions.RRNoDisplay)
                                                   , CommonEnum.NotificationType.Warning);
                    }
                    else
                    {
                        this.IssuedQty.Text = string.Format("{0:0.00}", temp.Rows[0]["RequestQty"]);
                    }

                    this.RRNo.Text = CommonFunctions.RRNoDisplay;
                    this.AvailableQty.Text = CommonFunctions.BarcodeQuantity;
                    this.LocatorQty.Text = CommonFunctions.BarcodeQuantity;
                    this.IssuedQty.Focus();
                    this.IssuedQty.SelectAll();
                    if (CommonFunctions.ConvertStringDecimal(IssuedQty.Text) <= 0)
                        this.IssuedQty.BackColor = Color.White;
                    else
                        this.IssuedQty.BackColor = Color.Cyan;
                    this.ExitButton = CommonEnum.Buttons.Cancel;
                }
                else
                {
                    if (!IsProjectNoValid)
                    {
                        CommonFunctions.MessageShow(string.Format(CommonMsg.Warning.d_WRISRR
                                                                , CommonFunctions.BarcodeWHReqControlNo
                                                                , CommonFunctions.RRNoDisplay
                                                                , CommonFunctions.BarcodeStockCode)
                                                                , CommonMsg.Warning.h_ItemMismatch
                                                                , CommonEnum.NotificationType.Warning);
                        this.IsMismatch = true;
                    }
                    this.ClearAll();
                    base.BarcodeReader_Start();
                    return;

                }
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
                IssuanceBase.DatatableDelete(Table, string.Format("EXTUploadStatus = '{0}'", CommonEnum.GetStringValue(CommonEnum.UploadStats.Sent)));
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
                                this.WRISNo.Text = CommonFunctions.BarcodeWHReqControlNo;
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
            if (WRISScanned && Table != null)
            {
                if (Table.Rows.Count > 0)
                {
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        if (FRow) i = 0; // First row
                        
                        if ((listView1.Items[i].Selected == true || FRow) && (Table.Rows[i].RowState != DataRowState.Deleted))
                        {
                            this.lblSpecs.Text = string.Format(CommonMsg.Info.d_Specs, listView1.Items[i].SubItems[5].Text.Trim());
                            this.RequestedQty.Text = String.Format("{0:0.00}", CommonFunctions.ConvertStringDecimal(listView1.Items[i].SubItems[7].Text.Trim()));
                            this.txtReserved.Text = String.Format("{0:0.00}", CommonFunctions.ConvertStringDecimal(listView1.Items[i].SubItems[8].Text.Trim()));
                            this.IssuedQty.Text = String.Format("{0:0.00}", CommonFunctions.ConvertStringDecimal(listView1.Items[i].SubItems[9].Text.Trim()));
                            this.AvailableQty.Text = String.Format("{0:0.00}", CommonFunctions.ConvertStringDecimal(listView1.Items[i].SubItems[18].Text.Trim()));
                            this.LocatorQty.Text = String.Format("{0:0.00}", CommonFunctions.ConvertStringDecimal(listView1.Items[i].SubItems[18].Text.Trim()));
                            this.lblRemark.Text = "Remark: " + listView1.Items[i].SubItems[20].Text.Trim();
                            this.lblLocator.Text = listView1.Items[i].SubItems[23].Text.Trim();

                            if (!string.IsNullOrEmpty(listView1.Items[i].SubItems[10].Text.Trim()))
                                this.RRNo.Text = string.Format("{0}-{1}-{2}-{3}"
                                           , listView1.Items[i].SubItems[10].Text.Trim()
                                           , listView1.Items[i].SubItems[11].Text.Trim()
                                           , listView1.Items[i].SubItems[12].Text.Trim()
                                           , listView1.Items[i].SubItems[13].Text.Trim());

                            if (CommonFunctions.ConvertStringDecimal(listView1.Items[i].SubItems[8].Text.Trim()) > 0
                                && listView1.Items[i].SubItems[15].Text.Trim() == CommonEnum.GetStringValue(CommonEnum.IssueStat.Generate))
                            {
                                this.txtReserved.Enabled = false;
                                this.IssuedQty.Enabled = false;
                                this.listView1.Focus();
                            }
                            else
                            {
                                this.txtReserved.Enabled = true;
                                this.IssuedQty.Enabled = true;
                            }

                            break;
                        }
                    }
                }
            }
            else
            {                 
                this.ShowSpecs(false);
                return;
            }
        }

        private void SaveButton(object sender, EventArgs e)
        {
            if (!IsMismatch)
            {
                if (WRISScanned)
                {
                    CommonFunctions.IssuedQty = CommonFunctions.ConvertStringDecimal(IssuedQty.Text);

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
                            if (IsReserved)
                                filter = string.Format(CommonQueryStrings.Mobile.ViewFiltered.Issuance
                                                     , CommonFunctions.BarcodeStockCode
                                                     , CommonFunctions.RRNoDisplay);
                            else
                                filter = string.Format("StockCode = '{0}' AND IssueStatus <> 'G'", CommonFunctions.BarcodeStockCode);

                            this.SaveIssued(CommonFunctions.WRISTable, filter);
                            this.ClearAll();
                        }
                    }
                    catch (Exception er)
                    { }
                }
                else
                {
                    CommonFunctions.MessageShow(CommonMsg.Info.d_ScanWRIS, CommonEnum.NotificationType.Warning);
                    this.ShowSpecs(false);
                }
            }
            else
            {
                IsMismatch = false;
            }
            this.lblRemark.Text = "Press [ Enter Key ] to issue scanned items.";
        }

        private void SaveIssued(DataTable Table, string filter)
        {
            DataRow[] rows = Table.Select(filter);
            foreach (DataRow row in rows)
            {
                if (CommonFunctions.IssuedQty < CommonFunctions.ConvertStringDecimal(row["RequestQty"].ToString()))
                {
                    CommonFunctions.isWRISSplit = true;
                }
                row["IssuedQty"] = CommonFunctions.IssuedQty;
                row["Wrd_RRNo"] = CommonFunctions.BarcodeRRNo;
                row["Wrd_RRSeqNo"] = CommonFunctions.BarcodeRRSeq;
                row["Wrd_RRLotSeqNo"] = CommonFunctions.BarcodeRRLotSeq;
                row["Wrd_RRLoc"] = CommonFunctions.BarcodeRRLocSeq;
                row["EXT_RRAvailable"] = CommonFunctions.BarcodeQuantity;
                row["EXTBarcodeQty"] = CommonFunctions.BarcodeQuantity;           //Checking for last transaction
                row["EXTBarcodePrintDate"] = CommonFunctions.BarcodePrintedDate;  //Checking for last transaction
                row["EXTUploadStatus"] = CommonEnum.GetStringValue(CommonEnum.UploadStats.Saved);
            }
            Table.AcceptChanges();
        }

        private void Key_PostWRIS(object sender, EventArgs e)
        {
            if (CommonFunctions.IsConnected())
            {
                CommonFunctions.PostProgress = this.Progress;

                IssuanceBase.IssueItem();

                if (CommonFunctions.isWRISSplit)  //Reconnecting to server to get new splitted rows
                {
                    if (IssuanceBase.GetWRISSplitList()) 
                    {
                        DataRow[] InsertRows = CommonFunctions.WRISTableSplitList.Select();
                        if (InsertRows.Length > 0)
                        {
                            int insertedsplit = 0;

                            foreach (DataRow Rows in InsertRows)
                            {
                                //Inserting Splits to Datatable
                                insertedsplit += IssuanceBase.InsertNotExist(CommonFunctions.WRISTable
                                                                           , Rows
                                                                           , string.Format("WrdSeqNo = '{0}' AND WrdSplitNo = '{1}'"
                                                                           , Rows["WrdSeqNo"]
                                                                           , Rows["WrdSplitNo"])); 
                            }
                            if (insertedsplit > 0) //Displaying message if split was added to datatable
                                CommonFunctions.MessageShow(CommonMsg.Info.d_NewWRISSplit, CommonEnum.NotificationType.Information);

                        }
                    }

                    CommonFunctions.isWRISSplit = false;
                }
                else
                {
                    if (listView1.Items.Count <= 0)
                    {
                        this.WRISNo.Text = "";
                        this.WRISScanned = false;
                    }
                }
                this.WRISNo.Text = "";
                this.ClearAll();
                this.ExitButton = CommonEnum.Buttons.Exit;
                this.IssuedQty.Focus();
                this.IssuedQty.SelectAll();
                base.BarcodeReader_Start();
                this.Progress.Visible = false;
            }
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

        private void ClearAll()
        {
            CommonFunctions.ClearStrings();
            CommonFunctions.BarcodeStockCode = "";
            this.RRNo.Text = "";
            this.IssuedQty.Text = "";
            this.RequestedQty.Text = "";
            this.txtReserved.Text = "";
            this.lblSpecs.Text = "";
            this.AvailableQty.Text = "";
            this.LocatorQty.Text = "";
            this.IssuedQty.BackColor = Color.White;
            this.IssuedQty.Enabled = true;
            this.txtReserved.Enabled = true;
            this.IsReserved = false;
            this.ShowSpecs(false);
            //Reloading Grids
            this.RefreshList(CommonFunctions.WRISTable);
            this.GetSelectedRow(CommonFunctions.WRISTable, true);
            return;
        }

        private void ShowSpecs(bool show)
        {
            this.lblSpecs.Visible = show;
            this.lblLocator.Visible = show;
        }

        #endregion Functions

        //Events

        private void IssuanceWindow_Closing(object sender, CancelEventArgs e)
        {
            try
            {
                ClearAll();
                CommonFunctions.WRISTable.Dispose();
                Close();
            }
            catch { }
        }

        private void IssuedQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumberFormatInfo numberFormatInfo = CultureInfo.CurrentCulture.NumberFormat;
            string decimalSeparator = numberFormatInfo.NumberDecimalSeparator;

            string keyInput = e.KeyChar.ToString();

            if ((!CommonFunctions.isDecimal()) && (Char.IsDigit(e.KeyChar) || e.KeyChar == '\b'))
                e.Handled = false;
            else if ((CommonFunctions.isDecimal()) && (Char.IsDigit(e.KeyChar) || keyInput.Equals(decimalSeparator) || e.KeyChar == '\b'))
                if (IssuedQty.Text.IndexOf('.') != -1)
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

        private void IssuanceWindow_Load(object sender, EventArgs e)
        {
            this.IssuedQty.Focus();
        }
    }
}