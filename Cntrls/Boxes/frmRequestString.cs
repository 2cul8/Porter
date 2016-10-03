using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cntrls.Boxes
{
    public partial class frmRequestString : Form
    {
        private static Bitmap backGroundBitmap;

        public string Value
        {
            get { return lblValue.TextLabel; }
        }

        public frmRequestString()
        {
            if (backGroundBitmap == null)
                backGroundBitmap = (Bitmap)Resources.Resources.GetResource("backGround600x360.bmp", Resources.ResourceType.Image);

            InitializeComponent();

            Size = new Size(600, 360);
            Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - Height) / 2);
        }

        public DialogResult ShowDialog(string title, bool returnPossible)
        {
            lblTitle.TextLabel = title;
            lblValue.TextLabel = string.Empty;

            btnReturn.Enabled = returnPossible;

            return base.ShowDialog();
        }

        private void commitRequest(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void returnRequest(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void cancLastDigitPressed(object sender, EventArgs e)
        { 
            string valueLabel = lblValue.TextLabel;

            if (string.IsNullOrEmpty(valueLabel)) return;

            lblValue.TextLabel = valueLabel = valueLabel.Remove(valueLabel.Length - 1, 1);
        }

        private void keyBoardButtonClick(object sender, EventArgs e)
        {
            SagoButton clickedButton = (SagoButton)sender;

            lblValue.TextLabel += clickedButton.TextLabel;
        } 

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap doubleBuffer = new Bitmap(Width, Height);
            Graphics gr = Graphics.FromImage(doubleBuffer);

            gr.DrawImage(backGroundBitmap, 0, 0);

            e.Graphics.DrawImage(doubleBuffer, 0, 0);
        }
    }
}