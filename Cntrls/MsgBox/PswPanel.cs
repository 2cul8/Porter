using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using Utility;

namespace Cntrls
{
    public partial class PswPanel : Form
    {
        private string _currentPswString = string.Empty;
        private string currentPswString
        {
            get { return _currentPswString; }
            set
            {
                _currentPswString = value; 

                string hidedPsw = string.Empty;
                for (int index = 0; index < _currentPswString.Length; index++)
                    hidedPsw += "*";

                if (!string.IsNullOrEmpty(hidedPsw))
                    lblPsw.Text = hidedPsw;
                else
                    lblPsw.Text = "- - -"; 
            }
        }

        public PswPanel()
        {
            InitializeComponent();

            InitGraphics();
            LoadText();
        }

        public new string ShowDialog()
        {
            Size = new Size(360, 166);
            Location = Utils.CenterScreen(Size);
            currentPswString = string.Empty;

            base.ShowDialog();
            return currentPswString;
        }

        private void InitGraphics()
        {
            lblTitle.LinePosition = eLinePosition.Down;
        }

        private void LoadText()
        {
            lblTitle.Text = Testi.GetText(Testi.eRisorsaTesto.BASE, "S0117");
            lblPsw.Text = "- - -";
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Pen BorderPen = new Pen(Color.Gainsboro, 2.0F);

            Rectangle rBorder = ClientRectangle;
            rBorder.Location = new Point(1, 1);
            rBorder.Width -= 3;
            rBorder.Height -= 3;

            Graphics gr = e.Graphics;

            gr.DrawRectangle(BorderPen, rBorder); 
            BorderPen = new Pen(Color.Gray, 1.0F);
            gr.DrawRectangle(BorderPen, rBorder);

            BorderPen.Dispose();
            base.OnPaint(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.NumPad0:
                case Keys.D0:
                    currentPswString += "0";
                    break;

                case Keys.NumPad1:
                case Keys.D1:
                    currentPswString += "1";
                    break;

                case Keys.NumPad2:
                case Keys.D2:
                    currentPswString += "2";
                    break;

                case Keys.NumPad3:
                case Keys.D3:
                    currentPswString += "3";
                    break;

                case Keys.NumPad4:
                case Keys.D4:
                    currentPswString += "4";
                    break;

                case Keys.NumPad5:
                case Keys.D5:
                    currentPswString += "5";
                    break;

                case Keys.NumPad6:
                case Keys.D6:
                    currentPswString += "6";
                    break;

                case Keys.NumPad7:
                case Keys.D7:
                    currentPswString += "7";
                    break;

                case Keys.NumPad8:
                case Keys.D8:
                    currentPswString += "8";
                    break;

                case Keys.NumPad9:
                case Keys.D9:
                    currentPswString += "9";
                    break;

                case Keys.Back: 
                    currentPswString = currentPswString.Remove(currentPswString.Length - 1, 1); 
                    break;

                case Keys.Enter:
                    Close();
                    break;

                case Keys.Escape:
                    currentPswString = string.Empty;
                    Close();
                    break;
            }

            base.OnKeyUp(e);
        }

        private void OkRequest(object sender, EventArgs e)
        {
            Close();
        }

        private void EscRequest(object sender, EventArgs e)
        {
            currentPswString = string.Empty;
            Close();
        }
    }
}