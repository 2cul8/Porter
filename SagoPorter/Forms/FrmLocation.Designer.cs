namespace SagoPorter
{
    partial class FrmLocation
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
            this.lblInfo = new Cntrls.GraphicLabelCntrl();
            this.btnSend = new Cntrls.SagoButton();
            this.btnReturnResponse = new Cntrls.SagoButton();
            this.lblTitle = new Cntrls.GraphicLabelCntrl();
            this.locationsList = new Cntrls.StringContainerControl();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.AllineamentoOrizzontale = System.Drawing.StringAlignment.Center;
            this.lblInfo.AllineamentoVerticale = System.Drawing.StringAlignment.Near;
            this.lblInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(41)))), ((int)(((byte)(38)))));
            this.lblInfo.BackGroundresourceName = "";
            this.lblInfo.BorderBottom = false;
            this.lblInfo.BorderLeft = false;
            this.lblInfo.BorderRight = false;
            this.lblInfo.BorderTop = false;
            this.lblInfo.BottomLineResourceName = "line192x1.bmp";
            this.lblInfo.ButtonEnabled = true;
            this.lblInfo.EnableDebug = false;
            this.lblInfo.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular);
            this.lblInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(234)))));
            this.lblInfo.LineColor = System.Drawing.Color.Empty;
            this.lblInfo.Location = new System.Drawing.Point(397, 130);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Selected = false;
            this.lblInfo.Size = new System.Drawing.Size(260, 176);
            this.lblInfo.TabIndex = 59;
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnSend.BlinkColor = System.Drawing.Color.Transparent;
            this.btnSend.BlinkEnabled = false;
            this.btnSend.BlinkInterval = 200;
            this.btnSend.BorderColor = System.Drawing.Color.Transparent;
            this.btnSend.BorderWidth = 1F;
            this.btnSend.ButtonColor = System.Drawing.Color.Transparent;
            this.btnSend.ButtonEnabled = true;
            this.btnSend.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular);
            this.btnSend.FromResource = false;
            this.btnSend.Location = new System.Drawing.Point(397, 330);
            this.btnSend.Name = "btnSend";
            this.btnSend.ResourceNameBase = "sendButton";
            this.btnSend.RoundSize = 0;
            this.btnSend.Selected = false;
            this.btnSend.Size = new System.Drawing.Size(260, 62);
            this.btnSend.TabIndex = 57;
            this.btnSend.TextMarginLeft = 0;
            this.btnSend.HeadTextLabel = "";
            this.btnSend.Click += new System.EventHandler(this.sendRequested);
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
            this.btnReturnResponse.Location = new System.Drawing.Point(615, 8);
            this.btnReturnResponse.Name = "btnReturnResponse";
            this.btnReturnResponse.ResourceNameBase = "closeButton";
            this.btnReturnResponse.RoundSize = 0;
            this.btnReturnResponse.Selected = false;
            this.btnReturnResponse.Size = new System.Drawing.Size(42, 42);
            this.btnReturnResponse.TabIndex = 52;
            this.btnReturnResponse.TextMarginLeft = 0;
            this.btnReturnResponse.HeadTextLabel = "";
            this.btnReturnResponse.Click += new System.EventHandler(this.abortRequested);
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
            this.lblTitle.Size = new System.Drawing.Size(601, 42);
            this.lblTitle.TabIndex = 4;
            // 
            // locationsList
            // 
            this.locationsList.Allineamento = System.Drawing.StringAlignment.Near;
            this.locationsList.AutoScrollEnable = false;
            this.locationsList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(41)))), ((int)(((byte)(38)))));
            this.locationsList.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(73)))), ((int)(((byte)(71)))));
            this.locationsList.BorderWidth = 1F;
            this.locationsList.ClickEnable = true;
            this.locationsList.Location = new System.Drawing.Point(8, 56);
            this.locationsList.Name = "locationsList";
            this.locationsList.NoStringText = "";
            this.locationsList.ShowIndex = true;
            this.locationsList.ShowListButtons = false;
            this.locationsList.ShowSelectedItem = true;
            this.locationsList.Size = new System.Drawing.Size(383, 336);
            this.locationsList.StringBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(234)))));
            this.locationsList.StringFont = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular);
            this.locationsList.StringForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(41)))), ((int)(((byte)(38)))));
            this.locationsList.StringHeight = 32;
            this.locationsList.StringIndexFont = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular);
            this.locationsList.StringSelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.locationsList.StringSelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(234)))));
            this.locationsList.TabIndex = 58;
            this.locationsList.UseCheckCntrl = false;
            this.locationsList.selectedLineChanged += new System.EventHandler(this.onLineSelected);
            // 
            // FrmLocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(41)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(667, 400);
            this.ControlBox = false;
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnReturnResponse);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.locationsList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLocation";
            this.Text = "FrmLocation";
            this.ResumeLayout(false);

        }

        #endregion

        private Cntrls.GraphicLabelCntrl lblTitle;
        private Cntrls.SagoButton btnReturnResponse;
        private Cntrls.SagoButton btnSend;
        private Cntrls.StringContainerControl locationsList;
        private Cntrls.GraphicLabelCntrl lblInfo;
    }
}