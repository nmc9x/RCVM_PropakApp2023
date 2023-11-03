using App.PVCFC_RFID.Controller;
using ML.Common.Controller;
using ML.SDK.DM60X.Model;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace App.PVCFC_RFID.Design.XAMLViews
{
    /// <summary>
    /// Interaction logic for ucTrigger.xaml
    /// </summary>
    public partial class ucTrigger : UserControl
    {
        public ucTrigger(int index)
        {
            InitializeComponent();
            DataContext = new TriggerViewModel(index);
            TriggerViewModel.CustomEvt += DataGridItemsChanged;
            TextBlockTitle.Text = "Trigger Read Data JOB "+(index+1);
        }
        public void CallbackCommand(Action<TriggerViewModel> execute)
        {
            try
            {
                if (DataContext is TriggerViewModel model)
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
        //Event 
        public void NotifyFormClosing()
        {
            CallbackCommand(vm => vm.CloseForm());
        }
        //Data Grid

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
        private void DataGrid1_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataGrid1.Items.Count > 0)
            {
                var lastItem = DataGrid1.Items[DataGrid1.Items.Count - 1];
                DataGrid1.ScrollIntoView(lastItem);
            }
        }
        private void DataGrid1_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }
        private void ClearDataGrid_Click(object sender, RoutedEventArgs e)
        {
            CallbackCommand(vm => vm.ClearDataRawList());
        }
        // COntrol
        private void TriggerClick(object sender, RoutedEventArgs e)
        {
            CallbackCommand(vm => vm.SoftwareTrigger());
        }
       
    }
    public class TriggerViewModel : ViewModelBase
    {

        #region Define
        private int Index;

        private ObservableCollection<GotCodeModel> _CodeList = new ObservableCollection<GotCodeModel>();
        public ObservableCollection<GotCodeModel> CodeList
        {
            get => _CodeList;
            set
            {
                SetProperty(ref _CodeList, value);

            }
        }

        private ImageSource _ImgSrc;
        public ImageSource ImgSrc
        {
            get { return _ImgSrc; }
            set
            {
                if (ImgSrc != value)
                {
                    _ImgSrc = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _TotalValue;

        public string TotalValue
        {
            get { return _TotalValue; }
            set { _TotalValue = value; OnPropertyChanged(); }
        }

        public delegate void CustomEvtHandler(object sender, NotifyCollectionChangedEventArgs e);
        public static event CustomEvtHandler CustomEvt;

        #endregion
        public void RaiseCustomEvent(NotifyCollectionChangedEventArgs e)
        {
            CustomEvt?.Invoke(this, e);
        }
        public TriggerViewModel(int index)
        {
            Index = index;
            var ThreadListenImgData = new Thread(GetImageData);
            ThreadListenImgData.IsBackground = true;
            ThreadListenImgData.Start();

            //var threadGetCode = new Thread(GetCode);
            //threadGetCode.IsBackground = true;
            //threadGetCode.Start();

        
            SharedControlHandler._dispatcher = Dispatcher.CurrentDispatcher;
            SharedControlHandler._dispatcher?.Invoke(() =>
            {
                CodeList = SharedValues.Running.StationList[index].DataTriggerList;

            });
            CodeList.CollectionChanged += CodeList_CollectionChanged;
            TotalValue = _CodeList.Count.ToString();

        }

        private void GetImageData()
        {
            while (true)
            {
                ImgSrc = SharedControlHandler.ImgSrc;
                Thread.Sleep(1);
            }

        }

        private void CodeList_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            RaiseCustomEvent(e);
            TotalValue = _CodeList.Count.ToString();
        }



        internal void CloseForm()
        {
            CodeList.CollectionChanged -= CodeList_CollectionChanged;
            ClearDataRawList();
        }


        internal void ClearDataRawList()
        {
            SharedControlHandler._dispatcher?.Invoke(() =>
            {
                SharedValues.Running.StationList[Index].DataTriggerList.Clear();
                CodeList.Clear();
            });
        }


        internal void SoftwareTrigger()
        {
            SharedControlHandler.isTriggerOn = true;
            var mmf_TriggerClick = new MemoryMapHelper("mmf_TriggerClick" + Index, 1);
            mmf_TriggerClick.WriteData(Encoding.UTF8.GetBytes("1"), 0);
        }
        private void GetCode()
        {
            while (true)
            {
                var mmf_feedbackTrigger = new MemoryMapHelper("mmf_feedbackTrigger" + Index, 1);
                var resFb = Encoding.ASCII.GetString(mmf_feedbackTrigger.ReadData(0, 1));
                switch (resFb)
                {
                    case "1":
                        SharedControlHandler._dispatcher.Invoke(new Action(() =>
                        {
                            if(SharedControlHandler.newCodeItem != null)
                            SharedValues.Running.StationList[Index].DataTriggerList.Add(SharedControlHandler.newCodeItem);
                            mmf_feedbackTrigger.WriteData(Encoding.ASCII.GetBytes("2"), 0);
                        }));
                       
                        break;
                    default:
                        break;
                }
                
                Thread.Sleep(11);
            }
        }
    }
}
