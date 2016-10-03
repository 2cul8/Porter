using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using PorterProto;
using Cntrls.Boxes;
using RfidManager;
using UserManagement;
using NetManagement; 
using LocationManagement;
using Resources;

namespace SagoPorter
{
    public partial class FrmHome : Form
    { 
        private FrmSpecial specialFrm;
        private FrmLocation locationFrm;
        private FrmMessages messagesBox;
        private Point lastCursorPoint = Point.Empty;

        private static int timeOutCount = 0;
        
        public FrmHome()
        {   
            InitializeComponent(); 

            bool[] statusFlag = new bool[8] { false, false, false, false, false, false, false, false };

            setStatusFlagBitmaps();
            statusBarCntrl.FlagStatus = statusFlag;
        }

        internal void initSpecialForm()
        {
            specialFrm = new FrmSpecial();
            specialFrm.HideSpecialRequested += new EventHandler(onSpeciaHided);

            locationFrm = new FrmLocation();
            messagesBox = new FrmMessages();
        }

        public new void Show()
        { 
            DeviceEvents.OnDeviceConnected += new EventHandler(onDeviceConnected);
            DeviceEvents.OnDeviceConnectionStarted += new EventHandler(onDeviceConnectionStarted);
            DeviceEvents.OnDeviceDisconnected += new EventHandler(onDeviceDisconnected);
            DeviceEvents.OnDeviceError += new DeviceErrorEventHandler(onDeviceError);
             
            NetworkManager.NewMessage += new NetworkMessageEventHandler(onNetworkMessage);

            manageLogin();

            tmrRefresh.Enabled = true;
            PowerManagement.StartSuspendDaemon();

            base.Show();
        }

        public new void Close()
        {
            try
            {
                DeviceEvents.OnDeviceConnected -= new EventHandler(onDeviceConnected);
                DeviceEvents.OnDeviceDisconnected -= new EventHandler(onDeviceDisconnected);
                DeviceEvents.OnDeviceError -= new DeviceErrorEventHandler(onDeviceError);
                DeviceEvents.OnDeviceConnectionStarted -= new EventHandler(onDeviceConnectionStarted);
                 
                tmrRefresh.Enabled = false;

                LettoManager.StopListening();

                DeviceInterface.ChiudiComunicazione();
                specialFrm.Close();
            }
            catch
            { }

            base.Close();
        }

        internal void Minimize()
        { }

        private void setStatusFlagBitmaps()
        { 
            Bitmap[] statusBarBitmapsOff = new Bitmap[8];

            statusBarBitmapsOff[0] = (Bitmap)Resources.Resources.GetResource("alarm_off.bmp", Resources.ResourceType.Image);
            statusBarBitmapsOff[1] = (Bitmap)Resources.Resources.GetResource("pinze_off.bmp", Resources.ResourceType.Image);
            statusBarBitmapsOff[2] = (Bitmap)Resources.Resources.GetResource("letto_off.bmp", Resources.ResourceType.Image);
            statusBarBitmapsOff[3] = (Bitmap)Resources.Resources.GetResource("right_hand.bmp", Resources.ResourceType.Image);
            statusBarBitmapsOff[4] = (Bitmap)Resources.Resources.GetResource("left_hand.bmp", Resources.ResourceType.Image);
            statusBarBitmapsOff[5] = (Bitmap)Resources.Resources.GetResource("moving_off.bmp", Resources.ResourceType.Image);
            statusBarBitmapsOff[6] = (Bitmap)Resources.Resources.GetResource("free_moving_off.bmp", Resources.ResourceType.Image);
            statusBarBitmapsOff[7] = (Bitmap)Resources.Resources.GetResource("wifi_off.bmp", Resources.ResourceType.Image);

            Bitmap[] statusBarBitmapsOn = new Bitmap[8];

            statusBarBitmapsOn[0] = (Bitmap)Resources.Resources.GetResource("alarm_on.bmp", Resources.ResourceType.Image);
            statusBarBitmapsOn[1] = (Bitmap)Resources.Resources.GetResource("pinze_on.bmp", Resources.ResourceType.Image);
            statusBarBitmapsOn[2] = (Bitmap)Resources.Resources.GetResource("letto_on.bmp", Resources.ResourceType.Image);
            statusBarBitmapsOn[3] = (Bitmap)Resources.Resources.GetResource(DeviceStatusFlag.UnaMano ? "right_hand_yellow.bmp" : "right_hand_present.bmp", Resources.ResourceType.Image);
            statusBarBitmapsOn[4] = (Bitmap)Resources.Resources.GetResource(DeviceStatusFlag.UnaMano ? "left_hand_yellow.bmp" : "left_hand_present.bmp", Resources.ResourceType.Image);
            statusBarBitmapsOn[5] = (Bitmap)Resources.Resources.GetResource("moving_on.bmp", Resources.ResourceType.Image);
            statusBarBitmapsOn[6] = (Bitmap)Resources.Resources.GetResource("free_moving_on.bmp", Resources.ResourceType.Image);
            statusBarBitmapsOn[7] = (Bitmap)Resources.Resources.GetResource("wifi_on.bmp", Resources.ResourceType.Image);

            statusBarCntrl.SetBitmaps(statusBarBitmapsOff, statusBarBitmapsOn);
        }

