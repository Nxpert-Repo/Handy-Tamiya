namespace Handy
{
    partial class LocatorTaggingListWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LocatorTaggingListWindow));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.ListView1 = new System.Windows.Forms.ListView();
            this.TagNumber = new System.Windows.Forms.ColumnHeader();
            this.LocaQty = new System.Windows.Forms.ColumnHeader();
            this.LocatorDesc = new System.Windows.Forms.ColumnHeader();
            this.LocatorCode = new System.Windows.Forms.ColumnHeader();
            this.lblLocatorDesc = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timerBackGroudTransaction = new System.Windows.Forms.Timer();
            this.lblListHeader = new System.Windows.Forms.Label();
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
            // imageList1
            // 
            this.imageList1.ImageSize = new System.Drawing.Size(40, 20);
            this.imageList1.Images.Clear();
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource"))));
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource1"))));
            // 
            // ListView1
            // 
            this.ListView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ListView1.Columns.Add(this.TagNumber);
            this.ListView1.Columns.Add(this.LocaQty);
            this.ListView1.Columns.Add(this.LocatorDesc);
            this.ListView1.Columns.Add(this.LocatorCode);
            this.ListView1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.ListView1.FullRowSelect = true;
            this.ListView1.LargeImageList = this.imageList1;
            this.ListView1.Location = new System.Drawing.Point(3, 78);
            this.ListView1.Name = "ListView1";
            this.ListView1.Size = new System.Drawing.Size(236, 172);
            this.ListView1.SmallImageList = this.imageList1;
            this.ListView1.TabIndex = 343;
            this.ListView1.View = System.Windows.Forms.View.Details;
            // 
            // TagNumber
            // 
            this.TagNumber.Text = "      Tag Number";
            this.TagNumber.Width = 200;
            // 
            // LocaQty
            // 
            this.LocaQty.Text = "QTY";
            this.LocaQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.LocaQty.Width = 55;
            // 
            // LocatorDesc
            // 
            this.LocatorDesc.Text = "Locator Desc";
            this.LocatorDesc.Width = 0;
            // 
            // LocatorCode
            // 
            this.LocatorCode.Text = "Locator Code";
            this.LocatorCode.Width = 0;
            // 
            // lblLocatorDesc
            // 
            this.lblLocatorDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular);
            this.lblLocatorDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblLocatorDesc.Location = new System.Drawing.Point(6, 36);
            this.lblLocatorDesc.Name = "lblLocatorDesc";
            this.lblLocatorDesc.Size = new System.Drawing.Size(226, 39);
            this.lblLocatorDesc.Text = "LOCATOR: ";
            // 
            // lblCount
            // 
            this.lblCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCount.Location = new System.Drawing.Point(114, 61);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(118, 16);
            this.lblCount.Text = "COUNT:  0";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(4, 251);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 32);
            this.label1.Text = "Pressing [ Arrow left/right keypad  button ] will display untagged list.";
            // 
            // timerBackGroudTransaction
            // 
            this.timerBackGroudTransaction.Interval = 3000;
            this.timerBackGroudTransaction.Tick += new System.EventHandler(this.timerBackGroudTransaction_Tick_1);
            // 
            // lblListHeader
            // 
            this.lblListHeader.BackColor = System.Drawing.Color.Teal;
            this.lblListHeader.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblListHeader.ForeColor = System.Drawing.Color.White;
            this.lblListHeader.Location = new System.Drawing.Point(2, 78);
            this.lblListHeader.Name = "lblListHeader";
            this.lblListHeader.Size = new System.Drawing.Size(237, 23);
            this.lblListHeader.Text = " Tag Number                        |    QTY";
            // 
            // LocatorTaggingListWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(243, 320);
            this.Controls.Add(this.lblListHeader);
            this.Controls.Add(this.ListView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.lblLocatorDesc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LocatorTaggingListWindow";
            this.Text = "Locator Tagging List";
            this.Load += new System.EventHandler(this.LocatorTaggingListWindow_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.LocatorTaggingListWindow_Closing);
            this.Controls.SetChildIndex(this.lblLocatorDesc, 0);
            this.Controls.SetChildIndex(this.lblCount, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.ListView1, 0);
            this.Controls.SetChildIndex(this.lblListHeader, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListView ListView1;
        private System.Windows.Forms.ColumnHeader TagNumber;
        private System.Windows.Forms.ColumnHeader LocaQty;
        private System.Windows.Forms.Label lblLocatorDesc;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.ColumnHeader LocatorDesc;
        private System.Windows.Forms.ColumnHeader LocatorCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timerBackGroudTransaction;
        private System.Windows.Forms.Label lblListHeader;
    }
}