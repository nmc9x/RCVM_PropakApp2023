using App.PVCFC_RFID.Controller;
using System;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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

        // COntrol
        private void TriggerClick(object sender, RoutedEventArgs e)
        {
            CallbackCommand(vm => vm.SoftwareTrigger());
        }
        private void ClearDataGrid_Click(object sender, RoutedEventArgs e)
        {
            CallbackCommand(vm => vm.ClearDataRawList());
        }
    }
}
