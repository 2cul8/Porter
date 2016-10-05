using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cntrls.Boxes
{
    public partial class frmLoadingBox : Form
    {
        public delegate string ShowedMessageDelegate();

        private Bitmap backGroundBitmap;
        private ShowedMessageDelegate messageDelegate;

        string message = string.Empty;
        private bool closing = false;
        private int closingTickCount = 0;

        private bool showing = false;
        internal bool Showing
        {
            get { return showing; }
        }

        public frmLoadingBox()
        {
            backGroundBitmap = (Bitmap)Resources.ResourcesManager.GetResource("dialogWarningBackGround.bmp", Resources.ResourceType.Image);

            InitializeComponent();
            Size = new Size(460, 240);
            Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - Height) / 2);
        }

        private new DialogResult ShowDialog()
        {
            throw new InvalidOperationException();
        }

        public void StartClosing()
        {
            closing = true; 
        }

        public DialogResult ShowDialog(string title, string message, ShowedMessageDelegate msgDelegate)
        {
            lblTitle.TextLabel = title;
            lblMessage.TextLabel = message;

            closingTickCount = 0;
            closing = false;
            messageDelegate = msgDelegate;
            spinnerCntrl1.SpinOn = true;

            if (msgDelegate == null)
                throw new ArgumentNullException();

            tmrRefresh.Enabled = true;
            showing = true;
            base.ShowDialog();

            spinnerCntrl1.SpinOn = false;
            return this.DialogResult;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap doubleBuffer = new Bitmap(Width, Height);
            using (Graphics gr = Graphics.FromImage(doubleBuffer)) 
                gr.DrawImage(backGroundBitmap, 0, 0);

            e.Graphics.DrawImage(doubleBuffer, 0, 0);
        }

        private void refreshTick(object sender, EventArgs e)
        {
            lblMessage.TextLabel = message;

            if (!closing)
                message = messageDelegate();
            else
                if (closingTickCount > 30)
                {
                    tmrRefresh.Enabled = false;
                    showing = false;
                    Close();
                }
                else
                    closingTickCount++;
        }

        private void lblMessage_Click(object sender, EventArgs e)
        {

        }
    }
}