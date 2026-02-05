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
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.UnitUntagged = new System.Windows.Forms.TextBox();
            this.OldLocatorCode = new System.Windows.Forms.TextBox();
            this.OldLocatorCodeDesc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TagNo = new System.Windows.Forms.TextBox();
            this.Class = new System.Windows.Forms.TextBox();
            this.Dimension = new System.Windows.Forms.TextBox();
            this.Specs = new System.Windows.Forms.TextBox();
            this.LocatorCode = new System.Windows.Forms.TextBox();
            this.LocatorCodeDesc = new System.Windows.Forms.TextBox();
            this.RRNo = new System.Windows.Forms.TextBox();
            this.timerMultilined = new System.Windows.Forms.Timer();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTaggingQuantityDisplay = new System.Windows.Forms.Label();
            this.timerBackGroundTransaction = new System.Windows.Forms.Timer();
            this.SuspendLayout();
            // 
            // LocLabel
            // 
            this.LocLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
            this.LocLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LocLabel.Location = new System.Drawing.Point(3, 47);
            this.LocLabel.Name = "LocLabel";
            this.LocLabel.Size = new System.Drawing.Size(70, 19);
            this.LocLabel.Text = "Locator";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(3, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 20);
            this.label4.Text = "Quantity";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(3, 190);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 20);
            this.label7.Text = "Available";
            // 
            // AvailableQty
            // 
            this.AvailableQty.BackColor = System.Drawing.Color.White;
            this.AvailableQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
            this.AvailableQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.AvailableQty.Location = new System.Drawing.Point(76, 187);
            this.AvailableQty.Multiline = true;
            this.AvailableQty.Name = "AvailableQty";
            this.AvailableQty.Size = new System.Drawing.Size(120, 25);
            this.AvailableQty.TabIndex = 100;
            // 
            // TaggingQty
            // 
            this.TaggingQty.BackColor = System.Drawing.Color.White;
            this.TaggingQty.Enabled = false;
            this.TaggingQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
            this.TaggingQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TaggingQty.Location = new System.Drawing.Point(76, 211);
            this.TaggingQty.Name = "TaggingQty";
            this.TaggingQty.ReadOnly = true;
            this.TaggingQty.Size = new System.Drawing.Size(120, 25);
            this.TaggingQty.TabIndex = 102;
            this.TaggingQty.Text = "123";
            // 
            // UnitTagging
            // 
            this.UnitTagging.BackColor = System.Drawing.Color.White;
            this.UnitTagging.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
            this.UnitTagging.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.UnitTagging.Location = new System.Drawing.Point(195, 210);
            this.UnitTagging.Multiline = true;
            this.UnitTagging.Name = "UnitTagging";
            this.UnitTagging.Size = new System.Drawing.Size(39, 26);
            this.UnitTagging.TabIndex = 152;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(3, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 19);
            this.label1.Text = "RR No";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(3, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 19);
            this.label8.Text = "Dimension";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(3, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 19);
            this.label2.Text = "Tag No";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label11.Location = new System.Drawing.Point(3, 119);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 19);
            this.label11.Text = "Specs";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label12.Location = new System.Drawing.Point(3, 143);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 19);
            this.label12.Text = "Class";
            // 
            // UnitUntagged
            // 
            this.UnitUntagged.BackColor = System.Drawing.Color.White;
            this.UnitUntagged.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
            this.UnitUntagged.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.UnitUntagged.Location = new System.Drawing.Point(195, 187);
            this.UnitUntagged.Multiline = true;
            this.UnitUntagged.Name = "UnitUntagged";
            this.UnitUntagged.Size = new System.Drawing.Size(39, 25);
            this.UnitUntagged.TabIndex = 254;
            // 
            // OldLocatorCode
            // 
            this.OldLocatorCode.BackColor = System.Drawing.Color.White;
            this.OldLocatorCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.OldLocatorCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.OldLocatorCode.Location = new System.Drawing.Point(76, 235);
            this.OldLocatorCode.Multiline = true;
            this.OldLocatorCode.Name = "OldLocatorCode";
            this.OldLocatorCode.Size = new System.Drawing.Size(67, 25);
            this.OldLocatorCode.TabIndex = 271;
            // 
            // OldLocatorCodeDesc
            // 
            this.OldLocatorCodeDesc.BackColor = System.Drawing.Color.White;
            this.OldLocatorCodeDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.OldLocatorCodeDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.OldLocatorCodeDesc.Location = new System.Drawing.Point(142, 235);
            this.OldLocatorCodeDesc.Multiline = true;
            this.OldLocatorCodeDesc.Name = "OldLocatorCodeDesc";
            this.OldLocatorCodeDesc.Size = new System.Drawing.Size(92, 25);
            this.OldLocatorCodeDesc.TabIndex = 270;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(3, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 19);
            this.label5.Text = "Old Locator";
            // 
            // TagNo
            // 
            this.TagNo.BackColor = System.Drawing.Color.White;
            this.TagNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
            this.TagNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TagNo.Location = new System.Drawing.Point(76, 67);
            this.TagNo.Multiline = true;
            this.TagNo.Name = "TagNo";
            this.TagNo.Size = new System.Drawing.Size(158, 25);
            this.TagNo.TabIndex = 391;
            // 
            // Class
            // 
            this.Class.BackColor = System.Drawing.Color.White;
            this.Class.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
            this.Class.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Class.Location = new System.Drawing.Point(76, 139);
            this.Class.Multiline = true;
            this.Class.Name = "Class";
            this.Class.Size = new System.Drawing.Size(158, 25);
            this.Class.TabIndex = 390;
            // 
            // Dimension
            // 
            this.Dimension.BackColor = System.Drawing.Color.White;
            this.Dimension.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
            this.Dimension.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Dimension.Location = new System.Drawing.Point(76, 91);
            this.Dimension.Multiline = true;
            this.Dimension.Name = "Dimension";
            this.Dimension.Size = new System.Drawing.Size(158, 25);
            this.Dimension.TabIndex = 389;
            // 
            // Specs
            // 
            this.Specs.BackColor = System.Drawing.Color.White;
            this.Specs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
            this.Specs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Specs.Location = new System.Drawing.Point(76, 115);
            this.Specs.Multiline = true;
            this.Specs.Name = "Specs";
            this.Specs.Size = new System.Drawing.Size(158, 25);
            this.Specs.TabIndex = 388;
            // 
            // LocatorCode
            // 
            this.LocatorCode.BackColor = System.Drawing.Color.White;
            this.LocatorCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.LocatorCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LocatorCode.Location = new System.Drawing.Point(76, 43);
            this.LocatorCode.Multiline = true;
            this.LocatorCode.Name = "LocatorCode";
            this.LocatorCode.Size = new System.Drawing.Size(67, 25);
            this.LocatorCode.TabIndex = 387;
            // 
            // LocatorCodeDesc
            // 
            this.LocatorCodeDesc.BackColor = System.Drawing.Color.White;
            this.LocatorCodeDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.LocatorCodeDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LocatorCodeDesc.Location = new System.Drawing.Point(142, 43);
            this.LocatorCodeDesc.Multiline = true;
            this.LocatorCodeDesc.Name = "LocatorCodeDesc";
            this.LocatorCodeDesc.Size = new System.Drawing.Size(92, 25);
            this.LocatorCodeDesc.TabIndex = 386;
            // 
            // RRNo
            // 
            this.RRNo.BackColor = System.Drawing.Color.White;
            this.RRNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
            this.RRNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.RRNo.Location = new System.Drawing.Point(76, 163);
            this.RRNo.Multiline = true;
            this.RRNo.Name = "RRNo";
            this.RRNo.Size = new System.Drawing.Size(158, 25);
            this.RRNo.TabIndex = 385;
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
            this.label6.Size = new System.Drawing.Size(232, 18);
            this.label6.Text = "Pressing [ Enter button ] will display list.";
            // 
            // lblTaggingQuantityDisplay
            // 
            this.lblTaggingQuantityDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
            this.lblTaggingQuantityDisplay.ForeColor = System.Drawing.Color.Black;
            this.lblTaggingQuantityDisplay.Location = new System.Drawing.Point(79, 212);
            this.lblTaggingQuantityDisplay.Name = "lblTaggingQuantityDisplay";
            this.lblTaggingQuantityDisplay.Size = new System.Drawing.Size(119, 23);
            // 
            // timerBackGroundTransaction
            // 
            this.timerBackGroundTransaction.Interval = 3000;
            this.timerBackGroundTransaction.Tick += new System.EventHandler(this.timerBackGroudTransaction_Tick);
            // 
            // LocatorTaggingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(241, 320);
            this.Controls.Add(this.lblTaggingQuantityDisplay);
            this.Controls.Add(this.LocatorCode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TagNo);
            this.Controls.Add(this.Class);
            this.Controls.Add(this.Dimension);
            this.Controls.Add(this.Specs);
            this.Controls.Add(this.LocLabel);
            this.Controls.Add(this.LocatorCodeDesc);
            this.Controls.Add(this.RRNo);
            this.Controls.Add(this.OldLocatorCode);
            this.Controls.Add(this.OldLocatorCodeDesc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.UnitUntagged);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
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
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.UnitUntagged, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.OldLocatorCodeDesc, 0);
            this.Controls.SetChildIndex(this.OldLocatorCode, 0);
            this.Controls.SetChildIndex(this.RRNo, 0);
            this.Controls.SetChildIndex(this.LocatorCodeDesc, 0);
            this.Controls.SetChildIndex(this.LocLabel, 0);
            this.Controls.SetChildIndex(this.Specs, 0);
            this.Controls.SetChildIndex(this.Dimension, 0);
            this.Controls.SetChildIndex(this.Class, 0);
            this.Controls.SetChildIndex(this.TagNo, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.LocatorCode, 0);
            this.Controls.SetChildIndex(this.lblTaggingQuantityDisplay, 0);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox UnitUntagged;
        private System.Windows.Forms.TextBox OldLocatorCode;
        private System.Windows.Forms.TextBox OldLocatorCodeDesc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TagNo;
        private System.Windows.Forms.TextBox Class;
        private System.Windows.Forms.TextBox Dimension;
        private System.Windows.Forms.TextBox Specs;
        private System.Windows.Forms.TextBox LocatorCode;
        private System.Windows.Forms.TextBox LocatorCodeDesc;
        private System.Windows.Forms.TextBox RRNo;
        private System.Windows.Forms.Timer timerMultilined;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTaggingQuantityDisplay;
        private System.Windows.Forms.Timer timerBackGroundTransaction;

    }
}