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
    public partial class BatteryStatus : BaseCntrls.BlinkControl
    { 
        private const int BATTERY_FULL_BMP_INDEX = 0;
        private const int BATTERY_EMPTY_BMP_INDEX = 1;
        private const int BATTERY_EMPTY_BLINKED_BMP_INDEX = 7;
        private const int BATTERY_CHARGING_BMP_INDEX = 2;
        private const int BATTERY_80_BMP_INDEX = 3;
        private const int BATTERY_60_BMP_INDEX = 4;
        private const int BATTERY_40_BMP_INDEX = 5;
        private const int BATTERY_20_BMP_INDEX = 6;

        private const int LINE_SEPARATOR_EXTENDED = 8;
        private const int LINE_SEPARATOR_EXTENDED_RED = 9;
        private const int BATTERY_STATUS_EXTENDED_OK = 10;
        private const int BATTERY_STATUS_EXTENDED_EMPTY = 11;

        private const int BATTERY_STATUS_OK = 12;
        private const int BATTERY_STATUS_EMPTY = 13;
        private const int LINE_SEPARATOR = 14;
        private const int LINE_SEPARATOR_RED = 15;

        private const int PERCENTAGE_ICON = 16;
        private const int VOLTAGE_ICON = 17;
        private const int HOURGLASS_ICON = 18;
        private const int PERCENTAGE_RED_ICON = 19;
        private const int VOLTAGE_RED_ICON = 20;
        private const int HOURGLASS_RED_ICON = 21;

        private bool expanded = false; 

        private static Bitmap[] allBatteryBmp;

        public bool Expanded
        {
            get { return expanded; }
        }

        private int batteryPercentage = 0;
        public int BatteryPercentage
        {
            get { return batteryPercentage; }
            set 
            {
                if (batteryPercentage == value)
                    return;

                batteryPercentage = (value > 100 ? 100 : (value < 0 ? 0 : value));
                setBatteryStatus();
                Invalidate(); 
            }
        }

        private int battery1Percentage = 0;
        public int Battery1Percentage
        {
            get { return battery1Percentage; }
            set
            {
                if (battery1Percentage == value)
                    return;

                battery1Percentage = (value > 100 ? 100 : (value < 0 ? 0 : value)); 
                Invalidate();
            }
        }

        private int battery2Percentage = 0;
        public int Battery2Percentage
        {
            get { return battery2Percentage; }
            set
            {
                if (battery2Percentage == value)
                    return;

                battery2Percentage = (value > 100 ? 100 : (value < 0 ? 0 : value));
                Invalidate();
            }
        }

        private float battery1Voltage = 0f;
        public float Battery1Voltage
        {
            get { return battery1Voltage; }
            set { battery1Voltage = value; Invalidate(); }
        }

        private float battery2Voltage = 0f;
        public float Battery2Voltage
        {
            get { return battery2Voltage; }
            set { battery2Voltage = value; Invalidate(); }
        }

        private TimeSpan workTime = TimeSpan.FromMinutes(0d);
        public TimeSpan WorkTime
        {
            get { return workTime; }
            set { workTime = value; Invalidate(); }
        }

        private bool batteryCharging = false;
        public bool BatteryCharging
        {
            get { return batteryCharging; }
            set
            {
                if (batteryCharging == value)
                    return;

                batteryCharging = value;
                Invalidate();
            }
        }

        private int collapsedHeight;
        public int CollapsedHeight
        {
            get { return collapsedHeight; }
            set { collapsedHeight = value; }
        }

        private int expandedHeight;
        public int ExpandedHeight
        {
            get { return expandedHeight; }
            set { expandedHeight = value; }
        }

        private int batteryStatus; 

        public BatteryStatus()
        {
            InitializeComponent();

            if (allBatteryBmp == null)
            {
                allBatteryBmp = new Bitmap[22];

                allBatteryBmp[BATTERY_FULL_BMP_INDEX] = (Bitmap)Resources.ResourcesManager.GetResource("battery_full.png", ResourceType.Image);
                allBatteryBmp[BATTERY_EMPTY_BMP_INDEX] = (Bitmap)Resources.ResourcesManager.GetResource("battery_empty.png", ResourceType.Image);
                allBatteryBmp[BATTERY_EMPTY_BLINKED_BMP_INDEX] = (Bitmap)Resources.ResourcesManager.GetResource("battery_empty_blinked.png", ResourceType.Image);
                allBatteryBmp[BATTERY_CHARGING_BMP_INDEX] = (Bitmap)Resources.ResourcesManager.GetResource("battery_charging.png", ResourceType.Image);
                allBatteryBmp[BATTERY_80_BMP_INDEX] = (Bitmap)Resources.ResourcesManager.GetResource("battery_80.png", ResourceType.Image);
                allBatteryBmp[BATTERY_60_BMP_INDEX] = (Bitmap)Resources.ResourcesManager.GetResource("battery_60.png", ResourceType.Image);
                allBatteryBmp[BATTERY_40_BMP_INDEX] = (Bitmap)Resources.ResourcesManager.GetResource("battery_40.png", ResourceType.Image);
                allBatteryBmp[BATTERY_20_BMP_INDEX] = (Bitmap)Resources.ResourcesManager.GetResource("battery_20.png", ResourceType.Image);

                allBatteryBmp[LINE_SEPARATOR_EXTENDED] = (Bitmap)Resources.ResourcesManager.GetResource("line336x3.bmp", ResourceType.Image);
                allBatteryBmp[LINE_SEPARATOR_EXTENDED_RED] = (Bitmap)Resources.ResourcesManager.GetResource("line336x3_red.bmp", ResourceType.Image);
                allBatteryBmp[BATTERY_STATUS_EXTENDED_OK] = (Bitmap)Resources.ResourcesManager.GetResource("batteryStatusExtended.bmp", ResourceType.Image);
                allBatteryBmp[BATTERY_STATUS_EXTENDED_EMPTY] = (Bitmap)Resources.ResourcesManager.GetResource("batteryStatusExtended_empty.bmp", ResourceType.Image);
                allBatteryBmp[BATTERY_STATUS_OK] = (Bitmap)Resources.ResourcesManager.GetResource("batteryStatusOk.bmp", ResourceType.Image);
                allBatteryBmp[BATTERY_STATUS_EMPTY] = (Bitmap)Resources.ResourcesManager.GetResource("batteryStatusEmpty.bmp", ResourceType.Image);
                allBatteryBmp[LINE_SEPARATOR] = (Bitmap)Resources.ResourcesManager.GetResource("line80x1.bmp", ResourceType.Image);
                allBatteryBmp[LINE_SEPARATOR_RED] = (Bitmap)Resources.ResourcesManager.GetResource("line80x1_red.bmp", ResourceType.Image);
                allBatteryBmp[PERCENTAGE_ICON] = (Bitmap)Resources.ResourcesManager.GetResource("percentage.bmp", ResourceType.Image);
                allBatteryBmp[VOLTAGE_ICON] = (Bitmap)Resources.ResourcesManager.GetResource("voltage.bmp", ResourceType.Image);
                allBatteryBmp[HOURGLASS_ICON] = (Bitmap)Resources.ResourcesManager.GetResource("hourglass.bmp", ResourceType.Image);
                allBatteryBmp[PERCENTAGE_RED_ICON] = (Bitmap)Resources.ResourcesManager.GetResource("percentage_red.bmp", ResourceType.Image);
                allBatteryBmp[VOLTAGE_RED_ICON] = (Bitmap)Resources.ResourcesManager.GetResource("voltage_red.bmp", ResourceType.Image);
                allBatteryBmp[HOURGLASS_RED_ICON] = (Bitmap)Resources.ResourcesManager.GetResource("hourglass_red.bmp", ResourceType.Image);
            }

            batteryStatus = BATTERY_FULL_BMP_INDEX; 
        }

        private void setBatteryStatus()
        {
            if (batteryCharging)
            {
                batteryStatus = BATTERY_CHARGING_BMP_INDEX;
                BlinkEnabled = false;
                btnExpand.ResourceNameBase = "expandButton";
                btnCollapse.ResourceNameBase = "collapseButton";
                return;
            }

            if (batteryPercentage > 95)
            {
                batteryStatus = BATTERY_FULL_BMP_INDEX;
                BlinkEnabled = false;
                btnExpand.ResourceNameBase = "expandButton";
                btnCollapse.ResourceNameBase = "collapseButton";
                return;
            }

            if (batteryPercentage >= 80)
            {
                batteryStatus = BATTERY_80_BMP_INDEX;
                BlinkEnabled = false;
                btnExpand.ResourceNameBase = "expandButton";
                btnCollapse.ResourceNameBase = "collapseButton";
                return;
            }

            if (batteryPercentage >= 60)
            {
                batteryStatus = BATTERY_60_BMP_INDEX;
                BlinkEnabled = false;
                btnExpand.ResourceNameBase = "expandButton";
                btnCollapse.ResourceNameBase = "collapseButton";
                return;
            }

            if (batteryPercentage >= 40)
            {
                batteryStatus = BATTERY_40_BMP_INDEX;
                BlinkEnabled = false;
                btnExpand.ResourceNameBase = "expandButton";
                btnCollapse.ResourceNameBase = "collapseButton";
                return;
            }

            if (batteryPercentage >= 20)
            {
                batteryStatus = BATTERY_20_BMP_INDEX;
                BlinkEnabled = false;
                btnExpand.ResourceNameBase = "expandButton";
                btnCollapse.ResourceNameBase = "collapseButton";
                return;
            } 

            BlinkInterval = batteryPercentage > 0 ? (batteryPercentage * 50) + 100 : 100; // Batteria + scarica = blink + veloce
            batteryStatus = BATTERY_EMPTY_BMP_INDEX;
            BlinkEnabled = true;

            btnExpand.ResourceNameBase = "expandButtonRed";
            btnCollapse.ResourceNameBase = "collapseButtonRed";
        }

        private Bitmap getBatteryBitmap()
        {
            switch (batteryStatus)
            { 
                case BATTERY_EMPTY_BMP_INDEX:
                    return BlinkOn ? allBatteryBmp[BATTERY_EMPTY_BMP_INDEX] : allBatteryBmp[BATTERY_EMPTY_BLINKED_BMP_INDEX]; 

                default:
                    return allBatteryBmp[batteryStatus];
            } 
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
                if (batteryStatus == BATTERY_EMPTY_BMP_INDEX)
                    gr.DrawImage(allBatteryBmp[expanded ? BATTERY_STATUS_EXTENDED_EMPTY : BATTERY_STATUS_EMPTY], 0, 0);
                else
                    gr.DrawImage(allBatteryBmp[expanded ? BATTERY_STATUS_EXTENDED_OK : BATTERY_STATUS_OK], 0, 0); 

                Bitmap batteryBmp = getBatteryBitmap();

                Color frColor = ForeColor;
                Color bkColor = BackColor;

                using (Font titleFont = new Font(Font.Name, 18.0f, FontStyle.Regular))
                {
                    Rectangle cntrlGraphicRect = new Rectangle(0, 0, 0, 0);
                    SizeF textSize = gr.MeasureString("0000000000", titleFont);
                    cntrlGraphicRect.Width += (batteryBmp.Width + (int)textSize.Width + 8);
                    cntrlGraphicRect.Height += batteryBmp.Height;
                    cntrlGraphicRect.Location = new Point((Width - cntrlGraphicRect.Width) / 2, (collapsedHeight - cntrlGraphicRect.Height) / 2);

                    if (batteryBmp != null)
                        gr.DrawImage(batteryBmp, cntrlGraphicRect.Right - batteryBmp.Width, cntrlGraphicRect.Top);

                    if (batteryStatus == BATTERY_EMPTY_BMP_INDEX)
                        bkColor = Color.Red;

                    using (Brush textBrush = new SolidBrush(frColor))
                    using (StringFormat sf = new StringFormat())
                    {
                        sf.Alignment = StringAlignment.Center;
                        sf.LineAlignment = StringAlignment.Center;

                        RectangleF textRect = new RectangleF(cntrlGraphicRect.Left, cntrlGraphicRect.Top, textSize.Width, cntrlGraphicRect.Height / 3);  
                        gr.DrawString(Text, titleFont, textBrush, textRect, sf);

                        textRect.Y += cntrlGraphicRect.Height / 3;
                        textRect.Height *= 2;
                        gr.DrawString(batteryPercentage.ToString() + "%", Font, textBrush, textRect, sf);

                        if (batteryStatus == BATTERY_EMPTY_BMP_INDEX)
                            gr.DrawImage(allBatteryBmp[LINE_SEPARATOR_RED], (int)textRect.Left + ((int)(textRect.Width - allBatteryBmp[LINE_SEPARATOR].Width)) / 2, (int)textRect.Top);
                        else
                            gr.DrawImage(allBatteryBmp[LINE_SEPARATOR], (int)textRect.Left + ((int)(textRect.Width - allBatteryBmp[LINE_SEPARATOR].Width)) / 2, (int)textRect.Top);
                    }
                }

                if (expanded)
                {
                    gr.DrawImage(allBatteryBmp[batteryStatus == BATTERY_EMPTY_BMP_INDEX ? LINE_SEPARATOR_EXTENDED_RED : LINE_SEPARATOR_EXTENDED],
                                    (Width - allBatteryBmp[batteryStatus == BATTERY_EMPTY_BMP_INDEX ? LINE_SEPARATOR_EXTENDED_RED : LINE_SEPARATOR_EXTENDED].Width) / 2,
                                    collapsedHeight);

                    Rectangle batt1Rect = new Rectangle(0, collapsedHeight + 1, Width / 2, expandedHeight - collapsedHeight);
                    Rectangle batt2Rect = new Rectangle(Width / 2 + 1, collapsedHeight + 1, Width / 2, expandedHeight - collapsedHeight); 

                    using (Brush textBrush = new SolidBrush(frColor))
                    using (StringFormat sf = new StringFormat())
                    using (Font titleFont = new Font(Font.Name, 16.0f, FontStyle.Regular))
                    using (Font percentageFont = new Font(Font.Name, 20.0f, FontStyle.Regular))
                    using (Font timeFont = new Font(Font.Name, 22.0f, FontStyle.Regular))
                    {
                        sf.Alignment = StringAlignment.Center;
                        sf.LineAlignment = StringAlignment.Center;

                        Rectangle batt1TextRect = new Rectangle(batt1Rect.Left, batt1Rect.Top, batt1Rect.Width, batt1Rect.Height / 5);
                        gr.DrawString("Batteria 1", titleFont, textBrush, batt1TextRect, sf); 

                        Rectangle batt2TextRect = new Rectangle(batt2Rect.Left, batt2Rect.Top, batt2Rect.Width, batt2Rect.Height / 5);
                        gr.DrawString("Batteria 2", titleFont, textBrush, batt2TextRect, sf);

                        batt1TextRect.Y += batt1TextRect.Height;
                        gr.DrawString(battery1Percentage.ToString() + "%", percentageFont, textBrush, batt1TextRect, sf); 

                        batt2TextRect.Y += batt2TextRect.Height;
                        gr.DrawString(battery2Percentage.ToString() + "%", percentageFont, textBrush, batt2TextRect, sf);

                        gr.DrawImage(allBatteryBmp[batteryStatus == BATTERY_EMPTY_BMP_INDEX ? PERCENTAGE_RED_ICON : PERCENTAGE_ICON], batt1TextRect.Right - 12, batt1TextRect.Top);

                        batt1TextRect.Y += batt1TextRect.Height;
                        gr.DrawString(battery1Voltage.ToString("0.0") + "V", percentageFont, textBrush, batt1TextRect, sf); 

                        batt2TextRect.Y += batt2TextRect.Height;
                        gr.DrawString(battery2Voltage.ToString("0.0") + "V", percentageFont, textBrush, batt2TextRect, sf);

                        gr.DrawImage(allBatteryBmp[batteryStatus == BATTERY_EMPTY_BMP_INDEX ? VOLTAGE_RED_ICON : VOLTAGE_ICON], batt1TextRect.Right - 12, batt1TextRect.Top);

                        batt1TextRect.Y += batt1TextRect.Height;
                        gr.DrawImage(allBatteryBmp[batteryStatus == BATTERY_EMPTY_BMP_INDEX ? HOURGLASS_RED_ICON : HOURGLASS_ICON], batt1TextRect.Right - 12, batt1TextRect.Top);

                        batt1TextRect.Y += batt1TextRect.Height;

                        batt1TextRect.Width = Width;
                        batt1TextRect.Y -= 4;
                        batt1TextRect.X = batt1Rect.Left;

                        gr.DrawString(workTime.Hours.ToString("00") + ":" + workTime.Minutes.ToString("00"), timeFont, textBrush, batt1TextRect, sf);
                    }
                }

                e.Graphics.DrawImage(doubleBuffer, 0, 0);
            }

            base.OnPaint(e);
        } 

        private void expandRequested(object sender, EventArgs e)
        { 
            if (!expanded)
            {
                Height = expandedHeight;
                expanded = true;

                btnExpand.Visible = false;
                btnCollapse.Visible = true;
                BringToFront();
            }
            else
            {
                Height = collapsedHeight;

                btnExpand.Visible = true;
                btnCollapse.Visible = false;
                expanded = false;
                BringToFront();
            }

            Invalidate();
        }
    }
}
