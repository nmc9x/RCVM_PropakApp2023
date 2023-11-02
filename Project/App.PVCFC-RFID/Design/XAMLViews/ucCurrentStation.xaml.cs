using App.PVCFC_RFID.Controller;
using ML.Common.Controller;
using ML.SDK.DM60X.Model;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

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
            MainPage.ScaleTransformChanged += MainPage_ScaleTransformChanged;
            UpdateScaleTransform();
            
        }
        #region TransformScale
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
            //IconRun.LayoutTransform = MainPage.ScaleTransform;
            //IconStop.LayoutTransform = MainPage.ScaleTransform;
            BtnDetailTotal.LayoutTransform = MainPage.ScaleTransform;
            BtnDetailGood.LayoutTransform = MainPage.ScaleTransform;
            BtnDetailPrinted.LayoutTransform = MainPage.ScaleTransform;
            BtnDetailFail.LayoutTransform = MainPage.ScaleTransform;
            EllipseTagName.LayoutTransform = MainPage.ScaleTransform;
            TextBoxTagName.LayoutTransform = MainPage.ScaleTransform;
            TextBoxRUN.LayoutTransform = MainPage.ScaleTransform;
            TextBoxSTOP.LayoutTransform = MainPage.ScaleTransform;
            BtnDetailTotal.LayoutTransform = MainPage.ScaleTransform;
            BtnDetailPrinted.LayoutTransform = MainPage.ScaleTransform;
            BtnDetailGood.LayoutTransform = MainPage.ScaleTransform;
            BtnDetailFail.LayoutTransform = MainPage.ScaleTransform;
            TextBlockTotal.LayoutTransform = MainPage.ScaleTransform;
            TextBlockPrinted.LayoutTransform = MainPage.ScaleTransform;
            TextBlockGood.LayoutTransform = MainPage.ScaleTransform;
            

            TextBlockFail.LayoutTransform = MainPage.ScaleTransform;



        }

       
        #endregion
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

        #region UI Event
        private void UcCurrentStation_Loaded(object sender, RoutedEventArgs e)
        {
            CallbackCommand(vm => vm.StationTagName = "JOB " + (_Index +1).ToString());
        }
      
        #endregion

      
    }
    public class ucCurrentStationVM:ViewModelBase
    {
        private int _Index;
        private Thread _ThreadUpdateDataRealTime = null;
        private MemoryMapHelper mmf_PrintedCode;
        public ucCurrentStationVM(int index)
        {
            _Index = index;
            UpdatePrintedCode();
            Task.Run(() => UpdateData()); // increase work efficiency by Task
            Task.Run(() => ClearData());
            
        }

        private void UpdatePrintedCode()
        {
            mmf_PrintedCode = new MemoryMapHelper("mmf_PrintedCode" + _Index, 100);

        }

        private void ClearData()
        {
           
        }

       

        private void UpdateData()
        {
            try
            {
                while (true)
                {
                    var mmfVerifyCheckSts = new MemoryMapHelper("mmf_VerifyCheckCode" + _Index, 20);
                    var countResult = Encoding.ASCII.GetString(mmfVerifyCheckSts.ReadData(0, 20));

                    var mmfCountPrintedPage = new MemoryMapHelper("mmf_PrintedPage" + _Index, 5);
                    var printedPage = Encoding.ASCII.GetString(mmfCountPrintedPage.ReadData(0, 5)).Trim('\0');

                    var mmf_classifyCode = new MemoryMapHelper("mmf_CheckCodeFlag" + _Index, 1);
                    var codeChk = Encoding.ASCII.GetString(mmf_classifyCode.ReadData(0, 1));
                    
                    
                    string[] splitRes = countResult.Split('-');

                    if (splitRes.Length > 1)
                    {
                        SharedControlHandler._dispatcher?.Invoke(() => // Dispather for speed up update Value to UI
                        {
                            GoodCount = splitRes[0].ToString();
                            FailCount = Regex.Replace(splitRes[1], @"\0", "");
                            TotalCount = Regex.Replace(splitRes[2], @"\0", "");

                            if (codeChk !="\0" && !SharedControlHandler.isTriggerOn)
                            {
                                switch (codeChk)
                                {
                                    case "1": // dup
                                        SharedControlHandler.newCodeItem.ErrorStr = "Fail";
                                        SharedValues.Running.StationList[_Index].DataFailList.Add(SharedControlHandler.newCodeItem);
                                        break;
                                    case "2": // unk
                                        SharedControlHandler.newCodeItem.ErrorStr = "Good";
                                        SharedValues.Running.StationList[_Index].DataGoodList.Add(SharedControlHandler.newCodeItem);
                                        break;
                                }
                                mmf_classifyCode.WriteData(new byte[1], 0);
                            }
                           
                        });
                   }

                    
                    SharedControlHandler._dispatcher?.Invoke(() =>
                    {
                        //
                        var printedCode = Encoding.ASCII.GetString(mmf_PrintedCode.ReadData(0, 100)).Trim('\0');
                        if (printedCode != "" && printedCode != Encoding.ASCII.GetString(new byte[100]))
                        {
                            var model = new GotCodeModel
                            {
                                Code = printedCode,
                                DateTimeStr = DateTime.Now.ToString("yyyy-MM-dd") + "/" + DateTime.Now.ToString("HH:mm:ss")
                            };
                            SharedValues.Running.StationList[_Index].DataPrintedList.Add(model);
                            mmf_PrintedCode.WriteData(new byte[100], 0);
                        }
                    });

                    PrintedCount = Regex.Replace(printedPage, @"\0", "");
                    PrintedCount = PrintedCount == "" ? "0" : PrintedCount;


                    Thread.Sleep(1);
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
        private int _StaticMode;

        public int StaticMode
        {
            get { return _StaticMode; }
            set { _StaticMode = value; OnPropertyChanged(); }
        }



    }

}
