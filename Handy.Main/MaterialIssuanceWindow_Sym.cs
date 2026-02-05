//UltimateDeliveryChecklistWindow
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Handy.Lib;
using Handy.Lib.MaterialTransferAndIssuance;

namespace Handy
{
    public partial class MaterialIssuanceWindow_Sym : BaseWindow
    {
        #region Variables

        private CommonEnum.Buttons ExitButton = CommonEnum.Buttons.Exit;
        string WRISNo = "";
        string LotCodex = "";
        #endregion

        #region Constructor 

        public MaterialIssuanceWindow_Sym(BarcodeReader BCReader, ReaderData BCData)
        {
            InitializeComponent();
            base.SetBarcodeReader(BCReader, BCData);
            base.SetWindowTitle("Material Issuance");
            base.SetActiveButtons(BaseButtons.View, BaseButtons.Cancel);
            CommonInterfaceFunctions.WLANAddSignalQualityHandler(base.pcbSignal, true);
        }

        #endregion

        #region Functions

        private void SetListDisplay()
        {
            this.lblGridHeader.Location = new System.Drawing.Point(12, 104);
            this.lblGridHeader.Size = new System.Drawing.Size(297, 26);
            this.listView1.Location = new System.Drawing.Point(11, 103);
            this.listView1.Size = new System.Drawing.Size(299, 154);
            this.lblGridHeader.BackColor = System.Drawing.Color.Teal;
        }

        private void SaveButton(object sender, EventArgs e)
        {
            if (DeliveryChecklistBase.IsAllScannedDR())
            {
                ClearAll();
                ExitButton = CommonEnum.Buttons.Exit;
            }
            else
            {
                ClearAll();
                ExitButton = CommonEnum.Buttons.Exit;
            }

            base.BarcodeReader_Start();
        }

        private void CancelButton(object sender, EventArgs e)
        {
            if (ExitButton == CommonEnum.Buttons.Cancel)
            {
                ClearAll();
                ExitButton = CommonEnum.Buttons.Exit;
                //TagNo.Focus();
                base.BarcodeReader_Start();
            }
            else
            {
                string[] ScannedSentChecker = MaterialIssuanceBase.CheckScannedIfAlreadySent();
                bool IsAllScanned = ScannedSentChecker[0].Equals("0") ? true : false;
                bool IsAllSent = ScannedSentChecker[1].Equals("0") ? true : false;
                if (IsAllScanned && !IsAllSent)
                {
                    if (DialogResult.Yes == CommonFunctions.MessageShow(CommonMsg.Info.NotAllItemsScanSent, CommonEnum.NotificationType.Warning, CommonEnum.MessageButtons.YesNo))
                    {
                        DataTable dtUnsentDr = new DataTable();
                        dtUnsentDr = MaterialIssuanceBase.GetUnsetIssuance();
                        if (dtUnsentDr == null)
                        {
                            //do nothing
                        }
                        else
                        {
                            int UnpostedDR = dtUnsentDr.Rows.Count;
                            int CountPostedDR = 0;

                            foreach (DataRow dr in dtUnsentDr.Rows)
                            {
                                string DRNo = dr["ControlNo"].ToString();
                                CountPostedDR = MaterialIssuanceBase.IsAllScannedIssuance(DRNo) ? ++CountPostedDR : CountPostedDR;
                            }

                            if (CountPostedDR == UnpostedDR)
                            {
                                CommonFunctions.MessageShow(CommonMsg.Success.d_S, CommonEnum.NotificationType.Success);
                                RefreshList();
                            }
                            else
                            {
                                CommonFunctions.MessageShow(CommonMsg.Warning.DRUnposted, CommonEnum.NotificationType.Warning);
                                CommonInterfaceFunctions.WLANRemoveSignalQualityHandler();
                                ScannedListWindow ScanListView = new ScannedListWindow(CommonEnum.Function.MaterialIssuance,IssuanceNo.Text);
                                ScanListView.ShowDialog();
                                CommonInterfaceFunctions.WLANAddSignalQualityHandler(base.pcbSignal, true);
                                RefreshList();
                            }
                            dtUnsentDr.Dispose();
                            dtUnsentDr = null;
                        }
                        return;
                    }
                }
                else if (!IsAllScanned)
                {
                    if (DialogResult.No == CommonFunctions.MessageShow(CommonMsg.Info.NotAllItemsScanned, CommonEnum.NotificationType.Warning, CommonEnum.MessageButtons.YesNo))
                    {
                        return;
                    }
                }


                if (DeliveryChecklistBase.IsAllSentDR())
                {
                    this.ClosingWindow();
                }
                else
                {
                    Audio.PlayErrorBeep();
                    this.ClosingWindow();
                }
            }
        }

