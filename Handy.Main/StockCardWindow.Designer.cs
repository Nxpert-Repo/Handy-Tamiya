namespace Handy
{
    partial class StockCardWindow
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem();
            this.StocksListView = new System.Windows.Forms.ListView();
            this.RRNumber = new System.Windows.Forms.ColumnHeader();
            this.Location = new System.Windows.Forms.ColumnHeader();
            this.qty = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbStockCode = new System.Windows.Forms.ComboBox();
            this.cmbStockType = new System.Windows.Forms.ComboBox();
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
            // StocksListView
            // 
            this.StocksListView.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.StocksListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.StocksListView.Columns.Add(this.RRNumber);
            this.StocksListView.Columns.Add(this.Location);
            this.StocksListView.Columns.Add(this.qty);
            this.StocksListView.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.StocksListView.FullRowSelect = true;
            listViewItem1.Text = "";
            this.StocksListView.Items.Add(listViewItem1);
            this.StocksListView.Location = new System.Drawing.Point(9, 100);
            this.StocksListView.Name = "StocksListView";
            this.StocksListView.Size = new System.Drawing.Size(227, 178);
            this.StocksListView.TabIndex = 334;
            this.StocksListView.View = System.Windows.Forms.View.Details;
            // 
            // RRNumber
            // 
            this.RRNumber.Text = "RR Number";
            this.RRNumber.Width = 155;
            // 
            // Location
            // 
            this.Location.Text = "Location";
            this.Location.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Location.Width = 75;
            // 
            // qty
            // 
            this.qty.Text = "QTY";
            this.qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.qty.Width = 63;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.Text = "Stock Code";
            // 
            // lblBal
            // 
            this.lblBal.BackColor = System.Drawing.Color.Gray;
            this.lblBal.Location = new System.Drawing.Point(180, 40);
            this.lblBal.Name = "lblBal";
            this.lblBal.Size = new System.Drawing.Size(55, 20);
            this.lblBal.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.Text = "Stock Type";
            // 
            // cmbStockCode
            // 
            this.cmbStockCode.Location = new System.Drawing.Point(77, 67);
            this.cmbStockCode.Name = "cmbStockCode";
            this.cmbStockCode.Size = new System.Drawing.Size(160, 23);
            this.cmbStockCode.TabIndex = 345;
            this.cmbStockCode.SelectedValueChanged += new System.EventHandler(this.cmbStockCode_SelectedValueChanged);
            // 
            // cmbStockType
            // 
            this.cmbStockType.Location = new System.Drawing.Point(77, 40);
            this.cmbStockType.Name = "cmbStockType";
            this.cmbStockType.Size = new System.Drawing.Size(102, 23);
            this.cmbStockType.TabIndex = 351;
            this.cmbStockType.SelectedValueChanged += new System.EventHandler(this.cmbStockType_SelectedValueChanged_1);
            // 
            // StockCardWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(242, 317);
            this.Controls.Add(this.cmbStockType);
            this.Controls.Add(this.cmbStockCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblBal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StocksListView);
            this.Name = "StockCardWindow";
            this.Controls.SetChildIndex(this.StocksListView, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lblBal, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.cmbStockCode, 0);
            this.Controls.SetChildIndex(this.cmbStockType, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView StocksListView;
        private System.Windows.Forms.ColumnHeader RRNumber;
        private System.Windows.Forms.ColumnHeader Location;
        private System.Windows.Forms.ColumnHeader qty;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbStockCode;
        private System.Windows.Forms.ComboBox cmbStockType;

    }
}
