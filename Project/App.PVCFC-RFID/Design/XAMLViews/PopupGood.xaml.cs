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

namespace App.PVCFC_RFID.Design
{
    /// <summary>
    /// Interaction logic for PopupGood.xaml
    /// </summary>
    public partial class PopupGood : UserControl
    {
        public PopupGood(int index, string title = "Detail View")
        {
            InitializeComponent();
            LabelTitle.Content = title;
        }

        private void DataGrid1_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void DataGrid1_LoadingRow(object sender, DataGridRowEventArgs e)
        {

        }
    }
}
