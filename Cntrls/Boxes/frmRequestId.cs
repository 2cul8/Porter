using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cntrls.Boxes
{
    public partial class frmRequestId : Form
    {
        private static Bitmap backGroundBitmap;

        public string Value
        {
            get { return lblValue.TextLabel; }
        }

        public frmRequestId()
        {
            if (backGroundBitmap == null)
                backGroundBitmap = (Bitmap)Resources.Resources.GetResource("backGround600x360.bmp", Resources.ResourceType.Image);

            InitializeComponent();

            Size = new Size(800, 600);
            Location = new Point(0, 0);
        }

        public DialogResult ShowDialog(string title)
        {
            lblTitle.TextLabel = title;
            lblValue.TextLabel = string.Empty; 

            return base.ShowDialog();
        }

        private void commitRequest(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
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
            try
            {
                SagoButton clickedButton = (SagoButton)sender;

                lblValue.TextLabel += clickedButton.TextLabel;
            }
            catch
            { }
        } 

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap doubleBuffer = new Bitmap(Width, Height);
            Graphics gr = Graphics.FromImage(doubleBuffer);

            gr.DrawImage(backGroundBitmap, (Width - backGroundBitmap.Width) / 2, 60);

            e.Graphics.DrawImage(doubleBuffer, 0, 0);
        }
    }
}