        private void ClosingWindow()
        {
            ClearAll();
            CommonFunctions.LocatorCode = string.Empty;
            CommonFunctions.LocatorDesc = string.Empty;
            CommonFunctions.BarcodeWRISNo = string.Empty;
            CommonFunctions.Customer = string.Empty;
            DeliveryChecklistBase.CleanDRScannedList();
            CommonFunctions.CeExecuteNonQuery("DELETE ScanStatus");
            Close();
        }

        private void ClearAll()
        {
            IssuanceNo.Text = "";
            IssuanceType.Text = "";
            CommonFunctions.BarcodeWRISNo = string.Empty;
            CommonFunctions.ClearStrings();
        }

        private void GetDeliveryReportRRInfo()
        {
            if (MaterialIssuanceBase.IsDeliveryReportRRInfoReprint())
            {
                CommonFunctions.MessageShow(CommonMsg.Warning.d_Reprint, CommonEnum.NotificationType.Warning);
                if (DialogResult.Yes == CommonFunctions.MessageShow(string.Format(CommonMsg.Warning.ScanDPPrompt), CommonMsg.Warning.Reprint, CommonEnum.NotificationType.Warning, CommonEnum.MessageButtons.YesNo))
                {
                    DisplayNewTagsWindow _DisplayNewTagsWindow = new DisplayNewTagsWindow(BCReader, BCData);
                    _DisplayNewTagsWindow.ShowDialog();
                    base.BarcodeReader_Start();
                }
                else {
                    ClearAll();
                    base.BarcodeReader_Start();
                }
               
            }
            else if (MaterialIssuanceBase.IsDeliveryReportRRInfoUpdated())
            {
                RefreshList();
                IssuanceType.Text = "";
                IssuanceNo.Text = "";
            }
            else
            {
                if (DialogResult.Yes == CommonFunctions.MessageShow(string.Format(CommonMsg.Warning.ScanDPPrompt), CommonMsg.Warning.Reprint, CommonEnum.NotificationType.Warning, CommonEnum.MessageButtons.YesNo))
                {
                    DisplayNewTagsWindow _DisplayNewTagsWindow = new DisplayNewTagsWindow(BCReader, BCData);
                    _DisplayNewTagsWindow.ShowDialog();
                    base.BarcodeReader_Start();
                }
                else
                {
                    ClearAll();
                    base.BarcodeReader_Start();
                }
                
            }

            base.BarcodeReader_Start();
        }

