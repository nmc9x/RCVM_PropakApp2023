using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ML.Common.Controller;

namespace App.PVCFC_RFID.Design
{
    public partial class ucSettingsItemsRFIDZebraFX9600_BK230909 : UserControl
    {
        #region Properties
        private int _Index = 0;
        public int Index
        {
            get { return _Index; }
            set { _Index = value; }
        }

        private string _Title = "";
        public string Title
        {
            get { return _Title; }
            set
            {
                _Title = value;

                CommonFunctions.Invoke(this, new Action(() =>
                {
                    //gRFIDConfig.Text = _Title;
                }));
            }
        }

        private bool _IsBinding = false;
        #endregion//End Properties

        public ucSettingsItemsRFIDZebraFX9600_BK230909()
        {
            InitializeComponent();
            InitControls();
        }

        #region Inits
        private void InitControls()
        {
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Font = new System.Drawing.Font(Properties.Settings.Default.FontFamily, Properties.Settings.Default.FontSize);
        }

        #endregion//End Inits
    }
}
