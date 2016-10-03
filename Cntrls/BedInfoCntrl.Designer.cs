namespace Cntrls
{
    partial class BedInfoCntrl
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
            this.spinnerCntrl = new Cntrls.SpinnerCntrl();
            this.lblInfo = new Cntrls.GraphicLabelCntrl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new Cntrls.GraphicLabelCntrl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // spinnerCntrl
            // 
            this.spinnerCntrl.ButtonEnabled = true;
            this.spinnerCntrl.Location = new System.Drawing.Point(20, 26);
            this.spinnerCntrl.Name = "spinnerCntrl";
            this.spinnerCntrl.Selected = false;
            this.spinnerCntrl.Size = new System.Drawing.Size(32, 32);
            this.spinnerCntrl.SpinnerFramesDir = "SpinnerFramesWhite32x32";
            this.spinnerCntrl.SpinOn = false;
            this.spinnerCntrl.TabIndex = 0;
            this.spinnerCntrl.Visible = false;
            // 
            // lblInfo
            // 
            this.lblInfo.AllineamentoOrizzontale = System.Drawing.StringAlignment.Center;
            this.lblInfo.AllineamentoVerticale = System.Drawing.StringAlignment.Center;
            this.lblInfo.BackColor = System.Drawing.Color.Black;
            this.lblInfo.BackGroundresourceName = "";
            this.lblInfo.BorderBottom = true;
            this.lblInfo.BorderLeft = false;
            this.lblInfo.BorderRight = false;
            this.lblInfo.BorderTop = false;
            this.lblInfo.BottomLineResourceName = "";
            this.lblInfo.ButtonEnabled = true;
            this.lblInfo.EnableDebug = false;
            this.lblInfo.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular);
            this.lblInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(234)))));
            this.lblInfo.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(172)))), ((int)(((byte)(37)))));
            this.lblInfo.Location = new System.Drawing.Point(0, 38);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Selected = false;
            this.lblInfo.Size = new System.Drawing.Size(336, 46);
            this.lblInfo.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.lblInfo);
            this.panel1.Controls.Add(this.spinnerCntrl);
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(336, 84);
            // 
            // lblTitle
            // 
            this.lblTitle.AllineamentoOrizzontale = System.Drawing.StringAlignment.Center;
            this.lblTitle.AllineamentoVerticale = System.Drawing.StringAlignment.Center;
            this.lblTitle.BackColor = System.Drawing.Color.Black;
            this.lblTitle.BackGroundresourceName = "";
            this.lblTitle.BorderBottom = true;
            this.lblTitle.BorderLeft = false;
            this.lblTitle.BorderRight = false;
            this.lblTitle.BorderTop = false;
            this.lblTitle.BottomLineResourceName = "line336x3.bmp";
            this.lblTitle.ButtonEnabled = true;
            this.lblTitle.EnableDebug = false;
            this.lblTitle.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(234)))));
            this.lblTitle.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(172)))), ((int)(((byte)(37)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Selected = false;
            this.lblTitle.Size = new System.Drawing.Size(336, 32);
            this.lblTitle.TabIndex = 6;
            // 
            // BedInfoCntrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel1);
            this.Name = "BedInfoCntrl";
            this.Size = new System.Drawing.Size(352, 100);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SpinnerCntrl spinnerCntrl;
        private GraphicLabelCntrl lblInfo;
        private System.Windows.Forms.Panel panel1;
        private GraphicLabelCntrl lblTitle;
    }
}
