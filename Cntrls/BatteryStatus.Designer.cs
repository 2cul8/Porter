namespace Cntrls
{
    partial class BatteryStatus
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
            this.btnExpand = new Cntrls.SagoButton();
            this.btnCollapse = new Cntrls.SagoButton();
            this.SuspendLayout();
            // 
            // btnExpand
            // 
            this.btnExpand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(21)))), ((int)(((byte)(5)))));
            this.btnExpand.BlinkColor = System.Drawing.Color.Gainsboro;
            this.btnExpand.BlinkEnabled = false;
            this.btnExpand.BlinkInterval = 1000;
            this.btnExpand.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(172)))), ((int)(((byte)(37)))));
            this.btnExpand.BorderWidth = 0F;
            this.btnExpand.ButtonColor = System.Drawing.Color.White;
            this.btnExpand.ButtonEnabled = true;
            this.btnExpand.ForeColor = System.Drawing.Color.Black;
            this.btnExpand.FromResource = true;
            this.btnExpand.Location = new System.Drawing.Point(6, 6);
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.ResourceNameBase = "expandButton";
            this.btnExpand.RoundSize = 6;
            this.btnExpand.Selected = false;
            this.btnExpand.Size = new System.Drawing.Size(48, 40);
            this.btnExpand.TabIndex = 16;
            this.btnExpand.HeadTextLabel = "";
            this.btnExpand.Click += new System.EventHandler(this.expandRequested);
            // 
            // btnCollapse
            // 
            this.btnCollapse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(21)))), ((int)(((byte)(5)))));
            this.btnCollapse.BlinkColor = System.Drawing.Color.Gainsboro;
            this.btnCollapse.BlinkEnabled = false;
            this.btnCollapse.BlinkInterval = 1000;
            this.btnCollapse.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(172)))), ((int)(((byte)(37)))));
            this.btnCollapse.BorderWidth = 0F;
            this.btnCollapse.ButtonColor = System.Drawing.Color.White;
            this.btnCollapse.ButtonEnabled = true;
            this.btnCollapse.ForeColor = System.Drawing.Color.Black;
            this.btnCollapse.FromResource = true;
            this.btnCollapse.Location = new System.Drawing.Point(6, 6);
            this.btnCollapse.Name = "btnCollapse";
            this.btnCollapse.ResourceNameBase = "collapseButton";
            this.btnCollapse.RoundSize = 6;
            this.btnCollapse.Selected = false;
            this.btnCollapse.Size = new System.Drawing.Size(48, 40);
            this.btnCollapse.TabIndex = 17;
            this.btnCollapse.HeadTextLabel = "";
            this.btnCollapse.Visible = false;
            this.btnCollapse.Click += new System.EventHandler(this.expandRequested);
            // 
            // BatteryStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.btnExpand);
            this.Controls.Add(this.btnCollapse);
            this.Name = "BatteryStatus";
            this.Size = new System.Drawing.Size(257, 128);
            this.ResumeLayout(false);

        }

        #endregion

        private SagoButton btnExpand;
        private SagoButton btnCollapse;
    }
}
