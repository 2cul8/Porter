using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Xml;

using LogManagement;
using PorterProto;
using RfidManager;
using UserManagement;
using LocationManagement;

namespace NetManagement
{
    public static class NetworkManager
    {
        private const string LOG_FILE_NAME = "NetManagement";
        /* 
         * PC = SERVER
         * PORTER = CLIENT
         * 
         * 0 - Invio continuamente pacchetto UDP bradcast per richiedere le informazioni dal server.
         * 1 - Aspetto UDP da server.
         * 2 - Leggo informazioni server e memorizzo.
         * 3 - Apro connessione TCP con server.
         * 4 - Scarico file di utilizzo. 
         * 5 - Rimango connesso per ulteriori richieste.
         * 
         * Se perdo la connessione tento di ricrearla. 
         * 
         * Richieste:
         * a - Dove mi trovo.    -> Se localizzazione ON mando posizione, altrimenti richiedo scelta da lista.
         * b - Chi sta guidando. 
         * c - Stato porter.
         * d - Errori. 
         * e - Messaggio da server. 
        */

        public static event NetworkMessageEventHandler NewMessage;

        //private static string SERVER_ID = "e441174a-7f62-44d2-9005-6fb7bc022612";

        private const int UDP_LISTENER_SERVICE_PORT_SERVER = 53337;
        private const int UDP_LISTENER_SERVICE_PORT_CLIENT = 53340; // Per ricevere le prime informazioni.
        private const int UDP_SENDER_SERVICE_PORT_CLIENT = 53336; // Per inviare un messaggio broadcast.

        private static Thread comunicationThread;
        private static Thread notificationThread;
        private static UdpClient udpSender;
        private static UdpClient udpListener;
        private static IPEndPoint remoteEp;
        private static IPEndPoint groupEpResponse;
        private static IPEndPoint groupEpRequest;
        private static Socket clientSocket;
        private static bool continueListening;
        private static bool listening;
        private static int comunicationStatus = 0;
        private static int protocollTicks = 0;
        private static int notificationStatus = 0;
        private static string notificationArgs = string.Empty;
        private static int requestsStatus = 0;
        private static object requestArgs;

        private static NetworkMessagesList messageList;

        public static NetworkMessagesList MessageList
        {
            get { return messageList; }
        }

        private static bool comunciationOn = false;
        public static bool ComunicationOn
        {
            get { return comunciationOn; }
        }

        public static bool InitManager()
        {
            udpListener = new UdpClient(UDP_LISTENER_SERVICE_PORT_CLIENT);
            udpSender = new UdpClient(UDP_SENDER_SERVICE_PORT_CLIENT);
            groupEpRequest = new IPEndPoint(IPAddress.Broadcast, UDP_LISTENER_SERVICE_PORT_SERVER);
            groupEpResponse = new IPEndPoint(IPAddress.Any, UDP_LISTENER_SERVICE_PORT_CLIENT);

            messageList = new NetworkMessagesList();

            comunicationThread = new Thread(comunciationDaemon);
            notificationThread = new Thread(networkNotificationDaemon);
            return true;
        }

        public static void StartListening()
        {
            if (listening) return;

            continueListening = true;
            comunicationThread.Start();
            notificationThread.Start();
        }

        public static void SendPosition(int positionIndex)
        {
            requestArgs = LocationManager.Locations[positionIndex];
            requestsStatus = 202;
        }

