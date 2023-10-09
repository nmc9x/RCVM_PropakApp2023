using System.Windows.Forms;

namespace App.PVCFC_RFID.Design
{
    public partial class frmSettingDM60X : Form
    {
        public frmSettingDM60X(int index)
        {
            InitializeComponent();
            this.ucSettingDM60X1.Index =  index;
        }
       
    }
}
