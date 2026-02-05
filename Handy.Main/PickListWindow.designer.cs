namespace Handy
{
    partial class PickListWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PickListWindow));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.lblSpecs = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Stockname = new System.Windows.Forms.ColumnHeader();
            this.RequestedQty = new System.Windows.Forms.ColumnHeader();
            this.ReservedQty = new System.Windows.Forms.ColumnHeader();
            this.txtReserved = new System.Windows.Forms.TextBox();
            this.RequestedQtyTxt = new System.Windows.Forms.TextBox();
            this.WRISNo = new System.Windows.Forms.TextBox();
            this.RRNoTxt = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SplitSeqNo = new System.Windows.Forms.TextBox();
            this.SeqNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
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
            // lblSpecs
            // 
            this.lblSpecs.BackColor = System.Drawing.Color.White;
            this.lblSpecs.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblSpecs.ForeColor = System.Drawing.Color.Teal;
            this.lblSpecs.Location = new System.Drawing.Point(4, 115);
            this.lblSpecs.Name = "lblSpecs";
            this.lblSpecs.Size = new System.Drawing.Size(232, 100);
            this.lblSpecs.Text = "Specs : ";
            this.imageList1.Images.Clear();
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource"))));
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource1"))));
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource2"))));
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource3"))));
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.listView1.Columns.Add(this.Stockname);
            this.listView1.Columns.Add(this.RequestedQty);
            this.listView1.Columns.Add(this.ReservedQty);
            this.listView1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.listView1.FullRowSelect = true;
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(3, 133);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(233, 150);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.TabIndex = 0;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // Stockname
            // 
            this.Stockname.Text = "Stock Name";
            this.Stockname.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.Stockname.Width = 100;
            // 
            // RequestedQty
            // 
            this.RequestedQty.Text = " Request";
            this.RequestedQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RequestedQty.Width = 60;
            // 
            // ReservedQty
            // 
            this.ReservedQty.Text = " Reserved";
            this.ReservedQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ReservedQty.Width = 70;
            // 
            // txtReserved
            // 
            this.txtReserved.BackColor = System.Drawing.Color.White;
            this.txtReserved.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular);
            this.txtReserved.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtReserved.Location = new System.Drawing.Point(176, 88);
            this.txtReserved.Multiline = true;
            this.txtReserved.Name = "txtReserved";
            this.txtReserved.ReadOnly = true;
            this.txtReserved.Size = new System.Drawing.Size(62, 25);
            this.txtReserved.TabIndex = 404;
            this.txtReserved.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // RequestedQtyTxt
            // 
            this.RequestedQtyTxt.BackColor = System.Drawing.Color.White;
            this.RequestedQtyTxt.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular);
            this.RequestedQtyTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.RequestedQtyTxt.Location = new System.Drawing.Point(61, 88);
            this.RequestedQtyTxt.Multiline = true;
            this.RequestedQtyTxt.Name = "RequestedQtyTxt";
            this.RequestedQtyTxt.ReadOnly = true;
            this.RequestedQtyTxt.Size = new System.Drawing.Size(66, 25);
            this.RequestedQtyTxt.TabIndex = 401;
            this.RequestedQtyTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // WRISNo
            // 
            this.WRISNo.BackColor = System.Drawing.Color.White;
            this.WRISNo.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular);
            this.WRISNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.WRISNo.Location = new System.Drawing.Point(61, 38);
            this.WRISNo.Multiline = true;
            this.WRISNo.Name = "WRISNo";
            this.WRISNo.ReadOnly = true;
            this.WRISNo.Size = new System.Drawing.Size(116, 25);
            this.WRISNo.TabIndex = 399;
            this.WRISNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // RRNoTxt
            // 
            this.RRNoTxt.BackColor = System.Drawing.Color.White;
            this.RRNoTxt.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular);
            this.RRNoTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.RRNoTxt.Location = new System.Drawing.Point(61, 63);
            this.RRNoTxt.Multiline = true;
            this.RRNoTxt.Name = "RRNoTxt";
            this.RRNoTxt.ReadOnly = true;
            this.RRNoTxt.Size = new System.Drawing.Size(177, 25);
            this.RRNoTxt.TabIndex = 398;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.White;
            this.label14.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(4, 91);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(90, 23);
            this.label14.Text = "Requested";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(4, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 23);
            this.label2.Text = "WRIS No";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(4, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 23);
            this.label1.Text = "RR Number";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(127, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 19);
            this.label3.Text = "Reserved";
            // 
            // SplitSeqNo
            // 
            this.SplitSeqNo.BackColor = System.Drawing.Color.White;
            this.SplitSeqNo.Font = new System.Drawing.Font("Calibri", 13F, System.Drawing.FontStyle.Regular);
            this.SplitSeqNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.SplitSeqNo.Location = new System.Drawing.Point(205, 38);
            this.SplitSeqNo.Multiline = true;
            this.SplitSeqNo.Name = "SplitSeqNo";
            this.SplitSeqNo.ReadOnly = true;
            this.SplitSeqNo.Size = new System.Drawing.Size(33, 25);
            this.SplitSeqNo.TabIndex = 418;
            this.SplitSeqNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SeqNo
            // 
            this.SeqNo.BackColor = System.Drawing.Color.White;
            this.SeqNo.Font = new System.Drawing.Font("Calibri", 13F, System.Drawing.FontStyle.Regular);
            this.SeqNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.SeqNo.Location = new System.Drawing.Point(175, 38);
            this.SeqNo.Multiline = true;
            this.SeqNo.Name = "SeqNo";
            this.SeqNo.ReadOnly = true;
            this.SeqNo.Size = new System.Drawing.Size(31, 25);
            this.SeqNo.TabIndex = 419;
            this.SeqNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Teal;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(4, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(232, 19);
            this.label4.Text = " Stock Name               | Request    | Reserved";
            this.label4.Visible = false;
            // 
            // PickListWindow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(347, 351);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.SeqNo);
            this.Controls.Add(this.SplitSeqNo);
            this.Controls.Add(this.txtReserved);
            this.Controls.Add(this.RequestedQtyTxt);
            this.Controls.Add(this.WRISNo);
            this.Controls.Add(this.RRNoTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSpecs);
            this.Controls.Add(this.label3);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "PickListWindow";
            this.Text = "PickListWindow";
            this.Load += new System.EventHandler(this.PickListWindow_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.PickListWindow_Closing);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.lblSpecs, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.RRNoTxt, 0);
            this.Controls.SetChildIndex(this.WRISNo, 0);
            this.Controls.SetChildIndex(this.RequestedQtyTxt, 0);
            this.Controls.SetChildIndex(this.txtReserved, 0);
            this.Controls.SetChildIndex(this.SplitSeqNo, 0);
            this.Controls.SetChildIndex(this.SeqNo, 0);
            this.Controls.SetChildIndex(this.listView1, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSpecs;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListView listView1;
        //private System.Windows.Forms.ColumnHeader ReqSplitSeqNo;
        //private System.Windows.Forms.ColumnHeader Stockcode;
        //private System.Windows.Forms.ColumnHeader ReqSeqNo;
        private System.Windows.Forms.ColumnHeader Stockname;
        //private System.Windows.Forms.ColumnHeader Specs;
        //private System.Windows.Forms.ColumnHeader StockTypeCode;
        //private System.Windows.Forms.ColumnHeader SiQuantity;
        private System.Windows.Forms.ColumnHeader RequestedQty;
        private System.Windows.Forms.ColumnHeader ReservedQty;
        //private System.Windows.Forms.ColumnHeader IssuedQty;
        //private System.Windows.Forms.ColumnHeader RRNo;
        //private System.Windows.Forms.ColumnHeader RRSeqNo;
        //private System.Windows.Forms.ColumnHeader RRLotSeqNo;
        //private System.Windows.Forms.ColumnHeader RRlocseqno;
        //private System.Windows.Forms.ColumnHeader IssueStatus;
        //private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.TextBox txtReserved;
        private System.Windows.Forms.TextBox RequestedQtyTxt;
        private System.Windows.Forms.TextBox WRISNo;
        private System.Windows.Forms.TextBox RRNoTxt;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SplitSeqNo;
        private System.Windows.Forms.TextBox SeqNo;
        private System.Windows.Forms.Label label4;
    }
}