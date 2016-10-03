namespace Cntrls
{
    partial class LedLine
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
            this.tmrRefresh = new System.Windows.Forms.Timer();
            this.statusLeds13 = new Cntrls.StatusLeds();
            this.statusLeds11 = new Cntrls.StatusLeds();
            this.statusLeds12 = new Cntrls.StatusLeds();
            this.statusLeds9 = new Cntrls.StatusLeds();
            this.statusLeds10 = new Cntrls.StatusLeds();
            this.statusLeds7 = new Cntrls.StatusLeds();
            this.statusLeds8 = new Cntrls.StatusLeds();
            this.statusLeds5 = new Cntrls.StatusLeds();
            this.statusLeds6 = new Cntrls.StatusLeds();
            this.statusLeds3 = new Cntrls.StatusLeds();
            this.statusLeds4 = new Cntrls.StatusLeds();
            this.statusLeds2 = new Cntrls.StatusLeds();
            this.statusLeds1 = new Cntrls.StatusLeds();
            this.SuspendLayout();
            // 
            // tmrRefresh
            // 
            this.tmrRefresh.Tick += new System.EventHandler(this.refresh);
            // 
            // statusLeds13
            // 
            this.statusLeds13.BorderColor = System.Drawing.Color.Black;
            this.statusLeds13.Location = new System.Drawing.Point(315, 3);
            this.statusLeds13.Name = "statusLeds13";
            this.statusLeds13.Size = new System.Drawing.Size(20, 20);
            this.statusLeds13.TabIndex = 12;
            // 
            // statusLeds11
            // 
            this.statusLeds11.BorderColor = System.Drawing.Color.Black;
            this.statusLeds11.Location = new System.Drawing.Point(263, 3);
            this.statusLeds11.Name = "statusLeds11";
            this.statusLeds11.Size = new System.Drawing.Size(20, 20);
            this.statusLeds11.TabIndex = 11;
            // 
            // statusLeds12
            // 
            this.statusLeds12.BorderColor = System.Drawing.Color.Black;
            this.statusLeds12.Location = new System.Drawing.Point(289, 3);
            this.statusLeds12.Name = "statusLeds12";
            this.statusLeds12.Size = new System.Drawing.Size(20, 20);
            this.statusLeds12.TabIndex = 10;
            // 
            // statusLeds9
            // 
            this.statusLeds9.BorderColor = System.Drawing.Color.Black;
            this.statusLeds9.Location = new System.Drawing.Point(211, 3);
            this.statusLeds9.Name = "statusLeds9";
            this.statusLeds9.Size = new System.Drawing.Size(20, 20);
            this.statusLeds9.TabIndex = 9;
            // 
            // statusLeds10
            // 
            this.statusLeds10.BorderColor = System.Drawing.Color.Black;
            this.statusLeds10.Location = new System.Drawing.Point(237, 3);
            this.statusLeds10.Name = "statusLeds10";
            this.statusLeds10.Size = new System.Drawing.Size(20, 20);
            this.statusLeds10.TabIndex = 8;
            // 
            // statusLeds7
            // 
            this.statusLeds7.BorderColor = System.Drawing.Color.Black;
            this.statusLeds7.Location = new System.Drawing.Point(159, 3);
            this.statusLeds7.Name = "statusLeds7";
            this.statusLeds7.Size = new System.Drawing.Size(20, 20);
            this.statusLeds7.TabIndex = 7;
            // 
            // statusLeds8
            // 
            this.statusLeds8.BorderColor = System.Drawing.Color.Black;
            this.statusLeds8.Location = new System.Drawing.Point(185, 3);
            this.statusLeds8.Name = "statusLeds8";
            this.statusLeds8.Size = new System.Drawing.Size(20, 20);
            this.statusLeds8.TabIndex = 6;
            // 
            // statusLeds5
            // 
            this.statusLeds5.BorderColor = System.Drawing.Color.Black;
            this.statusLeds5.Location = new System.Drawing.Point(107, 3);
            this.statusLeds5.Name = "statusLeds5";
            this.statusLeds5.Size = new System.Drawing.Size(20, 20);
            this.statusLeds5.TabIndex = 5;
            // 
            // statusLeds6
            // 
            this.statusLeds6.BorderColor = System.Drawing.Color.Black;
            this.statusLeds6.Location = new System.Drawing.Point(133, 3);
            this.statusLeds6.Name = "statusLeds6";
            this.statusLeds6.Size = new System.Drawing.Size(20, 20);
            this.statusLeds6.TabIndex = 4;
            // 
            // statusLeds3
            // 
            this.statusLeds3.BorderColor = System.Drawing.Color.Black;
            this.statusLeds3.Location = new System.Drawing.Point(55, 3);
            this.statusLeds3.Name = "statusLeds3";
            this.statusLeds3.Size = new System.Drawing.Size(20, 20);
            this.statusLeds3.TabIndex = 3;
            // 
            // statusLeds4
            // 
            this.statusLeds4.BorderColor = System.Drawing.Color.Black;
            this.statusLeds4.Location = new System.Drawing.Point(81, 3);
            this.statusLeds4.Name = "statusLeds4";
            this.statusLeds4.Size = new System.Drawing.Size(20, 20);
            this.statusLeds4.TabIndex = 2;
            // 
            // statusLeds2
            // 
            this.statusLeds2.BorderColor = System.Drawing.Color.Black;
            this.statusLeds2.Location = new System.Drawing.Point(29, 3);
            this.statusLeds2.Name = "statusLeds2";
            this.statusLeds2.Size = new System.Drawing.Size(20, 20);
            this.statusLeds2.TabIndex = 1;
            // 
            // statusLeds1
            // 
            this.statusLeds1.BorderColor = System.Drawing.Color.Black;
            this.statusLeds1.Location = new System.Drawing.Point(3, 3);
            this.statusLeds1.Name = "statusLeds1";
            this.statusLeds1.Size = new System.Drawing.Size(20, 20);
            this.statusLeds1.TabIndex = 0;
            // 
            // LedLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.statusLeds13);
            this.Controls.Add(this.statusLeds11);
            this.Controls.Add(this.statusLeds12);
            this.Controls.Add(this.statusLeds9);
            this.Controls.Add(this.statusLeds10);
            this.Controls.Add(this.statusLeds7);
            this.Controls.Add(this.statusLeds8);
            this.Controls.Add(this.statusLeds5);
            this.Controls.Add(this.statusLeds6);
            this.Controls.Add(this.statusLeds3);
            this.Controls.Add(this.statusLeds4);
            this.Controls.Add(this.statusLeds2);
            this.Controls.Add(this.statusLeds1);
            this.Name = "LedLine";
            this.Size = new System.Drawing.Size(338, 26);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrRefresh;
        private StatusLeds statusLeds1;
        private StatusLeds statusLeds2;
        private StatusLeds statusLeds3;
        private StatusLeds statusLeds4;
        private StatusLeds statusLeds5;
        private StatusLeds statusLeds6;
        private StatusLeds statusLeds7;
        private StatusLeds statusLeds8;
        private StatusLeds statusLeds9;
        private StatusLeds statusLeds10;
        private StatusLeds statusLeds11;
        private StatusLeds statusLeds12;
        private StatusLeds statusLeds13;
    }
}
