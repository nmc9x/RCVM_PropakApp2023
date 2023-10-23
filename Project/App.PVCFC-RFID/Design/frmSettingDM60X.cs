using System.Windows.Forms;

namespace App.PVCFC_RFID.Design
{
    public partial class frmSettingDM60X : Form
    {
     
        public frmSettingDM60X(int index)
        {
            InitializeComponent();
            this.elementHost1.Child = new ucSettingDM60X(index);
        }
       



    }
}
