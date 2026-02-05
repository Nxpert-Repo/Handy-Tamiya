namespace Handy
{
    partial class MaterialTransferWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaterialTransferWindow));
            this.TransferNo = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.RRNo = new System.Windows.Forms.TextBox();
            this.txttransqty = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLocator = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.StockNames = new System.Windows.Forms.ColumnHeader();
            this.WrdSeqNo = new System.Windows.Forms.ColumnHeader();
            this.WrdSplitNo = new System.Windows.Forms.ColumnHeader();
            this.Wrd_LastSplitSeqNo = new System.Windows.Forms.ColumnHeader();
            this.StockCode = new System.Windows.Forms.ColumnHeader();
            this.Spec = new System.Windows.Forms.ColumnHeader();
            this.SIQty = new System.Windows.Forms.ColumnHeader();
            this.RequestQty = new System.Windows.Forms.ColumnHeader();
            this.ReservedQty = new System.Windows.Forms.ColumnHeader();
            this.Issue = new System.Windows.Forms.ColumnHeader();
            this.Wrd_RRNo = new System.Windows.Forms.ColumnHeader();
            this.Wrd_RRSeqNo = new System.Windows.Forms.ColumnHeader();
            this.Wrd_RRLotSeqNo = new System.Windows.Forms.ColumnHeader();
            this.Wrd_RRLoc = new System.Windows.Forms.ColumnHeader();
            this.StockType = new System.Windows.Forms.ColumnHeader();
            this.IssueStatus = new System.Windows.Forms.ColumnHeader();
            this.WrhStatus = new System.Windows.Forms.ColumnHeader();
            this.WrdStatus = new System.Windows.Forms.ColumnHeader();
            this.EXT_RRAvailable = new System.Windows.Forms.ColumnHeader();
            this.EXT_UploadStatus = new System.Windows.Forms.ColumnHeader();
            this.EXT_Remark = new System.Windows.Forms.ColumnHeader();
            this.EXTBarcodeQty = new System.Windows.Forms.ColumnHeader();
            this.EXTBarcodePrintDate = new System.Windows.Forms.ColumnHeader();
            this.EXTLocator = new System.Windows.Forms.ColumnHeader();
            this.label2 = new System.Windows.Forms.Label();
            this.AvailableQty = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Progress = new System.Windows.Forms.ProgressBar();
            this.lblRemark = new System.Windows.Forms.Label();
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
            // TransferNo
            // 
            this.TransferNo.BackColor = System.Drawing.Color.White;
            this.TransferNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
            this.TransferNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TransferNo.Location = new System.Drawing.Point(80, 41);
            this.TransferNo.Name = "TransferNo";
            this.TransferNo.Size = new System.Drawing.Size(150, 25);
            this.TransferNo.TabIndex = 295;
            this.TransferNo.WordWrap = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageSize = new System.Drawing.Size(40, 20);
            this.imageList1.Images.Clear();
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource"))));
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource1"))));
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource2"))));
            // 
            // RRNo
            // 
            this.RRNo.BackColor = System.Drawing.Color.White;
            this.RRNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular);
            this.RRNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.RRNo.Location = new System.Drawing.Point(80, 68);
            this.RRNo.Multiline = true;
            this.RRNo.Name = "RRNo";
            this.RRNo.Size = new System.Drawing.Size(150, 25);
            this.RRNo.TabIndex = 372;
            // 
            // txttransqty
            // 
            this.txttransqty.BackColor = System.Drawing.Color.White;
            this.txttransqty.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular);
            this.txttransqty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txttransqty.Location = new System.Drawing.Point(80, 92);
            this.txttransqty.Multiline = true;
            this.txttransqty.Name = "txttransqty";
            this.txttransqty.Size = new System.Drawing.Size(150, 25);
            this.txttransqty.TabIndex = 374;
            this.txttransqty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(7, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 19);
            this.label1.Text = "RR Number:";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(7, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 18);
            this.label4.Text = "Transfer Qty:";
            // 
            // lblLocator
            // 
            this.lblLocator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblLocator.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblLocator.ForeColor = System.Drawing.Color.White;
            this.lblLocator.Location = new System.Drawing.Point(147, 145);
            this.lblLocator.Name = "lblLocator";
            this.lblLocator.Size = new System.Drawing.Size(86, 19);
            this.lblLocator.Text = "000000";
            this.lblLocator.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblLocator.Visible = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Teal;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(7, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(223, 19);
            this.label3.Text = " Stock Name                         | Issue Qty";
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.listView1.Columns.Add(this.StockNames);
            this.listView1.Columns.Add(this.WrdSeqNo);
            this.listView1.Columns.Add(this.WrdSplitNo);
            this.listView1.Columns.Add(this.Wrd_LastSplitSeqNo);
            this.listView1.Columns.Add(this.StockCode);
            this.listView1.Columns.Add(this.Spec);
            this.listView1.Columns.Add(this.SIQty);
            this.listView1.Columns.Add(this.RequestQty);
            this.listView1.Columns.Add(this.ReservedQty);
            this.listView1.Columns.Add(this.Issue);
            this.listView1.Columns.Add(this.Wrd_RRNo);
            this.listView1.Columns.Add(this.Wrd_RRSeqNo);
            this.listView1.Columns.Add(this.Wrd_RRLotSeqNo);
            this.listView1.Columns.Add(this.Wrd_RRLoc);
            this.listView1.Columns.Add(this.StockType);
            this.listView1.Columns.Add(this.IssueStatus);
            this.listView1.Columns.Add(this.WrhStatus);
            this.listView1.Columns.Add(this.WrdStatus);
            this.listView1.Columns.Add(this.EXT_RRAvailable);
            this.listView1.Columns.Add(this.EXT_UploadStatus);
            this.listView1.Columns.Add(this.EXT_Remark);
            this.listView1.Columns.Add(this.EXTBarcodeQty);
            this.listView1.Columns.Add(this.EXTBarcodePrintDate);
            this.listView1.Columns.Add(this.EXTLocator);
            this.listView1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.listView1.FullRowSelect = true;
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(6, 144);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(230, 108);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.TabIndex = 391;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // StockNames
            // 
            this.StockNames.Text = "  STOCK NAME";
            this.StockNames.Width = 151;
            // 
            // WrdSeqNo
            // 
            this.WrdSeqNo.Text = "SEQ";
            this.WrdSeqNo.Width = 0;
            // 
            // WrdSplitNo
            // 
            this.WrdSplitNo.Text = "SPLITNO";
            this.WrdSplitNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.WrdSplitNo.Width = 0;
            // 
            // Wrd_LastSplitSeqNo
            // 
            this.Wrd_LastSplitSeqNo.Text = "LASTSPLIT";
            this.Wrd_LastSplitSeqNo.Width = 0;
            // 
            // StockCode
            // 
            this.StockCode.Text = "SCode";
            this.StockCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.StockCode.Width = 0;
            // 
            // Spec
            // 
            this.Spec.Text = "SPEC";
            this.Spec.Width = 0;
            // 
            // SIQty
            // 
            this.SIQty.Text = "SI";
            this.SIQty.Width = 0;
            // 
            // RequestQty
            // 
            this.RequestQty.Text = " REQ";
            this.RequestQty.Width = 0;
            // 
            // ReservedQty
            // 
            this.ReservedQty.Text = "RESQTY";
            this.ReservedQty.Width = 0;
            // 
            // Issue
            // 
            this.Issue.Text = " ISSUE";
            this.Issue.Width = 70;
            // 
            // Wrd_RRNo
            // 
            this.Wrd_RRNo.Text = "RRNO";
            this.Wrd_RRNo.Width = 0;
            // 
            // Wrd_RRSeqNo
            // 
            this.Wrd_RRSeqNo.Text = "RRSEQ";
            this.Wrd_RRSeqNo.Width = 0;
            // 
            // Wrd_RRLotSeqNo
            // 
            this.Wrd_RRLotSeqNo.Text = "RRLOT";
            this.Wrd_RRLotSeqNo.Width = 0;
            // 
            // Wrd_RRLoc
            // 
            this.Wrd_RRLoc.Text = "RRLOC";
            this.Wrd_RRLoc.Width = 0;
            // 
            // StockType
            // 
            this.StockType.Text = "TYPE";
            this.StockType.Width = 0;
            // 
            // IssueStatus
            // 
            this.IssueStatus.Text = "ISSUESTAT";
            this.IssueStatus.Width = 0;
            // 
            // WrhStatus
            // 
            this.WrhStatus.Text = "WHSTAT";
            this.WrhStatus.Width = 0;
            // 
            // WrdStatus
            // 
            this.WrdStatus.Text = "WDSTAT";
            this.WrdStatus.Width = 0;
            // 
            // EXT_RRAvailable
            // 
            this.EXT_RRAvailable.Text = "Ext_RRAvailable";
            this.EXT_RRAvailable.Width = 0;
            // 
            // EXT_UploadStatus
            // 
            this.EXT_UploadStatus.Text = "Ext_UploadStatus";
            this.EXT_UploadStatus.Width = 0;
            // 
            // EXT_Remark
            // 
            this.EXT_Remark.Text = "EXT_Remark";
            this.EXT_Remark.Width = 0;
            // 
            // EXTBarcodeQty
            // 
            this.EXTBarcodeQty.Text = "EXTBarcodeQty";
            this.EXTBarcodeQty.Width = 0;
            // 
            // EXTBarcodePrintDate
            // 
            this.EXTBarcodePrintDate.Text = "EXTBarcodePrintDate";
            this.EXTBarcodePrintDate.Width = 2;
            // 
            // EXTLocator
            // 
            this.EXTLocator.Text = "EXTLocator";
            this.EXTLocator.Width = 0;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(7, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 22);
            this.label2.Text = "Transfer No:";
            // 
            // AvailableQty
            // 
            this.AvailableQty.BackColor = System.Drawing.Color.White;
            this.AvailableQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular);
            this.AvailableQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.AvailableQty.Location = new System.Drawing.Point(80, 118);
            this.AvailableQty.Multiline = true;
            this.AvailableQty.Name = "AvailableQty";
            this.AvailableQty.Size = new System.Drawing.Size(150, 25);
            this.AvailableQty.TabIndex = 397;
            this.AvailableQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(7, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 18);
            this.label5.Text = "Available";
            // 
            // Progress
            // 
            this.Progress.Location = new System.Drawing.Point(7, 267);
            this.Progress.Name = "Progress";
            this.Progress.Size = new System.Drawing.Size(229, 10);
            this.Progress.Visible = false;
            // 
            // lblRemark
            // 
            this.lblRemark.BackColor = System.Drawing.Color.White;
            this.lblRemark.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblRemark.ForeColor = System.Drawing.Color.Teal;
            this.lblRemark.Location = new System.Drawing.Point(6, 252);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(230, 28);
            this.lblRemark.Text = "Press [ Enter Key ] to issue scanned items.";
            // 
            // MaterialTransferWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(243, 323);
            this.Controls.Add(this.Progress);
            this.Controls.Add(this.lblRemark);
            this.Controls.Add(this.AvailableQty);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblLocator);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.RRNo);
            this.Controls.Add(this.txttransqty);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TransferNo);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MaterialTransferWindow";
            this.Text = "Stock Movement";
            this.Load += new System.EventHandler(this.MaterialTransferWindow_Load);
            this.Controls.SetChildIndex(this.TransferNo, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txttransqty, 0);
            this.Controls.SetChildIndex(this.RRNo, 0);
            this.Controls.SetChildIndex(this.listView1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.lblLocator, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.AvailableQty, 0);
            this.Controls.SetChildIndex(this.lblRemark, 0);
            this.Controls.SetChildIndex(this.Progress, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox TransferNo;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox RRNo;
        private System.Windows.Forms.TextBox txttransqty;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblLocator;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader StockNames;
        private System.Windows.Forms.ColumnHeader WrdSeqNo;
        private System.Windows.Forms.ColumnHeader WrdSplitNo;
        private System.Windows.Forms.ColumnHeader Wrd_LastSplitSeqNo;
        private System.Windows.Forms.ColumnHeader StockCode;
        private System.Windows.Forms.ColumnHeader Spec;
        private System.Windows.Forms.ColumnHeader SIQty;
        private System.Windows.Forms.ColumnHeader RequestQty;
        private System.Windows.Forms.ColumnHeader ReservedQty;
        private System.Windows.Forms.ColumnHeader Issue;
        private System.Windows.Forms.ColumnHeader Wrd_RRNo;
        private System.Windows.Forms.ColumnHeader Wrd_RRSeqNo;
        private System.Windows.Forms.ColumnHeader Wrd_RRLotSeqNo;
        private System.Windows.Forms.ColumnHeader Wrd_RRLoc;
        private System.Windows.Forms.ColumnHeader StockType;
        private System.Windows.Forms.ColumnHeader IssueStatus;
        private System.Windows.Forms.ColumnHeader WrhStatus;
        private System.Windows.Forms.ColumnHeader WrdStatus;
        private System.Windows.Forms.ColumnHeader EXT_RRAvailable;
        private System.Windows.Forms.ColumnHeader EXT_UploadStatus;
        private System.Windows.Forms.ColumnHeader EXT_Remark;
        private System.Windows.Forms.ColumnHeader EXTBarcodeQty;
        private System.Windows.Forms.ColumnHeader EXTBarcodePrintDate;
        private System.Windows.Forms.ColumnHeader EXTLocator;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox AvailableQty;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ProgressBar Progress;
        private System.Windows.Forms.Label lblRemark;
    }
}