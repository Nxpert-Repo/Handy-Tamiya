namespace Handy
{
    partial class DeliveryPreparationWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeliveryPreparationWindow));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.label1 = new System.Windows.Forms.Label();
            this.RRNo = new System.Windows.Forms.TextBox();
            this.LocatorQty = new System.Windows.Forms.TextBox();
            this.IssuedQty = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.WRISNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.AvailableQty = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.RequestedQty = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtReserved = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
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
            //this.imageList1 = new System.Windows.Forms.ImageList();
            this.lblSpecs = new System.Windows.Forms.Label();
            this.lblLocator = new System.Windows.Forms.Label();
            this.lblRemark = new System.Windows.Forms.Label();
            this.Progress = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
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
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(2, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 19);
            this.label1.Text = "RR No";
            // 
            // RRNo
            // 
            this.RRNo.BackColor = System.Drawing.Color.White;
            this.RRNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular);
            this.RRNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.RRNo.Location = new System.Drawing.Point(56, 90);
            this.RRNo.Multiline = true;
            this.RRNo.Name = "RRNo";
            this.RRNo.Size = new System.Drawing.Size(182, 24);
            this.RRNo.TabIndex = 320;
            // 
            // LocatorQty
            // 
            this.LocatorQty.BackColor = System.Drawing.Color.White;
            this.LocatorQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular);
            this.LocatorQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LocatorQty.Location = new System.Drawing.Point(177, 114);
            this.LocatorQty.Multiline = true;
            this.LocatorQty.Name = "LocatorQty";
            this.LocatorQty.Size = new System.Drawing.Size(61, 25);
            this.LocatorQty.TabIndex = 318;
            this.LocatorQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // IssuedQty
            // 
            this.IssuedQty.BackColor = System.Drawing.Color.White;
            this.IssuedQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.IssuedQty.ForeColor = System.Drawing.Color.Black;
            this.IssuedQty.Location = new System.Drawing.Point(176, 64);
            this.IssuedQty.Multiline = true;
            this.IssuedQty.Name = "IssuedQty";
            this.IssuedQty.Size = new System.Drawing.Size(61, 27);
            this.IssuedQty.TabIndex = 316;
            this.IssuedQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.IssuedQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IssuedQty_KeyPress);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(124, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 25);
            this.label7.Text = "  Issued";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(134, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 21);
            this.label5.Text = "Loc Qty";
            // 
            // WRISNo
            // 
            this.WRISNo.BackColor = System.Drawing.Color.White;
            this.WRISNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular);
            this.WRISNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.WRISNo.Location = new System.Drawing.Point(56, 42);
            this.WRISNo.Multiline = true;
            this.WRISNo.Name = "WRISNo";
            this.WRISNo.Size = new System.Drawing.Size(75, 24);
            this.WRISNo.TabIndex = 344;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(2, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 15);
            this.label2.Text = "WRIS No";
            // 
            // AvailableQty
            // 
            this.AvailableQty.BackColor = System.Drawing.Color.White;
            this.AvailableQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular);
            this.AvailableQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.AvailableQty.Location = new System.Drawing.Point(56, 114);
            this.AvailableQty.Multiline = true;
            this.AvailableQty.Name = "AvailableQty";
            this.AvailableQty.Size = new System.Drawing.Size(74, 25);
            this.AvailableQty.TabIndex = 347;
            this.AvailableQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(2, 116);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 20);
            this.label13.Text = "Available";
            // 
            // RequestedQty
            // 
            this.RequestedQty.BackColor = System.Drawing.Color.White;
            this.RequestedQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.RequestedQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.RequestedQty.Location = new System.Drawing.Point(176, 41);
            this.RequestedQty.Multiline = true;
            this.RequestedQty.Name = "RequestedQty";
            this.RequestedQty.Size = new System.Drawing.Size(61, 25);
            this.RequestedQty.TabIndex = 351;
            this.RequestedQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.White;
            this.label14.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(130, 41);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 25);
            this.label14.Text = "Request";
            // 
            // txtReserved
            // 
            this.txtReserved.BackColor = System.Drawing.Color.White;
            this.txtReserved.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular);
            this.txtReserved.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtReserved.Location = new System.Drawing.Point(56, 64);
            this.txtReserved.Multiline = true;
            this.txtReserved.Name = "txtReserved";
            this.txtReserved.Size = new System.Drawing.Size(75, 27);
            this.txtReserved.TabIndex = 364;
            this.txtReserved.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(2, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 18);
            this.label4.Text = "Reserved";
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
            //this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(3, 139);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(235, 123);
            //this.listView1.SmallImageList = this.imageList1;
            this.listView1.TabIndex = 388;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // StockNames
            // 
            this.StockNames.Text = "  STOCK NAME";
            this.StockNames.Width = 160;
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
            // imageList1
            // 
            //this.imageList1.ImageSize = new System.Drawing.Size(28, 17);
            //this.imageList1.Images.Clear();
            //this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource"))));
            //this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource1"))));
            //this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource2"))));
            // 
            // lblSpecs
            // 
            this.lblSpecs.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblSpecs.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblSpecs.ForeColor = System.Drawing.Color.Blue;
            this.lblSpecs.Location = new System.Drawing.Point(103, 159);
            this.lblSpecs.Name = "lblSpecs";
            this.lblSpecs.Size = new System.Drawing.Size(134, 102);
            this.lblSpecs.Text = "T[12]W[10]L[290]H[56.9]";
            this.lblSpecs.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblSpecs.Visible = false;
            // 
            // lblLocator
            // 
            this.lblLocator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblLocator.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblLocator.ForeColor = System.Drawing.Color.White;
            this.lblLocator.Location = new System.Drawing.Point(144, 140);
            this.lblLocator.Name = "lblLocator";
            this.lblLocator.Size = new System.Drawing.Size(94, 19);
            this.lblLocator.Text = "000000";
            this.lblLocator.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblLocator.Visible = false;
            // 
            // lblRemark
            // 
            this.lblRemark.BackColor = System.Drawing.Color.White;
            this.lblRemark.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblRemark.ForeColor = System.Drawing.Color.Teal;
            this.lblRemark.Location = new System.Drawing.Point(2, 261);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(237, 28);
            this.lblRemark.Text = "Press [ Enter Key ] to issue scanned items.";
            // 
            // Progress
            // 
            this.Progress.Location = new System.Drawing.Point(3, 276);
            this.Progress.Name = "Progress";
            this.Progress.Size = new System.Drawing.Size(236, 10);
            this.Progress.Visible = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Teal;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(4, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(235, 19);
            this.label3.Text = " Stock Name                         | Issue Qty";
            // 
            // IssuanceWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(258, 328);
            this.Controls.Add(this.RRNo);
            this.Controls.Add(this.IssuedQty);
            this.Controls.Add(this.lblLocator);
            this.Controls.Add(this.lblSpecs);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Progress);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.lblRemark);
            this.Controls.Add(this.txtReserved);
            this.Controls.Add(this.RequestedQty);
            this.Controls.Add(this.AvailableQty);
            this.Controls.Add(this.WRISNo);
            this.Controls.Add(this.LocatorQty);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IssuanceWindow";
            this.Text = "IssuanceWindow";
            this.Load += new System.EventHandler(this.DeliveryPreparationWindow_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.DeliveryPreparationWindow_Closing);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.LocatorQty, 0);
            this.Controls.SetChildIndex(this.WRISNo, 0);
            this.Controls.SetChildIndex(this.AvailableQty, 0);
            this.Controls.SetChildIndex(this.RequestedQty, 0);
            this.Controls.SetChildIndex(this.txtReserved, 0);
            this.Controls.SetChildIndex(this.lblRemark, 0);
            this.Controls.SetChildIndex(this.listView1, 0);
            this.Controls.SetChildIndex(this.Progress, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.lblSpecs, 0);
            this.Controls.SetChildIndex(this.lblLocator, 0);
            this.Controls.SetChildIndex(this.IssuedQty, 0);
            this.Controls.SetChildIndex(this.RRNo, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox RRNo;
        private System.Windows.Forms.TextBox LocatorQty;
        private System.Windows.Forms.TextBox IssuedQty;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox WRISNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox AvailableQty;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox RequestedQty;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtReserved;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader WrdSeqNo;
        private System.Windows.Forms.ColumnHeader WrdSplitNo;
        private System.Windows.Forms.ColumnHeader StockCode;
        private System.Windows.Forms.ColumnHeader StockNames;
        private System.Windows.Forms.ColumnHeader Spec;
        private System.Windows.Forms.ColumnHeader SIQty;
        private System.Windows.Forms.ColumnHeader RequestQty;
        private System.Windows.Forms.ColumnHeader ReservedQty;
        private System.Windows.Forms.ColumnHeader Wrd_RRNo;
        private System.Windows.Forms.ColumnHeader Wrd_RRSeqNo;
        private System.Windows.Forms.ColumnHeader Wrd_RRLotSeqNo;
        private System.Windows.Forms.ColumnHeader Wrd_RRLoc;
        private System.Windows.Forms.ColumnHeader StockType;
        private System.Windows.Forms.ColumnHeader IssueStatus;
        private System.Windows.Forms.ColumnHeader WrhStatus;
        private System.Windows.Forms.ColumnHeader WrdStatus;
        private System.Windows.Forms.ColumnHeader Wrd_LastSplitSeqNo;
        private System.Windows.Forms.ColumnHeader Issue;
        //private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ColumnHeader EXT_RRAvailable;
        private System.Windows.Forms.ColumnHeader EXT_UploadStatus;
        private System.Windows.Forms.ColumnHeader EXT_Remark;
        private System.Windows.Forms.ColumnHeader EXTBarcodePrintDate;
        private System.Windows.Forms.ColumnHeader EXTBarcodeQty;
        private System.Windows.Forms.Label lblSpecs;
        private System.Windows.Forms.Label lblLocator;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.ColumnHeader EXTLocator;
        public System.Windows.Forms.ProgressBar Progress;
        private System.Windows.Forms.Label label3;
    }
}