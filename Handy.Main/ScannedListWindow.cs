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
    public partial class ScannedListWindow : BaseWindow
    {
        #region Varialbles

        DataTable dt = new DataTable();
        CommonEnum.Function _CurrentFunction = CommonEnum.Function.DeliveryPreparation;
        int PendingCount = 0;
        string WRISNo = "";
        public string LotCodex = "";
        #endregion

        #region Constructor

        public ScannedListWindow(CommonEnum.Function CurrentFunction,string WRISNox)
        {
            InitializeComponent();
            //base.SetBarcodeReader(BCReader, BCData);
            base.SetWindowTitle("Scanned List");
            base.SetActiveButtons(BaseButtons.Post, BaseButtons.Cancel);
            CommonInterfaceFunctions.WLANAddSignalQualityHandler(base.pcbSignal, true);
            _CurrentFunction = CurrentFunction;
            WRISNo = WRISNox;
         
        }

        #endregion

        #region Functions

        private void SetListDisplay()
        {
            //this.ScannedListView.Location = new System.Drawing.Point(10, 64);
            //this.ScannedListView.Size = new System.Drawing.Size(301, 214);
            //this.lblGridHeader.Location = new System.Drawing.Point(11, 65);
            //this.lblGridHeader.Size = new System.Drawing.Size(299, 26);
            this.lblGridHeader.BackColor = System.Drawing.Color.Teal;
        }

        private void RefreshList(CommonEnum.Function CurrentFunction)
        {
            //clear recent
            ScannedListView.Items.Clear();

            //Get
            dt = GetTable(CurrentFunction);

            //Populate ListView
            PendingCount = 0;

            if (dt.Rows.Count > 0)
            {
                //populate
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem ScannedListViewItem = new ListViewItem();
                    ScannedListViewItem.ImageIndex = CommonFunctions.ItemStatus((int)row["ScanFlag"], (int)row["SentFlag"]);
                    ScannedListViewItem.Text = row["LotCode"].ToString();
                    ScannedListViewItem.SubItems.Add(Convert.ToInt32(row["SentFlag"]) == 0 ? "Pending" : "Issued");
                    this.ScannedListView.Items.Add(ScannedListViewItem);
                    if ((int)row["SentFlag"] == 0) PendingCount++;
                }
            }

            //Display pending count
            txtPendingCount.Text = "PENDING: " + PendingCount.ToString();
            ScannedListView.Focus();
        }

        private void UpdateDPScannedList()
        {
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    if (CommonFunctions.IsConnected())
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            if ((int)row["SentFlag"] == 0)
                            {
                                CommonFunctions.BarcodeRRNo = row["RRNo"].ToString();
                                CommonFunctions.BarcodeRRSeq = row["RRSeqNo"].ToString();
                                CommonFunctions.BarcodeRRLotSeq = row["LotSeqNo"].ToString();
                                CommonFunctions.BarcodeRRLocSeq = row["LocSeqNo"].ToString();
                                CommonFunctions.BarcodeStockCode = row["StockCode"].ToString();
                                CommonFunctions.BarcodeQuantity = row["Quantity"].ToString();
                                CommonFunctions.BarcodePrintedDate = row["PrintedDateTime"].ToString();
                                CommonFunctions.LocatorCode = row["LocatorCode"].ToString();

                                if (CommonFunctions.ExecuteNonQuery(string.Format(@"EXEC spHandyUpdateDeliveryPreparation '{0}','{1}','{2}','{3}','{4}'"
                                                                            , CommonFunctions.BarcodeRRNo
                                                                            , CommonFunctions.BarcodeRRSeq
                                                                            , CommonFunctions.BarcodeRRLotSeq
                                                                            , CommonFunctions.BarcodeRRLocSeq
                                                                            , row["DPNo"].ToString())))
                                {

                                    CommonFunctions.ScannedLabelForReprinting(false, false, CommonFunctions.LocatorCode, string.Format("DP-H{0}", CommonFunctions.HandyNo));
                                    CommonFunctions.CeExecuteNonQuery(string.Format(CommonQueryStrings.Mobile.Update.DPRRNoSentFlagCommit
                                                                            , CommonFunctions.BarcodeRRNo
                                                                            , CommonFunctions.BarcodeRRSeq
                                                                            , CommonFunctions.BarcodeRRLotSeq
                                                                            , CommonFunctions.BarcodeRRLocSeq));

                                }
                            }
                        }
                    }
                }
            }

           // IsAllDRReposted(_CurrentFunction);
            RefreshList(_CurrentFunction);
        }

        private void IsAllDRReposted(CommonEnum.Function CurrentFunction)
        {
            bool isDP = false;
            if (CurrentFunction == CommonEnum.Function.DeliveryPreparation)
                isDP = true;

            bool AllReposted = true;
            DataTable dt = new DataTable();
            dt = isDP ? DeliveryPreparationBaseOld.GetDPControlNoList() : DeliveryChecklistBase.GetDRControlNoList();
            bool IsCounted = false;
            if (dt != null)
            {
                // int CoutDP = 0;
                if (dt.Rows.Count > 0)
                {
                    IsCounted = true;
                    foreach (DataRow row in dt.Rows)
                    {
                        string ControlNo = row["ControlNo"].ToString();
                        #region Update commit flag and clear DR list if all items are already sent

                        string QueryAllSent = string.Format(isDP ? CommonQueryStrings.Mobile.ViewFiltered.DPRRUnpostCount : CommonQueryStrings.Mobile.ViewFiltered.ChecklistRRUnpostCount, ControlNo);
                        bool isAllSent = CommonFunctions.CEDataReader(QueryAllSent).Equals("0") ? true : false;
                        if (isAllSent)
                        {
                            DeliveryChecklistBase.UpdateDRControlNoCompleteFlag(ControlNo); //This function is common.
                            CommonFunctions.CeExecuteNonQuery(string.Format(isDP ? CommonQueryStrings.Mobile.Delete.DPSentItems : CommonQueryStrings.Mobile.Delete.ChecklistSentItems, ControlNo));
                        }

                        #endregion


                        #region Verifying items only that are scanned and unset after manual reposting

                        string QueryAllScannedSent = string.Format(isDP ? CommonQueryStrings.Mobile.ViewFiltered.DPRRScannedUnpostCount : CommonQueryStrings.Mobile.ViewFiltered.ChecklistRRScannedUnpostCount, ControlNo);
                        bool isAllScannedSent = CommonFunctions.CEDataReader(QueryAllScannedSent).Equals("0") ? true : false;
                        if (!isAllScannedSent)
                        {
                            AllReposted = false;
                        }
                        AllReposted = AllReposted ? isAllScannedSent : false;

                        #endregion
                    }
                }
            }

            if (AllReposted)
            {
                if (IsCounted)
                {
                    CommonFunctions.MessageShow(CommonMsg.Success.d_S, CommonEnum.NotificationType.Success);
                }
            }
            else
            {
                CommonFunctions.MessageShow(CommonMsg.Info.NotAllItemsPosted, CommonEnum.NotificationType.Warning);
            }
        }

        private void UpdateDRScannedList()
        {
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    if (CommonFunctions.IsConnected())
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            if ((int)row["SentFlag"] == 0)
                            {
                                CommonFunctions.BarcodeRRNo = row["RRNo"].ToString();
                                CommonFunctions.BarcodeRRSeq = row["RRSeqNo"].ToString();
                                CommonFunctions.BarcodeRRLotSeq = row["LotSeqNo"].ToString();
                                CommonFunctions.BarcodeRRLocSeq = row["LocSeqNo"].ToString();
                                CommonFunctions.BarcodeStockCode = row["StockCode"].ToString();
                                CommonFunctions.BarcodeQuantity = row["Quantity"].ToString();
                                CommonFunctions.BarcodePrintedDate = row["PrintedDateTime"].ToString();
                                CommonFunctions.LocatorCode = row["LocatorCode"].ToString();

                                if (CommonFunctions.ExecuteNonQuery(string.Format(@"EXEC spHandyUpdateMaterialIssuanceBackup '{0}','{1}','{2}','{3}','{4}','{5}','{6}'"
                                                                            , CommonFunctions.BarcodeRRNo
                                                                            , CommonFunctions.BarcodeRRSeq
                                                                            , CommonFunctions.BarcodeRRLotSeq
                                                                            , CommonFunctions.BarcodeRRLocSeq
                                                                            , row["DRNo"].ToString()
                                                                            , string.IsNullOrEmpty(CommonFunctions.BarcodeQuantity)? 0: CommonFunctions.ConvertStringDecimal(CommonFunctions.BarcodeQuantity)
                                                                            , CommonFunctions.Username)))
                                {

                                    CommonFunctions.ScannedLabelForReprinting(false, false, CommonFunctions.LocatorCode, string.Format("DR-H{0}", CommonFunctions.HandyNo));
                                    CommonFunctions.CeExecuteNonQuery(string.Format(CommonQueryStrings.Mobile.Update.CheckListRRSentFlagCommit_Issuance
                                                                            , CommonFunctions.BarcodeRRNo
                                                                            , CommonFunctions.BarcodeRRSeq
                                                                            , CommonFunctions.BarcodeRRLotSeq
                                                                            , CommonFunctions.BarcodeRRLocSeq));
                                }
                            }
                        }
                    }
                }
            }

            IsAllDRReposted(_CurrentFunction);
            RefreshList(_CurrentFunction);
        }

        private void UpdateIssuanceScannedList()
        {
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    if (CommonFunctions.IsConnected())
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            if ((int)row["SentFlag"] == 0)
                            {
                                CommonFunctions.BarcodeRRNo = row["RRNo"].ToString();
                                CommonFunctions.BarcodeRRSeq = row["RRSeqNo"].ToString();
                                CommonFunctions.BarcodeRRLotSeq = row["RRLotSeqNo"].ToString();
                                CommonFunctions.BarcodeRRLocSeq = row["RRLocSeqNo"].ToString();
                                CommonFunctions.BarcodeStockCode = row["StockCode"].ToString();
                                CommonFunctions.BarcodeQuantity = row["Quantity"].ToString();
                                CommonFunctions.BarcodePrintedDate = row["PrintedDateTime"].ToString();
                                CommonFunctions.LocatorCode = row["LocatorCode"].ToString();

                                if (CommonFunctions.ExecuteNonQuery(string.Format(@"EXEC spHandyUpdateMaterialIssuanceStatus '{0}','{1}','{2}','{3}','{4}','{5}','{6}'"
                                                                            , CommonFunctions.BarcodeRRNo
                                                                            , CommonFunctions.BarcodeRRSeq
                                                                            , CommonFunctions.BarcodeRRLotSeq
                                                                            , CommonFunctions.BarcodeRRLocSeq
                                                                            , row["IssuanceNo"].ToString()
                                                                            , string.IsNullOrEmpty(CommonFunctions.BarcodeQuantity) ? 0 : CommonFunctions.ConvertStringDecimal(CommonFunctions.BarcodeQuantity)
                                                                            , CommonFunctions.Username)))
                                {

                                    CommonFunctions.ScannedLabelForReprinting(false, false, CommonFunctions.LocatorCode, string.Format("DR-H{0}", CommonFunctions.HandyNo));
                                    CommonFunctions.CeExecuteNonQuery(string.Format(CommonQueryStrings.Mobile.Update.CheckListRRSentFlagCommit_Issuance
                                                                            , CommonFunctions.BarcodeRRNo
                                                                            , CommonFunctions.BarcodeRRSeq
                                                                            , CommonFunctions.BarcodeRRLotSeq
                                                                            , CommonFunctions.BarcodeRRLocSeq));
                                }
                            }
                        }
                    }
                }
            }

            IsAllDRReposted(_CurrentFunction);
            RefreshList(_CurrentFunction);
        }

        private DataTable GetTable(CommonEnum.Function CurrentFunction)
        {
            switch (CurrentFunction)
            {
                case CommonEnum.Function.DeliveryPreparation:
                    dt = DeliveryPreparationBaseOld.GetDPScannedList();
                    break;
                case CommonEnum.Function.DeliveryChecklist:
                    dt = DeliveryChecklistBase.GetDRScannedList();
                    break;
                case CommonEnum.Function.MaterialIssuance:
                    //dt = Handy.Lib.MaterialTransferAndIssuance.MaterialIssuanceBase.GetIssuancecannedListByItem(WRISNo, LotCodex);
                    dt = Handy.Lib.MaterialTransferAndIssuance.MaterialIssuanceBase.GetIssuancecannedList(WRISNo);
                    break;
                case CommonEnum.Function.MaterialTransfer:
                    dt = DeliveryChecklistBase.GetDRScannedList();
                    break;
            }

            return dt;
        }

        #endregion

        #region Override

        protected override void BaseWindow_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                case Keys.F14:
                    {
                        if (PendingCount > 0)
                        {
                            if (_CurrentFunction == CommonEnum.Function.DeliveryPreparation)
                                UpdateDPScannedList();
                            else if (_CurrentFunction == CommonEnum.Function.DeliveryChecklist)
                                UpdateDRScannedList();
                            else if((_CurrentFunction) == CommonEnum.Function.MaterialIssuance)
                                UpdateIssuanceScannedList();
                        }
                    }
                    break;
                case Keys.F4:
                case Keys.F15:
                    DeliveryPreparationBaseOld.CleanDPScannedList();
                    Close();
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

        private void ScanList_Load(object sender, EventArgs e)
        {
            this.SetListDisplay();
            this.RefreshList(_CurrentFunction);
        }

        private void panel2_GotFocus(object sender, EventArgs e)
        {

        }


    }
}