using System;
using System.Windows.Forms;
using System.Drawing;
using System.Resources;
using System.Drawing.Imaging;
using System.Reflection;
using System.ComponentModel;

namespace Handy.Lib
{
    public partial class MessageForm : Form, IDisposable
    {
        #region Variables

        CommonEnum.MessageButtons MessageButton;
        int MouseX = 0;
        int MouseY = 0;

        #endregion

        #region Constructor

        public MessageForm(string message, string caption, CommonEnum.NotificationType NotificationType, CommonEnum.MessageButtons Buttons)
        {
            //CommonFunctions.IsMessageDialogShown = true;
            InitializeComponent();

            if (caption.Length < 20)
            {
                this.Caption.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
                this.Caption.Location = new System.Drawing.Point(56, 27);
                this.Caption.Size = new System.Drawing.Size(154, 29);
            }
            else if (caption.Length >= 20)
            {
                this.Caption.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
                this.Caption.Location = new System.Drawing.Point(56, 25);
                this.Caption.Size = new System.Drawing.Size(154, 35);
            }

            MessageLabel.Text = message;
            MessageButton = Buttons;

            switch (Buttons)
            {
                case CommonEnum.MessageButtons.Ok:
                    {
                        Cancel.Visible = false;
                        this.FormatMessageButton(this.pbButton, Properties.Resource.OkOnly);
                    }
                    break;
                case CommonEnum.MessageButtons.YesNo:
                    {
                        OK.Text = "Yes";
                        Cancel.Text = "No";
                        this.FormatMessageButton(this.pbButton, Properties.Resource.YesNo);
                    }
                    break;
                case CommonEnum.MessageButtons.RevertCancel:
                    {
                        OK.Text = "Revert";
                        this.FormatMessageButton(this.pbButton, Properties.Resource.RevertCancel);
                    }
                    break;
                case CommonEnum.MessageButtons.UnloadCancel:
                    {
                        OK.Text = "Unload";
                        this.FormatMessageButton(this.pbButton, Properties.Resource.UnloadCancel);
                    }
                    break;
                case CommonEnum.MessageButtons.CloseOnly:
                    {
                        OK.Text = "Close";
                        this.FormatMessageButton(this.pbButton, Properties.Resource.CloseOnly);
                        Cancel.Visible = false;
                    }
                    break;
            }

            switch (NotificationType)
            {
                case CommonEnum.NotificationType.Error:
                    {
                        this.SetIcon(this.pbIcon, Properties.Resource.error);
                        this.MessageLabel.BackColor = System.Drawing.Color.LightSalmon;
                        this.lblMessageBack.BackColor = this.MessageLabel.BackColor;
                        Caption.Text = (string.IsNullOrEmpty(caption)) ? "Error" : caption;
                    }
                    break;

                case CommonEnum.NotificationType.Question:
                    {
                        this.SetIcon(this.pbIcon, Properties.Resource.question);
                        this.MessageLabel.BackColor = System.Drawing.Color.PaleTurquoise;
                        this.lblMessageBack.BackColor = this.MessageLabel.BackColor;
                        Caption.Text = (string.IsNullOrEmpty(caption)) ? "Question" : caption;
                    }
                    break;
                case CommonEnum.NotificationType.Information:
                    {
                        this.SetIcon(this.pbIcon, Properties.Resource.info);
                        this.MessageLabel.BackColor = System.Drawing.Color.PaleTurquoise;
                        this.lblMessageBack.BackColor = this.MessageLabel.BackColor;
                        Caption.Text = (string.IsNullOrEmpty(caption)) ? "Information" : caption;
                    }
                    break;
                case CommonEnum.NotificationType.Warning:
                    {
                        this.SetIcon(this.pbIcon, Properties.Resource.Warning);
                        this.MessageLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
                        this.lblMessageBack.BackColor = this.MessageLabel.BackColor;
                        Caption.Text = (string.IsNullOrEmpty(caption)) ? "Warning" : caption;
                    }
                    break;
                case CommonEnum.NotificationType.Success:
                    {
                        this.SetIcon(this.pbIcon, Properties.Resource.success);
                        this.MessageLabel.BackColor = System.Drawing.Color.PaleGreen;
                        this.lblMessageBack.BackColor = this.MessageLabel.BackColor;
                        Caption.Text = (string.IsNullOrEmpty(caption)) ? "Successful" : caption;
                    }
                    break;
                case CommonEnum.NotificationType.Default:
                    {
                        this.SetIcon(this.pbIcon, Properties.Resource.success);
                        this.MessageLabel.BackColor = System.Drawing.Color.PaleGreen;
                        this.lblMessageBack.BackColor = this.MessageLabel.BackColor;
                        Caption.Text = (string.IsNullOrEmpty(caption)) ? "Successful" : caption;
                    }
                    break;
            }

        }

