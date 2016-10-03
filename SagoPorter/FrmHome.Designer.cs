namespace SagoPorter
{
    partial class FrmHome
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
            this.tmrRefresh = new System.Windows.Forms.Timer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNetworkMessages = new Cntrls.SagoButton();
            this.graphicLabelCntrl1 = new Cntrls.GraphicLabelCntrl();
            this.btnAlarms = new Cntrls.SagoButton();
            this.alarmMessageCntrl = new Cntrls.AlarmMessageCntrl();
            this.sagoButton2 = new Cntrls.SagoButton();
            this.lblTest = new Cntrls.GraphicLabelCntrl();
            this.btnUnaMano = new Cntrls.SagoButton();
            this.statusBarCntrl = new Cntrls.StatusBarCntrl();
            this.bedInfoCntrl = new Cntrls.BedInfoCntrl();
            this.operatorCntrl = new Cntrls.OperatorCntrl();
            this.btnLento = new Cntrls.SagoButton();
            this.btnVeloce = new Cntrls.SagoButton();
            this.btnAbbPinza = new Cntrls.SagoButton();
            this.btnSollPinza = new Cntrls.SagoButton();
            this.btnChiudPinza = new Cntrls.SagoButton();
            this.btnApriPinza = new Cntrls.SagoButton();
            this.lblModInfo = new Cntrls.GraphicLabelCntrl();
            this.lblPinzaInfo = new Cntrls.GraphicLabelCntrl();
            this.btnMovimentoLibero = new Cntrls.SagoButton();
            this.controlloInMovimento1 = new SagoPorter.Controlli.ControlloInMovimento();
            this.batteryStatus = new Cntrls.BatteryStatus();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmrRefresh
            // 
            this.tmrRefresh.Interval = 60;
            this.tmrRefresh.Tick += new System.EventHandler(this.refreshTick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(234)))));
            this.panel1.Controls.Add(this.btnNetworkMessages);
            this.panel1.Controls.Add(this.graphicLabelCntrl1);
            this.panel1.Controls.Add(this.btnAlarms);
            this.panel1.Controls.Add(this.alarmMessageCntrl);
            this.panel1.Controls.Add(this.sagoButton2);
            this.panel1.Location = new System.Drawing.Point(0, 414);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 66);
            // 
            // btnNetworkMessages
            // 
            this.btnNetworkMessages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(234)))));
            this.btnNetworkMessages.BlinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnNetworkMessages.BlinkEnabled = false;
            this.btnNetworkMessages.BlinkInterval = 500;
            this.btnNetworkMessages.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(172)))), ((int)(((byte)(37)))));
            this.btnNetworkMessages.BorderWidth = 0F;
            this.btnNetworkMessages.ButtonColor = System.Drawing.Color.White;
            this.btnNetworkMessages.ButtonEnabled = true;
            this.btnNetworkMessages.Font = new System.Drawing.Font("Decker", 22F, System.Drawing.FontStyle.Regular);
            this.btnNetworkMessages.ForeColor = System.Drawing.Color.Black;
            this.btnNetworkMessages.FromResource = true;
            this.btnNetworkMessages.HeadTextLabel = "";
            this.btnNetworkMessages.Location = new System.Drawing.Point(59, 3);
            this.btnNetworkMessages.Name = "btnNetworkMessages";
            this.btnNetworkMessages.ResourceNameBase = "buttton68x60_messages";
            this.btnNetworkMessages.RoundSize = 6;
            this.btnNetworkMessages.Selected = false;
            this.btnNetworkMessages.Size = new System.Drawing.Size(50, 60);
            this.btnNetworkMessages.TabIndex = 22;
            this.btnNetworkMessages.TextLabel = "";
            this.btnNetworkMessages.TextMarginLeft = -6;
            // 
            // graphicLabelCntrl1
            // 
            this.graphicLabelCntrl1.AllineamentoOrizzontale = System.Drawing.StringAlignment.Center;
            this.graphicLabelCntrl1.AllineamentoVerticale = System.Drawing.StringAlignment.Center;
            this.graphicLabelCntrl1.BackGroundresourceName = "";
            this.graphicLabelCntrl1.BorderBottom = false;
            this.graphicLabelCntrl1.BorderLeft = false;
            this.graphicLabelCntrl1.BorderRight = false;
            this.graphicLabelCntrl1.BorderTop = false;
            this.graphicLabelCntrl1.BottomLineResourceName = "line800x4.bmp";
            this.graphicLabelCntrl1.ButtonEnabled = true;
            this.graphicLabelCntrl1.EnableDebug = false;
            this.graphicLabelCntrl1.LineColor = System.Drawing.Color.Empty;
            this.graphicLabelCntrl1.Location = new System.Drawing.Point(0, 0);
            this.graphicLabelCntrl1.Name = "graphicLabelCntrl1";
            this.graphicLabelCntrl1.Selected = false;
            this.graphicLabelCntrl1.Size = new System.Drawing.Size(800, 4);
            this.graphicLabelCntrl1.TabIndex = 21;
            this.graphicLabelCntrl1.TextLabel = "";
            // 
            // btnAlarms
            // 
            this.btnAlarms.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(234)))));
            this.btnAlarms.BlinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnAlarms.BlinkEnabled = false;
            this.btnAlarms.BlinkInterval = 500;
            this.btnAlarms.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(172)))), ((int)(((byte)(37)))));
            this.btnAlarms.BorderWidth = 0F;
            this.btnAlarms.ButtonColor = System.Drawing.Color.White;
            this.btnAlarms.ButtonEnabled = true;
            this.btnAlarms.Font = new System.Drawing.Font("Decker", 22F, System.Drawing.FontStyle.Regular);
            this.btnAlarms.ForeColor = System.Drawing.Color.Black;
            this.btnAlarms.FromResource = true;
            this.btnAlarms.HeadTextLabel = "";
            this.btnAlarms.Location = new System.Drawing.Point(3, 3);
            this.btnAlarms.Name = "btnAlarms";
            this.btnAlarms.ResourceNameBase = "buttton68x60_warning";
            this.btnAlarms.RoundSize = 6;
            this.btnAlarms.Selected = false;
            this.btnAlarms.Size = new System.Drawing.Size(50, 60);
            this.btnAlarms.TabIndex = 20;
            this.btnAlarms.TextLabel = "";
            this.btnAlarms.TextMarginLeft = -6;
            this.btnAlarms.Click += new System.EventHandler(this.showAlarmsBox);
            // 
            // alarmMessageCntrl
            // 
            this.alarmMessageCntrl.AlarmLevel = 0;
            this.alarmMessageCntrl.AlarmText = "ALLARME 999999";
            this.alarmMessageCntrl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(234)))));
            this.alarmMessageCntrl.ButtonEnabled = true;
            this.alarmMessageCntrl.Font = new System.Drawing.Font("Roboto", 28F, System.Drawing.FontStyle.Regular);
            this.alarmMessageCntrl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(41)))), ((int)(((byte)(38)))));
            this.alarmMessageCntrl.Location = new System.Drawing.Point(59, 8);
            this.alarmMessageCntrl.Name = "alarmMessageCntrl";
            this.alarmMessageCntrl.Selected = false;
            this.alarmMessageCntrl.Size = new System.Drawing.Size(682, 57);
            this.alarmMessageCntrl.TabIndex = 19;
            this.alarmMessageCntrl.TextLabel = "";
            // 
            // sagoButton2
            // 
            this.sagoButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(21)))), ((int)(((byte)(5)))));
            this.sagoButton2.BlinkColor = System.Drawing.Color.Gainsboro;
            this.sagoButton2.BlinkEnabled = false;
            this.sagoButton2.BlinkInterval = 500;
            this.sagoButton2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(172)))), ((int)(((byte)(37)))));
            this.sagoButton2.BorderWidth = 0F;
            this.sagoButton2.ButtonColor = System.Drawing.Color.White;
            this.sagoButton2.ButtonEnabled = true;
            this.sagoButton2.Font = new System.Drawing.Font("Decker", 22F, System.Drawing.FontStyle.Regular);
            this.sagoButton2.ForeColor = System.Drawing.Color.Black;
            this.sagoButton2.FromResource = true;
            this.sagoButton2.HeadTextLabel = "";
            this.sagoButton2.Location = new System.Drawing.Point(747, 3);
            this.sagoButton2.Name = "sagoButton2";
            this.sagoButton2.ResourceNameBase = "buttton68x60";
            this.sagoButton2.RoundSize = 6;
            this.sagoButton2.Selected = false;
            this.sagoButton2.Size = new System.Drawing.Size(50, 60);
            this.sagoButton2.TabIndex = 15;
            this.sagoButton2.TextLabel = "";
            this.sagoButton2.TextMarginLeft = -6;
            this.sagoButton2.Click += new System.EventHandler(this.onGoSpecialRequest);
            // 
            // lblTest
            // 
            this.lblTest.AllineamentoOrizzontale = System.Drawing.StringAlignment.Center;
            this.lblTest.AllineamentoVerticale = System.Drawing.StringAlignment.Center;
            this.lblTest.BackColor = System.Drawing.Color.Black;
            this.lblTest.BackGroundresourceName = "";
            this.lblTest.BorderBottom = true;
            this.lblTest.BorderLeft = false;
            this.lblTest.BorderRight = false;
            this.lblTest.BorderTop = false;
            this.lblTest.BottomLineResourceName = "";
            this.lblTest.ButtonEnabled = true;
            this.lblTest.EnableDebug = false;
            this.lblTest.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular);
            this.lblTest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(234)))));
            this.lblTest.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(172)))), ((int)(((byte)(37)))));
            this.lblTest.Location = new System.Drawing.Point(297, 373);
            this.lblTest.Name = "lblTest";
            this.lblTest.Selected = false;
            this.lblTest.Size = new System.Drawing.Size(203, 28);
            this.lblTest.TabIndex = 40;
            this.lblTest.TextLabel = "";
            this.lblTest.Visible = false;
            // 
            // btnUnaMano
            // 
            this.btnUnaMano.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(21)))), ((int)(((byte)(5)))));
            this.btnUnaMano.BlinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(252)))), ((int)(((byte)(117)))));
            this.btnUnaMano.BlinkEnabled = false;
            this.btnUnaMano.BlinkInterval = 500;
            this.btnUnaMano.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(172)))), ((int)(((byte)(37)))));
            this.btnUnaMano.BorderWidth = 4F;
            this.btnUnaMano.ButtonColor = System.Drawing.Color.White;
            this.btnUnaMano.ButtonEnabled = true;
            this.btnUnaMano.Font = new System.Drawing.Font("Roboto", 22F, System.Drawing.FontStyle.Regular);
            this.btnUnaMano.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(20)))), ((int)(((byte)(19)))));
            this.btnUnaMano.FromResource = true;
            this.btnUnaMano.HeadTextLabel = "";
            this.btnUnaMano.Location = new System.Drawing.Point(582, 130);
            this.btnUnaMano.Name = "btnUnaMano";
            this.btnUnaMano.ResourceNameBase = "buttton242x88BotLeftRounded";
            this.btnUnaMano.RoundSize = 16;
            this.btnUnaMano.Selected = false;
            this.btnUnaMano.Size = new System.Drawing.Size(242, 80);
            this.btnUnaMano.TabIndex = 38;
            this.btnUnaMano.TextLabel = "FrmHome.btnUnaMano.Text";
            this.btnUnaMano.TextMarginLeft = -6;
            this.btnUnaMano.Click += new System.EventHandler(this.unaManoRequested);
            // 
            // statusBarCntrl
            // 
            this.statusBarCntrl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.statusBarCntrl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(41)))), ((int)(((byte)(38)))));
            this.statusBarCntrl.ButtonEnabled = true;
            this.statusBarCntrl.FlagStatus = new bool[] {
        false,
        false,
        false};
            this.statusBarCntrl.Location = new System.Drawing.Point(589, 9);
            this.statusBarCntrl.Name = "statusBarCntrl";
            this.statusBarCntrl.Selected = false;
            this.statusBarCntrl.Size = new System.Drawing.Size(200, 25);
            this.statusBarCntrl.TabIndex = 34;
            this.statusBarCntrl.TextLabel = "";
            // 
            // bedInfoCntrl
            // 
            this.bedInfoCntrl.BackColor = System.Drawing.Color.Black;
            this.bedInfoCntrl.ButtonEnabled = true;
            this.bedInfoCntrl.Font = new System.Drawing.Font("Roboto", 22F, System.Drawing.FontStyle.Regular);
            this.bedInfoCntrl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(234)))));
            this.bedInfoCntrl.InfoLabel = "";
            this.bedInfoCntrl.Location = new System.Drawing.Point(224, 311);
            this.bedInfoCntrl.Name = "bedInfoCntrl";
            this.bedInfoCntrl.Selected = false;
            this.bedInfoCntrl.Size = new System.Drawing.Size(352, 100);
            this.bedInfoCntrl.TabIndex = 31;
            this.bedInfoCntrl.TextLabel = "";
            this.bedInfoCntrl.TitleFont = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular);
            this.bedInfoCntrl.TitleLabel = "";
            // 
            // operatorCntrl
            // 
            this.operatorCntrl.BackColor = System.Drawing.Color.Black;
            this.operatorCntrl.ButtonEnabled = true;
            this.operatorCntrl.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Regular);
            this.operatorCntrl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(234)))));
            this.operatorCntrl.IdOperatore = "0000000000";
            this.operatorCntrl.Location = new System.Drawing.Point(224, 143);
            this.operatorCntrl.Name = "operatorCntrl";
            this.operatorCntrl.NomeOperatore = "Paolo Rossi";
            this.operatorCntrl.Selected = false;
            this.operatorCntrl.Size = new System.Drawing.Size(352, 162);
            this.operatorCntrl.TabIndex = 30;
            this.operatorCntrl.TextLabel = "FrmHome.bedInfoCntrl.operatorCntrl";
            this.operatorCntrl.TitleFont = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular);
            this.operatorCntrl.ManageLogRequested += new System.EventHandler(this.manageLoginRequested);
            // 
            // btnLento
            // 
            this.btnLento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(21)))), ((int)(((byte)(5)))));
            this.btnLento.BlinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(252)))), ((int)(((byte)(117)))));
            this.btnLento.BlinkEnabled = false;
            this.btnLento.BlinkInterval = 500;
            this.btnLento.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(172)))), ((int)(((byte)(37)))));
            this.btnLento.BorderWidth = 4F;
            this.btnLento.ButtonColor = System.Drawing.Color.White;
            this.btnLento.ButtonEnabled = true;
            this.btnLento.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Regular);
            this.btnLento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(20)))), ((int)(((byte)(19)))));
            this.btnLento.FromResource = true;
            this.btnLento.HeadTextLabel = "";
            this.btnLento.Location = new System.Drawing.Point(602, 328);
            this.btnLento.Name = "btnLento";
            this.btnLento.ResourceNameBase = "moveSlowButton";
            this.btnLento.RoundSize = 16;
            this.btnLento.Selected = false;
            this.btnLento.Size = new System.Drawing.Size(242, 80);
            this.btnLento.TabIndex = 26;
            this.btnLento.TextLabel = "FrmHome.btnLento.Text";
            this.btnLento.TextMarginLeft = 0;
            this.btnLento.Click += new System.EventHandler(this.moveSlowRequested);
            // 
            // btnVeloce
            // 
            this.btnVeloce.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(21)))), ((int)(((byte)(5)))));
            this.btnVeloce.BlinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(252)))), ((int)(((byte)(117)))));
            this.btnVeloce.BlinkEnabled = false;
            this.btnVeloce.BlinkInterval = 500;
            this.btnVeloce.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(172)))), ((int)(((byte)(37)))));
            this.btnVeloce.BorderWidth = 4F;
            this.btnVeloce.ButtonColor = System.Drawing.Color.White;
            this.btnVeloce.ButtonEnabled = true;
            this.btnVeloce.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Regular);
            this.btnVeloce.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(20)))), ((int)(((byte)(19)))));
            this.btnVeloce.FromResource = true;
            this.btnVeloce.HeadTextLabel = "";
            this.btnVeloce.Location = new System.Drawing.Point(582, 245);
            this.btnVeloce.Name = "btnVeloce";
            this.btnVeloce.ResourceNameBase = "moveFastButton";
            this.btnVeloce.RoundSize = 16;
            this.btnVeloce.Selected = false;
            this.btnVeloce.Size = new System.Drawing.Size(242, 80);
            this.btnVeloce.TabIndex = 25;
            this.btnVeloce.TextLabel = "FrmHome.btnVeloce.Text";
            this.btnVeloce.TextMarginLeft = 0;
            this.btnVeloce.Click += new System.EventHandler(this.moveFastRequested);
            // 
            // btnAbbPinza
            // 
            this.btnAbbPinza.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(21)))), ((int)(((byte)(5)))));
            this.btnAbbPinza.BlinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(252)))), ((int)(((byte)(117)))));
            this.btnAbbPinza.BlinkEnabled = false;
            this.btnAbbPinza.BlinkInterval = 500;
            this.btnAbbPinza.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(172)))), ((int)(((byte)(37)))));
            this.btnAbbPinza.BorderWidth = 4F;
            this.btnAbbPinza.ButtonColor = System.Drawing.Color.White;
            this.btnAbbPinza.ButtonEnabled = true;
            this.btnAbbPinza.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular);
            this.btnAbbPinza.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(20)))), ((int)(((byte)(19)))));
            this.btnAbbPinza.FromResource = true;
            this.btnAbbPinza.HeadTextLabel = "";
            this.btnAbbPinza.Location = new System.Drawing.Point(-24, 320);
            this.btnAbbPinza.Name = "btnAbbPinza";
            this.btnAbbPinza.ResourceNameBase = "buttton242x88BotRightRounded";
            this.btnAbbPinza.RoundSize = 16;
            this.btnAbbPinza.Selected = false;
            this.btnAbbPinza.Size = new System.Drawing.Size(242, 88);
            this.btnAbbPinza.TabIndex = 24;
            this.btnAbbPinza.TextLabel = "FrmHome.btnAbbPinza.Text";
            this.btnAbbPinza.TextMarginLeft = 4;
            this.btnAbbPinza.MouseDown += new System.Windows.Forms.MouseEventHandler(this.abbassaPinzaRequested);
            this.btnAbbPinza.MouseUp += new System.Windows.Forms.MouseEventHandler(this.StopPinza);
            // 
            // btnSollPinza
            // 
            this.btnSollPinza.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(21)))), ((int)(((byte)(5)))));
            this.btnSollPinza.BlinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(252)))), ((int)(((byte)(117)))));
            this.btnSollPinza.BlinkEnabled = false;
            this.btnSollPinza.BlinkInterval = 500;
            this.btnSollPinza.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(172)))), ((int)(((byte)(37)))));
            this.btnSollPinza.BorderWidth = 4F;
            this.btnSollPinza.ButtonColor = System.Drawing.Color.White;
            this.btnSollPinza.ButtonEnabled = true;
            this.btnSollPinza.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular);
            this.btnSollPinza.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(20)))), ((int)(((byte)(19)))));
            this.btnSollPinza.FromResource = true;
            this.btnSollPinza.HeadTextLabel = "";
            this.btnSollPinza.Location = new System.Drawing.Point(-26, 229);
            this.btnSollPinza.Name = "btnSollPinza";
            this.btnSollPinza.ResourceNameBase = "buttton242x88NoRound";
            this.btnSollPinza.RoundSize = 16;
            this.btnSollPinza.Selected = false;
            this.btnSollPinza.Size = new System.Drawing.Size(242, 88);
            this.btnSollPinza.TabIndex = 23;
            this.btnSollPinza.TextLabel = "FrmHome.btnSollPinza.Text";
            this.btnSollPinza.TextMarginLeft = 0;
            this.btnSollPinza.MouseDown += new System.Windows.Forms.MouseEventHandler(this.alzaPinzaRequested);
            this.btnSollPinza.MouseUp += new System.Windows.Forms.MouseEventHandler(this.StopPinza);
            // 
            // btnChiudPinza
            // 
            this.btnChiudPinza.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(21)))), ((int)(((byte)(5)))));
            this.btnChiudPinza.BlinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(252)))), ((int)(((byte)(117)))));
            this.btnChiudPinza.BlinkEnabled = false;
            this.btnChiudPinza.BlinkInterval = 500;
            this.btnChiudPinza.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(172)))), ((int)(((byte)(37)))));
            this.btnChiudPinza.BorderWidth = 4F;
            this.btnChiudPinza.ButtonColor = System.Drawing.Color.White;
            this.btnChiudPinza.ButtonEnabled = true;
            this.btnChiudPinza.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular);
            this.btnChiudPinza.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(20)))), ((int)(((byte)(19)))));
            this.btnChiudPinza.FromResource = true;
            this.btnChiudPinza.HeadTextLabel = "";
            this.btnChiudPinza.Location = new System.Drawing.Point(-26, 138);
            this.btnChiudPinza.Name = "btnChiudPinza";
            this.btnChiudPinza.ResourceNameBase = "buttton242x88NoRound";
            this.btnChiudPinza.RoundSize = 16;
            this.btnChiudPinza.Selected = false;
            this.btnChiudPinza.Size = new System.Drawing.Size(242, 88);
            this.btnChiudPinza.TabIndex = 22;
            this.btnChiudPinza.TextLabel = "FrmHome.btnChiudPinza.Text";
            this.btnChiudPinza.TextMarginLeft = 0;
            this.btnChiudPinza.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chiudiPinzaRequested);
            this.btnChiudPinza.MouseUp += new System.Windows.Forms.MouseEventHandler(this.StopPinza);
            // 
            // btnApriPinza
            // 
            this.btnApriPinza.BackColor = System.Drawing.Color.White;
            this.btnApriPinza.BlinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(252)))), ((int)(((byte)(117)))));
            this.btnApriPinza.BlinkEnabled = false;
            this.btnApriPinza.BlinkInterval = 500;
            this.btnApriPinza.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(172)))), ((int)(((byte)(37)))));
            this.btnApriPinza.BorderWidth = 4F;
            this.btnApriPinza.ButtonColor = System.Drawing.Color.White;
            this.btnApriPinza.ButtonEnabled = true;
            this.btnApriPinza.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular);
            this.btnApriPinza.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(20)))), ((int)(((byte)(19)))));
            this.btnApriPinza.FromResource = true;
            this.btnApriPinza.HeadTextLabel = "";
            this.btnApriPinza.Location = new System.Drawing.Point(-24, 47);
            this.btnApriPinza.Name = "btnApriPinza";
            this.btnApriPinza.ResourceNameBase = "buttton242x88TopRounded";
            this.btnApriPinza.RoundSize = 16;
            this.btnApriPinza.Selected = false;
            this.btnApriPinza.Size = new System.Drawing.Size(242, 88);
            this.btnApriPinza.TabIndex = 21;
            this.btnApriPinza.TextLabel = "FrmHome.btnApriPinza.Text";
            this.btnApriPinza.TextMarginLeft = 0;
            this.btnApriPinza.MouseDown += new System.Windows.Forms.MouseEventHandler(this.apriPinzaRequested);
            this.btnApriPinza.MouseUp += new System.Windows.Forms.MouseEventHandler(this.StopPinza);
            // 
            // lblModInfo
            // 
            this.lblModInfo.AllineamentoOrizzontale = System.Drawing.StringAlignment.Center;
            this.lblModInfo.AllineamentoVerticale = System.Drawing.StringAlignment.Center;
            this.lblModInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(41)))), ((int)(((byte)(38)))));
            this.lblModInfo.BackGroundresourceName = "";
            this.lblModInfo.BorderBottom = true;
            this.lblModInfo.BorderLeft = false;
            this.lblModInfo.BorderRight = false;
            this.lblModInfo.BorderTop = false;
            this.lblModInfo.BottomLineResourceName = "";
            this.lblModInfo.ButtonEnabled = true;
            this.lblModInfo.EnableDebug = false;
            this.lblModInfo.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular);
            this.lblModInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(234)))));
            this.lblModInfo.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(172)))), ((int)(((byte)(37)))));
            this.lblModInfo.Location = new System.Drawing.Point(582, 210);
            this.lblModInfo.Name = "lblModInfo";
            this.lblModInfo.Selected = false;
            this.lblModInfo.Size = new System.Drawing.Size(242, 35);
            this.lblModInfo.TabIndex = 6;
            this.lblModInfo.TextLabel = "FrmHome.lblModInfo.Text";
            // 
            // lblPinzaInfo
            // 
            this.lblPinzaInfo.AllineamentoOrizzontale = System.Drawing.StringAlignment.Center;
            this.lblPinzaInfo.AllineamentoVerticale = System.Drawing.StringAlignment.Center;
            this.lblPinzaInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(41)))), ((int)(((byte)(38)))));
            this.lblPinzaInfo.BackGroundresourceName = "";
            this.lblPinzaInfo.BorderBottom = true;
            this.lblPinzaInfo.BorderLeft = false;
            this.lblPinzaInfo.BorderRight = false;
            this.lblPinzaInfo.BorderTop = false;
            this.lblPinzaInfo.BottomLineResourceName = "";
            this.lblPinzaInfo.ButtonEnabled = true;
            this.lblPinzaInfo.EnableDebug = false;
            this.lblPinzaInfo.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular);
            this.lblPinzaInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(234)))));
            this.lblPinzaInfo.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(172)))), ((int)(((byte)(37)))));
            this.lblPinzaInfo.Location = new System.Drawing.Point(3, 9);
            this.lblPinzaInfo.Name = "lblPinzaInfo";
            this.lblPinzaInfo.Selected = false;
            this.lblPinzaInfo.Size = new System.Drawing.Size(203, 35);
            this.lblPinzaInfo.TabIndex = 4;
            this.lblPinzaInfo.TextLabel = "FrmHome.lblPinzaInfo.Text";
            // 
            // btnMovimentoLibero
            // 
            this.btnMovimentoLibero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(21)))), ((int)(((byte)(5)))));
            this.btnMovimentoLibero.BlinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(252)))), ((int)(((byte)(117)))));
            this.btnMovimentoLibero.BlinkEnabled = false;
            this.btnMovimentoLibero.BlinkInterval = 500;
            this.btnMovimentoLibero.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(172)))), ((int)(((byte)(37)))));
            this.btnMovimentoLibero.BorderWidth = 4F;
            this.btnMovimentoLibero.ButtonColor = System.Drawing.Color.White;
            this.btnMovimentoLibero.ButtonEnabled = true;
            this.btnMovimentoLibero.Font = new System.Drawing.Font("Roboto", 22F, System.Drawing.FontStyle.Regular);
            this.btnMovimentoLibero.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(20)))), ((int)(((byte)(19)))));
            this.btnMovimentoLibero.FromResource = true;
            this.btnMovimentoLibero.HeadTextLabel = "";
            this.btnMovimentoLibero.Location = new System.Drawing.Point(582, 47);
            this.btnMovimentoLibero.Name = "btnMovimentoLibero";
            this.btnMovimentoLibero.ResourceNameBase = "buttton242x88TopLeftRounded";
            this.btnMovimentoLibero.RoundSize = 16;
            this.btnMovimentoLibero.Selected = false;
            this.btnMovimentoLibero.Size = new System.Drawing.Size(242, 80);
            this.btnMovimentoLibero.TabIndex = 2;
            this.btnMovimentoLibero.TextLabel = "FrmHome.btnMovimentoLibero.Text";
            this.btnMovimentoLibero.TextMarginLeft = -6;
            this.btnMovimentoLibero.Click += new System.EventHandler(this.freeMovingRequested);
            // 
            // controlloInMovimento1
            // 
            this.controlloInMovimento1.Location = new System.Drawing.Point(-24, 47);
            this.controlloInMovimento1.Name = "controlloInMovimento1";
            this.controlloInMovimento1.Size = new System.Drawing.Size(242, 361);
            this.controlloInMovimento1.TabIndex = 35;
            this.controlloInMovimento1.Visible = false;
            // 
            // batteryStatus
            // 
            this.batteryStatus.BackColor = System.Drawing.Color.Black;
            this.batteryStatus.Battery1Percentage = 0;
            this.batteryStatus.Battery1Voltage = 0F;
            this.batteryStatus.Battery2Percentage = 0;
            this.batteryStatus.Battery2Voltage = 0F;
            this.batteryStatus.BatteryCharging = false;
            this.batteryStatus.BatteryPercentage = 100;
            this.batteryStatus.BlinkColor = System.Drawing.Color.Transparent;
            this.batteryStatus.BlinkEnabled = false;
            this.batteryStatus.BlinkInterval = 500;
            this.batteryStatus.BorderColor = System.Drawing.Color.Transparent;
            this.batteryStatus.BorderWidth = 1F;
            this.batteryStatus.ButtonEnabled = true;
            this.batteryStatus.CollapsedHeight = 128;
            this.batteryStatus.ExpandedHeight = 296;
            this.batteryStatus.Font = new System.Drawing.Font("Roboto", 32F, System.Drawing.FontStyle.Regular);
            this.batteryStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(234)))));
            this.batteryStatus.Location = new System.Drawing.Point(224, 9);
            this.batteryStatus.Name = "batteryStatus";
            this.batteryStatus.RoundSize = 0;
            this.batteryStatus.Selected = false;
            this.batteryStatus.Size = new System.Drawing.Size(352, 128);
            this.batteryStatus.TabIndex = 28;
            this.batteryStatus.TextLabel = "FrmHome.bedInfoCntrl.batteryStatus";
            this.batteryStatus.WorkTime = System.TimeSpan.Parse("00:00:00");
            // 
            // FrmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(41)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.ControlBox = false;
            this.Controls.Add(this.lblTest);
            this.Controls.Add(this.btnUnaMano);
            this.Controls.Add(this.statusBarCntrl);
            this.Controls.Add(this.bedInfoCntrl);
            this.Controls.Add(this.operatorCntrl);
            this.Controls.Add(this.btnLento);
            this.Controls.Add(this.btnVeloce);
            this.Controls.Add(this.btnAbbPinza);
            this.Controls.Add(this.btnSollPinza);
            this.Controls.Add(this.btnChiudPinza);
            this.Controls.Add(this.btnApriPinza);
            this.Controls.Add(this.lblModInfo);
            this.Controls.Add(this.lblPinzaInfo);
            this.Controls.Add(this.btnMovimentoLibero);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.controlloInMovimento1);
            this.Controls.Add(this.batteryStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmHome";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion 
 
        private Cntrls.SagoButton btnMovimentoLibero; 
        private Cntrls.GraphicLabelCntrl lblPinzaInfo;
        private Cntrls.GraphicLabelCntrl lblModInfo;
        private Cntrls.AlarmMessageCntrl alarmMessageCntrl;
        private Cntrls.SagoButton btnApriPinza;
        private Cntrls.SagoButton btnChiudPinza;
        private Cntrls.SagoButton btnSollPinza;
        private Cntrls.SagoButton btnAbbPinza;
        private Cntrls.SagoButton btnVeloce;
        private Cntrls.SagoButton btnLento;
        private Cntrls.BatteryStatus batteryStatus;
        private System.Windows.Forms.Timer tmrRefresh;
        private Cntrls.OperatorCntrl operatorCntrl;
        private Cntrls.BedInfoCntrl bedInfoCntrl;
        private System.Windows.Forms.Panel panel1;
        private Cntrls.GraphicLabelCntrl graphicLabelCntrl1;
        private Cntrls.SagoButton btnAlarms;
        private Cntrls.SagoButton sagoButton2;
        private Cntrls.StatusBarCntrl statusBarCntrl;
        private SagoPorter.Controlli.ControlloInMovimento controlloInMovimento1;
        private Cntrls.SagoButton btnUnaMano;
        private Cntrls.SagoButton btnNetworkMessages;
        private Cntrls.GraphicLabelCntrl lblTest; 
    }
}

