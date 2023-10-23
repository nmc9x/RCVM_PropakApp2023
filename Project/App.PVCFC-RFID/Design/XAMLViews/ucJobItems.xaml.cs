using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace App.PVCFC_RFID.Design.XAMLViews
{
    /// <summary>
    /// Interaction logic for ucJobItems.xaml
    /// </summary>
    public partial class ucJobItems : UserControl
    {
     

        public ucJobItems(int index)
        {
            InitializeComponent();
            GroupBox1.Header = "Job " + index + " Setting";
        }   
    }
}