        private static void comunciationDaemon()
        {
            string msg = string.Empty;
            byte[] recivedData;

            string tokenString = ";1;53340";
            tokenString = (tokenString.Length + 2).ToString() + tokenString;
            byte[] dataToken = ASCIIEncoding.ASCII.GetBytes(tokenString);

            int serverPort = 0;
            int waitTime = 1000;
            string serverName = string.Empty;

            while (continueListening)
            {
                switch (comunicationStatus)
                {
                    case 0:
                        // Connessione non ancora avvenuta.
                        // Mi faccio vedere sulla rete.
                        udpSender.Send(dataToken, dataToken.Length, groupEpRequest);
                        comunicationStatus = 1;
                        waitTime = 1000;
                        comunciationOn = false; 
                        break;

                    case 1:
                        if (udpListener.Client.Available > 0)
                        {
                            // Controllo se il server ha risposto.
                            recivedData = udpListener.Receive(ref groupEpResponse);
                            string data = ASCIIEncoding.ASCII.GetString(recivedData, 0, recivedData.Length);
                            LogManager.WriteLog(LOG_FILE_NAME, string.Format("Informazioni ricevute: {0}", data));  

                            // Risposta:
                            // 0 - Porta connessione TCP server.
                            // 1 - Nome Server.
                            string[] fields = data.Split(";".ToCharArray());

                            if (fields.Length < 2)
                            {
                                comunicationStatus = 0;
                                break;
                            }

                            try
                            {
                                serverName = fields[1];
                                serverPort = int.Parse(fields[0]);
                                comunicationStatus = 2; // Dati ok.
                                LogManager.WriteLog(LOG_FILE_NAME, string.Format("Informazioni valide: ip {2}, porta {0}, nome {1}", serverPort, serverName, groupEpResponse.Address.ToString()));   
                            }
                            catch
                            {
                                // Porta non valida.
                                comunicationStatus = 0;
                            }
                        }
                        else
                            comunicationStatus = 0;
                        break;

                    case 2:
                        // Dati server ricevuti.
                        // Tento di creare la connessione.
                        clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        remoteEp = new IPEndPoint(groupEpResponse.Address, serverPort);
                        LogManager.WriteLog(LOG_FILE_NAME, "Connessione in corso...");   

                        try
                        {
                            clientSocket.Connect(remoteEp);
                            comunicationStatus = 3;
                            comunciationOn = true;
                            waitTime = 10;
                        }
                        catch (Exception ex)
                        {
                            LogManager.WriteLog(LOG_FILE_NAME, ex.Message);
                            LogManager.WriteLog(LOG_FILE_NAME, ex.StackTrace); 
                            // Connessione non avvenuta.
                            comunicationStatus = 0;
                            break;
                        }

                        break;

                    case 3:
                        // Connessione avvenuta.
                        // Invio informazioni preliminari.

                        byte[] fileLenght = new byte[4];
                        int lenght = 0;
                        LogManager.WriteLog(LOG_FILE_NAME, "Attesa lunghezza file delle locazioni.");
                        clientSocket.Receive(fileLenght);
                        lenght = BitConverter.ToInt32(fileLenght, 0);
                        LogManager.WriteLog(LOG_FILE_NAME, string.Format("Lunghezza: {0}. [{1}]", lenght, clientSocket.Available));
                        clientSocket.Receive(recivedData = new byte[lenght]);
                        LogManager.WriteLog(LOG_FILE_NAME, "File ricevuto -> Salvataggio impostazioni.");
                        setSettings(1, recivedData); 
                        comunicationStatus = 4;
                        break;

                    case 4: // Richiesta file di gestione.  
                        LogManager.WriteLog(LOG_FILE_NAME, "Invio informazioni.");
                        clientSocket.Send(ASCIIEncoding.ASCII.GetBytes("00001;Porter1"));
                        comunicationStatus = 5;
                        protocollTicks = 0;
                        break;

                    case 5:
                        // Esecuzione protocollo.
                        switch (execProtocoll())
                        {
                            case 0:
                                break;

                            case 1:
                            case 2:
                                comunicationStatus = 0; 
                                comunciationOn = false;
                            break;
                        }
                        break;
                }

                protocollTicks++;
                Thread.Sleep(waitTime);
            }

            listening = false;
        }

