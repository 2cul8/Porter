namespace Cntrls
{
    partial class NumPad
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Liberare le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReturn = new Cntrls.InputButton();
            this.lblTitle = new Cntrls.GraphicLabelCntrl();
            this.btnNeg = new Cntrls.InputButton();
            this.lblCifra = new Cntrls.GraphicLabelCntrl();
            this.iBtn10 = new Cntrls.InputButton();
            this.btnOk = new Cntrls.ImgButton();
            this.inputButton11 = new Cntrls.InputButton();
            this.btnDel = new Cntrls.ImgButton();
            this.inputButton7 = new Cntrls.InputButton();
            this.inputButton1 = new Cntrls.InputButton();
            this.inputButton8 = new Cntrls.InputButton();
            this.inputButton2 = new Cntrls.InputButton();
            this.inputButton9 = new Cntrls.InputButton();
            this.inputButton3 = new Cntrls.InputButton();
            this.inputButton4 = new Cntrls.InputButton();
            this.inputButton6 = new Cntrls.InputButton();
            this.inputButton5 = new Cntrls.InputButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel1.Controls.Add(this.btnReturn);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.btnNeg);
            this.panel1.Controls.Add(this.lblCifra);
            this.panel1.Controls.Add(this.iBtn10);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.inputButton11);
            this.panel1.Controls.Add(this.btnDel);
            this.panel1.Controls.Add(this.inputButton7);
            this.panel1.Controls.Add(this.inputButton1);
            this.panel1.Controls.Add(this.inputButton8);
            this.panel1.Controls.Add(this.inputButton2);
            this.panel1.Controls.Add(this.inputButton9);
            this.panel1.Controls.Add(this.inputButton3);
            this.panel1.Controls.Add(this.inputButton4);
            this.panel1.Controls.Add(this.inputButton6);
            this.panel1.Controls.Add(this.inputButton5);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(284, 354);
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnReturn.BackColorOnMouseDown = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.btnReturn.BorderColor = System.Drawing.Color.Red;
            this.btnReturn.BorderSize = 2;
            this.btnReturn.BtnColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnReturn.BtnFont = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular);
            this.btnReturn.BtnForeColor = System.Drawing.Color.DarkRed;
            this.btnReturn.BtnText = "ESC";
            this.btnReturn.DownTextColor = System.Drawing.Color.Red;
            this.btnReturn.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnReturn.InternalBorderColor = System.Drawing.Color.Salmon;
            this.btnReturn.LampColor = System.Drawing.Color.Empty;
            this.btnReturn.Location = new System.Drawing.Point(204, 87);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(77, 81);
            this.btnReturn.TabIndex = 78;
            this.btnReturn.TestoInRilievo = true;
            this.btnReturn.Click += new System.EventHandler(this.ExitRequest);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Black;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular);
            this.lblTitle.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblTitle.LineColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(284, 38);
            this.lblTitle.TabIndex = 19;
            // 
            // btnNeg
            // 
            this.btnNeg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnNeg.BackColorOnMouseDown = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.btnNeg.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnNeg.BorderSize = 2;
            this.btnNeg.BtnColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnNeg.BtnFont = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Regular);
            this.btnNeg.BtnForeColor = System.Drawing.Color.Gray;
            this.btnNeg.BtnText = "-";
            this.btnNeg.DownTextColor = System.Drawing.Color.Gainsboro;
            this.btnNeg.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.btnNeg.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnNeg.InternalBorderColor = System.Drawing.Color.Gray;
            this.btnNeg.Location = new System.Drawing.Point(3, 288);
            this.btnNeg.Name = "btnNeg";
            this.btnNeg.Size = new System.Drawing.Size(63, 63);
            this.btnNeg.TabIndex = 2;
            this.btnNeg.TabStop = false;
            this.btnNeg.TestoInRilievo = true;
            this.btnNeg.Click += new System.EventHandler(this.SetNegative);
            // 
            // lblCifra
            // 
            this.lblCifra.BackColor = System.Drawing.Color.Gainsboro;
            this.lblCifra.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular);
            this.lblCifra.ForeColor = System.Drawing.Color.Black;
            this.lblCifra.LineColor = System.Drawing.Color.Maroon;
            this.lblCifra.Location = new System.Drawing.Point(3, 41);
            this.lblCifra.Name = "lblCifra";
            this.lblCifra.Size = new System.Drawing.Size(278, 43);
            this.lblCifra.TabIndex = 3;
            // 
            // iBtn10
            // 
            this.iBtn10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.iBtn10.BackColorOnMouseDown = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.iBtn10.BorderColor = System.Drawing.Color.Gainsboro;
            this.iBtn10.BorderSize = 2;
            this.iBtn10.BtnColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.iBtn10.BtnFont = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Regular);
            this.iBtn10.BtnForeColor = System.Drawing.Color.Gray;
            this.iBtn10.BtnText = ".";
            this.iBtn10.DownTextColor = System.Drawing.Color.Gainsboro;
            this.iBtn10.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Bold);
            this.iBtn10.ForeColor = System.Drawing.Color.Gainsboro;
            this.iBtn10.InternalBorderColor = System.Drawing.Color.Gray;
            this.iBtn10.Location = new System.Drawing.Point(137, 288);
            this.iBtn10.Name = "iBtn10";
            this.iBtn10.Size = new System.Drawing.Size(63, 63);
            this.iBtn10.TabIndex = 4;
            this.iBtn10.TabStop = false;
            this.iBtn10.TestoInRilievo = true;
            this.iBtn10.Click += new System.EventHandler(this.ClickOnChar);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnOk.BackColorOnMouseDown = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.btnOk.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnOk.BorderSize = 2;
            this.btnOk.BtnColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnOk.InternalBorderColor = System.Drawing.Color.Gray;
            this.btnOk.Location = new System.Drawing.Point(204, 275);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(77, 76);
            this.btnOk.TabIndex = 5;
            this.btnOk.TabStop = false;
            this.btnOk.Click += new System.EventHandler(this.Enter);
            // 
            // inputButton11
            // 
            this.inputButton11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.inputButton11.BackColorOnMouseDown = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.inputButton11.BorderColor = System.Drawing.Color.Gainsboro;
            this.inputButton11.BorderSize = 2;
            this.inputButton11.BtnColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.inputButton11.BtnFont = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Regular);
            this.inputButton11.BtnForeColor = System.Drawing.Color.Gray;
            this.inputButton11.BtnText = "0";
            this.inputButton11.DownTextColor = System.Drawing.Color.Gainsboro;
            this.inputButton11.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Bold);
            this.inputButton11.ForeColor = System.Drawing.Color.Gainsboro;
            this.inputButton11.InternalBorderColor = System.Drawing.Color.Gray;
            this.inputButton11.Location = new System.Drawing.Point(70, 288);
            this.inputButton11.Name = "inputButton11";
            this.inputButton11.Size = new System.Drawing.Size(63, 63);
            this.inputButton11.TabIndex = 6;
            this.inputButton11.TabStop = false;
            this.inputButton11.TestoInRilievo = true;
            this.inputButton11.Click += new System.EventHandler(this.ClickOnChar);
            // 
            // btnDel
            // 
            this.btnDel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnDel.BackColorOnMouseDown = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.btnDel.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnDel.BorderSize = 2;
            this.btnDel.BtnColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnDel.InternalBorderColor = System.Drawing.Color.Gray;
            this.btnDel.Location = new System.Drawing.Point(204, 174);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(77, 75);
            this.btnDel.TabIndex = 9;
            this.btnDel.TabStop = false;
            this.btnDel.Click += new System.EventHandler(this.CancRequest);
            // 
            // inputButton7
            // 
            this.inputButton7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.inputButton7.BackColorOnMouseDown = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.inputButton7.BorderColor = System.Drawing.Color.Gainsboro;
            this.inputButton7.BorderSize = 2;
            this.inputButton7.BtnColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.inputButton7.BtnFont = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Regular);
            this.inputButton7.BtnForeColor = System.Drawing.Color.Gray;
            this.inputButton7.BtnText = "3";
            this.inputButton7.DownTextColor = System.Drawing.Color.Gainsboro;
            this.inputButton7.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Bold);
            this.inputButton7.ForeColor = System.Drawing.Color.Gainsboro;
            this.inputButton7.InternalBorderColor = System.Drawing.Color.Gray;
            this.inputButton7.Location = new System.Drawing.Point(137, 221);
            this.inputButton7.Name = "inputButton7";
            this.inputButton7.Size = new System.Drawing.Size(63, 63);
            this.inputButton7.TabIndex = 10;
            this.inputButton7.TabStop = false;
            this.inputButton7.TestoInRilievo = true;
            this.inputButton7.Click += new System.EventHandler(this.ClickOnChar);
            // 
            // inputButton1
            // 
            this.inputButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.inputButton1.BackColorOnMouseDown = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.inputButton1.BorderColor = System.Drawing.Color.Gainsboro;
            this.inputButton1.BorderSize = 2;
            this.inputButton1.BtnColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.inputButton1.BtnFont = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Regular);
            this.inputButton1.BtnForeColor = System.Drawing.Color.Gray;
            this.inputButton1.BtnText = "7";
            this.inputButton1.DownTextColor = System.Drawing.Color.Gainsboro;
            this.inputButton1.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Bold);
            this.inputButton1.ForeColor = System.Drawing.Color.Gainsboro;
            this.inputButton1.InternalBorderColor = System.Drawing.Color.Gray;
            this.inputButton1.Location = new System.Drawing.Point(3, 87);
            this.inputButton1.Name = "inputButton1";
            this.inputButton1.Size = new System.Drawing.Size(63, 63);
            this.inputButton1.TabIndex = 11;
            this.inputButton1.TabStop = false;
            this.inputButton1.TestoInRilievo = true;
            this.inputButton1.Click += new System.EventHandler(this.ClickOnChar);
            // 
            // inputButton8
            // 
            this.inputButton8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.inputButton8.BackColorOnMouseDown = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.inputButton8.BorderColor = System.Drawing.Color.Gainsboro;
            this.inputButton8.BorderSize = 2;
            this.inputButton8.BtnColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.inputButton8.BtnFont = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Regular);
            this.inputButton8.BtnForeColor = System.Drawing.Color.Gray;
            this.inputButton8.BtnText = "2";
            this.inputButton8.DownTextColor = System.Drawing.Color.Gainsboro;
            this.inputButton8.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Bold);
            this.inputButton8.ForeColor = System.Drawing.Color.Gainsboro;
            this.inputButton8.InternalBorderColor = System.Drawing.Color.Gray;
            this.inputButton8.Location = new System.Drawing.Point(70, 221);
            this.inputButton8.Name = "inputButton8";
            this.inputButton8.Size = new System.Drawing.Size(63, 63);
            this.inputButton8.TabIndex = 12;
            this.inputButton8.TabStop = false;
            this.inputButton8.TestoInRilievo = true;
            this.inputButton8.Click += new System.EventHandler(this.ClickOnChar);
            // 
            // inputButton2
            // 
            this.inputButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.inputButton2.BackColorOnMouseDown = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.inputButton2.BorderColor = System.Drawing.Color.Gainsboro;
            this.inputButton2.BorderSize = 2;
            this.inputButton2.BtnColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.inputButton2.BtnFont = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Regular);
            this.inputButton2.BtnForeColor = System.Drawing.Color.Gray;
            this.inputButton2.BtnText = "8";
            this.inputButton2.DownTextColor = System.Drawing.Color.Gainsboro;
            this.inputButton2.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Bold);
            this.inputButton2.ForeColor = System.Drawing.Color.Gainsboro;
            this.inputButton2.InternalBorderColor = System.Drawing.Color.Gray;
            this.inputButton2.Location = new System.Drawing.Point(70, 87);
            this.inputButton2.Name = "inputButton2";
            this.inputButton2.Size = new System.Drawing.Size(63, 63);
            this.inputButton2.TabIndex = 13;
            this.inputButton2.TabStop = false;
            this.inputButton2.TestoInRilievo = true;
            this.inputButton2.Click += new System.EventHandler(this.ClickOnChar);
            // 
            // inputButton9
            // 
            this.inputButton9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.inputButton9.BackColorOnMouseDown = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.inputButton9.BorderColor = System.Drawing.Color.Gainsboro;
            this.inputButton9.BorderSize = 2;
            this.inputButton9.BtnColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.inputButton9.BtnFont = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Regular);
            this.inputButton9.BtnForeColor = System.Drawing.Color.Gray;
            this.inputButton9.BtnText = "1";
            this.inputButton9.DownTextColor = System.Drawing.Color.Gainsboro;
            this.inputButton9.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Bold);
            this.inputButton9.ForeColor = System.Drawing.Color.Gainsboro;
            this.inputButton9.InternalBorderColor = System.Drawing.Color.Gray;
            this.inputButton9.Location = new System.Drawing.Point(3, 221);
            this.inputButton9.Name = "inputButton9";
            this.inputButton9.Size = new System.Drawing.Size(63, 63);
            this.inputButton9.TabIndex = 14;
            this.inputButton9.TabStop = false;
            this.inputButton9.TestoInRilievo = true;
            this.inputButton9.Click += new System.EventHandler(this.ClickOnChar);
            // 
            // inputButton3
            // 
            this.inputButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.inputButton3.BackColorOnMouseDown = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.inputButton3.BorderColor = System.Drawing.Color.Gainsboro;
            this.inputButton3.BorderSize = 2;
            this.inputButton3.BtnColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.inputButton3.BtnFont = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Regular);
            this.inputButton3.BtnForeColor = System.Drawing.Color.Gray;
            this.inputButton3.BtnText = "9";
            this.inputButton3.DownTextColor = System.Drawing.Color.Gainsboro;
            this.inputButton3.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Bold);
            this.inputButton3.ForeColor = System.Drawing.Color.Gainsboro;
            this.inputButton3.InternalBorderColor = System.Drawing.Color.Gray;
            this.inputButton3.Location = new System.Drawing.Point(137, 87);
            this.inputButton3.Name = "inputButton3";
            this.inputButton3.Size = new System.Drawing.Size(63, 63);
            this.inputButton3.TabIndex = 15;
            this.inputButton3.TabStop = false;
            this.inputButton3.TestoInRilievo = true;
            this.inputButton3.Click += new System.EventHandler(this.ClickOnChar);
            // 
            // inputButton4
            // 
            this.inputButton4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.inputButton4.BackColorOnMouseDown = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.inputButton4.BorderColor = System.Drawing.Color.Gainsboro;
            this.inputButton4.BorderSize = 2;
            this.inputButton4.BtnColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.inputButton4.BtnFont = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Regular);
            this.inputButton4.BtnForeColor = System.Drawing.Color.Gray;
            this.inputButton4.BtnText = "6";
            this.inputButton4.DownTextColor = System.Drawing.Color.Gainsboro;
            this.inputButton4.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Bold);
            this.inputButton4.ForeColor = System.Drawing.Color.Gainsboro;
            this.inputButton4.InternalBorderColor = System.Drawing.Color.Gray;
            this.inputButton4.Location = new System.Drawing.Point(137, 154);
            this.inputButton4.Name = "inputButton4";
            this.inputButton4.Size = new System.Drawing.Size(63, 63);
            this.inputButton4.TabIndex = 16;
            this.inputButton4.TabStop = false;
            this.inputButton4.TestoInRilievo = true;
            this.inputButton4.Click += new System.EventHandler(this.ClickOnChar);
            // 
            // inputButton6
            // 
            this.inputButton6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.inputButton6.BackColorOnMouseDown = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.inputButton6.BorderColor = System.Drawing.Color.Gainsboro;
            this.inputButton6.BorderSize = 2;
            this.inputButton6.BtnColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.inputButton6.BtnFont = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Regular);
            this.inputButton6.BtnForeColor = System.Drawing.Color.Gray;
            this.inputButton6.BtnText = "4";
            this.inputButton6.DownTextColor = System.Drawing.Color.Gainsboro;
            this.inputButton6.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Bold);
            this.inputButton6.ForeColor = System.Drawing.Color.Gainsboro;
            this.inputButton6.InternalBorderColor = System.Drawing.Color.Gray;
            this.inputButton6.Location = new System.Drawing.Point(3, 154);
            this.inputButton6.Name = "inputButton6";
            this.inputButton6.Size = new System.Drawing.Size(63, 63);
            this.inputButton6.TabIndex = 17;
            this.inputButton6.TabStop = false;
            this.inputButton6.TestoInRilievo = true;
            this.inputButton6.Click += new System.EventHandler(this.ClickOnChar);
            // 
            // inputButton5
            // 
            this.inputButton5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.inputButton5.BackColorOnMouseDown = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.inputButton5.BorderColor = System.Drawing.Color.Gainsboro;
            this.inputButton5.BorderSize = 2;
            this.inputButton5.BtnColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.inputButton5.BtnFont = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Regular);
            this.inputButton5.BtnForeColor = System.Drawing.Color.Gray;
            this.inputButton5.BtnText = "5";
            this.inputButton5.DownTextColor = System.Drawing.Color.Gainsboro;
            this.inputButton5.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Bold);
            this.inputButton5.ForeColor = System.Drawing.Color.Gainsboro;
            this.inputButton5.InternalBorderColor = System.Drawing.Color.Gray;
            this.inputButton5.Location = new System.Drawing.Point(70, 154);
            this.inputButton5.Name = "inputButton5";
            this.inputButton5.Size = new System.Drawing.Size(63, 63);
            this.inputButton5.TabIndex = 18;
            this.inputButton5.TabStop = false;
            this.inputButton5.TestoInRilievo = true;
            this.inputButton5.Click += new System.EventHandler(this.ClickOnChar);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Location = new System.Drawing.Point(2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(286, 356);
            // 
            // NumPad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(290, 360);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NumPad";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.NumPad_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GraphicLabelCntrl lblCifra;
        private ImgButton btnOk;
        private ImgButton btnDel;
        private InputButton inputButton1;
        private InputButton inputButton2;
        private InputButton inputButton3;
        private InputButton inputButton4;
        private InputButton inputButton5;
        private InputButton inputButton6;
        private InputButton inputButton7;
        private InputButton inputButton8;
        private InputButton inputButton9;
        private InputButton iBtn10;
        private InputButton inputButton11;
        private InputButton btnNeg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private GraphicLabelCntrl lblTitle;
        private InputButton btnReturn;
    }
}