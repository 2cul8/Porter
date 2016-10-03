namespace SagoPorter.Controlli
{
    partial class ControlloSettaggi
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

        #region Codice generato da Progettazione componenti

        /// <summary> 
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare 
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnEsp = new Cntrls.SagoButton();
            this.btnEng = new Cntrls.SagoButton();
            this.btnIta = new Cntrls.SagoButton();
            this.btnExitAll = new Cntrls.SagoButton();
            this.btnMinimize = new Cntrls.SagoButton();
            this.btnPrevStats = new Cntrls.SagoButton();
            this.btnNextStats = new Cntrls.SagoButton();
            this.lblTitle = new Cntrls.GraphicLabelCntrl();
            this.pnlLanguage = new System.Windows.Forms.Panel();
            this.pnlControls = new System.Windows.Forms.Panel();
            this.pnlLanguage.SuspendLayout();
            this.pnlControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEsp
            // 
            this.btnEsp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(21)))), ((int)(((byte)(5)))));
            this.btnEsp.BlinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(252)))), ((int)(((byte)(117)))));
            this.btnEsp.BlinkEnabled = false;
            this.btnEsp.BlinkInterval = 1000;
            this.btnEsp.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(172)))), ((int)(((byte)(37)))));
            this.btnEsp.BorderWidth = 4F;
            this.btnEsp.ButtonColor = System.Drawing.Color.White;
            this.btnEsp.ButtonEnabled = true;
            this.btnEsp.Font = new System.Drawing.Font("Roboto", 22F, System.Drawing.FontStyle.Regular);
            this.btnEsp.ForeColor = System.Drawing.Color.Black;
            this.btnEsp.FromResource = true;
            this.btnEsp.HeadTextLabel = "";
            this.btnEsp.Location = new System.Drawing.Point(190, 217);
            this.btnEsp.Name = "btnEsp";
            this.btnEsp.ResourceNameBase = "buttton242x88NoRound";
            this.btnEsp.RoundSize = 16;
            this.btnEsp.Selected = false;
            this.btnEsp.Size = new System.Drawing.Size(242, 88);
            this.btnEsp.TabIndex = 7;
            this.btnEsp.TextLabel = "ControlloSettaggi.btnEsp.Text";
            this.btnEsp.TextMarginLeft = -6;
            this.btnEsp.Click += new System.EventHandler(this.setSpanishLanguageRequested);
            // 
            // btnEng
            // 
            this.btnEng.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(21)))), ((int)(((byte)(5)))));
            this.btnEng.BlinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(252)))), ((int)(((byte)(117)))));
            this.btnEng.BlinkEnabled = false;
            this.btnEng.BlinkInterval = 1000;
            this.btnEng.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(172)))), ((int)(((byte)(37)))));
            this.btnEng.BorderWidth = 4F;
            this.btnEng.ButtonColor = System.Drawing.Color.White;
            this.btnEng.ButtonEnabled = true;
            this.btnEng.Font = new System.Drawing.Font("Roboto", 22F, System.Drawing.FontStyle.Regular);
            this.btnEng.ForeColor = System.Drawing.Color.Black;
            this.btnEng.FromResource = true;
            this.btnEng.HeadTextLabel = "";
            this.btnEng.Location = new System.Drawing.Point(337, 116);
            this.btnEng.Name = "btnEng";
            this.btnEng.ResourceNameBase = "buttton242x88NoRound";
            this.btnEng.RoundSize = 16;
            this.btnEng.Selected = false;
            this.btnEng.Size = new System.Drawing.Size(242, 88);
            this.btnEng.TabIndex = 6;
            this.btnEng.TextLabel = "ControlloSettaggi.btnEng.Text";
            this.btnEng.TextMarginLeft = -6;
            this.btnEng.Click += new System.EventHandler(this.setEnglishLanguageRequested);
            // 
            // btnIta
            // 
            this.btnIta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(21)))), ((int)(((byte)(5)))));
            this.btnIta.BlinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(252)))), ((int)(((byte)(117)))));
            this.btnIta.BlinkEnabled = false;
            this.btnIta.BlinkInterval = 1000;
            this.btnIta.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(172)))), ((int)(((byte)(37)))));
            this.btnIta.BorderWidth = 4F;
            this.btnIta.ButtonColor = System.Drawing.Color.White;
            this.btnIta.ButtonEnabled = true;
            this.btnIta.Font = new System.Drawing.Font("Roboto", 22F, System.Drawing.FontStyle.Regular);
            this.btnIta.ForeColor = System.Drawing.Color.Black;
            this.btnIta.FromResource = true;
            this.btnIta.HeadTextLabel = "";
            this.btnIta.Location = new System.Drawing.Point(72, 116);
            this.btnIta.Name = "btnIta";
            this.btnIta.ResourceNameBase = "buttton242x88NoRound";
            this.btnIta.RoundSize = 16;
            this.btnIta.Selected = false;
            this.btnIta.Size = new System.Drawing.Size(242, 88);
            this.btnIta.TabIndex = 5;
            this.btnIta.TextLabel = "ControlloSettaggi.btnIta.Text";
            this.btnIta.TextMarginLeft = -6;
            this.btnIta.Click += new System.EventHandler(this.setItalianLanguageRequested);
            // 
            // btnExitAll
            // 
            this.btnExitAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(21)))), ((int)(((byte)(5)))));
            this.btnExitAll.BlinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(252)))), ((int)(((byte)(117)))));
            this.btnExitAll.BlinkEnabled = false;
            this.btnExitAll.BlinkInterval = 1000;
            this.btnExitAll.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(172)))), ((int)(((byte)(37)))));
            this.btnExitAll.BorderWidth = 4F;
            this.btnExitAll.ButtonColor = System.Drawing.Color.White;
            this.btnExitAll.ButtonEnabled = true;
            this.btnExitAll.Font = new System.Drawing.Font("Roboto", 22F, System.Drawing.FontStyle.Regular);
            this.btnExitAll.ForeColor = System.Drawing.Color.Black;
            this.btnExitAll.FromResource = true;
            this.btnExitAll.HeadTextLabel = "";
            this.btnExitAll.Location = new System.Drawing.Point(204, 213);
            this.btnExitAll.Name = "btnExitAll";
            this.btnExitAll.ResourceNameBase = "buttton242x88NoRound";
            this.btnExitAll.RoundSize = 16;
            this.btnExitAll.Selected = false;
            this.btnExitAll.Size = new System.Drawing.Size(242, 88);
            this.btnExitAll.TabIndex = 4;
            this.btnExitAll.TextLabel = "ControlloSettaggi.btnExitAll.Text";
            this.btnExitAll.TextMarginLeft = -6;
            this.btnExitAll.Click += new System.EventHandler(this.closeAllRequested);
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(21)))), ((int)(((byte)(5)))));
            this.btnMinimize.BlinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(252)))), ((int)(((byte)(117)))));
            this.btnMinimize.BlinkEnabled = false;
            this.btnMinimize.BlinkInterval = 1000;
            this.btnMinimize.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(172)))), ((int)(((byte)(37)))));
            this.btnMinimize.BorderWidth = 4F;
            this.btnMinimize.ButtonColor = System.Drawing.Color.White;
            this.btnMinimize.ButtonEnabled = true;
            this.btnMinimize.Font = new System.Drawing.Font("Roboto", 22F, System.Drawing.FontStyle.Regular);
            this.btnMinimize.ForeColor = System.Drawing.Color.Black;
            this.btnMinimize.FromResource = true;
            this.btnMinimize.HeadTextLabel = "";
            this.btnMinimize.Location = new System.Drawing.Point(204, 119);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.ResourceNameBase = "buttton242x88NoRound";
            this.btnMinimize.RoundSize = 16;
            this.btnMinimize.Selected = false;
            this.btnMinimize.Size = new System.Drawing.Size(242, 88);
            this.btnMinimize.TabIndex = 3;
            this.btnMinimize.TextLabel = "ControlloSettaggi.btnMinimize.Text";
            this.btnMinimize.TextMarginLeft = -6;
            this.btnMinimize.Click += new System.EventHandler(this.minimizeRequested);
            // 
            // btnPrevStats
            // 
            this.btnPrevStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(21)))), ((int)(((byte)(5)))));
            this.btnPrevStats.BlinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(252)))), ((int)(((byte)(117)))));
            this.btnPrevStats.BlinkEnabled = false;
            this.btnPrevStats.BlinkInterval = 1000;
            this.btnPrevStats.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(172)))), ((int)(((byte)(37)))));
            this.btnPrevStats.BorderWidth = 4F;
            this.btnPrevStats.ButtonColor = System.Drawing.Color.White;
            this.btnPrevStats.ButtonEnabled = true;
            this.btnPrevStats.Font = new System.Drawing.Font("Roboto", 22F, System.Drawing.FontStyle.Regular);
            this.btnPrevStats.ForeColor = System.Drawing.Color.Black;
            this.btnPrevStats.FromResource = true;
            this.btnPrevStats.HeadTextLabel = "";
            this.btnPrevStats.Location = new System.Drawing.Point(3, 3);
            this.btnPrevStats.Name = "btnPrevStats";
            this.btnPrevStats.ResourceNameBase = "buttton68x51_left";
            this.btnPrevStats.RoundSize = 16;
            this.btnPrevStats.Selected = false;
            this.btnPrevStats.Size = new System.Drawing.Size(68, 51);
            this.btnPrevStats.TabIndex = 12;
            this.btnPrevStats.TextLabel = "";
            this.btnPrevStats.TextMarginLeft = 0;
            this.btnPrevStats.Click += new System.EventHandler(this.showPrevPageRequested);
            // 
            // btnNextStats
            // 
            this.btnNextStats.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextStats.AutoScroll = true;
            this.btnNextStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(21)))), ((int)(((byte)(5)))));
            this.btnNextStats.BlinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(252)))), ((int)(((byte)(117)))));
            this.btnNextStats.BlinkEnabled = false;
            this.btnNextStats.BlinkInterval = 1000;
            this.btnNextStats.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(172)))), ((int)(((byte)(37)))));
            this.btnNextStats.BorderWidth = 4F;
            this.btnNextStats.ButtonColor = System.Drawing.Color.White;
            this.btnNextStats.ButtonEnabled = true;
            this.btnNextStats.Font = new System.Drawing.Font("Roboto", 22F, System.Drawing.FontStyle.Regular);
            this.btnNextStats.ForeColor = System.Drawing.Color.Black;
            this.btnNextStats.FromResource = true;
            this.btnNextStats.HeadTextLabel = "";
            this.btnNextStats.Location = new System.Drawing.Point(585, 3);
            this.btnNextStats.Name = "btnNextStats";
            this.btnNextStats.ResourceNameBase = "buttton68x51_right";
            this.btnNextStats.RoundSize = 16;
            this.btnNextStats.Selected = false;
            this.btnNextStats.Size = new System.Drawing.Size(68, 51);
            this.btnNextStats.TabIndex = 11;
            this.btnNextStats.TextLabel = "";
            this.btnNextStats.TextMarginLeft = 0;
            this.btnNextStats.Click += new System.EventHandler(this.showNextPageRequested);
            // 
            // lblTitle
            // 
            this.lblTitle.AllineamentoOrizzontale = System.Drawing.StringAlignment.Center;
            this.lblTitle.AllineamentoVerticale = System.Drawing.StringAlignment.Center;
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.lblTitle.BackGroundresourceName = "";
            this.lblTitle.BorderBottom = false;
            this.lblTitle.BorderLeft = false;
            this.lblTitle.BorderRight = false;
            this.lblTitle.BorderTop = false;
            this.lblTitle.BottomLineResourceName = "line492x1.bmp";
            this.lblTitle.ButtonEnabled = true;
            this.lblTitle.EnableDebug = false;
            this.lblTitle.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(234)))));
            this.lblTitle.LineColor = System.Drawing.Color.Empty;
            this.lblTitle.Location = new System.Drawing.Point(77, 3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Selected = false;
            this.lblTitle.Size = new System.Drawing.Size(502, 51);
            this.lblTitle.TabIndex = 13;
            this.lblTitle.TextLabel = "ControlloSettaggi.lblTitle.Text.1";
            // 
            // pnlLanguage
            // 
            this.pnlLanguage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.pnlLanguage.Controls.Add(this.btnIta);
            this.pnlLanguage.Controls.Add(this.btnEng);
            this.pnlLanguage.Controls.Add(this.btnEsp);
            this.pnlLanguage.Location = new System.Drawing.Point(3, 57);
            this.pnlLanguage.Name = "pnlLanguage";
            this.pnlLanguage.Size = new System.Drawing.Size(650, 420);
            // 
            // pnlControls
            // 
            this.pnlControls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.pnlControls.Controls.Add(this.btnMinimize);
            this.pnlControls.Controls.Add(this.btnExitAll);
            this.pnlControls.Location = new System.Drawing.Point(3, 57);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(650, 420);
            this.pnlControls.Visible = false;
            // 
            // ControlloSettaggi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnPrevStats);
            this.Controls.Add(this.btnNextStats);
            this.Controls.Add(this.pnlLanguage);
            this.Controls.Add(this.pnlControls);
            this.Name = "ControlloSettaggi";
            this.Size = new System.Drawing.Size(656, 480);
            this.pnlLanguage.ResumeLayout(false);
            this.pnlControls.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Cntrls.SagoButton btnMinimize;
        private Cntrls.SagoButton btnExitAll;
        private Cntrls.SagoButton btnIta;
        private Cntrls.SagoButton btnEng;
        private Cntrls.SagoButton btnEsp;
        private Cntrls.SagoButton btnPrevStats;
        private Cntrls.SagoButton btnNextStats;
        private Cntrls.GraphicLabelCntrl lblTitle;
        private System.Windows.Forms.Panel pnlLanguage;
        private System.Windows.Forms.Panel pnlControls;
    }
}