        private static int execProtocoll()
        {
            byte[] reciveBuffer = new byte[1024];

            try
            {
                if (protocollTicks > 500)
                {
                    // TimeOut comunicazione.
                    // Riavvio tutto.
                    LogManager.WriteLog(LOG_FILE_NAME, "Time out comuncazione.");
                    LogManager.WriteLog(LOG_FILE_NAME, "Chiudo socket e riavvio.");    
                    clientSocket.Close();
                    comunicationStatus = 0;
                    return 1;
                }

                if (clientSocket.Available > 0)
                { 
                    protocollTicks = 0;
                    reciveBuffer = new byte[1];
                    clientSocket.Receive(reciveBuffer);

                    switch (reciveBuffer[0]) // id Comando.
                    {
                        case 100: // Idle
                            clientSocket.Send(new byte[] { 100 }); // Risposta ACK.
                            break;

                        case 101: // Richiesta di stato.
                            LogManager.WriteLog(LOG_FILE_NAME, "Richiesto stato (101).");

                            StringBuilder sb = new StringBuilder();
                            sb.Append("0"); sb.Append(";"); // Posizione automatica abilitata.
                            sb.Append(""); sb.Append(";"); // Posizione (se abilitata).
                            sb.Append(UserManager.CurrentUser.Id); sb.Append(";"); // User corrente
                            sb.Append(BatteryStatusManager.GetBatteryPercentage(BatteryEnum.Generale).ToString()); sb.Append(";"); // Percentuale batteria
                            sb.Append((DeviceStatusFlag.LettoPresente & DeviceStatusFlag.FcPinza) ? LettoManager.LettoAgganciato.Name : string.Empty); sb.Append(";"); // Letto agganciato
                            sb.Append(DeviceInterface.DeviceConnected ? "1" : "0"); sb.Append(";");// Terminale collegato a dispositivo.
                            sb.Append(DeviceStatusFlag.OutMotoruote & DeviceInterface.DeviceConnected ? "1" : "0"); sb.Append(";");  // Porter in movimento. 

                            MessageList allMessages = (MessageList)DeviceData.GetDeviceData(DeviceDataDef.Messages);

                            if (allMessages != null) 
                                foreach (Message msg in allMessages)
                                    sb.Append(msg.IsActive ? "1" : "0");

                            sb.Append(";");

                            clientSocket.Send(new byte[] { 201 });
                            clientSocket.Send(ASCIIEncoding.ASCII.GetBytes(sb.ToString()));
                            LogManager.WriteLog(LOG_FILE_NAME, "Stato inviato.");

                            break;

                        case 102:
                            LogManager.WriteLog(LOG_FILE_NAME, "Richiesta posizione da utente (102).");
                            notificationStatus = 2;
                            break;

                        case 103: // Messaggio.
                            LogManager.WriteLog(LOG_FILE_NAME, "Ricevuto messaggio (103)."); 
                            if (clientSocket.Available > 0)
                            {
                                reciveBuffer = new byte[1];
                                clientSocket.Receive(reciveBuffer);
                                int msgLenght = reciveBuffer[0];
                                LogManager.WriteLog(LOG_FILE_NAME, string.Format("Lunghezza messaggio [{0}].", msgLenght.ToString()));  
                                reciveBuffer = new byte[msgLenght];
                                clientSocket.Receive(reciveBuffer);
                                notificationArgs = ASCIIEncoding.ASCII.GetString(reciveBuffer, 0, reciveBuffer.Length);
                                notificationStatus = 1; 
                            }
                            break;

                        case 255: // Richiesta disconnessione.
                            clientSocket.Close();
                            comunicationStatus = 0;
                            break;
                    }
                }
                else
                    switch (requestsStatus)
                    {
                        case 0:
                            break;

                        case 202: // Invio risposta per richiesta posizione. 
                            clientSocket.Send(new byte[] { 202 });
                            clientSocket.Send(ASCIIEncoding.ASCII.GetBytes(((Location)requestArgs).Id));
                            LogManager.WriteLog(LOG_FILE_NAME, "Posizione inviata.");
                            requestsStatus = 0;
                            break;
                    }

                return 0;
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(LOG_FILE_NAME, "Errore durante la comunicazione con il server:");
                LogManager.WriteLog(LOG_FILE_NAME, ex.Message);
                LogManager.WriteLog(LOG_FILE_NAME, "Riavvio comunicazione ...");
                comunicationStatus = 0;
                return 2; 
            }
        }

