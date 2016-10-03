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
    public partial class ControlloInformazioni : UserControl
    {
        enum Informations
        {
            stwInfo = 0,
            statistics = 1,
        }

        private Informations showedInfo = Informations.stwInfo;

        public ControlloInformazioni()
        {
            InitializeComponent();

            lblTitleDevice.TextLabel = "ControlloInformazioni.lblTitleDevice.Text";
            lblTitleTerm.TextLabel = "ControlloInformazioni.lblTitleTerm.Text";
            lblTitleProto.TextLabel = "ControlloInformazioni.lblTitleProto.Text";
            lblDistance.TextLabel = "ControlloInformazioni.lblDistance.Text";
            lblUm.TextLabel = "m";

            Utils.SpecialUserLoggedIn += new EventHandler(onSpecialUserLogIn);
            Utils.SpecialUserLoggedOut += new EventHandler(onSpecialUserLogOut);

            showInfo(Informations.stwInfo);
        }

        public new void Show()
        {
            lblDeviceVersion.TextLabel = (string)DeviceData.GetDeviceData(DeviceDataDef.Version);
            lblTermVersion.TextLabel = TerminalInfo.TermVersion;
            lblProtoVersion.TextLabel = ProtoInfo.Version;

            Visible = true;
            BringToFront(); 
        }

        public new void Hide()
        {
            Visible = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics gr = e.Graphics;

            using (Pen leftLinePen = new Pen(Color.FromArgb(64, 64, 64)))
                gr.DrawLine(leftLinePen, 0, 0, 0, Height);

            base.OnPaint(e);
        } 

        private void onSpecialUserLogIn(object sender, EventArgs e)
        {
            btnClearStored.Visible = true;
        }

        private void onSpecialUserLogOut(object sender, EventArgs e)
        {
            btnClearStored.Visible = false;
        }

        private void showInfo(Informations toShow)
        {
            switch (toShow)
            {
                case Informations.stwInfo:
                    lblTitle.TextLabel = "ControlloInformazioni.lblTitle.Text.1";
                    pnlSftwInfo.Visible = true;
                    pnlSftwInfo.BringToFront();

                    if (DeviceInterface.DeviceConnected)
                        DeviceInterface.DisattivaTask(Tasks.TASK_SPEC_PLC);

                    tmrRefreshInfo.Enabled = false;
                    break;

                case Informations.statistics:
                    lblTitle.TextLabel = "ControlloInformazioni.lblTitle.Text.2";
                    pnlStatistics.Visible = true;
                    pnlStatistics.BringToFront();

                    DeviceInterface.AttivaTask(Tasks.TASK_SPEC_PLC);
                    tmrRefreshInfo.Enabled = true;
                    break;
            }

            showedInfo = toShow;
        } 

        private void refreshTmrTick(object sender, EventArgs e)
        {
            switch (showedInfo)
            {
                case Informations.stwInfo:
                    break;

                case Informations.statistics:
                    DeviceInterface.AttivaTask(Tasks.TASK_SPEC_PLC); 

                    int distanceStored = ((int)DeviceData.GetDeviceData(DeviceDataDef.DistanceStored));

                    if (distanceStored > 1000)
                    {
                        lblStoredDistance.TextLabel = (((float)distanceStored) / 1000f).ToString("0.00");
                        lblUm.TextLabel = "Km";
                    }
                    else
                    {
                        lblStoredDistance.TextLabel = distanceStored.ToString(); 
                        lblUm.TextLabel = "m";
                    }
                    break;
            }
        }

        private void showNextRequested(object sender, EventArgs e)
        {
            switch (showedInfo)
            {
                case Informations.statistics:
                    break;

                case Informations.stwInfo:
                    showInfo(Informations.statistics);
                    break;
            }
        }

        private void showPrevRequested(object sender, EventArgs e)
        {
            switch (showedInfo)
            {
                case Informations.statistics:
                    showInfo(Informations.stwInfo);
                    break;

                case Informations.stwInfo:
                    break;
            }
        } 

        private void clearStoredRequested(object sender, EventArgs e)
        {
            DeviceInterface.InviaFunzione(51);
        }
    }
}
