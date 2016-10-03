using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Cntrls.Boxes;

namespace SagoPorter.Controlli
{
    public partial class ControlloSettaggi : UserControl
    {
        private enum Pages
        {
            Language = 0,
            Controls = 1,
        }

        private Pages currentShowed = Pages.Language;

        public ControlloSettaggi()
        {
            InitializeComponent();

            Resources.Settings.LoadingTextOn += new EventHandler(loadingTextOn);
            Resources.Settings.LoadingTextDone += new EventHandler(loadingTextDone);
        }

        public new void Show()
        { 
            Visible = true;
            BringToFront();
        }

        public new void Hide() 
        {
            Visible = false;
            SendToBack();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics gr = e.Graphics;

            using (Pen leftLinePen = new Pen(Color.FromArgb(64, 64, 64)))
                gr.DrawLine(leftLinePen, 0, 0, 0, Height);

            base.OnPaint(e);
        }

        private void loadingTextDone(object sender, EventArgs e)
        {
            if (InvokeRequired)
                Invoke(new EventHandler(loadingTextDone), new object[] { sender, e });
            else
                Boxes.CloseLoadingDialog();
        }

        private void loadingTextOn(object sender, EventArgs e)
        {
            if (InvokeRequired)
                Invoke(new EventHandler(loadingTextOn), new object[] { sender, e });
            else
                Boxes.ShowLoadingDialog("Global.3", "ControlloSettaggi.Message.1", (frmLoadingBox.ShowedMessageDelegate)delegate
                {
                    return "ControlloSettaggi.Message.1";
                });
        }

        private void showNextPageRequested(object sender, EventArgs e)
        {
            switch (currentShowed)
            {
                case Pages.Language:
                    if (!Utils.LoggedIn)
                        if (RequestLogin())
                            ShowPage(Pages.Controls);
                        else { }
                    else
                        ShowPage(Pages.Controls);
                    break;

                case Pages.Controls: 
                    ShowPage(Pages.Language);
                    break;
            }
        }

        private void showPrevPageRequested(object sender, EventArgs e)
        {
            switch (currentShowed)
            {
                case Pages.Language:
                    if (!Utils.LoggedIn)
                        if (RequestLogin())
                            ShowPage(Pages.Controls);
                        else { }
                    else
                        ShowPage(Pages.Controls);
                    break;

                case Pages.Controls:
                    ShowPage(Pages.Language);
                    break;
            }
        }

        private bool RequestLogin()
        {
            return Utils.LogIn(Cntrls.Boxes.Boxes.ShowPasswordPad().GetHashCode());
        }

        private void ShowPage(Pages toShow)
        {
            if (toShow == currentShowed)
                return;

            switch (toShow)
            {
                case Pages.Language:
                    pnlControls.Visible = false;
                    pnlLanguage.Visible = true;
                    pnlLanguage.BringToFront();
                    lblTitle.TextLabel = "ControlloSettaggi.lblTitle.Text.1";
                    break;

                case Pages.Controls:
                    pnlLanguage.Visible = false;
                    pnlControls.Visible = true;
                    pnlControls.BringToFront();
                    lblTitle.TextLabel = "ControlloSettaggi.lblTitle.Text.2";
                    break;
            }

            currentShowed = toShow;
        }

        private void minimizeRequested(object sender, EventArgs e)
        {
            WindowsManager.InvokeMinimizeRequested();
        }

        private void closeAllRequested(object sender, EventArgs e)
        {
            WindowsManager.InvokeCloseAllRequested();
        }

        private void setItalianLanguageRequested(object sender, EventArgs e)
        {
            Resources.Settings.SetSetting(Resources.SettingOptions.Language, "0");
        }

        private void setEnglishLanguageRequested(object sender, EventArgs e)
        {
            Resources.Settings.SetSetting(Resources.SettingOptions.Language, "1");
        }

        private void setSpanishLanguageRequested(object sender, EventArgs e)
        {
            Resources.Settings.SetSetting(Resources.SettingOptions.Language, "2");
        }

        private void showPrevRequested(object sender, EventArgs e)
        {

        }

        private void showNextRequested(object sender, EventArgs e)
        {

        }
    }
}
