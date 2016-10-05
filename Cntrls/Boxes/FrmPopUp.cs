using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cntrls.Boxes
{
    public partial class FrmPopUp : Form
    {
        private Bitmap backGroundBitmap;
        string message = string.Empty;
        private bool closing = false;
        private int closingTickCount = 0;
        private int closingTime = 0;

        private bool showing = false;
        internal bool Showing
        {
            get { return showing; }
        }

        private string popUpMessage = string.Empty;
        internal string PopUpMessage
        {
            get { return popUpMessage; }
            set 
            {
                lblMessage.TextLabel = popUpMessage = value;
                closingTickCount = 0;
                BringToFront();
            }
        }

        public FrmPopUp()
        {
            backGroundBitmap = (Bitmap)Resources.ResourcesManager.GetResource("dialogWarningBackGround.bmp", Resources.ResourceType.Image);

            InitializeComponent();
            Size = new Size(460, 240);
            Location = new Point(800, (Screen.PrimaryScreen.WorkingArea.Height - Height) / 2);

            base.Show();
        }

        private new DialogResult ShowDialog()
        {
            throw new InvalidOperationException();
        }

        public void StartClosing()
        {
            closing = true;
        }  

        public void Show(string title, string msg, int time)
        {
            lblTitle.TextLabel = title;
            lblMessage.TextLabel = popUpMessage = msg;

            closingTime = time / 100;
            closingTickCount = 0; 

            tmrRefresh.Enabled = true;
            Show(); 
        }

        private new void Show()
        {
            Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - Height) / 2);
            BringToFront();
            showing = true;
        }

        private new void Hide()
        {
            Location = new Point(800, (Screen.PrimaryScreen.WorkingArea.Height - Height) / 2);
            SendToBack();
            showing = false;
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
            if (closingTickCount > closingTime)
            {
                tmrRefresh.Enabled = false;
                showing = false;
                Hide();
            }
            else
                closingTickCount++;
        } 
    }
}