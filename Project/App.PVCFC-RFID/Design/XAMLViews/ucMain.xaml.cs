using App.PVCFC_RFID.Controller;
using App.PVCFC_RFID.Controller.ViewModels;
using App.PVCFC_RFID.Properties;
using Microsoft.VisualBasic.FileIO;
using ML.Common.Controller;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;



namespace App.PVCFC_RFID.Design.XAMLViews
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class ucMain : UserControl
    {
        #region Properties
        [JsonProperty]
        private List<DatabaseSetting> listucDB = new List<DatabaseSetting>();
        [JsonProperty]
        private List<ucJobItems> listJob = new List<ucJobItems>();

        private List<ucCurrentStation> listCurStation = new List<ucCurrentStation>();

        private List<string> listPathDb = new List<string>();
        #endregion

        private System.Windows.Point scrollStartPoint;
        private double scrollStartOffset;
        private static int _TotalStation = SharedControlHandler.NumberOfStation;

        #region ModelWindowClick
        public delegate void ButtonTotalClickHandler(object sender, EventArgs e);
        public event ButtonTotalClickHandler ButtonTotalClickEvent;

        public delegate void ButtonGoodClickHandler(object sender, EventArgs e);
        public event ButtonGoodClickHandler ButtonGoodClickEvent;

        public delegate void ButtonPrintedClickHandler(object sender, EventArgs e);
        public event ButtonPrintedClickHandler ButtonPrintedClickEvent;

        public delegate void ButtonFailClickHandler(object sender, EventArgs e);
        public event ButtonFailClickHandler ButtonFailClickEvent;

        public event EventHandler RestartAppEvent;
        #endregion

        public ucMain()
        {

            InitializeComponent();

            this.SizeChanged += UcCurrentStation_SizeChanged;
            MainPage.ScaleTransformChanged += MainPage_ScaleTransformChanged;
            UpdateScaleTransform();
            DataContext = new MainTabViewModel();
            InitStation();
            LoadLastValues();


        }



        #region Utility Function

        // Load Saved Value
        private void LoadLastValues()
        {
            // Job Load
            int i = 0;
            foreach (var item in listJob)
            {
                var viewModel = (ucJobItemsVM)item.DataContext;

                switch (SharedValues.Settings.StationList[i].CameraModel)
                {
                    case DataType.StationType.COGNEX_DATAMAN:
                        viewModel.CamIP = SharedValues.Settings.StationList[i].DMCamera.IPAddress;
                        viewModel.CamPort = SharedValues.Settings.StationList[i].DMCamera.Port;
                        viewModel.SelectedModelCam = 0;
                        viewModel.PrinterIP = SharedValues.Settings.StationList[i].DMCamera.PrinterIP;
                        viewModel.PrinterPort = SharedValues.Settings.StationList[i].DMCamera.PrinterPort;
                        break;
                    case DataType.StationType.KEYENCE:
                        break;
                }

                i++;
            }

            // DB Load
            int j = 0;
            foreach (var item in listucDB)
            {
                var viewModel = (DatabaseSettingVM)item.DataContext;
                viewModel.FilePath = SharedValues.Settings.StationList[j].LastPathDatabase;
                viewModel.SelectedTemplateId = SharedValues.Settings.StationList[j].LastSelectedIndexTemplate;
                viewModel.SelectedPODId = SharedValues.Settings.StationList[j].LastSeletedIndexColumn;
                j++;
            }
        }

        #region Init Station
        private void InitStation()
        {
            for (int i = 0; i < _TotalStation; i++)
            {
                InitUIStationStatus(i);
                InitItemCombobox(i);
                InitDeviceTransferStations(i);
                InitJob(i);
                InitDbItem(i);
            }
            SharedControlHandler.InitDeviceTransfer();

        }
        private void InitUIStationStatus(int i)
        {
            ucStationStatus.StationID = i + 1;
            var stationStatusUC = new ucStationStatus(i);
            StackPanelStatus.Children.Add(stationStatusUC);
        }
        private void InitItemCombobox(int i)
        {
            ComboboxStation.FontSize = 25;
            ComboboxStation.Items.Add("JOB " + (i + 1));

        }
        private List<Grid> listGridCover = new List<Grid>();
        private void InitDeviceTransferStations(int i)
        {

            var ucStation = new ucCurrentStation(i);

            ucStation.BtnDetailTotal.Name = "BtnDetailTotal" + i;
            ucStation.BtnDetailGood.Name = "BtnDetailGood" + i;
            ucStation.BtnDetailPrinted.Name = "BtnDetailPrinted" + i;
            ucStation.BtnDetailFail.Name = "BtnDetailFail" + i;

            ucStation.BtnDetailTotal.Click += BtnDetailTotal_Click;
            ucStation.BtnDetailGood.Click += BtnDetailGood_Click;
            ucStation.BtnDetailPrinted.Click += BtnDetailPrinted_Click;
            ucStation.BtnDetailFail.Click += BtnDetailFail_Click;
            ucStation.Margin = new Thickness(10);

            var gridCover = new Grid();
            gridCover.Background = System.Windows.Media.Brushes.Transparent;
            gridCover.Name = "GridCover" + i;
            gridCover.Children.Add(ucStation);
            gridCover.MouseLeftButtonDown += GridCover_MouseLeftButtonDown;

            Grid.SetRow(gridCover, i);
            GridStation.Children.Add(gridCover);

            listCurStation.Add(ucStation);
            listGridCover.Add(gridCover);

            //SharedControlHandler.KillDeviceTransferBefore();


        }



        private void InitTriggerTab(int index)
        {
            if (index < 0)
            {
                index = 0;
            };
            var ucTrigger = new ucTrigger(index);

            GridTrigger.Children.Clear();
            GridTrigger.Children.Add(ucTrigger);


        }
        private void InitJob(int i)
        {
            var ucJob = new ucJobItems(i);
            ucJob.BtnSetCam.Click += BtnSetCam_Click;
            ucJob.BtnSetPrinter.Click += BtnSetPrinter_Click;
            ucJob.BtnDBSet.Click += BtnDBSet_Click;
            //ucJob.BtnWebPrinter.Click += BtnWebPrinter_Click;
            ucJob.BtnSetPrinter.Name = "BtnSetPrinter" + i;
            ucJob.BtnSetCam.Name = "BtnSetCam" + i;
            var rowDef = new RowDefinition();
            GridItemJob.RowDefinitions.Add(rowDef);
            Grid.SetRow(ucJob, i);
            GridItemJob.Children.Add(ucJob);
            listJob.Add(ucJob);
        }

        private void BtnDBSet_Click(object sender, RoutedEventArgs e)
        {

            CallbackCommand(vm => vm.TabIndex = 4);

        }

        void InitDbItem(int i)
        {
            var rowDef = new RowDefinition();
            GridSetPath.RowDefinitions.Add(rowDef);
            var dbset = new DatabaseSetting(i);

            dbset.BtnReview.Name = "BtnReview" + i;
            dbset.BtnReview.Click += BtnReview_Click;
            dbset.BtnUpdateTemplate.Name = "BtnUpdateTemplate" + i;
            dbset.BtnUpdateTemplate.Click += BtnUpdateTemplate_Click;
            Grid.SetRow(dbset, i);
            GridSetPath.Children.Add(dbset);
            listucDB.Add(dbset);
        }
        #endregion

        public void CallbackCommand(Action<MainTabViewModel> execute)
        {
            try
            {
                if (DataContext is MainTabViewModel model)
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
        private void LoadCsvIntoDataGrid(string csvFilePath)
        {
            try
            {
                DataTable dataTable = new DataTable();

                using (TextFieldParser parser = new TextFieldParser(csvFilePath))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    if (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();
                        foreach (string field in fields)
                        {
                            dataTable.Columns.Add(field);
                        }
                    }

                    while (!parser.EndOfData)
                    {
                        string[] values = parser.ReadFields();
                        dataTable.Rows.Add(values);
                    }
                }

                DataGridPreview.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception)
            {
                MessageBox.Show("Database Not Found", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void UpdateScaleTransform()
        {
            BtnStart.LayoutTransform = MainPage.ScaleTransform;
            BtnStop.LayoutTransform = MainPage.ScaleTransform;
            BtnTrigger.LayoutTransform = MainPage.ScaleTransform;
            LabelSelect.LayoutTransform = MainPage.ScaleTransform;
            ComboboxStation.LayoutTransform = MainPage.ScaleTransform;
        }

        #endregion

        #region Event UI   
        private void BtnDetailFail_Click(object sender, RoutedEventArgs e)
        {
            var btnName = ((System.Windows.Controls.Button)sender).Name;
            var id = int.Parse((btnName[btnName.Length - 1]).ToString());
            ButtonFailClickEvent?.Invoke(id, EventArgs.Empty);
        }
        private void BtnDetailPrinted_Click(object sender, RoutedEventArgs e)
        {
            var btnName = ((System.Windows.Controls.Button)sender).Name;
            var id = int.Parse((btnName[btnName.Length - 1]).ToString());
            ButtonPrintedClickEvent?.Invoke(id, EventArgs.Empty);
        }
        private void BtnDetailTotal_Click(object sender, RoutedEventArgs e)
        {
            var btnName = ((System.Windows.Controls.Button)sender).Name;
            var id = int.Parse((btnName[btnName.Length - 1]).ToString());
            ButtonTotalClickEvent?.Invoke(id, EventArgs.Empty);
        }
        private void BtnDetailGood_Click(object sender, RoutedEventArgs e)
        {
            var btnName = ((System.Windows.Controls.Button)sender).Name;
            var id = int.Parse((btnName[btnName.Length - 1]).ToString());
            ButtonGoodClickEvent?.Invoke(id, EventArgs.Empty);
        }
        private void BtnUpdateTemplate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var btn = (Button)sender;
                var index = int.Parse(btn.Name.Substring(btn.Name.Length - 1));
                var viewModel = (DatabaseSettingVM)listucDB[index].DataContext;
                var mmf = new MemoryMapHelper("mmf_UpdateTemplate" + index, 1);
                mmf.WriteData(Encoding.ASCII.GetBytes("1"), 0);

                // Get Path
                string directoryPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\MLSolutions";
                string filePath = Path.Combine(directoryPath, "Template" + index + ".txt");

                //Get POD list and update to UI
                var tempList = CommonFunctions.GetTemplatePod(filePath);
                viewModel.TemplateList = new System.Collections.ObjectModel.ObservableCollection<string>(tempList);
            }
            catch (Exception)
            {

            }

        }
        private void BtnReview_Click(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            var index = int.Parse(btn.Name.Substring(btn.Name.Length - 1));
            var viewModel = (DatabaseSettingVM)listucDB[index].DataContext;
            LoadCsvIntoDataGrid(viewModel.FilePath);


        }
        private void BtnWebPrinter_Click(object sender, RoutedEventArgs e)
        {

        }
        private void MainPage_ScaleTransformChanged(object sender, EventArgs e)
        {
            UpdateScaleTransform();
        }
        private void UcCurrentStation_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateScaleTransform();
        }
        private void GridCover_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var clickedGrid = sender as Grid;

            var index = int.Parse(clickedGrid.Name.Substring(clickedGrid.Name.Length - 1));
            ComboboxStation.SelectedIndex = index;
            if (clickedGrid != null)
            {
                foreach (var child in GridStation.Children)
                {
                    if (child is Grid grid)
                    {
                        grid.Background = Brushes.Transparent;
                    }
                }
                clickedGrid.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#6ded8f"));
            }
        }



        private void BtnSetPrinter_Click(object sender, RoutedEventArgs e)
        {

        }
        private void BtnSetCam_Click(object sender, RoutedEventArgs e)
        {
            var btn = (System.Windows.Controls.Button)sender;
            CallbackCommand(vm => vm.TabIndex = 2);
            var index = btn.Name.Substring(btn.Name.Length - 1);
            var ucSetCam = new ucSettingDM60X(int.Parse(index));
            GridSetting.Children.Add(ucSetCam);
        }
        private void Exit_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var res = MessageBox.Show("Exit Application ?", "Exit Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.Yes)
            {
                //App.Current.Shutdown();
            }

        }
        private void HomeClick(object sender, MouseButtonEventArgs e)
        {
            CallbackCommand(vm => vm.TabIndex = 0);

        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            CallbackCommand(vm => vm.TabIndex = 0);

        }
        private void JobItemsClick(object sender, MouseButtonEventArgs e)
        {
            CallbackCommand(vm => vm.TabIndex = 1);
        }
        private void DatabaseClick(object sender, MouseButtonEventArgs e)
        {
            CallbackCommand(vm => vm.TabIndex = 4);
        }
        private void ButtonTrigger_Click(object sender, RoutedEventArgs e)
        {
            CallbackCommand(vm => vm.TabIndex = 3);
            InitTriggerTab(ComboboxStation.SelectedIndex);
        }
        private void StartClick(object sender, RoutedEventArgs e)
        {
            bool isRun = false;
            CallbackCommand(vm => vm.StartPrint(ref isRun));
            var tempvm = (ucCurrentStationVM)listCurStation[ComboboxStation.SelectedIndex].DataContext;
            if (isRun)
            {
                tempvm.StaticMode = 1;
            }
            else
            {
                tempvm.StaticMode = 0;
            }
        }
        private void StopClick(object sender, RoutedEventArgs e)
        {
            bool isStop = false;
            CallbackCommand(vm => vm.StopPrint(ref isStop));
            var tempvm = (ucCurrentStationVM)listCurStation[ComboboxStation.SelectedIndex].DataContext;
            if (isStop)
            {
                tempvm.StaticMode = 0;
            }
            else
            {
                tempvm.StaticMode = 1;
            }
        }
        private void ButtonSaveDB_Click(object sender, RoutedEventArgs e)
        {
            var listFilePath = new List<string>();
            var listPodId = new List<string>();
            var listTemplate = new List<string>();

            foreach (var item in listucDB)
            {
                listFilePath.Add(((DatabaseSettingVM)item.DataContext).FilePath);
                listPodId.Add(((DatabaseSettingVM)item.DataContext).SelectedPODId.ToString());
                listTemplate.Add(((DatabaseSettingVM)item.DataContext).SelectedTemplate);
            }
            CallbackCommand(vm => vm.SaveDB(listFilePath, listPodId, listTemplate));
            var mmf_Save = new MemoryMapHelper("mmf_Save", 1);
            mmf_Save.WriteData(new byte[1] { 1 }, 0);
        }
        #endregion


        #region ScrollViewer Status Station
        private void MyScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewerStatus.ScrollToVerticalOffset(ScrollViewerStatus.HorizontalOffset - e.Delta);
            e.Handled = true;
        }

        private void MyScrollViewer_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            scrollStartPoint = e.GetPosition(this);
            scrollStartOffset = ScrollViewerStatus.HorizontalOffset;
            ScrollViewerStatus.Cursor = Cursors.Hand;
            ScrollViewerStatus.CaptureMouse();
        }

        private void MyScrollViewer_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (ScrollViewerStatus.IsMouseCaptured)
            {
                var currentPoint = e.GetPosition(this);
                var delta = scrollStartPoint.X - currentPoint.X;
                ScrollViewerStatus.ScrollToHorizontalOffset(scrollStartOffset + delta);
            }
        }

        private void MyScrollViewer_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            ScrollViewerStatus.Cursor = Cursors.Arrow;
            ScrollViewerStatus.ReleaseMouseCapture();
        }
        #endregion

        private void GroupBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            listGridCover[ComboboxStation.SelectedIndex].Background = Brushes.Transparent;
        }

        private void ComboboxStation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            for (int i = 0; i < _TotalStation; i++)
            {
                if (i == ComboboxStation.SelectedIndex)
                {
                    listGridCover[ComboboxStation.SelectedIndex].Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#6ded8f"));
                }
                else
                {
                    listGridCover[i].Background = Brushes.Transparent;
                }
            }
        }

        private void BtnApplyClick(object sender, RoutedEventArgs e)
        {
            SaveValues();
            SharedFunctions.SaveSettingsFunc();
            var appPath = Application.ResourceAssembly.Location;
            RestartAppEvent?.Invoke(this, EventArgs.Empty);
        }

        private void SaveValues()
        {

            for (int i = 0; i < _TotalStation; i++)
            {
                var viewModelJob = (ucJobItemsVM)listJob[i].DataContext;
                var viewModelDb = (DatabaseSettingVM)listucDB[i].DataContext;
                switch (SharedValues.Settings.StationList[i].CameraModel)
                {
                    case DataType.StationType.UNKNOWN:
                        break;
                    case DataType.StationType.COGNEX_DATAMAN:
                        SharedValues.Settings.StationList[i].DMCamera.IPAddress = viewModelJob.CamIP;
                        SharedValues.Settings.StationList[i].DMCamera.Port = viewModelJob.CamPort;
                        SharedValues.Settings.StationList[i].DMCamera.PrinterIP = viewModelJob.PrinterIP;
                        SharedValues.Settings.StationList[i].DMCamera.PrinterPort = viewModelJob.PrinterPort;
                        break;
                    case DataType.StationType.KEYENCE:
                        break;
                    default:
                        break;
                }

                //--Database Save--//
                SharedValues.Settings.StationList[i].CameraModel =
                            viewModelJob.SelectedModelCam == 0 ?
                            DataType.StationType.COGNEX_DATAMAN :
                            DataType.StationType.KEYENCE;
                SharedValues.Settings.StationList[i].LastPathDatabase = viewModelDb.FilePath;
                SharedValues.Settings.StationList[i].LastSeletedIndexColumn = viewModelDb.SelectedPODId;
                SharedValues.Settings.StationList[i].LastSelectedIndexTemplate = viewModelDb.SelectedTemplateId;
            }

        }
    }
}
