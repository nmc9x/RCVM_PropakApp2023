using App.PVCFC_RFID.Design.XAMLViews;
using ML.Common.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
        public static event EventHandler ScaleTransformChanged;
        public MainPage()
        {

            InitializeComponent();
            this.initialWidth = this.Width;
            this.initialHeight = this.Height;
            this.SizeChanged += MainPage_SizeChanged;
            this.Resize += MainPage_Resize;
            var mainChild = new ucMain();
            elementHost1.Child = mainChild;
            mainChild.ButtonTotalClickEvent += MainChild_ButtonTotalClickEvent;
            mainChild.ButtonGoodClickEvent += MainChild_ButtonGoodClickEvent;
            mainChild.ButtonFailClickEvent += MainChild_ButtonFailClickEvent;
            mainChild.ButtonPrintedClickEvent += MainChild_ButtonPrintedClickEvent;
            UpdateScaleTransform();
        }

        private void MainChild_ButtonPrintedClickEvent(object sender, EventArgs e)
        {
            var index = (int)sender;
            frmDetailList pug = new frmDetailList(index, 3, "Printed Product List");
            pug.StartPosition = FormStartPosition.CenterParent;
            pug.ShowDialog(this);
        }

        private void MainChild_ButtonTotalClickEvent(object sender, EventArgs e)
        {
            var index = (int)sender;
            frmDetailList pug = new frmDetailList(index, 1, "Total Product List");
            pug.StartPosition = FormStartPosition.CenterParent;
            pug.ShowDialog(this);
        }

        private void MainChild_ButtonFailClickEvent(object sender, EventArgs e)
        {
            var index = (int)sender;
            frmDetailList pug = new frmDetailList(index, 4, "Fail Product List");
            pug.StartPosition = FormStartPosition.CenterParent;
            pug.ShowDialog(this);
        }

        private void MainChild_ButtonGoodClickEvent(object sender, EventArgs e)
        {
            var index = (int)sender;
            frmDetailList pug = new frmDetailList(index, 2, "Good Product List");
            pug.StartPosition = FormStartPosition.CenterParent;
            pug.ShowDialog(this);
        }

        private void MainPage_Resize(object sender, EventArgs e)
        {
            UpdateScaleTransform();
            ScaleTransformChanged?.Invoke(this, EventArgs.Empty);
        }

       
        private void MainPage_SizeChanged(object sender, EventArgs e)
        {
            UpdateScaleTransform();
        }
        private void UpdateScaleTransform()
        {
            double xScale = this.Width / initialWidth / 1.5;
            double yScale = this.Height / initialHeight / 1.5;
            ScaleTransform = new ScaleTransform(xScale, yScale);
        }
    }
}
