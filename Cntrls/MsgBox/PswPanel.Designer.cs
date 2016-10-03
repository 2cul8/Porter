namespace Cntrls 
{
    partial class PswPanel
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
            this.inputButton1 = new Cntrls.InputButton();
            this.btnSetFresIndex = new Cntrls.InputButton();
            this.lblTitle = new Cntrls.GraphicLabelCntrl();
            this.lblPsw = new Cntrls.GraphicLabelCntrl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputButton1
            // 
            this.inputButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.inputButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.inputButton1.BackColorOnMouseDown = System.Drawing.Color.Gray;
            this.inputButton1.BorderColor = System.Drawing.Color.Silver;
            this.inputButton1.BorderSize = 2;
            this.inputButton1.BtnColor = System.Drawing.Color.Gainsboro;
            this.inputButton1.BtnFont = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular);
            this.inputButton1.BtnForeColor = System.Drawing.Color.DarkGray;
            this.inputButton1.BtnText = "Annulla";
            this.inputButton1.Caption = "Esc";
            this.inputButton1.CaptionFont = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular);
            this.inputButton1.DownTextColor = System.Drawing.Color.Black;
            this.inputButton1.ForeColor = System.Drawing.Color.Gainsboro;
            this.inputButton1.InternalBorderColor = System.Drawing.Color.Gray;
            this.inputButton1.LampColor = System.Drawing.Color.Red;
            this.inputButton1.Location = new System.Drawing.Point(179, 99);
            this.inputButton1.Name = "inputButton1";
            this.inputButton1.Size = new System.Drawing.Size(175, 61);
            this.inputButton1.TabIndex = 82;
            this.inputButton1.TestoInRilievo = true;
            this.inputButton1.Click += new System.EventHandler(this.EscRequest);
            // 
            // btnSetFresIndex
            // 
            this.btnSetFresIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSetFresIndex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnSetFresIndex.BackColorOnMouseDown = System.Drawing.Color.Gray;
            this.btnSetFresIndex.BorderColor = System.Drawing.Color.Silver;
            this.btnSetFresIndex.BorderSize = 2;
            this.btnSetFresIndex.BtnColor = System.Drawing.Color.Gainsboro;
            this.btnSetFresIndex.BtnFont = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular);
            this.btnSetFresIndex.BtnForeColor = System.Drawing.Color.DarkGray;
            this.btnSetFresIndex.BtnText = "Ok";
            this.btnSetFresIndex.Caption = "Enter";
            this.btnSetFresIndex.CaptionFont = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular);
            this.btnSetFresIndex.DownTextColor = System.Drawing.Color.Black;
            this.btnSetFresIndex.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnSetFresIndex.InternalBorderColor = System.Drawing.Color.Gray;
            this.btnSetFresIndex.LampColor = System.Drawing.Color.Red;
            this.btnSetFresIndex.Location = new System.Drawing.Point(0, 99);
            this.btnSetFresIndex.Name = "btnSetFresIndex";
            this.btnSetFresIndex.Size = new System.Drawing.Size(175, 61);
            this.btnSetFresIndex.TabIndex = 81;
            this.btnSetFresIndex.TestoInRilievo = true;
            this.btnSetFresIndex.Click += new System.EventHandler(this.OkRequest);
            // 
            // lblTitle
            // 
            this.lblTitle.AllineamentoOrizzontale = System.Drawing.StringAlignment.Center;
            this.lblTitle.AllineamentoVerticale = System.Drawing.StringAlignment.Center;
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.BackColor = System.Drawing.Color.Black;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(354, 33);
            this.lblTitle.TabIndex = 12;
            // 
            // lblPsw
            // 
            this.lblPsw.AllineamentoOrizzontale = System.Drawing.StringAlignment.Center;
            this.lblPsw.AllineamentoVerticale = System.Drawing.StringAlignment.Center;
            this.lblPsw.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPsw.BackColor = System.Drawing.Color.Black;
            this.lblPsw.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular);
            this.lblPsw.ForeColor = System.Drawing.Color.White;
            this.lblPsw.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPsw.Location = new System.Drawing.Point(0, 36);
            this.lblPsw.Name = "lblPsw";
            this.lblPsw.Size = new System.Drawing.Size(354, 60);
            this.lblPsw.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.inputButton1);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.btnSetFresIndex);
            this.panel1.Controls.Add(this.lblPsw);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(354, 160);
            // 
            // PswPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(360, 166);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PswPanel";
            this.Text = "PswPanel";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GraphicLabelCntrl lblPsw;
        private GraphicLabelCntrl lblTitle;
        private InputButton btnSetFresIndex;
        private InputButton inputButton1;
        private System.Windows.Forms.Panel panel1;
    }
}