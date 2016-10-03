namespace Cntrls
{
    partial class LedMatrix
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
            this.tmrGraphicRefresh = new System.Windows.Forms.Timer();
            this.SuspendLayout();
            // 
            // tmrGraphicRefresh
            // 
            this.tmrGraphicRefresh.Interval = 400;
            this.tmrGraphicRefresh.Tick += new System.EventHandler(this.RefreshGraphic);
            // 
            // LedMatrix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Black;
            this.Name = "LedMatrix";
            this.Size = new System.Drawing.Size(800, 200);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrGraphicRefresh;
    }
}
