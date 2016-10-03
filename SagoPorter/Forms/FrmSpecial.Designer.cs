namespace SagoPorter
{
    partial class FrmSpecial
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
            this.controlloInformazioni = new SagoPorter.Controlli.ControlloInformazioni();
            this.btnShowSettaggi = new Cntrls.SagoButton();
            this.btnShowTaratura = new Cntrls.SagoButton();
            this.btnEsci = new Cntrls.SagoButton();
            this.btnShowInfo = new Cntrls.SagoButton();
            this.btnShowInputOutput = new Cntrls.SagoButton();
            this.btnShowParametri = new Cntrls.SagoButton();
            this.controlloTaratura = new SagoPorter.Controlli.ControlloTaratura();
            this.controlloParametri = new SagoPorter.Controlli.ControlloParametri();
            this.btnLogin = new Cntrls.SagoButton();
            this.btnLogout = new Cntrls.SagoButton();
            this.controlloSettaggi = new SagoPorter.Controlli.ControlloSettaggi();
            this.SuspendLayout();
            // 
            // controlloInformazioni
            // 
            this.controlloInformazioni.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.controlloInformazioni.Location = new System.Drawing.Point(136, 0);
            this.controlloInformazioni.Name = "controlloInformazioni";
            this.controlloInformazioni.Size = new System.Drawing.Size(664, 480);
            this.controlloInformazioni.TabIndex = 18;
            // 
            // btnShowSettaggi
            // 
            this.btnShowSettaggi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(21)))), ((int)(((byte)(5)))));
            this.btnShowSettaggi.BlinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(252)))), ((int)(((byte)(117)))));
            this.btnShowSettaggi.BlinkEnabled = false;
            this.btnShowSettaggi.BlinkInterval = 1000;
            this.btnShowSettaggi.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(252)))), ((int)(((byte)(117)))));
            this.btnShowSettaggi.BorderWidth = 4F;
            this.btnShowSettaggi.ButtonColor = System.Drawing.Color.White;
            this.btnShowSettaggi.ButtonEnabled = true;
            this.btnShowSettaggi.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular);
            this.btnShowSettaggi.ForeColor = System.Drawing.Color.Black;
            this.btnShowSettaggi.FromResource = true;
            this.btnShowSettaggi.HeadTextLabel = "";
            this.btnShowSettaggi.Location = new System.Drawing.Point(-40, 144);
            this.btnShowSettaggi.Name = "btnShowSettaggi";
            this.btnShowSettaggi.ResourceNameBase = "buttton140x60";
            this.btnShowSettaggi.RoundSize = 8;
            this.btnShowSettaggi.Selected = false;
            this.btnShowSettaggi.Size = new System.Drawing.Size(140, 60);
            this.btnShowSettaggi.TabIndex = 16;
            this.btnShowSettaggi.TextLabel = "FrmSpecial.btnShowSettaggi.Text";
            this.btnShowSettaggi.TextMarginLeft = 16;
            this.btnShowSettaggi.Click += new System.EventHandler(this.showSettaggiRequested);
            // 
            // btnShowTaratura
            // 
            this.btnShowTaratura.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(21)))), ((int)(((byte)(5)))));
            this.btnShowTaratura.BlinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(252)))), ((int)(((byte)(117)))));
            this.btnShowTaratura.BlinkEnabled = false;
            this.btnShowTaratura.BlinkInterval = 1000;
            this.btnShowTaratura.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(252)))), ((int)(((byte)(117)))));
            this.btnShowTaratura.BorderWidth = 4F;
            this.btnShowTaratura.ButtonColor = System.Drawing.Color.White;
            this.btnShowTaratura.ButtonEnabled = true;
            this.btnShowTaratura.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular);
            this.btnShowTaratura.ForeColor = System.Drawing.Color.Black;
            this.btnShowTaratura.FromResource = true;
            this.btnShowTaratura.HeadTextLabel = "";
            this.btnShowTaratura.Location = new System.Drawing.Point(-40, 210);
            this.btnShowTaratura.Name = "btnShowTaratura";
            this.btnShowTaratura.ResourceNameBase = "buttton140x60";
            this.btnShowTaratura.RoundSize = 8;
            this.btnShowTaratura.Selected = false;
            this.btnShowTaratura.Size = new System.Drawing.Size(140, 60);
            this.btnShowTaratura.TabIndex = 15;
            this.btnShowTaratura.TextLabel = "FrmSpecial.btnShowTaratura.Text";
            this.btnShowTaratura.TextMarginLeft = 16;
            this.btnShowTaratura.Visible = false;
            this.btnShowTaratura.Click += new System.EventHandler(this.showTaraturaRequested);
            // 
            // btnEsci
            // 
            this.btnEsci.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(21)))), ((int)(((byte)(5)))));
            this.btnEsci.BlinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(252)))), ((int)(((byte)(117)))));
            this.btnEsci.BlinkEnabled = false;
            this.btnEsci.BlinkInterval = 1000;
            this.btnEsci.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(252)))), ((int)(((byte)(117)))));
            this.btnEsci.BorderWidth = 4F;
            this.btnEsci.ButtonColor = System.Drawing.Color.White;
            this.btnEsci.ButtonEnabled = true;
            this.btnEsci.Font = new System.Drawing.Font("Decker", 18F, System.Drawing.FontStyle.Regular);
            this.btnEsci.ForeColor = System.Drawing.Color.Black;
            this.btnEsci.FromResource = true;
            this.btnEsci.HeadTextLabel = "";
            this.btnEsci.Location = new System.Drawing.Point(3, 3);
            this.btnEsci.Name = "btnEsci";
            this.btnEsci.ResourceNameBase = "buttton140x70_esc";
            this.btnEsci.RoundSize = 8;
            this.btnEsci.Selected = false;
            this.btnEsci.Size = new System.Drawing.Size(68, 60);
            this.btnEsci.TabIndex = 14;
            this.btnEsci.TextLabel = "";
            this.btnEsci.TextMarginLeft = -4;
            this.btnEsci.Click += new System.EventHandler(this.onExitRequested);
            // 
            // btnShowInfo
            // 
            this.btnShowInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(21)))), ((int)(((byte)(5)))));
            this.btnShowInfo.BlinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(252)))), ((int)(((byte)(117)))));
            this.btnShowInfo.BlinkEnabled = false;
            this.btnShowInfo.BlinkInterval = 1000;
            this.btnShowInfo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(252)))), ((int)(((byte)(117)))));
            this.btnShowInfo.BorderWidth = 4F;
            this.btnShowInfo.ButtonColor = System.Drawing.Color.White;
            this.btnShowInfo.ButtonEnabled = true;
            this.btnShowInfo.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular);
            this.btnShowInfo.ForeColor = System.Drawing.Color.Black;
            this.btnShowInfo.FromResource = true;
            this.btnShowInfo.HeadTextLabel = "";
            this.btnShowInfo.Location = new System.Drawing.Point(-10, 78);
            this.btnShowInfo.Name = "btnShowInfo";
            this.btnShowInfo.ResourceNameBase = "buttton140x60";
            this.btnShowInfo.RoundSize = 8;
            this.btnShowInfo.Selected = false;
            this.btnShowInfo.Size = new System.Drawing.Size(140, 60);
            this.btnShowInfo.TabIndex = 12;
            this.btnShowInfo.TextLabel = "FrmSpecial.btnShowInfo.Text";
            this.btnShowInfo.TextMarginLeft = 0;
            this.btnShowInfo.Click += new System.EventHandler(this.showInfoRequested);
            // 
            // btnShowInputOutput
            // 
            this.btnShowInputOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(21)))), ((int)(((byte)(5)))));
            this.btnShowInputOutput.BlinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(252)))), ((int)(((byte)(117)))));
            this.btnShowInputOutput.BlinkEnabled = false;
            this.btnShowInputOutput.BlinkInterval = 1000;
            this.btnShowInputOutput.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(252)))), ((int)(((byte)(117)))));
            this.btnShowInputOutput.BorderWidth = 4F;
            this.btnShowInputOutput.ButtonColor = System.Drawing.Color.White;
            this.btnShowInputOutput.ButtonEnabled = true;
            this.btnShowInputOutput.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular);
            this.btnShowInputOutput.ForeColor = System.Drawing.Color.Black;
            this.btnShowInputOutput.FromResource = true;
            this.btnShowInputOutput.HeadTextLabel = "";
            this.btnShowInputOutput.Location = new System.Drawing.Point(-40, 342);
            this.btnShowInputOutput.Name = "btnShowInputOutput";
            this.btnShowInputOutput.ResourceNameBase = "buttton140x60";
            this.btnShowInputOutput.RoundSize = 8;
            this.btnShowInputOutput.Selected = false;
            this.btnShowInputOutput.Size = new System.Drawing.Size(140, 60);
            this.btnShowInputOutput.TabIndex = 11;
            this.btnShowInputOutput.TextLabel = "FrmSpecial.btnShowInputOutput.Text";
            this.btnShowInputOutput.TextMarginLeft = 16;
            this.btnShowInputOutput.Visible = false;
            this.btnShowInputOutput.Click += new System.EventHandler(this.showInputOutputRequested);
            // 
            // btnShowParametri
            // 
            this.btnShowParametri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(21)))), ((int)(((byte)(5)))));
            this.btnShowParametri.BlinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(252)))), ((int)(((byte)(117)))));
            this.btnShowParametri.BlinkEnabled = false;
            this.btnShowParametri.BlinkInterval = 1000;
            this.btnShowParametri.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(252)))), ((int)(((byte)(117)))));
            this.btnShowParametri.BorderWidth = 4F;
            this.btnShowParametri.ButtonColor = System.Drawing.Color.White;
            this.btnShowParametri.ButtonEnabled = true;
            this.btnShowParametri.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular);
            this.btnShowParametri.ForeColor = System.Drawing.Color.Black;
            this.btnShowParametri.FromResource = true;
            this.btnShowParametri.HeadTextLabel = "";
            this.btnShowParametri.Location = new System.Drawing.Point(-40, 276);
            this.btnShowParametri.Name = "btnShowParametri";
            this.btnShowParametri.ResourceNameBase = "buttton140x60";
            this.btnShowParametri.RoundSize = 8;
            this.btnShowParametri.Selected = false;
            this.btnShowParametri.Size = new System.Drawing.Size(140, 60);
            this.btnShowParametri.TabIndex = 10;
            this.btnShowParametri.TextLabel = "FrmSpecial.btnShowParametri.Text";
            this.btnShowParametri.TextMarginLeft = 16;
            this.btnShowParametri.Visible = false;
            this.btnShowParametri.Click += new System.EventHandler(this.showParametriRequested);
            // 
            // controlloTaratura
            // 
            this.controlloTaratura.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.controlloTaratura.Location = new System.Drawing.Point(136, 0);
            this.controlloTaratura.Name = "controlloTaratura";
            this.controlloTaratura.Size = new System.Drawing.Size(664, 480);
            this.controlloTaratura.TabIndex = 17;
            // 
            // controlloParametri
            // 
            this.controlloParametri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.controlloParametri.ForeColor = System.Drawing.Color.White;
            this.controlloParametri.Location = new System.Drawing.Point(136, 0);
            this.controlloParametri.Name = "controlloParametri";
            this.controlloParametri.Size = new System.Drawing.Size(664, 480);
            this.controlloParametri.TabIndex = 13;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(21)))), ((int)(((byte)(5)))));
            this.btnLogin.BlinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(252)))), ((int)(((byte)(117)))));
            this.btnLogin.BlinkEnabled = false;
            this.btnLogin.BlinkInterval = 1000;
            this.btnLogin.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(252)))), ((int)(((byte)(117)))));
            this.btnLogin.BorderWidth = 4F;
            this.btnLogin.ButtonColor = System.Drawing.Color.White;
            this.btnLogin.ButtonEnabled = true;
            this.btnLogin.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular);
            this.btnLogin.ForeColor = System.Drawing.Color.Black;
            this.btnLogin.FromResource = true;
            this.btnLogin.HeadTextLabel = "";
            this.btnLogin.Location = new System.Drawing.Point(3, 417);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.ResourceNameBase = "buttton_unlock";
            this.btnLogin.RoundSize = 8;
            this.btnLogin.Selected = false;
            this.btnLogin.Size = new System.Drawing.Size(68, 60);
            this.btnLogin.TabIndex = 19;
            this.btnLogin.TextLabel = "";
            this.btnLogin.TextMarginLeft = 16;
            this.btnLogin.Click += new System.EventHandler(this.loginRequested);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(21)))), ((int)(((byte)(5)))));
            this.btnLogout.BlinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(252)))), ((int)(((byte)(117)))));
            this.btnLogout.BlinkEnabled = false;
            this.btnLogout.BlinkInterval = 1000;
            this.btnLogout.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(252)))), ((int)(((byte)(117)))));
            this.btnLogout.BorderWidth = 4F;
            this.btnLogout.ButtonColor = System.Drawing.Color.White;
            this.btnLogout.ButtonEnabled = true;
            this.btnLogout.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular);
            this.btnLogout.ForeColor = System.Drawing.Color.Black;
            this.btnLogout.FromResource = true;
            this.btnLogout.HeadTextLabel = "";
            this.btnLogout.Location = new System.Drawing.Point(3, 417);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.ResourceNameBase = "buttton_lock";
            this.btnLogout.RoundSize = 8;
            this.btnLogout.Selected = false;
            this.btnLogout.Size = new System.Drawing.Size(68, 60);
            this.btnLogout.TabIndex = 20;
            this.btnLogout.TextLabel = "";
            this.btnLogout.TextMarginLeft = 16;
            this.btnLogout.Visible = false;
            this.btnLogout.Click += new System.EventHandler(this.loginRequested);
            // 
            // controlloSettaggi
            // 
            this.controlloSettaggi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.controlloSettaggi.Location = new System.Drawing.Point(136, 0);
            this.controlloSettaggi.Name = "controlloSettaggi";
            this.controlloSettaggi.Size = new System.Drawing.Size(664, 480);
            this.controlloSettaggi.TabIndex = 21;
            // 
            // FrmSpecial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(41)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.ControlBox = false;
            this.Controls.Add(this.controlloSettaggi);
            this.Controls.Add(this.controlloInformazioni);
            this.Controls.Add(this.btnShowSettaggi);
            this.Controls.Add(this.btnShowTaratura);
            this.Controls.Add(this.btnEsci);
            this.Controls.Add(this.btnShowInfo);
            this.Controls.Add(this.btnShowInputOutput);
            this.Controls.Add(this.btnShowParametri);
            this.Controls.Add(this.controlloTaratura);
            this.Controls.Add(this.controlloParametri);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnLogout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSpecial";
            this.Text = "FrmSpecial";
            this.ResumeLayout(false);

        }

        #endregion

        private Cntrls.SagoButton btnShowParametri;
        private Cntrls.SagoButton btnShowInputOutput;
        private Cntrls.SagoButton btnShowInfo;
        private SagoPorter.Controlli.ControlloParametri controlloParametri;
        private Cntrls.SagoButton btnEsci;
        private Cntrls.SagoButton btnShowTaratura;
        private Cntrls.SagoButton btnShowSettaggi;
        private SagoPorter.Controlli.ControlloTaratura controlloTaratura;
        private SagoPorter.Controlli.ControlloInformazioni controlloInformazioni;
        private Cntrls.SagoButton btnLogin;
        private Cntrls.SagoButton btnLogout;
        private SagoPorter.Controlli.ControlloSettaggi controlloSettaggi; 
    }
}