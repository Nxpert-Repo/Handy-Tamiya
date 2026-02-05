namespace Handy
{
    partial class DisplayNewTagsWindow
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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.TagNumber = new System.Windows.Forms.TextBox();
            this.lblTagNo = new System.Windows.Forms.Label();
            this.listViewNewTags = new System.Windows.Forms.ListView();
            this.TagNo = new System.Windows.Forms.ColumnHeader();
            this.LocatorCode = new System.Windows.Forms.ColumnHeader();
            this.lblGridHeader = new System.Windows.Forms.Label();
            this.lblListofTags = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TagNumber
            // 
            this.TagNumber.BackColor = System.Drawing.Color.White;
            this.TagNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
            this.TagNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TagNumber.Location = new System.Drawing.Point(75, 42);
            this.TagNumber.Name = "TagNumber";
            this.TagNumber.Size = new System.Drawing.Size(151, 25);
            this.TagNumber.TabIndex = 296;
            // 
            // lblTagNo
            // 
            this.lblTagNo.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTagNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
            this.lblTagNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTagNo.Location = new System.Drawing.Point(12, 46);
            this.lblTagNo.Name = "lblTagNo";
            this.lblTagNo.Size = new System.Drawing.Size(57, 19);
            this.lblTagNo.Text = "Tag No:";
            // 
            // listViewNewTags
            // 
            this.listViewNewTags.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listViewNewTags.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.listViewNewTags.Columns.Add(this.TagNo);
            this.listViewNewTags.Columns.Add(this.LocatorCode);
            this.listViewNewTags.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
            this.listViewNewTags.FullRowSelect = true;
            this.listViewNewTags.Location = new System.Drawing.Point(12, 107);
            this.listViewNewTags.Name = "listViewNewTags";
            this.listViewNewTags.Size = new System.Drawing.Size(217, 172);
            this.listViewNewTags.TabIndex = 333;
            this.listViewNewTags.View = System.Windows.Forms.View.Details;
            // 
            // TagNo
            // 
            this.TagNo.Text = "   Tag Number";
            this.TagNo.Width = 110;
            // 
            // LocatorCode
            // 
            this.LocatorCode.Text = "Locator";
            this.LocatorCode.Width = 103;
            // 
            // lblGridHeader
            // 
            this.lblGridHeader.BackColor = System.Drawing.Color.Teal;
            this.lblGridHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
            this.lblGridHeader.ForeColor = System.Drawing.Color.White;
            this.lblGridHeader.Location = new System.Drawing.Point(13, 108);
            this.lblGridHeader.Name = "lblGridHeader";
            this.lblGridHeader.Size = new System.Drawing.Size(215, 23);
            this.lblGridHeader.Text = " Tag Number         |  Locator";
            // 
            // lblListofTags
            // 
            this.lblListofTags.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblListofTags.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
            this.lblListofTags.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblListofTags.Location = new System.Drawing.Point(13, 84);
            this.lblListofTags.Name = "lblListofTags";
            this.lblListofTags.Size = new System.Drawing.Size(213, 19);
            this.lblListofTags.Text = "List of New Tag Nos:";
            // 
            // DisplayNewTagsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(246, 325);
            this.Controls.Add(this.lblListofTags);
            this.Controls.Add(this.lblGridHeader);
            this.Controls.Add(this.listViewNewTags);
            this.Controls.Add(this.lblTagNo);
            this.Controls.Add(this.TagNumber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DisplayNewTagsWindow";
            this.Text = "DisplayNewTagsWindow";
            this.Load += new System.EventHandler(this.DisplayNewTagsWindow_Load);
            this.Controls.SetChildIndex(this.TagNumber, 0);
            this.Controls.SetChildIndex(this.lblTagNo, 0);
            this.Controls.SetChildIndex(this.listViewNewTags, 0);
            this.Controls.SetChildIndex(this.lblGridHeader, 0);
            this.Controls.SetChildIndex(this.lblListofTags, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox TagNumber;
        private System.Windows.Forms.Label lblTagNo;
        private System.Windows.Forms.ListView listViewNewTags;
        private System.Windows.Forms.ColumnHeader TagNo;
        private System.Windows.Forms.Label lblGridHeader;
        private System.Windows.Forms.Label lblListofTags;
        private System.Windows.Forms.ColumnHeader LocatorCode;
    }
}