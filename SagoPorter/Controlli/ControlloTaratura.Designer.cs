namespace SagoPorter.Controlli
{
    partial class ControlloTaratura
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
            this.tarPotSterzo = new Cntrls.TarPotenziometro();
            this.tarPotVelocità = new Cntrls.TarPotenziometro();
            this.tmrReadAdc = new System.Windows.Forms.Timer();
            this.SuspendLayout();
            // 
            // tarPotSterzo
            // 
            this.tarPotSterzo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tarPotSterzo.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular);
            this.tarPotSterzo.ForeColor = System.Drawing.Color.Gainsboro;
            this.tarPotSterzo.Labels = "Posizione;Teorico;Reale;Acquisito";
            this.tarPotSterzo.LabelsFont = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular);
            this.tarPotSterzo.Location = new System.Drawing.Point(4, 240);
            this.tarPotSterzo.Name = "tarPotSterzo";
            this.tarPotSterzo.RealValue = "---";
            this.tarPotSterzo.Size = new System.Drawing.Size(677, 240);
            this.tarPotSterzo.TabIndex = 1;
            this.tarPotSterzo.Title = "Potenziometro Sterzo";
            this.tarPotSterzo.TitleFont = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular);
            this.tarPotSterzo.SetValue += new System.EventHandler(this.SetPotSterzoValue);
            // 
            // tarPotVelocità
            // 
            this.tarPotVelocità.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tarPotVelocità.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular);
            this.tarPotVelocità.ForeColor = System.Drawing.Color.Gainsboro;
            this.tarPotVelocità.Labels = "Posizione;Teorico;Reale;Acquisito";
            this.tarPotVelocità.LabelsFont = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular);
            this.tarPotVelocità.Location = new System.Drawing.Point(4, 0);
            this.tarPotVelocità.Name = "tarPotVelocità";
            this.tarPotVelocità.RealValue = "---";
            this.tarPotVelocità.Size = new System.Drawing.Size(677, 240);
            this.tarPotVelocità.TabIndex = 0;
            this.tarPotVelocità.Title = "Potenziometro Velocità";
            this.tarPotVelocità.TitleFont = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular);
            this.tarPotVelocità.SetValue += new System.EventHandler(this.SetPotVelocitàValue);
            // 
            // tmrReadAdc
            // 
            this.tmrReadAdc.Tick += new System.EventHandler(this.onTmrTick);
            // 
            // ControlloTaratura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Controls.Add(this.tarPotSterzo);
            this.Controls.Add(this.tarPotVelocità);
            this.Name = "ControlloTaratura";
            this.Size = new System.Drawing.Size(664, 480);
            this.ResumeLayout(false);

        }

        #endregion

        private Cntrls.TarPotenziometro tarPotVelocità;
        private Cntrls.TarPotenziometro tarPotSterzo;
        private System.Windows.Forms.Timer tmrReadAdc;
    }
}
