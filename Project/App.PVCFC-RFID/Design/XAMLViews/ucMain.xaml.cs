using App.PVCFC_RFID.Controller;
using App.PVCFC_RFID.Controller.ViewModels;
using ControlzEx.Theming;
using Microsoft.VisualBasic.FileIO;
using ML.Common.Controller;
using Symbol.RFID3;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;



namespace App.PVCFC_RFID.Design.XAMLViews
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class ucMain : UserControl
    {
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

        private List<DatabaseSetting> listucDB;

        #endregion
        public ucMain()
        {

            InitializeComponent();

            this.SizeChanged += UcCurrentStation_SizeChanged;
            MainPage.ScaleTransformChanged += MainPage_ScaleTransformChanged;
            UpdateScaleTransform();
            DataContext = new MainTabViewModel();
            listucDB = new List<DatabaseSetting>();
            InitStation();


        }

        private void MainPage_ScaleTransformChanged(object sender, EventArgs e)
        {
            UpdateScaleTransform();
        }

        private void UcCurrentStation_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateScaleTransform();
        }
        private void UpdateScaleTransform()
        {
            BtnStart.LayoutTransform = MainPage.ScaleTransform;
            BtnStop.LayoutTransform = MainPage.ScaleTransform;
            BtnTrigger.LayoutTransform = MainPage.ScaleTransform;
            LabelSelect.LayoutTransform = MainPage.ScaleTransform;
            ComboboxStation.LayoutTransform = MainPage.ScaleTransform;


        }

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

        #region Init Station
        private void InitUIStationStatus(int i)
        {
                ucStationStatus.StationID = i + 1;
                var stationStatusUC = new ucStationStatus(i);
                StackPanelStatus.Children.Add(stationStatusUC);
        }
        private void InitItemCombobox(int i)
        {
            ComboboxStation.FontSize = 25;
            ComboboxStation.Items.Add("JOB "+(i+1));
           
        }
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



            //SharedControlHandler.KillDeviceTransferBefore();
            

        }

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
        static int TempIndex;
        ucTrigger tempUctrigger ;
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
                //ucJob.BtnWebPrinter.Click += BtnWebPrinter_Click;
                ucJob.BtnSetPrinter.Name = "BtnSetPrinter" + i;
                ucJob.BtnSetCam.Name = "BtnSetCam" + i;
            StackPanelJob.Children.Add(ucJob);
        }
        
        private List<string> listPathDb = new List<string>();
        void InitDbItem(int i)
        {
            var rowDef = new RowDefinition();
            GridSetPath.RowDefinitions.Add(rowDef);
            var dbset = new DatabaseSetting(i);
            
            dbset.BtnReview.Name = "BtnReview" + i;
            dbset.BtnReview.Click += BtnReview_Click;
            Grid.SetRow(dbset, i);
            GridSetPath.Children.Add(dbset);
            listucDB.Add(dbset);
        }

        private void BtnReview_Click(object sender, RoutedEventArgs e)
        {
            var btn = (System.Windows.Controls.Button)sender;
            var index = int.Parse(btn.Name.Substring(btn.Name.Length-1));
            var viewModel = (DatabaseSettingVM)listucDB[index].DataContext;
            LoadCsvIntoDataGrid(viewModel.FilePath);


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
                MessageBox.Show("Database Not Found","",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            
        }
        #endregion

        private void BtnWebPrinter_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void GridCover_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var clickedGrid = sender as Grid;
            if (clickedGrid != null)
            {
                foreach (var child in GridStation.Children)
                {
                    if (child is Grid grid)
                    {
                        grid.Background = System.Windows.Media.Brushes.Transparent;
                    }
                }
                clickedGrid.Background = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#6ded8f"));
            }
        }
        private void BtnSetPrinter_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnSetCam_Click(object sender, RoutedEventArgs e)
        {
            var btn = (System.Windows.Controls.Button)sender;
            CallbackCommand(vm => vm.TabIndex = 2);
            var index = btn.Name.Substring(btn.Name.Length-1);
            var ucSetCam = new ucSettingDM60X(int.Parse(index));
            GridSetting.Children.Add(ucSetCam);
        }

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
            CallbackCommand(vm=>vm.TabIndex = 3);
            InitTriggerTab(ComboboxStation.SelectedIndex);
        }

      
        private void StartClick(object sender, RoutedEventArgs e)
        {
           CallbackCommand(vm=>vm.StartPrint());    
        }
        private void StopClick(object sender, RoutedEventArgs e)
        {
            CallbackCommand(vm => vm.StopPrint());
        }

        private void ButtonSaveDB_Click(object sender, RoutedEventArgs e)
        {
           
            List<string> listFilePath = new List<string>();
            foreach(var item in listucDB)
            {
                listFilePath.Add(((DatabaseSettingVM)item.DataContext).FilePath); 
            }
            CallbackCommand(vm => vm.SaveDB(listFilePath));
        }
    }
}
