namespace Handy.Lib
{
    partial class PriveledgeWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.Cancel = new System.Windows.Forms.Label();
            this.OK = new System.Windows.Forms.Label();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Caption = new System.Windows.Forms.Label();
            this.TextPINCode = new System.Windows.Forms.TextBox();
            this.TextNotifyUser = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Controls.Add(this.Cancel);
            this.panel1.Controls.Add(this.OK);
            this.panel1.Location = new System.Drawing.Point(0, 193);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(238, 36);
            // 
            // Cancel
            // 
            this.Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular);
            this.Cancel.ForeColor = System.Drawing.Color.White;
            this.Cancel.Location = new System.Drawing.Point(122, 1);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(100, 30);
            this.Cancel.Text = "Cancel";
            this.Cancel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // OK
            // 
            this.OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular);
            this.OK.ForeColor = System.Drawing.Color.White;
            this.OK.Location = new System.Drawing.Point(2, 0);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(100, 30);
            this.OK.Text = "OK";
            this.OK.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MessageLabel
            // 
            this.MessageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
            this.MessageLabel.Location = new System.Drawing.Point(15, 58);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(223, 52);
            this.MessageLabel.Text = "message";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel2.Controls.Add(this.Caption);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(238, 52);
            // 
            // Caption
            // 
            this.Caption.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular);
            this.Caption.ForeColor = System.Drawing.Color.White;
            this.Caption.Location = new System.Drawing.Point(3, 18);
            this.Caption.Name = "Caption";
            this.Caption.Size = new System.Drawing.Size(314, 34);
            this.Caption.Text = "Caption";
            // 
            // TextPINCode
            // 
            this.TextPINCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.TextPINCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular);
            this.TextPINCode.ForeColor = System.Drawing.Color.Black;
            this.TextPINCode.Location = new System.Drawing.Point(15, 137);
            this.TextPINCode.Name = "TextPINCode";
            this.TextPINCode.PasswordChar = '*';
            this.TextPINCode.Size = new System.Drawing.Size(207, 31);
            this.TextPINCode.TabIndex = 3;
            this.TextPINCode.Text = "Enter PIN";
            this.TextPINCode.TextChanged += new System.EventHandler(this.TextPINCode_TextChanged);
            this.TextPINCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PriveledgeWindow_KeyUp);
            // 
            // TextNotifyUser
            // 
            this.TextNotifyUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
            this.TextNotifyUser.Location = new System.Drawing.Point(15, 110);
            this.TextNotifyUser.Name = "TextNotifyUser";
            this.TextNotifyUser.Size = new System.Drawing.Size(207, 27);
            this.TextNotifyUser.Text = " NotifyUser";
            this.TextNotifyUser.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // PriveledgeWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(238, 230);
            this.ControlBox = false;
            this.Controls.Add(this.TextPINCode);
            this.Controls.Add(this.TextNotifyUser);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.MessageLabel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = new System.Drawing.Point(-1, 90);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PriveledgeWindow";
            this.TopMost = true;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PriveledgeWindow_KeyUp);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label Cancel;
        private System.Windows.Forms.Label OK;
        private System.Windows.Forms.Label Caption;
        private System.Windows.Forms.TextBox TextPINCode;
        private System.Windows.Forms.Label TextNotifyUser;
    }
}