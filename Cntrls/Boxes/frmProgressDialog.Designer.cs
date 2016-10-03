namespace Cntrls.Boxes
{
    partial class frmProgressDialog
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.spinnerCntrl1 = new Cntrls.SpinnerCntrl();
            this.lblTitle = new Cntrls.GraphicLabelCntrl();
            this.lblPercentage = new Cntrls.GraphicLabelCntrl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmrRefresh
            // 
            this.tmrRefresh.Tick += new System.EventHandler(this.refreshTick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(41)))), ((int)(((byte)(38)))));
            this.panel1.Controls.Add(this.spinnerCntrl1);
            this.panel1.Location = new System.Drawing.Point(294, 82);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(100, 100);
            // 
            // spinnerCntrl1
            // 
            this.spinnerCntrl1.BackColor = System.Drawing.Color.White;
            this.spinnerCntrl1.ButtonEnabled = true;
            this.spinnerCntrl1.Location = new System.Drawing.Point(18, 18);
            this.spinnerCntrl1.Name = "spinnerCntrl1";
            this.spinnerCntrl1.Selected = false;
            this.spinnerCntrl1.Size = new System.Drawing.Size(64, 64);
            this.spinnerCntrl1.SpinnerFramesDir = "SpinnerFramesWhite";
            this.spinnerCntrl1.SpinOn = true;
            this.spinnerCntrl1.TabIndex = 5;
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
            this.lblTitle.TabIndex = 1;
            // 
            // lblPercentage
            // 
            this.lblPercentage.AllineamentoOrizzontale = System.Drawing.StringAlignment.Center;
            this.lblPercentage.AllineamentoVerticale = System.Drawing.StringAlignment.Center;
            this.lblPercentage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(41)))), ((int)(((byte)(38)))));
            this.lblPercentage.BackGroundresourceName = "";
            this.lblPercentage.BorderBottom = false;
            this.lblPercentage.BorderLeft = false;
            this.lblPercentage.BorderRight = false;
            this.lblPercentage.BorderTop = false;
            this.lblPercentage.BottomLineResourceName = "";
            this.lblPercentage.ButtonEnabled = true;
            this.lblPercentage.Font = new System.Drawing.Font("Roboto", 48F, System.Drawing.FontStyle.Regular);
            this.lblPercentage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(234)))));
            this.lblPercentage.LineColor = System.Drawing.Color.Empty;
            this.lblPercentage.Location = new System.Drawing.Point(67, 82);
            this.lblPercentage.Name = "lblPercentage";
            this.lblPercentage.Selected = false;
            this.lblPercentage.Size = new System.Drawing.Size(221, 100);
            this.lblPercentage.TabIndex = 0;
            // 
            // frmProgressDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(41)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(460, 240);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblPercentage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProgressDialog";
            this.Text = "frmProgressDialog";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GraphicLabelCntrl lblPercentage;
        private GraphicLabelCntrl lblTitle;
        private System.Windows.Forms.Timer tmrRefresh;
        private System.Windows.Forms.Panel panel1;
        private SpinnerCntrl spinnerCntrl1;
    }
}