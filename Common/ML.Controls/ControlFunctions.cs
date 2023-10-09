using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.Controls
{
    public class ControlFunctions
    {
        #region Shared functions
        public static void ShowLoading(System.Windows.Forms.Form parentForm, int style = 0)
        {
            switch (style)
            {
                case 0:
                default:
                    frmLoadingScreenStyle3.ShowSplashScreen(parentForm);
                    break;
                case 1:
                    frmLoadingScreen.ShowSplashScreen(parentForm);
                    break;
                case 2:
                    frmLoadingScreenStyle2.ShowSplashScreen(parentForm);
                    break;
            }

        }

        public static void ShowLoading(System.Drawing.Point point, System.Drawing.Size size, int style = 0)
        {
            switch (style)
            {
                case 0:
                default:
                    frmLoadingScreenStyle3.ShowSplashScreen(point, size);
                    break;
                case 1:
                    frmLoadingScreen.ShowSplashScreen(point, size);
                    break;
                case 2:
                    frmLoadingScreenStyle2.ShowSplashScreen(point, size);
                    break;
            }
            
        }

        public static void CloseLoading(int style = 0)
        {
            switch (style)
            {
                case 0:
                default:
                    frmLoadingScreenStyle3.CloseSplash();
                    break;
                case 1:
                    frmLoadingScreen.CloseSplash();
                    break;
                case 2:
                    frmLoadingScreenStyle2.CloseSplash();
                    break;
            }
            
        }

        #endregion//End Shared functions

        #region Invoke
        public static void Invoke(System.Windows.Forms.Form frm, Action a)
        {
            try
            {
                if (frm.InvokeRequired)
                {
                    frm.Invoke((System.Windows.Forms.MethodInvoker)delegate()
                    {
                        a();
                    });
                }
                else
                {
                    a();
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                //System.Windows.Forms.MessageBox.Show("Invoke: " + ex.Message);
#endif
            }
        }

        public static void Invoke(System.Windows.Forms.UserControl uc, Action a)
        {
            try
            {
                if (uc.InvokeRequired)
                {
                    uc.Invoke((System.Windows.Forms.MethodInvoker)delegate()
                    {
                        a();
                    });
                }
                else
                {
                    a();
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                //System.Windows.Forms.MessageBox.Show("Invoke: " + ex.Message);
#endif
            }
        }

        #endregion//End Invoke
    }
}
