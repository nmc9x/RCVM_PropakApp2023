using App.PVCFC_RFID.Controller;
using System.Windows.Controls;

namespace App.PVCFC_RFID.Design.XAMLViews
{
    /// <summary>
    /// Interaction logic for JobsConfig.xaml
    /// </summary>
    public partial class JobsConfig : UserControl
    {
        public JobsConfig()
        {
            InitializeComponent();
            InitControl();
        }
        private void InitControl()
        {
            for (int i = 0; i < SharedControlHandler.NumberOfStation; i++)
            {
                var jobItems = new ucJobItems();
                ListBox1.Items.Add(jobItems);
            }
        }
    }
}
