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
    public partial class DisplayNewTagsWindow : BaseWindow

    {
        #region Variable Declarations

        public CommonEnum.Buttons ExitButton = CommonEnum.Buttons.Exit;
        private string BarcodeRRNo = string.Empty;
        private string BarcodeRRSeqNo = string.Empty;
        private string BarcodeLotSeqNo = string.Empty;
        private string BarcodeLocSeqNo = string.Empty;

        #endregion

        #region Constructor

        public DisplayNewTagsWindow(BarcodeReader BCReader, ReaderData BCData)
        {
            InitializeComponent();
            base.SetBarcodeReader(BCReader, BCData);
            base.SetWindowTitle("Display New Tags");
            base.SetActiveButtons(BaseButtons.Generate, BaseButtons.Cancel);
            CommonInterfaceFunctions.WLANAddSignalQualityHandler(base.pcbSignal, true);
            //this.TagNumber.Text = BCData.Text;
           
            //DisplayAllNewTagNo();
        }

        #endregion
        
        #region User Defined Functions

        /// <summary>
        /// Adjusts ListView properties.
        /// </summary>
        private void SetListDisplay()
        {
            this.lblGridHeader.Size = new System.Drawing.Size(215, 23);
            this.lblGridHeader.BackColor = System.Drawing.Color.Teal;
            this.lblGridHeader.Location = new System.Drawing.Point(13, 108);
            this.listViewNewTags.Location = new System.Drawing.Point(12, 107);
            this.listViewNewTags.Size = new System.Drawing.Size(217, 172);
        }

        /// <summary>
        /// Closes this window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Populates List View with tag numbers and shows a message information.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateButton(object sender, EventArgs e) 
        {
            if (DisplayAllNewTagNo())
            {
                CommonFunctions.MessageShow("Scanned barcode is latest.", CommonMsg.Info.BarcodeUpdated, CommonEnum.NotificationType.Information, CommonEnum.MessageButtons.CloseOnly);
            }
        }

        /// <summary>
        /// Reads Tag Number from T_ReceivingReportDetail and displays it.
        /// </summary>
        /// <param name="BarcodeData">Last read barcode data. Not used by method.</param>
        private void GetBarcodeData(string BarcodeData) 
        {
             DataTable dt = null;

            try
            {
                    dt = DisplayNewTagsWindowBase.GetTagNoByRRNo(CommonFunctions.BarcodeRRNo, CommonFunctions.BarcodeRRSeq, CommonFunctions.BarcodeRRLotSeq, CommonFunctions.BarcodeRRLocSeq);
                    if (dt != null)
                    {
                        if(dt.Rows.Count > 0 )
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                this.TagNumber.Text = row["TagNo"].ToString() + "-" + row["TagSeqNo"].ToString();
                            }
                        }
                    }

            }
            catch(Exception e)
            {
                CommonFunctions.MessageShow(e.Message, CommonMsg.Warning.d_NoDataSource, CommonEnum.NotificationType.Error, CommonEnum.MessageButtons.CloseOnly);
            }
        }

        /// <summary>
        /// Populates List View with tag numbers for the previously read RR info. 
        /// Returns true if there is no data, false otherwise.
        /// </summary>
        /// <returns></returns>
        private bool DisplayAllNewTagNo() 
        {
            DataTable dtTagNumbers = null;
            bool isTagNumberUpdated = false; ;
            dtTagNumbers = DisplayNewTagsWindowBase.GetAllNewTagNumbers(BarcodeRRNo, BarcodeRRSeqNo, BarcodeLotSeqNo, BarcodeLocSeqNo);

            if (dtTagNumbers == null || dtTagNumbers.Rows.Count == 0)
            {
                isTagNumberUpdated = true;
            }
            else 
            {
                DataRow row = dtTagNumbers.Rows[0];

                ListViewItem listViewItem1 = new ListViewItem();
                listViewItem1.Text = row["TagNo"].ToString() + "-" + row["TagSeqNo"].ToString();
                listViewItem1.SubItems.Add(row["LocatorCode"].ToString());
                this.listViewNewTags.Items.Add(listViewItem1);

                isTagNumberUpdated = false;

            }
            return isTagNumberUpdated;
        }


        private void ClosingWindow()
        {
            CommonFunctions.CeExecuteNonQuery("DELETE ScanStatus");
            ClearAll();
            Close();
        }

        private void ClearAll()
        {
            TagNumber.Text = "";
            //CommonFunctions.BarcodeWRISNo = string.Empty;
            CommonFunctions.ClearStrings();
        }

        /// <summary>
        /// Retrieves tag numbers and populates List View.
        /// </summary>
        private void RefreshList()
        {
            //clear recent
            listViewNewTags.Items.Clear();
            //Get
            DataTable dt = DisplayNewTagsWindowBase.GetAllNewTagNumbers();

            if (dt.Rows.Count > 0)
            {
                //populate

                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem listViewItem1 = new ListViewItem();
                    listViewItem1.ImageIndex = CommonFunctions.ItemStatus((int)row["ScanFlag"], (int)row["SentFlag"]);        //ScanFlag 1 for scanned
                    listViewItem1.Text = row["TagNo"].ToString() + "-" + row["TagSeqNo"].ToString();           //TagNo
                    listViewItem1.SubItems.Add(row["LocatorCode"].ToString());
                    this.listViewNewTags.Items.Add(listViewItem1);
                }

                this.GetFirstRow();

            }
        }

        /// <summary>
        /// Updates TagNumber control using first item in the List View.
        /// </summary>
        private void GetFirstRow()
        {
            if (listViewNewTags.Items.Count > 0)
            {
                TagNumber.Text = listViewNewTags.Items[0].SubItems[1].Text.Trim();
            }
        }


        #endregion

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #region Overrides

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

        /// <summary>
        /// Process keystrokes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void BaseWindow_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                case Keys.F14:
                    base.BarcodeReader_Stop();
                    CommonInterfaceFunctions.WLANAddSignalQualityHandler(base.pcbSignal, true);
                    //
                    GenerateButton(this, e);
                    //RefreshList();
                    base.BarcodeReader_Start();
                    break;
                case Keys.F4:
                case Keys.F15:
                    CancelButton(this, e);
                   // Close();
                    break;
                case Keys.Down:
                    if (!listViewNewTags.Focused)
                    {
                        listViewNewTags.Focus();
                        if (listViewNewTags.Items != null)
                        {
                            if (listViewNewTags.Items.Count > 0)
                            {
                                listViewNewTags.Items[0].Selected = true;
                                listViewNewTags.Items[0].Focused = true;
                                TagNumber.Text = (listViewNewTags.FocusedItem == null) ? "" : string.IsNullOrEmpty(listViewNewTags.FocusedItem.SubItems[1].Text) ? "" : listViewNewTags.FocusedItem.SubItems[1].Text;
                                
                            }
                        }
                    }
                    break;
                
                
            }

            base.BaseWindow_KeyUp(sender, e);
        }
        #endregion

        #region Events

        /// <summary>
        /// Populates Tag Number field for the given RR info passed from previous operation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplayNewTagsWindow_Load(object sender, EventArgs e)
        {
            this.SetListDisplay(); 
            CommonFunctions.CurrentFunction = CommonEnum.Function.DisplayNewTags;
            GetBarcodeData(BCData.Text);
            this.TagNumber.ReadOnly = true;
            this.TagNumber.Focus();
        }
        #endregion

    }
} 