using ML.Common.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.PVCFC_RFID.Design
{
    public partial class frmSettingsRFIDZebra : Form
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
        public frmSettingsRFIDZebra()
        {
            InitializeComponent();
        }

        public frmSettingsRFIDZebra(int index)
        {
            _Index = index;
            InitializeComponent();
            //
            this.Icon = Properties.Resources.rfid;
            this.MinimumSize = new Size(1024, 768);
            ucSettingsItemsRFIDZebraFX96001.Index = _Index;
            //
            InitControls();
            InitLanguages();
            InitEvent();
            InitData();
        }

        #region Inits
        private void InitControls()
        {

        }
        private void InitLanguages()
        {

        }
        private void InitEvent()
        {
            this.FormClosed+=frmSettingsRFIDZebra_FormClosed;
        }
        private void InitData()
        {

        }
        #endregion//End Inits

        #region Events
        private void frmSettingsRFIDZebra_FormClosed(object sender, EventArgs e)
        {
            if(!_IsBinding)
            {

            }
        }
        #endregion//End Events

        #region Methods
        #endregion//End Methods


        #region Fixed flickering forms - https://www.youtube.com/watch?v=_h-UXxp3cd0&t=116s

        /// <summary>
        /// Linh.Tran
        /// On 190904
        /// Methods override is fix error Controls in usercontrol flicker while usercontrol visiblity changes
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        #endregion//End Fixed flickering forms
    }
}