        private void RefreshList()
        {
            //clear recent
            listView1.Items.Clear();
            //Get
            DataTable dt = MaterialIssuanceBase.GetMaterialIssuanceList();

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    //populate

                    foreach (DataRow row in dt.Rows)
                    {
                        ListViewItem listViewItem1 = new ListViewItem();
                        try
                        {
                            int ScanFlag = (int)row["ScanFlag"];
                            int SentFlag = (int)row["SentFlag"];
                            listViewItem1.ImageIndex = CommonFunctions.ItemStatus(ScanFlag, SentFlag);
                        }
                        catch (Exception err)
                        { }
                        listViewItem1.Text = row["LotCode"].ToString();
                        listViewItem1.SubItems.Add(row["IssuanceNo"].ToString());
                        listViewItem1.SubItems.Add(row["IssuanceDesc"].ToString());
                        this.listView1.Items.Add(listViewItem1);
                    }

                    this.GetFirstRow();
                }
            }
            else
                CommonFunctions.MessageShow("Unable to retrieve information");
        }

        private void GetFirstRow()
        {
            if (listView1.Items.Count > 0)
            {
                IssuanceNo.Text = listView1.Items[0].SubItems[3].Text.Trim();
                IssuanceType.Text = listView1.Items[0].SubItems[4].Text.Trim();
            }
        }

        #endregion

        #region Overrides

        protected override void BaseWindow_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F14:
                    base.BarcodeReader_Stop();
                    StatusListWindow StatusListView = new StatusListWindow(CommonEnum.Function.MaterialIssuance);
                    StatusListView.ShowDialog();
                    CommonInterfaceFunctions.WLANAddSignalQualityHandler(base.pcbSignal, true);
                    RefreshList();
                    base.BarcodeReader_Start();
                    break;
                case Keys.F15:
                    CancelButton(this, e);
                    break;
                case Keys.Enter:
                    base.BarcodeReader_Stop();
                    ScannedListWindow ScanListView = new ScannedListWindow(CommonEnum.Function.MaterialIssuance, IssuanceNo.Text);
                    ScanListView.ShowDialog();
                    CommonInterfaceFunctions.WLANAddSignalQualityHandler(base.pcbSignal, true);
                    RefreshList();
                    base.BarcodeReader_Start();
                    break;
                case Keys.Down:
                    if (!listView1.Focused)
                    {
                        listView1.Focus();
                        if (listView1.Items != null)
                        {
                            if (listView1.Items.Count > 0)
                            {
                                listView1.Items[0].Selected = true;
                                listView1.Items[0].Focused = true;
                                IssuanceNo.Text = (listView1.FocusedItem == null) ? "" : string.IsNullOrEmpty(listView1.FocusedItem.SubItems[1].Text) ? "" : listView1.FocusedItem.SubItems[1].Text;
                                IssuanceType.Text = (listView1.FocusedItem == null) ? "" : string.IsNullOrEmpty(listView1.FocusedItem.SubItems[2].Text) ? "" : listView1.FocusedItem.SubItems[2].Text;
                            }
                        }
                    }
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
            base.BarcodeReader_AnalyzeType(Sender, e);

            switch (base.ScannedBarcodeType)
            {
                case CommonEnum.LabelType.Item2D:
                    {
                        GetDeliveryReportRRInfo();
                    }
                    break;
                case CommonEnum.LabelType.Invalid:
                    {
                        ClearAll();
                        base.BarcodeReader_Start();
                    }
                    break;
                case CommonEnum.LabelType.WRISNo:
                    {
                        ClearAll();
                        RefreshList();
                        if (!listView1.Focused)
                        {
                            listView1.Focus();
                            if (listView1.Items != null)
                            {
                                listView1.Items[0].Selected = true;
                                listView1.Items[0].Focused = true;
                                IssuanceNo.Text = (listView1.FocusedItem == null) ? "" : string.IsNullOrEmpty(listView1.FocusedItem.SubItems[1].Text) ? "" : listView1.FocusedItem.SubItems[1].Text;
                                IssuanceType.Text = (listView1.FocusedItem == null) ? "" : string.IsNullOrEmpty(listView1.FocusedItem.SubItems[2].Text) ? "" : listView1.FocusedItem.SubItems[2].Text;
                            }
                        }
                        base.BarcodeReader_Start();
                    }
                    break;
                case CommonEnum.LabelType.ServerNotFound:
                    {
                        ClearAll();
                        IssuanceType.Text = "";
                        IssuanceNo.Text = "";
                        IssuanceNo.Focus();
                        base.BarcodeReader_Start();
                    }
                    break;
            }

            base.ScannedBarcodeType = CommonEnum.LabelType.Null;
        }

        #endregion

        private void MaterialIssuanceWindow_Load(object sender, EventArgs e)
        {
            this.SetListDisplay();
            CommonFunctions.CurrentFunction = CommonEnum.Function.MaterialIssuance;
            MaterialIssuanceBase.UpdateWRISScanStatusList();
            this.RefreshList();
            this.IssuanceNo.Focus();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            IssuanceNo.Text = (listView1.FocusedItem == null) ? "" : string.IsNullOrEmpty(listView1.FocusedItem.SubItems[1].Text) ? "" : listView1.FocusedItem.SubItems[1].Text;
            IssuanceType.Text = (listView1.FocusedItem == null) ? "" : string.IsNullOrEmpty(listView1.FocusedItem.SubItems[2].Text) ? "" : listView1.FocusedItem.SubItems[2].Text;
        }

    }
}