namespace Handy
{
    partial class BaseWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseWindow));
            this.pnlWindow = new System.Windows.Forms.Panel();
            this.pcbBatteryLife = new System.Windows.Forms.PictureBox();
            this.pcbSignal = new System.Windows.Forms.PictureBox();
            this.lblWindowTitle = new System.Windows.Forms.Label();
            this.pcbBaseWindowHeader = new System.Windows.Forms.PictureBox();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.pnlButtonLeft = new System.Windows.Forms.Panel();
            this.lblBtnLeft = new System.Windows.Forms.LinkLabel();
            this.pcbButtonLeft = new System.Windows.Forms.PictureBox();
            this.pnlButtonRight = new System.Windows.Forms.Panel();
            this.lblBtnRight = new System.Windows.Forms.LinkLabel();
            this.pcbButtonRight = new System.Windows.Forms.PictureBox();
            this.pcbBaseWindowFooter = new System.Windows.Forms.PictureBox();
            this.pnlWindow.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlButtonLeft.SuspendLayout();
            this.pnlButtonRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlWindow
            // 
            this.pnlWindow.BackColor = System.Drawing.Color.White;
            this.pnlWindow.Controls.Add(this.pcbBatteryLife);
            this.pnlWindow.Controls.Add(this.pcbSignal);
            this.pnlWindow.Controls.Add(this.lblWindowTitle);
            this.pnlWindow.Controls.Add(this.pcbBaseWindowHeader);
            this.pnlWindow.Controls.Add(this.pnlFooter);
            this.pnlWindow.Location = new System.Drawing.Point(1, 1);
            this.pnlWindow.Name = "pnlWindow";
            this.pnlWindow.Size = new System.Drawing.Size(238, 314);
            // 
            // pcbBatteryLife
            // 
            this.pcbBatteryLife.BackColor = System.Drawing.Color.White;
            this.pcbBatteryLife.Image = ((System.Drawing.Image)(resources.GetObject("pcbBatteryLife.Image")));
            this.pcbBatteryLife.Location = new System.Drawing.Point(214, 0);
            this.pcbBatteryLife.Name = "pcbBatteryLife";
            this.pcbBatteryLife.Size = new System.Drawing.Size(23, 16);
            this.pcbBatteryLife.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            // 
            // pcbSignal
            // 
            this.pcbSignal.BackColor = System.Drawing.Color.White;
            this.pcbSignal.Image = ((System.Drawing.Image)(resources.GetObject("pcbSignal.Image")));
            this.pcbSignal.Location = new System.Drawing.Point(214, 15);
            this.pcbSignal.Name = "pcbSignal";
            this.pcbSignal.Size = new System.Drawing.Size(23, 16);
            this.pcbSignal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            // 
            // lblWindowTitle
            // 
            this.lblWindowTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWindowTitle.BackColor = System.Drawing.Color.White;
            this.lblWindowTitle.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblWindowTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblWindowTitle.Location = new System.Drawing.Point(34, 11);
            this.lblWindowTitle.Name = "lblWindowTitle";
            this.lblWindowTitle.Size = new System.Drawing.Size(163, 15);
            this.lblWindowTitle.Text = "BASE WINDOW FORM";
            // 
            // pcbBaseWindowHeader
            // 
            this.pcbBaseWindowHeader.BackColor = System.Drawing.Color.White;
            this.pcbBaseWindowHeader.Image = ((System.Drawing.Image)(resources.GetObject("pcbBaseWindowHeader.Image")));
            this.pcbBaseWindowHeader.Location = new System.Drawing.Point(0, 1);
            this.pcbBaseWindowHeader.Name = "pcbBaseWindowHeader";
            this.pcbBaseWindowHeader.Size = new System.Drawing.Size(237, 34);
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.DimGray;
            this.pnlFooter.Controls.Add(this.pnlButtonLeft);
            this.pnlFooter.Controls.Add(this.pnlButtonRight);
            this.pnlFooter.Controls.Add(this.pcbBaseWindowFooter);
            this.pnlFooter.Location = new System.Drawing.Point(1, 281);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(237, 47);
            // 
            // pnlButtonLeft
            // 
            this.pnlButtonLeft.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlButtonLeft.Controls.Add(this.lblBtnLeft);
            this.pnlButtonLeft.Controls.Add(this.pcbButtonLeft);
            this.pnlButtonLeft.Location = new System.Drawing.Point(11, 1);
            this.pnlButtonLeft.Name = "pnlButtonLeft";
            this.pnlButtonLeft.Size = new System.Drawing.Size(93, 30);
            // 
            // lblBtnLeft
            // 
            this.lblBtnLeft.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblBtnLeft.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblBtnLeft.ForeColor = System.Drawing.Color.White;
            this.lblBtnLeft.Location = new System.Drawing.Point(3, 5);
            this.lblBtnLeft.Name = "lblBtnLeft";
            this.lblBtnLeft.Size = new System.Drawing.Size(87, 22);
            this.lblBtnLeft.TabIndex = 5;
            this.lblBtnLeft.Text = "LEFT";
            this.lblBtnLeft.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblBtnLeft.Click += new System.EventHandler(this.lblBtnLeft_Click);
            // 
            // pcbButtonLeft
            // 
            this.pcbButtonLeft.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pcbButtonLeft.Image = ((System.Drawing.Image)(resources.GetObject("pcbButtonLeft.Image")));
            this.pcbButtonLeft.Location = new System.Drawing.Point(0, 0);
            this.pcbButtonLeft.Name = "pcbButtonLeft";
            this.pcbButtonLeft.Size = new System.Drawing.Size(93, 30);
            // 
            // pnlButtonRight
            // 
            this.pnlButtonRight.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlButtonRight.Controls.Add(this.lblBtnRight);
            this.pnlButtonRight.Controls.Add(this.pcbButtonRight);
            this.pnlButtonRight.Location = new System.Drawing.Point(135, 2);
            this.pnlButtonRight.Name = "pnlButtonRight";
            this.pnlButtonRight.Size = new System.Drawing.Size(93, 30);
            // 
            // lblBtnRight
            // 
            this.lblBtnRight.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblBtnRight.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblBtnRight.ForeColor = System.Drawing.Color.White;
            this.lblBtnRight.Location = new System.Drawing.Point(3, 5);
            this.lblBtnRight.Name = "lblBtnRight";
            this.lblBtnRight.Size = new System.Drawing.Size(87, 22);
            this.lblBtnRight.TabIndex = 4;
            this.lblBtnRight.Text = "RIGHT";
            this.lblBtnRight.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblBtnRight.Click += new System.EventHandler(this.lblBtnRight_Click);
            // 
            // pcbButtonRight
            // 
            this.pcbButtonRight.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pcbButtonRight.Image = ((System.Drawing.Image)(resources.GetObject("pcbButtonRight.Image")));
            this.pcbButtonRight.Location = new System.Drawing.Point(0, 0);
            this.pcbButtonRight.Name = "pcbButtonRight";
            this.pcbButtonRight.Size = new System.Drawing.Size(93, 30);
            // 
            // pcbBaseWindowFooter
            // 
            this.pcbBaseWindowFooter.BackColor = System.Drawing.Color.DimGray;
            this.pcbBaseWindowFooter.Image = ((System.Drawing.Image)(resources.GetObject("pcbBaseWindowFooter.Image")));
            this.pcbBaseWindowFooter.Location = new System.Drawing.Point(1, 1);
            this.pcbBaseWindowFooter.Name = "pcbBaseWindowFooter";
            this.pcbBaseWindowFooter.Size = new System.Drawing.Size(236, 32);
            // 
            // BaseWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(242, 320);
            this.ControlBox = false;
            this.Controls.Add(this.pnlWindow);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "BaseWindow";
            this.Text = "BaseWindow";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.BaseWindow_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.BaseWindow_Closing);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.BaseWindow_KeyUp);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BaseWindow_KeyDown);
            this.pnlWindow.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.pnlButtonLeft.ResumeLayout(false);
            this.pnlButtonRight.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlWindow;
        private System.Windows.Forms.Label lblWindowTitle;
        private System.Windows.Forms.PictureBox pcbBaseWindowHeader;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlButtonLeft;
        private System.Windows.Forms.PictureBox pcbButtonLeft;
        private System.Windows.Forms.Panel pnlButtonRight;
        private System.Windows.Forms.PictureBox pcbButtonRight;
        private System.Windows.Forms.PictureBox pcbBaseWindowFooter;
        protected System.Windows.Forms.PictureBox pcbSignal;
        protected System.Windows.Forms.LinkLabel lblBtnLeft;
        protected System.Windows.Forms.LinkLabel lblBtnRight;
        protected System.Windows.Forms.PictureBox pcbBatteryLife;
    }
}