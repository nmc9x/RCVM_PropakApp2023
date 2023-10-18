using App.PVCFC_RFID.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace App.PVCFC_RFID.Design.XAMLViews
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class ucMain : UserControl
    {
        private Point scrollStartPoint;
        private double scrollStartOffset;
        
        public ucMain()
        {

            InitializeComponent();
            InitUIStationStatus(SharedControlHandler.NumberOfStation);
            InitDeviceTransferStations();

        }
        private void InitUIStationStatus(int numStation)
        {
            for (int i = 0; i < numStation; i++)
            {
                ucStationStatus.StationID = i + 1;
                var stationStatusUC = new ucStationStatus(i);
                StackPanelStatus.Children.Add(stationStatusUC);
            }
        }
        private void InitDeviceTransferStations()
        {
            for (int i = 0; i < 4; i++)
            {
                var ucStation = new ucCurrentJobs();
                StackPanelStation.Children.Add(ucStation);
            }
           
            //SharedControlHandler.KillDeviceTransferBefore();
            SharedControlHandler.InitDeviceTransfer();
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
            for (int i = 0; i < 4; i++)
            {
                var ucStation = new ucCurrentJobs();
                StackPanelStation.Children.Add(ucStation);
            }
            //if ((ucHomePage)FrameContent.Content == null)
            //    FrameContent.Content = new ucHomePage();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //if ((ucHomePage)FrameContent.Content == null)
            //    FrameContent.Content = new ucHomePage();
        }

        private void JobItemsClick(object sender, MouseButtonEventArgs e)
        {
            StackPanelStation.Children.Clear();
            //if ((ucHomePage)FrameContent.Content != null)
            //    FrameContent.Content = null;

            //    if (FrameContent.Content == null)
            //    FrameContent.Content = new JobsConfig();
        }
    }
}
