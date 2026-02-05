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
    public partial class StatusListWindow : BaseWindow
    {
        #region Variables

        DataTable dt = new DataTable();
        CommonEnum.Function _CurrentFunction = CommonEnum.Function.DeliveryPreparation;

        #endregion

        #region Constructor

        public StatusListWindow(CommonEnum.Function CurrentFunction)
        {
            InitializeComponent();
            //base.SetBarcodeReader(BCReader, BCData);
            base.SetWindowTitle("Status");
            base.SetActiveButtons(BaseButtons.Done, BaseButtons.Cancel);
            CommonInterfaceFunctions.WLANAddSignalQualityHandler(base.pcbSignal, true);
            _CurrentFunction = CurrentFunction;
        }

        #endregion

        #region Function

        private void SetDisplayList()
        {
            //this.lblListGridHeader.Location = new System.Drawing.Point(11, 41);
            //this.lblListGridHeader.Size = new System.Drawing.Size(299, 26);
            //this.ListView.Location = new System.Drawing.Point(10, 40);
            //this.ListView.Size = new System.Drawing.Size(301, 239);
        }

        /// <summary>
        /// Populates List View with data from 
        /// </summary>
        /// <param name="CurrentFunction">MaterialIssuance</param>
        private void RefreshList(CommonEnum.Function CurrentFunction)
        {
            //clear recent
            ListView.Items.Clear();

            //Get
            dt = GetTable(CurrentFunction);

            //Populate ListView
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    //populate
                    foreach (DataRow row in dt.Rows)
                    {
                        ListViewItem StatusListViewItem = new ListViewItem();
                        StatusListViewItem.ImageIndex = (int)row["CompleteFlag"];
                        StatusListViewItem.Text = row["ControlNo"].ToString();
                        StatusListViewItem.SubItems.Add(row["Status"].ToString());
                        this.ListView.Items.Add(StatusListViewItem);
                    }
                }
            }

            try
            {
                ListView.Focus();
                if (ListView.Items != null)
                {
                    if (ListView.Items.Count > 0)
                    {
                        ListView.Items[0].Selected = true;
                        ListView.Items[0].Focused = true;
                    }

                }
            }
            catch { }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CurrentFunction">MaterialIssuance</param>
        /// <returns></returns>
        private DataTable GetTable(CommonEnum.Function CurrentFunction)
        {
            switch (CurrentFunction)
            {
                case CommonEnum.Function.DeliveryPreparation:
                    dt = DeliveryPreparationBaseOld.GetDPStatusList();
                    break;
                case CommonEnum.Function.DeliveryChecklist:
                    dt = DeliveryChecklistBase.GetDRStatusList();
                    break;
            }

            return dt;
        }

        #endregion

        #region Overload

        protected override void BaseWindow_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                case Keys.F14:
                    {
                        if (ListView.FocusedItem != null)
                        {
                            if (!string.IsNullOrEmpty(ListView.FocusedItem.SubItems[0].Text))
                            {
                                if (_CurrentFunction == CommonEnum.Function.DeliveryPreparation)
                                    DeliveryPreparationBaseOld.UpdateDPScannedList(ListView.FocusedItem.SubItems[0].Text);
                                else if (_CurrentFunction == CommonEnum.Function.DeliveryChecklist)
                                    DeliveryChecklistBase.UpdateDRScannedList(ListView.FocusedItem.SubItems[0].Text);

                                RefreshList(_CurrentFunction);
                            }
                        }
                    }
                    break;
                case Keys.F4:
                case Keys.F15:
                    Close();
                    break;
                case Keys.Down:
                    if (!ListView.Focused)
                    {
                        ListView.Focus();
                        if (ListView.Items != null)
                        {
                            if (ListView.Items.Count > 0)
                            {
                                ListView.Items[0].Selected = true;
                                ListView.Items[0].Focused = true;
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

        #endregion

        private void StatusListWindow_Load(object sender, EventArgs e)
        {
            this.SetDisplayList();
            this.RefreshList(_CurrentFunction); // _CurrentFunction = MaterialIsuance
        }
    }
}