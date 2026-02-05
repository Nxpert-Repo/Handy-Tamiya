namespace Handy
{
    partial class StockReclassWindow
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
            this.txtNewClass = new System.Windows.Forms.TextBox();
            this.TagNo = new System.Windows.Forms.TextBox();
            this.Dimension = new System.Windows.Forms.TextBox();
            this.Specs = new System.Windows.Forms.TextBox();
            this.LocatorCode = new System.Windows.Forms.TextBox();
            this.LocatorCodeDesc = new System.Windows.Forms.TextBox();
            this.RRNo = new System.Windows.Forms.TextBox();
            this.UnitAvailable = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.AvailableQty = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.LocLabel = new System.Windows.Forms.Label();
            this.Class = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panelClassList = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.lstClassList = new System.Windows.Forms.ListView();
            this.StockClassCode = new System.Windows.Forms.ColumnHeader();
            this.StockType = new System.Windows.Forms.ColumnHeader();
            this.StockClassDesc = new System.Windows.Forms.ColumnHeader();
            this.timerMultilined = new System.Windows.Forms.Timer();
            this.timerMultilined2 = new System.Windows.Forms.Timer();
            this.panelCustomerList = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lstCustomerList = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.panelClassList.SuspendLayout();
            this.panelCustomerList.SuspendLayout();
            this.SuspendLayout();
            // 
            // pcbSignal
            // 
            this.pcbSignal.BackColor = System.Drawing.Color.White;
            // 
            // txtNewClass
            // 
            this.txtNewClass.BackColor = System.Drawing.Color.White;
            this.txtNewClass.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular);
            this.txtNewClass.ForeColor = System.Drawing.Color.Blue;
            this.txtNewClass.Location = new System.Drawing.Point(276, 88);
            this.txtNewClass.Name = "txtNewClass";
            this.txtNewClass.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNewClass.Size = new System.Drawing.Size(32, 28);
            this.txtNewClass.TabIndex = 433;
            this.txtNewClass.Visible = false;
            // 
            // TagNo
            // 
            this.TagNo.BackColor = System.Drawing.Color.White;
            this.TagNo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular);
            this.TagNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TagNo.Location = new System.Drawing.Point(75, 77);
            this.TagNo.Multiline = true;
            this.TagNo.Name = "TagNo";
            this.TagNo.Size = new System.Drawing.Size(235, 25);
            this.TagNo.TabIndex = 413;
            // 
            // Dimension
            // 
            this.Dimension.BackColor = System.Drawing.Color.White;
            this.Dimension.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular);
            this.Dimension.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Dimension.Location = new System.Drawing.Point(75, 125);
            this.Dimension.Multiline = true;
            this.Dimension.Name = "Dimension";
            this.Dimension.Size = new System.Drawing.Size(235, 25);
            this.Dimension.TabIndex = 411;
            // 
            // Specs
            // 
            this.Specs.BackColor = System.Drawing.Color.White;
            this.Specs.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular);
            this.Specs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Specs.Location = new System.Drawing.Point(75, 149);
            this.Specs.Multiline = true;
            this.Specs.Name = "Specs";
            this.Specs.Size = new System.Drawing.Size(235, 25);
            this.Specs.TabIndex = 410;
            // 
            // LocatorCode
            // 
            this.LocatorCode.BackColor = System.Drawing.Color.White;
            this.LocatorCode.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.LocatorCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LocatorCode.Location = new System.Drawing.Point(75, 221);
            this.LocatorCode.Multiline = true;
            this.LocatorCode.Name = "LocatorCode";
            this.LocatorCode.Size = new System.Drawing.Size(67, 25);
            this.LocatorCode.TabIndex = 409;
            // 
            // LocatorCodeDesc
            // 
            this.LocatorCodeDesc.BackColor = System.Drawing.Color.White;
            this.LocatorCodeDesc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.LocatorCodeDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LocatorCodeDesc.Location = new System.Drawing.Point(141, 221);
            this.LocatorCodeDesc.Multiline = true;
            this.LocatorCodeDesc.Name = "LocatorCodeDesc";
            this.LocatorCodeDesc.Size = new System.Drawing.Size(169, 25);
            this.LocatorCodeDesc.TabIndex = 408;
            this.LocatorCodeDesc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.BaseWindow_KeyUp);
            // 
            // RRNo
            // 
            this.RRNo.BackColor = System.Drawing.Color.White;
            this.RRNo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular);
            this.RRNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.RRNo.Location = new System.Drawing.Point(75, 173);
            this.RRNo.Multiline = true;
            this.RRNo.Name = "RRNo";
            this.RRNo.Size = new System.Drawing.Size(235, 25);
            this.RRNo.TabIndex = 407;
            // 
            // UnitAvailable
            // 
            this.UnitAvailable.BackColor = System.Drawing.Color.White;
            this.UnitAvailable.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular);
            this.UnitAvailable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.UnitAvailable.Location = new System.Drawing.Point(249, 197);
            this.UnitAvailable.Multiline = true;
            this.UnitAvailable.Name = "UnitAvailable";
            this.UnitAvailable.Size = new System.Drawing.Size(61, 25);
            this.UnitAvailable.TabIndex = 404;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(7, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 19);
            this.label1.Text = "RR No";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(7, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 19);
            this.label8.Text = "Dimension";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(7, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 19);
            this.label2.Text = "Tag No";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label11.Location = new System.Drawing.Point(7, 151);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 19);
            this.label11.Text = "Specs";
            // 
            // AvailableQty
            // 
            this.AvailableQty.BackColor = System.Drawing.Color.White;
            this.AvailableQty.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular);
            this.AvailableQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.AvailableQty.Location = new System.Drawing.Point(75, 197);
            this.AvailableQty.Multiline = true;
            this.AvailableQty.Name = "AvailableQty";
            this.AvailableQty.Size = new System.Drawing.Size(181, 25);
            this.AvailableQty.TabIndex = 401;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(7, 199);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 20);
            this.label7.Text = "Available";
            // 
            // LocLabel
            // 
            this.LocLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.LocLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LocLabel.Location = new System.Drawing.Point(7, 225);
            this.LocLabel.Name = "LocLabel";
            this.LocLabel.Size = new System.Drawing.Size(70, 19);
            this.LocLabel.Text = "Locator";
            // 
            // Class
            // 
            this.Class.BackColor = System.Drawing.Color.White;
            this.Class.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular);
            this.Class.ForeColor = System.Drawing.Color.Red;
            this.Class.Location = new System.Drawing.Point(75, 101);
            this.Class.Multiline = true;
            this.Class.Name = "Class";
            this.Class.Size = new System.Drawing.Size(235, 25);
            this.Class.TabIndex = 430;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(7, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 19);
            this.label5.Text = "Class";
            // 
            // panelClassList
            // 
            this.panelClassList.BackColor = System.Drawing.Color.Teal;
            this.panelClassList.Controls.Add(this.label9);
            this.panelClassList.Controls.Add(this.lstClassList);
            this.panelClassList.Location = new System.Drawing.Point(12, 253);
            this.panelClassList.Name = "panelClassList";
            this.panelClassList.Size = new System.Drawing.Size(26, 27);
            this.panelClassList.Visible = false;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(2, 4);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(147, 19);
            this.label9.Text = "SELECT NEW CLASS";
            // 
            // lstClassList
            // 
            this.lstClassList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lstClassList.Columns.Add(this.StockClassCode);
            this.lstClassList.Columns.Add(this.StockType);
            this.lstClassList.Columns.Add(this.StockClassDesc);
            this.lstClassList.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lstClassList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lstClassList.FullRowSelect = true;
            this.lstClassList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstClassList.Location = new System.Drawing.Point(0, 26);
            this.lstClassList.Name = "lstClassList";
            this.lstClassList.Size = new System.Drawing.Size(304, 105);
            this.lstClassList.TabIndex = 335;
            this.lstClassList.View = System.Windows.Forms.View.Details;
            // 
            // StockClassCode
            // 
            this.StockClassCode.Text = "StockClassCode";
            this.StockClassCode.Width = 0;
            // 
            // StockType
            // 
            this.StockType.Text = "StockType";
            this.StockType.Width = 0;
            // 
            // StockClassDesc
            // 
            this.StockClassDesc.Text = "StockClassDesc";
            this.StockClassDesc.Width = 285;
            // 
            // timerMultilined
            // 
            this.timerMultilined.Interval = 60000;
            // 
            // timerMultilined2
            // 
            this.timerMultilined2.Interval = 3000;
            this.timerMultilined2.Tick += new System.EventHandler(this.timerMultilined2_Tick);
            // 
            // panelCustomerList
            // 
            this.panelCustomerList.BackColor = System.Drawing.Color.Teal;
            this.panelCustomerList.Controls.Add(this.label4);
            this.panelCustomerList.Controls.Add(this.label3);
            this.panelCustomerList.Controls.Add(this.lstCustomerList);
            this.panelCustomerList.Location = new System.Drawing.Point(3, 43);
            this.panelCustomerList.Name = "panelCustomerList";
            this.panelCustomerList.Size = new System.Drawing.Size(24, 19);
            this.panelCustomerList.Visible = false;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(308, 19);
            this.label4.Text = "Customer Code      |  Customer Name";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(2, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 19);
            this.label3.Text = "SELECT CUSTOMER";
            // 
            // lstCustomerList
            // 
            this.lstCustomerList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lstCustomerList.Columns.Add(this.columnHeader1);
            this.lstCustomerList.Columns.Add(this.columnHeader2);
            this.lstCustomerList.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lstCustomerList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lstCustomerList.FullRowSelect = true;
            this.lstCustomerList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstCustomerList.Location = new System.Drawing.Point(3, 43);
            this.lstCustomerList.Name = "lstCustomerList";
            this.lstCustomerList.Size = new System.Drawing.Size(308, 200);
            this.lstCustomerList.TabIndex = 335;
            this.lstCustomerList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "CustomerCode";
            this.columnHeader1.Width = 110;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "CustomerShortDesc";
            this.columnHeader2.Width = 175;
            // 
            // StockReclassWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(320, 320);
            this.Controls.Add(this.panelCustomerList);
            this.Controls.Add(this.panelClassList);
            this.Controls.Add(this.LocatorCode);
            this.Controls.Add(this.LocatorCodeDesc);
            this.Controls.Add(this.LocLabel);
            this.Controls.Add(this.Class);
            this.Controls.Add(this.TagNo);
            this.Controls.Add(this.txtNewClass);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Dimension);
            this.Controls.Add(this.Specs);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.RRNo);
            this.Controls.Add(this.UnitAvailable);
            this.Controls.Add(this.AvailableQty);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label11);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StockReclassWindow";
            this.Text = "StockReclassWindow";
            this.Load += new System.EventHandler(this.StockReclassWindow_Load);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.AvailableQty, 0);
            this.Controls.SetChildIndex(this.UnitAvailable, 0);
            this.Controls.SetChildIndex(this.RRNo, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.Specs, 0);
            this.Controls.SetChildIndex(this.Dimension, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtNewClass, 0);
            this.Controls.SetChildIndex(this.TagNo, 0);
            this.Controls.SetChildIndex(this.Class, 0);
            this.Controls.SetChildIndex(this.LocLabel, 0);
            this.Controls.SetChildIndex(this.LocatorCodeDesc, 0);
            this.Controls.SetChildIndex(this.LocatorCode, 0);
            this.Controls.SetChildIndex(this.panelClassList, 0);
            this.Controls.SetChildIndex(this.panelCustomerList, 0);
            this.panelClassList.ResumeLayout(false);
            this.panelCustomerList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox TagNo;
        private System.Windows.Forms.TextBox Dimension;
        private System.Windows.Forms.TextBox Specs;
        private System.Windows.Forms.TextBox LocatorCode;
        private System.Windows.Forms.TextBox LocatorCodeDesc;
        private System.Windows.Forms.TextBox RRNo;
        private System.Windows.Forms.TextBox UnitAvailable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox AvailableQty;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label LocLabel;
        private System.Windows.Forms.TextBox Class;
        private System.Windows.Forms.TextBox txtNewClass;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelClassList;
        private System.Windows.Forms.ListView lstClassList;
        public System.Windows.Forms.ColumnHeader StockClassCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ColumnHeader StockType;
        private System.Windows.Forms.ColumnHeader StockClassDesc;
        private System.Windows.Forms.Timer timerMultilined;
        private System.Windows.Forms.Timer timerMultilined2;
        private System.Windows.Forms.Panel panelCustomerList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView lstCustomerList;
        public System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label4;
    }
}