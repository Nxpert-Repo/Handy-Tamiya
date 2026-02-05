namespace Handy.Lib
{
    partial class SupervisoryCancelation
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
            this.TextNotifyUser = new System.Windows.Forms.Label();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.Caption = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.NotifyUser = new System.Windows.Forms.Label();
            this.PINText = new System.Windows.Forms.TextBox();
            this.UserIDText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Label();
            this.LogInButton = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextNotifyUser
            // 
            this.TextNotifyUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
            this.TextNotifyUser.Location = new System.Drawing.Point(1, 164);
            this.TextNotifyUser.Name = "TextNotifyUser";
            this.TextNotifyUser.Size = new System.Drawing.Size(237, 27);
            this.TextNotifyUser.Text = " NotifyUser";
            this.TextNotifyUser.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // MessageLabel
            // 
            this.MessageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5F, System.Drawing.FontStyle.Regular);
            this.MessageLabel.Location = new System.Drawing.Point(14, 7);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(208, 68);
            this.MessageLabel.Text = "message";
            // 
            // Caption
            // 
            this.Caption.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular);
            this.Caption.ForeColor = System.Drawing.Color.White;
            this.Caption.Location = new System.Drawing.Point(14, 13);
            this.Caption.Name = "Caption";
            this.Caption.Size = new System.Drawing.Size(208, 23);
            this.Caption.Text = "Caption";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Controls.Add(this.NotifyUser);
            this.panel1.Controls.Add(this.PINText);
            this.panel1.Controls.Add(this.UserIDText);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.MessageLabel);
            this.panel1.Location = new System.Drawing.Point(0, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(238, 191);
            // 
            // NotifyUser
            // 
            this.NotifyUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
            this.NotifyUser.Location = new System.Drawing.Point(14, 78);
            this.NotifyUser.Name = "NotifyUser";
            this.NotifyUser.Size = new System.Drawing.Size(208, 22);
            this.NotifyUser.Text = "Status";
            this.NotifyUser.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // PINText
            // 
            this.PINText.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular);
            this.PINText.Location = new System.Drawing.Point(108, 141);
            this.PINText.Name = "PINText";
            this.PINText.PasswordChar = '*';
            this.PINText.Size = new System.Drawing.Size(114, 31);
            this.PINText.TabIndex = 16;
            this.PINText.TextChanged += new System.EventHandler(this.PINText_TextChanged);
            this.PINText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.LogInForm_KeyUp);
            // 
            // UserIDText
            // 
            this.UserIDText.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular);
            this.UserIDText.Location = new System.Drawing.Point(108, 103);
            this.UserIDText.Name = "UserIDText";
            this.UserIDText.Size = new System.Drawing.Size(114, 31);
            this.UserIDText.TabIndex = 15;
            this.UserIDText.TextChanged += new System.EventHandler(this.UserIDText_TextChanged);
            this.UserIDText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.LogInForm_KeyUp);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(9, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 28);
            this.label1.Text = "USER ID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(-13, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 21);
            this.label2.Text = "PIN CODE";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // CancelButton
            // 
            this.CancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular);
            this.CancelButton.ForeColor = System.Drawing.Color.White;
            this.CancelButton.Location = new System.Drawing.Point(131, 236);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(105, 27);
            this.CancelButton.Text = "Cancel";
            this.CancelButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LogInButton
            // 
            this.LogInButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular);
            this.LogInButton.ForeColor = System.Drawing.Color.White;
            this.LogInButton.Location = new System.Drawing.Point(2, 237);
            this.LogInButton.Name = "LogInButton";
            this.LogInButton.Size = new System.Drawing.Size(105, 27);
            this.LogInButton.Text = "OK";
            this.LogInButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // SupervisoryCancelation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.DarkRed;
            this.ClientSize = new System.Drawing.Size(238, 270);
            this.ControlBox = false;
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.LogInButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TextNotifyUser);
            this.Controls.Add(this.Caption);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(0, 50);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SupervisoryCancelation";
            this.Text = "SupervisoryCancelation";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SupervisoryCancelation_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.LogInForm_KeyUp);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label TextNotifyUser;
        private System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.Label Caption;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label NotifyUser;
        private System.Windows.Forms.TextBox PINText;
        private System.Windows.Forms.TextBox UserIDText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label CancelButton;
        private System.Windows.Forms.Label LogInButton;
    }
}