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
    public enum eModNumPad 
    {
        Normal = 0,
        Password = 1, 
        Numeric = 2,
        NumericPosi = 3,
        NumericInteger = 4,
        UnaCifra = 5
    }; 

    public partial class NumPad : Form
    {
        [Flags]
        public enum ButtonToEnableEnum : short 
        {
            Enable1 = 1,
            Enable2 = 2,
            Enable3 = 4,
            Enable4 = 8,
            Enable5 = 16,
            Enable6 = 32,
            Enable7 = 64,
            Enable8 = 128,
            Enable9 = 256,
            Enable0 = 512,
            EnablePoint = 1024,
            EnableNeg = 2048
        } 

        private string _Cifra = string.Empty;
        private eModNumPad Mod = eModNumPad.Normal;

        private string Cifra
        {
            get { return _Cifra; }
            set
            {
                if (Mod == eModNumPad.UnaCifra)
                {
                    if (_Cifra.Length >= 1)
                        return;

                    _Cifra = lblCifra.Text = value;
                    return;
                }

                if (Mod != eModNumPad.Password)
                {
                    if (Mod == eModNumPad.Numeric)
                    {
                        if (value == string.Empty)
                        {
                            lblCifra.Text = "0";
                            _Cifra = string.Empty;
                        }
                        else
                            _Cifra = lblCifra.Text = value;
                    }
                    else
                        _Cifra = lblCifra.Text = value;

                    if (string.IsNullOrEmpty(_Cifra))
                        if (isNeg)
                            isNeg = false;
                }
                else
                {
                    _Cifra = value;

                    lblCifra.Text = string.Empty;

                    for (int c = 0; c < _Cifra.Length; c++)
                    {
                        lblCifra.Text += "*";
                    }
                }
            }
        }

        public NumPad()
        {
            InitializeComponent();
            InitGraphics();
        }

        private void InitGraphics()
        {  
        }

        public NumPad(eModNumPad _Mod)
            : this()
        {
            Mod = _Mod;
            SetMode(); 
        }

        public NumPad(eModNumPad _Mod, string InitValue)
            : this(_Mod)
        {
            this.Cifra = InitValue;
        }

        private void CancRequest(object sender, EventArgs e)
        {
            if (Cifra.Length > 0)
            {
                if (Cifra.Length == 1)
                {
                    Cifra = string.Empty;
                    return;
                }
                Cifra = Cifra.Remove(Cifra.Length - 1, 1);
            }
        }

        private void ClickOnChar(object sender, EventArgs e)
        {
            Cifra += ((InputButton)sender).BtnText.ToString();
        }

        public new string ShowDialog()
        {
            Location = Utils.CenterScreen(Size);
            Size = new Size(290, 360);
             
            lblTitle.Text = (Mod == eModNumPad.Password ? "Password" : "Input Panel"); 

            base.ShowDialog();
            return _Cifra;
        }

        public string ShowDialog(string InitText)
        {
            this.Cifra = InitText;
            EnableAll();
            return this.ShowDialog();
        }

        public string ShowDialog(eModNumPad _Mod)
        {
            Mod = _Mod;
            SetMode();
            EnableAll();
            return this.ShowDialog();
        }

        public string ShowDialog(string InitText, eModNumPad _Mod)
        {
            Mod = _Mod;
            SetMode();
            return this.ShowDialog(InitText);
        } 

        public string ShowDialog(string InitText, eModNumPad _Mod, ButtonToEnableEnum bEnable)
        {
            Mod = _Mod;
            SetMode();
            SetEnabled(bEnable);
            return this.ShowDialog();
        }

        private void EnableAll()
        {
            inputButton1.Enabled = true;
            inputButton2.Enabled = true;
            inputButton3.Enabled = true;
            inputButton4.Enabled = true;
            inputButton5.Enabled = true;
            inputButton6.Enabled = true;
            inputButton7.Enabled = true;
            inputButton8.Enabled = true;
            inputButton9.Enabled = true;
            inputButton11.Enabled = true;

            iBtn10.Enabled = true;
            btnNeg.Enabled = true;

            Application.DoEvents();
        }

        private void SetEnabled(ButtonToEnableEnum bEnable)
        {
            inputButton9.Enabled = ((int)bEnable % 2) > 0;
            inputButton8.Enabled    = (((int)bEnable >> 1) % 2) > 0;
            inputButton7.Enabled    = (((int)bEnable >> 2) % 2) > 0;
            inputButton6.Enabled    = (((int)bEnable >> 3) % 2) > 0;
            inputButton5.Enabled    = (((int)bEnable >> 4) % 2) > 0;
            inputButton4.Enabled    = (((int)bEnable >> 5) % 2) > 0;
            inputButton3.Enabled    = (((int)bEnable >> 6) % 2) > 0;
            inputButton2.Enabled    = (((int)bEnable >> 7) % 2) > 0;
            inputButton1.Enabled    = (((int)bEnable >> 8) % 2) > 0;
            inputButton11.Enabled   = (((int)bEnable >> 9) % 2) > 0;

            iBtn10.Enabled          = (((int)bEnable >> 10) % 2) > 0;
            btnNeg.Enabled          = (((int)bEnable >> 11) % 2) > 0;
        }

        private void SetMode()
        {
            switch (Mod)
            {
                case eModNumPad.NumericPosi:
                    this.btnNeg.Visible = false;
                    this.iBtn10.Visible = false; 
                    Cifra = string.Empty;
                    break;

                case eModNumPad.Normal:
                    this.btnNeg.Visible = true;
                    this.iBtn10.Visible = true;
                    break;

                case eModNumPad.Numeric:
                    this.iBtn10.Visible = true; 
                    this.btnNeg.Visible = false;
                    Cifra = string.Empty;
                    break;

                case eModNumPad.Password:
                    this.iBtn10.Visible = false; 
                    this.btnNeg.Visible = false;
                    break;

                case eModNumPad.NumericInteger:
                    this.iBtn10.Visible = false;
                    this.btnNeg.Visible = true;
                    break;
            }
 
        } 

        private void ExitRequest(object sender, EventArgs e)
        {
            _Cifra = string.Empty;
            this.Close();
        }

        private void Enter(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NumPad_Load(object sender, EventArgs e)
        {
            lblCifra.Text = string.Empty;
            _Cifra = string.Empty;
        }

        private bool isNeg = false;

        private void SetNegative(object sender, EventArgs e)
        {
            if (!isNeg)
                Cifra = "-" + Cifra;
            else
            {
                string[] c = Cifra.Split("-".ToCharArray());

                if (c.Length > 1)
                    Cifra = c[1];
                else
                    Cifra = "0";
            }
            isNeg = !isNeg;
        }

        private void EscRequest(object sender, EventArgs e)
        {

        }
    }    
}