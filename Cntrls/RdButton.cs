using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Cntrls
{
    public partial class RdButton : UserControl
    {
        public event EventHandler CheckStateChanged = null;

        private const float BORDER_WIDTH = 1.0F;

        private string _Text = string.Empty;
        public override string Text
        {
            get { return _Text; }
            set { _Text = value; Refresh(); }
        }

        private bool _Checked = false;
        public bool Checked
        {
            get { return _Checked; }
        }

        private Color _BorderColor = Color.Transparent;
        public Color BorderColor
        {
            get { return _BorderColor; }
            set { _BorderColor = value; Refresh(); }
        }

        private Color _BackColorOnMouseDown = Color.Transparent;
        public Color BackColorOnMouseDown
        {
            get { return _BackColorOnMouseDown; }
            set { _BackColorOnMouseDown = value; }
        }

        private Color _InternalGraphicColor = Color.Transparent;
        public Color InternalGraphicColor
        {
            get { return _InternalGraphicColor; }
            set { _InternalGraphicColor = value; }
        } 

        public RdButton()
        {
            InitializeComponent();
        } 

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
        }

        private Bitmap BufferBmp = null;
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (BufferBmp == null)
                BufferBmp = new Bitmap(Width, Height);

            Graphics Gr = Graphics.FromImage(BufferBmp);

            Brush MyBrush = new SolidBrush(_InternalGraphicColor);

            Point[] Points1 = new Point[4];
            Points1[0] = new Point(0, this.Height / 3);
            Points1[1] = new Point(this.Height / 3, 0);
            Points1[2] = new Point(0, 0);
            Points1[3] = Points1[0];

            Gr.FillPolygon(MyBrush, Points1);

            Point[] Points2 = new Point[4];
            Points2[0] = new Point(this.Width, this.Height - (this.Height / 3));
            Points2[1] = new Point(this.Width - (this.Height / 3), this.Height);
            Points2[2] = new Point(this.Width, this.Height);
            Points2[3] = Points2[0];

            Gr.FillPolygon(MyBrush, Points2);

            Pen MyPen = new Pen(_BorderColor, BORDER_WIDTH);

            Rectangle Rect = new Rectangle(0, 0, this.Width - (int)(BORDER_WIDTH), this.Height - (int)(BORDER_WIDTH));
            Gr.DrawRectangle(MyPen, Rect);

            RectangleF TextRect = new RectangleF(BORDER_WIDTH, BORDER_WIDTH, this.Width - (BORDER_WIDTH * 2) - 26, this.Height - (BORDER_WIDTH * 2));
            StringFormat SF = new StringFormat();

            SF.Alignment = StringAlignment.Center;
            SF.LineAlignment = StringAlignment.Center;

            MyBrush = new SolidBrush(ForeColor);

            Gr.DrawString(_Text, Font, MyBrush, TextRect, SF); 

            MyPen.Dispose();
            MyBrush.Dispose();
            SF.Dispose();

            e.Graphics.DrawImage(BufferBmp, 0, 0); 
        }

        protected override void OnResize(EventArgs e)
        {
            BufferBmp = null;

            if (this.Height < 26)
                this.Height = 26;

            int Y = (this.Height - sLed.Height) / 2;

            sLed.Location = new Point(this.Width - 20 - Y, Y);
            Invalidate();
            base.OnResize(e);
        }

        protected override void  OnClick(EventArgs e)
        {
            if (_Checked)
                return;

            _Checked = true;

            SuspendLayout();
            RefreshState();
            ResumeLayout(true);

            if (CheckStateChanged != null)
                CheckStateChanged.Invoke(this, EventArgs.Empty);

            ResetOther();
        }

        public void SetChecked()
        {
            if (_Checked)
                return;

            _Checked = true;

            SuspendLayout();
            RefreshState(); 
            ResumeLayout(true);

            if (CheckStateChanged != null)
                CheckStateChanged.Invoke(this, EventArgs.Empty);

            ResetOther();
        }

        private void SetUnchecked()
        {
            if (!_Checked)
                return;

            _Checked = false;

            SuspendLayout();
            RefreshState(); 
            ResumeLayout(true); 
        }

        private void RefreshState()
        {
            sLed.SetLedStatus(_Checked ? StatusLeds.eStatusLed.GREEN : StatusLeds.eStatusLed.BLACK);
        }

        private void ResetOther()
        {
            if (Parent == null)
                return;

            foreach (Control Cntrl in Parent.Controls)
                if (Cntrl is RdButton)
                    if (!Cntrl.Equals(this))
                        ((RdButton)Cntrl).SetUnchecked();
        }

        private void rbClick(object sender, EventArgs e)
        {
            OnClick(e);
        } 

        private Color BackRetail = Color.Transparent;
        private void OnMouseDownEvent(object sender, MouseEventArgs e)
        {
            BackRetail = BackColor;
            BackColor = BackColorOnMouseDown;
        }

        private void OnMouseUpEvent(object sender, MouseEventArgs e)
        { 
            BackColor = BackRetail;
        } 
    }
}
