using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Utility; 

namespace Cntrls
{
    public partial class InputPanel : Form
    {
        private bool ShiftOn = false;

        private string _MyString = string.Empty;

        private string InputString
        {
            get { return _MyString; }
            set { _MyString = lblStringa.Text = value; }
        }

        public InputPanel()
        {
            InitializeComponent();
            InitGraphics();
        }

        public InputPanel(string ShowString)
            : this()
        {
            InputString = ShowString;
        }

        private void CloseRequest(object sender, EventArgs e)
        {
            InputString = string.Empty;
            this.Close();
        }

        private void ClickOnChar(object sender, EventArgs e)
        {
            InputString += ((InputButton)sender).BtnText;
        }

        private void CancelRequest(object sender, EventArgs e)
        {
            if (InputString.Length > 0)
                InputString = InputString.Remove(InputString.Length - 1, 1);
        }

        public new string ShowDialog()
        {
            this.Size = new Size(800, 480);
            this.Location = Utils.CenterScreen(this.Size);
            InputString = string.Empty; 

            base.ShowDialog();
            return _MyString;
        }

        private void InitGraphics()
        {
            lblStringa.LinePosition = eLinePosition.All;

            lblTitle.LinePosition = eLinePosition.Down;
            lblTitle.Text = "Input Panel";

            if (!ImageManager.ImagesLoaded)
                return;
              

            SetBtnText();
        }

        private void SetBtnText()
        {
            if (ShiftOn)
            {
                inputButton1.BtnText = "Q";
                inputButton2.BtnText = "W";
                inputButton4.BtnText = "E";
                inputButton3.BtnText = "R";
                inputButton8.BtnText = "T";
                inputButton7.BtnText = "Y";
                inputButton6.BtnText = "U";
                inputButton5.BtnText = "I";
                inputButton10.BtnText = "O";
                inputButton9.BtnText = "P";
                inputButton20.BtnText = "A";
                inputButton19.BtnText = "S";
                inputButton18.BtnText = "D";
                inputButton17.BtnText = "F";
                inputButton16.BtnText = "G";
                inputButton15.BtnText = "H";
                inputButton14.BtnText = "J";
                inputButton13.BtnText = "K";
                inputButton12.BtnText = "L";
                inputButton30.BtnText = "Z";
                inputButton29.BtnText = "X";
                inputButton28.BtnText = "C";
                inputButton27.BtnText = "V";
                inputButton26.BtnText = "B";
                inputButton25.BtnText = "N";
                inputButton24.BtnText = "M";
                inputButton23.BtnText = ";";
                inputButton22.BtnText = ":";
                inputButton21.BtnText = "_";


                inputButton41.BtnText = "!";
                inputButton40.BtnText = ((char)(0x22)).ToString();
                inputButton39.BtnText = "£";
                inputButton38.BtnText = "$";
                inputButton37.BtnText = "%";
                inputButton36.BtnText = "&";
                inputButton35.BtnText = "/";
                inputButton34.BtnText = "(";
                inputButton33.BtnText = ")";
                inputButton32.BtnText = "=";
            }
            else
            {
                inputButton1.BtnText = "q";
                inputButton2.BtnText = "w";
                inputButton4.BtnText = "e";
                inputButton3.BtnText = "r";
                inputButton8.BtnText = "t";
                inputButton7.BtnText = "y";
                inputButton6.BtnText = "u";
                inputButton5.BtnText = "i";
                inputButton10.BtnText = "o";
                inputButton9.BtnText = "p";
                inputButton20.BtnText = "a";
                inputButton19.BtnText = "s";
                inputButton18.BtnText = "d";
                inputButton17.BtnText = "f";
                inputButton16.BtnText = "g";
                inputButton15.BtnText = "h";
                inputButton14.BtnText = "j";
                inputButton13.BtnText = "k";
                inputButton12.BtnText = "l";
                inputButton30.BtnText = "z";
                inputButton29.BtnText = "x";
                inputButton28.BtnText = "c";
                inputButton27.BtnText = "v";
                inputButton26.BtnText = "b";
                inputButton25.BtnText = "n";
                inputButton24.BtnText = "m";
                inputButton23.BtnText = ",";
                inputButton22.BtnText = ".";
                inputButton21.BtnText = "-";


                inputButton41.BtnText = "1";
                inputButton40.BtnText = "2";
                inputButton39.BtnText = "3";
                inputButton38.BtnText = "4";
                inputButton37.BtnText = "5";
                inputButton36.BtnText = "6";
                inputButton35.BtnText = "7";
                inputButton34.BtnText = "8";
                inputButton33.BtnText = "9";
                inputButton32.BtnText = "0";
            }

            inputButton11.BtnText = "SHIFT"; 
        }

        private void DoneRequest(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShiftRequest(object sender, EventArgs e)
        {
            ShiftOn = !ShiftOn;

            SetBtnText();

            if (!ShiftOn)
            {
                inputButton11.BackColor = Color.FromArgb(48, 48, 48);
                inputButton11.ForeColor = Color.Gray;
                inputButton11.DownTextColor = Color.Gainsboro;
            }
            else
            {
                inputButton11.BackColor = Color.Gainsboro;
                inputButton11.ForeColor = Color.Gray;
                inputButton11.DownTextColor = Color.FromArgb(48, 48, 48);
            }
        }

        private void ExitRequest(object sender, EventArgs e)
        {

        }
    }
}