using App.PVCFC_RFID.Controller;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ucHomePage.xaml
    /// </summary>
    public partial class ucHomePage : UserControl
    {
        private string _Index;

        public string Index
        {
            get { return _Index; }
            set { _Index = value; }
        }
        private ObservableCollection<string> _ItemStation = new ObservableCollection<string>();
        public ObservableCollection<string> ItemStation
        {
            get => _ItemStation;
            set { _ItemStation = value; }   
        }

        

        public ucHomePage()
        {
            InitializeComponent();
            DataContext = this;
            CreateItemJob(SharedControlHandler.NumberOfStation);
            Index = "2";
        }

        private void CreateItemJob(int numStation)
        {
            for (int i = 0; i < numStation; i++)
            {
                //create
                ucCurrentJobs.Index = i;
                var job = new ucCurrentJobs();
                job.StationTagName = "Station " + (i+1).ToString();
                var grid1 = new Grid();
                grid1.Children.Add(job);
                grid1.MouseUp += Grid1_MouseUp;
                StackPanelJob.Children.Add(grid1);
                ItemStation.Add("Station " + (i + 1));
            }
        }

        private void Grid1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (sender is Grid selectedGrid)
            {
                // Đặt màu sắc nổi bật khi item được chọn
                selectedGrid.Background = new BrushConverter().ConvertFrom("#abb7c9") as Brush;

                // Đặt lại màu sắc của các Grid khác (nếu cần)
                foreach (var child in StackPanelJob.Children)
                {
                    if (child is Grid otherGrid && otherGrid != selectedGrid)
                    {
                        otherGrid.Background = Brushes.Transparent;
                    }
                }
            }
        }

        private void ucCurrentJob_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
