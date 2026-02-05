namespace Handy
{
    partial class StockMovementWindow
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
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TransferredQty = new System.Windows.Forms.TextBox();
            this.LocatorCode = new System.Windows.Forms.TextBox();
            this.LocatorCodeDesc = new System.Windows.Forms.TextBox();
            this.AvailableQty = new System.Windows.Forms.TextBox();
            this.UnitTransferred = new System.Windows.Forms.TextBox();
            this.RRNo = new System.Windows.Forms.TextBox();
            this.StockCode = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.UnitAvailable = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(-8, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 19);
            this.label8.Text = "Available";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(-7, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 19);
            this.label2.Text = "RR Number";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(-8, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 19);
            this.label4.Text = "Transferred";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(-7, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 19);
            this.label5.Text = "New Locator";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // TransferredQty
            // 
            this.TransferredQty.BackColor = System.Drawing.Color.White;
            this.TransferredQty.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.TransferredQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TransferredQty.Location = new System.Drawing.Point(92, 139);
            this.TransferredQty.Multiline = true;
            this.TransferredQty.Name = "TransferredQty";
            this.TransferredQty.ReadOnly = true;
            this.TransferredQty.Size = new System.Drawing.Size(55, 20);
            this.TransferredQty.TabIndex = 174;
            this.TransferredQty.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StockMovementForm_KeyUp);
            this.TransferredQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TransQty_KeyPress);
            // 
            // LocatorCode
            // 
            this.LocatorCode.BackColor = System.Drawing.Color.White;
            this.LocatorCode.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.LocatorCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LocatorCode.Location = new System.Drawing.Point(92, 63);
            this.LocatorCode.Multiline = true;
            this.LocatorCode.Name = "LocatorCode";
            this.LocatorCode.ReadOnly = true;
            this.LocatorCode.Size = new System.Drawing.Size(55, 20);
            this.LocatorCode.TabIndex = 173;
            this.LocatorCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StockMovementForm_KeyUp);
            // 
            // LocatorCodeDesc
            // 
            this.LocatorCodeDesc.BackColor = System.Drawing.Color.White;
            this.LocatorCodeDesc.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.LocatorCodeDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LocatorCodeDesc.Location = new System.Drawing.Point(147, 63);
            this.LocatorCodeDesc.Multiline = true;
            this.LocatorCodeDesc.Name = "LocatorCodeDesc";
            this.LocatorCodeDesc.ReadOnly = true;
            this.LocatorCodeDesc.Size = new System.Drawing.Size(85, 20);
            this.LocatorCodeDesc.TabIndex = 172;
            this.LocatorCodeDesc.TabStop = false;
            this.LocatorCodeDesc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StockMovementForm_KeyUp);
            // 
            // AvailableQty
            // 
            this.AvailableQty.BackColor = System.Drawing.Color.White;
            this.AvailableQty.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.AvailableQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.AvailableQty.Location = new System.Drawing.Point(92, 120);
            this.AvailableQty.Multiline = true;
            this.AvailableQty.Name = "AvailableQty";
            this.AvailableQty.ReadOnly = true;
            this.AvailableQty.Size = new System.Drawing.Size(55, 20);
            this.AvailableQty.TabIndex = 167;
            this.AvailableQty.TabStop = false;
            this.AvailableQty.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StockMovementForm_KeyUp);
            // 
            // UnitTransferred
            // 
            this.UnitTransferred.BackColor = System.Drawing.Color.White;
            this.UnitTransferred.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.UnitTransferred.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.UnitTransferred.Location = new System.Drawing.Point(147, 139);
            this.UnitTransferred.Multiline = true;
            this.UnitTransferred.Name = "UnitTransferred";
            this.UnitTransferred.ReadOnly = true;
            this.UnitTransferred.Size = new System.Drawing.Size(85, 20);
            this.UnitTransferred.TabIndex = 165;
            this.UnitTransferred.TabStop = false;
            this.UnitTransferred.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StockMovementForm_KeyUp);
            // 
            // RRNo
            // 
            this.RRNo.BackColor = System.Drawing.Color.White;
            this.RRNo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.RRNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.RRNo.Location = new System.Drawing.Point(92, 101);
            this.RRNo.Multiline = true;
            this.RRNo.Name = "RRNo";
            this.RRNo.ReadOnly = true;
            this.RRNo.Size = new System.Drawing.Size(140, 20);
            this.RRNo.TabIndex = 164;
            this.RRNo.TabStop = false;
            this.RRNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StockMovementForm_KeyUp);
            // 
            // StockCode
            // 
            this.StockCode.BackColor = System.Drawing.Color.White;
            this.StockCode.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.StockCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.StockCode.Location = new System.Drawing.Point(92, 82);
            this.StockCode.Multiline = true;
            this.StockCode.Name = "StockCode";
            this.StockCode.ReadOnly = true;
            this.StockCode.Size = new System.Drawing.Size(140, 20);
            this.StockCode.TabIndex = 242;
            this.StockCode.TabStop = false;
            this.StockCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StockMovementForm_KeyUp);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(-7, 83);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 19);
            this.label12.Text = "Stock Code";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // UnitAvailable
            // 
            this.UnitAvailable.BackColor = System.Drawing.Color.White;
            this.UnitAvailable.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.UnitAvailable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.UnitAvailable.Location = new System.Drawing.Point(147, 120);
            this.UnitAvailable.Multiline = true;
            this.UnitAvailable.Name = "UnitAvailable";
            this.UnitAvailable.ReadOnly = true;
            this.UnitAvailable.Size = new System.Drawing.Size(85, 20);
            this.UnitAvailable.TabIndex = 250;
            this.UnitAvailable.TabStop = false;
            this.UnitAvailable.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StockMovementForm_KeyUp);
            // 
            // StockMovementWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.UnitAvailable);
            this.Controls.Add(this.StockCode);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.TransferredQty);
            this.Controls.Add(this.LocatorCode);
            this.Controls.Add(this.LocatorCodeDesc);
            this.Controls.Add(this.AvailableQty);
            this.Controls.Add(this.UnitTransferred);
            this.Controls.Add(this.RRNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StockMovementWindow";
            this.Text = "Material Transfer";
            this.Load += new System.EventHandler(this.StockMovementForm_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.StockMovementForm_Closing);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StockMovementForm_KeyUp);
            this.Controls.SetChildIndex(this.UnitAvailable,0);
            this.Controls.SetChildIndex(this.StockCode, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.TransferredQty, 0);
            this.Controls.SetChildIndex(this.LocatorCode, 0);
            this.Controls.SetChildIndex(this.LocatorCodeDesc, 0);
            this.Controls.SetChildIndex(this.AvailableQty, 0);
            this.Controls.SetChildIndex(this.UnitTransferred, 0);
            this.Controls.SetChildIndex(this.RRNo, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TransferredQty;
        private System.Windows.Forms.TextBox LocatorCode;
        private System.Windows.Forms.TextBox LocatorCodeDesc;
        private System.Windows.Forms.TextBox AvailableQty;
        private System.Windows.Forms.TextBox UnitTransferred;
        private System.Windows.Forms.TextBox RRNo;
        private System.Windows.Forms.TextBox StockCode;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox UnitAvailable;
    }
}