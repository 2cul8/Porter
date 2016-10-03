namespace SagoPorter.Controlli
{
    partial class ControlloInMovimento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlloInMovimento));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tmrHide = new System.Windows.Forms.Timer();
            this.lblVelocitàTitle = new Cntrls.GraphicLabelCntrl();
            this.lblVelocità = new Cntrls.GraphicLabelCntrl();
            this.lblSterzoTitle = new Cntrls.GraphicLabelCntrl();
            this.lblSterzo = new Cntrls.GraphicLabelCntrl();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(33, 56);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 92);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(33, 213);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 92);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            // 
            // tmrHide
            // 
            this.tmrHide.Interval = 500;
            this.tmrHide.Tick += new System.EventHandler(this.onTimerHideTick);
            // 
            // lblVelocitàTitle
            // 
            this.lblVelocitàTitle.AllineamentoOrizzontale = System.Drawing.StringAlignment.Center;
            this.lblVelocitàTitle.AllineamentoVerticale = System.Drawing.StringAlignment.Center;
            this.lblVelocitàTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(234)))));
            this.lblVelocitàTitle.BackGroundresourceName = "";
            this.lblVelocitàTitle.BorderBottom = false;
            this.lblVelocitàTitle.BorderLeft = false;
            this.lblVelocitàTitle.BorderRight = false;
            this.lblVelocitàTitle.BorderTop = false;
            this.lblVelocitàTitle.BottomLineResourceName = "";
            this.lblVelocitàTitle.ButtonEnabled = true;
            this.lblVelocitàTitle.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular);
            this.lblVelocitàTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(41)))), ((int)(((byte)(38)))));
            this.lblVelocitàTitle.LineColor = System.Drawing.Color.Empty;
            this.lblVelocitàTitle.Location = new System.Drawing.Point(83, 56);
            this.lblVelocitàTitle.Name = "lblVelocitàTitle";
            this.lblVelocitàTitle.Selected = false;
            this.lblVelocitàTitle.Size = new System.Drawing.Size(148, 43);
            this.lblVelocitàTitle.TabIndex = 3;
            // 
            // lblVelocità
            // 
            this.lblVelocità.AllineamentoOrizzontale = System.Drawing.StringAlignment.Center;
            this.lblVelocità.AllineamentoVerticale = System.Drawing.StringAlignment.Center;
            this.lblVelocità.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(234)))));
            this.lblVelocità.BackGroundresourceName = "";
            this.lblVelocità.BorderBottom = false;
            this.lblVelocità.BorderLeft = false;
            this.lblVelocità.BorderRight = false;
            this.lblVelocità.BorderTop = false;
            this.lblVelocità.BottomLineResourceName = "";
            this.lblVelocità.ButtonEnabled = true;
            this.lblVelocità.Font = new System.Drawing.Font("Roboto", 26F, System.Drawing.FontStyle.Regular);
            this.lblVelocità.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(41)))), ((int)(((byte)(38)))));
            this.lblVelocità.LineColor = System.Drawing.Color.Empty;
            this.lblVelocità.Location = new System.Drawing.Point(83, 105);
            this.lblVelocità.Name = "lblVelocità";
            this.lblVelocità.Selected = false;
            this.lblVelocità.Size = new System.Drawing.Size(148, 43);
            this.lblVelocità.TabIndex = 2;
            // 
            // lblSterzoTitle
            // 
            this.lblSterzoTitle.AllineamentoOrizzontale = System.Drawing.StringAlignment.Center;
            this.lblSterzoTitle.AllineamentoVerticale = System.Drawing.StringAlignment.Center;
            this.lblSterzoTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(234)))));
            this.lblSterzoTitle.BackGroundresourceName = "";
            this.lblSterzoTitle.BorderBottom = false;
            this.lblSterzoTitle.BorderLeft = false;
            this.lblSterzoTitle.BorderRight = false;
            this.lblSterzoTitle.BorderTop = false;
            this.lblSterzoTitle.BottomLineResourceName = "";
            this.lblSterzoTitle.ButtonEnabled = true;
            this.lblSterzoTitle.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular);
            this.lblSterzoTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(41)))), ((int)(((byte)(38)))));
            this.lblSterzoTitle.LineColor = System.Drawing.Color.Empty;
            this.lblSterzoTitle.Location = new System.Drawing.Point(83, 213);
            this.lblSterzoTitle.Name = "lblSterzoTitle";
            this.lblSterzoTitle.Selected = false;
            this.lblSterzoTitle.Size = new System.Drawing.Size(148, 43);
            this.lblSterzoTitle.TabIndex = 1;
            // 
            // lblSterzo
            // 
            this.lblSterzo.AllineamentoOrizzontale = System.Drawing.StringAlignment.Center;
            this.lblSterzo.AllineamentoVerticale = System.Drawing.StringAlignment.Center;
            this.lblSterzo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(234)))));
            this.lblSterzo.BackGroundresourceName = "";
            this.lblSterzo.BorderBottom = false;
            this.lblSterzo.BorderLeft = false;
            this.lblSterzo.BorderRight = false;
            this.lblSterzo.BorderTop = false;
            this.lblSterzo.BottomLineResourceName = "";
            this.lblSterzo.ButtonEnabled = true;
            this.lblSterzo.Font = new System.Drawing.Font("Roboto", 26F, System.Drawing.FontStyle.Regular);
            this.lblSterzo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(41)))), ((int)(((byte)(38)))));
            this.lblSterzo.LineColor = System.Drawing.Color.Empty;
            this.lblSterzo.Location = new System.Drawing.Point(83, 262);
            this.lblSterzo.Name = "lblSterzo";
            this.lblSterzo.Selected = false;
            this.lblSterzo.Size = new System.Drawing.Size(148, 43);
            this.lblSterzo.TabIndex = 0;
            // 
            // ControlloInMovimento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblVelocitàTitle);
            this.Controls.Add(this.lblVelocità);
            this.Controls.Add(this.lblSterzoTitle);
            this.Controls.Add(this.lblSterzo);
            this.Name = "ControlloInMovimento";
            this.Size = new System.Drawing.Size(242, 361);
            this.ResumeLayout(false);

        }

        #endregion

        private Cntrls.GraphicLabelCntrl lblSterzo;
        private Cntrls.GraphicLabelCntrl lblSterzoTitle;
        private Cntrls.GraphicLabelCntrl lblVelocitàTitle;
        private Cntrls.GraphicLabelCntrl lblVelocità;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Timer tmrHide;
    }
}
