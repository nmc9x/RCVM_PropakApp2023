﻿using App.PVCFC_RFID.Design.XAMLViews;
using ML.Common.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        private static string ProcessName_1 = Properties.Settings.Default.DeviceTransferName;
        private static string ProcessName_2 = "ML.DeviceTransfer.CVX450";
        public static event EventHandler CloseMainPageEvent;
        public MainPage()
        {
            KillProcess();
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
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
            mainChild.RestartAppEvent += MainChild_RestartAppEvent;
            UpdateScaleTransform();
            this.FormClosed += MainPage_FormClosed;
            
        }

        private void MainChild_RestartAppEvent(object sender, EventArgs e)
        {
            Process.Start(Application.ExecutablePath);
            Application.Exit();
        }

        private void MainPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            KillProcess();
            CloseMainPageEvent?.Invoke(this, EventArgs.Empty);
        }
        void KillProcess()
        {
            foreach (var process in Process.GetProcessesByName(ProcessName_1))
            {
                process.Kill();
            }
            foreach (var process in Process.GetProcessesByName(ProcessName_2))
            {
                process.Kill();
            }
        }
        #region Open Detail Dialog Evennt
        private void MainChild_ButtonPrintedClickEvent(object sender, EventArgs e)
        {
            var index = (int)sender;
            frmDetailList pug = new frmDetailList(index, 3);
            pug.StartPosition = FormStartPosition.CenterParent;
            pug.ShowDialog(this);
            pug.Dispose();
        }

        private void MainChild_ButtonTotalClickEvent(object sender, EventArgs e)
        {
            var index = (int)sender;
            frmDetailList pug = new frmDetailList(index, 1);
            pug.StartPosition = FormStartPosition.CenterParent;
            pug.ShowDialog(this);
            pug.Dispose();
        }

        private void MainChild_ButtonFailClickEvent(object sender, EventArgs e)
        {
            var index = (int)sender;
            frmDetailList pug = new frmDetailList(index, 4);
            pug.StartPosition = FormStartPosition.CenterParent;
            pug.ShowDialog(this);
            pug.Dispose();
        }

        private void MainChild_ButtonGoodClickEvent(object sender, EventArgs e)
        {
            var index = (int)sender;
            frmDetailList pug = new frmDetailList(index, 2);
            pug.StartPosition = FormStartPosition.CenterParent;
            pug.ShowDialog(this);
            pug.Dispose();


        }
        #endregion


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
            double xScale = this.Width / initialWidth / 2;
            double yScale = this.Height / initialHeight / 2;
            ScaleTransform = new ScaleTransform(xScale, yScale);
        }
    }
}
