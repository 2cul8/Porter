using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

//using ELCCN12.UTILS;

namespace Cntrls
{
    public enum eIOState
    {
        OFF = 0,
        ON = 1
    }
    public enum eIOType
    {
        INPUT = 1,
        OUTPUT = 2,

        NULL = 0
    }

    internal partial class IoViewCntrl : Control
    {
        //public event dGenericIntDelegate eStatusChanged = null;
        //public event dGenericObjectDelegate eSelectionChanged = null;

        internal bool Initializing = false;

        protected eIOState _IOStatus = eIOState.OFF;
        public eIOState IOStatus
        {
            get { return _IOStatus; }
            set 
            {
                if (_IOStatus != value)
                {
                    _IOStatus = value;
                    OnStatusChanged();
                }
            }
        }

        protected Color _IOBorderColor;
        public Color IOBorderColor
        {
            get { return _IOBorderColor; }
            set { _IOBorderColor = value; Refresh(); }
        }

        protected float _IOBorderWidth;
        public float IOBorderWidth
        {
            get { return _IOBorderWidth; }
            set { _IOBorderWidth = value; Refresh(); }
        }

        protected Color _IO_OFF_BackGroundColor;
        public Color IO_OFF_BackGroundColor
        {
            get { return _IO_OFF_BackGroundColor; }
            set { _IO_OFF_BackGroundColor = value; Refresh(); }
        }

        protected Color _IO_ON_BackGroundColor = Color.Lime;
        public Color IO_ON_BackGroundColor
        {
            get { return _IO_ON_BackGroundColor; }
            set { _IO_ON_BackGroundColor = value; Refresh(); }
        }

        protected Color _IO_ForeColor;
        public Color IO_ForeColor
        {
            get { return _IO_ForeColor; }
            set 
            {
                _IO_ForeColor = value;
                if (lblIndex != null)
                    lblIndex.ForeColor = _IO_ForeColor;
            }
        }

        protected int _IO_Index = 0;
        public int IO_Index
        {
            get { return _IO_Index; }
            set 
            {
                _IO_Index = value;
                lblIndex.Text = _IO_Index.ToString();
            }
        }

        protected bool _IsSelected = false;
        public bool IsSelected
        {
            get { return _IsSelected; }
            internal set 
            {
                if (_IsSelected != value)
                {
                    //if (eSelectionChanged != null && !Initializing)
                    //    eSelectionChanged.Invoke((object)this);

                    this.Focus();
                    _IsSelected = value;
                    Refresh();
                }
            }
        }

        protected Point _MatrixLocation = Point.Empty;
        public Point MatrixLoaction
        {
            get { return _MatrixLocation; }
            internal set { _MatrixLocation = value; }
        }

        protected eIOType _Type = eIOType.NULL;
        public eIOType Type
        {
            internal get { return _Type; }
            set { _Type = value; }
        }

        protected Label lblIndex = null;

        public IoViewCntrl()
        {
            InitializeComponent();
            lblIndex = new Label();
            lblIndex.BackColor = _IO_OFF_BackGroundColor;
            lblIndex.Size = new Size(this.Width - 1, 20);
            lblIndex.Location = new Point(1, 1);

            lblIndex.Font = new Font("Arial", 14F, FontStyle.Regular);
            lblIndex.TextAlign = ContentAlignment.TopCenter;

            this.Controls.Add(lblIndex);
        }

        private void OnStatusChanged()
        {
            Refresh();

            //if (eStatusChanged != null && !Initializing)
            //    eStatusChanged.Invoke(IO_Index - 1);
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            //IsSelected = true;

            //if (_Type != eIOType.INPUT)
            //    if (_IOStatus == eIOState.ON)
            //        IOStatus = eIOState.OFF;
            //    else
            //        IOStatus = eIOState.ON;
        }

        public void SetApparance
            (
            Color _IO_ON_COLOR,
            Color _IO_OFF_COLOR,
            Color _IO_FORE_COLOR,
            Color _IO_BORDER_COLOR,
            int _IO_BORDER_WIDTH
            )
        {
            this.BackColor = IO_OFF_BackGroundColor = _IO_OFF_COLOR;
            IO_ON_BackGroundColor = _IO_ON_COLOR;
            IOBorderColor = _IO_BORDER_COLOR;
            IO_ForeColor = _IO_FORE_COLOR;
            IOBorderWidth = (float)_IO_BORDER_WIDTH;
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                OnClick(EventArgs.Empty);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Pen MyPen;
            Graphics G = e.Graphics;

            if (!_IsSelected)
                MyPen = new Pen(_IOBorderColor, _IOBorderWidth);
            else
            {
                //Disegno un triangolo in alto per indicare la selezione.
                MyPen = new Pen(Color.Gainsboro, _IOBorderWidth);
                Point[] Points = new Point[4];

                Points[0] = new Point(3, 3);
                Points[1] = new Point(6, 3);
                Points[2] = new Point(6, 6);
                Points[3] = Points[0];

                G.DrawPolygon(MyPen, Points);
                G.FillPolygon(new SolidBrush(Color.Gainsboro), Points);
            }

            int W = this.Width;
            int H = this.Height;

            Rectangle R = new Rectangle(0, 0, W - ((int)MyPen.Width), H - ((int)MyPen.Width));
            G.DrawRectangle(MyPen, R);

            MyPen.Dispose();

            if (IOStatus == eIOState.ON)
            {
                R = new Rectangle(2, lblIndex.Height + lblIndex.Location.Y + 2, W - 4, H - lblIndex.Height - 5);
                Brush MyBrush = new SolidBrush(_IO_ON_BackGroundColor);
                e.Graphics.FillRectangle(MyBrush, R);
                MyBrush.Dispose();
            } 
                
            base.OnPaint(e);
        }
    }

    public class ListOfIOStatus : List<eIOState>
    {
        public const int IO_COUNT = 48;
    }
}
