using App.PVCFC_RFID.Controller;
using ML.Common.Controller;
using ML.SDK.DM60X.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
        private MemoryMapHelper mmf_ResetDataOption;
        public event EventHandler ClearEvent;
        public PopupDetails(int index,int kind, string title = "Detail View")
        {
            InitializeComponent();
            _Index=index;
            _Kind=kind;
            LabelTitle.Content = " JOB " + index +": "+ title;
            this.DataContext = new PopupDetailsVM(index,kind);
            mmf_ResetDataOption = new MemoryMapHelper("mmf_ResetDataOption" + index, 1);

        }
        public void CallbackCommand(Action<PopupDetailsVM> execute)
        {
            try
            {
                if (DataContext is PopupDetailsVM model)
                {
                    execute.Invoke(model);
                }
                else
                {
                    return;
                }
            }
            catch (Exception)
            {
                return;
            }

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
        private void DataGridItemsChanged(object sender, NotifyCollectionChangedEventArgs e)
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
        private void ControlDataGridButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            switch (button.Name)
            {
                case "FirstButton":
                    DataGrid1.SelectedIndex = 0;
                    DataGrid1.ScrollIntoView(DataGrid1.SelectedItem);
                    break;
                case "BackButton":
                    if (DataGrid1.SelectedIndex > 0)
                    {
                        DataGrid1.SelectedIndex -= 1;
                        DataGrid1.ScrollIntoView(DataGrid1.SelectedItem);
                    }
                    break;
                case "NextButton":
                    if (DataGrid1.SelectedIndex < DataGrid1.Items.Count - 1)
                    {
                        DataGrid1.SelectedIndex += 1;
                        DataGrid1.ScrollIntoView(DataGrid1.SelectedItem);
                    }
                    break;
                case "LastButton":
                    DataGrid1.SelectedIndex = DataGrid1.Items.Count - 1;
                    DataGrid1.ScrollIntoView(DataGrid1.SelectedItem);
                    break;
                default: break;
            }
        }
       
        private void DataGrid1_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }
        private void ClearDataGrid_Click(object sender, RoutedEventArgs e)
        {
            var Data = _Index.ToString() + _Kind.ToString();

            ClearEvent?.Invoke(Data, EventArgs.Empty);
            switch (_Kind)
            {
                case 1: // total
                    mmf_ResetDataOption.WriteData(Encoding.ASCII.GetBytes("1"),0);
                    break;
                case 3: // printed
                    mmf_ResetDataOption.WriteData(Encoding.ASCII.GetBytes("3"), 0);
                    break;
                case 2: // good
                    mmf_ResetDataOption.WriteData(Encoding.ASCII.GetBytes("2"), 0);
                    break;
                case 4: // fail
                    mmf_ResetDataOption.WriteData(Encoding.ASCII.GetBytes("4"), 0);
                    break;
                default:
                    break;
            }
            
            CallbackCommand(vm => vm.ClearDataList());
        }
       
    }
    public class PopupDetailsVM:ViewModelBase
    {
        private int Index { get; set; }
        private int Kind { get; set; }

        private ObservableCollection<GotCodeModel> _CodeList = new ObservableCollection<GotCodeModel>();
        public ObservableCollection<GotCodeModel> CodeList
        {
            get => _CodeList;
            set => SetProperty(ref _CodeList, value);
        }

        public PopupDetailsVM(int index, int kind)
        {
            Index = index;
            Kind = kind;
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
        }

        internal void ClearDataList()
        {
            SharedControlHandler._dispatcher.Invoke(new Action(() =>
            {
                switch (Kind)
                {
                    case 1:
                        SharedValues.Running.StationList[Index].DataRawList.Clear();
                        CodeList.Clear();
                        break;
                    case 2:
                        SharedValues.Running.StationList[Index].DataGoodList.Clear();
                        CodeList.Clear();
                        break;
                    case 3:
                        SharedValues.Running.StationList[Index].DataPrintedList.Clear();
                        CodeList.Clear();
                        break;
                    case 4:
                        SharedValues.Running.StationList[Index].DataFailList.Clear();
                        CodeList.Clear();
                        break;
                    default:
                        break;
                }
            }));
        }
    }
}
