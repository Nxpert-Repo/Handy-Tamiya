namespace Handy
{
    partial class InventoryGenerationWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventoryGenerationWindow));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.panelGenerationInfo = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelRenewLogIn = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.NotifyUser = new System.Windows.Forms.Label();
            this.PINText = new System.Windows.Forms.TextBox();
            this.UserIDText = new System.Windows.Forms.TextBox();
            this.lblGeneratedby = new System.Windows.Forms.Label();
            this.lblDateGenerated = new System.Windows.Forms.Label();
            this.lblWGenerated = new System.Windows.Forms.Label();
            this.labelgeneratelist = new System.Windows.Forms.Label();
            this.labelnote = new System.Windows.Forms.Label();
            this.lblRows = new System.Windows.Forms.Label();
            this.labellist = new System.Windows.Forms.Label();
            this.labelverifyuser = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.panelMachineryListView = new System.Windows.Forms.Panel();
            this.lblInstruction = new System.Windows.Forms.Label();
            this.Select = new System.Windows.Forms.ColumnHeader();
            this.StockInitial = new System.Windows.Forms.ColumnHeader();
            this.Count = new System.Windows.Forms.ColumnHeader();
            this.handy = new Handy.Main.Handy();
            this.panelGenerationInfo.SuspendLayout();
            this.panelRenewLogIn.SuspendLayout();
            this.panelMachineryListView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.handy)).BeginInit();
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
            // panelGenerationInfo
            // 
            this.panelGenerationInfo.BackColor = System.Drawing.Color.White;
            this.panelGenerationInfo.Controls.Add(this.comboBox1);
            this.panelGenerationInfo.Controls.Add(this.label1);
            this.panelGenerationInfo.Controls.Add(this.panelRenewLogIn);
            this.panelGenerationInfo.Controls.Add(this.lblGeneratedby);
            this.panelGenerationInfo.Controls.Add(this.lblDateGenerated);
            this.panelGenerationInfo.Controls.Add(this.lblWGenerated);
            this.panelGenerationInfo.Controls.Add(this.labelgeneratelist);
            this.panelGenerationInfo.Controls.Add(this.labelnote);
            this.panelGenerationInfo.Controls.Add(this.lblRows);
            this.panelGenerationInfo.Controls.Add(this.labellist);
            this.panelGenerationInfo.Controls.Add(this.labelverifyuser);
            this.panelGenerationInfo.Controls.Add(this.listView1);
            this.panelGenerationInfo.Controls.Add(this.panelMachineryListView);
            this.panelGenerationInfo.Location = new System.Drawing.Point(3, 474);
            this.panelGenerationInfo.Name = "panelGenerationInfo";
            this.panelGenerationInfo.Size = new System.Drawing.Size(230, 253);
            this.panelGenerationInfo.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.Location = new System.Drawing.Point(6, 63);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(221, 19);
            this.comboBox1.TabIndex = 339;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(3, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 18);
            this.label1.Text = "Warehouse:";
            // 
            // panelRenewLogIn
            // 
            this.panelRenewLogIn.BackColor = System.Drawing.Color.White;
            this.panelRenewLogIn.Controls.Add(this.pictureBox2);
            this.panelRenewLogIn.Controls.Add(this.pictureBox1);
            this.panelRenewLogIn.Controls.Add(this.NotifyUser);
            this.panelRenewLogIn.Controls.Add(this.PINText);
            this.panelRenewLogIn.Controls.Add(this.UserIDText);
            this.panelRenewLogIn.Location = new System.Drawing.Point(2, 38);
            this.panelRenewLogIn.Name = "panelRenewLogIn";
            this.panelRenewLogIn.Size = new System.Drawing.Size(235, 80);
            this.panelRenewLogIn.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(8, 122);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 33);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(8, 83);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 33);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // NotifyUser
            // 
            this.NotifyUser.BackColor = System.Drawing.Color.Maroon;
            this.NotifyUser.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.NotifyUser.ForeColor = System.Drawing.Color.White;
            this.NotifyUser.Location = new System.Drawing.Point(8, 157);
            this.NotifyUser.Name = "NotifyUser";
            this.NotifyUser.Size = new System.Drawing.Size(205, 18);
            this.NotifyUser.Text = "status";
            this.NotifyUser.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.NotifyUser.Visible = false;
            // 
            // PINText
            // 
            this.PINText.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular);
            this.PINText.ForeColor = System.Drawing.Color.Black;
            this.PINText.Location = new System.Drawing.Point(44, 119);
            this.PINText.Name = "PINText";
            this.PINText.PasswordChar = '*';
            this.PINText.Size = new System.Drawing.Size(170, 33);
            this.PINText.TabIndex = 3;
            this.PINText.TextChanged += new System.EventHandler(this.PINText_TextChanged);
            // 
            // UserIDText
            // 
            this.UserIDText.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular);
            this.UserIDText.ForeColor = System.Drawing.Color.Black;
            this.UserIDText.Location = new System.Drawing.Point(44, 83);
            this.UserIDText.Name = "UserIDText";
            this.UserIDText.Size = new System.Drawing.Size(170, 33);
            this.UserIDText.TabIndex = 2;
            this.UserIDText.TextChanged += new System.EventHandler(this.UserIDText_TextChanged);
            // 
            // lblGeneratedby
            // 
            this.lblGeneratedby.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblGeneratedby.ForeColor = System.Drawing.Color.Black;
            this.lblGeneratedby.Location = new System.Drawing.Point(5, 160);
            this.lblGeneratedby.Name = "lblGeneratedby";
            this.lblGeneratedby.Size = new System.Drawing.Size(301, 20);
            this.lblGeneratedby.Text = "Generated By :";
            // 
            // lblDateGenerated
            // 
            this.lblDateGenerated.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblDateGenerated.ForeColor = System.Drawing.Color.Black;
            this.lblDateGenerated.Location = new System.Drawing.Point(4, 139);
            this.lblDateGenerated.Name = "lblDateGenerated";
            this.lblDateGenerated.Size = new System.Drawing.Size(301, 20);
            this.lblDateGenerated.Text = "Date Generated : ";
            // 
            // lblWGenerated
            // 
            this.lblWGenerated.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblWGenerated.ForeColor = System.Drawing.Color.Black;
            this.lblWGenerated.Location = new System.Drawing.Point(3, 120);
            this.lblWGenerated.Name = "lblWGenerated";
            this.lblWGenerated.Size = new System.Drawing.Size(224, 18);
            this.lblWGenerated.Text = "Gen. Warehouse : ";
            // 
            // labelgeneratelist
            // 
            this.labelgeneratelist.BackColor = System.Drawing.Color.Teal;
            this.labelgeneratelist.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelgeneratelist.ForeColor = System.Drawing.Color.White;
            this.labelgeneratelist.Location = new System.Drawing.Point(1, 0);
            this.labelgeneratelist.Name = "labelgeneratelist";
            this.labelgeneratelist.Size = new System.Drawing.Size(232, 23);
            this.labelgeneratelist.Text = "GENERATE LOCAL INVENTORY LIST";
            this.labelgeneratelist.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelnote
            // 
            this.labelnote.BackColor = System.Drawing.Color.Teal;
            this.labelnote.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.labelnote.ForeColor = System.Drawing.Color.White;
            this.labelnote.Location = new System.Drawing.Point(1, 202);
            this.labelnote.Name = "labelnote";
            this.labelnote.Size = new System.Drawing.Size(226, 42);
            this.labelnote.Text = "Note : Generating inventory reference list will take for a while, please wait upo" +
                "n generation.";
            this.labelnote.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblRows
            // 
            this.lblRows.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblRows.ForeColor = System.Drawing.Color.Black;
            this.lblRows.Location = new System.Drawing.Point(5, 184);
            this.lblRows.Name = "lblRows";
            this.lblRows.Size = new System.Drawing.Size(301, 20);
            this.lblRows.Text = "Row(s) :";
            // 
            // labellist
            // 
            this.labellist.BackColor = System.Drawing.Color.Teal;
            this.labellist.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular);
            this.labellist.ForeColor = System.Drawing.Color.White;
            this.labellist.Location = new System.Drawing.Point(3, 0);
            this.labellist.Name = "labellist";
            this.labellist.Size = new System.Drawing.Size(227, 23);
            this.labellist.Text = "  Select  |        Stock Initial          |    Count";
            // 
            // labelverifyuser
            // 
            this.labelverifyuser.BackColor = System.Drawing.Color.White;
            this.labelverifyuser.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelverifyuser.ForeColor = System.Drawing.Color.Black;
            this.labelverifyuser.Location = new System.Drawing.Point(5, 26);
            this.labelverifyuser.Name = "labelverifyuser";
            this.labelverifyuser.Size = new System.Drawing.Size(195, 26);
            this.labelverifyuser.Text = "verify user";
            this.labelverifyuser.Visible = false;
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.White;
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.Add(this.columnHeader1);
            this.listView1.Columns.Add(this.columnHeader2);
            this.listView1.Columns.Add(this.columnHeader3);
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(0, -65);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(233, 245);
            this.listView1.TabIndex = 336;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "colSelect";
            this.columnHeader1.Width = 20;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "colStockInitial";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader2.Width = 94;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "colCount";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader3.Width = 96;
            // 
            // panelMachineryListView
            // 
            this.panelMachineryListView.BackColor = System.Drawing.Color.White;
            this.panelMachineryListView.Controls.Add(this.lblInstruction);
            this.panelMachineryListView.Location = new System.Drawing.Point(3, 95);
            this.panelMachineryListView.Name = "panelMachineryListView";
            this.panelMachineryListView.Size = new System.Drawing.Size(233, 40);
            this.panelMachineryListView.Visible = false;
            // 
            // lblInstruction
            // 
            this.lblInstruction.BackColor = System.Drawing.Color.Teal;
            this.lblInstruction.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.lblInstruction.ForeColor = System.Drawing.Color.White;
            this.lblInstruction.Location = new System.Drawing.Point(2, 220);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(308, 29);
            this.lblInstruction.Text = "Press [1] to check/uncheck stock code/s.";
            this.lblInstruction.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Select
            // 
            this.Select.Text = "Select";
            this.Select.Width = 150;
            // 
            // StockInitial
            // 
            this.StockInitial.Text = "Stock Initial";
            this.StockInitial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.StockInitial.Width = 105;
            // 
            // Count
            // 
            this.Count.Text = "Count";
            this.Count.Width = 105;
            // 
            // handy
            // 
            this.handy.DataSetName = "Handy";
            this.handy.Prefix = "";
            this.handy.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // InventoryGenerationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(321, 416);
            this.Controls.Add(this.panelGenerationInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InventoryGenerationWindow";
            this.Text = "InventoryReferenceGeneration";
            this.Load += new System.EventHandler(this.InventoryReferenceGeneration_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.InventoryReferenceGeneration_Closing);
            this.Controls.SetChildIndex(this.panelGenerationInfo, 0);
            this.panelGenerationInfo.ResumeLayout(false);
            this.panelRenewLogIn.ResumeLayout(false);
            this.panelMachineryListView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.handy)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelGenerationInfo;
        private System.Windows.Forms.Label labelnote;
        private System.Windows.Forms.Label lblGeneratedby;
        private System.Windows.Forms.Label lblRows;
        private System.Windows.Forms.Label lblDateGenerated;
        private System.Windows.Forms.Label labelgeneratelist;
        private System.Windows.Forms.ColumnHeader Select;
        private System.Windows.Forms.ColumnHeader StockInitial;
        private System.Windows.Forms.ColumnHeader Count;
        private System.Windows.Forms.Panel panelRenewLogIn;
        private System.Windows.Forms.TextBox UserIDText;
        private System.Windows.Forms.TextBox PINText;
        private System.Windows.Forms.Label labelverifyuser;
        private System.Windows.Forms.Label NotifyUser;
        private System.Windows.Forms.Panel panelMachineryListView;
        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.Label labellist;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Handy.Main.Handy handy;
        private System.Windows.Forms.Label lblWGenerated;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}