        private void manageLogin()
        {
            bool userLogged = false;

            string userName = string.Empty;
            string password = string.Empty;

            User currentUser = User.Empty;

            while (!userLogged)
            {
                if (string.IsNullOrEmpty(userName))
                {
                    if (string.IsNullOrEmpty(userName = Boxes.RequestId("FrmHome.Messages.001")))
                        continue;

                    currentUser = UserManager.UserIdNameExist(userName);

                    if (currentUser.Equals(User.Empty))
                    {
                        Boxes.ShowMessageDialog("Message.1", "FrmHome.Messages.002", frmMessageBox.MessageLevel.Warning, frmMessageBox.BoxResponse.Ok);
                        userName = string.Empty;
                        continue;
                    }
                } 

                UserManager.LoginUser(currentUser);
                userLogged = true;
            }
        }

        private void ManageLogout()
        {
            UserManager.LogoutUSer();
        }

        private void onNetworkMessage(object sender, NetworkMessageEventArgs e)
        {
            if (InvokeRequired)
                Invoke(new NetworkMessageEventHandler(onNetworkMessage), new object[] { sender, e });
            else
                switch (e.Message.MessageType)
                {
                    case 0: // Messaggio normale
                        //Boxes.ShowMessageDialog(e.Message.SourceName, e.Message.Message, frmMessageBox.MessageLevel.Error, frmMessageBox.BoxResponse.Ok);
                        break;

                    case 1: // Richiesta posizione.
                        if (locationFrm.ShowDialog() == DialogResult.OK)
                            NetworkManager.SendPosition(locationFrm.SelectedLocation);
                        break;
                }
        }

        private void manageLoginRequested(object sender, EventArgs e)
        {
            if (Boxes.ShowMessageDialog("Message.2", "FrmHome.Messages.003", frmMessageBox.MessageLevel.Message, frmMessageBox.BoxResponse.YesNo) == DialogResult.OK)
            { 
                ManageLogout();
                manageLogin();
            }
        } 

        private void onSpeciaHided(object sender, EventArgs e)
        { 
            PowerManagement.StopSuspendManage = false;
        } 

        private void onGoSpecialRequest(object sender, EventArgs e)
        {
            PowerManagement.StopSuspendManage = true; 
            specialFrm.Show(); 
        }

        private void onDeviceConnected(object sender, EventArgs e)
        {
            if (InvokeRequired)
                Invoke(new EventHandler(onDeviceConnected), new object[] { sender, e });
            else
            {   // UI THREAD
                Boxes.CloseLoadingDialog();
                timeOutCount = 0;
            }
        }

        private void onDeviceConnectionStarted(object sender, EventArgs e)
        {
            if (InvokeRequired)
                Invoke(new EventHandler(onDeviceConnectionStarted), new object[] { sender, e });
            else
            {   // UI THREAD
                Boxes.ShowLoadingDialog(
                    "Global.1", "FrmHome.Messages.004", 
                    (frmLoadingBox.ShowedMessageDelegate)delegate { return "Riavvio comunicazione in corso... Tentativo {0}" + timeOutCount.ToString(); }
                    );
            }
        }

