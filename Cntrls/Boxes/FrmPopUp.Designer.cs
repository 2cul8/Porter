namespace Cntrls.Boxes
{
    partial class FrmPopUp
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
            this.lblMessage = new Cntrls.GraphicLabelCntrl();
            this.lblTitle = new Cntrls.GraphicLabelCntrl();
            this.SuspendLayout();
            // 
            // tmrRefresh
            // 
            this.tmrRefresh.Tick += new System.EventHandler(this.refreshTick);
            // 
            // lblMessage
            // 
            this.lblMessage.AllineamentoOrizzontale = System.Drawing.StringAlignment.Center;
            this.lblMessage.AllineamentoVerticale = System.Drawing.StringAlignment.Center;
            this.lblMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(41)))), ((int)(((byte)(38)))));
            this.lblMessage.BackGroundresourceName = "";
            this.lblMessage.BorderBottom = false;
            this.lblMessage.BorderLeft = false;
            this.lblMessage.BorderRight = false;
            this.lblMessage.BorderTop = false;
            this.lblMessage.BottomLineResourceName = "";
            this.lblMessage.ButtonEnabled = true;
            this.lblMessage.Font = new System.Drawing.Font("Roboto", 20F, System.Drawing.FontStyle.Regular);
            this.lblMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(234)))));
            this.lblMessage.LineColor = System.Drawing.Color.Empty;
            this.lblMessage.Location = new System.Drawing.Point(9, 54);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Selected = false;
            this.lblMessage.Size = new System.Drawing.Size(442, 177);
            this.lblMessage.TabIndex = 7;
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
            this.lblTitle.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(234)))));
            this.lblTitle.LineColor = System.Drawing.Color.Empty;
            this.lblTitle.Location = new System.Drawing.Point(9, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Selected = false;
            this.lblTitle.Size = new System.Drawing.Size(442, 39);
            this.lblTitle.TabIndex = 4;
            // 
            // FrmPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(41)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(460, 240);
            this.ControlBox = false;
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPopUp";
            this.Text = "FrmPopUp";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrRefresh;
        private GraphicLabelCntrl lblTitle;
        private GraphicLabelCntrl lblMessage;
    }
}