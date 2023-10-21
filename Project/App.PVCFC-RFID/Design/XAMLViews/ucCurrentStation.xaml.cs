using App.PVCFC_RFID.Controller;
using MaterialDesignThemes.Wpf;
using ML.Common.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
    /// Interaction logic for ucCurrentJobs.xaml
    /// </summary>
    public partial class ucCurrentStation : UserControl
    {
        private  int _Index;
       
        public ucCurrentStation(int index)
        {
            _Index = index;
            InitializeComponent();
            DataContext = new ucCurrentStationVM(index);
            this.Loaded += UcCurrentStation_Loaded;
            this.SizeChanged += UcCurrentStation_SizeChanged;
          
        }

        private void UcCurrentStation_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            IconRun.LayoutTransform = MainPage.ScaleTransform;
            IconStop.LayoutTransform = MainPage.ScaleTransform;
            EllipseTagName.LayoutTransform = MainPage.ScaleTransform;
            TextBoxTagName.LayoutTransform = MainPage.ScaleTransform;

        }

        public void CallbackCommand(Action<ucCurrentStationVM> execute)
        {
            try
            {
                if (DataContext is ucCurrentStationVM model)
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

        private void UcCurrentStation_Loaded(object sender, RoutedEventArgs e)
        {
            CallbackCommand(vm => vm.StationTagName = _Index.ToString());
        }

        private void BtnDetailGood_Click(object sender, RoutedEventArgs e)
        {
            puGood pug = new puGood(0, "");
            pug.ShowDialog();
        }

        private void BtnDetailGood_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDetailFail_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDetailTotal_Click(object sender, RoutedEventArgs e)
        {

        }
    }
    public class ucCurrentStationVM:ViewModelBase
    {
        private int _Index;
        private Thread _ThreadUpdateDataRealTime = null;
        public ucCurrentStationVM(int index)
        {
            _Index = index;
            //_ThreadUpdateDataRealTime = new Thread(UpdateData);
            //_ThreadUpdateDataRealTime.IsBackground = true;
            //_ThreadUpdateDataRealTime.Start();
            Task.Run(() => UpdateData()); // increase work efficiency
        }

        private void UpdateData()
        {
            
            try
            {
                var mmfVerifyCheckSts = new MemoryMapHelper("mmf_VerifyCheckCode" + _Index, 20);
                var mmfCountPrintedPage = new MemoryMapHelper("mmf_PrintedPage" + _Index, 5);
                while (true)
                {
                        
                        var printedPage = Encoding.ASCII.GetString(mmfCountPrintedPage.ReadData(0, 5));
                        var countResult = Encoding.ASCII.GetString(mmfVerifyCheckSts.ReadData(0, 20));
                        string[] splitRes = countResult.Split('-');
                    if (splitRes.Length > 1)
                    {
                        SharedControlHandler._dispatcher?.Invoke(() => // Dispather for speed up update Value to UI
                        {
                            GoodCount = splitRes[0].ToString();
                            FailCount = Regex.Replace(splitRes[1], @"\0", "");
                            TotalCount = (int.Parse(GoodCount) + int.Parse(FailCount)).ToString();
                            PrintedCount = Regex.Replace(printedPage, @"\0", "");
                            PrintedCount = PrintedCount == "" ? "0" : PrintedCount;
                        });


                   }
                    Thread.Sleep(10);
                }
            }
            catch (Exception)
            {

            }
       

        }

        private string _StationTagName;
        public string StationTagName
        {
            get { return _StationTagName; }
            set { _StationTagName = value; OnPropertyChanged(); }
        }

        private string _GoodCount = "0";

        public string GoodCount
        {
            get { return _GoodCount; }
            set { _GoodCount = value; OnPropertyChanged(); }
        }

        private string _FailCount = "0";

        public string FailCount
        {
            get { return _FailCount; }
            set { _FailCount = value;OnPropertyChanged(); }
        }

        private string _TotalCount = "0";

        public string TotalCount
        {
            get { return _TotalCount; }
            set { _TotalCount = value; OnPropertyChanged(); }
        }

        private string _PrintedCount = "0";
        public string PrintedCount
        {
            get { return _PrintedCount; }
            set { _PrintedCount = value; OnPropertyChanged(); }
        }


    }

}