        private void onDeviceDisconnected(object sender, EventArgs e)
        {
            if (InvokeRequired)
                Invoke(new EventHandler(onDeviceDisconnected), new object[] { sender, e });
            else
            { // UI THREAD  
            }
        }

        private void onDeviceError(object sender, DeviceErrorEventArgs e)
        {
            if (InvokeRequired)
                Invoke(new DeviceErrorEventHandler(onDeviceError), new object[] { sender, e });
            else
            {   // UI THREAD
                switch (e.Error.Id)
                {
                    case 200: // Time OUT  

                        if (timeOutCount == 0)
                            Boxes.ShowMessageDialog("Global.1", "FrmHome.Messages.004", frmMessageBox.MessageLevel.Error); 

                        DeviceInterface.AvviaComunicazione();
                        timeOutCount++;
                        break; 

                    case 101: // Errore PORTA COM 
                        Boxes.ShowMessageDialog("Global.1", "FrmHome.Messages.005", frmMessageBox.MessageLevel.Error); 
                        break;

                    case 121:
                        Boxes.ShowMessageDialog("Global.1", "FrmHome.Messages.006", frmMessageBox.MessageLevel.Error);
                        break;

                    case 122:
                        Boxes.ShowMessageDialog("Global.1", "FrmHome.Messages.007", frmMessageBox.MessageLevel.Error); 
                        DeviceInterface.AvviaComunicazione();
                        timeOutCount++;
                        break;
                            
                    default: // Errore 
                        Boxes.ShowMessageDialog("Global.1", "Global.2", frmMessageBox.MessageLevel.Error, e.Error.Id);
                        break;
                }
            }
        } 

