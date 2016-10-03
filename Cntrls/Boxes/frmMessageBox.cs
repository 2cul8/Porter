using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cntrls.Boxes
{
    public partial class frmMessageBox : Form
    {
        public enum MessageLevel
        {
            Message = 0,
            Warning = 1,
            Error = 2
        } 

        public enum BoxResponse
        {
            YesNo = 0,
            Ok = 1,
            YesNoReturn = 2 
        } 


        private static Bitmap warningBackGroundBitmap;
        private static Bitmap errorBackGroundBitmap;
        private static Bitmap messageBackGroundBitmap;

        private Bitmap currentBackGround;

        public frmMessageBox()
        {
            if (messageBackGroundBitmap == null)
                messageBackGroundBitmap = (Bitmap)Resources.Resources.GetResource("dialogMessageBackGround.bmp", Resources.ResourceType.Image);

            if (warningBackGroundBitmap == null)
                warningBackGroundBitmap = (Bitmap)Resources.Resources.GetResource("dialogWarningBackGround.bmp", Resources.ResourceType.Image);

            if (errorBackGroundBitmap == null)
                errorBackGroundBitmap = (Bitmap)Resources.Resources.GetResource("dialogErrorBackGround.bmp", Resources.ResourceType.Image);

            InitializeComponent();

            Size = new Size(460, 240);
            Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - Height) / 2);
        }

        private new DialogResult ShowDialog()
        {
            throw new InvalidOperationException();
        }

        public DialogResult ShowDialog(string title, string text, MessageLevel lvl, params object[] args)
        {
            lblTitle.TextLabel = title;
            lblText.TextLabel = lblText.SetLabelFormatArgs(text, args);

            btnClose.Visible = true;

            btnYesResponse.Visible =
                btnNoResponse.Visible =
                btnReturnResponse.Visible = false;

            switch (lvl)
            {
                case MessageLevel.Message:
                    currentBackGround = messageBackGroundBitmap;
                    break;

                case MessageLevel.Warning:
                    currentBackGround = warningBackGroundBitmap;
                    break;

                case MessageLevel.Error:
                    currentBackGround = errorBackGroundBitmap;
                    break;
            }

            return base.ShowDialog();
        }

        public DialogResult ShowDialog(string title, string text, MessageLevel lvl, BoxResponse response)
        {
            lblTitle.TextLabel = title;
            lblText.TextLabel = text;

            btnClose.Visible = false;

            switch (response)
            {
                case BoxResponse.Ok:
                    btnYesResponse.TextLabel = "FrmMessageBox.btnYesResponse.Text.1";
                    btnYesResponse.Visible = true;
                    btnNoResponse.Visible = false;
                    btnReturnResponse.Visible = false;
                    break;

                case BoxResponse.YesNo:
                    btnYesResponse.TextLabel = "FrmMessageBox.btnYesResponse.Text.2";
                    btnYesResponse.Visible = true;
                    btnNoResponse.Visible = true;
                    btnReturnResponse.Visible = false;
                    break;

                case BoxResponse.YesNoReturn:
                    btnYesResponse.Visible = true;
                    btnNoResponse.Visible = true;
                    btnReturnResponse.Visible = true;
                    break;
            }

            switch (lvl)
            {
                case MessageLevel.Message:
                    currentBackGround = messageBackGroundBitmap;
                    break;

                case MessageLevel.Warning:
                    currentBackGround = warningBackGroundBitmap;
                    break;

                case MessageLevel.Error:
                    currentBackGround = errorBackGroundBitmap;
                    break;
            }

            return base.ShowDialog();
        } 

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap doubleBuffer = new Bitmap(Width, Height);
            Graphics gr = Graphics.FromImage(doubleBuffer);

            gr.DrawImage(currentBackGround, 0, 0); 
            e.Graphics.DrawImage(doubleBuffer, 0, 0); 
        }

        private void closeRequested(object sender, EventArgs e)
        {
            Close();
        }

        private void yesResponseRequested(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void noResponseRequested(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void returnResponseRequested(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Retry;
            Close();
        }
    }
}