using App.PVCFC_RFID.Design.XAMLViews;
using ML.Common.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.PVCFC_RFID.Design
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
            elementHost1.Child = new ucMain();
           
        }
        
    }
}
