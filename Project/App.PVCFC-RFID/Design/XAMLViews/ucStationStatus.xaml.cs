using App.PVCFC_RFID.Controller.ViewModels;
using System;
using System.Windows.Controls;

namespace App.PVCFC_RFID.Design.XAMLViews
{
    /// <summary>
    /// Interaction logic for ucStationStatus.xaml
    /// </summary>
    public partial class ucStationStatus : UserControl
    {
        
        public static int StationID { get; set; }
        public EventHandler checkConnectionEvent;
        public ucStationStatus(int index)
        {
            InitializeComponent();
            DataContext = new StationStatusViewModel(index);
            InitUIParameter();
            checkConnectionEvent?.Invoke(this, EventArgs.Empty);
        }
        public void CallbackCommand(Action<StationStatusViewModel> execute)
        {
            try
            {
                if (DataContext is StationStatusViewModel model)
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
        private void InitUIParameter()
        {
            TextBoxStationId.Text = "Job "+StationID.ToString();
        }
    }
}
