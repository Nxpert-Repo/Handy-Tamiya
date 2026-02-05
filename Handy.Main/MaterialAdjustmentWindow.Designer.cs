namespace Handy
{
    partial class MaterialAdjustmentWindow
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
            this.ActualQty = new System.Windows.Forms.TextBox();
            this.AvailableQty = new System.Windows.Forms.TextBox();
            this.UnitActual = new System.Windows.Forms.TextBox();
            this.RRNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CancelButtonLabel = new System.Windows.Forms.Label();
            this.SaveButtonLabel = new System.Windows.Forms.Label();
            this.LocLabel = new System.Windows.Forms.Label();
            this.ReceivedQty = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ReservedQty = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.VarianceQty = new System.Windows.Forms.TextBox();
            this.VarianceDesc = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.TagNo = new System.Windows.Forms.TextBox();
            this.Class = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Dimension = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.UnitReceived = new System.Windows.Forms.TextBox();
            this.UnitReserved = new System.Windows.Forms.TextBox();
            this.UnitAvailable = new System.Windows.Forms.TextBox();
            this.Specs = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbSignalStrength = new System.Windows.Forms.PictureBox();
            this.pbIcon = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ActualQty
            // 
            this.ActualQty.BackColor = System.Drawing.Color.White;
            this.ActualQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
            this.ActualQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ActualQty.Location = new System.Drawing.Point(77, 230);
            this.ActualQty.Multiline = true;
            this.ActualQty.Name = "ActualQty";
            this.ActualQty.Size = new System.Drawing.Size(110, 25);
            this.ActualQty.TabIndex = 201;
            this.ActualQty.TextChanged += new System.EventHandler(this.ActualQty_TextChanged);
            this.ActualQty.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MaterialAdjustmentWindow_KeyUp);
            this.ActualQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ActualQty_KeyPress);
            // 
            // AvailableQty
            // 
            this.AvailableQty.BackColor = System.Drawing.Color.White;
            this.AvailableQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
            this.AvailableQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.AvailableQty.Location = new System.Drawing.Point(77, 206);
            this.AvailableQty.Multiline = true;
            this.AvailableQty.Name = "AvailableQty";
            this.AvailableQty.Size = new System.Drawing.Size(110, 25);
            this.AvailableQty.TabIndex = 194;
            this.AvailableQty.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MaterialAdjustmentWindow_KeyUp);
            // 
            // UnitActual
            // 
            this.UnitActual.BackColor = System.Drawing.Color.White;
            this.UnitActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
            this.UnitActual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.UnitActual.Location = new System.Drawing.Point(186, 230);
            this.UnitActual.Multiline = true;
            this.UnitActual.Name = "UnitActual";
            this.UnitActual.Size = new System.Drawing.Size(48, 25);
            this.UnitActual.TabIndex = 192;
            this.UnitActual.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MaterialAdjustmentWindow_KeyUp);
            // 
            // RRNo
            // 
            this.RRNo.BackColor = System.Drawing.Color.White;
            this.RRNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
            this.RRNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.RRNo.Location = new System.Drawing.Point(77, 134);
            this.RRNo.Multiline = true;
            this.RRNo.Name = "RRNo";
            this.RRNo.Size = new System.Drawing.Size(157, 25);
            this.RRNo.TabIndex = 191;
            this.RRNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MaterialAdjustmentWindow_KeyUp);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(6, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 19);
            this.label4.Text = "Actual";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(6, 212);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 19);
            this.label8.Text = "Available";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(6, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 19);
            this.label2.Text = "RR No.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // CancelButtonLabel
            // 
            this.CancelButtonLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.5F, System.Drawing.FontStyle.Regular);
            this.CancelButtonLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(214)))), ((int)(((byte)(214)))));
            this.CancelButtonLabel.Location = new System.Drawing.Point(132, 3);
            this.CancelButtonLabel.Name = "CancelButtonLabel";
            this.CancelButtonLabel.Size = new System.Drawing.Size(102, 24);
            this.CancelButtonLabel.Tag = "";
            this.CancelButtonLabel.Text = "CANCEL";
            this.CancelButtonLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // SaveButtonLabel
            // 
            this.SaveButtonLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.5F, System.Drawing.FontStyle.Regular);
            this.SaveButtonLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(214)))), ((int)(((byte)(214)))));
            this.SaveButtonLabel.Location = new System.Drawing.Point(4, 3);
            this.SaveButtonLabel.Name = "SaveButtonLabel";
            this.SaveButtonLabel.Size = new System.Drawing.Size(104, 24);
            this.SaveButtonLabel.Tag = "";
            this.SaveButtonLabel.Text = "SAVE";
            this.SaveButtonLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LocLabel
            // 
            this.LocLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5F, System.Drawing.FontStyle.Regular);
            this.LocLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(214)))), ((int)(((byte)(214)))));
            this.LocLabel.Location = new System.Drawing.Point(30, 2);
            this.LocLabel.Name = "LocLabel";
            this.LocLabel.Size = new System.Drawing.Size(166, 25);
            this.LocLabel.Text = "MAT\'L ADJSTMNT";
            // 
            // ReceivedQty
            // 
            this.ReceivedQty.BackColor = System.Drawing.Color.White;
            this.ReceivedQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
            this.ReceivedQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ReceivedQty.Location = new System.Drawing.Point(77, 158);
            this.ReceivedQty.Multiline = true;
            this.ReceivedQty.Name = "ReceivedQty";
            this.ReceivedQty.Size = new System.Drawing.Size(110, 25);
            this.ReceivedQty.TabIndex = 228;
            this.ReceivedQty.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MaterialAdjustmentWindow_KeyUp);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(6, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 19);
            this.label6.Text = "Received";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ReservedQty
            // 
            this.ReservedQty.BackColor = System.Drawing.Color.White;
            this.ReservedQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
            this.ReservedQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ReservedQty.Location = new System.Drawing.Point(77, 182);
            this.ReservedQty.Multiline = true;
            this.ReservedQty.Name = "ReservedQty";
            this.ReservedQty.Size = new System.Drawing.Size(110, 25);
            this.ReservedQty.TabIndex = 234;
            this.ReservedQty.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MaterialAdjustmentWindow_KeyUp);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(6, 188);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 15);
            this.label12.Text = "Reserved";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // VarianceQty
            // 
            this.VarianceQty.BackColor = System.Drawing.Color.White;
            this.VarianceQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
            this.VarianceQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.VarianceQty.Location = new System.Drawing.Point(77, 254);
            this.VarianceQty.Multiline = true;
            this.VarianceQty.Name = "VarianceQty";
            this.VarianceQty.Size = new System.Drawing.Size(62, 25);
            this.VarianceQty.TabIndex = 253;
            this.VarianceQty.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MaterialAdjustmentWindow_KeyUp);
            // 
            // VarianceDesc
            // 
            this.VarianceDesc.BackColor = System.Drawing.Color.White;
            this.VarianceDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
            this.VarianceDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.VarianceDesc.Location = new System.Drawing.Point(138, 254);
            this.VarianceDesc.Multiline = true;
            this.VarianceDesc.Name = "VarianceDesc";
            this.VarianceDesc.Size = new System.Drawing.Size(96, 25);
            this.VarianceDesc.TabIndex = 252;
            this.VarianceDesc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MaterialAdjustmentWindow_KeyUp);
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(6, 260);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 19);
            this.label13.Text = "Variance";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // TagNo
            // 
            this.TagNo.BackColor = System.Drawing.Color.White;
            this.TagNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
            this.TagNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TagNo.Location = new System.Drawing.Point(77, 38);
            this.TagNo.Multiline = true;
            this.TagNo.Name = "TagNo";
            this.TagNo.Size = new System.Drawing.Size(157, 25);
            this.TagNo.TabIndex = 281;
            this.TagNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MaterialAdjustmentWindow_KeyUp);
            // 
            // Class
            // 
            this.Class.BackColor = System.Drawing.Color.White;
            this.Class.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
            this.Class.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Class.Location = new System.Drawing.Point(77, 110);
            this.Class.Multiline = true;
            this.Class.Name = "Class";
            this.Class.Size = new System.Drawing.Size(157, 25);
            this.Class.TabIndex = 280;
            this.Class.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MaterialAdjustmentWindow_KeyUp);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(0, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 19);
            this.label7.Text = "Dimension";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Dimension
            // 
            this.Dimension.BackColor = System.Drawing.Color.White;
            this.Dimension.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
            this.Dimension.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Dimension.Location = new System.Drawing.Point(77, 62);
            this.Dimension.Multiline = true;
            this.Dimension.Name = "Dimension";
            this.Dimension.Size = new System.Drawing.Size(157, 25);
            this.Dimension.TabIndex = 278;
            this.Dimension.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MaterialAdjustmentWindow_KeyUp);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(6, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 19);
            this.label1.Text = "Tag No";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(6, 116);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 19);
            this.label14.Text = "Class";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // UnitReceived
            // 
            this.UnitReceived.BackColor = System.Drawing.Color.White;
            this.UnitReceived.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
            this.UnitReceived.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.UnitReceived.Location = new System.Drawing.Point(186, 158);
            this.UnitReceived.Multiline = true;
            this.UnitReceived.Name = "UnitReceived";
            this.UnitReceived.Size = new System.Drawing.Size(48, 25);
            this.UnitReceived.TabIndex = 288;
            this.UnitReceived.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MaterialAdjustmentWindow_KeyUp);
            // 
            // UnitReserved
            // 
            this.UnitReserved.BackColor = System.Drawing.Color.White;
            this.UnitReserved.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
            this.UnitReserved.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.UnitReserved.Location = new System.Drawing.Point(186, 182);
            this.UnitReserved.Multiline = true;
            this.UnitReserved.Name = "UnitReserved";
            this.UnitReserved.Size = new System.Drawing.Size(48, 25);
            this.UnitReserved.TabIndex = 289;
            this.UnitReserved.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MaterialAdjustmentWindow_KeyUp);
            // 
            // UnitAvailable
            // 
            this.UnitAvailable.BackColor = System.Drawing.Color.White;
            this.UnitAvailable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
            this.UnitAvailable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.UnitAvailable.Location = new System.Drawing.Point(186, 206);
            this.UnitAvailable.Multiline = true;
            this.UnitAvailable.Name = "UnitAvailable";
            this.UnitAvailable.Size = new System.Drawing.Size(48, 25);
            this.UnitAvailable.TabIndex = 290;
            this.UnitAvailable.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MaterialAdjustmentWindow_KeyUp);
            // 
            // Specs
            // 
            this.Specs.BackColor = System.Drawing.Color.White;
            this.Specs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
            this.Specs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Specs.Location = new System.Drawing.Point(77, 86);
            this.Specs.Multiline = true;
            this.Specs.Name = "Specs";
            this.Specs.Size = new System.Drawing.Size(157, 25);
            this.Specs.TabIndex = 382;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(5, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 19);
            this.label3.Text = "Specs";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.panel2.Controls.Add(this.pbSignalStrength);
            this.panel2.Controls.Add(this.pbIcon);
            this.panel2.Controls.Add(this.LocLabel);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(238, 30);
            // 
            // pbSignalStrength
            // 
            this.pbSignalStrength.BackColor = System.Drawing.Color.White;
            this.pbSignalStrength.Location = new System.Drawing.Point(205, 4);
            this.pbSignalStrength.Name = "pbSignalStrength";
            this.pbSignalStrength.Size = new System.Drawing.Size(30, 21);
            // 
            // pbIcon
            // 
            this.pbIcon.BackColor = System.Drawing.Color.White;
            this.pbIcon.Location = new System.Drawing.Point(4, 4);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.Size = new System.Drawing.Size(21, 21);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.panel1.Controls.Add(this.CancelButtonLabel);
            this.panel1.Controls.Add(this.SaveButtonLabel);
            this.panel1.Location = new System.Drawing.Point(0, 283);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(238, 37);
            // 
            // MaterialAdjustmentWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(238, 320);
            this.ControlBox = false;
            this.Controls.Add(this.Specs);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TagNo);
            this.Controls.Add(this.Dimension);
            this.Controls.Add(this.UnitAvailable);
            this.Controls.Add(this.UnitReserved);
            this.Controls.Add(this.UnitReceived);
            this.Controls.Add(this.Class);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.VarianceQty);
            this.Controls.Add(this.VarianceDesc);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.ReservedQty);
            this.Controls.Add(this.ReceivedQty);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ActualQty);
            this.Controls.Add(this.AvailableQty);
            this.Controls.Add(this.UnitActual);
            this.Controls.Add(this.RRNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MaterialAdjustmentWindow";
            this.Text = "Material Adjustment";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MaterialAdjustmentWindow_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MaterialAdjustmentWindow_Closing);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MaterialAdjustmentWindow_KeyUp);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox ActualQty;
        private System.Windows.Forms.TextBox AvailableQty;
        private System.Windows.Forms.TextBox UnitActual;
        private System.Windows.Forms.TextBox RRNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label CancelButtonLabel;
        private System.Windows.Forms.Label SaveButtonLabel;
        private System.Windows.Forms.Label LocLabel;
        private System.Windows.Forms.TextBox ReceivedQty;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ReservedQty;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox VarianceQty;
        private System.Windows.Forms.TextBox VarianceDesc;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox TagNo;
        private System.Windows.Forms.TextBox Class;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Dimension;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox UnitReceived;
        private System.Windows.Forms.TextBox UnitReserved;
        private System.Windows.Forms.TextBox UnitAvailable;
        private System.Windows.Forms.TextBox Specs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pbIcon;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbSignalStrength;

    }
}