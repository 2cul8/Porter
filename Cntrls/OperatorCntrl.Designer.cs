namespace Cntrls
{
    partial class OperatorCntrl
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
            this.btnManageLogin = new Cntrls.SagoButton();
            this.btnShowStats = new Cntrls.SagoButton();
            this.SuspendLayout();
            // 
            // btnManageLogin
            // 
            this.btnManageLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(21)))), ((int)(((byte)(5)))));
            this.btnManageLogin.BlinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(252)))), ((int)(((byte)(117)))));
            this.btnManageLogin.BlinkEnabled = false;
            this.btnManageLogin.BlinkInterval = 500;
            this.btnManageLogin.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(172)))), ((int)(((byte)(37)))));
            this.btnManageLogin.BorderWidth = 4F;
            this.btnManageLogin.ButtonColor = System.Drawing.Color.White;
            this.btnManageLogin.ButtonEnabled = true;
            this.btnManageLogin.Font = new System.Drawing.Font("Roboto", 22F, System.Drawing.FontStyle.Regular);
            this.btnManageLogin.ForeColor = System.Drawing.Color.Black;
            this.btnManageLogin.FromResource = true;
            this.btnManageLogin.Location = new System.Drawing.Point(9, 9);
            this.btnManageLogin.Name = "btnManageLogin";
            this.btnManageLogin.ResourceNameBase = "loginButton";
            this.btnManageLogin.RoundSize = 16;
            this.btnManageLogin.Selected = false;
            this.btnManageLogin.Size = new System.Drawing.Size(48, 40);
            this.btnManageLogin.TabIndex = 3;
            this.btnManageLogin.TextMarginLeft = 0;
            this.btnManageLogin.HeadTextLabel = "";
            this.btnManageLogin.Click += new System.EventHandler(this.manageLogRequested);
            // 
            // btnShowStats
            // 
            this.btnShowStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(21)))), ((int)(((byte)(5)))));
            this.btnShowStats.BlinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(252)))), ((int)(((byte)(117)))));
            this.btnShowStats.BlinkEnabled = false;
            this.btnShowStats.BlinkInterval = 500;
            this.btnShowStats.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(172)))), ((int)(((byte)(37)))));
            this.btnShowStats.BorderWidth = 4F;
            this.btnShowStats.ButtonColor = System.Drawing.Color.White;
            this.btnShowStats.ButtonEnabled = true;
            this.btnShowStats.Font = new System.Drawing.Font("Roboto", 22F, System.Drawing.FontStyle.Regular);
            this.btnShowStats.ForeColor = System.Drawing.Color.Black;
            this.btnShowStats.FromResource = true;
            this.btnShowStats.Location = new System.Drawing.Point(295, 9);
            this.btnShowStats.Name = "btnShowStats";
            this.btnShowStats.ResourceNameBase = "userStatsButton";
            this.btnShowStats.RoundSize = 16;
            this.btnShowStats.Selected = false;
            this.btnShowStats.Size = new System.Drawing.Size(48, 40);
            this.btnShowStats.TabIndex = 4;
            this.btnShowStats.TextMarginLeft = 0;
            this.btnShowStats.HeadTextLabel = "";
            // 
            // OperatorCntrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.btnShowStats);
            this.Controls.Add(this.btnManageLogin);
            this.Name = "OperatorCntrl";
            this.Size = new System.Drawing.Size(352, 162);
            this.ResumeLayout(false);

        }

        #endregion

        private SagoButton btnManageLogin;
        private SagoButton btnShowStats;

    }
}
