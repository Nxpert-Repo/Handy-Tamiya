namespace Handy
{
    partial class InventoryProcessingWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventoryProcessingWindow));
            this.txtStockCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ActualQty = new System.Windows.Forms.TextBox();
            this.RRNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.timerHideMsg = new System.Windows.Forms.Timer();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPending = new System.Windows.Forms.Label();
            this.lblPendingBack = new System.Windows.Forms.Label();
            this.LocLabel = new System.Windows.Forms.Label();
            this.pcbSaved = new System.Windows.Forms.PictureBox();
            this.lblSaved = new System.Windows.Forms.Label();
            this.txtSpecs = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStockName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblGeneratedWarehouse = new System.Windows.Forms.Label();
            this.lblBalanceQty = new System.Windows.Forms.Label();
            this.lblSystem = new System.Windows.Forms.Label();
            this.txtLocatorDesc = new System.Windows.Forms.TextBox();
            this.LocatorCode = new System.Windows.Forms.TextBox();
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
            // txtStockCode
            // 
            this.txtStockCode.BackColor = System.Drawing.Color.White;
            this.txtStockCode.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.txtStockCode.ForeColor = System.Drawing.Color.Black;
            this.txtStockCode.Location = new System.Drawing.Point(77, 139);
            this.txtStockCode.Multiline = true;
            this.txtStockCode.Name = "txtStockCode";
            this.txtStockCode.Size = new System.Drawing.Size(159, 23);
            this.txtStockCode.TabIndex = 325;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(8, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.Text = "Stock Code";
            // 
            // ActualQty
            // 
            this.ActualQty.BackColor = System.Drawing.Color.White;
            this.ActualQty.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular);
            this.ActualQty.ForeColor = System.Drawing.Color.Black;
            this.ActualQty.Location = new System.Drawing.Point(171, 250);
            this.ActualQty.Multiline = true;
            this.ActualQty.Name = "ActualQty";
            this.ActualQty.Size = new System.Drawing.Size(65, 25);
            this.ActualQty.TabIndex = 320;
            this.ActualQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ActualQty.TextChanged += new System.EventHandler(this.ActualQty_TextChanged);
            this.ActualQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ActualQty_KeyPress);
            // 
            // RRNo
            // 
            this.RRNo.BackColor = System.Drawing.Color.White;
            this.RRNo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.RRNo.ForeColor = System.Drawing.Color.Black;
            this.RRNo.Location = new System.Drawing.Point(77, 115);
            this.RRNo.Multiline = true;
            this.RRNo.Name = "RRNo";
            this.RRNo.Size = new System.Drawing.Size(159, 23);
            this.RRNo.TabIndex = 318;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(108, 255);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 20);
            this.label4.Text = "Actual Qty";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(8, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 20);
            this.label2.Text = "RR Number";
            this.imageList1.Images.Clear();
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource"))));
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource1"))));
            // 
            // timerHideMsg
            // 
            this.timerHideMsg.Interval = 4000;
            this.timerHideMsg.Tick += new System.EventHandler(this.timerHideMsg_Tick);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label5.ForeColor = System.Drawing.Color.Teal;
            this.label5.Location = new System.Drawing.Point(167, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.Text = "Pending";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblPending
            // 
            this.lblPending.BackColor = System.Drawing.Color.White;
            this.lblPending.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.lblPending.ForeColor = System.Drawing.Color.Black;
            this.lblPending.Location = new System.Drawing.Point(174, 38);
            this.lblPending.Name = "lblPending";
            this.lblPending.Size = new System.Drawing.Size(56, 34);
            this.lblPending.Text = "005";
            this.lblPending.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblPendingBack
            // 
            this.lblPendingBack.BackColor = System.Drawing.Color.Teal;
            this.lblPendingBack.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.lblPendingBack.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblPendingBack.Location = new System.Drawing.Point(172, 37);
            this.lblPendingBack.Name = "lblPendingBack";
            this.lblPendingBack.Size = new System.Drawing.Size(60, 38);
            this.lblPendingBack.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LocLabel
            // 
            this.LocLabel.BackColor = System.Drawing.Color.White;
            this.LocLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.LocLabel.ForeColor = System.Drawing.Color.Black;
            this.LocLabel.Location = new System.Drawing.Point(8, 93);
            this.LocLabel.Name = "LocLabel";
            this.LocLabel.Size = new System.Drawing.Size(90, 20);
            this.LocLabel.Text = "Locator Code";
            // 
            // pcbSaved
            // 
            this.pcbSaved.Image = ((System.Drawing.Image)(resources.GetObject("pcbSaved.Image")));
            this.pcbSaved.Location = new System.Drawing.Point(84, 189);
            this.pcbSaved.Name = "pcbSaved";
            this.pcbSaved.Size = new System.Drawing.Size(44, 29);
            this.pcbSaved.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbSaved.Visible = false;
            // 
            // lblSaved
            // 
            this.lblSaved.BackColor = System.Drawing.Color.White;
            this.lblSaved.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold);
            this.lblSaved.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblSaved.Location = new System.Drawing.Point(128, 191);
            this.lblSaved.Name = "lblSaved";
            this.lblSaved.Size = new System.Drawing.Size(105, 27);
            this.lblSaved.Text = "Item Scanned";
            this.lblSaved.Visible = false;
            // 
            // txtSpecs
            // 
            this.txtSpecs.BackColor = System.Drawing.Color.White;
            this.txtSpecs.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular);
            this.txtSpecs.ForeColor = System.Drawing.Color.Black;
            this.txtSpecs.Location = new System.Drawing.Point(77, 185);
            this.txtSpecs.Multiline = true;
            this.txtSpecs.Name = "txtSpecs";
            this.txtSpecs.Size = new System.Drawing.Size(159, 55);
            this.txtSpecs.TabIndex = 364;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(9, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 20);
            this.label3.Text = "Specification";
            // 
            // txtStockName
            // 
            this.txtStockName.BackColor = System.Drawing.Color.White;
            this.txtStockName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.txtStockName.ForeColor = System.Drawing.Color.Black;
            this.txtStockName.Location = new System.Drawing.Point(77, 163);
            this.txtStockName.Multiline = true;
            this.txtStockName.Name = "txtStockName";
            this.txtStockName.Size = new System.Drawing.Size(159, 23);
            this.txtStockName.TabIndex = 363;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(8, 164);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 20);
            this.label10.Text = "Stock Name";
            // 
            // lblGeneratedWarehouse
            // 
            this.lblGeneratedWarehouse.BackColor = System.Drawing.Color.Teal;
            this.lblGeneratedWarehouse.Font = new System.Drawing.Font("Tahoma", 11.5F, System.Drawing.FontStyle.Bold);
            this.lblGeneratedWarehouse.ForeColor = System.Drawing.Color.White;
            this.lblGeneratedWarehouse.Location = new System.Drawing.Point(6, 39);
            this.lblGeneratedWarehouse.Name = "lblGeneratedWarehouse";
            this.lblGeneratedWarehouse.Size = new System.Drawing.Size(163, 21);
            this.lblGeneratedWarehouse.Text = "Default Warehouse";
            this.lblGeneratedWarehouse.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblBalanceQty
            // 
            this.lblBalanceQty.BackColor = System.Drawing.Color.Yellow;
            this.lblBalanceQty.ForeColor = System.Drawing.Color.Black;
            this.lblBalanceQty.Location = new System.Drawing.Point(11, 251);
            this.lblBalanceQty.Name = "lblBalanceQty";
            this.lblBalanceQty.Size = new System.Drawing.Size(92, 22);
            this.lblBalanceQty.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblBalanceQty.Visible = false;
            // 
            // lblSystem
            // 
            this.lblSystem.BackColor = System.Drawing.Color.White;
            this.lblSystem.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblSystem.ForeColor = System.Drawing.Color.Black;
            this.lblSystem.Location = new System.Drawing.Point(9, 237);
            this.lblSystem.Name = "lblSystem";
            this.lblSystem.Size = new System.Drawing.Size(61, 20);
            this.lblSystem.Text = "System:";
            // 
            // txtLocatorDesc
            // 
            this.txtLocatorDesc.BackColor = System.Drawing.Color.White;
            this.txtLocatorDesc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.txtLocatorDesc.ForeColor = System.Drawing.Color.Black;
            this.txtLocatorDesc.Location = new System.Drawing.Point(131, 92);
            this.txtLocatorDesc.Multiline = true;
            this.txtLocatorDesc.Name = "txtLocatorDesc";
            this.txtLocatorDesc.Size = new System.Drawing.Size(105, 23);
            this.txtLocatorDesc.TabIndex = 376;
            // 
            // LocatorCode
            // 
            this.LocatorCode.BackColor = System.Drawing.Color.White;
            this.LocatorCode.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.LocatorCode.ForeColor = System.Drawing.Color.Black;
            this.LocatorCode.Location = new System.Drawing.Point(77, 92);
            this.LocatorCode.Multiline = true;
            this.LocatorCode.Name = "LocatorCode";
            this.LocatorCode.Size = new System.Drawing.Size(58, 23);
            this.LocatorCode.TabIndex = 375;
            // 
            // InventoryProcessingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(248, 330);
            this.Controls.Add(this.txtLocatorDesc);
            this.Controls.Add(this.LocatorCode);
            this.Controls.Add(this.lblBalanceQty);
            this.Controls.Add(this.lblSaved);
            this.Controls.Add(this.pcbSaved);
            this.Controls.Add(this.lblPending);
            this.Controls.Add(this.lblPendingBack);
            this.Controls.Add(this.txtSpecs);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtStockName);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtStockCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ActualQty);
            this.Controls.Add(this.RRNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LocLabel);
            this.Controls.Add(this.lblGeneratedWarehouse);
            this.Controls.Add(this.lblSystem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimizeBox = false;
            this.Name = "InventoryProcessingWindow";
            this.Text = "INVENTORY";
            this.Load += new System.EventHandler(this.InventoryProcessingWindow_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.InventoryProcessingWindow_Closing);
            this.Controls.SetChildIndex(this.lblSystem, 0);
            this.Controls.SetChildIndex(this.lblGeneratedWarehouse, 0);
            this.Controls.SetChildIndex(this.LocLabel, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.RRNo, 0);
            this.Controls.SetChildIndex(this.ActualQty, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtStockCode, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.txtStockName, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtSpecs, 0);
            this.Controls.SetChildIndex(this.lblPendingBack, 0);
            this.Controls.SetChildIndex(this.lblPending, 0);
            this.Controls.SetChildIndex(this.pcbSaved, 0);
            this.Controls.SetChildIndex(this.lblSaved, 0);
            this.Controls.SetChildIndex(this.lblBalanceQty, 0);
            this.Controls.SetChildIndex(this.LocatorCode, 0);
            this.Controls.SetChildIndex(this.txtLocatorDesc, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtStockCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ActualQty;
        private System.Windows.Forms.TextBox RRNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Timer timerHideMsg;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPending;
        private System.Windows.Forms.Label lblPendingBack;
        private System.Windows.Forms.Label LocLabel;
        private System.Windows.Forms.PictureBox pcbSaved;
        private System.Windows.Forms.Label lblSaved;
        private System.Windows.Forms.TextBox txtSpecs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStockName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblGeneratedWarehouse;
        private System.Windows.Forms.Label lblBalanceQty;
        private System.Windows.Forms.Label lblSystem;
        private System.Windows.Forms.TextBox txtLocatorDesc;
        private System.Windows.Forms.TextBox LocatorCode;

    }
}