using System.Windows.Forms;

namespace App.PVCFC_RFID.Design
{
    public partial class frmSettingDM60X : Form
    {
        public static int Index { get; set; }
        public frmSettingDM60X():this(Index)
        {
           
        }
        public frmSettingDM60X(int index)
        {
            ucSettingDM60X.Index = index;
            InitializeComponent();
            
        }



    }
}
