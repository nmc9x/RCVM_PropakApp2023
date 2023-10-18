using App.PVCFC_RFID.Controller;
using ML.Common.Controller;
using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;
using TextBox = System.Windows.Controls.TextBox;
using UserControl = System.Windows.Controls.UserControl;

namespace App.PVCFC_RFID.Design
{
    public partial class ucSettingDM60X : UserControl
    {
        #region Properties
        private static readonly string IPv4Pattern = @"^(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";

        public static int Index { get; set; }
        #endregion

        public ucSettingDM60X()
        {
            InitializeComponent();
            SettingViewModel.Index = Index;
            DataContext = new SettingViewModel();
            //if(DataContext is SettingViewModel sm)
            //{
            //    sm.Index = Index;
            //}
        }

        public void CallbackCommand(Action<SettingViewModel> execute)
        {
            try
            {
                if (DataContext is SettingViewModel model)
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
        #region Control Event

        private void ApplySettingClick(object sender, RoutedEventArgs e)
        {
            CallbackCommand(vm => vm.ApplySettingFunction());
        }
        private void ThisForm_Loaded(object sender, RoutedEventArgs e)
        {
            //CallbackCommand(model => model.GetSavedValueSettingToElement(Index));
        }
        private void Reboot_Click(object sender, RoutedEventArgs e)
        {
            CallbackCommand(model => model.RebootDevice());
        }
        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            CallbackCommand(model => model.ResetParams());
        }
        private void BrowseSettingFileClick(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Title = "Open Setting File",
                Filter = "All files (*.*)|*.*|Text files (*.txt)|*.txt",
                InitialDirectory = CommonValues.SettingsPath
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                Process.Start("rundll32.exe", $"shell32.dll,OpenAs_RunDLL {filePath}");
            }
        }
        #endregion

        #region Value Validation 
        private async void TbDecodeTime_LostFocus(object sender, RoutedEventArgs e)
        {
            var obj = (TextBox)sender;
            obj.LostFocus -= TbDecodeTime_LostFocus;
            await Task.Delay(10);
            try
            {
                if (int.Parse(obj.Text) < 0 || int.Parse(obj.Text) > 10000)
                {
                    MessageBox.Show("Value must be in (0-10000)", "Value Validate", MessageBoxButton.OK, MessageBoxImage.Error);
                    obj.Focus();
                    obj.SelectAll();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Fail format !", "Value Validate", MessageBoxButton.OK, MessageBoxImage.Error);
                obj.Focus();
                obj.SelectAll();
            }
            obj.LostFocus += TbDecodeTime_LostFocus;

        }
        private async void TbDelayTime_LostFocus(object sender, RoutedEventArgs e)
        {
            var obj = (TextBox)sender;
            obj.LostFocus -= TbDelayTime_LostFocus;
            await Task.Delay(10);
            try
            {
                if (int.Parse(obj.Text) < 0 || int.Parse(obj.Text) > 10000)
                {
                    MessageBox.Show("Value must be in (0-10000)", "Value Validate", MessageBoxButton.OK, MessageBoxImage.Error);
                    obj.Focus();
                    obj.SelectAll();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Fail format !", "Value Validate", MessageBoxButton.OK, MessageBoxImage.Error);
                obj.Focus();
                obj.SelectAll();
            }
            obj.LostFocus += TbDelayTime_LostFocus;
        }
        private async void TbIPAddress_LostFocus(object sender, RoutedEventArgs e)
        {
            var obj = (TextBox)sender;
            obj.LostFocus -= TbIPAddress_LostFocus;
            await Task.Delay(10);
            try
            {
                if (!Regex.IsMatch(obj.Text, IPv4Pattern))
                {
                    MessageBox.Show("IP Address incorrect format", "Value Validate", MessageBoxButton.OK, MessageBoxImage.Error);
                    obj.Focus();
                    obj.SelectAll();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Fail format !", "Value Validate", MessageBoxButton.OK, MessageBoxImage.Error);
                obj.Focus();
                obj.SelectAll();
            }
            obj.LostFocus += TbIPAddress_LostFocus;
        }
        private async void TbSubnet_LostFocus(object sender, RoutedEventArgs e)
        {
            var obj = (TextBox)sender;
            obj.LostFocus -= TbSubnet_LostFocus;
            await Task.Delay(10);
            try
            {
                if (!Regex.IsMatch(obj.Text, IPv4Pattern))
                {
                    MessageBox.Show("IP Address incorrect format", "Value Validate", MessageBoxButton.OK, MessageBoxImage.Error);
                    obj.Focus();
                    obj.SelectAll();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Fail format !", "Value Validate", MessageBoxButton.OK, MessageBoxImage.Error);
                obj.Focus();
                obj.SelectAll();
            }
            obj.LostFocus += TbSubnet_LostFocus;
        }
        private async void TbPort_LostFocus(object sender, RoutedEventArgs e)
        {
            var obj = (TextBox)sender;
            obj.LostFocus -= TbPort_LostFocus;
            await Task.Delay(10);
            try
            {
                if (int.Parse(obj.Text) < 0 || int.Parse(obj.Text) > 10000)
                {
                    MessageBox.Show("Value must be in (0-10000)", "Value Validate", MessageBoxButton.OK, MessageBoxImage.Error);
                    obj.Focus();
                    obj.SelectAll();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Fail format !", "Value Validate", MessageBoxButton.OK, MessageBoxImage.Error);
                obj.Focus();
                obj.SelectAll();
            }
            obj.LostFocus += TbPort_LostFocus;
        }

        #endregion

       
    }
   
}
