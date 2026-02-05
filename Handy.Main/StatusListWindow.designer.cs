namespace Handy
{
    partial class StatusListWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatusListWindow));
            this.ListView = new System.Windows.Forms.ListView();
            this.ControlNumber = new System.Windows.Forms.ColumnHeader();
            this.Status = new System.Windows.Forms.ColumnHeader();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.lblListGridHeader = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ListView
            // 
            this.ListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ListView.Columns.Add(this.ControlNumber);
            this.ListView.Columns.Add(this.Status);
            this.ListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
            this.ListView.FullRowSelect = true;
            this.ListView.Location = new System.Drawing.Point(3, 45);
            this.ListView.Name = "ListView";
            this.ListView.Size = new System.Drawing.Size(233, 237);
            this.ListView.SmallImageList = this.imageList1;
            this.ListView.TabIndex = 338;
            this.ListView.View = System.Windows.Forms.View.Details;
            // 
            // ControlNumber
            // 
            this.ControlNumber.Text = "   DP Number";
            this.ControlNumber.Width = 120;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            this.Status.Width = 109;
            // 
            // imageList1
            // 
            this.imageList1.ImageSize = new System.Drawing.Size(40, 20);
            this.imageList1.Images.Clear();
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource"))));
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource1"))));
            // 
            // lblListGridHeader
            // 
            this.lblListGridHeader.BackColor = System.Drawing.Color.Teal;
            this.lblListGridHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
            this.lblListGridHeader.ForeColor = System.Drawing.Color.White;
            this.lblListGridHeader.Location = new System.Drawing.Point(4, 46);
            this.lblListGridHeader.Name = "lblListGridHeader";
            this.lblListGridHeader.Size = new System.Drawing.Size(231, 23);
            this.lblListGridHeader.Text = " DR Number              |  Status";
            // 
            // StatusListWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(248, 326);
            this.Controls.Add(this.lblListGridHeader);
            this.Controls.Add(this.ListView);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(205)))), ((int)(((byte)(210)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StatusListWindow";
            this.Text = "Status List";
            this.Load += new System.EventHandler(this.StatusListWindow_Load);
            this.Controls.SetChildIndex(this.ListView, 0);
            this.Controls.SetChildIndex(this.lblListGridHeader, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView ListView;
        private System.Windows.Forms.ColumnHeader ControlNumber;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lblListGridHeader;
    }
}