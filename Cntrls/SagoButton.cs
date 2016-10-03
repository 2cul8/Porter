using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;  
 
namespace Cntrls
{
    public sealed partial class SagoButton : Cntrls.BaseCntrls.BitmapButton
    {
        private Color backColor = Color.Transparent; 
        public new Color BackColor
        {
            get { return backColor; }
            set { backColor = value; Invalidate(); }
        }

        private Color buttonColor = Color.Transparent;
        public Color ButtonColor
        {
            get { return buttonColor; }
            set { buttonColor = value; Invalidate(); }
        } 

        private int textMerginLeft = 0;
        public int TextMarginLeft
        {
            get { return textMerginLeft; }
            set { textMerginLeft = value; Invalidate(); }
        }

        private int padding = 0;
        public int Padding
        {
            get { return padding; }
            set { padding = value; }
        }

        private string headTextLabel = string.Empty;
        private string headText = string.Empty;
        public string HeadTextLabel
        {
            get { return headTextLabel; }
            set
            {
                if (string.Compare(headTextLabel, value) == 0)
                    return;

                headTextLabel = value;
                headText = LoadString(headTextLabel);
                Invalidate();
            }
        } 

        public SagoButton()
        { 
            InitializeComponent(); 
            Invalidate();
        } 

        protected override void OnResize(EventArgs e)
        { 
            Invalidate();
            base.OnResize(e);
        }

        protected override void OnBlinkSwitched()
        {
            Refresh();
            //Invalidate();
            //base.OnBlinkSwitch();
        }

        protected override void OnLanguageChanged()
        {
            headTextLabel = LoadString(textLabel);
            base.OnLanguageChanged();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Color btnColor = buttonColor;
            Color brdColor = borderColor; 

            if (bmpButtonNormal != null)
                using (doubleBuffer = new Bitmap(Width, Height))
                using (Graphics gr = Graphics.FromImage(doubleBuffer))
                {  
                    if (!enabled)
                         gr.DrawImage(bmpButtonDisabled, 0, 0);
                    else
                        if (BlinkOn & !Pressed)
                            gr.DrawImage(bmpButtonBlinked, 0, 0);
                        else if (Selected)
                            gr.DrawImage(bmpButtonSelected, 0, 0);
                        else if (Pressed)
                            gr.DrawImage(bmpButtonPressed, 0, 0);
                        else
                            gr.DrawImage(bmpButtonNormal, 0, 0);  

                    Color frColor = ForeColor;

                    if (BlinkOn & !Pressed)
                        frColor = Color.FromArgb(((ForeColor.R * 5) + btnColor.R) / 6, ((ForeColor.G * 5) + btnColor.G) / 6, ((ForeColor.B * 5) + btnColor.B) / 6);

                    using (Brush textShadowBrush = new SolidBrush(Color.FromArgb((frColor.R + btnColor.R) / 2, (frColor.G + btnColor.G) / 2, (frColor.B + btnColor.B) / 2)))
                    using (Brush textBrush = new SolidBrush(frColor))
                    using (StringFormat sf = new StringFormat())
                    {
                        sf.Alignment = StringAlignment.Center;
                        sf.LineAlignment = StringAlignment.Center;

                        Rectangle textRect = ClientRectangle;
                        textRect.Location = new Point(textRect.Left + textMerginLeft, textRect.Top);

                        if (!string.IsNullOrEmpty(Text))
                        {
                            if (!Pressed & enabled & !Selected)
                            {
                                Rectangle shadowRect = new Rectangle(textRect.X + 1, textRect.Y + 1, textRect.Width, textRect.Height);
                                gr.DrawString(Text, Font, textShadowBrush, shadowRect, sf);
                            }

                            if (!BlinkOn)
                                gr.DrawString(Text, Font, textBrush, textRect, sf);
                        }

                        if (!string.IsNullOrEmpty(headText))
                        {
                            textRect = new Rectangle(0, 3, Width, 16);

                            using (SolidBrush topCleanBrush = new SolidBrush(Pressed ? blinkColor : BackColor))
                                gr.FillRectangle(topCleanBrush, textRect);

                            using (Font topFont = new Font(Font.Name, 10.0f, FontStyle.Bold))
                                gr.DrawString(headText, topFont, textBrush, textRect, sf);
                        }
                    }

                    e.Graphics.DrawImage(doubleBuffer, 0, 0); 
                }

            base.OnPaint(e);
        } 
    }
} 