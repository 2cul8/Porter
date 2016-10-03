namespace Cntrls.Boxes
{
    partial class frmMessageBox
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
            this.btnClose = new Cntrls.SagoButton();
            this.btnReturnResponse = new Cntrls.SagoButton();
            this.btnYesResponse = new Cntrls.SagoButton();
            this.btnNoResponse = new Cntrls.SagoButton();
            this.lblText = new Cntrls.GraphicLabelCntrl();
            this.lblTitle = new Cntrls.GraphicLabelCntrl();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnClose.BlinkColor = System.Drawing.Color.Transparent;
            this.btnClose.BlinkEnabled = false;
            this.btnClose.BlinkInterval = 200;
            this.btnClose.BorderColor = System.Drawing.Color.Transparent;
            this.btnClose.BorderWidth = 1F;
            this.btnClose.ButtonColor = System.Drawing.Color.Transparent;
            this.btnClose.ButtonEnabled = true;
            this.btnClose.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular);
            this.btnClose.FromResource = false;
            this.btnClose.HeadTextLabel = "";
            this.btnClose.Location = new System.Drawing.Point(167, 184);
            this.btnClose.Name = "btnClose";
            this.btnClose.ResourceNameBase = "buttton126x47_redo";
            this.btnClose.RoundSize = 0;
            this.btnClose.Selected = false;
            this.btnClose.Size = new System.Drawing.Size(126, 47);
            this.btnClose.TabIndex = 48;
            this.btnClose.TextLabel = "";
            this.btnClose.TextMarginLeft = 0;
            this.btnClose.Click += new System.EventHandler(this.closeRequested);
            // 
            // btnReturnResponse
            // 
            this.btnReturnResponse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnReturnResponse.BlinkColor = System.Drawing.Color.Transparent;
            this.btnReturnResponse.BlinkEnabled = false;
            this.btnReturnResponse.BlinkInterval = 200;
            this.btnReturnResponse.BorderColor = System.Drawing.Color.Transparent;
            this.btnReturnResponse.BorderWidth = 1F;
            this.btnReturnResponse.ButtonColor = System.Drawing.Color.Transparent;
            this.btnReturnResponse.ButtonEnabled = true;
            this.btnReturnResponse.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular);
            this.btnReturnResponse.FromResource = false;
            this.btnReturnResponse.HeadTextLabel = "";
            this.btnReturnResponse.Location = new System.Drawing.Point(325, 184);
            this.btnReturnResponse.Name = "btnReturnResponse";
            this.btnReturnResponse.ResourceNameBase = "buttton126x47";
            this.btnReturnResponse.RoundSize = 0;
            this.btnReturnResponse.Selected = false;
            this.btnReturnResponse.Size = new System.Drawing.Size(126, 47);
            this.btnReturnResponse.TabIndex = 51;
            this.btnReturnResponse.TextLabel = "FrmMessageBox.btnReturnResponse.Text";
            this.btnReturnResponse.TextMarginLeft = 0;
            this.btnReturnResponse.Click += new System.EventHandler(this.returnResponseRequested);
            // 
            // btnYesResponse
            // 
            this.btnYesResponse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnYesResponse.BlinkColor = System.Drawing.Color.Transparent;
            this.btnYesResponse.BlinkEnabled = false;
            this.btnYesResponse.BlinkInterval = 200;
            this.btnYesResponse.BorderColor = System.Drawing.Color.Transparent;
            this.btnYesResponse.BorderWidth = 1F;
            this.btnYesResponse.ButtonColor = System.Drawing.Color.Transparent;
            this.btnYesResponse.ButtonEnabled = true;
            this.btnYesResponse.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular);
            this.btnYesResponse.FromResource = false;
            this.btnYesResponse.HeadTextLabel = "";
            this.btnYesResponse.Location = new System.Drawing.Point(9, 184);
            this.btnYesResponse.Name = "btnYesResponse";
            this.btnYesResponse.ResourceNameBase = "buttton126x47";
            this.btnYesResponse.RoundSize = 0;
            this.btnYesResponse.Selected = false;
            this.btnYesResponse.Size = new System.Drawing.Size(126, 47);
            this.btnYesResponse.TabIndex = 50;
            this.btnYesResponse.TextLabel = "SI";
            this.btnYesResponse.TextMarginLeft = 0;
            this.btnYesResponse.Click += new System.EventHandler(this.yesResponseRequested);
            // 
            // btnNoResponse
            // 
            this.btnNoResponse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnNoResponse.BlinkColor = System.Drawing.Color.Transparent;
            this.btnNoResponse.BlinkEnabled = false;
            this.btnNoResponse.BlinkInterval = 200;
            this.btnNoResponse.BorderColor = System.Drawing.Color.Transparent;
            this.btnNoResponse.BorderWidth = 1F;
            this.btnNoResponse.ButtonColor = System.Drawing.Color.Transparent;
            this.btnNoResponse.ButtonEnabled = true;
            this.btnNoResponse.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular);
            this.btnNoResponse.FromResource = false;
            this.btnNoResponse.HeadTextLabel = "";
            this.btnNoResponse.Location = new System.Drawing.Point(141, 184);
            this.btnNoResponse.Name = "btnNoResponse";
            this.btnNoResponse.ResourceNameBase = "buttton126x47";
            this.btnNoResponse.RoundSize = 0;
            this.btnNoResponse.Selected = false;
            this.btnNoResponse.Size = new System.Drawing.Size(126, 47);
            this.btnNoResponse.TabIndex = 49;
            this.btnNoResponse.TextLabel = "NO";
            this.btnNoResponse.TextMarginLeft = 0;
            this.btnNoResponse.Click += new System.EventHandler(this.noResponseRequested);
            // 
            // lblText
            // 
            this.lblText.AllineamentoOrizzontale = System.Drawing.StringAlignment.Near;
            this.lblText.AllineamentoVerticale = System.Drawing.StringAlignment.Near;
            this.lblText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(41)))), ((int)(((byte)(38)))));
            this.lblText.BackGroundresourceName = "";
            this.lblText.BorderBottom = false;
            this.lblText.BorderLeft = false;
            this.lblText.BorderRight = false;
            this.lblText.BorderTop = false;
            this.lblText.BottomLineResourceName = "";
            this.lblText.ButtonEnabled = true;
            this.lblText.EnableDebug = false;
            this.lblText.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular);
            this.lblText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(234)))));
            this.lblText.LineColor = System.Drawing.Color.Empty;
            this.lblText.Location = new System.Drawing.Point(9, 54);
            this.lblText.Name = "lblText";
            this.lblText.Selected = false;
            this.lblText.Size = new System.Drawing.Size(442, 124);
            this.lblText.TabIndex = 3;
            this.lblText.TextLabel = "";
            // 
            // lblTitle
            // 
            this.lblTitle.AllineamentoOrizzontale = System.Drawing.StringAlignment.Center;
            this.lblTitle.AllineamentoVerticale = System.Drawing.StringAlignment.Center;
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(41)))), ((int)(((byte)(38)))));
            this.lblTitle.BackGroundresourceName = "";
            this.lblTitle.BorderBottom = false;
            this.lblTitle.BorderLeft = false;
            this.lblTitle.BorderRight = false;
            this.lblTitle.BorderTop = false;
            this.lblTitle.BottomLineResourceName = "line192x1.bmp";
            this.lblTitle.ButtonEnabled = true;
            this.lblTitle.EnableDebug = false;
            this.lblTitle.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(234)))));
            this.lblTitle.LineColor = System.Drawing.Color.Empty;
            this.lblTitle.Location = new System.Drawing.Point(9, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Selected = false;
            this.lblTitle.Size = new System.Drawing.Size(442, 39);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.TextLabel = "";
            // 
            // frmMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(41)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(460, 240);
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnReturnResponse);
            this.Controls.Add(this.btnYesResponse);
            this.Controls.Add(this.btnNoResponse);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMessageBox";
            this.Text = "frmMessageBox";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private GraphicLabelCntrl lblTitle;
        private GraphicLabelCntrl lblText;
        private SagoButton btnClose;
        private SagoButton btnNoResponse;
        private SagoButton btnYesResponse;
        private SagoButton btnReturnResponse;
    }
}