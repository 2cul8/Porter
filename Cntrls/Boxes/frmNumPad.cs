using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cntrls.Boxes
{
    public partial class frmNumPad : Form
    {
        private static Bitmap backGroundBitmap;

        private bool firstDigit = false;
        
        public string NumPadValue
        {
            get { return passwordDigit ? passwordString : lblValue.TextLabel; }
            set { lblValue.TextLabel = value; }
        }

        private bool passwordDigit = false;
        private string passwordString = string.Empty;

        public frmNumPad()
        {
            if (backGroundBitmap == null)
                backGroundBitmap = (Bitmap)Resources.ResourcesManager.GetResource("dialogNumPadBackGround.bmp", Resources.ResourceType.Image);

            InitializeComponent();
            Size = new Size(233, 373); 
            Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - Height) / 2);
        }

        public DialogResult ShowDialog(string title, string value)
        {
            lblTitle.TextLabel = title;
            lblValue.TextLabel = value;
            firstDigit = true;
            passwordDigit = false;

            return base.ShowDialog();
        }

        public new DialogResult ShowDialog()
        {
            passwordDigit = true;
            firstDigit = false;
            passwordString = string.Empty;

            lblValue.TextLabel = string.Empty;
            lblTitle.TextLabel = "Password";

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

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap doubleBuffer = new Bitmap(Width, Height);
            Graphics gr = Graphics.FromImage(doubleBuffer);

            gr.DrawImage(backGroundBitmap, 0, 0);

            e.Graphics.DrawImage(doubleBuffer, 0, 0);
        }

        private void numPad1Clicked(object sender, EventArgs e)
        {
            if (firstDigit) { lblValue.TextLabel = string.Empty; firstDigit = false; }
            if (!passwordDigit) lblValue.TextLabel += "1";
            else
            {
                passwordString += "1";
                lblValue.TextLabel += "*";
            }
        }

        private void numPad2Clicked(object sender, EventArgs e)
        {
            if (firstDigit) { lblValue.TextLabel = string.Empty; firstDigit = false; }
            if (!passwordDigit) lblValue.TextLabel += "2";
            else
            {
                passwordString += "2";
                lblValue.TextLabel += "*";
            }
        }

        private void numPad3Clicked(object sender, EventArgs e)
        {
            if (firstDigit) { lblValue.TextLabel = string.Empty; firstDigit = false; }
            if (!passwordDigit) lblValue.TextLabel += "3";
            else
            {
                passwordString += "3";
                lblValue.TextLabel += "*";
            }
        }

        private void numPad4Clicked(object sender, EventArgs e)
        {
            if (firstDigit) { lblValue.TextLabel = string.Empty; firstDigit = false; }
            if (!passwordDigit) lblValue.TextLabel += "4";
            else
            {
                passwordString += "4";
                lblValue.TextLabel += "*";
            }
        }

        private void numPad5Clicked(object sender, EventArgs e)
        {
            if (firstDigit) { lblValue.TextLabel = string.Empty; firstDigit = false; }
            if (!passwordDigit) lblValue.TextLabel += "5";
            else
            {
                passwordString += "5";
                lblValue.TextLabel += "*";
            }
        }

        private void numPad6Clicked(object sender, EventArgs e)
        {
            if (firstDigit) { lblValue.TextLabel = string.Empty; firstDigit = false; }
            if (!passwordDigit) lblValue.TextLabel += "6";
            else
            {
                passwordString += "6";
                lblValue.TextLabel += "*";
            }
        }

        private void numPad7Clicked(object sender, EventArgs e)
        {
            if (firstDigit) { lblValue.TextLabel = string.Empty; firstDigit = false; }
            if (!passwordDigit) lblValue.TextLabel += "7";
            else
            {
                passwordString += "7";
                lblValue.TextLabel += "*";
            }
        }

        private void numPad8Clicked(object sender, EventArgs e)
        {
            if (firstDigit) { lblValue.TextLabel = string.Empty; firstDigit = false; }
            if (!passwordDigit) lblValue.TextLabel += "8";
            else
            {
                passwordString += "8";
                lblValue.TextLabel += "*";
            }
        }

        private void numPad9Clicked(object sender, EventArgs e)
        {
            if (firstDigit) { lblValue.TextLabel = string.Empty; firstDigit = false; }
            if (!passwordDigit) lblValue.TextLabel += "9";
            else
            {
                passwordString += "9";
                lblValue.TextLabel += "*";
            }
        }

        private void numPad0Clicked(object sender, EventArgs e)
        {
            if (firstDigit) { lblValue.TextLabel = string.Empty; firstDigit = false; }
            if (!passwordDigit) lblValue.TextLabel += "0";
            else
            {
                passwordString += "0";
                lblValue.TextLabel += "*";
            }
        } 

        private void cancLastDigitPressed(object sender, EventArgs e)
        {
            if (!passwordDigit)
            {
                string valueLabel = lblValue.TextLabel;

                if (string.IsNullOrEmpty(valueLabel)) return;

                lblValue.TextLabel = valueLabel = valueLabel.Remove(valueLabel.Length - 1, 1);
            }
            else
            {
                string valueLabel = passwordString;
                string showedLabel = lblValue.TextLabel;

                if (string.IsNullOrEmpty(passwordString)) return;

                lblValue.TextLabel = showedLabel.Remove(showedLabel.Length - 1, 1);
                passwordString = valueLabel.Remove(valueLabel.Length - 1, 1);
            }
        }
    }
}