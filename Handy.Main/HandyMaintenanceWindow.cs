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
    public partial class HandyMaintenanceWindow : BaseWindow
    {
        #region Variables

        public CommonEnum.Buttons ExitButton = CommonEnum.Buttons.Exit;
        private string SelectedProcess = string.Empty;
        
        #endregion Variables
        
        #region Constructor

        public HandyMaintenanceWindow()
        {
            InitializeComponent();
            base.SetWindowTitle("Maintenance");
            base.SetActiveButtons(BaseButtons.Select, BaseButtons.Cancel);
            CommonInterfaceFunctions.WLANAddSignalQualityHandler(base.pcbSignal, true);
        }

        #endregion Constructor

        #region Functions

        private void SelectButton(object sender, EventArgs e)
        {
            HandyMaintenanceListWindow _HandyConnectionModeWindow = new HandyMaintenanceListWindow(SelectedProcess);
            _HandyConnectionModeWindow.Show();
            
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

        private void GetSelectedRow()
        {
            bool IsItemSelected = false;
            if (listView1.Items != null)
            {
                if (listView1.Items.Count > 0)
                {
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        if (listView1.Items[i].Selected == true)
                        {
                            SelectedProcess = listView1.Items[i].SubItems[1].Text.Trim();
                            IsItemSelected = true;
                        }
                    }

                    if (!IsItemSelected)
                    {
                        try
                        {
                            SelectedProcess = listView1.Items[0].SubItems[1].Text.Trim();
                            listView1.Items[0].Selected = true;
                        }
                        catch
                        { }
                    }
                }
            }
        }

        #endregion Functions

        #region Overrides

        protected override void BaseWindow_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                case Keys.F14:
                    {
                        GetSelectedRow();
                        SelectButton(this, e);
                        ExitButton = CommonEnum.Buttons.Exit;
                    }
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

        #region Events

        #endregion Events
    }
}