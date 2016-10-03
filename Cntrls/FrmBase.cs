using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Utility;

namespace Cntrls
{
    public partial class FrmBase : Form
    {
        private bool _DoubleBuffered = false;
        public bool DoubleBuffered
        {
            get { return _DoubleBuffered; }
            set { _DoubleBuffered = value; }
        }

        public new Color BackColor
        {
            get { return base.BackColor; }
            set { return; }
        }

        public FrmBase()
        {
            InitializeComponent();

            this.BackColor = Color.Black;
            this.ForeColor = Color.Red;

            Refresh();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            DoubleBufferBmp = null;
            BackColor = BackColor;
        }

        protected override void OnPaint(PaintEventArgs e)
        {  
            //base.OnPaint(e);
        }

        private Bitmap DoubleBufferBmp = null;
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (DoubleBufferBmp == null)
                DoubleBufferBmp = new Bitmap(Width, Height);

            Graphics Gr = Graphics.FromImage(DoubleBufferBmp);

            Rectangle rToFill = ClientRectangle;

            Gr.FillRectangle(new SolidBrush(Color.Black), ClientRectangle); 
            rToFill.Width -= 80;

            Utils.DrawGradientFill
                (
                Gr,
                Color.Red,
                Color.Black,
                ClientRectangle,
                Utils.GradientDirection.TopToBottom
                );

            Brush MyBrush = new SolidBrush(Color.Black);
            Rectangle rDown = new Rectangle(0, Height - 40, Width, 40);
            Gr.FillRectangle(MyBrush, rDown);

            e.Graphics.DrawImage(DoubleBufferBmp, 0, 0);
        }
    }
}