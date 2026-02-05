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
    public partial class LicenseWindow : Form
    {
        public LicenseWindow()
        {
            InitializeComponent();
        }

        private void NotifyUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void LicenseWindow_Load(object sender, EventArgs e)
        {
            setLicenseInfo();
        }

        private void setLicenseInfo()
        {
            this.lblHandyNo.Text = CommonFunctions.HandyNo;
            this.lblMac.Text = CommonFunctions.HandyMacAddress;
            this.lblSerial.Text = CommonFunctions.HandySerialNo;
            this.lblIP.Text = CommonFunctions.HandyIPAddress;
            this.lblDeviceModel.Text =CommonFunctions.HandyModel;
            this.lblStatus.Text = CommonFunctions.HandyStatus.Equals("A")?"ACTIVE":"CANCELLED";
        }

        private void LicenseWindow_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Back:
                case Keys.Space:
                    this.Close();
                    break;
            }
        }
    }
}