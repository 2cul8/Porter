namespace Cntrls
{
    partial class RdButton
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
            this.sLed = new Cntrls.StatusLeds();
            this.SuspendLayout();
            // 
            // sLed
            // 
            this.sLed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sLed.Location = new System.Drawing.Point(202, 3);
            this.sLed.Name = "sLed";
            this.sLed.Size = new System.Drawing.Size(20, 20);
            this.sLed.TabIndex = 0;
            this.sLed.Click += new System.EventHandler(this.rbClick);
            this.sLed.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDownEvent);
            this.sLed.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUpEvent);
            // 
            // RdButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.sLed);
            this.Name = "RdButton";
            this.Size = new System.Drawing.Size(225, 26);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDownEvent);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUpEvent);
            this.ResumeLayout(false);

        }

        #endregion

        private StatusLeds sLed;
    }
}
