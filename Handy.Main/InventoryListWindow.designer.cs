namespace Handy
{
    partial class InventoryListWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventoryListWindow));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.listView1 = new System.Windows.Forms.ListView();
            this.StockCode = new System.Windows.Forms.ColumnHeader();
            this.RRNumber = new System.Windows.Forms.ColumnHeader();
            this.Quantity = new System.Windows.Forms.ColumnHeader();
            this.SentDateTime = new System.Windows.Forms.ColumnHeader();
            this.Remark = new System.Windows.Forms.ColumnHeader();
            this.LocatorDesc = new System.Windows.Forms.ColumnHeader();
            this.Specs = new System.Windows.Forms.ColumnHeader();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.ProgressMIT = new System.Windows.Forms.ProgressBar();
            this.lblRemark = new System.Windows.Forms.Label();
            this.txtLocatorDesc = new System.Windows.Forms.TextBox();
            this.RRNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPending = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblGridHeader = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblFilterHeader = new System.Windows.Forms.Label();
            this.lblSentPress = new System.Windows.Forms.Label();
            this.lblPendingPress = new System.Windows.Forms.Label();
            this.lblReprintPress = new System.Windows.Forms.Label();
            this.lblFailedPress = new System.Windows.Forms.Label();
            this.lblALLPress = new System.Windows.Forms.Label();
            this.lblSpecs = new System.Windows.Forms.Label();
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
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.listView1.Columns.Add(this.StockCode);
            this.listView1.Columns.Add(this.RRNumber);
            this.listView1.Columns.Add(this.Quantity);
            this.listView1.Columns.Add(this.SentDateTime);
            this.listView1.Columns.Add(this.Remark);
            this.listView1.Columns.Add(this.LocatorDesc);
            this.listView1.Columns.Add(this.Specs);
            this.listView1.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular);
            this.listView1.FullRowSelect = true;
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(4, 121);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(229, 103);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.TabIndex = 333;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // StockCode
            // 
            this.StockCode.Text = " Stock Code";
            this.StockCode.Width = 137;
            // 
            // RRNumber
            // 
            this.RRNumber.Text = "   RR Number";
            this.RRNumber.Width = 0;
            // 
            // Quantity
            // 
            this.Quantity.Text = " Quantity";
            this.Quantity.Width = 89;
            // 
            // SentDateTime
            // 
            this.SentDateTime.Text = "SentDateTime";
            this.SentDateTime.Width = 0;
            // 
            // Remark
            // 
            this.Remark.Text = "Remark";
            this.Remark.Width = 0;
            // 
            // LocatorDesc
            // 
            this.LocatorDesc.Text = "Locator Desc";
            this.LocatorDesc.Width = 0;
            // 
            // Specs
            // 
            this.Specs.Text = "Specs";
            this.Specs.Width = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageSize = new System.Drawing.Size(35, 20);
            this.imageList1.Images.Clear();
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource"))));
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource1"))));
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource2"))));
            // 
            // ProgressMIT
            // 
            this.ProgressMIT.Location = new System.Drawing.Point(4, 222);
            this.ProgressMIT.Name = "ProgressMIT";
            this.ProgressMIT.Size = new System.Drawing.Size(235, 10);
            this.ProgressMIT.Visible = false;
            // 
            // lblRemark
            // 
            this.lblRemark.BackColor = System.Drawing.Color.White;
            this.lblRemark.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblRemark.ForeColor = System.Drawing.Color.Teal;
            this.lblRemark.Location = new System.Drawing.Point(4, 231);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(238, 17);
            this.lblRemark.Text = "Remark: Scroll Items to view each remarks.";
            // 
            // txtLocatorDesc
            // 
            this.txtLocatorDesc.BackColor = System.Drawing.Color.White;
            this.txtLocatorDesc.Font = new System.Drawing.Font("Calibri", 8.5F, System.Drawing.FontStyle.Regular);
            this.txtLocatorDesc.ForeColor = System.Drawing.Color.Black;
            this.txtLocatorDesc.Location = new System.Drawing.Point(85, 66);
            this.txtLocatorDesc.Multiline = true;
            this.txtLocatorDesc.Name = "txtLocatorDesc";
            this.txtLocatorDesc.Size = new System.Drawing.Size(151, 21);
            this.txtLocatorDesc.TabIndex = 375;
            // 
            // RRNo
            // 
            this.RRNo.BackColor = System.Drawing.Color.White;
            this.RRNo.Font = new System.Drawing.Font("Calibri", 8.5F, System.Drawing.FontStyle.Regular);
            this.RRNo.ForeColor = System.Drawing.Color.Black;
            this.RRNo.Location = new System.Drawing.Point(85, 44);
            this.RRNo.Multiline = true;
            this.RRNo.Name = "RRNo";
            this.RRNo.Size = new System.Drawing.Size(151, 21);
            this.RRNo.TabIndex = 374;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(3, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 23);
            this.label2.Text = "Locator Desc";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(3, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 23);
            this.label1.Text = "RR Number";
            // 
            // lblPending
            // 
            this.lblPending.BackColor = System.Drawing.Color.White;
            this.lblPending.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblPending.ForeColor = System.Drawing.Color.Black;
            this.lblPending.Location = new System.Drawing.Point(124, 106);
            this.lblPending.Name = "lblPending";
            this.lblPending.Size = new System.Drawing.Size(112, 20);
            this.lblPending.Text = "PENDING : 0";
            this.lblPending.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblCount
            // 
            this.lblCount.BackColor = System.Drawing.Color.White;
            this.lblCount.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblCount.ForeColor = System.Drawing.Color.Black;
            this.lblCount.Location = new System.Drawing.Point(3, 106);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(116, 20);
            this.lblCount.Text = "COUNT : 00000";
            // 
            // lblGridHeader
            // 
            this.lblGridHeader.BackColor = System.Drawing.Color.Teal;
            this.lblGridHeader.ForeColor = System.Drawing.Color.White;
            this.lblGridHeader.Location = new System.Drawing.Point(5, 121);
            this.lblGridHeader.Name = "lblGridHeader";
            this.lblGridHeader.Size = new System.Drawing.Size(231, 22);
            this.lblGridHeader.Text = " SC (SN)                    | Quantity";
            this.lblGridHeader.ParentChanged += new System.EventHandler(this.lblGridHeader_ParentChanged);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.DarkGreen;
            this.label4.Location = new System.Drawing.Point(9, 255);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(224, 18);
            this.label4.Text = "1       2        3         4        5";
            // 
            // lblFilterHeader
            // 
            this.lblFilterHeader.BackColor = System.Drawing.Color.Teal;
            this.lblFilterHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblFilterHeader.ForeColor = System.Drawing.Color.White;
            this.lblFilterHeader.Location = new System.Drawing.Point(4, 244);
            this.lblFilterHeader.Name = "lblFilterHeader";
            this.lblFilterHeader.Size = new System.Drawing.Size(235, 13);
            this.lblFilterHeader.Text = "PRESS TO FILTER";
            // 
            // lblSentPress
            // 
            this.lblSentPress.BackColor = System.Drawing.Color.Teal;
            this.lblSentPress.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lblSentPress.ForeColor = System.Drawing.Color.White;
            this.lblSentPress.Location = new System.Drawing.Point(35, 271);
            this.lblSentPress.Name = "lblSentPress";
            this.lblSentPress.Size = new System.Drawing.Size(57, 12);
            this.lblSentPress.Text = "    SENT";
            // 
            // lblPendingPress
            // 
            this.lblPendingPress.BackColor = System.Drawing.Color.Teal;
            this.lblPendingPress.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lblPendingPress.ForeColor = System.Drawing.Color.White;
            this.lblPendingPress.Location = new System.Drawing.Point(87, 271);
            this.lblPendingPress.Name = "lblPendingPress";
            this.lblPendingPress.Size = new System.Drawing.Size(54, 12);
            this.lblPendingPress.Text = "PENDING";
            this.lblPendingPress.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblReprintPress
            // 
            this.lblReprintPress.BackColor = System.Drawing.Color.Teal;
            this.lblReprintPress.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lblReprintPress.ForeColor = System.Drawing.Color.White;
            this.lblReprintPress.Location = new System.Drawing.Point(138, 271);
            this.lblReprintPress.Name = "lblReprintPress";
            this.lblReprintPress.Size = new System.Drawing.Size(61, 12);
            this.lblReprintPress.Text = "REPRINT";
            this.lblReprintPress.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblFailedPress
            // 
            this.lblFailedPress.BackColor = System.Drawing.Color.Teal;
            this.lblFailedPress.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lblFailedPress.ForeColor = System.Drawing.Color.White;
            this.lblFailedPress.Location = new System.Drawing.Point(198, 271);
            this.lblFailedPress.Name = "lblFailedPress";
            this.lblFailedPress.Size = new System.Drawing.Size(40, 12);
            this.lblFailedPress.Text = "FAILED";
            // 
            // lblALLPress
            // 
            this.lblALLPress.BackColor = System.Drawing.Color.Teal;
            this.lblALLPress.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lblALLPress.ForeColor = System.Drawing.Color.White;
            this.lblALLPress.Location = new System.Drawing.Point(5, 271);
            this.lblALLPress.Name = "lblALLPress";
            this.lblALLPress.Size = new System.Drawing.Size(38, 12);
            this.lblALLPress.Text = " ALL";
            // 
            // lblSpecs
            // 
            this.lblSpecs.BackColor = System.Drawing.Color.White;
            this.lblSpecs.ForeColor = System.Drawing.Color.Teal;
            this.lblSpecs.Location = new System.Drawing.Point(4, 89);
            this.lblSpecs.Name = "lblSpecs";
            this.lblSpecs.Size = new System.Drawing.Size(232, 21);
            this.lblSpecs.Text = "Specs :";
            // 
            // InventoryListWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(243, 318);
            this.Controls.Add(this.ProgressMIT);
            this.Controls.Add(this.lblGridHeader);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.txtLocatorDesc);
            this.Controls.Add(this.lblSentPress);
            this.Controls.Add(this.lblALLPress);
            this.Controls.Add(this.lblFailedPress);
            this.Controls.Add(this.lblReprintPress);
            this.Controls.Add(this.lblPendingPress);
            this.Controls.Add(this.lblFilterHeader);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.RRNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPending);
            this.Controls.Add(this.lblRemark);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.lblSpecs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InventoryListWindow";
            this.Text = " Inventory List";
            this.Load += new System.EventHandler(this.InventoryListWindow_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.InventoryListWindow_Closing);
            this.Controls.SetChildIndex(this.lblSpecs, 0);
            this.Controls.SetChildIndex(this.lblCount, 0);
            this.Controls.SetChildIndex(this.lblRemark, 0);
            this.Controls.SetChildIndex(this.lblPending, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.RRNo, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.lblFilterHeader, 0);
            this.Controls.SetChildIndex(this.lblPendingPress, 0);
            this.Controls.SetChildIndex(this.lblReprintPress, 0);
            this.Controls.SetChildIndex(this.lblFailedPress, 0);
            this.Controls.SetChildIndex(this.lblALLPress, 0);
            this.Controls.SetChildIndex(this.lblSentPress, 0);
            this.Controls.SetChildIndex(this.txtLocatorDesc, 0);
            this.Controls.SetChildIndex(this.listView1, 0);
            this.Controls.SetChildIndex(this.lblGridHeader, 0);
            this.Controls.SetChildIndex(this.ProgressMIT, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader RRNumber;
        private System.Windows.Forms.ColumnHeader Quantity;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ColumnHeader StockCode;
        private System.Windows.Forms.ColumnHeader SentDateTime;
        private System.Windows.Forms.ColumnHeader Remark;
        private System.Windows.Forms.ColumnHeader LocatorDesc;
        public System.Windows.Forms.ProgressBar ProgressMIT;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.TextBox txtLocatorDesc;
        private System.Windows.Forms.TextBox RRNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPending;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblGridHeader;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblFilterHeader;
        private System.Windows.Forms.Label lblSentPress;
        private System.Windows.Forms.Label lblPendingPress;
        private System.Windows.Forms.Label lblReprintPress;
        private System.Windows.Forms.Label lblFailedPress;
        private System.Windows.Forms.Label lblALLPress;
        private System.Windows.Forms.Label lblSpecs;
        private System.Windows.Forms.ColumnHeader Specs;
    }
}