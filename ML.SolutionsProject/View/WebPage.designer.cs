namespace ML.SolutionsProject.View
{
    partial class WebPage
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
            // webView21
            // 
            this.webViewControl.AllowExternalDrop = true;
            this.webViewControl.CreationProperties = null;
            this.webViewControl.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webViewControl.Location = new System.Drawing.Point(12, 12);
            this.webViewControl.Name = "webView21";
            this.webViewControl.Size = new System.Drawing.Size(767, 426);
            this.webViewControl.TabIndex = 0;
            this.webViewControl.ZoomFactor = 1D;
            // 
            // WebPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.webViewControl);
            this.Name = "WebPage";
            this.Text = "WebPage";
            ((System.ComponentModel.ISupportInitialize)(this.webViewControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webViewControl;
    }
}