using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using SagoPorter.Controlli; 
using PorterProto;

namespace SagoPorter
{
    public partial class FrmSpecial : Form
    {
        public event EventHandler HideSpecialRequested;

        private enum ShowedFunction
        {
            Info = 0,
            Zeri = 1,
            Parametri = 2,
            InOut = 3,
            Settaggi = 4,

            none = 9999
        }

        private ShowedFunction currentShowed = ShowedFunction.none;

        public FrmSpecial()
        {
            Utils.SpecialUserLoggedIn += new EventHandler(onSpecialUserLogIn);
            Utils.SpecialUserLoggedOut += new EventHandler(onSpecialUserLogOut);

            InitializeComponent(); 

            Location = new Point(800, 0);
            //base.Show();
        }

        private void onSpecialUserLogIn(object sender, EventArgs e)
        {
            btnShowInputOutput.Visible = true;
            btnShowParametri.Visible = true;
            btnShowTaratura.Visible = true;

            btnLogin.Visible = false;
            btnLogout.Visible = true;
        }

        private void onSpecialUserLogOut(object sender, EventArgs e)
        {
            btnShowInputOutput.Visible = false;
            btnShowParametri.Visible = false;
            btnShowTaratura.Visible = false;

            btnLogin.Visible = true;
            btnLogout.Visible = false;
        }

        public new void Show()
        {
            setShowedFunction(ShowedFunction.Info);
            Location = new Point(0, 0);
            BringToFront();
            base.Show();
        }

        public new void Hide()
        {
            Location = new Point(800, 0);
            SendToBack();

            if (HideSpecialRequested != null)
                HideSpecialRequested.Invoke(this, EventArgs.Empty); 
        }

        public new void Close()
        {
            //controlloParametri.manageClose();
            base.Close();
        }

        private void onExitRequested(object sender, EventArgs e)
        {
            Hide();
        }

        private void setShowedFunction(ShowedFunction toShow)
        {
            if (toShow == currentShowed)
                return;

            switch (toShow)
            {
                case ShowedFunction.Info:
                    btnShowInfo.Location = new Point(-10, btnShowInfo.Top);
                    btnShowParametri.Location = new Point(-40, btnShowParametri.Top);
                    btnShowInputOutput.Location = new Point(-40, btnShowInputOutput.Top);
                    btnShowSettaggi.Location = new Point(-40, btnShowSettaggi.Top);
                    btnShowTaratura.Location = new Point(-40, btnShowTaratura.Top);

                    btnShowInfo.TextMarginLeft = 0;
                    btnShowParametri.TextMarginLeft = 16;
                    btnShowInputOutput.TextMarginLeft = 16;
                    btnShowSettaggi.TextMarginLeft = 16;
                    btnShowTaratura.TextMarginLeft = 16;

                    controlloTaratura.Hide();
                    controlloInformazioni.Show();
                    controlloParametri.Hide();
                    controlloSettaggi.Hide();
                    break;

                case ShowedFunction.InOut:
                    //btnShowInfo.Location = new Point(-40, btnShowInfo.Top);
                    //btnShowParametri.Location = new Point(-40, btnShowParametri.Top);
                    //btnShowInputOutput.Location = new Point(-10, btnShowInputOutput.Top);
                    //btnShowSettaggi.Location = new Point(-40, btnShowSettaggi.Top);
                    //btnShowTaratura.Location = new Point(-40, btnShowTaratura.Top);

                    //btnShowInfo.TextMarginLeft = 16;
                    //btnShowParametri.TextMarginLeft = 16;
                    //btnShowInputOutput.TextMarginLeft = 0;
                    //btnShowSettaggi.TextMarginLeft = 16;
                    //btnShowTaratura.TextMarginLeft = 16;

                    //controlloTaratura.Hide();
                    //controlloInformazioni.Hide();
                    break;

                case ShowedFunction.Parametri:
                    btnShowInfo.Location = new Point(-40, btnShowInfo.Top);
                    btnShowParametri.Location = new Point(-10, btnShowParametri.Top);
                    btnShowInputOutput.Location = new Point(-40, btnShowInputOutput.Top);
                    btnShowSettaggi.Location = new Point(-40, btnShowSettaggi.Top);
                    btnShowTaratura.Location = new Point(-40, btnShowTaratura.Top);

                    btnShowInfo.TextMarginLeft = 16;
                    btnShowParametri.TextMarginLeft = 0;
                    btnShowInputOutput.TextMarginLeft = 16;
                    btnShowSettaggi.TextMarginLeft = 16;
                    btnShowTaratura.TextMarginLeft = 16;

                    controlloParametri.Show();
                    controlloTaratura.Hide();
                    controlloInformazioni.Hide();
                    controlloSettaggi.Hide();
                    break;

                case ShowedFunction.Settaggi:
                    btnShowInfo.Location = new Point(-40, btnShowInfo.Top);
                    btnShowParametri.Location = new Point(-40, btnShowParametri.Top);
                    btnShowInputOutput.Location = new Point(-40, btnShowInputOutput.Top);
                    btnShowSettaggi.Location = new Point(-10, btnShowSettaggi.Top);
                    btnShowTaratura.Location = new Point(-40, btnShowTaratura.Top);

                    btnShowInfo.TextMarginLeft = 16;
                    btnShowParametri.TextMarginLeft = 16;
                    btnShowInputOutput.TextMarginLeft = 16;
                    btnShowSettaggi.TextMarginLeft = 0;
                    btnShowTaratura.TextMarginLeft = 16;

                    controlloSettaggi.Show();
                    controlloTaratura.Hide();
                    controlloInformazioni.Hide();
                    controlloParametri.Hide();
                    break;

                case ShowedFunction.Zeri:
                    btnShowInfo.Location = new Point(-40, btnShowInfo.Top);
                    btnShowParametri.Location = new Point(-40, btnShowParametri.Top);
                    btnShowInputOutput.Location = new Point(-40, btnShowInputOutput.Top);
                    btnShowSettaggi.Location = new Point(-40, btnShowSettaggi.Top);
                    btnShowTaratura.Location = new Point(-10, btnShowTaratura.Top);

                    btnShowInfo.TextMarginLeft = 16;
                    btnShowParametri.TextMarginLeft = 16;
                    btnShowInputOutput.TextMarginLeft = 16;
                    btnShowSettaggi.TextMarginLeft = 16;
                    btnShowTaratura.TextMarginLeft = 0;

                    controlloTaratura.Show();
                    controlloInformazioni.Hide();
                    controlloParametri.Hide();
                    controlloSettaggi.Hide();
                    break;
            }

            currentShowed = toShow;
        }

        private void showInfoRequested(object sender, EventArgs e)
        {
            setShowedFunction(ShowedFunction.Info);
        }

        private void showTaraturaRequested(object sender, EventArgs e)
        {
            setShowedFunction(ShowedFunction.Zeri);
        }

        private void showParametriRequested(object sender, EventArgs e)
        {
            setShowedFunction(ShowedFunction.Parametri);
        }

        private void showInputOutputRequested(object sender, EventArgs e)
        {
            setShowedFunction(ShowedFunction.InOut);
        }

        private void showSettaggiRequested(object sender, EventArgs e)
        {
            setShowedFunction(ShowedFunction.Settaggi);
        }

        private void loginRequested(object sender, EventArgs e)
        {
            if (!Utils.LoggedIn) 
                Utils.LogIn(Cntrls.Boxes.Boxes.ShowPasswordPad().GetHashCode()); 
            else
                Utils.LogOut();
        }
    }
}