using App.PVCFC_RFID.Design.XAMLViews;
using ML.Common.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.PVCFC_RFID.Design
{
    public partial class MainPage : Form
    {
        public static int MainPageHeight;
        public MainPage()
        {

            InitializeComponent();
            MainPageHeight = this.Height;
            this.SizeChanged += MainPage_SizeChanged;
            elementHost1.Child = new ucMain();
           
        }

        private void MainPage_SizeChanged(object sender, EventArgs e)
        {
            MainPageHeight = this.Height;
        }
    }
}
