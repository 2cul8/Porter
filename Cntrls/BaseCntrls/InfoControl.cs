using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Resources;

namespace Cntrls.BaseCntrls
{
    public partial class InfoControl : DoubleBufferedControl
    {
        protected Bitmap backGround = null;
        protected Bitmap separatorLine = null; 

        protected Font titleFont = new Font("Arial", 10.0f, FontStyle.Regular);
        public Font TitleFont
        {
            get { return titleFont; }
            set { titleFont = value; Invalidate(); }
        }

        public InfoControl()
        {
            InitializeComponent();

            backGround = (Bitmap)Resources.Resources.GetResource("backGround352x100.bmp", ResourceType.Image); 
            separatorLine = (Bitmap)Resources.Resources.GetResource("line336x3.bmp", ResourceType.Image);
        }

        protected override void OnPaint(PaintEventArgs e)
        { 
            //Graphics gr = Graphics.FromImage(doubleBuffer);
            //gr.Clear(BackColor);

            //gr.DrawImage(backGround, 0, 0);

            //e.Graphics.DrawImage(doubleBuffer, 0, 0); 
            //base.OnPaint(e);
        }
    }
}