        #endregion

        #region Functions

        private void FormatMessageButton(PictureBox PicBox, Bitmap Img)
        {
            try
            {
                PictureBox pictureBox = PicBox;
                //pictureBox.Height = 45;
                //pictureBox.Width = 315;
                //pictureBox.Location = new Point(3, 231);
                pictureBox.SizeMode = PictureBoxSizeMode.Normal;
                pictureBox.Image = Img;
            }
            catch { }
        }

        private void SetIcon(PictureBox PicBox, Bitmap Img)
        {
            try
            {
                PictureBox pictureBox = PicBox;
                //pictureBox.Height = 30;
                //pictureBox.Width = 30;
                //pictureBox.Location = new Point(30, 34);
                pictureBox.SizeMode = PictureBoxSizeMode.Normal;
                pictureBox.Image = Img;
            }
            catch { }
        }

        private void MessageButtonClick(object sender, EventArgs e)
        {
            switch (MessageButton)
            {
                case CommonEnum.MessageButtons.Ok:
                    {
                        this.MouseDownClickCenterButton(sender, e);
                    }
                    break;
                case CommonEnum.MessageButtons.YesNo:
                    {
                        this.MouseDownClickLeftRightButton(sender, e);
                    }
                    break;
                case CommonEnum.MessageButtons.RevertCancel:
                    {
                        this.MouseDownClickLeftRightButton(sender, e);
                    }
                    break;
                case CommonEnum.MessageButtons.UnloadCancel:
                    {
                        this.MouseDownClickLeftRightButton(sender, e);
                    }
                    break;
                case CommonEnum.MessageButtons.CloseOnly:
                    {
                        this.MouseDownClickCenterButton(sender, e);
                    }
                    break;
            }
        }

        private void MouseDownClickLeftRightButton(object sender, EventArgs e)
        {
            if (MouseX > 60 && MouseX < 150 && MouseY > 5 && MouseY < 40)
                this.OK_Click(sender, e);
            else if (MouseX > 165 && MouseX < 250 && MouseY > 5 && MouseY < 40)
                this.Cancel_Click(sender, e);
        }

        private void MouseDownClickCenterButton(object sender, EventArgs e)
        {
            if (MouseX > 20 && MouseX < 195 && MouseY > 5 && MouseY < 40)
                this.OK_Click(sender, e);
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (OK.Text == "Yes")
                DialogResult = DialogResult.Yes;
            else
                DialogResult = DialogResult.OK;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            if (Cancel.Text == "Cancel")
                DialogResult = DialogResult.Cancel;
            else
                DialogResult = DialogResult.No;
        }

        private void pbButton_MouseMove(object sender, MouseEventArgs e)
        {
            this.MouseX = e.X;
            this.MouseY = e.Y;
        }

        private void pbButton_Click(object sender, EventArgs e)
        {
            this.MessageButtonClick(sender, e);
        }


        #endregion

        //Events

        private void MessageForm_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                case Keys.F1:
                case Keys.F14:
                    if (OK.Text == "Yes")
                        DialogResult = DialogResult.Yes;
                    else
                        DialogResult = DialogResult.OK;
                    break;
                case Keys.Cancel:
                case Keys.F4:
                case Keys.F15:
                    if (Cancel.Visible == true)
                        if (Cancel.Text == "Cancel")
                            DialogResult = DialogResult.Cancel;
                        else
                            DialogResult = DialogResult.No;
                    break;
            }
        }

        private void MessageForm_Closing(object sender, CancelEventArgs e)
        {
            //CommonFunctions.IsMessageDialogShown = false;
        }

        private void MessageForm_Load(object sender, EventArgs e)
        {

        }
    }

}
