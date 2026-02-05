namespace Handy
{
    partial class LocatorUnTaggingListWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LocatorUnTaggingListWindow));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.ListTag = new System.Windows.Forms.ListView();
            this.TagNumber = new System.Windows.Forms.ColumnHeader();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.ListRR = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.lblListHeader = new System.Windows.Forms.Label();
            this.lblListHeader2 = new System.Windows.Forms.Label();
            this.lblLocatorDesc = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ListTag
            // 
            this.ListTag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ListTag.Columns.Add(this.TagNumber);
            this.ListTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
            this.ListTag.FullRowSelect = true;
            this.ListTag.LargeImageList = this.imageList1;
            this.ListTag.Location = new System.Drawing.Point(69, 129);
            this.ListTag.Name = "ListTag";
            this.ListTag.Size = new System.Drawing.Size(166, 118);
            this.ListTag.SmallImageList = this.imageList1;
            this.ListTag.TabIndex = 343;
            this.ListTag.View = System.Windows.Forms.View.Details;
            // 
            // TagNumber
            // 
            this.TagNumber.Text = "   Tag Number";
            this.TagNumber.Width = 155;
            this.imageList1.Images.Clear();
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource"))));
            // 
            // ListRR
            // 
            this.ListRR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ListRR.Columns.Add(this.columnHeader1);
            this.ListRR.Columns.Add(this.columnHeader2);
            this.ListRR.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular);
            this.ListRR.FullRowSelect = true;
            this.ListRR.LargeImageList = this.imageList1;
            this.ListRR.Location = new System.Drawing.Point(4, 40);
            this.ListRR.Name = "ListRR";
            this.ListRR.Size = new System.Drawing.Size(233, 86);
            this.ListRR.SmallImageList = this.imageList1;
            this.ListRR.TabIndex = 347;
            this.ListRR.View = System.Windows.Forms.View.Details;
            this.ListRR.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ListRR_ColumnClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "RR Number";
            this.columnHeader1.Width = 116;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Untag Item";
            this.columnHeader2.Width = 114;
            // 
            // lblListHeader
            // 
            this.lblListHeader.BackColor = System.Drawing.Color.Teal;
            this.lblListHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
            this.lblListHeader.ForeColor = System.Drawing.Color.White;
            this.lblListHeader.Location = new System.Drawing.Point(5, 41);
            this.lblListHeader.Name = "lblListHeader";
            this.lblListHeader.Size = new System.Drawing.Size(231, 20);
            this.lblListHeader.Text = " RR Number            |  Untag Item";
            // 
            // lblListHeader2
            // 
            this.lblListHeader2.BackColor = System.Drawing.Color.Teal;
            this.lblListHeader2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
            this.lblListHeader2.ForeColor = System.Drawing.Color.White;
            this.lblListHeader2.Location = new System.Drawing.Point(70, 130);
            this.lblListHeader2.Name = "lblListHeader2";
            this.lblListHeader2.Size = new System.Drawing.Size(164, 23);
            this.lblListHeader2.Text = "              Tag Number";
            // 
            // lblLocatorDesc
            // 
            this.lblLocatorDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblLocatorDesc.ForeColor = System.Drawing.Color.Black;
            this.lblLocatorDesc.Location = new System.Drawing.Point(9, 127);
            this.lblLocatorDesc.Name = "lblLocatorDesc";
            this.lblLocatorDesc.Size = new System.Drawing.Size(68, 70);
            this.lblLocatorDesc.Text = "List of Tag No.\r\nPer RR Number.";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(7, 250);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(229, 32);
            this.label3.Text = "Pressing [ Arrow left/right keypad  button ] will display tagged list.";
            // 
            // LocatorUnTaggingListWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(248, 324);
            this.Controls.Add(this.lblListHeader2);
            this.Controls.Add(this.lblListHeader);
            this.Controls.Add(this.ListRR);
            this.Controls.Add(this.ListTag);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblLocatorDesc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LocatorUnTaggingListWindow";
            this.Text = "Locator Tagging List";
            this.Load += new System.EventHandler(this.LocatorUnTaggingListWindow_Load);
            this.Controls.SetChildIndex(this.lblLocatorDesc, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.ListTag, 0);
            this.Controls.SetChildIndex(this.ListRR, 0);
            this.Controls.SetChildIndex(this.lblListHeader, 0);
            this.Controls.SetChildIndex(this.lblListHeader2, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView ListTag;
        private System.Windows.Forms.ColumnHeader TagNumber;
        private System.Windows.Forms.ListView ListRR;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lblListHeader;
        private System.Windows.Forms.Label lblListHeader2;
        private System.Windows.Forms.Label lblLocatorDesc;
        private System.Windows.Forms.Label label3;
    }
}