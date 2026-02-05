namespace Handy
{
    partial class MaterialIssuanceWindow_Sym
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaterialIssuanceWindow_Sym));
            this.label7 = new System.Windows.Forms.Label();
            this.IssuanceNo = new System.Windows.Forms.TextBox();
            this.IssuanceType = new System.Windows.Forms.TextBox();
            this.LocLabel = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.TagNumber = new System.Windows.Forms.ColumnHeader();
            this.DRNumber = new System.Windows.Forms.ColumnHeader();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.lblGridHeader = new System.Windows.Forms.Label();
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
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(4, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 19);
            this.label7.Text = "Control No";
            // 
            // IssuanceNo
            // 
            this.IssuanceNo.BackColor = System.Drawing.Color.White;
            this.IssuanceNo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular);
            this.IssuanceNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.IssuanceNo.Location = new System.Drawing.Point(80, 43);
            this.IssuanceNo.Name = "IssuanceNo";
            this.IssuanceNo.Size = new System.Drawing.Size(155, 28);
            this.IssuanceNo.TabIndex = 319;
            // 
            // IssuanceType
            // 
            this.IssuanceType.BackColor = System.Drawing.Color.White;
            this.IssuanceType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular);
            this.IssuanceType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.IssuanceType.Location = new System.Drawing.Point(80, 72);
            this.IssuanceType.Name = "IssuanceType";
            this.IssuanceType.Size = new System.Drawing.Size(155, 28);
            this.IssuanceType.TabIndex = 309;
            // 
            // LocLabel
            // 
            this.LocLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.LocLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LocLabel.Location = new System.Drawing.Point(4, 77);
            this.LocLabel.Name = "LocLabel";
            this.LocLabel.Size = new System.Drawing.Size(78, 19);
            this.LocLabel.Text = "Type";
            // 
            // listView1
            // 
            this.listView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.listView1.Columns.Add(this.TagNumber);
            this.listView1.Columns.Add(this.DRNumber);
            this.listView1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular);
            this.listView1.FullRowSelect = true;
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(3, 109);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(236, 154);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.TabIndex = 332;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // TagNumber
            // 
            this.TagNumber.Text = "   Tag Number";
            this.TagNumber.Width = 125;
            // 
            // DRNumber
            // 
            this.DRNumber.Text = "DR Number";
            this.DRNumber.Width = 125;
            // 
            // imageList1
            // 
            this.imageList1.ImageSize = new System.Drawing.Size(40, 20);
            this.imageList1.Images.Clear();
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource"))));
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource1"))));
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource2"))));
            // 
            // lblGridHeader
            // 
            this.lblGridHeader.BackColor = System.Drawing.Color.White;
            this.lblGridHeader.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblGridHeader.ForeColor = System.Drawing.Color.Black;
            this.lblGridHeader.Location = new System.Drawing.Point(2, 105);
            this.lblGridHeader.Name = "lblGridHeader";
            this.lblGridHeader.Size = new System.Drawing.Size(235, 26);
            this.lblGridHeader.Text = " Tag Number           |  DR Number";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(2, 263);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(240, 18);
            this.label6.Text = "Pressing [ Enter keypad  button ] will display list.";
            // 
            // MaterialIssuanceWindow_Sym
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(242, 320);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblGridHeader);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.IssuanceNo);
            this.Controls.Add(this.IssuanceType);
            this.Controls.Add(this.LocLabel);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(205)))), ((int)(((byte)(210)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MaterialIssuanceWindow_Sym";
            this.Text = "Material Issuance";
            this.Load += new System.EventHandler(this.MaterialIssuanceWindow_Load);
            this.Controls.SetChildIndex(this.LocLabel, 0);
            this.Controls.SetChildIndex(this.IssuanceType, 0);
            this.Controls.SetChildIndex(this.IssuanceNo, 0);
            this.Controls.SetChildIndex(this.listView1, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.lblGridHeader, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox IssuanceNo;
        private System.Windows.Forms.TextBox IssuanceType;
        private System.Windows.Forms.Label LocLabel;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader TagNumber;
        private System.Windows.Forms.ColumnHeader DRNumber;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lblGridHeader;
        private System.Windows.Forms.Label label6;
    }
}