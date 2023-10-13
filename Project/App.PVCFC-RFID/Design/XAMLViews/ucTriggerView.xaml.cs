using App.PVCFC_RFID.Controller;
using System;
using System.Windows;
using System.Windows.Controls;
using Button = System.Windows.Controls.Button;
using UserControl = System.Windows.Controls.UserControl;

namespace App.PVCFC_RFID.Design.XAMLViews
{
    /// <summary>
    /// Interaction logic for ucTriggerView.xaml
    /// </summary>
    public partial class ucTriggerView : UserControl
    {
        public static int Index { get; set; }
        public ucTriggerView():this(Index){}
        public ucTriggerView(int index)
        {
            InitializeComponent();
            DataContext = new TriggerViewModel();
            if (DataContext is TriggerViewModel trgm)
            {
                trgm.Index = index;
            }
        }
        public void NotifyFormClosing()
        {
            CallbackCommand(vm=>vm.CloseForm());    
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
        private void DataGrid1_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
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

        private void ClearDataGrid_Click(object sender, RoutedEventArgs e)
        {
            CallbackCommand(vm => vm.ClearDataRawList());
        }

        private void TriggerClick(object sender, RoutedEventArgs e)
        {
            CallbackCommand(vm => vm.SoftwareTrigger());
        }
    }
}
