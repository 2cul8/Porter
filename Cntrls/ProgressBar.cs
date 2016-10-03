//#define GRADIENT_FILL_ENABLE

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
    public partial class ProgressBar : UserControl
    {
        private Color _ProgressBarColor;
        public Color ProgresBar
        {
            get { return _ProgressBarColor; }
            set { _ProgressBarColor = value; }
        }

        private Color _ProgressBarBorderColor;
        public Color ProgressBarBorderColor
        {
            get { return _ProgressBarBorderColor; }
            set { _ProgressBarBorderColor = value; }
        }

        private int _MaxValue = 0;
        public int MaxValue
        {
            get { return _MaxValue; }
            set { _MaxValue = value; }
        }

        private int _MinValue = 0;
        public int MinValue
        {
            get { return _MinValue; }
            set { _MinValue = value; }
        }

        private int _CurrentValue = 0;
        public int CurrentValue
        {
            get { return _CurrentValue; }
            set 
            {
                if (value == _CurrentValue)
                    return;
                _CurrentValue = value; 
                PerformStep(0); 
            }
        }

        public ProgressBar()
        {
            InitializeComponent();
        }

        private bool DrawBorder = true;

        public void PerformStep()
        {
            PerformStep(1);
        } 

        private void PerformStep(int StepValue)
        {
            Graphics G = CreateGraphics();
            Rectangle RPBar = Rectangle.Empty;

            _CurrentValue += StepValue;

            if (_CurrentValue == 0)
            {
                G.Clear(this.BackColor);
                RPBar = new Rectangle(0, 0, this.Width, this.Height);
                DrawBorder = true;
                OnPaint(new PaintEventArgs(G, RPBar));
                return;
            }

            if ((_CurrentValue + StepValue) < _MaxValue)
            {
                int _PBarInterval = _MaxValue - _MinValue;
                int pBarWidth = ((this.Width - 4) * _CurrentValue) / _PBarInterval;

                int RefreshWidth = this.Width / _MaxValue;

                RPBar = new Rectangle((pBarWidth - RefreshWidth >= 1 ? pBarWidth - RefreshWidth + 1: 0), 2, RefreshWidth, this.Height - 4); 

                DrawBorder = (pBarWidth - 10) < 2;
                OnPaint(new PaintEventArgs(G, RPBar)); 
                DrawBorder = true;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Pen MyPen = new Pen(_ProgressBarBorderColor);

            if (DrawBorder)
            { 
                Rectangle RControl = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
                e.Graphics.DrawRectangle(MyPen, RControl);
            }

            if (_CurrentValue > 0)
            {
                int RefreshWidth = this.Width / _MaxValue;
                int _PBarInterval = _MaxValue - _MinValue;
                int pBarWidth = ((this.Width - 4) * _CurrentValue) / _PBarInterval;
                
#if GRADIENT_FILL_ENABLE

                Rectangle RPBar = new Rectangle(2, 2, pBarWidth, this.Height - 4);

                Color StartEndColor = _ProgressBarColor;
                Color MidColor = Color.Black; //Color.FromArgb
                                        //(
                                        //255 - (StartEndColor.R) + 64,
                                        //255 - (StartEndColor.G) + 64,
                                        //255 - (StartEndColor.B) + 64
                                        //);


                e.Graphics.Clip = new Region(RPBar);

                Utils.DrawDoubleFillGradient
                    (
                    e.Graphics.GetHdc(),
                    StartEndColor,
                    StartEndColor,
                    MidColor,
                    PointToClient(new Point(RPBar.X, RPBar.Y)),
                    new Point(RPBar.Right, RPBar.Bottom),
                    0x00
                    );

#else

                Rectangle RPBar = new Rectangle(pBarWidth - RefreshWidth + 2, 2, RefreshWidth + 1, this.Height - 4);

                Brush PBarBrush = new SolidBrush(_ProgressBarColor);
                MyPen = new Pen(Color.Black);
                 
                e.Graphics.FillRectangle(PBarBrush, RPBar);
                RPBar = new Rectangle(2, 2, pBarWidth - 1, this.Height - 5);
                //e.Graphics.DrawRectangle(MyPen, RPBar);
                PBarBrush.Dispose();
                MyPen.Dispose();

#endif

                e.Graphics.Clip = new Region(RPBar);
                base.OnPaint(e);
                return;
            }

            MyPen.Dispose();
            base.OnPaint(e);
        }
    }
}
