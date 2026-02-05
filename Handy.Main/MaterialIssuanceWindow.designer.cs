namespace Handy
{
    partial class MaterialIssuanceWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaterialIssuanceWindow));
            this.label7 = new System.Windows.Forms.Label();
            this.IssuanceNo = new System.Windows.Forms.TextBox();
            this.IssuanceType = new System.Windows.Forms.TextBox();
            this.LocLabel = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.LotCode = new System.Windows.Forms.ColumnHeader();
            this.Locator = new System.Windows.Forms.ColumnHeader();
            this.Quantity = new System.Windows.Forms.ColumnHeader();
            this.IssuanceNum = new System.Windows.Forms.ColumnHeader();
            this.Type = new System.Windows.Forms.ColumnHeader();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.label6 = new System.Windows.Forms.Label();
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
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(5, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 19);
            this.label7.Text = "Control No";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // IssuanceNo
            // 
            this.IssuanceNo.BackColor = System.Drawing.Color.White;
            this.IssuanceNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
            this.IssuanceNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.IssuanceNo.Location = new System.Drawing.Point(80, 43);
            this.IssuanceNo.Name = "IssuanceNo";
            this.IssuanceNo.Size = new System.Drawing.Size(149, 25);
            this.IssuanceNo.TabIndex = 319;
            // 
            // IssuanceType
            // 
            this.IssuanceType.BackColor = System.Drawing.Color.White;
            this.IssuanceType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
            this.IssuanceType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.IssuanceType.Location = new System.Drawing.Point(80, 72);
            this.IssuanceType.Name = "IssuanceType";
            this.IssuanceType.Size = new System.Drawing.Size(149, 25);
            this.IssuanceType.TabIndex = 309;
            // 
            // LocLabel
            // 
            this.LocLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
            this.LocLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LocLabel.Location = new System.Drawing.Point(6, 77);
            this.LocLabel.Name = "LocLabel";
            this.LocLabel.Size = new System.Drawing.Size(72, 19);
            this.LocLabel.Text = "Type";
            this.LocLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.listView1.Columns.Add(this.LotCode);
            this.listView1.Columns.Add(this.Locator);
            this.listView1.Columns.Add(this.Quantity);
            this.listView1.Columns.Add(this.IssuanceNum);
            this.listView1.Columns.Add(this.Type);
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular);
            this.listView1.FullRowSelect = true;
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(4, 104);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(232, 140);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.TabIndex = 332;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // LotCode
            // 
            this.LotCode.Text = "Lot Code";
            this.LotCode.Width = 160;
            // 
            // Locator
            // 
            this.Locator.Text = "Locator";
            this.Locator.Width = 70;
            // 
            // Quantity
            // 
            this.Quantity.Text = "QTY";
            this.Quantity.Width = 65;
            // 
            // IssuanceNum
            // 
            this.IssuanceNum.Text = "IssuanceNum";
            this.IssuanceNum.Width = 0;
            // 
            // Type
            // 
            this.Type.Text = "Type";
            this.Type.Width = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageSize = new System.Drawing.Size(40, 20);
            this.imageList1.Images.Clear();
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource"))));
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource1"))));
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource2"))));
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(10, 248);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(223, 35);
            this.label6.Text = "Pressing [Enter] will display list.";
            // 
            // MaterialIssuanceWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(240, 325);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.IssuanceNo);
            this.Controls.Add(this.IssuanceType);
            this.Controls.Add(this.LocLabel);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(205)))), ((int)(((byte)(210)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MaterialIssuanceWindow";
            this.Text = "Material Issuance";
            this.Load += new System.EventHandler(this.MaterialIssuanceWindow_Load);
            this.Controls.SetChildIndex(this.LocLabel, 0);
            this.Controls.SetChildIndex(this.IssuanceType, 0);
            this.Controls.SetChildIndex(this.IssuanceNo, 0);
            this.Controls.SetChildIndex(this.listView1, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox IssuanceNo;
        private System.Windows.Forms.TextBox IssuanceType;
        private System.Windows.Forms.Label LocLabel;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader LotCode;
        private System.Windows.Forms.ColumnHeader Locator;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ColumnHeader Quantity;
        private System.Windows.Forms.ColumnHeader IssuanceNum;
        private System.Windows.Forms.ColumnHeader Type;
    }
}