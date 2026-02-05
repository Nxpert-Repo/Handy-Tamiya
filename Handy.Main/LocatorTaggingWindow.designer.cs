namespace Handy
{
    partial class LocatorTaggingWindow
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
            this.LocLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.AvailableQty = new System.Windows.Forms.TextBox();
            this.TaggingQty = new System.Windows.Forms.TextBox();
            this.UnitTagging = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.UnitUntagged = new System.Windows.Forms.TextBox();
            this.TagNo = new System.Windows.Forms.TextBox();
            this.LocatorCode = new System.Windows.Forms.TextBox();
            this.LocatorCodeDesc = new System.Windows.Forms.TextBox();
            this.RRNo = new System.Windows.Forms.TextBox();
            this.timerMultilined = new System.Windows.Forms.Timer();
            this.label6 = new System.Windows.Forms.Label();
            this.timerBackGroudTransaction = new System.Windows.Forms.Timer();
            this.Expiry = new System.Windows.Forms.TextBox();
            this.StockCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.OldLocatorCode = new System.Windows.Forms.TextBox();
            this.OldLocatorCodeDesc = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
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
            // LocLabel
            // 
            this.LocLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular);
            this.LocLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LocLabel.Location = new System.Drawing.Point(3, 47);
            this.LocLabel.Name = "LocLabel";
            this.LocLabel.Size = new System.Drawing.Size(67, 19);
            this.LocLabel.Text = "Locator";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(3, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 19);
            this.label4.Text = "Quantity";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(3, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 19);
            this.label7.Text = "Available";
            // 
            // AvailableQty
            // 
            this.AvailableQty.BackColor = System.Drawing.Color.White;
            this.AvailableQty.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.AvailableQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.AvailableQty.Location = new System.Drawing.Point(76, 187);
            this.AvailableQty.Multiline = true;
            this.AvailableQty.Name = "AvailableQty";
            this.AvailableQty.ReadOnly = true;
            this.AvailableQty.Size = new System.Drawing.Size(121, 25);
            this.AvailableQty.TabIndex = 8;
            this.AvailableQty.GotFocus += new System.EventHandler(this.AvailableQty_GotFocus);
            // 
            // TaggingQty
            // 
            this.TaggingQty.BackColor = System.Drawing.Color.White;
            this.TaggingQty.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.TaggingQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TaggingQty.Location = new System.Drawing.Point(76, 212);
            this.TaggingQty.Multiline = true;
            this.TaggingQty.Name = "TaggingQty";
            this.TaggingQty.Size = new System.Drawing.Size(121, 25);
            this.TaggingQty.TabIndex = 9;
            // 
            // UnitTagging
            // 
            this.UnitTagging.BackColor = System.Drawing.Color.White;
            this.UnitTagging.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.UnitTagging.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.UnitTagging.Location = new System.Drawing.Point(193, 212);
            this.UnitTagging.Multiline = true;
            this.UnitTagging.Name = "UnitTagging";
            this.UnitTagging.ReadOnly = true;
            this.UnitTagging.Size = new System.Drawing.Size(40, 25);
            this.UnitTagging.TabIndex = 152;
            this.UnitTagging.GotFocus += new System.EventHandler(this.UnitTagging_GotFocus);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(3, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 19);
            this.label1.Text = "RR No";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(3, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 24);
            this.label8.Text = "Lot Code";
            // 
            // UnitUntagged
            // 
            this.UnitUntagged.BackColor = System.Drawing.Color.White;
            this.UnitUntagged.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.UnitUntagged.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.UnitUntagged.Location = new System.Drawing.Point(193, 187);
            this.UnitUntagged.Multiline = true;
            this.UnitUntagged.Name = "UnitUntagged";
            this.UnitUntagged.ReadOnly = true;
            this.UnitUntagged.Size = new System.Drawing.Size(40, 25);
            this.UnitUntagged.TabIndex = 254;
            this.UnitUntagged.GotFocus += new System.EventHandler(this.UnitUntagged_GotFocus);
            // 
            // TagNo
            // 
            this.TagNo.BackColor = System.Drawing.Color.White;
            this.TagNo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.TagNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TagNo.Location = new System.Drawing.Point(76, 65);
            this.TagNo.Multiline = true;
            this.TagNo.Name = "TagNo";
            this.TagNo.ReadOnly = true;
            this.TagNo.Size = new System.Drawing.Size(157, 25);
            this.TagNo.TabIndex = 4;
            this.TagNo.GotFocus += new System.EventHandler(this.StockCode_GotFocus);
            // 
            // LocatorCode
            // 
            this.LocatorCode.BackColor = System.Drawing.Color.White;
            this.LocatorCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular);
            this.LocatorCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LocatorCode.Location = new System.Drawing.Point(76, 43);
            this.LocatorCode.Multiline = true;
            this.LocatorCode.Name = "LocatorCode";
            this.LocatorCode.ReadOnly = true;
            this.LocatorCode.Size = new System.Drawing.Size(48, 23);
            this.LocatorCode.TabIndex = 1;
            // 
            // LocatorCodeDesc
            // 
            this.LocatorCodeDesc.BackColor = System.Drawing.Color.White;
            this.LocatorCodeDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular);
            this.LocatorCodeDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LocatorCodeDesc.Location = new System.Drawing.Point(124, 43);
            this.LocatorCodeDesc.Multiline = true;
            this.LocatorCodeDesc.Name = "LocatorCodeDesc";
            this.LocatorCodeDesc.ReadOnly = true;
            this.LocatorCodeDesc.Size = new System.Drawing.Size(109, 25);
            this.LocatorCodeDesc.TabIndex = 2;
            this.LocatorCodeDesc.GotFocus += new System.EventHandler(this.LocatorCodeDesc_GotFocus);
            // 
            // RRNo
            // 
            this.RRNo.BackColor = System.Drawing.Color.White;
            this.RRNo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.RRNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.RRNo.Location = new System.Drawing.Point(76, 163);
            this.RRNo.Multiline = true;
            this.RRNo.Name = "RRNo";
            this.RRNo.ReadOnly = true;
            this.RRNo.Size = new System.Drawing.Size(157, 25);
            this.RRNo.TabIndex = 7;
            this.RRNo.GotFocus += new System.EventHandler(this.RRNo_GotFocus);
            // 
            // timerMultilined
            // 
            this.timerMultilined.Interval = 3000;
            this.timerMultilined.Tick += new System.EventHandler(this.timerMultilined_Tick);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(4, 263);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(231, 18);
            this.label6.Text = "Pressing [ Enter button ] will display list.";
            this.label6.Visible = false;
            // 
            // timerBackGroudTransaction
            // 
            this.timerBackGroudTransaction.Interval = 3000;
            this.timerBackGroudTransaction.Tick += new System.EventHandler(this.timerBackGroudTransaction_Tick);
            // 
            // Expiry
            // 
            this.Expiry.BackColor = System.Drawing.Color.White;
            this.Expiry.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.Expiry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Expiry.Location = new System.Drawing.Point(76, 137);
            this.Expiry.Multiline = true;
            this.Expiry.Name = "Expiry";
            this.Expiry.ReadOnly = true;
            this.Expiry.Size = new System.Drawing.Size(157, 25);
            this.Expiry.TabIndex = 259;
            // 
            // StockCode
            // 
            this.StockCode.BackColor = System.Drawing.Color.White;
            this.StockCode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.StockCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.StockCode.Location = new System.Drawing.Point(76, 90);
            this.StockCode.Multiline = true;
            this.StockCode.Name = "StockCode";
            this.StockCode.ReadOnly = true;
            this.StockCode.Size = new System.Drawing.Size(157, 25);
            this.StockCode.TabIndex = 261;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(3, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 19);
            this.label2.Text = "Stock Code";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(3, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 19);
            this.label5.Text = "Exp Date";
            this.label5.ParentChanged += new System.EventHandler(this.label5_ParentChanged);
            // 
            // OldLocatorCode
            // 
            this.OldLocatorCode.BackColor = System.Drawing.Color.White;
            this.OldLocatorCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular);
            this.OldLocatorCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.OldLocatorCode.Location = new System.Drawing.Point(76, 237);
            this.OldLocatorCode.Multiline = true;
            this.OldLocatorCode.Name = "OldLocatorCode";
            this.OldLocatorCode.ReadOnly = true;
            this.OldLocatorCode.Size = new System.Drawing.Size(48, 23);
            this.OldLocatorCode.TabIndex = 268;
            // 
            // OldLocatorCodeDesc
            // 
            this.OldLocatorCodeDesc.BackColor = System.Drawing.Color.White;
            this.OldLocatorCodeDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular);
            this.OldLocatorCodeDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.OldLocatorCodeDesc.Location = new System.Drawing.Point(124, 237);
            this.OldLocatorCodeDesc.Multiline = true;
            this.OldLocatorCodeDesc.Name = "OldLocatorCodeDesc";
            this.OldLocatorCodeDesc.ReadOnly = true;
            this.OldLocatorCodeDesc.Size = new System.Drawing.Size(109, 23);
            this.OldLocatorCodeDesc.TabIndex = 269;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(3, 237);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 19);
            this.label9.Text = "Old Locator";
            // 
            // LocatorTaggingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(257, 337);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.OldLocatorCodeDesc);
            this.Controls.Add(this.OldLocatorCode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.StockCode);
            this.Controls.Add(this.Expiry);
            this.Controls.Add(this.LocatorCode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TagNo);
            this.Controls.Add(this.LocLabel);
            this.Controls.Add(this.LocatorCodeDesc);
            this.Controls.Add(this.RRNo);
            this.Controls.Add(this.UnitUntagged);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.UnitTagging);
            this.Controls.Add(this.TaggingQty);
            this.Controls.Add(this.AvailableQty);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LocatorTaggingWindow";
            this.Text = "Locator Tagging";
            this.Load += new System.EventHandler(this.LocatorTaggingWindow_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.LocatorTaggingWindow_Closing);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.AvailableQty, 0);
            this.Controls.SetChildIndex(this.TaggingQty, 0);
            this.Controls.SetChildIndex(this.UnitTagging, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.UnitUntagged, 0);
            this.Controls.SetChildIndex(this.RRNo, 0);
            this.Controls.SetChildIndex(this.LocatorCodeDesc, 0);
            this.Controls.SetChildIndex(this.LocLabel, 0);
            this.Controls.SetChildIndex(this.TagNo, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.LocatorCode, 0);
            this.Controls.SetChildIndex(this.Expiry, 0);
            this.Controls.SetChildIndex(this.StockCode, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.OldLocatorCode, 0);
            this.Controls.SetChildIndex(this.OldLocatorCodeDesc, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LocLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox AvailableQty;
        private System.Windows.Forms.TextBox TaggingQty;
        private System.Windows.Forms.TextBox UnitTagging;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox UnitUntagged;
        private System.Windows.Forms.TextBox TagNo;
        private System.Windows.Forms.TextBox LocatorCode;
        private System.Windows.Forms.TextBox LocatorCodeDesc;
        private System.Windows.Forms.TextBox RRNo;
        private System.Windows.Forms.Timer timerMultilined;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer timerBackGroudTransaction;
        private System.Windows.Forms.TextBox Expiry;
        private System.Windows.Forms.TextBox StockCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox OldLocatorCode;
        private System.Windows.Forms.TextBox OldLocatorCodeDesc;
        private System.Windows.Forms.Label label9;

    }
}