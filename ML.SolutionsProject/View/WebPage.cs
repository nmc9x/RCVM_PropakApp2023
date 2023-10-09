using System;
using System.Windows.Forms;
namespace ML.SolutionsProject.View
{
    public partial class WebPage : Form
    {
        public WebPage()
        {
            InitializeComponent();
            this.SizeChanged += WebPage_SizeChanged;
            InitializeWebView();
        }

        private void WebPage_SizeChanged(object sender, EventArgs e)
        {
            webViewControl.Height = this.Height -20;
            webViewControl.Padding = new System.Windows.Forms.Padding(10);
            webViewControl.Width = this.Width - 20;
           
        }

        private async void InitializeWebView()
        {
            await webViewControl.EnsureCoreWebView2Async(null);
            webViewControl.Source = new Uri("http://169.254.76.81");
        }
    }
}
