using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Cntrls
{
    public partial class LedLine : UserControl
    {
        private StatusLeds.eStatusLed _LedStatus = StatusLeds.eStatusLed.BLACK;
        public StatusLeds.eStatusLed LedStatus
        {
            get { return _LedStatus; }
            set { _LedStatus = value; }
        }

        private byte CurrentOnLed = 0;

        public LedLine()
        {
            InitializeComponent();
        }

        protected override void OnResize(EventArgs e)
        {
            this.Size = new Size(Width, 26);
            base.OnResize(e);
        }

        private void CreateLedLine()
        {

        }

        private void refresh(object sender, EventArgs e)
        {
            ShutDownAllLeds();

            switch (CurrentOnLed)
            {
                case 0:
                    statusLeds1.SetLedStatus(_LedStatus);
                    CurrentOnLed = 1;
                    break;

                case 1:
                    statusLeds2.SetLedStatus(_LedStatus);
                    CurrentOnLed = 2;
                    break;

                case 2:
                    statusLeds3.SetLedStatus(_LedStatus);
                    CurrentOnLed = 3;
                    break;

                case 3:
                    statusLeds4.SetLedStatus(_LedStatus);
                    CurrentOnLed = 4;
                    break;

                case 4:
                    statusLeds5.SetLedStatus(_LedStatus);
                    CurrentOnLed = 5;
                    break;

                case 5:
                    statusLeds6.SetLedStatus(_LedStatus);
                    CurrentOnLed = 6;
                    break;

                case 6:
                    statusLeds7.SetLedStatus(_LedStatus);
                    CurrentOnLed = 7;
                    break;

                case 7:
                    statusLeds8.SetLedStatus(_LedStatus);
                    CurrentOnLed = 8;
                    break;

                case 8:
                    statusLeds9.SetLedStatus(_LedStatus);
                    CurrentOnLed = 9;
                    break;

                case 9:
                    statusLeds10.SetLedStatus(_LedStatus);
                    CurrentOnLed = 10;
                    break;

                case 10:
                    statusLeds11.SetLedStatus(_LedStatus);
                    CurrentOnLed = 11;
                    break;

                case 11:
                    statusLeds12.SetLedStatus(_LedStatus);
                    CurrentOnLed = 12;
                    break;

                case 12:
                    statusLeds13.SetLedStatus(_LedStatus);
                    CurrentOnLed = 0;
                    break; 
            }
        }

        private void ShutDownAllLeds()
        {
            statusLeds1.SetLedStatus(StatusLeds.eStatusLed.BLACK);
            statusLeds2.SetLedStatus(StatusLeds.eStatusLed.BLACK);
            statusLeds3.SetLedStatus(StatusLeds.eStatusLed.BLACK);
            statusLeds4.SetLedStatus(StatusLeds.eStatusLed.BLACK);
            statusLeds5.SetLedStatus(StatusLeds.eStatusLed.BLACK);
            statusLeds6.SetLedStatus(StatusLeds.eStatusLed.BLACK);
            statusLeds7.SetLedStatus(StatusLeds.eStatusLed.BLACK);
            statusLeds8.SetLedStatus(StatusLeds.eStatusLed.BLACK);
            statusLeds9.SetLedStatus(StatusLeds.eStatusLed.BLACK);
            statusLeds10.SetLedStatus(StatusLeds.eStatusLed.BLACK);
            statusLeds11.SetLedStatus(StatusLeds.eStatusLed.BLACK);
            statusLeds12.SetLedStatus(StatusLeds.eStatusLed.BLACK); 
            statusLeds13.SetLedStatus(StatusLeds.eStatusLed.BLACK); 
        }

        public void EnableLedLine()
        {
            tmrRefresh.Enabled = true;
        }

        public void DisableLedLine()
        {
            tmrRefresh.Enabled = false;
        }
    }
}
