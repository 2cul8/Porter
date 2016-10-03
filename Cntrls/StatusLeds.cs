using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

//using Utility;

namespace Cntrls
{
    public partial class StatusLeds : UserControl
    {
        #region Enumerazioni
        public enum eStatusLed
        {
            BLACK,
            GRAY,
            GREEN,
            ORANGE,
            YELLOW,
            RED,
            NONE
        };
        #endregion

        #region Campi privati
        private static List<Bitmap> _bmLeds = null;
        private Timer TmrRefresh = null;
        private bool LampStat = false;
        private Bitmap MyBlackLed;
        private Bitmap ToShow;

        private delegate void dSetStatusLed(eStatusLed Stat);
        #endregion

        #region Proprietà pubbliche
        private eStatusLed _status = eStatusLed.NONE;
        public eStatusLed Status
        {
            set { _status = value; }          
        }

        private Color _BorderColor = Color.Black;
        public Color BorderColor
        {
            get { return _BorderColor; }
            set { _BorderColor = value; }
        }

        private static bool InvokeRunning = false;
        public void SetLedStatus(eStatusLed Stat)
        {
            if (Stat == _status)
                return;

            if (InvokeRequired)
            {
                if (InvokeRunning) return;
                InvokeRunning = true;
                Invoke(new dSetStatusLed(SetLedStatus), new object[] { (object)Stat });
            }
            else
            {
                //Entro solo al cambiamento di stato.
                _status = Stat;

                if (_bmLeds != null)
                    if (((int)_status) < _bmLeds.Count)
                        ToShow = _bmLeds[(int)_status];
                    else
                        ToShow = _bmLeds[0]; 

                Invalidate(); 
                InvokeRunning = false;
            }
        } 

        private bool _selected = false;
        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; Invalidate(); }
        }
        #endregion
        
        public StatusLeds()
        {
            InitializeComponent();
            try
            {
                if (_bmLeds == null)
                {
                    _bmLeds = new List<Bitmap>();
                    //0
                    _bmLeds.Add(MyBlackLed = ToShow = Cntrls.Properties.Resources.BlackLed_DarkGrayBack);
                    //1
                    _bmLeds.Add(Cntrls.Properties.Resources.GreenLed_DarkGreenBack);
                    //2
                    _bmLeds.Add(Cntrls.Properties.Resources.GreenLed_DarkGreenBack);
                    //3
                    _bmLeds.Add(Cntrls.Properties.Resources.OrangeLed_DarkOrangeBack);
                    //4
                    _bmLeds.Add(Cntrls.Properties.Resources.YellowLed_DarkYellowBack);
                    //5
                    _bmLeds.Add(Cntrls.Properties.Resources.RedLed_DarkRedBack);
                }

                ToShow = _bmLeds[0]; 
            }
            catch { }
        }     

        protected override void OnPaint(PaintEventArgs e)
        { }

        private Bitmap BufferBmp = null;
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            this.Size = new Size(ToShow.Width + 4, ToShow.Height + 4);

            if (BufferBmp == null)
                BufferBmp = new Bitmap(Width, Height);

            Graphics Gr = Graphics.FromImage(BufferBmp);

            if (ToShow != null)
                Gr.DrawImage(ToShow, 2, 2);
            else
                Gr.FillRectangle(new SolidBrush(Color.Black), ClientRectangle);

            Pen MyPen1 = new Pen(_BorderColor, 1F);
            Pen MyPen2 = new Pen(Color.FromArgb(32, 32, 32), 1F);

            Rectangle RBord1 = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            Rectangle RBord2 = new Rectangle(1, 1, this.Width - 3, this.Height - 3);

            Gr.DrawRectangle(MyPen1, RBord1);
            Gr.DrawRectangle(MyPen2, RBord2); 

            MyPen1.Dispose();
            MyPen2.Dispose();

            e.Graphics.DrawImage(BufferBmp, 0, 0); 
        }
    }
}
