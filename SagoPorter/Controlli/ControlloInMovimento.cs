using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using PorterProto;

namespace SagoPorter.Controlli
{
    public partial class ControlloInMovimento : UserControl
    {
        private static Bitmap backGroundBitmap;
        private bool hideRequested = false;
        private int hideTick = 0;

        public ControlloInMovimento()
        {
            InitializeComponent(); 
            backGroundBitmap = (Bitmap)Resources.ResourcesManager.GetResource("movingStatusBackGround.bmp", Resources.ResourceType.Image);

            lblSterzoTitle.TextLabel = "Sterzo:";
            lblVelocitàTitle.TextLabel = "Velocità:";
        }

        public new void Show()
        {
            if (Visible) return;

            Visible = true;
            BringToFront();
        }

        public new void Hide()
        {
            if (!Visible) return;

            Visible = false;
            SendToBack();
        }

        public new void Refresh()
        { 
            AdcList adcValues = (AdcList)DeviceData.GetDeviceData(DeviceDataDef.AdcValues);

            lblVelocità.TextLabel = adcValues[1].Value.ToString();
            lblSterzo.TextLabel = adcValues[0].Value.ToString(); 
        }

        protected override void OnPaint(PaintEventArgs e)
        { 
            Graphics gr = Graphics.FromImage(backGroundBitmap);
            e.Graphics.DrawImage(backGroundBitmap, 0, 0); 
        }

        private void onTimerHideTick(object sender, EventArgs e)
        {
            Refresh();

            if (hideRequested)
                if (hideTick >= 4)
                {
                    hideTick = 0;
                    tmrHide.Enabled = false;
                    hideRequested = false; 
                }
                else
                    hideTick++;
            else
            {
                hideTick = 0;
                tmrHide.Enabled = false;
            }  
        }
    }
}