        private void refreshTick(object sender, EventArgs e)
        { 
            // Gestione SOSPENSIONE
            if (MousePosition.X != lastCursorPoint.X | MousePosition.Y != lastCursorPoint.Y | !DeviceInterface.DeviceConnected)
            {
                PowerManagement.ResetSuspendTime();
                lastCursorPoint = new Point(MousePosition.X, MousePosition.Y);
            }

            if (!DeviceStatusFlag.Emergenza | 
                DeviceStatusFlag.OutMotoruote |
                DeviceStatusFlag.PresenzaManoDx |
                DeviceStatusFlag.PresenzaManoSx | 
                DeviceStatusFlag.LettoPresente | 
                DeviceStatusFlag.MovimentoLibero)
                PowerManagement.ResetSuspendTime(); 

            // Gestione VELOCITA'
            if (btnVeloce.ButtonEnabled ^ DeviceStatusFlag.MuoviInLento) 
                if (btnVeloce.ButtonEnabled = DeviceStatusFlag.MuoviInLento)
                {
                    btnLento.ButtonEnabled = false;
                    btnVeloce.Font = new Font(btnVeloce.Font.Name, 18.0f, FontStyle.Regular);
                    btnLento.Font = new Font(btnVeloce.Font.Name, 24.0f, FontStyle.Regular);
                    btnVeloce.Location = new Point(582 + 20, btnVeloce.Location.Y);
                    btnLento.Location = new Point(582, btnLento.Location.Y);
                    btnVeloce.ForeColor = Color.FromArgb(22, 20, 19);
                    btnLento.ForeColor = Color.FromArgb(177, 253, 0);
                }
                else 
                {
                    btnLento.ButtonEnabled = true;
                    btnVeloce.Font = new Font(btnVeloce.Font.Name, 24.0f, FontStyle.Regular);
                    btnLento.Font = new Font(btnVeloce.Font.Name, 18.0f, FontStyle.Regular);
                    btnVeloce.Location = new Point(582, btnVeloce.Location.Y);
                    btnLento.Location = new Point(582 + 20, btnLento.Location.Y);
                    btnVeloce.ForeColor = Color.FromArgb(177, 253, 0);
                    btnLento.ForeColor = Color.FromArgb(22, 20, 19);
                }

            // Gestione MOVIMENTO LIBERO
            btnMovimentoLibero.BlinkEnabled = DeviceStatusFlag.MovimentoLibero;

            // Gestione MOVIMENTO AD UNA MANO
            setStatusFlagBitmaps();
            btnUnaMano.BlinkEnabled = DeviceStatusFlag.UnaMano;

            // Grafica BATTERIE 
            batteryStatus.BatteryPercentage = BatteryStatusManager.GetBatteryPercentage(BatteryEnum.Generale);
 
            if (batteryStatus.Expanded)
            {
                batteryStatus.Battery1Percentage = BatteryStatusManager.GetBatteryPercentage(BatteryEnum.Batteria1);
                batteryStatus.Battery2Percentage = BatteryStatusManager.GetBatteryPercentage(BatteryEnum.Batteria2);

                batteryStatus.Battery1Voltage = BatteryStatusManager.GetBatteryVoltage(BatteryEnum.Batteria1);
                batteryStatus.Battery2Voltage = BatteryStatusManager.GetBatteryVoltage(BatteryEnum.Batteria2);

                batteryStatus.WorkTime = TimeSpan.FromMinutes(BatteryStatusManager.GetWorkTime());
            }

            btnChiudPinza.ButtonEnabled = !PorterFunctions.GetPinzaChiusa();

            if ((statusBarCntrl.FlagStatus[0] ^ (!DeviceStatusFlag.Emergenza & DeviceInterface.DeviceConnected)) |
                (statusBarCntrl.FlagStatus[1] ^ (PorterFunctions.GetPinzaChiusa() & DeviceInterface.DeviceConnected)) |
                (statusBarCntrl.FlagStatus[2] ^ (DeviceStatusFlag.LettoPresente & DeviceInterface.DeviceConnected)) |
                (statusBarCntrl.FlagStatus[3] ^ (DeviceStatusFlag.PresenzaManoDx & DeviceInterface.DeviceConnected)) |
                (statusBarCntrl.FlagStatus[4] ^ (DeviceStatusFlag.PresenzaManoSx & DeviceInterface.DeviceConnected)) |
                (statusBarCntrl.FlagStatus[5] ^ (DeviceStatusFlag.OutMotoruote & DeviceInterface.DeviceConnected)) |
                (statusBarCntrl.FlagStatus[6] ^ (DeviceStatusFlag.MovimentoLibero & DeviceInterface.DeviceConnected)) |
                (statusBarCntrl.FlagStatus[7] ^ NetworkManager.ComunicationOn))
            {
                statusBarCntrl.FlagStatus[0] = !DeviceStatusFlag.Emergenza & DeviceInterface.DeviceConnected;
                statusBarCntrl.FlagStatus[1] = PorterFunctions.GetPinzaChiusa() & DeviceInterface.DeviceConnected;
                statusBarCntrl.FlagStatus[2] = DeviceStatusFlag.LettoPresente & DeviceInterface.DeviceConnected;
                statusBarCntrl.FlagStatus[3] = DeviceStatusFlag.PresenzaManoDx & DeviceInterface.DeviceConnected;
                statusBarCntrl.FlagStatus[4] = DeviceStatusFlag.PresenzaManoSx & DeviceInterface.DeviceConnected;
                statusBarCntrl.FlagStatus[5] = DeviceStatusFlag.OutMotoruote & DeviceInterface.DeviceConnected;
                statusBarCntrl.FlagStatus[6] = DeviceStatusFlag.MovimentoLibero & DeviceInterface.DeviceConnected;
                statusBarCntrl.FlagStatus[7] = NetworkManager.ComunicationOn;
                statusBarCntrl.Invalidate();
            }

            // Grafica USER
            operatorCntrl.NomeOperatore = UserManager.CurrentUser.Name;
            operatorCntrl.IdOperatore = UserManager.CurrentUser.Id;

            // Grafica LETTO  
            switch (LettoManager.Status)
            {
                case ManagerStatus.Hidle:
                    bedInfoCntrl.TitleLabel = "FrmHome.bedInfoCntrl.TitleLabel.1";
                    bedInfoCntrl.InfoLabel = "FrmHome.bedInfoCntrl.InfoLabel.1";
                    break;

                case ManagerStatus.InitializingRfidReader:
                    bedInfoCntrl.TitleLabel = "FrmHome.bedInfoCntrl.TitleLabel.1";
                    bedInfoCntrl.InfoLabel = "FrmHome.bedInfoCntrl.InfoLabel.2";

                    break;

                case ManagerStatus.WaitingRfidTag:
                    bedInfoCntrl.TitleLabel = "FrmHome.bedInfoCntrl.TitleLabel.1";
                    bedInfoCntrl.InfoLabel = "FrmHome.bedInfoCntrl.InfoLabel.3";
                    break;

                case ManagerStatus.TagRfidReaded:
                    bedInfoCntrl.TitleLabel = "FrmHome.bedInfoCntrl.TitleLabel.2";
                    bedInfoCntrl.InfoLabel = LettoManager.LettoAgganciato.Name;
                    break;

                case ManagerStatus.Error:
                    bedInfoCntrl.TitleLabel = "FrmHome.bedInfoCntrl.TitleLabel.1";
                    bedInfoCntrl.InfoLabel = string.Format("Errore [{0}]", LettoManager.LastError);
                    break;
            }  

            if (DeviceStatusFlag.OutMotoruote)
            {
                lblPinzaInfo.TextLabel = "FrmHome.lblPinzaInfo.Text.Mod.2";
                controlloInMovimento1.Show();
                controlloInMovimento1.Refresh();
            }
            else
            {
                lblPinzaInfo.TextLabel = "FrmHome.lblPinzaInfo.Text";
                controlloInMovimento1.Hide();
            }

            // Grafica ALLARMI
            MessageList allMessages = (MessageList)DeviceData.GetDeviceData(DeviceDataDef.Messages);

            if (allMessages != null)
            {
                bool oneMessage = false;
                foreach (Message msg in allMessages)
                    if (msg.IsActive)
                    {
                        alarmMessageCntrl.AlarmText = Resources.Resources.GetString(msg.MessageResourceName);
                        alarmMessageCntrl.AlarmLevel = msg.MessageLevel;

                        btnAlarms.HeadTextLabel = allMessages.GetActiveMessageCount().ToString();
                        btnAlarms.ButtonEnabled = btnAlarms.BlinkEnabled = true;
                        oneMessage = true;
                        break;
                    }

                if (!oneMessage)
                {
                    alarmMessageCntrl.AlarmText = "Global.3";
                    alarmMessageCntrl.AlarmLevel = 1;

                    btnAlarms.HeadTextLabel = string.Empty;
                    btnAlarms.ButtonEnabled = btnAlarms.BlinkEnabled = false; 
                }
            }
            else
                alarmMessageCntrl.AlarmText = "NONE";  

            // Grafica MESSAGGI da RETE 
            btnNetworkMessages.HeadTextLabel = NetworkManager.MessageList.Count > 0 ? NetworkManager.MessageList.Count.ToString() : string.Empty;
            btnNetworkMessages.ButtonEnabled = NetworkManager.MessageList.Count > 0;
            btnNetworkMessages.BlinkEnabled = NetworkManager.MessageList.Count > 0;
        } 

