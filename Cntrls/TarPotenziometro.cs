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
    public partial class TarPotenziometro : Cntrls.BaseCntrls.DoubleBufferedControl
    {
        public event EventHandler SetValue;
        public event EventHandler AllValuesAquired;

        public enum Values
        {
            None = 0,
            Low = 1,
            Middle = 2,
            High = 3
        }

        private Rectangle lowPositionRegion = Rectangle.Empty;
        private Rectangle middlePositionRegion = Rectangle.Empty;
        private Rectangle highPositionRegion = Rectangle.Empty;
        private Rectangle titleRegion = Rectangle.Empty;
        private Rectangle labelsRegion = Rectangle.Empty;
        private Rectangle[] realValueRect;

        private Bitmap[] buttonSetBitmap;
        private Bitmap[] separatorLineBitmap;
        private Bitmap selectedItemBackGroungBitmap;

        private Rectangle lowBtnSetPosRectangle = Rectangle.Empty;
        private Rectangle midBtnSetPosRectangle = Rectangle.Empty;
        private Rectangle highBtnSetPosRectangle = Rectangle.Empty;

        private bool lowBtnPressed = false;
        private bool midBtnPressed = false;
        private bool highBtnPressed = false;

        private const int NONE_SELECTED_INDEX = -1;
        private const int MIDDLE_POSITION_INDEX = 0;
        private const int LOW_POSITION_INDEX = 1;
        private const int HIGH_POSITION_INDEX = 2;

        private const int SEPARATOR_LINE_HOR_INDEX = 0;
        private const int SEPARATOR_LINE_VER_INDEX = 1;

        private int currentPosition = NONE_SELECTED_INDEX;
        public Values CurrentSelected
        {
            get
            {
                switch (currentPosition)
                {
                    case LOW_POSITION_INDEX: return Values.Low;
                    case MIDDLE_POSITION_INDEX: return Values.Middle;
                    case HIGH_POSITION_INDEX: return Values.High;
                    default:
                    case NONE_SELECTED_INDEX: return Values.None;
                }
            }  
        }

        private string[] lowValues;
        private string[] midValues;
        private string[] highValues;

        private string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { title = value; Invalidate(); }
        }

        private string realValue;
        public string RealValue
        {
            get { return realValue; }
            set 
            {
                //if (String.Compare(realValue, value) == 0)
                //    return;

                realValue = value;
                drawRealValues(); 
                //Invalidate();
            }
        }

        private string[] aquiredValues;
        public string[] AquiredValues
        {
            get { return aquiredValues; }  
        }

        private string labels;
        private string[] labelTexts = new string[4];
        public string Labels
        {
            get { return labels; }
            set
            {
                try
                {
                    string[] labelTextsApp = value.Split(new char[] { ';' });

                    if (labelTextsApp.Length != 4)
                        throw new Exception("Valore della proprietà non valido");

                    labelTexts = labelTextsApp;
                    labels = value;

                    Invalidate();
                }
                catch
                {
                    throw new Exception("Valore della proprietà non valido");
                }
            }
        }

        private Font titleFont = new Font("Arial", 10.0f, FontStyle.Regular);
        public Font TitleFont
        {
            get { return titleFont; }
            set { titleFont = value; }
        }

        private Font labelsFont = new Font("Arial", 10.0f, FontStyle.Regular);
        public Font LabelsFont
        {
            get { return labelsFont; }
            set { labelsFont = value; }
        }

        public TarPotenziometro()
        {
            realValue = "---";
            aquiredValues = new string[3] { "---", "---", "---" };

            lowValues = new string[4] { "0 %", "0", realValue, aquiredValues[0] };
            midValues = new string[4] { "50 %", "512", realValue, aquiredValues[0] };
            highValues = new string[4] { "100 %", "1024", realValue, aquiredValues[0] }; 

            realValueRect = new Rectangle[3];

            InitializeComponent();
            Labels = "Label 1;Label 2;Label 3;Label 4";
             
            buttonSetBitmap = new Bitmap[2];
            buttonSetBitmap[0] = (Bitmap)Resources.ResourcesManager.GetResource("buttton88x44.bmp", ResourceType.Image);
            buttonSetBitmap[1] = (Bitmap)Resources.ResourcesManager.GetResource("buttton88x44_pressed.bmp", ResourceType.Image); 

            separatorLineBitmap = new Bitmap[2];
            separatorLineBitmap[0] = (Bitmap)Resources.ResourcesManager.GetResource("line492x1.bmp", ResourceType.Image);
            separatorLineBitmap[1] = (Bitmap)Resources.ResourcesManager.GetResource("line1x168.bmp", ResourceType.Image); 

            if (selectedItemBackGroungBitmap == null) 
                selectedItemBackGroungBitmap = (Bitmap)Resources.ResourcesManager.GetResource("selected_item.bmp", ResourceType.Image); 

            refreshLayout();
        }

        public void SetAquiredValue(string val)
        {
            switch (currentPosition)
            {
                case LOW_POSITION_INDEX:
                    aquiredValues[0] = val;
                    break;

                case MIDDLE_POSITION_INDEX:
                    aquiredValues[1] = val;
                    break;

                case HIGH_POSITION_INDEX:
                    aquiredValues[2] = val;
                    break;
            }
        }

        public void SelectNext()
        {
            switch (currentPosition)
            {
                case NONE_SELECTED_INDEX:
                    SelectValue(Values.Middle);
                    break;

                case LOW_POSITION_INDEX:
                    SelectValue(Values.High);
                    break;

                case MIDDLE_POSITION_INDEX:
                    SelectValue(Values.Low);
                    break;

                case HIGH_POSITION_INDEX:
                    SelectValue(Values.None);

                    if (AllValuesAquired != null)
                        AllValuesAquired.Invoke(this, EventArgs.Empty);

                    break;
            }
        }

        public void SelectPrev()
        {
            switch (currentPosition)
            {
                case NONE_SELECTED_INDEX:
                    return;

                case LOW_POSITION_INDEX:
                    SelectValue(Values.Middle);
                    break;

                case MIDDLE_POSITION_INDEX:
                    SelectValue(Values.None);
                    break;

                case HIGH_POSITION_INDEX:
                    SelectValue(Values.Low);
                    break;
            }
        }

        public void ClearSelected()
        {
            aquiredValues = new string[3] { "---", "---", "---" }; 
            SelectValue(Values.None);
        }

        private void SelectValue(Values val)
        {
            switch (val)
            {
                case Values.None:
                    currentPosition = NONE_SELECTED_INDEX;
                    break;

                case Values.Low:
                    currentPosition = LOW_POSITION_INDEX;
                    break;

                case Values.Middle:
                    currentPosition = MIDDLE_POSITION_INDEX;
                    break;

                case Values.High:
                    currentPosition = HIGH_POSITION_INDEX;
                    break;
            }

            Refresh();
        }

        private void refreshLayout()
        {
            if (buttonSetBitmap == null) return;

            titleRegion = new Rectangle(0, 0, Width, Height / 8);
            labelsRegion = new Rectangle(0, titleRegion.Bottom, Width, titleRegion.Height);
            lowPositionRegion = new Rectangle(0, labelsRegion.Bottom, Width, titleRegion.Height * 2);
            middlePositionRegion = new Rectangle(0, lowPositionRegion.Bottom, Width, titleRegion.Height * 2);
            highPositionRegion = new Rectangle(0, middlePositionRegion.Bottom, Width, titleRegion.Height * 2);

            int buttonRectSize = lowPositionRegion.Width / 5;
            lowBtnSetPosRectangle = new Rectangle(
                lowPositionRegion.Width - buttonRectSize + ((buttonRectSize - buttonSetBitmap[0].Width) / 2),
                lowPositionRegion.Top + ((lowPositionRegion.Height - buttonSetBitmap[0].Height) / 2),
                buttonSetBitmap[0].Width,
                buttonSetBitmap[0].Height);

            midBtnSetPosRectangle = new Rectangle(lowBtnSetPosRectangle.Left, lowPositionRegion.Bottom + ((middlePositionRegion.Height - buttonSetBitmap[0].Height) / 2), lowBtnSetPosRectangle.Width, lowBtnSetPosRectangle.Height);
            highBtnSetPosRectangle = new Rectangle(lowBtnSetPosRectangle.Left, middlePositionRegion.Bottom + ((highPositionRegion.Height - buttonSetBitmap[0].Height) / 2), midBtnSetPosRectangle.Width, lowBtnSetPosRectangle.Height);

            realValueRect = new Rectangle[3] { Rectangle.Empty, Rectangle.Empty, Rectangle.Empty }; 
        }

        protected override void OnResize(EventArgs e)
        { 
            refreshLayout();
            base.OnResize(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            lowBtnPressed = lowBtnSetPosRectangle.Contains(new Point(e.X, e.Y));
            midBtnPressed = midBtnSetPosRectangle.Contains(new Point(e.X, e.Y));
            highBtnPressed = highBtnSetPosRectangle.Contains(new Point(e.X, e.Y));

            Invalidate();
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (midBtnPressed & midBtnSetPosRectangle.Contains(new Point(e.X, e.Y)) & currentPosition == MIDDLE_POSITION_INDEX)
                if (SetValue != null)
                    SetValue.Invoke(this, EventArgs.Empty);

            if (lowBtnPressed & lowBtnSetPosRectangle.Contains(new Point(e.X, e.Y)) & currentPosition == LOW_POSITION_INDEX)
                if (SetValue != null)
                    SetValue.Invoke(this, EventArgs.Empty);

            if (highBtnPressed & highBtnSetPosRectangle.Contains(new Point(e.X, e.Y)) & currentPosition == HIGH_POSITION_INDEX)
                if (SetValue != null)
                    SetValue.Invoke(this, EventArgs.Empty);

            lowBtnPressed = false;
            midBtnPressed = false;
            highBtnPressed = false;

            Invalidate();
            base.OnMouseDown(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (doubleBuffer = new Bitmap(Width, Height))
            using (Graphics gr = Graphics.FromImage(doubleBuffer))
            {
                gr.Clear(BackColor);
                Color frColor = ForeColor;

                using (Brush textShadowBrush = new SolidBrush(Color.FromArgb((frColor.R + BackColor.R) / 2, (frColor.G + BackColor.G) / 2, (frColor.B + BackColor.B) / 2)))
                using (Brush textBrush = new SolidBrush(frColor))
                using (StringFormat sf = new StringFormat())
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;

                    drawTitle(gr, textShadowBrush, textBrush, sf);
                    drawLabels(gr, textShadowBrush, textBrush, sf);
                    drawSelected(gr, sf);
                    drawValues(gr, textShadowBrush, textBrush, sf);
                }

                e.Graphics.DrawImage(doubleBuffer, 0, 0);
            } 
        }

        private void drawTitle(Graphics gr, Brush textShadowBrush, Brush textBrush, StringFormat sf)
        {
            Rectangle shadowRect = new Rectangle(titleRegion.Left + 1, titleRegion.Top + 1, titleRegion.Width, titleRegion.Height);
            gr.DrawString(title, titleFont, textShadowBrush, shadowRect, sf);
            gr.DrawString(title, titleFont, textBrush, titleRegion, sf);
        }

        private void drawLabels(Graphics gr, Brush textShadowBrush, Brush textBrush, StringFormat sf)
        {
            Rectangle labelRect = new Rectangle(labelsRegion.Left, labelsRegion.Top, (labelsRegion.Width / 4) - (buttonSetBitmap[0].Width / 4) - 2, labelsRegion.Height);
            Rectangle labelShadowRect = new Rectangle(labelRect.Left + 1, labelRect.Top + 1, labelRect.Width, labelRect.Height);

            //gr.DrawString(labelTexts[0], labelsFont, textShadowBrush, labelShadowRect, sf);
            gr.DrawString(labelTexts[0], labelsFont, textBrush, labelRect, sf);

            gr.DrawImage(separatorLineBitmap[1], labelRect.Right, labelsRegion.Top + 6);

            labelRect.X += labelRect.Width;
            labelShadowRect.X += labelRect.Width;

            //gr.DrawString(labelTexts[1], labelsFont, textShadowBrush, labelShadowRect, sf);
            gr.DrawString(labelTexts[1], labelsFont, textBrush, labelRect, sf);

            gr.DrawImage(separatorLineBitmap[1], labelRect.Right, labelsRegion.Top + 6);

            labelRect.X += labelRect.Width;
            labelShadowRect.X += labelRect.Width;

            //gr.DrawString(labelTexts[2], labelsFont, textShadowBrush, labelShadowRect, sf);
            gr.DrawString(labelTexts[2], labelsFont, textBrush, labelRect, sf);

            gr.DrawImage(separatorLineBitmap[1], labelRect.Right, labelsRegion.Top + 6);

            labelRect.X += labelRect.Width;
            labelShadowRect.X += labelRect.Width;

            //gr.DrawString(labelTexts[3], labelsFont, textShadowBrush, labelShadowRect, sf);
            gr.DrawString(labelTexts[3], labelsFont, textBrush, labelRect, sf);

            gr.DrawImage(separatorLineBitmap[0], labelsRegion.Left + 16, labelsRegion.Bottom - 1);
            gr.DrawImage(separatorLineBitmap[0], labelsRegion.Left + 16, lowPositionRegion.Bottom - 1);
            gr.DrawImage(separatorLineBitmap[0], labelsRegion.Left + 16, middlePositionRegion.Bottom - 1); 
        }

        private void drawSelected(Graphics gr, StringFormat sf)
        {
            Rectangle buttonRect;
            Point selectedImagePosition;
            int bitmapIndex = 0;

            switch (currentPosition)
            {
                case LOW_POSITION_INDEX:
                    buttonRect = lowBtnSetPosRectangle;
                    selectedImagePosition = new Point(6, lowPositionRegion.Top + 6);

                    if (lowBtnPressed)
                    {
                        buttonRect.X++;
                        buttonRect.Y++;
                        bitmapIndex = 1;
                    }

                    break;

                case MIDDLE_POSITION_INDEX:
                    buttonRect = midBtnSetPosRectangle;
                    selectedImagePosition = new Point(6, middlePositionRegion.Top + 6);

                    if (midBtnPressed)
                    {
                        buttonRect.X++;
                        buttonRect.Y++;
                        bitmapIndex = 1;
                    }
                    break;

                case HIGH_POSITION_INDEX:
                    buttonRect = highBtnSetPosRectangle;
                    selectedImagePosition = new Point(6, highPositionRegion.Top + 6);

                    if (highBtnPressed)
                    {
                        buttonRect.X++;
                        buttonRect.Y++;
                        bitmapIndex = 1;
                    }
                    break;

                default:
                    return;
            }

            gr.DrawImage(selectedItemBackGroungBitmap, selectedImagePosition.X, selectedImagePosition.Y);
            gr.DrawImage(buttonSetBitmap[bitmapIndex], buttonRect.X, buttonRect.Y); 

            using (Brush textShadowBrush = new SolidBrush(Color.Gainsboro))
            using (Brush textBrush = new SolidBrush(Color.Black))
            using (Font textFont = new Font(Font.Name, 14.0f, FontStyle.Regular))
            {
                Rectangle buttonShadow = new Rectangle(buttonRect.Left + 1, buttonRect.Top + 1, buttonRect.Width, buttonRect.Height);
                gr.DrawString("SET", textFont, textShadowBrush, buttonShadow, sf);
                gr.DrawString("SET", textFont, textBrush, buttonRect, sf);
            }  
        }

        private void drawValues(Graphics gr, Brush textShadowBrush, Brush textBrush, StringFormat sf)
        {
            Rectangle textRect = new Rectangle(lowPositionRegion.Left, lowPositionRegion.Top, (lowPositionRegion.Width / 4) - (buttonSetBitmap[0].Width / 4) - 2, lowPositionRegion.Height);

            using (Brush selectedTextBrush = new SolidBrush(Color.Black))
            using (Font selectedTextFont = new Font(Font.Name, Font.Size + 6.0f, FontStyle.Regular))
            {
                gr.DrawString(lowValues[0], currentPosition != LOW_POSITION_INDEX ? Font : selectedTextFont, currentPosition == LOW_POSITION_INDEX ? selectedTextBrush : textBrush, textRect, sf);

                textRect.X += textRect.Width;
                gr.DrawString(lowValues[1], currentPosition != LOW_POSITION_INDEX ? Font : selectedTextFont, currentPosition == LOW_POSITION_INDEX ? selectedTextBrush : textBrush, textRect, sf);

                textRect.X += textRect.Width;

                if (currentPosition != LOW_POSITION_INDEX)
                    gr.DrawString("---", Font, textBrush, textRect, sf);

                if (realValueRect[2].Equals(Rectangle.Empty))
                    realValueRect[0] = new Rectangle(textRect.X + 3, textRect.Y + 9, textRect.Width - 6, textRect.Height - 18);

                textRect.X += textRect.Width;
                gr.DrawString(aquiredValues[0], currentPosition != LOW_POSITION_INDEX ? Font : selectedTextFont, currentPosition == LOW_POSITION_INDEX ? selectedTextBrush : textBrush, textRect, sf);

                textRect = new Rectangle(middlePositionRegion.Left, middlePositionRegion.Top, (middlePositionRegion.Width / 4) - (buttonSetBitmap[0].Width / 4) - 2, middlePositionRegion.Height);

                gr.DrawString(midValues[0], currentPosition != MIDDLE_POSITION_INDEX ? Font : selectedTextFont, currentPosition == MIDDLE_POSITION_INDEX ? selectedTextBrush : textBrush, textRect, sf);

                textRect.X += textRect.Width;
                gr.DrawString(midValues[1], currentPosition != MIDDLE_POSITION_INDEX ? Font : selectedTextFont, currentPosition == MIDDLE_POSITION_INDEX ? selectedTextBrush : textBrush, textRect, sf);

                textRect.X += textRect.Width;

                if (currentPosition != MIDDLE_POSITION_INDEX)
                    gr.DrawString("---", Font, textBrush, textRect, sf);

                if (realValueRect[2].Equals(Rectangle.Empty))
                    realValueRect[1] = new Rectangle(textRect.X + 3, textRect.Y + 9, textRect.Width - 6, textRect.Height - 18);

                textRect.X += textRect.Width;
                gr.DrawString(aquiredValues[1], currentPosition != MIDDLE_POSITION_INDEX ? Font : selectedTextFont, currentPosition == MIDDLE_POSITION_INDEX ? selectedTextBrush : textBrush, textRect, sf);

                textRect = new Rectangle(highPositionRegion.Left, highPositionRegion.Top, (highPositionRegion.Width / 4) - (buttonSetBitmap[0].Width / 4) - 2, highPositionRegion.Height);

                gr.DrawString(highValues[0], currentPosition != HIGH_POSITION_INDEX ? Font : selectedTextFont, currentPosition == HIGH_POSITION_INDEX ? selectedTextBrush : textBrush, textRect, sf);

                textRect.X += textRect.Width;
                gr.DrawString(highValues[1], currentPosition != HIGH_POSITION_INDEX ? Font : selectedTextFont, currentPosition == HIGH_POSITION_INDEX ? selectedTextBrush : textBrush, textRect, sf);

                textRect.X += textRect.Width;

                if (currentPosition != HIGH_POSITION_INDEX)
                    gr.DrawString("---", Font, textBrush, textRect, sf);

                if (realValueRect[2].Equals(Rectangle.Empty))
                    realValueRect[2] = new Rectangle(textRect.X + 3, textRect.Y + 9, textRect.Width - 6, textRect.Height - 18);

                textRect.X += textRect.Width;
                gr.DrawString(aquiredValues[2], currentPosition != HIGH_POSITION_INDEX ? Font : selectedTextFont, currentPosition == HIGH_POSITION_INDEX ? selectedTextBrush : textBrush, textRect, sf);

                drawRealValues();
            }
        }

        private void drawRealValues()
        {
            Rectangle region;
            switch (currentPosition)
            {
                case LOW_POSITION_INDEX: 
                    region = realValueRect[0]; 
                    break;

                case MIDDLE_POSITION_INDEX: 
                    region = realValueRect[1]; 
                    break;

                case HIGH_POSITION_INDEX: 
                    region = realValueRect[2];
                    break;

                default:
                    return;
            }

            Bitmap bmpRealValue = new Bitmap(realValueRect[0].Width, realValueRect[0].Height);
            Graphics gr = Graphics.FromImage(bmpRealValue); 
            
            gr.Clear(Color.LightBlue);
             
            using (Brush textBrush = new SolidBrush(Color.Black))
            using (StringFormat sf = new StringFormat())
            using (Font selectedTextFont = new Font(Font.Name, Font.Size + 6.0f, FontStyle.Regular))
            {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;

                gr.DrawString(realValue, selectedTextFont, textBrush, new Rectangle(0, 0, region.Width, region.Height), sf);
            }

            CreateGraphics().DrawImage(bmpRealValue, region.X, region.Y); 
        }
    } 
}
