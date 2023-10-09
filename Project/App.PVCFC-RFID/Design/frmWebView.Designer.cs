namespace App.PVCFC_RFID.Design
{
    partial class frmWebView
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
            this.webViewControl = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)(this.webViewControl)).BeginInit();
            this.SuspendLayout();
            // 
            // webViewControl
            // 
            this.webViewControl.AllowExternalDrop = true;
            this.webViewControl.CreationProperties = null;
            this.webViewControl.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webViewControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webViewControl.Location = new System.Drawing.Point(0, 0);
            this.webViewControl.Name = "webViewControl";
            this.webViewControl.Size = new System.Drawing.Size(881, 484);
            this.webViewControl.TabIndex = 1;
            this.webViewControl.ZoomFactor = 1D;
            // 
            // frmWebView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 484);
            this.Controls.Add(this.webViewControl);
            this.Name = "frmWebView";
            this.Text = "frmWebView";
            ((System.ComponentModel.ISupportInitialize)(this.webViewControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webViewControl;
    }
}