using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Permissions;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;
using MouseKeyboardActivityMonitor;

namespace ML.Controls
{
    public class MLButton : Button
    {
        #region Properties
        private readonly MouseHookListener m_MouseHookManager;
        private Point _MousedownPoint = new Point(0, 0);
        private Timer _TimerBtnMouseUpHold;
        private ButtonStylesEnum _ButtonStyle = ButtonStylesEnum.None;
        public ButtonStylesEnum ButtonStyle
        {
            get { return _ButtonStyle; }
            set
            {
                _ButtonStyle = value;
                SetEnableColor(_ButtonStyle);
            }
        }

        private bool _AllowLoopEvents = false;
        public bool AllowLoopEvents
        {
            get { return _AllowLoopEvents; }
            set
            {
                _AllowLoopEvents = value;
                if (!_AllowLoopEvents)
                {
                    m_MouseHookManager.MouseMove -= HookManager_MouseMove;
                }
            }
        }


        private Color _BackColorInNoneStyle = SystemColors.ButtonFace;
        /// <summary>
        /// Linh.Tran_210524
        /// </summary>
        public Color BackColorInNoneStyle
        {
            get { return _BackColorInNoneStyle; }
            set
            {
                _BackColorInNoneStyle = value;
                SetEnableColor(_ButtonStyle);
            }
        }

        private Color _BorderColorInNoneStyle = Color.Gray;
        /// <summary>
        /// Linh.Tran_210524
        /// </summary>
        public Color BorderColorInNoneStyle
        {
            get { return _BorderColorInNoneStyle; }
            set
            {
                _BorderColorInNoneStyle = value;
                SetEnableColor(_ButtonStyle);
            }
        }

        private int _BorderSizeInNoneStyle = 0;
        /// <summary>
        /// Linh.Tran_210524
        /// </summary>
        public int BorderSizeInNoneStyle
        {
            get { return _BorderSizeInNoneStyle; }
            set
            {
                _BorderSizeInNoneStyle = value;
                SetEnableColor(_ButtonStyle);
            }
        }

        private Color _ForeColorInInNoneStyle = Color.White;
        public Color ForeColorInInNoneStyle
        {
            get { return _ForeColorInInNoneStyle; }
            set
            {
                _ForeColorInInNoneStyle = value;
                SetEnableColor(_ButtonStyle);
            }
        }

        private bool _IsStandardButton = false;
        public bool IsStandardButton
        {
            get { return _IsStandardButton; }
            set
            {
                _IsStandardButton = value;
                //
                if (_IsStandardButton)
                {
                    this.BackColor =
                    this.FlatAppearance.MouseDownBackColor =
                    this.FlatAppearance.MouseOverBackColor =
                    this.FlatAppearance.BorderColor =
                    this.ForeColor = SystemColors.ControlText;
                    this.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
                    this.UseVisualStyleBackColor = true;
                }
            }
        }

        /// <summary>
        /// Linh.Tran_220418: Fix errors translate
        /// </summary>
        public string TextWithEpplise
        {
            set
            {
                Size sizeOfText = System.Windows.Forms.TextRenderer.MeasureText(value, this.Font);
                Size space = System.Windows.Forms.TextRenderer.MeasureText("  ", this.Font);
                if (sizeOfText.Width > (this.Width - space.Width))
                {
                    int getChar = (this.DefaultSize.Width - space.Width) / (int)Math.Round(((double)sizeOfText.Width / (double)value.Length), 0);
                    if (getChar - 3 > 0)
                    {
                        getChar = getChar - 3;
                    }
                    value = value.Substring(0, getChar) + "...";
                }
                this.Text = value;
            }
        }
        public MLButton()
        {
            // GetTouchInputInfo need to be
            // passed the size of the structure it will be filling
            // we get the sizes upfront so they can be used later.
            //this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimumSize = new Size(0, 32);
            //this.TextAlign = ContentAlignment.MiddleRight;
            //this.ImageAlign = ContentAlignment.MiddleLeft;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Font = new System.Drawing.Font("Arial", 10.25F);
            //
            this.MouseDown += btn_MouseDown;
            this.MouseUp += btn_MouseUp;
            //
            this.EnabledChanged += btn_EnableChanged;
            //
            //Hook events
            //m_MouseHookManager = new MouseHookListener(new MouseKeyboardActivityMonitor.WinApi.GlobalHooker());
            m_MouseHookManager = new MouseHookListener(new MouseKeyboardActivityMonitor.WinApi.AppHooker());
            m_MouseHookManager.Enabled = true;
        }
        #endregion//End Properties

