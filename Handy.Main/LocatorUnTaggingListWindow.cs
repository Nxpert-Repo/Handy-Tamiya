using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using System.Data;
using Handy.Lib;

namespace Handy
{
    public partial class LocatorUnTaggingListWindow : BaseWindow
    {
        #region Variables

        private Int32 Count=0;
        private DataTable UnTagRRList = new DataTable();
        private DataTable UntagTagNoList = new DataTable();
        private CommonEnum.Buttons ExitButton = CommonEnum.Buttons.Exit;

        #endregion

        public LocatorUnTaggingListWindow()
        {
            InitializeComponent();
            //base.SetBarcodeReader(BCReader, BCData);
            base.SetWindowTitle("Untagged List");
            //base.SetActiveButtons(BaseButtons.Clear, BaseButtons.Cancel);
            base.SetRightButton(BaseButtons.Cancel);
            CommonInterfaceFunctions.WLANAddSignalQualityHandler(base.pcbSignal, true);
        }

        #region Function
        
        private void SetListDisplay()
        {
            //this.ListRR.Location = new System.Drawing.Point(5, 36);
            //this.ListRR.Size = new System.Drawing.Size(308, 85);
            //this.ListTag.Location = new System.Drawing.Point(131, 128);
            //this.ListTag.Size = new System.Drawing.Size(182, 124);
            //this.lblListHeader.Location = new System.Drawing.Point(5, 37);
            //this.lblListHeader.Size = new System.Drawing.Size(308, 23);
            //this.lblListHeader2.Location = new System.Drawing.Point(131, 129);
            //this.lblListHeader2.Size = new System.Drawing.Size(182, 26);
            this.lblListHeader.BackColor = System.Drawing.Color.Teal;
            this.lblListHeader2.BackColor = System.Drawing.Color.Teal;
        }

        private void RefreshList()
        {
            this.ListRR.Focus();
            this.Count = 0;
            bool GreyBack = false;
            //clear recent
            this.ListRR.Items.Clear();
            //this.UnTagRRList = Logger.GetTextDataTable(Logger.HandyPath, Logger.HandyTaggingFile, 2,false,'~'); //Column 2 is RR No.'
            this.UnTagRRList = LocatorTaggingBase.MobiledbTaggedListView();
            if (this.UnTagRRList == null)
                return;
            this.Count = this.UnTagRRList.Rows.Count;
            int i = 0;
            string RRList = string.Empty;

            if (Count > 0)
            {
                //populate
                foreach (DataRow row in this.UnTagRRList.Rows)
                {
                    CommonFunctions.ParseRRNoDisplay(row["RRNo"].ToString().Trim());           //RR No
                    if (i == 0)
                    {
                        RRList = string.Format("'{0}'",CommonFunctions.BarcodeRRNo);
                    }
                    else
                    {
                        RRList = RRList + ',' + string.Format("'{0}'", CommonFunctions.BarcodeRRNo);           //RR No
                    }
                    ++i;
                }

                //Setting List View
                DataTable Dt = LocatorTaggingBase.ListUntagRRNumber(RRList);
                if (Dt != null)
                {
                    this.UntagTagNoList = LocatorTaggingBase.ListUntagTagNo(RRList);
                    //populate
                    int j = 0;
                    foreach(DataRow rows in Dt.Rows)
                    {
                        //efault columns retrieve from text file conversion
                        ListViewItem listViewItem1 = new ListViewItem();
                        listViewItem1.ImageIndex = 0;
                        listViewItem1.Text = rows["RRNumber"].ToString();
                        listViewItem1.SubItems.Add(rows["Untagged"].ToString());
                        this.ListRR.Items.Add(listViewItem1);

                        if (j == 0)
                        {
                            this.GetSelectedRow(rows["RRNumber"].ToString(), true);
                        }
                        if (GreyBack)
                        {
                            listViewItem1.ListView.Items[j].BackColor = Color.LightCyan;
                            listViewItem1.ListView.Items[j].ForeColor = Color.Black;
                            GreyBack = false;
                        }
                        else
                        {
                            listViewItem1.ListView.Items[j].BackColor = Color.White;
                            listViewItem1.ListView.Items[j].ForeColor = Color.Black;
                            GreyBack = true;
                        }
                        ++j;
                    }
                }

            }
        }

