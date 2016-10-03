using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Cntrls
{ 
    public partial class CkCntrl : UserControl
    {
        public event EventHandler ChekedStateChanged = null;

        private const int CNTRL_WIDTH = 20;
        private const int CNTRL_HEIGHT = 20;

        private static Bitmap CkBitmap = null;

        private bool _Checked = false;
        public bool Checked
        {
            get { return _Checked; }
            set
            {
                if (_Checked != value)
                {
                    _Checked = value;
                    Refresh();

                    if (ChekedStateChanged != null)
                        ChekedStateChanged.Invoke(this, EventArgs.Empty); 
                }
            }
        }

        private Color _BorderColor = Color.FromArgb(32, 32, 32);
        public Color BorderColor
        {
            get { return _BorderColor; }
            set { _BorderColor = value; Refresh(); }
        }

        public CkCntrl()
        {
            InitializeComponent(); 
            Size = new Size(CNTRL_WIDTH, CNTRL_HEIGHT);
            BackColor = Color.FromArgb(32, 32, 32);

            if (CkBitmap == null)
                CkBitmap = Cntrls.Properties.Resources.CheckedIcon;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle bRect = new Rectangle(0, 0, Width - 1, Height - 1);
            Pen MyPen = new Pen(_BorderColor); 

            e.Graphics.DrawRectangle(MyPen, bRect);

            MyPen.Dispose();

            if (_Checked)
            {
                Rectangle iRect = new Rectangle(1, 1, Width - 2, Height - 2);
                e.Graphics.DrawImage((Image)CkBitmap, iRect, new Rectangle(0, 0, CkBitmap.Width, CkBitmap.Height), GraphicsUnit.Pixel);
            }

            base.OnPaint(e);
        }

        protected override void OnClick(EventArgs e)
        {
            Checked = !_Checked; 
            base.OnClick(e);
        }
    }
}
