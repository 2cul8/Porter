namespace Cntrls
{
    partial class TabPorterCntrl
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
            this.sagoButton1 = new Cntrls.SagoButton();
            this.sagoButton2 = new Cntrls.SagoButton();
            this.lblPage = new Cntrls.GraphicLabelCntrl();
            this.SuspendLayout();
            // 
            // sagoButton1
            // 
            this.sagoButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sagoButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(237)))));
            this.sagoButton1.BlinkColor = System.Drawing.Color.Transparent;
            this.sagoButton1.BlinkEnabled = false;
            this.sagoButton1.BlinkInterval = 100;
            this.sagoButton1.BorderColor = System.Drawing.Color.Transparent;
            this.sagoButton1.BorderWidth = 1F;
            this.sagoButton1.ButtonColor = System.Drawing.Color.Transparent;
            this.sagoButton1.FromResource = false;
            this.sagoButton1.Location = new System.Drawing.Point(305, 389);
            this.sagoButton1.Name = "sagoButton1";
            this.sagoButton1.ResourceNameBase = "moveRight";
            this.sagoButton1.RoundSize = 0;
            this.sagoButton1.Selected = false;
            this.sagoButton1.Size = new System.Drawing.Size(198, 31);
            this.sagoButton1.TabIndex = 0;
            this.sagoButton1.TextMarginLeft = 0;
            this.sagoButton1.Click += new System.EventHandler(this.onNextRequested);
            // 
            // sagoButton2
            // 
            this.sagoButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sagoButton2.BackColor = System.Drawing.Color.Transparent;
            this.sagoButton2.BlinkColor = System.Drawing.Color.Transparent;
            this.sagoButton2.BlinkEnabled = false;
            this.sagoButton2.BlinkInterval = 100;
            this.sagoButton2.BorderColor = System.Drawing.Color.Transparent;
            this.sagoButton2.BorderWidth = 1F;
            this.sagoButton2.ButtonColor = System.Drawing.Color.Transparent;
            this.sagoButton2.FromResource = false;
            this.sagoButton2.Location = new System.Drawing.Point(4, 389);
            this.sagoButton2.Name = "sagoButton2";
            this.sagoButton2.ResourceNameBase = "moveLeft";
            this.sagoButton2.RoundSize = 0;
            this.sagoButton2.Selected = false;
            this.sagoButton2.Size = new System.Drawing.Size(198, 31);
            this.sagoButton2.TabIndex = 1;
            this.sagoButton2.TextMarginLeft = 0;
            this.sagoButton2.Click += new System.EventHandler(this.onPrevRequested);
            // 
            // lblPage
            // 
            this.lblPage.AllineamentoOrizzontale = System.Drawing.StringAlignment.Center;
            this.lblPage.AllineamentoVerticale = System.Drawing.StringAlignment.Center;
            this.lblPage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(237)))));
            this.lblPage.BackGroundresourceName = "";
            this.lblPage.BorderBottom = false;
            this.lblPage.BorderLeft = false;
            this.lblPage.BorderRight = false;
            this.lblPage.BorderTop = false;
            this.lblPage.BottomLineResourceName = "";
            this.lblPage.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular);
            this.lblPage.LineColor = System.Drawing.Color.Empty;
            this.lblPage.Location = new System.Drawing.Point(208, 394);
            this.lblPage.Name = "lblPage";
            this.lblPage.Selected = false;
            this.lblPage.Size = new System.Drawing.Size(91, 28);
            this.lblPage.TabIndex = 2;
            this.lblPage.Click += new System.EventHandler(this.lblPage_Click);
            // 
            // TabPorterCntrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(232)))));
            this.Controls.Add(this.lblPage);
            this.Controls.Add(this.sagoButton2);
            this.Controls.Add(this.sagoButton1);
            this.Name = "TabPorterCntrl";
            this.Size = new System.Drawing.Size(507, 426);
            this.ResumeLayout(false);

        }

        #endregion

        private SagoButton sagoButton1;
        private SagoButton sagoButton2;
        private GraphicLabelCntrl lblPage;
    }
}
