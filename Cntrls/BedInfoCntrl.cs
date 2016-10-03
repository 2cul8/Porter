using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Cntrls
{
    public partial class BedInfoCntrl : Cntrls.BaseCntrls.InfoControl
    {  
        public string TitleLabel
        {
            get { return lblTitle.TextLabel; }
            set { lblTitle.TextLabel = value; }
        }

        public string InfoLabel
        {
            get { return lblInfo.TextLabel; }
            set { lblInfo.TextLabel = value; }
        }

        public BedInfoCntrl()
        {
            InitializeComponent();
        }

        protected override void OnResize(EventArgs e)
        { 
            base.OnResize(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (doubleBuffer = new Bitmap(Width, Height))
            using (Graphics gr = Graphics.FromImage(doubleBuffer))
            {
                gr.Clip = new Region(new Rectangle(12, 12, ClientRectangle.Width - 24, ClientRectangle.Height - 24));
                gr.Clear(BackColor);
                gr.ResetClip();

                gr.DrawImage(backGround, 0, 0); 

                e.Graphics.DrawImage(doubleBuffer, 0, 0);
            }

            base.OnPaint(e);
        }
    }
}
