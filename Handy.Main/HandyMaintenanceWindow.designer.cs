namespace Handy
{
    partial class HandyMaintenanceWindow
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
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem();
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem();
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem();
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem();
            System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem();
            this.listView1 = new System.Windows.Forms.ListView();
            this.MAINTENANCEMENU = new System.Windows.Forms.ColumnHeader();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.listView1.Columns.Add(this.MAINTENANCEMENU);
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular);
            this.listView1.ForeColor = System.Drawing.Color.DimGray;
            this.listView1.FullRowSelect = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            listViewItem6.ForeColor = System.Drawing.Color.Black;
            listViewItem6.Text = "    Database Settings";
            listViewItem6.SubItems.Add("Database Settings");
            listViewItem7.ForeColor = System.Drawing.Color.Black;
            listViewItem7.Text = "    Host Name";
            listViewItem7.SubItems.Add("Host Name");
            listViewItem8.ForeColor = System.Drawing.Color.Black;
            listViewItem8.Text = "    Handy Info";
            listViewItem8.SubItems.Add("Handy Info");
            listViewItem9.ForeColor = System.Drawing.Color.Black;
            listViewItem9.Text = "    FTP";
            listViewItem9.SubItems.Add("FTP");
            listViewItem10.ForeColor = System.Drawing.Color.Black;
            listViewItem10.Text = "    Log Files";
            listViewItem10.SubItems.Add("Log Files");
            this.listView1.Items.Add(listViewItem6);
            this.listView1.Items.Add(listViewItem7);
            this.listView1.Items.Add(listViewItem8);
            this.listView1.Items.Add(listViewItem9);
            this.listView1.Items.Add(listViewItem10);
            this.listView1.Location = new System.Drawing.Point(4, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(211, 209);
            this.listView1.TabIndex = 334;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // MAINTENANCEMENU
            // 
            this.MAINTENANCEMENU.Text = "Maintenance Menu";
            this.MAINTENANCEMENU.Width = 190;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.listView1);
            this.panel3.Location = new System.Drawing.Point(11, 52);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(218, 215);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Teal;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(9, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 220);
            // 
            // HandyMaintenanceWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(246, 320);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.DimGray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HandyMaintenanceWindow";
            this.Text = "Maintenance";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        public System.Windows.Forms.ColumnHeader MAINTENANCEMENU;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
    }
}