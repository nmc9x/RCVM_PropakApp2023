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
        public frmDetailList(int index,int kind, string title)
        {
            InitializeComponent();
            elementHost1.Child = new PopupDetails(index,kind,title);
            this.FormClosed += FrmDetailList_FormClosed;
        }

        private void FrmDetailList_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
