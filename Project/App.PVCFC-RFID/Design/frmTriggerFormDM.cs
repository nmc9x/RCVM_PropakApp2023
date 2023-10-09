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
    public partial class frmTriggerFormDM : Form
    {
        public frmTriggerFormDM(int index)
        {
            InitializeComponent();
            ucTriggerView.Index = index;
            FormClosed += FrmTriggerFormDM_FormClosed;
        }

        private void FrmTriggerFormDM_FormClosed(object sender, FormClosedEventArgs e)
        {
            ucTriggerView.NotifyFormClosing();
        }

    }
}
