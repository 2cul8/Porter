using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Cntrls.BaseCntrls
{
    public partial class BlinkControl : RoundedControl
    {
        private static List<BlinkControl> blinkControlsList;
        private static Timer tmrBlink;

        private const int MIN_BLINK_DURATION = 100;

        private int currentBlinkTime = 0; 

        private bool blinkOn = false; 
        protected bool BlinkOn
        {
            get { return blinkOn; }
        }

        private int blinkInterval;
        public int BlinkInterval
        {
            get { return blinkInterval; }
            set 
            { 
                if (value <= 200)
                    blinkInterval = 200;
                else if (value <= 300)
                    blinkInterval = 300;
                else if (value <= 500)
                    blinkInterval = 500;
                else
                    blinkInterval = 1000; 
            }
        }

        private bool blinkEnabled = false;
        public bool BlinkEnabled
        {
            get { return blinkEnabled; }
            set 
            {
                if (blinkEnabled & !value)
                {
                    blinkOn = false;
                    OnBlinkSwitched();
                }

                blinkEnabled = value; 
                manageBlink();
            }
        }

        protected Color blinkColor = Color.Transparent;
        public Color BlinkColor
        {
            get { return blinkColor; }
            set { blinkColor = value; }
        }

        public BlinkControl()
        {
            //if (blinkControlsList == null)
            //    blinkControlsList = new List<BlinkControl>();

            //if (tmrBlink == null)
            //{
            //    tmrBlink = new Timer();
            //    tmrBlink.Interval = MIN_BLINK_DURATION;
            //    tmrBlink.Enabled = true;
            //    tmrBlink.Tick += new EventHandler(onBlink);
            //}
             
            InitializeComponent();

            //blinkControlsList.Add(this);
        } 

        private void manageBlink()
        {
            if (BlinkEnabled)
                if (Environment.TickCount - currentBlinkTime > blinkInterval)
                {
                    currentBlinkTime = Environment.TickCount;
                    blinkOn = !blinkOn;
                    OnBlinkSwitched();
                }
        }

        protected virtual void OnBlinkSwitched() { }

        private static void onBlink(object sender, EventArgs e)
        { 
            //foreach (BlinkControl blinkCntrl in blinkControlsList)
            //    if (blinkCntrl.blinkEnabled)
            //        blinkCntrl.manageBlink(); 
        }
    }
}
