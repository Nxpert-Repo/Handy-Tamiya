using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using System.Data;
using Handy.Lib;

namespace Handy
{
    public partial class LocatorTaggingListWindow : BaseWindow
    {
        #region Variables

        private Int32 Count = 0;
        private DataTable TagList = new DataTable();
        private CommonEnum.Buttons ExitButton = CommonEnum.Buttons.Exit;

        #endregion

        #region Constructor

        public LocatorTaggingListWindow()
        {
            InitializeComponent();
            //base.SetBarcodeReader(BCReader, BCData);
            base.SetWindowTitle("Tagged List");
            base.SetActiveButtons(BaseButtons.Clear, BaseButtons.Cancel);
            CommonInterfaceFunctions.WLANAddSignalQualityHandler(base.pcbSignal, true);
        }

        #endregion

        #region Function

        private void SetListDisplay()
        {
            //this.ListView1.Location = new System.Drawing.Point(5, 76);
            //this.ListView1.Size = new System.Drawing.Size(311, 175);
            //this.lblListHeader.Location = new System.Drawing.Point(7, 77);
            //this.lblListHeader.Size = new System.Drawing.Size(308, 26);
            //this.lblListHeader.BackColor = System.Drawing.Color.Teal;
            lblListHeader.Visible = false;
        }

        private void RefreshList()
        {
            this.Count = 0;
            this.lblCount.Text = string.Format("COUNT: {0}", this.Count);
            this.lblLocatorDesc.Text = "LOCATOR: ";
            bool GreyBack = false;
            //clear recent
            this.ListView1.Items.Clear();
            //this.ListView1.Columns[0].Width = 141;
            //this.ListView1.Columns[1].Width = 92;
            //this.TagList = Logger.GetTextDataTable(Logger.HandyPath, Logger.HandyTaggingFile, 2,false,'~'); //Column 2 is RR No.
            this.TagList = LocatorTaggingBase.MobiledbTaggedListView();
            if (this.TagList == null)
                return;
            this.Count = this.TagList.Rows.Count;
            int i = 0;
            if (Count > 0)
            {
                //populate
                foreach (DataRow row in this.TagList.Rows)
                {
                    ListViewItem listViewItem1 = new ListViewItem();
                    //Default columns retrieve from text file conversion
                    listViewItem1.ImageIndex = Convert.ToInt16(row["SentFlag"].ToString());
                    listViewItem1.Text = row["TagNo"].ToString();           //Tag-No
                    String Quantity = row["Quantity"].ToString();
                    try
                    {
                        int inputqty = Convert.ToInt32 (row["Quantity"]);
                        Quantity = inputqty.ToString();
                    }
                    catch { }
                    listViewItem1.SubItems.Add(Quantity);           //Input Qty
                    listViewItem1.SubItems.Add(row["LocatorDesc"].ToString()); //Locator Desc
                    listViewItem1.SubItems.Add(row["LocatorCode"].ToString()); //Locator Code
                    if (i == 0)
                    {
                        lblLocatorDesc.Text = "LOCATOR: " + row["LocatorCode"].ToString() + " [" + row["LocatorDesc"].ToString() + "]";
                    }
                    this.ListView1.Items.Add(listViewItem1);
                    //Set Back Color
                    if (GreyBack)
                    {
                        listViewItem1.ListView.Items[i].BackColor = Color.LightCyan;
                        listViewItem1.ListView.Items[i].ForeColor = Color.Black;
                        GreyBack = false;
                    }
                    else
                    {
                        listViewItem1.ListView.Items[i].BackColor = Color.White;
                        listViewItem1.ListView.Items[i].ForeColor = Color.Black;
                        GreyBack = true;
                    }
                    ++i;
                }

                this.GetFirstRow();
            }
            this.lblCount.Text = string.Format("COUNT: {0}", this.Count);
            this.ListView1.Focus();
        }

