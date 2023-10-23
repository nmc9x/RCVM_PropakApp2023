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
    public partial class frmDialogue : Form
    {
        public frmDialogue()
        {
            InitializeComponent();
            
            this.FormBorderStyle = FormBorderStyle.None;
            this.elementHost1.Child = new ucDialogue();
            this.MouseDown += FrmDialogue_MouseDown;
            this.MouseMove += FrmDialogue_MouseMove;
        }

        
        private Point _mouseLoc;

        private void FrmDialogue_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseLoc = e.Location;
        }

        private void FrmDialogue_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int dx = e.Location.X - _mouseLoc.X;
                int dy = e.Location.Y - _mouseLoc.Y;
                this.Location = new Point(this.Location.X + dx, this.Location.Y + dy);
            }
        }
    }
}
