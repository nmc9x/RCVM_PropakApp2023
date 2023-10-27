using App.PVCFC_RFID.Controller;
using App.PVCFC_RFID.DataType;
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
            GroupBox1.Header = "JOB " + (index+1) + " CONFIG";
            DataContext = new ucJobItemsVM();
        }   
    }
    public class ucJobItemsVM : ViewModelBase
    {

        private string _CamIP;
        public string CamIP
        {
            get { return _CamIP; }
            set { _CamIP = value; OnPropertyChanged(); }
        }

        private string _CamPort;
        public string CamPort
        {
            get { return _CamPort; }
            set { _CamPort = value; OnPropertyChanged(); }
        }

        private string _PrinterIP;
        public string PrinterIP
        {
            get { return _PrinterIP; }
            set { _PrinterIP = value; OnPropertyChanged(); }
        }

        private string _PrinterPort;
        public string PrinterPort
        {
            get { return _PrinterPort; }
            set { _PrinterPort = value; OnPropertyChanged(); }
        }

        private int _SelectedModelCam;
        public int SelectedModelCam
        {
            get => _SelectedModelCam;
            set { _SelectedModelCam = value; OnPropertyChanged(); }
        }

    }
}
