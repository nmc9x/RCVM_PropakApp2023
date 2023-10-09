using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ML.Controls
{
    public class MLDateTimePicker: DateTimePicker
    {
        private const int SWP_NOMOVE = 0x0002;
        private const int DTM_First = 0x1000;
        private const int DTM_GETMONTHCAL = DTM_First + 8;
        private const int MCM_GETMINREQRECT = DTM_First + 9;

        [DllImport("uxtheme.dll")]
        private static extern int SetWindowTheme(IntPtr hWnd, string appName, string idList);
        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, ref RECT lParam);
        [DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter,
        int X, int Y, int cx, int cy, int uFlags);
        [DllImport("User32.dll")]
        private static extern IntPtr GetParent(IntPtr hWnd);
        [StructLayout(LayoutKind.Sequential)]
        private struct RECT { public int L, T, R, B; }
        protected override void OnDropDown(EventArgs eventargs)
        {
            if (_IsShowCalendarButton)//Linh.Tran_210628
            {
                var hwndCalendar = SendMessage(this.Handle, DTM_GETMONTHCAL, 0, 0);
                SetWindowTheme(hwndCalendar, string.Empty, string.Empty);
                var r = new RECT();
                SendMessage(hwndCalendar, MCM_GETMINREQRECT, 0, ref r);
                var hwndDropDown = GetParent(hwndCalendar);
                SetWindowPos(hwndDropDown, IntPtr.Zero, 0, 0,
                    r.R - r.L + 6, r.B - r.T + 6, SWP_NOMOVE);
                base.OnDropDown(eventargs);
            }
        }

        #region Properties
        public bool ShowKeyboard = true;
        private bool isDropDown = false;
        private string _TitleName = "";
        public string TitleName
        {
            get { return _TitleName; }
            set { _TitleName = value; }
        }

        //Linh.Tran_210628
        private bool _IsShowCalendarButton = true;
        public bool IsShowCalendarButton
        {
            get { return _IsShowCalendarButton; }
            set { _IsShowCalendarButton = value; }
        }
        #endregion//End Properties
        public MLDateTimePicker()
        {
            this.MouseDown += TouchMaskedTextBox_Click;
            this.DropDown+=TouchDateTimePicker_DropDown;
            //
        }

        private string _DatetimeMask = "dd/MM/yyyy HH:mm:ss";
        public string DatetimeMask
        {
            get { return _DatetimeMask; }
            set { _DatetimeMask = value; }
        }

        #region Events
        private void TouchDateTimePicker_DropDown(object sender, EventArgs e)
        {
            isDropDown = true;
        }

        private void TouchMaskedTextBox_Click(object sender, EventArgs e)
        {
            //if (ShowKeyboard && !isDropDown)
            //{
            //    frmNumpad frm = new frmNumpad(this, _TitleName, datetimeMask:_DatetimeMask);
            //    Control parent = this;
            //    while (!(parent is Form) && parent.Parent != null)
            //    {
            //        parent = parent.Parent;
            //    }
            //    frm.StartPosition = FormStartPosition.CenterScreen;
            //    //frm.Show();
            //    frm.ShowDialog(); //BringToFront();//Linh.Tran_200105
            //}
            //isDropDown = false;
        }

        #endregion//End Events

        public void Enter()
        {
            SendKeys.Send("{ENTER}");
        }
    }
}
