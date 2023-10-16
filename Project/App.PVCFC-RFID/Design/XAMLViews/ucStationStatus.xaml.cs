using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for ucStationStatus.xaml
    /// </summary>
    public partial class ucStationStatus : UserControl
    {
        public int SignalColorId { get; set; }
        public static int StationID { get; set; }
        public ucStationStatus()
        {
            InitializeComponent();
            DataContext = this;
            InitUIParameter();
            // SignalColorId = 3;
        }
        private void InitUIParameter()
        {
            TextBoxStationId.Text = StationID.ToString();
        }
    }
}
