using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cntrls.Boxes
{
    public partial class frmProgressDialog : Form
    {
        public delegate int PercentageValueDelegate();

        private Bitmap backGroundBitmap;
        private PercentageValueDelegate percentageWorker;

        private int percentage = 0;
        private bool closing = false;
        private int closingTickCount = 0;

        public frmProgressDialog()
        { 
            backGroundBitmap = (Bitmap)Resources.Resources.GetResource("dialogWarningBackGround.bmp", Resources.ResourceType.Image);

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
            percentage = 100;
        }

        public DialogResult ShowDialog(string title, PercentageValueDelegate percentageWork)
        {
            lblTitle.TextLabel = title; 
            percentage = 0; 
            closingTickCount = 0;
            closing = false;
            percentageWorker = percentageWork;
            spinnerCntrl1.SpinOn = true;

            if (percentageWorker == null)
                throw new ArgumentNullException();

            tmrRefresh.Enabled = true;
            base.ShowDialog();

            spinnerCntrl1.SpinOn = false;
            return this.DialogResult;
        }

        private void refreshTick(object sender, EventArgs e)
        {
            lblPercentage.TextLabel = percentage.ToString() + " %";

            if (!closing)
                percentage = percentageWorker(); 
            else
                if (closingTickCount > 30)
                {
                    tmrRefresh.Enabled = false;
                    Close();
                }
                else
                    closingTickCount++;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap doubleBuffer = new Bitmap(Width, Height);

            using (Graphics gr = Graphics.FromImage(doubleBuffer))
                gr.DrawImage(backGroundBitmap, 0, 0);

            e.Graphics.DrawImage(doubleBuffer, 0, 0); 
        } 
    }
}