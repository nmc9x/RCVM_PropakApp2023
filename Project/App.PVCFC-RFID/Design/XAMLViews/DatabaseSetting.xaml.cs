using App.PVCFC_RFID.Controller;
using ML.Common.Controller;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading;
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
            var ThreadListTemplate = new Thread(ListenTemplate);
            ThreadListTemplate.IsBackground = true;
            ThreadListTemplate.Start();
            LoadDatabaseFile(index);
        }

        private void ListenTemplate()
        {
            try
            {
                while (true)
                {
                    var mmf_TemplateList = new MemoryMapHelper("mmf_TemplateList" + JobsIndex, 1000);
                   var resultStrList =  Encoding.ASCII.GetString(mmf_TemplateList.ReadData(0, 1000));
                    Thread.Sleep(1);
                }
            }
            catch (Exception)
            {

               
            }
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

        private int _SelectedTemplateId = -1;

        public int SelectedTemplateId
        {
            get { return _SelectedTemplateId; }
            set { _SelectedTemplateId = value; OnPropertyChanged(); }
        }

        private ObservableCollection<string> _TemplateList;

        public ObservableCollection<string> TemplateList
        {
            get { return _TemplateList; }
            set { _TemplateList = value; OnPropertyChanged(); }
        }
        private string _SelectedTemplate;

        public string SelectedTemplate
        {
            get { return _SelectedTemplate; }
            set { _SelectedTemplate = value; OnPropertyChanged(); }
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

        internal void LoadDatabaseFile(int index)
        {
            try
            {
                var listHeader = GetCsvHeaders(SharedValues.Settings.StationList[index].LastPathDatabase);
                CollectionHeaderCsv = new ObservableCollection<string>(listHeader);
            }
            catch (Exception)
            {
                CollectionHeaderCsv = null;
            }
            
        }

        public List<string> GetCsvHeaders(string csvFilePath)
        {
            try
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
            catch (Exception)
            {
                return null;
            }
           
        }

    }
}
