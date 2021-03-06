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
    public partial class ControlloTaratura : UserControl
    { 
        private int[] currentAdcsValues;

        private int[] tarAquiredVelocità;
        private int[] tarAquiredSterzo;

        public ControlloTaratura()
        {
            InitializeComponent();
        }

        public new void Show()
        {
            Visible = true;
            BringToFront();

            tarPotVelocità.ClearSelected();
            tarPotVelocità.SelectNext();
            tarPotSterzo.ClearSelected();

            currentAdcsValues = new int[2];

            tarAquiredVelocità = new int[3];
            tarAquiredSterzo = new int[3];

            tmrReadAdc.Enabled = true;
        }

        public new void Hide()
        {
            tmrReadAdc.Enabled = false;
            Visible = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics gr = e.Graphics;

            using (Pen leftLinePen = new Pen(Color.FromArgb(64, 64, 64)))
                gr.DrawLine(leftLinePen, 0, 0, 0, Height);

            base.OnPaint(e);
        }

        private void SetPotVelocitàValue(object sender, EventArgs e)
        {
            switch (tarPotVelocità.CurrentSelected)
            {
                case Cntrls.TarPotenziometro.Values.Low:
                    tarAquiredVelocità[0] = currentAdcsValues[0];
                    break;

                case Cntrls.TarPotenziometro.Values.Middle:
                    tarAquiredVelocità[1] = currentAdcsValues[0];
                    break;

                case Cntrls.TarPotenziometro.Values.High:
                    tarAquiredVelocità[2] = currentAdcsValues[0];
                    break;
            }

            tarPotVelocità.SetAquiredValue(currentAdcsValues[0].ToString());
            tarPotVelocità.SelectNext();

            if (tarPotVelocità.CurrentSelected == Cntrls.TarPotenziometro.Values.None)
                tarPotSterzo.SelectNext();
        }

        private void SetPotSterzoValue(object sender, EventArgs e)
        {
            switch (tarPotSterzo.CurrentSelected)
            {
                case Cntrls.TarPotenziometro.Values.Low:
                    tarAquiredSterzo[0] = currentAdcsValues[0];
                    break;

                case Cntrls.TarPotenziometro.Values.Middle:
                    tarAquiredSterzo[1] = currentAdcsValues[0];
                    break;

                case Cntrls.TarPotenziometro.Values.High:
                    tarAquiredSterzo[2] = currentAdcsValues[0];
                    break;
            }

            tarPotSterzo.SetAquiredValue(currentAdcsValues[0].ToString());
            tarPotSterzo.SelectNext();
        }

        private void onTmrTick(object sender, EventArgs e)
        {
            AdcList adcList = (AdcList)DeviceData.GetDeviceData(DeviceDataDef.AdcValues);

            tarPotVelocità.RealValue = (currentAdcsValues[0] = adcList[1].Value).ToString();
            tarPotSterzo.RealValue = (currentAdcsValues[1] = adcList[0].Value).ToString();
        }
    }
}
