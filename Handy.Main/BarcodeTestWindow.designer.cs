namespace Handy
{
    partial class BarcodeTestWindow
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
            this.TextBarcodeContent = new System.Windows.Forms.Label();
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
            // TextBarcodeContent
            // 
            this.TextBarcodeContent.BackColor = System.Drawing.Color.Honeydew;
            this.TextBarcodeContent.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.TextBarcodeContent.Location = new System.Drawing.Point(3, 47);
            this.TextBarcodeContent.Name = "TextBarcodeContent";
            this.TextBarcodeContent.Size = new System.Drawing.Size(234, 222);
            // 
            // BarcodeTestWindow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.TextBarcodeContent);
            this.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BarcodeTestWindow";
            this.Text = "Barcode Test";
            this.Load += new System.EventHandler(this.BarcodeTestWindow_Load);
            this.Controls.SetChildIndex(this.TextBarcodeContent, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label TextBarcodeContent;
        //private System.Windows.Forms.Label label1;
    }
}