        private static void networkNotificationDaemon()
        {
            while (continueListening)
            {
                if (comunicationStatus < 5)
                {
                    Thread.Sleep(100);
                    continue;
                }

                switch (notificationStatus)
                {
                    case 0:
                        break;

                    case 1: // gestione messaggio. 

                        NetworkMessage msg =new NetworkMessage(0, 0, "Server", notificationArgs);

                        if (NewMessage != null)
                            NewMessage.Invoke(new object(), new NetworkMessageEventArgs(msg));

                        messageList.Add(msg);
                        LogManager.WriteLog(LOG_FILE_NAME, string.Format("Notifica messaggio [{0}] in corso.", msg.Id));
                        notificationStatus = 0; // Messaggio notificato. mi metto in attesa.
                        break;

                    case 2: // richiesta posizione. 
                        LogManager.WriteLog(LOG_FILE_NAME, "Notifica richiesta in corso.");
                        if (NewMessage != null)
                            NewMessage.Invoke(new object(), new NetworkMessageEventArgs(new NetworkMessage(0, 1, "Server", notificationArgs)));

                        LogManager.WriteLog(LOG_FILE_NAME, "Michiesta notificata.");
                        notificationStatus = 0; // Messaggio notificato. mi metto in attesa. 
                        break;
                }

                Thread.Sleep(100);
            }
        }

        private static void setSettings(int settingType, byte[] fileBuffer)
        {
            switch (settingType)
            {
                case 1:
                    Stream locationStream = new MemoryStream(fileBuffer);
                    XmlDocument xDocLocation = new XmlDocument();
                    xDocLocation.Load(locationStream);
                    LocationManager.SetLocationsList(xDocLocation);
                    break;
            }
        }
    }

    public class NetworkMessagesList : List<NetworkMessage>
    {
        internal new void Add(NetworkMessage msg)
        {
            msg.Id = getFreeId();
            base.Add(msg);            
        }

        internal new bool Remove(NetworkMessage msg)
        {
            return base.Remove(msg);
        }

        public void MessageNotified(NetworkMessage msg)
        {
            base.Remove(msg);
        }

        private int getFreeId()
        {
            int id = 0;
            bool idFounded = false;

            while (!idFounded)
            {
                id = (new Random()).Next(int.MaxValue);
                idFounded = true;

                foreach (NetworkMessage msg in this)
                    if (msg.Id == id)
                        idFounded = false;
            }

            return id;
        }
    }

    public delegate void NetworkMessageEventHandler(object sender, NetworkMessageEventArgs e);

    public class NetworkMessageEventArgs : EventArgs
    {
        private NetworkMessage message;
        public NetworkMessage Message
        {
            get { return message; }
        }

        public NetworkMessageEventArgs(NetworkMessage msg)
        {
            message = msg;
        } 
    }

    public class NetworkMessage
    {
        private int id = 0;
        public int Id
        {
            get { return id; }
            internal set { id = value; }
        }

        private int type = 0;
        public int MessageType
        {
            get { return type; }
        }

        private string sourceName = string.Empty;
        public string SourceName
        {
            get { return sourceName; }
        }

        private string message = string.Empty;
        public string Message
        {
            get { return message; }
        }

        internal NetworkMessage(int messageId, int messageType, string source, string msg)
        {
            id = messageId;
            type = messageType;
            sourceName = source;
            message = msg;
        }
    }
}
