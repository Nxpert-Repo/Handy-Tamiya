namespace Handy
{
    partial class LogInWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogInWindow));
            this.UserIDText = new System.Windows.Forms.TextBox();
            this.PINText = new System.Windows.Forms.TextBox();
            this.NotifyUser = new System.Windows.Forms.Label();
            this.lblHandyVersion = new System.Windows.Forms.Label();
            this.StatusBackground = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pbHeader = new System.Windows.Forms.PictureBox();
            this.lblTerminalNumber = new System.Windows.Forms.Label();
            this.lblTermalBorder = new System.Windows.Forms.Label();
            this.pcbLoginSignal = new System.Windows.Forms.PictureBox();
            this.pcbLogInBaterryLife = new System.Windows.Forms.PictureBox();
            this.tmr = new System.Windows.Forms.Timer();
            this.SuspendLayout();
            // 
            // lblBtnLeft
            // 
            this.lblBtnLeft.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            // 
            // lblBtnRight
            // 
            this.lblBtnRight.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            // 
            // UserIDText
            // 
            this.UserIDText.BackColor = System.Drawing.Color.White;
            this.UserIDText.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular);
            this.UserIDText.ForeColor = System.Drawing.Color.Black;
            this.UserIDText.Location = new System.Drawing.Point(55, 169);
            this.UserIDText.Name = "UserIDText";
            this.UserIDText.Size = new System.Drawing.Size(165, 31);
            this.UserIDText.TabIndex = 1;
            this.UserIDText.TextChanged += new System.EventHandler(this.UserIDText_TextChanged);
            // 
            // PINText
            // 
            this.PINText.BackColor = System.Drawing.Color.White;
            this.PINText.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular);
            this.PINText.ForeColor = System.Drawing.Color.Black;
            this.PINText.Location = new System.Drawing.Point(55, 205);
            this.PINText.Name = "PINText";
            this.PINText.PasswordChar = '*';
            this.PINText.Size = new System.Drawing.Size(165, 31);
            this.PINText.TabIndex = 2;
            this.PINText.TextChanged += new System.EventHandler(this.PINText_TextChanged);
            // 
            // NotifyUser
            // 
            this.NotifyUser.BackColor = System.Drawing.Color.DarkRed;
            this.NotifyUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
            this.NotifyUser.ForeColor = System.Drawing.Color.White;
            this.NotifyUser.Location = new System.Drawing.Point(18, 241);
            this.NotifyUser.Name = "NotifyUser";
            this.NotifyUser.Size = new System.Drawing.Size(220, 36);
            this.NotifyUser.Text = "Status";
            this.NotifyUser.TextChanged += new System.EventHandler(this.NotifyUser_TextChanged);
            // 
            // lblHandyVersion
            // 
            this.lblHandyVersion.BackColor = System.Drawing.Color.White;
            this.lblHandyVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular);
            this.lblHandyVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblHandyVersion.Location = new System.Drawing.Point(6, 256);
            this.lblHandyVersion.Name = "lblHandyVersion";
            this.lblHandyVersion.Size = new System.Drawing.Size(230, 21);
            this.lblHandyVersion.Text = "Version : ";
            // 
            // StatusBackground
            // 
            this.StatusBackground.BackColor = System.Drawing.Color.DarkRed;
            this.StatusBackground.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
            this.StatusBackground.ForeColor = System.Drawing.Color.White;
            this.StatusBackground.Location = new System.Drawing.Point(2, 241);
            this.StatusBackground.Name = "StatusBackground";
            this.StatusBackground.Size = new System.Drawing.Size(237, 38);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(17, 169);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 33);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(17, 205);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 33);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(7, 54);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(231, 109);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(46, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 20);
            this.label3.Text = "Service Center Corporation";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(7, 7);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(35, 35);
            // 
            // pbHeader
            // 
            this.pbHeader.BackColor = System.Drawing.Color.White;
            this.pbHeader.Image = ((System.Drawing.Image)(resources.GetObject("pbHeader.Image")));
            this.pbHeader.Location = new System.Drawing.Point(1, 1);
            this.pbHeader.Name = "pbHeader";
            this.pbHeader.Size = new System.Drawing.Size(238, 47);
            // 
            // lblTerminalNumber
            // 
            this.lblTerminalNumber.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTerminalNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular);
            this.lblTerminalNumber.ForeColor = System.Drawing.Color.Teal;
            this.lblTerminalNumber.Location = new System.Drawing.Point(165, 15);
            this.lblTerminalNumber.Name = "lblTerminalNumber";
            this.lblTerminalNumber.Size = new System.Drawing.Size(44, 25);
            this.lblTerminalNumber.Text = "001";
            this.lblTerminalNumber.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTermalBorder
            // 
            this.lblTermalBorder.BackColor = System.Drawing.Color.DarkCyan;
            this.lblTermalBorder.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular);
            this.lblTermalBorder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(205)))), ((int)(((byte)(210)))));
            this.lblTermalBorder.Location = new System.Drawing.Point(163, 12);
            this.lblTermalBorder.Name = "lblTermalBorder";
            this.lblTermalBorder.Size = new System.Drawing.Size(48, 32);
            this.lblTermalBorder.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pcbLoginSignal
            // 
            this.pcbLoginSignal.Image = ((System.Drawing.Image)(resources.GetObject("pcbLoginSignal.Image")));
            this.pcbLoginSignal.Location = new System.Drawing.Point(216, 10);
            this.pcbLoginSignal.Name = "pcbLoginSignal";
            this.pcbLoginSignal.Size = new System.Drawing.Size(23, 16);
            this.pcbLoginSignal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            // 
            // pcbLogInBaterryLife
            // 
            this.pcbLogInBaterryLife.Image = ((System.Drawing.Image)(resources.GetObject("pcbLogInBaterryLife.Image")));
            this.pcbLogInBaterryLife.Location = new System.Drawing.Point(216, 28);
            this.pcbLogInBaterryLife.Name = "pcbLogInBaterryLife";
            this.pcbLogInBaterryLife.Size = new System.Drawing.Size(23, 16);
            this.pcbLogInBaterryLife.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            // 
            // tmr
            // 
            this.tmr.Tick += new System.EventHandler(this.tmr_Tick);
            // 
            // LogInWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(242, 320);
            this.Controls.Add(this.pcbLogInBaterryLife);
            this.Controls.Add(this.NotifyUser);
            this.Controls.Add(this.pcbLoginSignal);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.lblTerminalNumber);
            this.Controls.Add(this.lblTermalBorder);
            this.Controls.Add(this.pbHeader);
            this.Controls.Add(this.StatusBackground);
            this.Controls.Add(this.PINText);
            this.Controls.Add(this.UserIDText);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblHandyVersion);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LogInWindow";
            this.Text = "Log In";
            this.Load += new System.EventHandler(this.LogInForm_Load);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.lblHandyVersion, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.pictureBox2, 0);
            this.Controls.SetChildIndex(this.pictureBox4, 0);
            this.Controls.SetChildIndex(this.UserIDText, 0);
            this.Controls.SetChildIndex(this.PINText, 0);
            this.Controls.SetChildIndex(this.StatusBackground, 0);
            this.Controls.SetChildIndex(this.pbHeader, 0);
            this.Controls.SetChildIndex(this.lblTermalBorder, 0);
            this.Controls.SetChildIndex(this.lblTerminalNumber, 0);
            this.Controls.SetChildIndex(this.pictureBox3, 0);
            this.Controls.SetChildIndex(this.pcbLoginSignal, 0);
            this.Controls.SetChildIndex(this.NotifyUser, 0);
            this.Controls.SetChildIndex(this.pcbLogInBaterryLife, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox UserIDText;
        private System.Windows.Forms.TextBox PINText;
        private System.Windows.Forms.Label NotifyUser;
        private System.Windows.Forms.Label lblHandyVersion;
        private System.Windows.Forms.Label StatusBackground;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pbHeader;
        private System.Windows.Forms.Label lblTerminalNumber;
        private System.Windows.Forms.Label lblTermalBorder;
        private System.Windows.Forms.Timer tmr;   
        protected System.Windows.Forms.PictureBox pcbLoginSignal;
        protected System.Windows.Forms.PictureBox pcbLogInBaterryLife;
    }
}