        private void GetFirstRow()
        {
            if (ListView1.Items.Count > 0)
            {
                lblLocatorDesc.Text = "LOCATOR: " + this.ListView1.Items[0].SubItems[3].Text.Trim() + " [" + this.ListView1.Items[0].SubItems[2].Text.Trim() + "]";
            }
        }

        private void GetSelectedRow()
        {
            if (this.ListView1.Items.Count > 0)
            {
                for (int i = 0; i < this.ListView1.Items.Count; i++)
                {
                    if (this.ListView1.Items[i].Selected == true)
                    {
                        lblLocatorDesc.Text = "LOCATOR: " + this.ListView1.Items[i].SubItems[3].Text.Trim()+ " [" +this.ListView1.Items[i].SubItems[2].Text.Trim() + "]";
                    }
                }
            }
        }

        private void ClearButton(object sender, EventArgs e)
        {
            if (DialogResult.Yes == CommonFunctions.MessageShow(CommonMsg.Warning.d_ClearTagged, CommonEnum.NotificationType.Question, CommonEnum.MessageButtons.YesNo))
            {
                //if (!Logger.isFileCleared(Logger.HandyPath, Logger.HandyTaggingFile))
                //    CommonFunctions.MessageShow("Unable to clear file.", CommonEnum.NotificationType.Warning);
                LocatorTaggingBase.MobiledbClearTagging();
                this.RefreshList();
                ExitButton = CommonEnum.Buttons.Exit;
            }
        }

        private void CancelButton(object sender, EventArgs e)
        {
            if (ExitButton == CommonEnum.Buttons.Cancel)
            {
                ExitButton = CommonEnum.Buttons.Exit;
            }
            else
                Close();
        }

        #endregion

        #region Override

        protected override void BaseWindow_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    this.GetSelectedRow();
                    break;
                case Keys.Down:
                    this.GetSelectedRow();
                    break;
                case Keys.F1:
                case Keys.F14:
                    ClearButton(this, e);
                    break;
                case Keys.F4:
                case Keys.F15:
                    CancelButton(this, e);
                    break;
                case Keys.Left:
                    if (this.Count < 100) // limit retrieval
                    {
                        this.Close();
                        CommonFunctions.ClearStrings();
                        LocatorUnTaggingListWindow _TaggingListForm = new LocatorUnTaggingListWindow();
                        _TaggingListForm.ShowDialog();
                    }
                    break;
                case Keys.Right:
                    if (this.Count < 100) // limit retrieval
                    {
                        this.Close();
                        CommonFunctions.ClearStrings();
                        LocatorUnTaggingListWindow _TaggingListForm2 = new LocatorUnTaggingListWindow();
                        _TaggingListForm2.ShowDialog();
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

        #endregion

        //Events

        private void LocatorTaggingListWindow_Load(object sender, EventArgs e)
        {

            this.SetListDisplay();
            this.Count =  LocatorTaggingBase.CountTaggedList();
            this.RefreshList();
            if (this.Count > 300)
            {
                if (DialogResult.Yes == CommonFunctions.MessageShow(CommonMsg.Warning.d_ClearExceededTagged, CommonEnum.NotificationType.Question, CommonEnum.MessageButtons.YesNo))
                {
                    //if (!Logger.isFileCleared(Logger.HandyPath, Logger.HandyTaggingFile))
                    //    CommonFunctions.MessageShow("Unable to clear file.", CommonEnum.NotificationType.Warning);
                    LocatorTaggingBase.MobiledbClearTagging();
                    this.RefreshList();
                }
            }

            this.timerBackGroudTransaction.Enabled = true;

        }

        private void timerBackGroudTransaction_Tick(object sender, EventArgs e)
        {

        }

        private void timerBackGroudTransaction_Tick_1(object sender, EventArgs e)
        {
            //START Back ground transactions : Interval before starting 3 seconds
            timerBackGroudTransaction.Enabled = false;
            LocatorTaggingBase.OnloadStartBackGroundTransactions();
        }

        private void LocatorTaggingListWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                this.timerBackGroudTransaction.Enabled = false;
                this.timerBackGroudTransaction.Dispose();
            }
            catch { }
        }
    }
}