using App.PVCFC_RFID.Controller;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace App.PVCFC_RFID.Design.XAMLViews
{
    /// <summary>
    /// Interaction logic for DatabaseSetting.xaml
    /// </summary>
    public partial class DatabaseSetting : UserControl
    {
        public DatabaseSetting(int i)
        {
            InitializeComponent();
            GroupBox1.Header = "Select Database Job" + (i + 1);
            DataContext = new DatabaseSettingVM(i);
        }
        public void CallbackCommand(Action<DatabaseSettingVM> execute)
        {
            try
            {
                if (DataContext is DatabaseSettingVM model)
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
        private void BrowseClick(object sender, RoutedEventArgs e)
        {
            CallbackCommand(vm => vm.GetFilePath());
        }

        private void ButtonReview_Click(object sender, RoutedEventArgs e)
        {

        }
    }
    public class DatabaseSettingVM : ViewModelBase
    {
        public DatabaseSettingVM(int index)
        {
            JobsIndex = index;
        }
        private string _FilePath;

        public string FilePath
        {
            get { return _FilePath; }
            set { _FilePath = value; OnPropertyChanged(); }
        }

        private ObservableCollection<string> _CollectionHeaderCsv;

        public ObservableCollection<string> CollectionHeaderCsv
        {
            get { return _CollectionHeaderCsv; }
            set { _CollectionHeaderCsv = value; OnPropertyChanged(); }
        }

        private int _SelectedPODId;

        public int SelectedPODId
        {
            get { return _SelectedPODId; }
            set { _SelectedPODId = value; OnPropertyChanged(); }
        }

        private int _JobsIndex;

        public int JobsIndex
        {
            get { return _JobsIndex; }
            set { _JobsIndex = value; OnPropertyChanged(); }
        }


        internal void GetFilePath()
        {
            var openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FilePath = openFileDialog.FileName;
            }
            var listHeader = GetCsvHeaders(FilePath);
            CollectionHeaderCsv = new ObservableCollection<string>(listHeader);
            SelectedPODId = 0;
        }

        public List<string> GetCsvHeaders(string csvFilePath)
        {
            var headers = new List<string>();

            using (StreamReader reader = new StreamReader(csvFilePath))
            {
                string firstLine = reader.ReadLine(); 
                if (!string.IsNullOrEmpty(firstLine))
                {
                    headers.AddRange(firstLine.Split(','));
                }
            }
            return headers;
        }

    }
}
