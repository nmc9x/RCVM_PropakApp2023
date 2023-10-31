using Microsoft.Web.WebView2.Core;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace App.PVCFC_RFID.Design.XAMLViews
{
    /// <summary>
    /// Interaction logic for WebControl.xaml
    /// </summary>
    public partial class WebControl : UserControl
    {
        private string _IP;
        public WebControl(string IP)
        {
            _IP = IP;
            InitializeComponent();
            webView.EnsureCoreWebView2Async();
            webView.CoreWebView2InitializationCompleted += WebView_CoreWebView2InitializationCompleted;
            MainPage.CloseMainPageEvent += MainPage_CloseMainPageEvent;
        }

        private void MainPage_CloseMainPageEvent(object sender, EventArgs e)
        {
            webView?.Dispose();
        }

        private void WebView_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            if (e.IsSuccess)
            {
                webView.CoreWebView2.Navigate($"http://{_IP}");
            }
            else
            {
                MessageBox.Show($"WebView initialization failed: {e.InitializationException}");
            }
        }
    }
}
