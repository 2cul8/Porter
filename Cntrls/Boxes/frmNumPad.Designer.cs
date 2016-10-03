namespace Cntrls.Boxes
{
    partial class frmNumPad
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
            this.sagoButton4 = new Cntrls.SagoButton();
            this.sagoButton3 = new Cntrls.SagoButton();
            this.sagoButton2 = new Cntrls.SagoButton();
            this.sagoButton1 = new Cntrls.SagoButton();
            this.btnNumPad2 = new Cntrls.SagoButton();
            this.btnNumPad0 = new Cntrls.SagoButton();
            this.btnNumPad3 = new Cntrls.SagoButton();
            this.btnNumPad1 = new Cntrls.SagoButton();
            this.btnNumPad6 = new Cntrls.SagoButton();
            this.btnNumPad5 = new Cntrls.SagoButton();
            this.btnNumPad4 = new Cntrls.SagoButton();
            this.btnNumPad9 = new Cntrls.SagoButton();
            this.btnNumPad8 = new Cntrls.SagoButton();
            this.btnNumPad7 = new Cntrls.SagoButton();
            this.lblTitle = new Cntrls.GraphicLabelCntrl();
            this.lblValue = new Cntrls.GraphicLabelCntrl();
            this.SuspendLayout();
            // 
            // sagoButton4
            // 
            this.sagoButton4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.sagoButton4.BlinkColor = System.Drawing.Color.Transparent;
            this.sagoButton4.BlinkEnabled = false;
            this.sagoButton4.BlinkInterval = 200;
            this.sagoButton4.BorderColor = System.Drawing.Color.Transparent;
            this.sagoButton4.BorderWidth = 1F;
            this.sagoButton4.ButtonColor = System.Drawing.Color.Transparent;
            this.sagoButton4.ButtonEnabled = true;
            this.sagoButton4.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular);
            this.sagoButton4.FromResource = false;
            this.sagoButton4.HeadTextLabel = "";
            this.sagoButton4.Location = new System.Drawing.Point(152, 312);
            this.sagoButton4.Name = "sagoButton4";
            this.sagoButton4.ResourceNameBase = "buttton126x47_redo";
            this.sagoButton4.RoundSize = 0;
            this.sagoButton4.Selected = false;
            this.sagoButton4.Size = new System.Drawing.Size(60, 47);
            this.sagoButton4.TabIndex = 46;
            this.sagoButton4.TextLabel = "";
            this.sagoButton4.TextMarginLeft = 0;
            this.sagoButton4.Click += new System.EventHandler(this.returnRequest);
            // 
            // sagoButton3
            // 
            this.sagoButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.sagoButton3.BlinkColor = System.Drawing.Color.Transparent;
            this.sagoButton3.BlinkEnabled = false;
            this.sagoButton3.BlinkInterval = 200;
            this.sagoButton3.BorderColor = System.Drawing.Color.Transparent;
            this.sagoButton3.BorderWidth = 1F;
            this.sagoButton3.ButtonColor = System.Drawing.Color.Transparent;
            this.sagoButton3.ButtonEnabled = true;
            this.sagoButton3.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular);
            this.sagoButton3.FromResource = false;
            this.sagoButton3.HeadTextLabel = "";
            this.sagoButton3.Location = new System.Drawing.Point(20, 312);
            this.sagoButton3.Name = "sagoButton3";
            this.sagoButton3.ResourceNameBase = "buttton60x47_ok";
            this.sagoButton3.RoundSize = 0;
            this.sagoButton3.Selected = false;
            this.sagoButton3.Size = new System.Drawing.Size(126, 47);
            this.sagoButton3.TabIndex = 45;
            this.sagoButton3.TextLabel = "";
            this.sagoButton3.TextMarginLeft = 0;
            this.sagoButton3.Click += new System.EventHandler(this.commitRequest);
            // 
            // sagoButton2
            // 
            this.sagoButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.sagoButton2.BlinkColor = System.Drawing.Color.Transparent;
            this.sagoButton2.BlinkEnabled = false;
            this.sagoButton2.BlinkInterval = 200;
            this.sagoButton2.BorderColor = System.Drawing.Color.Transparent;
            this.sagoButton2.BorderWidth = 1F;
            this.sagoButton2.ButtonColor = System.Drawing.Color.Transparent;
            this.sagoButton2.ButtonEnabled = true;
            this.sagoButton2.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular);
            this.sagoButton2.FromResource = false;
            this.sagoButton2.HeadTextLabel = "";
            this.sagoButton2.Location = new System.Drawing.Point(20, 259);
            this.sagoButton2.Name = "sagoButton2";
            this.sagoButton2.ResourceNameBase = "buttton60x47_canc";
            this.sagoButton2.RoundSize = 0;
            this.sagoButton2.Selected = false;
            this.sagoButton2.Size = new System.Drawing.Size(60, 47);
            this.sagoButton2.TabIndex = 44;
            this.sagoButton2.TextLabel = "";
            this.sagoButton2.TextMarginLeft = 0;
            this.sagoButton2.Click += new System.EventHandler(this.cancLastDigitPressed);
            // 
            // sagoButton1
            // 
            this.sagoButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.sagoButton1.BlinkColor = System.Drawing.Color.Transparent;
            this.sagoButton1.BlinkEnabled = false;
            this.sagoButton1.BlinkInterval = 200;
            this.sagoButton1.BorderColor = System.Drawing.Color.Transparent;
            this.sagoButton1.BorderWidth = 1F;
            this.sagoButton1.ButtonColor = System.Drawing.Color.Transparent;
            this.sagoButton1.ButtonEnabled = true;
            this.sagoButton1.Font = new System.Drawing.Font("Roboto", 22F, System.Drawing.FontStyle.Regular);
            this.sagoButton1.FromResource = false;
            this.sagoButton1.HeadTextLabel = "";
            this.sagoButton1.Location = new System.Drawing.Point(152, 259);
            this.sagoButton1.Name = "sagoButton1";
            this.sagoButton1.ResourceNameBase = "buttton60x47";
            this.sagoButton1.RoundSize = 0;
            this.sagoButton1.Selected = false;
            this.sagoButton1.Size = new System.Drawing.Size(60, 47);
            this.sagoButton1.TabIndex = 43;
            this.sagoButton1.TextLabel = ".";
            this.sagoButton1.TextMarginLeft = 0;
            this.sagoButton1.Visible = false;
            // 
            // btnNumPad2
            // 
            this.btnNumPad2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnNumPad2.BlinkColor = System.Drawing.Color.Transparent;
            this.btnNumPad2.BlinkEnabled = false;
            this.btnNumPad2.BlinkInterval = 200;
            this.btnNumPad2.BorderColor = System.Drawing.Color.Transparent;
            this.btnNumPad2.BorderWidth = 1F;
            this.btnNumPad2.ButtonColor = System.Drawing.Color.Transparent;
            this.btnNumPad2.ButtonEnabled = true;
            this.btnNumPad2.Font = new System.Drawing.Font("Roboto", 22F, System.Drawing.FontStyle.Regular);
            this.btnNumPad2.FromResource = false;
            this.btnNumPad2.HeadTextLabel = "";
            this.btnNumPad2.Location = new System.Drawing.Point(86, 206);
            this.btnNumPad2.Name = "btnNumPad2";
            this.btnNumPad2.ResourceNameBase = "buttton60x47";
            this.btnNumPad2.RoundSize = 0;
            this.btnNumPad2.Selected = false;
            this.btnNumPad2.Size = new System.Drawing.Size(60, 47);
            this.btnNumPad2.TabIndex = 42;
            this.btnNumPad2.TextLabel = "2";
            this.btnNumPad2.TextMarginLeft = 0;
            this.btnNumPad2.Click += new System.EventHandler(this.numPad2Clicked);
            // 
            // btnNumPad0
            // 
            this.btnNumPad0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnNumPad0.BlinkColor = System.Drawing.Color.Transparent;
            this.btnNumPad0.BlinkEnabled = false;
            this.btnNumPad0.BlinkInterval = 200;
            this.btnNumPad0.BorderColor = System.Drawing.Color.Transparent;
            this.btnNumPad0.BorderWidth = 1F;
            this.btnNumPad0.ButtonColor = System.Drawing.Color.Transparent;
            this.btnNumPad0.ButtonEnabled = true;
            this.btnNumPad0.Font = new System.Drawing.Font("Roboto", 22F, System.Drawing.FontStyle.Regular);
            this.btnNumPad0.FromResource = false;
            this.btnNumPad0.HeadTextLabel = "";
            this.btnNumPad0.Location = new System.Drawing.Point(86, 259);
            this.btnNumPad0.Name = "btnNumPad0";
            this.btnNumPad0.ResourceNameBase = "buttton60x47";
            this.btnNumPad0.RoundSize = 0;
            this.btnNumPad0.Selected = false;
            this.btnNumPad0.Size = new System.Drawing.Size(60, 47);
            this.btnNumPad0.TabIndex = 41;
            this.btnNumPad0.TextLabel = "0";
            this.btnNumPad0.TextMarginLeft = 0;
            this.btnNumPad0.Click += new System.EventHandler(this.numPad0Clicked);
            // 
            // btnNumPad3
            // 
            this.btnNumPad3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnNumPad3.BlinkColor = System.Drawing.Color.Transparent;
            this.btnNumPad3.BlinkEnabled = false;
            this.btnNumPad3.BlinkInterval = 200;
            this.btnNumPad3.BorderColor = System.Drawing.Color.Transparent;
            this.btnNumPad3.BorderWidth = 1F;
            this.btnNumPad3.ButtonColor = System.Drawing.Color.Transparent;
            this.btnNumPad3.ButtonEnabled = true;
            this.btnNumPad3.Font = new System.Drawing.Font("Roboto", 22F, System.Drawing.FontStyle.Regular);
            this.btnNumPad3.FromResource = false;
            this.btnNumPad3.HeadTextLabel = "";
            this.btnNumPad3.Location = new System.Drawing.Point(152, 206);
            this.btnNumPad3.Name = "btnNumPad3";
            this.btnNumPad3.ResourceNameBase = "buttton60x47";
            this.btnNumPad3.RoundSize = 0;
            this.btnNumPad3.Selected = false;
            this.btnNumPad3.Size = new System.Drawing.Size(60, 47);
            this.btnNumPad3.TabIndex = 40;
            this.btnNumPad3.TextLabel = "3";
            this.btnNumPad3.TextMarginLeft = 0;
            this.btnNumPad3.Click += new System.EventHandler(this.numPad3Clicked);
            // 
            // btnNumPad1
            // 
            this.btnNumPad1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnNumPad1.BlinkColor = System.Drawing.Color.Transparent;
            this.btnNumPad1.BlinkEnabled = false;
            this.btnNumPad1.BlinkInterval = 200;
            this.btnNumPad1.BorderColor = System.Drawing.Color.Transparent;
            this.btnNumPad1.BorderWidth = 1F;
            this.btnNumPad1.ButtonColor = System.Drawing.Color.Transparent;
            this.btnNumPad1.ButtonEnabled = true;
            this.btnNumPad1.Font = new System.Drawing.Font("Roboto", 22F, System.Drawing.FontStyle.Regular);
            this.btnNumPad1.FromResource = false;
            this.btnNumPad1.HeadTextLabel = "";
            this.btnNumPad1.Location = new System.Drawing.Point(20, 206);
            this.btnNumPad1.Name = "btnNumPad1";
            this.btnNumPad1.ResourceNameBase = "buttton60x47";
            this.btnNumPad1.RoundSize = 0;
            this.btnNumPad1.Selected = false;
            this.btnNumPad1.Size = new System.Drawing.Size(60, 47);
            this.btnNumPad1.TabIndex = 39;
            this.btnNumPad1.TextLabel = "1";
            this.btnNumPad1.TextMarginLeft = 0;
            this.btnNumPad1.Click += new System.EventHandler(this.numPad1Clicked);
            // 
            // btnNumPad6
            // 
            this.btnNumPad6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnNumPad6.BlinkColor = System.Drawing.Color.Transparent;
            this.btnNumPad6.BlinkEnabled = false;
            this.btnNumPad6.BlinkInterval = 200;
            this.btnNumPad6.BorderColor = System.Drawing.Color.Transparent;
            this.btnNumPad6.BorderWidth = 1F;
            this.btnNumPad6.ButtonColor = System.Drawing.Color.Transparent;
            this.btnNumPad6.ButtonEnabled = true;
            this.btnNumPad6.Font = new System.Drawing.Font("Roboto", 22F, System.Drawing.FontStyle.Regular);
            this.btnNumPad6.FromResource = false;
            this.btnNumPad6.HeadTextLabel = "";
            this.btnNumPad6.Location = new System.Drawing.Point(152, 153);
            this.btnNumPad6.Name = "btnNumPad6";
            this.btnNumPad6.ResourceNameBase = "buttton60x47";
            this.btnNumPad6.RoundSize = 0;
            this.btnNumPad6.Selected = false;
            this.btnNumPad6.Size = new System.Drawing.Size(60, 47);
            this.btnNumPad6.TabIndex = 38;
            this.btnNumPad6.TextLabel = "6";
            this.btnNumPad6.TextMarginLeft = 0;
            this.btnNumPad6.Click += new System.EventHandler(this.numPad6Clicked);
            // 
            // btnNumPad5
            // 
            this.btnNumPad5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnNumPad5.BlinkColor = System.Drawing.Color.Transparent;
            this.btnNumPad5.BlinkEnabled = false;
            this.btnNumPad5.BlinkInterval = 200;
            this.btnNumPad5.BorderColor = System.Drawing.Color.Transparent;
            this.btnNumPad5.BorderWidth = 1F;
            this.btnNumPad5.ButtonColor = System.Drawing.Color.Transparent;
            this.btnNumPad5.ButtonEnabled = true;
            this.btnNumPad5.Font = new System.Drawing.Font("Roboto", 22F, System.Drawing.FontStyle.Regular);
            this.btnNumPad5.FromResource = false;
            this.btnNumPad5.HeadTextLabel = "";
            this.btnNumPad5.Location = new System.Drawing.Point(86, 153);
            this.btnNumPad5.Name = "btnNumPad5";
            this.btnNumPad5.ResourceNameBase = "buttton60x47";
            this.btnNumPad5.RoundSize = 0;
            this.btnNumPad5.Selected = false;
            this.btnNumPad5.Size = new System.Drawing.Size(60, 47);
            this.btnNumPad5.TabIndex = 37;
            this.btnNumPad5.TextLabel = "5";
            this.btnNumPad5.TextMarginLeft = 0;
            this.btnNumPad5.Click += new System.EventHandler(this.numPad5Clicked);
            // 
            // btnNumPad4
            // 
            this.btnNumPad4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnNumPad4.BlinkColor = System.Drawing.Color.Transparent;
            this.btnNumPad4.BlinkEnabled = false;
            this.btnNumPad4.BlinkInterval = 200;
            this.btnNumPad4.BorderColor = System.Drawing.Color.Transparent;
            this.btnNumPad4.BorderWidth = 1F;
            this.btnNumPad4.ButtonColor = System.Drawing.Color.Transparent;
            this.btnNumPad4.ButtonEnabled = true;
            this.btnNumPad4.Font = new System.Drawing.Font("Roboto", 22F, System.Drawing.FontStyle.Regular);
            this.btnNumPad4.FromResource = false;
            this.btnNumPad4.HeadTextLabel = "";
            this.btnNumPad4.Location = new System.Drawing.Point(20, 153);
            this.btnNumPad4.Name = "btnNumPad4";
            this.btnNumPad4.ResourceNameBase = "buttton60x47";
            this.btnNumPad4.RoundSize = 0;
            this.btnNumPad4.Selected = false;
            this.btnNumPad4.Size = new System.Drawing.Size(60, 47);
            this.btnNumPad4.TabIndex = 36;
            this.btnNumPad4.TextLabel = "4";
            this.btnNumPad4.TextMarginLeft = 0;
            this.btnNumPad4.Click += new System.EventHandler(this.numPad4Clicked);
            // 
            // btnNumPad9
            // 
            this.btnNumPad9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnNumPad9.BlinkColor = System.Drawing.Color.Transparent;
            this.btnNumPad9.BlinkEnabled = false;
            this.btnNumPad9.BlinkInterval = 200;
            this.btnNumPad9.BorderColor = System.Drawing.Color.Transparent;
            this.btnNumPad9.BorderWidth = 1F;
            this.btnNumPad9.ButtonColor = System.Drawing.Color.Transparent;
            this.btnNumPad9.ButtonEnabled = true;
            this.btnNumPad9.Font = new System.Drawing.Font("Roboto", 22F, System.Drawing.FontStyle.Regular);
            this.btnNumPad9.FromResource = false;
            this.btnNumPad9.HeadTextLabel = "";
            this.btnNumPad9.Location = new System.Drawing.Point(152, 100);
            this.btnNumPad9.Name = "btnNumPad9";
            this.btnNumPad9.ResourceNameBase = "buttton60x47";
            this.btnNumPad9.RoundSize = 0;
            this.btnNumPad9.Selected = false;
            this.btnNumPad9.Size = new System.Drawing.Size(60, 47);
            this.btnNumPad9.TabIndex = 35;
            this.btnNumPad9.TextLabel = "9";
            this.btnNumPad9.TextMarginLeft = 0;
            this.btnNumPad9.Click += new System.EventHandler(this.numPad9Clicked);
            // 
            // btnNumPad8
            // 
            this.btnNumPad8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnNumPad8.BlinkColor = System.Drawing.Color.Transparent;
            this.btnNumPad8.BlinkEnabled = false;
            this.btnNumPad8.BlinkInterval = 200;
            this.btnNumPad8.BorderColor = System.Drawing.Color.Transparent;
            this.btnNumPad8.BorderWidth = 1F;
            this.btnNumPad8.ButtonColor = System.Drawing.Color.Transparent;
            this.btnNumPad8.ButtonEnabled = true;
            this.btnNumPad8.Font = new System.Drawing.Font("Roboto", 22F, System.Drawing.FontStyle.Regular);
            this.btnNumPad8.FromResource = false;
            this.btnNumPad8.HeadTextLabel = "";
            this.btnNumPad8.Location = new System.Drawing.Point(86, 100);
            this.btnNumPad8.Name = "btnNumPad8";
            this.btnNumPad8.ResourceNameBase = "buttton60x47";
            this.btnNumPad8.RoundSize = 0;
            this.btnNumPad8.Selected = false;
            this.btnNumPad8.Size = new System.Drawing.Size(60, 47);
            this.btnNumPad8.TabIndex = 34;
            this.btnNumPad8.TextLabel = "8";
            this.btnNumPad8.TextMarginLeft = 0;
            this.btnNumPad8.Click += new System.EventHandler(this.numPad8Clicked);
            // 
            // btnNumPad7
            // 
            this.btnNumPad7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnNumPad7.BlinkColor = System.Drawing.Color.Transparent;
            this.btnNumPad7.BlinkEnabled = false;
            this.btnNumPad7.BlinkInterval = 200;
            this.btnNumPad7.BorderColor = System.Drawing.Color.Transparent;
            this.btnNumPad7.BorderWidth = 1F;
            this.btnNumPad7.ButtonColor = System.Drawing.Color.Transparent;
            this.btnNumPad7.ButtonEnabled = true;
            this.btnNumPad7.Font = new System.Drawing.Font("Roboto", 22F, System.Drawing.FontStyle.Regular);
            this.btnNumPad7.FromResource = false;
            this.btnNumPad7.HeadTextLabel = "";
            this.btnNumPad7.Location = new System.Drawing.Point(20, 100);
            this.btnNumPad7.Name = "btnNumPad7";
            this.btnNumPad7.ResourceNameBase = "buttton60x47";
            this.btnNumPad7.RoundSize = 0;
            this.btnNumPad7.Selected = false;
            this.btnNumPad7.Size = new System.Drawing.Size(60, 47);
            this.btnNumPad7.TabIndex = 33;
            this.btnNumPad7.TextLabel = "7";
            this.btnNumPad7.TextMarginLeft = 0;
            this.btnNumPad7.Click += new System.EventHandler(this.numPad7Clicked);
            // 
            // lblTitle
            // 
            this.lblTitle.AllineamentoOrizzontale = System.Drawing.StringAlignment.Center;
            this.lblTitle.AllineamentoVerticale = System.Drawing.StringAlignment.Center;
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(41)))), ((int)(((byte)(38)))));
            this.lblTitle.BackGroundresourceName = "";
            this.lblTitle.BorderBottom = true;
            this.lblTitle.BorderLeft = false;
            this.lblTitle.BorderRight = false;
            this.lblTitle.BorderTop = false;
            this.lblTitle.BottomLineResourceName = "";
            this.lblTitle.ButtonEnabled = true;
            this.lblTitle.EnableDebug = false;
            this.lblTitle.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.LineColor = System.Drawing.Color.DimGray;
            this.lblTitle.Location = new System.Drawing.Point(20, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Selected = false;
            this.lblTitle.Size = new System.Drawing.Size(192, 28);
            this.lblTitle.TabIndex = 32;
            this.lblTitle.TextLabel = "FrmNumPad.lblTitle.Text";
            // 
            // lblValue
            // 
            this.lblValue.AllineamentoOrizzontale = System.Drawing.StringAlignment.Center;
            this.lblValue.AllineamentoVerticale = System.Drawing.StringAlignment.Center;
            this.lblValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(41)))), ((int)(((byte)(38)))));
            this.lblValue.BackGroundresourceName = "";
            this.lblValue.BorderBottom = true;
            this.lblValue.BorderLeft = false;
            this.lblValue.BorderRight = false;
            this.lblValue.BorderTop = false;
            this.lblValue.BottomLineResourceName = "line192x1.bmp";
            this.lblValue.ButtonEnabled = true;
            this.lblValue.EnableDebug = false;
            this.lblValue.Font = new System.Drawing.Font("Roboto", 26F, System.Drawing.FontStyle.Regular);
            this.lblValue.ForeColor = System.Drawing.Color.White;
            this.lblValue.LineColor = System.Drawing.Color.DimGray;
            this.lblValue.Location = new System.Drawing.Point(20, 45);
            this.lblValue.Name = "lblValue";
            this.lblValue.Selected = false;
            this.lblValue.Size = new System.Drawing.Size(192, 49);
            this.lblValue.TabIndex = 27;
            this.lblValue.TextLabel = "";
            // 
            // frmNumPad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(41)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(233, 373);
            this.ControlBox = false;
            this.Controls.Add(this.sagoButton4);
            this.Controls.Add(this.sagoButton3);
            this.Controls.Add(this.sagoButton2);
            this.Controls.Add(this.sagoButton1);
            this.Controls.Add(this.btnNumPad2);
            this.Controls.Add(this.btnNumPad0);
            this.Controls.Add(this.btnNumPad3);
            this.Controls.Add(this.btnNumPad1);
            this.Controls.Add(this.btnNumPad6);
            this.Controls.Add(this.btnNumPad5);
            this.Controls.Add(this.btnNumPad4);
            this.Controls.Add(this.btnNumPad9);
            this.Controls.Add(this.btnNumPad8);
            this.Controls.Add(this.btnNumPad7);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblValue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNumPad";
            this.ResumeLayout(false);

        }

        #endregion

        private GraphicLabelCntrl lblValue;
        private GraphicLabelCntrl lblTitle;
        private SagoButton btnNumPad7;
        private SagoButton btnNumPad8;
        private SagoButton btnNumPad9;
        private SagoButton btnNumPad4;
        private SagoButton btnNumPad5;
        private SagoButton btnNumPad6;
        private SagoButton btnNumPad1;
        private SagoButton btnNumPad3;
        private SagoButton btnNumPad0;
        private SagoButton btnNumPad2;
        private SagoButton sagoButton1;
        private SagoButton sagoButton2;
        private SagoButton sagoButton3;
        private SagoButton sagoButton4;
    }
}