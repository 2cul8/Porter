using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Cntrls
{
    public partial class StatusBarCntrl : BaseCntrls.DoubleBufferedControl
    {
        private Bitmap[] statusOffBitmaps;
        private Bitmap[] statusOnBitmaps; 

        private bool[] flagsStatus;
        public bool[] FlagStatus
        {
            get { return flagsStatus; }
            set 
            {
                if (flagsStatus == null)
                {
                    flagsStatus = value;
                    Invalidate();
                    return;
                }

                if (flagsStatus.Length != value.Length)
                {
                    flagsStatus = value;
                    Invalidate();
                    return;
                }

                if (value == null)
                {
                    flagsStatus = value;
                    Invalidate();
                    return;
                }

                flagsStatus = value;
                Invalidate(); 
            }
        }

        public StatusBarCntrl()
        {
            InitializeComponent(); 
        }

        public void SetBitmaps(Bitmap[] bitmapsOff, Bitmap[] bitmapsOn)
        {
            if (bitmapsOff.Length != bitmapsOn.Length)
                return;

            statusOffBitmaps = bitmapsOff;
            statusOnBitmaps = bitmapsOn;
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
                gr.Clear(BackColor);

                if (flagsStatus != null)
                    if (statusOffBitmaps != null & statusOnBitmaps != null & flagsStatus != null)
                    {
                        int currentLocation = Width;

                        for (int i = 0; i < statusOffBitmaps.Length; i++)
                        {
                            currentLocation -= statusOnBitmaps[i].Width;
                            gr.DrawImage(flagsStatus[i] ? statusOnBitmaps[i] : statusOffBitmaps[i], currentLocation, 0);
                        }
                    }

                e.Graphics.DrawImage(doubleBuffer, 0, 0);
            } 
        }
    }
}
