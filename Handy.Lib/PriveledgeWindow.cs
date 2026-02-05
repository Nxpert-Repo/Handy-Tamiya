using System;
using System.Windows.Forms;
using System.Drawing;
using System.Resources;
using System.Drawing.Imaging;
using System.Reflection;
using System.ComponentModel;

namespace Handy.Lib
{
    public partial class PriveledgeWindow : Form, IDisposable
    {
        public PriveledgeWindow(string message, string caption, CommonEnum.NotificationType NotificationType, CommonEnum.MessageButtons Buttons)
        {
            InitializeComponent();

            MessageLabel.Text = message;
            Caption.Text = caption;
            TextNotifyUser.Text = "";
            TextPINCode.Text = "";

            switch (Buttons)
            {
                case CommonEnum.MessageButtons.Ok:
                    {
                        Cancel.Visible = false;
                    }
                    break;
                case CommonEnum.MessageButtons.YesNo:
                    {
                        OK.Text = "Yes";
                        Cancel.Text = "No";
                        //Cancel.Focus(); // for unsent data
                    }
                    break;
                case CommonEnum.MessageButtons.RevertCancel:
                    {
                        OK.Text = "Revert";
                        //Cancel.Focus(); 
                    }
                    break;
                case CommonEnum.MessageButtons.UnloadCancel:
                    {
                        OK.Text = "Unload";
                        //Cancel.Focus();
                    }
                    break;
                case CommonEnum.MessageButtons.UnstartCancel:
                    {
                        OK.Text = "Unstart";
                        //Cancel.Focus();
                    }
                    break;
                case CommonEnum.MessageButtons.CloseOnly:
                    {
                        OK.Text = "Close";
                        Cancel.Visible = false;
                    }
                    break;
            }

            switch (NotificationType)
            {
                case CommonEnum.NotificationType.Error:
                    {
                        this.panel1.BackColor = Color.DarkRed;
                        this.panel2.BackColor = Color.DarkRed;
                        this.BackColor = Color.Red;
                    }
                    break;
                
                case CommonEnum.NotificationType.Question:
                    {
                        this.panel1.BackColor = Color.MidnightBlue;
                        this.panel2.BackColor = Color.MidnightBlue;
                        this.BackColor = Color.LightSteelBlue;
                    }
                    break;
                case CommonEnum.NotificationType.Information:
                    {
                        this.panel1.BackColor = Color.MidnightBlue;
                        this.panel2.BackColor = Color.MidnightBlue;
                        this.BackColor = Color.LightSteelBlue;
                    }
                    break;
                case CommonEnum.NotificationType.Warning:
                    {
                        this.panel1.BackColor = Color.SaddleBrown;
                        this.panel2.BackColor = Color.SaddleBrown;
                        this.BackColor = Color.Yellow;
                    }
                    break;
                case CommonEnum.NotificationType.Default:
                    {
                        this.panel1.BackColor = Color.DarkGreen;
                        this.panel2.BackColor = Color.DarkGreen;
                        this.BackColor = Color.YellowGreen;
                    }
                    break;
            }
        }

        private void PriveledgeWindow_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                case Keys.F14:
                    //if (TextPINCode.Text == "1430")
                    //    DialogResult = DialogResult.OK;
                    //else
                    //{
                    //    TextNotifyUser.Text = "Invalid PIN";
                    //    TextPINCode.SelectAll();
                    //    TextPINCode.Focus();
                    //}
                    OK_Click(this, e);
                    break;
                case Keys.F4:
                case Keys.F15:
                    if (Cancel.Visible == true)
                        DialogResult = DialogResult.Cancel;
                    break;
            }
        }
        
        private void OK_Click(object sender, EventArgs e)
        {
            if (TextPINCode.Text == "1430")
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                TextNotifyUser.Text = "Invalid PIN";
                TextPINCode.SelectAll();
                TextPINCode.Focus();
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void TextPINCode_TextChanged(object sender, EventArgs e)
        {
            TextNotifyUser.Text = "";
        }
    }
}