        private void GetSelectedRow(string RR ,bool onload)
        {
            if (!this.ListRR.Focused)
                return;
            else if (UntagTagNoList == null)
                return;
            else if (UntagTagNoList.Rows.Count <= 0)
                return;
            else
            {
                if (this.ListRR.Items.Count > 0)
                {
                    bool GreyBack = false;
                    if (onload)
                    {
                        int x = 0;
                        this.ListTag.Items.Clear();
                        DataRow[] Dr;
                        Dr = this.UntagTagNoList.Select(string.Format("RRNumber = '{0}'", RR));
                        foreach (DataRow dr in Dr)
                        {
                            //efault columns retrieve from text file conversion
                            ListViewItem listViewItem1 = new ListViewItem();
                            listViewItem1.ImageIndex = 0;
                            listViewItem1.Text = "     "+dr["TagNo"].ToString();
                            this.ListTag.Items.Add(listViewItem1);
                            if (GreyBack)
                            {
                                listViewItem1.ListView.Items[x].BackColor = Color.LightCyan;
                                listViewItem1.ListView.Items[x].ForeColor = Color.Black;
                                GreyBack = false;
                            }
                            else
                            {
                                listViewItem1.ListView.Items[x].BackColor = Color.White;
                                listViewItem1.ListView.Items[x].ForeColor = Color.Black;
                                GreyBack = true;
                            }
                            ++x;
                        }

                    }
                    else
                    {
                        for (int i = 0; i < this.ListRR.Items.Count; i++)
                        {

                            if (this.ListRR.Items[i].Selected == true)
                            {
                                this.ListTag.Items.Clear();
                                int y = 0;
                                DataRow[] Dr;
                                RR = this.ListRR.Items[i].SubItems[0].Text.Trim();
                                Dr = this.UntagTagNoList.Select(string.Format("RRNumber = '{0}'", RR));
                                foreach (DataRow dr in Dr)
                                {
                                    //efault columns retrieve from text file conversion
                                    ListViewItem listViewItem1 = new ListViewItem();
                                    listViewItem1.ImageIndex = 0;
                                    listViewItem1.Text = "     "+dr["TagNo"].ToString();
                                    this.ListTag.Items.Add(listViewItem1);
                                    if (GreyBack)
                                    {
                                        listViewItem1.ListView.Items[y].BackColor = Color.LightCyan;
                                        listViewItem1.ListView.Items[y].ForeColor = Color.Black;
                                        GreyBack = false;
                                    }
                                    else
                                    {
                                        listViewItem1.ListView.Items[y].BackColor = Color.White;
                                        listViewItem1.ListView.Items[y].ForeColor = Color.Black;
                                        GreyBack = true;
                                    }
                                    ++y;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void ClearButton(object sender, EventArgs e)
        {
            return;

            //if (DialogResult.Yes == CommonFunctions.MessageShow("Are you sure you want to clear tagged list?", CommonEnum.NotificationType.Question, CommonEnum.MessageButtons.YesNo))
            //{
            //    if (!Logger.isFileCleared(Logger.HandyPath, Logger.HandyTaggingFile))
            //        CommonFunctions.MessageShow("Unable to clear file.", CommonEnum.NotificationType.Warning);
            //    this.RefreshList();
            //    ExitButton = CommonEnum.Buttons.Exit;
            //}
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
                    this.GetSelectedRow(string.Empty,false);
                    break;
                case Keys.Down:
                    this.GetSelectedRow(string.Empty, false);
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
                    this.Close();
                    CommonFunctions.ClearStrings();
                    this.UntagTagNoList = null;
                    this.UnTagRRList = null;
                    LocatorTaggingListWindow _TaggingListForm = new LocatorTaggingListWindow();
                    _TaggingListForm.ShowDialog();
                    break;
                case Keys.Right:
                    this.Close();
                    CommonFunctions.ClearStrings();
                    this.UntagTagNoList = null;
                    this.UnTagRRList = null;
                    LocatorTaggingListWindow _TaggingListForm2 = new LocatorTaggingListWindow();
                    _TaggingListForm2.ShowDialog();
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

        private void LocatorUnTaggingListWindow_Load(object sender, EventArgs e)
        {
            this.SetListDisplay();
            Cursor.Current = Cursors.WaitCursor;
            this.RefreshList();
            Cursor.Current = Cursors.Default;
        }

        private void ListRR_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            this.GetSelectedRow(string.Empty, false);
        }
    }
}