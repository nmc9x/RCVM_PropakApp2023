using App.PVCFC_RFID.Controller;
using App.PVCFC_RFID.Controller.ViewModels;
using ControlzEx.Theming;
using ML.Common.Controller;
using System;
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
        public ucMain()
        {

            InitializeComponent();
           
            DataContext = new MainTabViewModel();
            InitStation();


        }
        private void InitStation()
        {
            for (int i = 0; i < _TotalStation; i++)
            {
                InitUIStationStatus(i);
                InitItemCombobox(i);
                InitDeviceTransferStations(i);
                InitJob(i);
                InitTriggerTab(i);
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
            ComboboxStation.Items.Add(i);
        }
        private void InitDeviceTransferStations(int i)
        {

            var ucStation = new ucCurrentStation(i);
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
        private void InitTriggerTab(int index)
        {
            if (index < 0) index = 0;
                var ucTrigger = new ucTrigger(index);
                GridTrigger.Children.Add(ucTrigger); 
        }
        private void InitJob(int i)
        {
           
                var ucJob = new ucJobItems();
                ucJob.BtnSetCam.Click += BtnSetCam_Click;
                ucJob.BtnSetPrinter.Click += BtnSetPrinter_Click;
                ucJob.BtnWebPrinter.Click += BtnWebPrinter_Click;

                ucJob.BtnSetPrinter.Name = "BtnSetPrinter" + i;

                StackPanelJob.Children.Add(ucJob);
            
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
                clickedGrid.Background = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#e3b330"));
            }
        }
        private void BtnSetPrinter_Click(object sender, RoutedEventArgs e)
        {
            var btn = (System.Windows.Controls.Button)sender;
            CallbackCommand(vm => vm.TabIndex = 2);
            var index = btn.Name.Substring(13);
            ucSettingDM60X.Index = int.Parse(index);
            var ucSetCam = new ucSettingDM60X();
            GridSettingPrinter.Children.Add(ucSetCam);
        }

        private void BtnSetCam_Click(object sender, RoutedEventArgs e)
        {
           
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
            //if ((ucHomePage)FrameContent.Content == null)
            //    FrameContent.Content = new ucHomePage();
        }

        private void JobItemsClick(object sender, MouseButtonEventArgs e)
        {
            CallbackCommand(vm => vm.TabIndex = 1);
           
            

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
    }
}
