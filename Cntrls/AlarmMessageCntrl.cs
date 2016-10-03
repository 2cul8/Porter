using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Resources;

namespace Cntrls
{
    public partial class AlarmMessageCntrl : Cntrls.BaseCntrls.DoubleBufferedControl
    {
        //private const int ALARM_INFORMATION_BITMAP = 0;
        //private const int ALARM_ERROR_BITMAP = 1;
        //private const int ALARM_WARNING_BITMAP = 2;

        //private Bitmap[] backGroundBitmaps;

        private string alarmText = string.Empty;
        public string AlarmText
        {
            get { return alarmText; }
            set 
            {
                if (string.Compare(value, alarmText) == 0) 
                    return;

                alarmText = value; 
                Invalidate(); 
            }
        }

        private int alarmLevel = 0;
        public int AlarmLevel
        {
            get { return alarmLevel; }
            set
            {
                if (alarmLevel == value)
                    return;

                alarmLevel = value;
                Invalidate();
            }
        }
         
        public AlarmMessageCntrl()
        {
            InitializeComponent();

            //backGroundBitmaps = new Bitmap[3];
            //backGroundBitmaps[ALARM_INFORMATION_BITMAP] = (Bitmap)Resources.Resources.GetResource("alarm646x80_green.bmp", ResourceType.Image);
            //backGroundBitmaps[ALARM_ERROR_BITMAP] = (Bitmap)Resources.Resources.GetResource("alarm646x80_red.bmp", ResourceType.Image);
            //backGroundBitmaps[ALARM_WARNING_BITMAP] = (Bitmap)Resources.Resources.GetResource("", ResourceType.Image);
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

                //switch (alarmLevel)
                //{
                //    case 0:
                //        gr.DrawImage(backGroundBitmaps[ALARM_ERROR_BITMAP], 0, 0);
                //        cntrlColor = Color.Red;
                //        break;

                //    default:
                //        gr.DrawImage(backGroundBitmaps[ALARM_INFORMATION_BITMAP], 0, 0);
                //        cntrlColor = Color.Black;
                //        break;
                //}

                //using (Brush textShadowBrush = new SolidBrush(Color.FromArgb((ForeColor.R + cntrlColor.R) / 2, (ForeColor.G + cntrlColor.G) / 2, (ForeColor.B + cntrlColor.B) / 2)))
                using (Brush textBrush = new SolidBrush(ForeColor))
                using (StringFormat sf = new StringFormat())
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;

                    Rectangle textRect = ClientRectangle;
                    textRect.Location = new Point(textRect.Left, textRect.Top);

                    Rectangle shadowRect = new Rectangle(textRect.X + 1, textRect.Y + 1, textRect.Width, textRect.Height);
                    //gr.DrawString(alarmText, Font, textShadowBrush, shadowRect, sf);  
                    gr.DrawString(alarmText, Font, textBrush, textRect, sf);
                }

                e.Graphics.DrawImage(doubleBuffer, 0, 0); 
            }

            base.OnPaint(e);
        }
    }
}
