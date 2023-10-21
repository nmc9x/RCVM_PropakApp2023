using App.PVCFC_RFID.Design.XAMLViews;
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
    public partial class puGood : Form
    {
        public puGood(int index, string title)
        {
            InitializeComponent();
            elementHost1.Child = new PopupGood(index);
        }
    }
}
