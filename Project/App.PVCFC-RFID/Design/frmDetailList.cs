using App.PVCFC_RFID.Design.XAMLViews;
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
    public partial class frmDetailList : Form
    {
        public static event EventHandler ClearClickEvt;
        public frmDetailList(int index,int kind, string title = "")
        {
            InitializeComponent();
            switch (kind)
            {
                case 1:
                    title = "Total Product List";
                    break;
                case 2:
                    title = "Good Product List";
                    break;
                case 3:
                    title = "Printed Product List";
                    break;
                case 4:
                    title = "Fail Product List";
                        break;
                default:
                    break;
            }
            var objectUc = new PopupDetails(index, kind, title);
            elementHost1.Child = objectUc;
            objectUc.ClearEvent += ObjectUc_ClearEvent;

            this.FormClosed += FrmDetailList_FormClosed;
        }

        private void ObjectUc_ClearEvent(object sender, EventArgs e)
        {

            ClearClickEvt?.Invoke(sender, e);
        }

        private void FrmDetailList_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
