using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace RfidManager
{ 
    public enum ManagerStatus
    {
        Hidle = 0,
        InitializingRfidReader = 1,
        WaitingRfidTag = 2,
        TagRfidReaded = 3,
        Error = 4,
    } 

    public static class LettoManager
    {
        private static int lastError = 0;
        public static int LastError
        {
            get { return lastError; }
        }

        public static ManagerStatus Status
        {
            get
            { 
                switch (RfidManager.daemonStatus)
                {
                    case 10: // Apro porta seriale
                    case 20: // Attivo uscita rfid
                    case 21: // Aspetto uscita rfid attiva
                    case 30: // Dispositivo rfid presente
                        return lastError != 0 ? ManagerStatus.Error : ManagerStatus.InitializingRfidReader;

                    case 31: // Attesa ricezione tag
                    case 32: // Attesa ricezione tag
                    case 33: // Test tag ricevuto
                    case 40: // Leggo tag rfid
                        return lastError != 0 ? ManagerStatus.Error : ManagerStatus.WaitingRfidTag;

                    case 60: // Tolgo uscita rfid
                    case 61: // Attesa disattivazione uscita RFID
                    case 70: // Chiudo porta seriale.
                    case 80: // Attesa letto sganciato. 
                        return lastError != 0 ? ManagerStatus.Error : ManagerStatus.TagRfidReaded;

                    case 65535: // Errore
                        return ManagerStatus.Error;

                    case 0: // Attesa aggancio letto. (pinze chiuse e letto presente)
                    default:
                        lastLetto = Letto.Empty;
                        lastError = 0;
                        return ManagerStatus.Hidle;

                }
            }
        }

        private static Letto lastLetto;
        public static Letto LettoAgganciato
        {
            get { return lastLetto; }
        }

        private static DataBaseLetti dbLetti;

        public static void InitializeManager()
        {
            RfidManager.InitManager();
            lastLetto = Letto.Empty;
            dbLetti = DataBaseLetti.LoadDataBase(); 
        }

        public static void PulisciLettoAgganciato()
        {
            lastLetto = Letto.Empty;
        }

        public static void StartListening()
        { 
            RfidManager.StartRfidDaemon();
        }

        public static void StopListening()
        {
            RfidManager.StopRfidDaemon();
        }

        internal static void NotifyNewTag(byte[] tag)
        {
            // Evento di notifica.
            lastLetto = dbLetti[0];
        }

        internal static void NotifyRfidError(int error)
        { 
            switch (error)
            {
                case RfidManager.RFID_OPENING_PORT_ERROR:
                    lastLetto = Letto.Empty;
                    lastError = RfidManager.RFID_OPENING_PORT_ERROR;
                    break;

                case RfidManager.RFID_CLOSING_PORT_ERROR: // Notifico l'errore con messaggio.
                    lastError = RfidManager.RFID_CLOSING_PORT_ERROR;
                    break;

                case RfidManager.RFID_TIME_OUT_ERROR: // Notifico l'errore con messaggio.
                    lastError = RfidManager.RFID_TIME_OUT_ERROR;
                    break;

                case RfidManager.RFID_CLOSE_PORT_ERROR: // Notifico l'errore con messaggio. 
                    lastError = RfidManager.RFID_CLOSE_PORT_ERROR;
                    break;

                case RfidManager.RFID_READ_PORT_ERROR:
                    lastError = RfidManager.RFID_READ_PORT_ERROR;
                    lastLetto = Letto.Empty;
                    break;

                case RfidManager.RFID_OUT_ON_ERROR:
                    lastError = RfidManager.RFID_OUT_ON_ERROR;
                    lastLetto = Letto.Empty;
                    break;

                case RfidManager.RFID_READER_NOT_FOUNDED:
                    lastError = RfidManager.RFID_READER_NOT_FOUNDED;
                    lastLetto = Letto.Empty;
                    break; 
            }
        }
    }

    public class DataBaseLetti : List<Letto>
    {
        private const string DATA_BASE_NAME = "DataBaseLetti.dat";

        public new Letto this[int index]
        {
            get { return base[index]; }
        }

        internal DataBaseLetti() 
        : base()
        { }

        internal new void Add(Letto toAdd)
        {
            base.Add(toAdd);
        }

        internal new void Remove(Letto toRemove)
        {
            base.Remove(toRemove);
        }

        internal static DataBaseLetti LoadDataBase()
        {
            string dbFileName = Path.Combine(Utils.GetApplicationPath(), DATA_BASE_NAME);

            //if (!File.Exists(dbFileName))
            //    return new DataBaseLetti();

            //try
            //{
                //StreamReader sr = File.OpenText(dbFileName);

                DataBaseLetti dataBase = new DataBaseLetti();
                dataBase.Add(new Letto(new byte[21] { 160, 0, 9, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 201 } , "Chirurgia 123"));

                return dataBase;
                //while (!sr.EndOfStream)
                //{
                //    string line = sr.ReadLine();

                //    string[] fields = line.Split(";".ToCharArray());

                //    string name = fields[0];
                //    string[] codeStrings = fields[1].Trim().Split(",".ToCharArray());
                //    byte[] code = new byte[codeStrings.Length];

                //    for (int i = 0; i < codeStrings.Length; i++)
                //        code[i] = byte.Parse(codeStrings[i]);

                //    dataBase.Add(new Letto(new byte[21] { 160, 0, 9, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 201 } , name)); 
                     
                //}

                //return dataBase;
            //}
            //catch
            //{
            //    return new DataBaseLetti();
            //}
        }
    }

    public class Letto
    {
        public static readonly Letto Empty = new Letto(new byte[0], string.Empty);

        private byte[] rfidCode = new byte[0];
        public byte[] RfidCode
        {
            get { return rfidCode; }
        }

        private string name = string.Empty;
        public string Name
        {
            get { return name; }
        }

        internal Letto(byte[] rfid, string name)
        {
            rfidCode = rfid;
            this.name = name;
        }
    }
}
