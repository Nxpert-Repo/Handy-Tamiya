namespace Handy
{
    partial class ScannedListWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScannedListWindow));
            this.ScannedListView = new System.Windows.Forms.ListView();
            this.TagNumber = new System.Windows.Forms.ColumnHeader();
            this.SendingStatus = new System.Windows.Forms.ColumnHeader();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.txtPendingCount = new System.Windows.Forms.Label();
            this.lblGridHeader = new System.Windows.Forms.Label();
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
            // ScannedListView
            // 
            this.ScannedListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ScannedListView.Columns.Add(this.TagNumber);
            this.ScannedListView.Columns.Add(this.SendingStatus);
            this.ScannedListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
            this.ScannedListView.FullRowSelect = true;
            this.ScannedListView.Location = new System.Drawing.Point(3, 61);
            this.ScannedListView.Name = "ScannedListView";
            this.ScannedListView.Size = new System.Drawing.Size(233, 216);
            this.ScannedListView.SmallImageList = this.imageList1;
            this.ScannedListView.TabIndex = 333;
            this.ScannedListView.View = System.Windows.Forms.View.Details;
            // 
            // TagNumber
            // 
            this.TagNumber.Text = "   Tag Number";
            this.TagNumber.Width = 140;
            // 
            // SendingStatus
            // 
            this.SendingStatus.Text = "Sending Status";
            this.SendingStatus.Width = 123;
            // 
            // imageList1
            // 
            this.imageList1.ImageSize = new System.Drawing.Size(40, 20);
            this.imageList1.Images.Clear();
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource"))));
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource1"))));
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource2"))));
            // 
            // txtPendingCount
            // 
            this.txtPendingCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular);
            this.txtPendingCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPendingCount.Location = new System.Drawing.Point(10, 41);
            this.txtPendingCount.Name = "txtPendingCount";
            this.txtPendingCount.Size = new System.Drawing.Size(173, 19);
            this.txtPendingCount.Text = "PENDING: 0";
            // 
            // lblGridHeader
            // 
            this.lblGridHeader.BackColor = System.Drawing.Color.Teal;
            this.lblGridHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular);
            this.lblGridHeader.ForeColor = System.Drawing.Color.White;
            this.lblGridHeader.Location = new System.Drawing.Point(5, 61);
            this.lblGridHeader.Name = "lblGridHeader";
            this.lblGridHeader.Size = new System.Drawing.Size(230, 23);
            this.lblGridHeader.Text = "      Tag Number             | Sending Status";
            // 
            // ScannedListWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(241, 321);
            this.Controls.Add(this.lblGridHeader);
            this.Controls.Add(this.ScannedListView);
            this.Controls.Add(this.txtPendingCount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScannedListWindow";
            this.Text = "Scanned List";
            this.Load += new System.EventHandler(this.ScanList_Load);
            this.Controls.SetChildIndex(this.txtPendingCount, 0);
            this.Controls.SetChildIndex(this.ScannedListView, 0);
            this.Controls.SetChildIndex(this.lblGridHeader, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView ScannedListView;
        private System.Windows.Forms.ColumnHeader TagNumber;
        private System.Windows.Forms.ColumnHeader SendingStatus;
        private System.Windows.Forms.Label txtPendingCount;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lblGridHeader;
    }
}