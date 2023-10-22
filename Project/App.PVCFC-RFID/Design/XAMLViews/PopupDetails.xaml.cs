using App.PVCFC_RFID.Controller;
using ML.SDK.DM60X.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
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
    public partial class PopupDetails : UserControl
    {
        private int _Index;
        private int _Kind;
        public PopupDetails(int index,int kind, string title = "Detail View")
        {
            InitializeComponent();
            _Index=index;
            _Kind=kind;
            LabelTitle.Content = title;
            this.DataContext = new PopupDetailsVM(index,kind);
           
     
        }

        private void DataGrid1_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataGrid1.Items.Count > 0)
            {
                var border = VisualTreeHelper.GetChild(DataGrid1, 0) as Decorator;
                if (border != null)
                {
                    var scroll = border.Child as ScrollViewer;
                    if (scroll != null) scroll.ScrollToEnd();
                }
            }
        }

        private void DataGrid1_LoadingRow(object sender, DataGridRowEventArgs e)
        {

        }
    }
    public class PopupDetailsVM:ViewModelBase
    {
        private ObservableCollection<GotCodeModel> _CodeList = new ObservableCollection<GotCodeModel>();
        public ObservableCollection<GotCodeModel> CodeList
        {
            get => _CodeList;
            set => SetProperty(ref _CodeList, value);
        }

        public PopupDetailsVM(int index, int kind)
        {
            SharedControlHandler._dispatcher.Invoke(new Action(() =>
            {
                switch (kind)
                {
                    case 1:
                        CodeList = SharedValues.Running.StationList[index].DataRawList;
                        break;
                    case 2:
                        CodeList = SharedValues.Running.StationList[index].DataGoodList;
                        break;
                    case 3:
                        CodeList = SharedValues.Running.StationList[index].DataPrintedList;
                        break;
                    case 4:
                        CodeList = SharedValues.Running.StationList[index].DataFailList;
                        break;
                    default:
                        break;
                }
            }));
           
            //SharedControlHandler._dispatcher?.Invoke(() =>
            //{
            //    CodeList = SharedValues.Running.StationList[index].DataRawList;
            //});
            //SharedControlHandler.DataRawListChanged += OnDataRawListChanged;
            //CodeList.CollectionChanged += CodeList_CollectionChanged;
        }
    }
}
