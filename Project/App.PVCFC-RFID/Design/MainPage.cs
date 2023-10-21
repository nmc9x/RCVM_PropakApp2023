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
using System.Windows.Media;

namespace App.PVCFC_RFID.Design
{
    public partial class MainPage : Form
    {
       
        private double initialWidth;
        private double initialHeight;
        public static ScaleTransform ScaleTransform;
        public MainPage()
        {

            InitializeComponent();
            this.initialWidth = this.Width;
            this.initialHeight = this.Height;
            this.SizeChanged += MainPage_SizeChanged;
            elementHost1.Child = new ucMain();
           
        }

        private void MainPage_SizeChanged(object sender, EventArgs e)
        {
            double xScale = this.Width / initialWidth/1.5;
            double yScale = this.Height / initialHeight/1.5;

            ScaleTransform = new ScaleTransform(xScale, yScale);
        }
    }
}
