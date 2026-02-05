namespace Handy
{
    partial class TestWindow
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtBarcodeContent = new System.Windows.Forms.TextBox();
            this.txtBarcodeType = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(18, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 18);
            this.label1.Text = "Barcode Content";
            // 
            // txtBarcodeContent
            // 
            this.txtBarcodeContent.AcceptsTab = true;
            this.txtBarcodeContent.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txtBarcodeContent.Location = new System.Drawing.Point(18, 129);
            this.txtBarcodeContent.Multiline = true;
            this.txtBarcodeContent.Name = "txtBarcodeContent";
            this.txtBarcodeContent.Size = new System.Drawing.Size(203, 130);
            this.txtBarcodeContent.TabIndex = 1;
            // 
            // txtBarcodeType
            // 
            this.txtBarcodeType.AcceptsTab = true;
            this.txtBarcodeType.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txtBarcodeType.Location = new System.Drawing.Point(18, 81);
            this.txtBarcodeType.Multiline = true;
            this.txtBarcodeType.Name = "txtBarcodeType";
            this.txtBarcodeType.Size = new System.Drawing.Size(203, 24);
            this.txtBarcodeType.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(18, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 18);
            this.label2.Text = "Barcode Type";
            // 
            // TestWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(242, 321);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBarcodeType);
            this.Controls.Add(this.txtBarcodeContent);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TestWindow";
            this.Text = "TestWindow";
            this.Closed += new System.EventHandler(this.TestWindow_Closed);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtBarcodeContent, 0);
            this.Controls.SetChildIndex(this.txtBarcodeType, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBarcodeContent;
        private System.Windows.Forms.TextBox txtBarcodeType;
        private System.Windows.Forms.Label label2;
    }
}