using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Handy.Lib
{
    public partial class SupervisoryCancelation : Form, IDisposable
    {
        public SupervisoryCancelation(string Message, string Caption)
        {
            InitializeComponent();
            this.Caption.Text = Caption;
            this.MessageLabel.Text = Message;
        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            switch (CommonFunctions.VerifyUser(UserIDText.Text, PINText.Text,false))
            {
                case CommonEnum.Result.Retry:
                    {
                        this.PINText.Text = string.Empty;
                        this.UserIDText.Focus();
                        this.UserIDText.SelectAll();
                        this.NotifyUser.Text = "Retry";
                        this.NotifyUser.Visible = true;
                    }
                    break;
                case CommonEnum.Result.EnterUser:
                    {
                        this.NotifyUser.Text = "Enter User ID";
                        this.UserIDText.Focus();
                    }
                    break;
                case CommonEnum.Result.EnterPIN:
                    {
                        this.PINText.Focus();
                        this.NotifyUser.Text = "Enter PIN";
                    }
                    break;
                case CommonEnum.Result.ServerNotFound:
                    {
                        this.UserIDText.Focus();
                        this.NotifyUser.Text = "Server not available";
                    }
                    break;
                case CommonEnum.Result.InvalidUser:
                    {
                        this.PINText.Text = "";
                        this.UserIDText.Focus();
                        this.UserIDText.SelectAll();
                        this.NotifyUser.Text = "Invalid User";
                    }
                    break;
                case CommonEnum.Result.OK:
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                    break;
                case CommonEnum.Result.InvalidPIN:
                    {
                        this.NotifyUser.Text = "Invalid PIN";
                        this.PINText.Focus();
                        this.PINText.SelectAll();
                    }
                    break;
                default:
                    {
                        this.NotifyUser.Text = "Invalid User ID";
                        this.PINText.Text = "";
                        this.UserIDText.Focus();
                        this.UserIDText.SelectAll();
                    }
                    break;
            }

        }

        private void LogInForm_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                case Keys.F14:
                    this.LogInButton_Click(this, e);
                    break;
                case Keys.F4:
                case Keys.F15:
                    this.DialogResult = DialogResult.Cancel;
                    break;
                case Keys.F2:
                case Keys.F7:
                    {
                        this.LogInButton.Text = "OK";
                        this.NotifyUser.Text = "";
                    }
                    break;
                case Keys.Down:
                    {
                        this.PINText.Focus();
                        this.PINText.SelectAll();
                    }
                    break;
                case Keys.Up:
                    {
                        this.UserIDText.Focus();
                        this.UserIDText.SelectAll();
                    }
                    break;
            }
        }

        private void SupervisoryCancelation_Load(object sender, EventArgs e)
        {
            UserIDText.Focus();
            NotifyUser.Text = "";
        }

        private void UserIDText_TextChanged(object sender, EventArgs e)
        {
            NotifyUser.Text = "";
        }

        private void PINText_TextChanged(object sender, EventArgs e)
        {
            NotifyUser.Text = "";
        }

        private static CommonEnum.Result VerifyUser(string User, string UserPIN)
        {
            if (User == string.Empty)
                return CommonEnum.Result.EnterUser;
            else
                if (UserPIN == string.Empty)
                    return CommonEnum.Result.EnterPIN;
                else
                {
                    // ADDED FOR ONLINE
                    string PIN = CommonFunctions.CEDataReader(string.Format(@"SELECT Umt_UserHandypin FROM T_UserMaster 
                                                                WHERE Umt_Usercode = '{0}' 
                                                                AND Umt_usersupv = 1",User)); //VerifyUserPIN(User);
                    if (PIN == "Error")
                    {
                        UserPIN = string.Empty;
                        Audio.PlayErrorBeep();
                        return CommonEnum.Result.ServerNotFound;
                    }
                    else
                    {
                        if (PIN == string.Empty)
                        {
                            return CommonEnum.Result.InvalidUser;
                        }
                        else
                            if (UserPIN == PIN)
                            {
                                return CommonEnum.Result.OK;
                            }
                            else
                            {
                                return CommonEnum.Result.InvalidPIN;
                            }
                    }
                }
        }
    }
}
