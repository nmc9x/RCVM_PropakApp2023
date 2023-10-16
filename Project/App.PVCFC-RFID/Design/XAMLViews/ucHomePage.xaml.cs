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

        public ucHomePage()
        {
            InitializeComponent();
            DataContext = this;
            CreateItemJob(12);
            Index = "2";
        }

        private void CreateItemJob(int numStation)
        {
            for (int i = 0; i < numStation; i++)
            {
                //create
                ucCurrentJobs.Index = i;
                ucCurrentJobs job = new ucCurrentJobs();
                Grid grid1 = new Grid();
                grid1.Children.Add(job);
                grid1.MouseUp += Grid1_MouseUp;
                StackPanelJob.Children.Add(grid1);
                // Add to combobox
                ComboBoxItemJob.Items.Add("Station " + (i + 1));
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
