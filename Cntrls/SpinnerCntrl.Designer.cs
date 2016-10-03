namespace Cntrls
{
    partial class SpinnerCntrl
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
            this.tmrChangeBitmap = new System.Windows.Forms.Timer();
            this.SuspendLayout();
            // 
            // tmrChangeBitmap
            // 
            this.tmrChangeBitmap.Interval = 60;
            this.tmrChangeBitmap.Tick += new System.EventHandler(this.onTmrTick);
            // 
            // SpinnerCntrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Name = "SpinnerCntrl";
            this.Size = new System.Drawing.Size(128, 128);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrChangeBitmap;
    }
}