        #region Events
        private void HookManager_MouseMove(object sender, MouseEventArgs e)
        {
#if DEBUG
            Console.WriteLine("HookManager_MouseMove");
#endif
            if (_AllowLoopEvents && (_TimerBtnMouseUpHold != null))
            {
                //Console.WriteLine("x={0:0000}; y={1:0000}", e.X, e.Y);
                if (Math.Sqrt(Math.Pow(e.X - _MousedownPoint.X, 2) + Math.Pow(e.Y - _MousedownPoint.Y, 2)) > 20)
                {
                    _TimerBtnMouseUpHold.Stop();
                    _TimerBtnMouseUpHold.Tick -= (s, ev) => this.PerformClick();//Linh.Tran on 190910
                    _TimerBtnMouseUpHold = null;
                    Subscribe(false); 
                }
            }
        }

        private void btn_MouseDown(object sender, EventArgs e)
        {
            if (_AllowLoopEvents)
            {
                _MousedownPoint = Cursor.Position;//quangle19082101
                _TimerBtnMouseUpHold = new Timer();
                _TimerBtnMouseUpHold.Interval = 100;
                //_timerBtnDecrease_MouseUpHold.Tick += btnDecrease_Do_Something;//quangle19082101 //Command
                _TimerBtnMouseUpHold.Tick += (s, ev) => this.PerformClick();//quangle19082101
                _TimerBtnMouseUpHold.Start();
            }
            Subscribe(_AllowLoopEvents);
        }

        private void btn_MouseUp(object sender, EventArgs e)
        {
            if (_AllowLoopEvents)
            {
                if (_TimerBtnMouseUpHold != null)//quangle19082101
                {
                    _TimerBtnMouseUpHold.Stop();
                    _TimerBtnMouseUpHold.Tick -= (s, ev) => this.PerformClick();//Linh.Tran on 190910
                }
                _TimerBtnMouseUpHold = null;
                Subscribe(false);
            }
        }

        private void btn_EnableChanged(object sender,EventArgs e)
        {
            if (this.Enabled)
            {
                SetEnableColor(_ButtonStyle);
            }
            else
            {
                SetEnableColor(ButtonStylesEnum.Disable);
            }
        }

        #endregion//End Events

