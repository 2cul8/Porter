namespace SagoPorter
{
    partial class FrmLoader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLoader));
            this.tmrFrmLoaded = new System.Windows.Forms.Timer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.spinnerCntrl1 = new Cntrls.SpinnerCntrl();
            this.lblMessages = new Cntrls.GraphicLabelCntrl();
            this.lblStatus = new Cntrls.GraphicLabelCntrl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmrFrmLoaded
            // 
            this.tmrFrmLoaded.Interval = 1000;
            this.tmrFrmLoaded.Tick += new System.EventHandler(this.onFrmLoadedTick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(649, 168);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(151, 119);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.White;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(0, 308);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(800, 192);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(800, 192);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.spinnerCntrl1);
            this.panel1.Location = new System.Drawing.Point(0, 168);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(128, 119);
            // 
            // spinnerCntrl1
            // 
            this.spinnerCntrl1.BackColor = System.Drawing.Color.White;
            this.spinnerCntrl1.ButtonEnabled = true;
            this.spinnerCntrl1.Location = new System.Drawing.Point(32, 27);
            this.spinnerCntrl1.Name = "spinnerCntrl1";
            this.spinnerCntrl1.Selected = false;
            this.spinnerCntrl1.Size = new System.Drawing.Size(64, 64);
            this.spinnerCntrl1.SpinnerFramesDir = "SpinnerFramesBlack";
            this.spinnerCntrl1.SpinOn = true;
            this.spinnerCntrl1.TabIndex = 5;
            // 
            // lblMessages
            // 
            this.lblMessages.AllineamentoOrizzontale = System.Drawing.StringAlignment.Center;
            this.lblMessages.AllineamentoVerticale = System.Drawing.StringAlignment.Center;
            this.lblMessages.BackColor = System.Drawing.Color.White;
            this.lblMessages.BackGroundresourceName = "";
            this.lblMessages.BorderBottom = false;
            this.lblMessages.BorderLeft = false;
            this.lblMessages.BorderRight = false;
            this.lblMessages.BorderTop = false;
            this.lblMessages.BottomLineResourceName = "";
            this.lblMessages.ButtonEnabled = true;
            this.lblMessages.EnableDebug = false;
            this.lblMessages.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular);
            this.lblMessages.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(120)))), ((int)(((byte)(123)))));
            this.lblMessages.LineColor = System.Drawing.Color.Empty;
            this.lblMessages.Location = new System.Drawing.Point(134, 241);
            this.lblMessages.Name = "lblMessages";
            this.lblMessages.Selected = false;
            this.lblMessages.Size = new System.Drawing.Size(509, 46);
            this.lblMessages.TabIndex = 2;
            this.lblMessages.TextLabel = "";
            // 
            // lblStatus
            // 
            this.lblStatus.AllineamentoOrizzontale = System.Drawing.StringAlignment.Center;
            this.lblStatus.AllineamentoVerticale = System.Drawing.StringAlignment.Center;
            this.lblStatus.BackColor = System.Drawing.Color.White;
            this.lblStatus.BackGroundresourceName = "";
            this.lblStatus.BorderBottom = false;
            this.lblStatus.BorderLeft = false;
            this.lblStatus.BorderRight = false;
            this.lblStatus.BorderTop = false;
            this.lblStatus.BottomLineResourceName = "";
            this.lblStatus.ButtonEnabled = true;
            this.lblStatus.EnableDebug = false;
            this.lblStatus.Font = new System.Drawing.Font("Roboto", 28F, System.Drawing.FontStyle.Regular);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(120)))), ((int)(((byte)(123)))));
            this.lblStatus.LineColor = System.Drawing.Color.Empty;
            this.lblStatus.Location = new System.Drawing.Point(134, 168);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Selected = false;
            this.lblStatus.Size = new System.Drawing.Size(509, 67);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.TextLabel = "";
            // 
            // FrmLoader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblMessages);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLoader";
            this.Text = "FrmLoader";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Cntrls.GraphicLabelCntrl lblStatus;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer tmrFrmLoaded;
        private Cntrls.GraphicLabelCntrl lblMessages;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private Cntrls.SpinnerCntrl spinnerCntrl1;
        private System.Windows.Forms.Panel panel1;
    }
}