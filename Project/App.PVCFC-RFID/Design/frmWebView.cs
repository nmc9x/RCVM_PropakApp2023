using App.PVCFC_RFID.Controller;
using ML.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.PVCFC_RFID.Design
{
    public partial class frmWebView : Form
    {
        private string _URL = "";
        public frmWebView()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.rfid;
            this.MinimumSize = new Size(1024, 768);
        }

        public frmWebView(int index, string url)
        {
            _URL = url;
            InitializeComponent();
            SharedFunctions.Invoke(this, new Action(() =>
            {
                this.Icon = Properties.Resources.rfid;
                this.Text = SharedFunctions.GetStationName(index) + " - " + url;
                InitializeWebView();
                webViewControl.NavigationCompleted += webViewControl_NavigationCompleted;
            }));
        }

        private async void InitializeWebView()
        {
            await webViewControl.EnsureCoreWebView2Async(null);
            try
            {

                //webViewControl.Source = new Uri("https://169.254.76.81");
                webViewControl.Source = new Uri(_URL);
            }
            catch (Exception ex)
            {
                //webViewControl.Source = new Uri("https://169.254.76.81");
                webViewControl.Source = new Uri("Https://Notfound.ml");
            }
        }

        private void webViewControl_NavigationCompleted(object sender, EventArgs  e)
        {
            ControlFunctions.CloseLoading();
        }


        #region Fixed flickering forms - https://www.youtube.com/watch?v=_h-UXxp3cd0&t=116s

        /// <summary>
        /// Linh.Tran
        /// On 190904
        /// Methods override is fix error Controls in usercontrol flicker while usercontrol visiblity changes
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        #endregion//End Fixed flickering forms
    }
}