        #region Methods
        private void SetEnableColor(ButtonStylesEnum btnStyle)
        {
            if (_IsStandardButton)
            {
                //
            }
            else
            {
                //Linh.Tran_210524
                if (!this.Enabled)
                {
                    btnStyle = ButtonStylesEnum.Disable;
                }
                //End Linh.Tran_210524
                Color clrfc = SystemColors.ControlText;
                Color clrbg = SystemColors.ControlLight;
                Color clrbd = SystemColors.ActiveBorder;
                switch (btnStyle)
                {
                    default:
                    case ButtonStylesEnum.None:
                        clrfc = _ForeColorInInNoneStyle;
                        clrbg = _BackColorInNoneStyle;//Linh.Tran_210524
                        clrbd = _BorderColorInNoneStyle;
                        this.FlatAppearance.BorderSize = _BorderSizeInNoneStyle;//Linh.Tran_210524d
                        break;
                    case ButtonStylesEnum.Default:
                        clrfc = Color.FromArgb(66, 66, 64);//Color.FromArgb(66, 66, 64);
                        clrbg = Color.LightGray;
                        clrbd = Color.FromArgb(206, 212, 218);
                        this.FlatAppearance.BorderSize = 1;//Linh.Tran_210524d
                        break;
                    case ButtonStylesEnum.Primary:
                        clrfc = Color.White;
                        clrbg = Color.FromArgb(51, 122, 183);
                        clrbd = Color.FromArgb(46, 109, 164);
                        this.FlatAppearance.BorderSize = 1;//Linh.Tran_210524
                        break;
                    case ButtonStylesEnum.Success:
                        clrfc = Color.White;
                        clrbg = Color.FromArgb(92, 184, 92);
                        clrbd = Color.FromArgb(76, 174, 76);
                        this.FlatAppearance.BorderSize = 1;//Linh.Tran_210524
                        break;
                    case ButtonStylesEnum.Info:
                        clrfc = Color.White;
                        clrbg = Color.FromArgb(91, 192, 222);
                        clrbd = Color.FromArgb(70, 184, 218);
                        this.FlatAppearance.BorderSize = 1;//Linh.Tran_210524
                        break;
                    case ButtonStylesEnum.Warning:
                        clrfc = Color.White;
                        clrbg = Color.FromArgb(240, 173, 78);
                        clrbd = Color.FromArgb(238, 162, 54);
                        this.FlatAppearance.BorderSize = 1;//Linh.Tran_210524
                        break;
                    case ButtonStylesEnum.Danger:
                        clrfc = Color.White;
                        clrbg = Color.FromArgb(217, 83, 79);
                        clrbd = Color.FromArgb(212, 63, 58);
                        this.FlatAppearance.BorderSize = 1;//Linh.Tran_210524
                        break;
                    case ButtonStylesEnum.Link:
                        clrfc = Color.White;
                        clrbg = Color.FromArgb(255, 255, 255);
                        clrbd = Color.FromArgb(04, 204, 204);
                        this.FlatAppearance.BorderSize = 1;//Linh.Tran_210524
                        break;
                    case ButtonStylesEnum.Disable:
                        clrfc = Color.White;
                        clrbg = Color.FromArgb(233, 236, 239);
                        clrbd = SystemColors.ActiveBorder;
                        this.FlatAppearance.BorderSize = 1;//Linh.Tran_210524
                        break;
                    case ButtonStylesEnum.Cancel:
                        clrfc = Color.White;
                        clrbg = Color.FromArgb(53, 53, 53);
                        clrbd = Color.FromArgb(38, 38, 38);
                        this.FlatAppearance.BorderSize = 0;//Linh.Tran_210524
                        break;
                    case ButtonStylesEnum.Press:
                        //Linh.Tran_210524
                        clrfc = Color.White;//Color.FromArgb(66, 66, 64);
                        clrbg = SystemColors.Highlight;
                        clrbd = SystemColors.Highlight;
                        //End Linh.Tran_210524
                        break;
                    case ButtonStylesEnum.Selected:
                        //Linh.Tran_210524
                        clrfc = Color.White;//Color.FromArgb(66, 66, 64);
                        clrbg = Color.FromArgb(84, 144, 204);
                        clrbd = Color.FromArgb(84, 144, 204);
                        this.FlatAppearance.BorderSize = 1;//Linh.Tran_210524
                        //End Linh.Tran_210524
                        break;
                }
                //
                this.ForeColor = clrfc;
                this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                //this.FlatAppearance.BorderSize = 1;//Linh.Tran_210524
                this.FlatAppearance.BorderColor = clrbd;
                this.BackColor = clrbg;
                this.FlatAppearance.MouseDownBackColor =
                    this.FlatAppearance.MouseOverBackColor = Color.Empty;//CommonFunctions.GetColorLighter(this.BackColor, 0.3f);
                //End Linh.Tran_210524
            }
        }

        private bool _MSubscribed;
        private void Subscribe(bool enabled)
        {
            if (!enabled) m_MouseHookManager.MouseMove -= HookManager_MouseMove;
            else if (!_MSubscribed) m_MouseHookManager.MouseMove += HookManager_MouseMove;
            _MSubscribed = enabled;
        }
        #endregion//End Methods

        #region Override

        #endregion//End Override
    }

    public enum ButtonStylesEnum
    {
        Default =0,
        Primary =1,
        Success=2,
        Info=3,
        Warning=4,
        Danger=5,
        Link=6,
        Disable = 7,
        Cancel = 8,
        None=9,
        Press = 10,//Linh.Tran_210524
        Selected = 11//Linh.Tran_210524
    }
}
