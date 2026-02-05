namespace Handy
{
    partial class MainWindow
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
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem();
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem();
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem();
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem();
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem();
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem();
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.lvFunctionList = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.SuspendLayout();
            // 
            // lblBtnLeft
            // 
            this.lblBtnLeft.BackColor = System.Drawing.Color.Teal;
            this.lblBtnLeft.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            // 
            // lblBtnRight
            // 
            this.lblBtnRight.BackColor = System.Drawing.Color.Teal;
            this.lblBtnRight.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            // 
            // lvFunctionList
            // 
            this.lvFunctionList.BackColor = System.Drawing.Color.White;
            this.lvFunctionList.Columns.Add(this.columnHeader1);
            this.lvFunctionList.Columns.Add(this.columnHeader2);
            this.lvFunctionList.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lvFunctionList.FullRowSelect = true;
            this.lvFunctionList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            listViewItem1.BackColor = System.Drawing.Color.LightGreen;
            listViewItem1.ImageIndex = 1;
            listViewItem1.Text = "";
            listViewItem1.SubItems.Add("LOCATOR TAGGING");
            listViewItem2.BackColor = System.Drawing.Color.White;
            listViewItem2.ImageIndex = 4;
            listViewItem2.Text = "";
            listViewItem2.SubItems.Add("MATERIAL ISSUANCE");
            listViewItem3.BackColor = System.Drawing.Color.LightGreen;
            listViewItem3.ImageIndex = 6;
            listViewItem3.Text = "";
            listViewItem3.SubItems.Add("INVTY GENERATION");
            listViewItem4.BackColor = System.Drawing.Color.White;
            listViewItem4.ImageIndex = 3;
            listViewItem4.Text = "";
            listViewItem4.SubItems.Add("INVTY PROCESSING");
            listViewItem5.BackColor = System.Drawing.Color.LightGreen;
            listViewItem5.ImageIndex = 10;
            listViewItem5.Text = "";
            listViewItem5.SubItems.Add("STOCK CARD");
            listViewItem6.BackColor = System.Drawing.Color.White;
            listViewItem6.ImageIndex = 7;
            listViewItem6.Text = "";
            listViewItem6.SubItems.Add("BARCODE TEST");
            listViewItem7.BackColor = System.Drawing.Color.LightGreen;
            listViewItem7.ImageIndex = 8;
            listViewItem7.Text = "";
            listViewItem7.SubItems.Add("MAINTENANCE");
            listViewItem8.BackColor = System.Drawing.Color.White;
            listViewItem8.ImageIndex = 9;
            listViewItem8.Text = "";
            listViewItem8.SubItems.Add("LOG-OUT");
            this.lvFunctionList.Items.Add(listViewItem1);
            this.lvFunctionList.Items.Add(listViewItem2);
            this.lvFunctionList.Items.Add(listViewItem3);
            this.lvFunctionList.Items.Add(listViewItem4);
            this.lvFunctionList.Items.Add(listViewItem5);
            this.lvFunctionList.Items.Add(listViewItem6);
            this.lvFunctionList.Items.Add(listViewItem7);
            this.lvFunctionList.Items.Add(listViewItem8);
            this.lvFunctionList.Location = new System.Drawing.Point(1, 34);
            this.lvFunctionList.Name = "lvFunctionList";
            this.lvFunctionList.Size = new System.Drawing.Size(259, 244);
            this.lvFunctionList.SmallImageList = this.imageList1;
            this.lvFunctionList.TabIndex = 12;
            this.lvFunctionList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ColumnHeader";
            this.columnHeader1.Width = 60;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ColumnHeader";
            this.columnHeader2.Width = 170;
            // 
            // imageList1
            // 
            this.imageList1.ImageSize = new System.Drawing.Size(40, 40);
            this.imageList1.Images.Clear();
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource"))));
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource1"))));
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource2"))));
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource3"))));
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource4"))));
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource5"))));
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource6"))));
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource7"))));
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource8"))));
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource9"))));
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource10"))));
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource11"))));
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource12"))));
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource13"))));
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource14"))));
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = false;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(295, 368);
            this.Controls.Add(this.lvFunctionList);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Main Window";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
            this.Controls.SetChildIndex(this.lvFunctionList, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        public System.Windows.Forms.ListView lvFunctionList;
    }
}
