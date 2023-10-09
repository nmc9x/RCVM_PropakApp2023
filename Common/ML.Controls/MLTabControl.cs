using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ML.Controls
{
    public class MLTabControl: TabControl
    {
        private Color _SkinColor = Color.FromArgb(10, 55, 143);
        public Color SkinColor
        {
            get { return _SkinColor; }
            set { _SkinColor = value; }
        }
        public MLTabControl()
        {
            //InitializeComponent();
            this.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.Appearance = TabAppearance.FlatButtons;
            //this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            //
            this.ItemSize = new Size(0, 1); 
            this.SizeMode = TabSizeMode.Fixed;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);

            if (this.SelectedTab == this.TabPages[e.Index])
            {
                e.Graphics.FillRectangle(new SolidBrush(_SkinColor), e.Bounds);
                //e.Graphics.FillRectangle(new SolidBrush(skinColor),new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
            }
            else
            {
                //e.Graphics.FillRectangle(new SolidBrush(_SkinColor), e.Bounds);
                e.Graphics.FillRectangle(new SolidBrush(_SkinColor), new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height + 5));
            }

            this.TabPages[e.Index].BorderStyle = BorderStyle.None;
            this.TabPages[e.Index].ForeColor = SystemColors.ControlText;

            Rectangle paddedBounds = e.Bounds;
            //paddedBounds.Inflate(-2, -2);
            paddedBounds.Inflate(-2, -2);

            e.Graphics.DrawString(this.TabPages[e.Index].Text, this.Font, SystemBrushes.HighlightText, paddedBounds);
            // 
        }
    }
}
