using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ML.Controls
{
    /// <summary>
    /// @Author: Linh.Tran
    /// </summary>
    public partial class frmLoadingScreenStyle3 : Form
    {
        #region Properties
        //The type of form to be displayed as the splash screen.
        private static frmLoadingScreenStyle3 _splashForm;
        private static Thread _splashThread;
        private static bool _IsWaitOne = false;
        //Delegate for cross thread call to close
        private delegate void CloseDelegate();
        //private GifImage gifImage;
        public static Color SkinColor = Color.FromArgb(66, 155, 214);
        private bool _IsClosed = false;//Linh.Tran_210524
        #endregion//End Properties

        public frmLoadingScreenStyle3()
        {
            InitializeComponent();
            InitControls();
            InitEvents();
        }

        private void InitControls()
        {
            new Thread(() =>
            {
                while (!_IsClosed)
                {
                    ControlFunctions.Invoke(this, new Action(() =>
                        {
                            this.TopMost = true;
                        }));
                    Thread.Sleep(1);
                }

            }).Start();
        }

        private void InitEvents()
        {
            this.FormClosed+=frmLoadingScreen_FormClosed;
        }

        private void frmLoadingScreen_FormClosed(object sender, EventArgs e)
        {
            _IsClosed = true;
        }

        static public void ShowSplashScreen(Form parentForm)
        {
            _IsWaitOne = true;
            if (_splashThread == null)
            {
                // show the form in a new thread            
                _splashThread = new Thread(() => DoShowSplash(parentForm.Location, parentForm.Size));
                _splashThread.IsBackground = true;
                _splashThread.Start();
            }
        }

        static public void ShowSplashScreen(Point point, Size size)
        {
            _IsWaitOne = true;
            if (_splashThread == null)
            {
                // show the form in a new thread            
                _splashThread = new Thread(() => DoShowSplash(point, size));
                _splashThread.IsBackground = true;
                _splashThread.Start();
            }
        }

        private static void DoShowSplash(Point point, Size size)
        {
            if (_splashForm == null)
            {
                _splashForm = new frmLoadingScreenStyle3();
                //_splashForm.lblComment.Text = "";
                _splashForm.StartPosition = FormStartPosition.Manual;
                _splashForm.Location = new Point((point.X + (size.Width - _splashForm.Size.Width) / 2), (point.Y + (size.Height - _splashForm.Size.Height) / 2));
                _splashForm.TopMost = true;
            }
            //
            _IsWaitOne = false;
            Application.Run(_splashForm);
        }

        // Close the splash (Loading...) screen    
        public static void CloseSplash()
        {
            try
            {
                int i = 0;
                while (_IsWaitOne && i < 20)
                {
                    Thread.Sleep(100);
                    i++;
                }

                if (_splashForm == null)
                {
                    return;
                }
                // Need to call on the thread that launched this splash        
                if (_splashForm != null)
                {
                    if (_splashForm.InvokeRequired)
                    {
                        _splashForm.Invoke((System.Windows.Forms.MethodInvoker)delegate()
                        {
                            _splashThread = null;
                            if (_splashForm != null) _splashForm.Close();
                            _splashForm = null;
                            Application.ExitThread();
                        });
                    }
                    else
                    {
                        _splashThread = null;
                        if (_splashForm != null) _splashForm.Close();
                        _splashForm = null;
                        Application.ExitThread();
                    }
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine(ex.Message);
#endif
            }
        }
    }
}
