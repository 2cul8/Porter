namespace SagoPorter
{
    partial class FrmMessages
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
            this.tmrRefresh = new System.Windows.Forms.Timer();
            this.lblSelectedMessageText = new Cntrls.GraphicLabelCntrl();
            this.btnReturnResponse = new Cntrls.SagoButton();
            this.lblTitle = new Cntrls.GraphicLabelCntrl();
            this.messagesTabCntrl1 = new Cntrls.MessagesTabCntrl();
            this.SuspendLayout();
            // 
            // tmrRefresh
            // 
            this.tmrRefresh.Interval = 500;
            this.tmrRefresh.Tick += new System.EventHandler(this.refreshTick);
            // 
            // lblSelectedMessageText
            // 
            this.lblSelectedMessageText.AllineamentoOrizzontale = System.Drawing.StringAlignment.Center;
            this.lblSelectedMessageText.AllineamentoVerticale = System.Drawing.StringAlignment.Center;
            this.lblSelectedMessageText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(41)))), ((int)(((byte)(38)))));
            this.lblSelectedMessageText.BackGroundresourceName = "";
            this.lblSelectedMessageText.BorderBottom = true;
            this.lblSelectedMessageText.BorderLeft = false;
            this.lblSelectedMessageText.BorderRight = false;
            this.lblSelectedMessageText.BorderTop = false;
            this.lblSelectedMessageText.BottomLineResourceName = "";
            this.lblSelectedMessageText.ButtonEnabled = true;
            this.lblSelectedMessageText.EnableDebug = true;
            this.lblSelectedMessageText.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular);
            this.lblSelectedMessageText.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblSelectedMessageText.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(172)))), ((int)(((byte)(37)))));
            this.lblSelectedMessageText.Location = new System.Drawing.Point(8, 345);
            this.lblSelectedMessageText.Name = "lblSelectedMessageText";
            this.lblSelectedMessageText.Selected = false;
            this.lblSelectedMessageText.Size = new System.Drawing.Size(651, 47);
            this.lblSelectedMessageText.TabIndex = 55;
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
            this.btnReturnResponse.Location = new System.Drawing.Point(617, 8);
            this.btnReturnResponse.Name = "btnReturnResponse";
            this.btnReturnResponse.ResourceNameBase = "closeButton";
            this.btnReturnResponse.RoundSize = 0;
            this.btnReturnResponse.Selected = false;
            this.btnReturnResponse.Size = new System.Drawing.Size(42, 42);
            this.btnReturnResponse.TabIndex = 53;
            this.btnReturnResponse.TextMarginLeft = 0;
            this.btnReturnResponse.HeadTextLabel = "";
            this.btnReturnResponse.Click += new System.EventHandler(this.closeRequested);
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
            this.lblTitle.Location = new System.Drawing.Point(8, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Selected = false;
            this.lblTitle.Size = new System.Drawing.Size(651, 42);
            this.lblTitle.TabIndex = 5;
            // 
            // messagesTabCntrl1
            // 
            this.messagesTabCntrl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(41)))), ((int)(((byte)(38)))));
            this.messagesTabCntrl1.ButtonEnabled = true;
            this.messagesTabCntrl1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular);
            this.messagesTabCntrl1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(20)))), ((int)(((byte)(19)))));
            this.messagesTabCntrl1.Location = new System.Drawing.Point(8, 56);
            this.messagesTabCntrl1.Name = "messagesTabCntrl1";
            this.messagesTabCntrl1.Selected = false;
            this.messagesTabCntrl1.Size = new System.Drawing.Size(651, 283);
            this.messagesTabCntrl1.TabIndex = 0;
            this.messagesTabCntrl1.SelectedItemChanged += new System.EventHandler(this.onItemSelected);
            // 
            // FrmMessages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(41)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(667, 400);
            this.ControlBox = false;
            this.Controls.Add(this.lblSelectedMessageText);
            this.Controls.Add(this.btnReturnResponse);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.messagesTabCntrl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMessages";
            this.Text = "FrmMessages";
            this.ResumeLayout(false);

        }

        #endregion

        private Cntrls.MessagesTabCntrl messagesTabCntrl1;
        private Cntrls.GraphicLabelCntrl lblTitle;
        private Cntrls.SagoButton btnReturnResponse;
        private System.Windows.Forms.Timer tmrRefresh;
        private Cntrls.GraphicLabelCntrl lblSelectedMessageText;
    }
}