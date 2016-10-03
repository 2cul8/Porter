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
    public partial class OperatorCntrl : Cntrls.BaseCntrls.InfoControl
    {
        //private Bitmap logo = null;
        public event EventHandler ManageLogRequested;

        private string nomeOperatore = string.Empty;
        public string NomeOperatore
        {
            get { return nomeOperatore; }
            set 
            {
                if (string.Compare(nomeOperatore, value) == 0)
                    return;

                nomeOperatore = value; 
                Invalidate(); 
            }
        }

        private string idOperatore = string.Empty;
        public string IdOperatore
        {
            get { return idOperatore; }
            set
            {
                if (string.Compare(idOperatore, value) == 0)
                    return; 

                idOperatore = value; 
                Invalidate();
            }
        }

        public OperatorCntrl()
        {
            InitializeComponent();

            backGround = (Bitmap)Resources.Resources.GetResource("label352x162.bmp", ResourceType.Image); 
            separatorLine = (Bitmap)Resources.Resources.GetResource("line336x3.bmp", ResourceType.Image);
        }

        private void manageLogRequested(object sender, EventArgs e)
        {
            if (ManageLogRequested != null)
                ManageLogRequested.Invoke(new object(), e);
        }

        protected override void OnPaint(PaintEventArgs e)
        { 
            using (doubleBuffer = new Bitmap(Width, Height))
            using (Graphics gr = Graphics.FromImage(doubleBuffer))
            {
                gr.DrawImage(backGround, 0, 0);
                Color frColor = ForeColor;

                gr.Clip = new Region(new Rectangle(12, 12, ClientRectangle.Width - 24, ClientRectangle.Height - 24));
                gr.Clear(BackColor);
                gr.ResetClip();
                 
                using (Brush textBrush = new SolidBrush(frColor))
                using (StringFormat sf = new StringFormat())
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;

                    RectangleF textRect = new RectangleF(3, 3, Width - 6, Height / 3); 
                    textRect.X--; textRect.Y--;
                    gr.DrawString(Text, titleFont, textBrush, textRect, sf);

                    textRect = new RectangleF(3, Height / 3, Width - 6, Height / 3); 

                    gr.DrawImage(separatorLine, (Width - separatorLine.Width) / 2, (int)textRect.Top);

                    textRect.X--; textRect.Y--;
                    gr.DrawString(nomeOperatore, Font, textBrush, textRect, sf);

                    textRect = new RectangleF(3, (Height / 3) * 2, Width - 6, Height / 3); 

                    gr.DrawImage(separatorLine, (Width - separatorLine.Width) / 2, (int)textRect.Top);

                    textRect.X--; textRect.Y--;
                    gr.DrawString("ID: " + idOperatore, Font, textBrush, textRect, sf);
                }

                e.Graphics.DrawImage(doubleBuffer, 0, 0);
            } 
        } 
    }
}