        private void apriPinzaRequested(object sender, MouseEventArgs e)
        {
            PorterFunctions.ApriPinza();
        }

        private void chiudiPinzaRequested(object sender, MouseEventArgs e)
        {
            PorterFunctions.ChiudiPinza();
        }

        private void alzaPinzaRequested(object sender, MouseEventArgs e)
        {
            PorterFunctions.SollevaPinza();
        }

        private void abbassaPinzaRequested(object sender, MouseEventArgs e)
        {
            PorterFunctions.AbbassaPinza();
        }

        private void StopPinza(object sender, MouseEventArgs e)
        {
            PorterFunctions.StopComando();
        }

        private void freeMovingRequested(object sender, EventArgs e)
        {
            PorterFunctions.FreeMovingSwitch();
        }

        private void unaManoRequested(object sender, EventArgs e)
        {
            PorterFunctions.UnaManoSwitch();
        }

        private void moveFastRequested(object sender, EventArgs e)
        {
            if (DeviceStatusFlag.MuoviInLento)
                PorterFunctions.MoveFast();
        }

        private void moveSlowRequested(object sender, EventArgs e)
        {
            if (!DeviceStatusFlag.MuoviInLento)
                PorterFunctions.MoveSlow();
        }

        private void showAlarmsBox(object sender, EventArgs e)
        {
            messagesBox.ShowDialog();
        }
    }
}