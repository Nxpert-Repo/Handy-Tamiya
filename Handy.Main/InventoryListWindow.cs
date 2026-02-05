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
    public partial class InventoryListWindow : BaseWindow
    {
        #region Variables

        private Int32 Count = 0;
        private DataTable dtInventoryList = new DataTable();
        
        #endregion Variables

        #region Constructor

        public InventoryListWindow()
        {
            InitializeComponent();
            base.SetBarcodeReader(BCReader, BCData);
            base.SetWindowTitle("Inventory List");
            base.SetActiveButtons(BaseButtons.Post, BaseButtons.Cancel);
            CommonInterfaceFunctions.WLANAddSignalQualityHandler(base.pcbSignal, true); 
        }

        #endregion Constructor

        #region Functions

        private void SetGridHeaderDisplay()
        {
            this.lblGridHeader.BackColor = System.Drawing.Color.Teal;
            this.lblFilterHeader.BackColor = System.Drawing.Color.Teal;
        }

        private void GetSelectedRow()
        {
            if (listView1.Items.Count > 0)
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].Selected == true)
                    {
                        RRNo.Text = listView1.Items[i].SubItems[1].Text.Trim();
                        lblRemark.Text ="Remark : " + listView1.Items[i].SubItems[4].Text.Trim();
                        txtLocatorDesc.Text = listView1.Items[i].SubItems[5].Text.Trim();
                        lblSpecs.Text = "Specs: " + listView1.Items[i].SubItems[6].Text.Trim();

                    }
                }
            }
        }

        private void RefreshList()
        {
            RefreshList(CommonEnum.UploadStats.AllValid); //Default
        }

        private void RefreshList(CommonEnum.UploadStats UploadSatus)
        {
            this.PressFilter(UploadSatus);

            Cursor.Current = Cursors.WaitCursor;
            //PostFlag 0 - pending ; 1 - sent ; 2 - failed
            int Sent = 0, Pending = 0, Failed = 0, ReprintCount = 0;
            this.Count = 0;
            this.lblCount.Text = string.Format("COUNT : {0}", this.Count);
            this.lblPending.Text = string.Format("PENDING : {0}", Pending);
            this.RRNo.Text = string.Empty;
            this.txtLocatorDesc.Text = string.Empty;
            lblSpecs.Text = "Specs: ";
            bool GreyBack = false;
            //clear recent
            this.listView1.Items.Clear();
            if (CommonFunctions.UseMobileDB)
            {
                this.dtInventoryList = InventoryBase.MobileInventoryDisplayList(UploadSatus); //20130405 Allen Modify: changed CommonFunctions to InventoryBase
            }
            else
            {
                this.dtInventoryList = Logger.GetTextDataTable(Logger.HandyPath, Logger.HandyMITFile, 2); //Second Column RR Number as Primary
            }
            if (dtInventoryList == null)
                return;
            this.Count = this.dtInventoryList.Rows.Count;
            int i = 0;
            if (this.Count > 0)
            {
                //populate
                foreach (DataRow row in dtInventoryList.Rows)
                {
                    if (i == 0)
                    {
                        this.RRNo.Text = row["COLUMN_2"].ToString();
                        this.txtLocatorDesc.Text = row["COLUMN_10"].ToString();
                        this.lblSpecs.Text = "Specs: " + row["Inv_Specs"].ToString();         
                    }
                    ListViewItem listViewItem1 = new ListViewItem();
                    //Default columns retrieve from text file conversion
                    listViewItem1.ImageIndex = Convert.ToInt16(row["COLUMN_7"]);        //PostFlag
                    listViewItem1.Text = row["COLUMN_1"].ToString();      //StockCode
                    listViewItem1.SubItems.Add(row["COLUMN_2"].ToString());           //RRNumber
                    string StockQty = string.Format("{0:0.00}", row["COLUMN_3"]);
                    listViewItem1.SubItems.Add(StockQty);   //Quantity
                    StockQty = null;
                    listViewItem1.SubItems.Add(row["COLUMN_8"].ToString());   //Sent date time
                    listViewItem1.SubItems.Add(row["COLUMN_9"].ToString());   //Remark
                    listViewItem1.SubItems.Add(row["COLUMN_10"].ToString());   //Locator Desc
                    listViewItem1.SubItems.Add(row["Inv_Specs"].ToString());   //specs
                    //listViewItem1.Text = row["Inv_Stockname"].ToString();      //StockName //20230807 - marvie commented - change stockname to stockcode
                    //listViewItem1.Text = row["COLUMN_1"].ToString();      //20230807 - marvie added - change stockname to stockcode
                    listViewItem1.Text = row["COLUMN_1"].ToString() + " (" + row["Inv_Stockname"].ToString() + ")";      //20230911 - marvie added - change stockcode to stockcode + stockname


                    this.listView1.Items.Add(listViewItem1);
                    if (Convert.ToInt16(row["COLUMN_7"]) == 0)
                        ++Pending;
                    else if (Convert.ToInt16(row["COLUMN_7"]) == 1)
                        ++Sent;
                    else if (Convert.ToInt16(row["COLUMN_7"]) == 2)
                        ++Failed;
                    //Set Back Color

                    if (listView1.Items[i].SubItems[4].Text.Trim().Equals("FOR REPRINT"))
                    {
                        listViewItem1.ListView.Items[i].BackColor = Color.Red;
                        ++ReprintCount;
                    }
                    else if (GreyBack)
                    {
                        listViewItem1.ListView.Items[i].BackColor = Color.LightCyan;
                        listViewItem1.ListView.Items[i].ForeColor = Color.Black;
                        GreyBack = false;
                    }
                    else
                    {
                        listViewItem1.ListView.Items[i].BackColor = Color.White;
                        listViewItem1.ListView.Items[i].ForeColor = Color.Blue;
                        GreyBack = true;
                    }
                    ++i;
                }
            }
            this.lblCount.Text = string.Format("COUNT : {0}", this.Count);
            this.lblPending.Text = string.Format("PENDING : {0}", Pending);
            Cursor.Current = Cursors.Default;
            this.CountReprint(ReprintCount);
            this.listView1.Focus();
        }

        private void CountReprint(int ReprintCount)
        {
            if (Convert.ToInt16(ReprintCount) > 0)
            {
                CommonFunctions.MessageShow(String.Format(CommonMsg.Warning.d_ReprintCount,ReprintCount), CommonEnum.NotificationType.Warning);
            }
        }

        private void PressFilter(CommonEnum.UploadStats UploadStatus)
        {
            switch (UploadStatus)
            {
                case CommonEnum.UploadStats.All:
                    {
                        this.lblALLPress.BackColor = Color.Maroon;
                        this.lblALLPress.BringToFront();
                        this.lblSentPress.BackColor = Color.Teal;
                        this.lblPendingPress.BackColor = Color.Teal;
                        this.lblReprintPress.BackColor = Color.Teal;
                        this.lblFailedPress.BackColor = Color.Teal;
                    }
                    break;
                case CommonEnum.UploadStats.Sent:
                    {
                        this.lblALLPress.BackColor = Color.Teal;
                        this.lblSentPress.BackColor = Color.Maroon;
                        this.lblSentPress.BringToFront();
                        this.lblPendingPress.BackColor = Color.Teal;
                        this.lblReprintPress.BackColor = Color.Teal;
                        this.lblFailedPress.BackColor = Color.Teal;
                    }
                    break;
                case CommonEnum.UploadStats.Pending:
                    {
                        this.lblALLPress.BackColor = Color.Teal;
                        this.lblSentPress.BackColor = Color.Teal;
                        this.lblPendingPress.BackColor = Color.Maroon;
                        this.lblPendingPress.BringToFront();
                        this.lblReprintPress.BackColor = Color.Teal;
                        this.lblFailedPress.BackColor = Color.Teal;
                    }
                    break;
                case CommonEnum.UploadStats.Reprint:
                    {
                        this.lblALLPress.BackColor = Color.Teal;
                        this.lblSentPress.BackColor = Color.Teal;
                        this.lblPendingPress.BackColor = Color.Teal;
                        this.lblReprintPress.BackColor = Color.Maroon;
                        this.lblReprintPress.BringToFront();
                        this.lblFailedPress.BackColor = Color.Teal;
                    }
                    break;
                case CommonEnum.UploadStats.Failed:
                    {
                        this.lblALLPress.BackColor = Color.Teal;
                        this.lblSentPress.BackColor = Color.Teal;
                        this.lblPendingPress.BackColor = Color.Teal;
                        this.lblReprintPress.BackColor = Color.Teal;
                        this.lblFailedPress.BackColor = Color.Maroon;
                        this.lblFailedPress.BringToFront();
                    }
                    break;
                case CommonEnum.UploadStats.AllValid:
                    {
                        this.lblALLPress.BackColor = Color.Maroon;
                        this.lblALLPress.BringToFront();
                        this.lblSentPress.BackColor = Color.Teal;
                        this.lblPendingPress.BackColor = Color.Teal;
                        this.lblReprintPress.BackColor = Color.Teal;
                        this.lblFailedPress.BackColor = Color.Teal;
                    }
                    break;
            }
        }

        private void ClearSent()
        {
            #region Use Mobile DB

            CommonFunctions.MITMobileDBListClear(CommonQueryStrings.Mobile.Delete.MITMobileDBListClear); 

            #endregion   
        }

        private void SaveButton(object sender, EventArgs e)
        {

            if (this.dtInventoryList != null)
            {
                ProgressMIT.Visible = true;
                ProgressMIT.Value = 0;
                CommonFunctions.MITTable = this.dtInventoryList.Copy();
                CommonFunctions.PostProgress = ProgressMIT;
                CommonFunctions.SendingThread(CommonEnum.Function.Inventory);  
                CommonFunctions.ClearStrings();
                RefreshList();
                ProgressMIT.Visible = false;
            }
        }

        private void CancelButton(object sender, EventArgs e)
        {
            try
            {
                this.dtInventoryList.Dispose();
                CommonFunctions.MITTable.Dispose();
            }
            catch { }
            Close();
        }

        #endregion Functions

        #region Overrides

        protected override void BaseWindow_KeyUp(object sender, KeyEventArgs e)
        {
           
            switch (e.KeyCode)
            {
                case Keys.F1:
                case Keys.F14:
                    SaveButton(this, e);
                    break;
                case Keys.F4:
                case Keys.F15:
                    CancelButton(this, e);
                    break;
                case Keys.Down:
                    GetSelectedRow();
                    listView1.Focus();
                    break;
                case Keys.Up:
                    GetSelectedRow();
                    listView1.Focus();
                    break;
                case Keys.Space:
                    if (DialogResult.Yes == CommonFunctions.MessageShow(string.Format(CommonMsg.Warning.d_QClearFile, "Inventory"), CommonEnum.NotificationType.Question, CommonEnum.MessageButtons.YesNo))
                    {
                        this.ClearSent();
                        this.RefreshList();
                    }
                    break;
               
                case Keys.NumPad1:
                    {
                        RefreshList(CommonEnum.UploadStats.AllValid);
                    }
                    break;
                case Keys.NumPad2:
                    {
                        RefreshList(CommonEnum.UploadStats.Sent);
                    }
                    break;
                case Keys.NumPad3:
                    {
                        RefreshList(CommonEnum.UploadStats.Pending);
                    }
                    break;
                case Keys.NumPad4:
                    {
                        RefreshList(CommonEnum.UploadStats.Reprint);
                    }
                    break;
                case Keys.NumPad5:
                    {
                        RefreshList(CommonEnum.UploadStats.Failed);
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

        #region Validations
        #endregion Validations

        //Events

        private void InventoryListWindow_Closing(object sender, CancelEventArgs e)
        {
            CommonFunctions.DisposeCommonObj();
        }

        private void InventoryListWindow_Load(object sender, EventArgs e)
        {
            this.SetGridHeaderDisplay();
            this.RefreshList();
        }

        private void lblGridHeader_ParentChanged(object sender, EventArgs e)
        {

        }
    }
}