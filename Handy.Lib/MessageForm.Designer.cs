namespace Handy.Lib
{
    partial class MessageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageForm));
            this.pbButton = new System.Windows.Forms.PictureBox();
            this.pbIcon = new System.Windows.Forms.PictureBox();
            this.Caption = new System.Windows.Forms.Label();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.Cancel = new System.Windows.Forms.Label();
            this.OK = new System.Windows.Forms.Label();
            this.lblMessageBack = new System.Windows.Forms.Label();
            this.pbMessageDesign = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // pbButton
            // 
            this.pbButton.BackColor = System.Drawing.Color.White;
            this.pbButton.Image = ((System.Drawing.Image)(resources.GetObject("pbButton.Image")));
            this.pbButton.Location = new System.Drawing.Point(0, 226);
            this.pbButton.Name = "pbButton";
            this.pbButton.Size = new System.Drawing.Size(230, 45);
            this.pbButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbButton_MouseMove);
            this.pbButton.Click += new System.EventHandler(this.pbButton_Click);
            // 
            // pbIcon
            // 
            this.pbIcon.BackColor = System.Drawing.Color.White;
            this.pbIcon.Image = ((System.Drawing.Image)(resources.GetObject("pbIcon.Image")));
            this.pbIcon.Location = new System.Drawing.Point(25, 26);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.Size = new System.Drawing.Size(30, 30);
            // 
            // Caption
            // 
            this.Caption.BackColor = System.Drawing.Color.White;
            this.Caption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.Caption.ForeColor = System.Drawing.Color.Black;
            this.Caption.Location = new System.Drawing.Point(56, 27);
            this.Caption.Name = "Caption";
            this.Caption.Size = new System.Drawing.Size(154, 29);
            this.Caption.Text = "Warning";
            // 
            // MessageLabel
            // 
            this.MessageLabel.BackColor = System.Drawing.Color.LightSalmon;
            this.MessageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular);
            this.MessageLabel.ForeColor = System.Drawing.Color.Black;
            this.MessageLabel.Location = new System.Drawing.Point(11, 72);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(214, 151);
            this.MessageLabel.Text = "Dimension: 1.00 X 549.00 X 1180.00";
            // 
            // Cancel
            // 
            this.Cancel.BackColor = System.Drawing.Color.Black;
            this.Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.Cancel.ForeColor = System.Drawing.Color.White;
            this.Cancel.Location = new System.Drawing.Point(145, 229);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(50, 17);
            this.Cancel.Text = "Cancel";
            this.Cancel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // OK
            // 
            this.OK.BackColor = System.Drawing.Color.Black;
            this.OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.OK.ForeColor = System.Drawing.Color.White;
            this.OK.Location = new System.Drawing.Point(46, 229);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(50, 17);
            this.OK.Text = "Ok";
            this.OK.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblMessageBack
            // 
            this.lblMessageBack.BackColor = System.Drawing.Color.LightSalmon;
            this.lblMessageBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular);
            this.lblMessageBack.ForeColor = System.Drawing.Color.Black;
            this.lblMessageBack.Location = new System.Drawing.Point(12, 72);
            this.lblMessageBack.Name = "lblMessageBack";
            this.lblMessageBack.Size = new System.Drawing.Size(211, 132);
            this.lblMessageBack.Text = "Dimension: 1.00 X 549.00 X 1180.00";
            this.lblMessageBack.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pbMessageDesign
            // 
            this.pbMessageDesign.BackColor = System.Drawing.Color.White;
            this.pbMessageDesign.Image = ((System.Drawing.Image)(resources.GetObject("pbMessageDesign.Image")));
            this.pbMessageDesign.Location = new System.Drawing.Point(0, 7);
            this.pbMessageDesign.Name = "pbMessageDesign";
            this.pbMessageDesign.Size = new System.Drawing.Size(239, 270);
            // 
            // MessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(246, 277);
            this.ControlBox = false;
            this.Controls.Add(this.pbButton);
            this.Controls.Add(this.pbIcon);
            this.Controls.Add(this.Caption);
            this.Controls.Add(this.MessageLabel);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.lblMessageBack);
            this.Controls.Add(this.pbMessageDesign);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = new System.Drawing.Point(-1, 35);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MessageForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MessageForm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MessageForm_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbButton;
        private System.Windows.Forms.PictureBox pbIcon;
        private System.Windows.Forms.Label Caption;
        private System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.Label Cancel;
        private System.Windows.Forms.Label OK;
        private System.Windows.Forms.Label lblMessageBack;
        private System.Windows.Forms.PictureBox pbMessageDesign;

    }
}