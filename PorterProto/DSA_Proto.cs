using System;
using System.Collections.Generic;  
using System.Runtime.InteropServices; 

namespace PorterProto
{ 
    internal static class DevProto
    {
        #region strutture 

        [StructLayout(LayoutKind.Sequential)]
        public struct STSK
        {
            public byte Tipo;		// Trasmissione o Ricezione
            public byte Dato;  	// Tag protocollo
            public byte[] Buf;		// Indirizzo buffer dati
            public int BufMax;	// Dimensioni massime buffer 
            public byte BufSize;	// 0 Buffer no buono, !0 numero char nel buffer
            public byte Repeat;	// Ripete richiesta

            public void Initialize()
            {
                Tipo = 0;
                Dato = 0;
                Buf = new byte[200];
                BufSize = 0;
                Repeat = 0;
            }
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct SERSTRU
        {
            private byte _Attivo;			// Attiva il task;
            internal byte Attivo
            {
                get { return _Attivo; }
                set { _Attivo = value; }
            }

            private byte _AttesaSpedParametri;
            public byte AttesaSpedParametri
            {
                get { return _AttesaSpedParametri; }
                set { _AttesaSpedParametri = value; }
            }
             
            public byte Com;				// Porta seriale
            public int SerErr;			// Ultimo errore seriale
            public byte SerFlag;			// Flag per task seriale
            public int Numero;			// Numero di protocollo attivo
            public byte Send;           // Stato di spedizione
            public STSK[] Task;

            public void Initialize()
            {
                Task = new STSK[(int)MAXSERTASK];
                SerFlag = 1;

                _Attivo = 0;
                _AttesaSpedParametri = 0;

                for (int i = 0; i < (int)MAXSERTASK; i++)
                {
                    Task[i].Initialize();
                }
            } 
        };

        internal static int TIMERBUFF_SIZE = DeviceConstants.PAR_TIMER;
        internal static int CONTBUFF_SIZE = DeviceConstants.PAR_CONTATORI;
        internal static int MONOSBUFF_SIZE = DeviceConstants.PAR_MONOSTABILI;
        internal static int MACCHINABUFF_SIZE = DeviceConstants.PAR_MACCHINA;
 
        //DSA Banco
        //private const int TIMERBUFF_SIZE = 40;
        //private const int CONTBUFF_SIZE = 40;
        //private const int MONOSBUFF_SIZE = 40;
        //private const int MACCHINABUFF_SIZE = 140;

        //Nuovo GS-DSA
        //private const int TIMERBUFF_SIZE = 32;
        //private const int CONTBUFF_SIZE = 32;
        //private const int MONOSBUFF_SIZE = 16;
        //private const int MACCHINABUFF_SIZE = 90;

        internal static int ASSEBUFF_SIZE = DeviceConstants.PAR_ASSE;
        internal static int ALLPARBUFF_SIZE = TIMERBUFF_SIZE + CONTBUFF_SIZE + MONOSBUFF_SIZE + MACCHINABUFF_SIZE + (ASSEBUFF_SIZE * DeviceConstants.NUM_ASSI); 

        internal struct SERPAR
        {
            public short[] TerminalParTimer;
            public short[] TerminalParAsse;
            public short[] TerminalParMonostabili;
            public short[] TerminalParMacchina;
            public short[] TerminalParContatori; 

            public void Initialize()
            {
                TerminalParTimer = new short[DeviceConstants.PAR_TIMER];
                TerminalParAsse = new short[DeviceConstants.PAR_ASSE * DeviceConstants.NUM_ASSI];
                TerminalParMonostabili = new short[DeviceConstants.PAR_MONOSTABILI];
                TerminalParMacchina = new short[DeviceConstants.PAR_MACCHINA];
                TerminalParContatori = new short[DeviceConstants.PAR_CONTATORI];
            } 
        }

        public enum eComError
        {
            NOERR = 0,
            NOCHAR = 1,
            TIMEOUT = 2,
            ERRTX = 3,
            ERRCOM = 4,
            ERRCHKSUM = 5,
            NOHOST = 6
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct LINKSTRU
        {
            private static byte pConnesso;			// Vera se connesso al DSA
            public static byte Connesso
            {
                get { return pConnesso; }
            }

            public static string Version;

            public static void SetConctStat(byte c)
            { pConnesso = c; LastError = (c != 0 ? (byte)0 : LastError); }

            public eComError LastErr;			// Ultimo Errore  
            public byte[] Val_Input;
            public byte[] Val_Output;
            public byte[] Val_MemIF;
            public byte[] Val_MemUF;
            public byte[] Val_Timer;
            public byte[] Val_SetRset;
            public byte[] Val_Conta;
            public byte[] Val_Monos;
            public byte[] Val_Versione;
            public byte[] Val_Msg_PLC;
            public byte[] Buf_Msg_PLC;	//da verificare sbordamento: questa è un'area dati cuscinetto
            public byte[] Val_Var_PLC;
            public int[] Val_Spec_PLC;

            // Vettori dati letti da DSA
            public int[] Val_Cnt;
            public int[] Val_Quote;
            public int[] Val_Impul;
            public int[] Val_Inseg;
            public int[] Val_Read_ADC;
            public int[] Val_Var;
            public int[] Val_Var_Valori;
            public int[] Val_Strutture;

            public void Initialize()
            {
                Val_Input = new byte[TOTIN];
                Val_Output = new byte[TOTOU];
                Val_MemIF = new byte[TOTUIF];
                Val_MemUF = new byte[TOTUIF];
                Val_Timer = new byte[TOTTIM];
                Val_SetRset = new byte[TOTSRE];
                Val_Conta = new byte[TOTCNT];
                Val_Monos = new byte[TOTMON];
                Val_Versione = new byte[SIZEBUF_VERSIONE];
                Val_Msg_PLC = new byte[NMSGPLC];
                Buf_Msg_PLC = new byte[NMSGPLC];
                Val_Read_ADC = new int[MAXADC];
                Val_Var = new int[MAX_VAR_QUOTE];
                Val_Quote = new int[MAXASS];
                Val_Inseg = new int[MAXASS];
                Val_Impul = new int[MAXASS];
                Val_Var_Valori = new int[MAX_VAR_VALORI];
                Val_Var_PLC = new byte[SIZEBUF_VAR_PLC];
                Val_Spec_PLC = new int[SIZEBUF_SPEC_PLC];
                Val_Strutture = new int[SIZEBUF_STRUTTURE / 2];

                if (pConnesso != 1)
                {
                    pConnesso = 0;
                    Version = "0.0.0";
                }
            }
        };

        // Struttura stato DSA (protocollo E)
        [StructLayout(LayoutKind.Sequential)]
        public struct ASSE
        {         			// Struttura per ogni asse
            public byte InMovimento;	// Asse in movimento
            public byte InQuota;		// Asse in quota
            public byte InStop;		// Asse in stop
            public byte InErrore;		// Asse in errore
            internal bool RetailDataActive;
            public void SetRetailDataValue(bool Value)
            { 
                RetailDataActive = Value;
            }

            internal byte InQuotRetail;
            public byte GetInQuote()
            {
                if (!RetailDataActive)
                {
                    InQuotRetail = 0x00;
                    return InQuota;
                }

                byte bValue = InQuotRetail;
                InQuotRetail = 0x00;

                return bValue;
            }

            internal byte InMovimentoRetail;
            public byte GetInMovimento()
            {
                if (!RetailDataActive)
                {
                    InMovimentoRetail = 0x00;
                    return InMovimento;
                }

                byte bValue = InMovimentoRetail;
                InMovimentoRetail = 0x00;

                return bValue;
            }

            internal byte InStopRetail;
            public byte GetInStop()
            {
                if (!RetailDataActive)
                {
                    InStopRetail = 0x00;
                    return InStop;
                }

                byte bValue = InStopRetail;
                InStopRetail = 0x00;

                return bValue;
            }

            internal byte InErroreRetail;
            public byte GetInErrore()
            {
                if (!RetailDataActive)
                {
                    InErroreRetail = 0x00;
                    return InErrore;
                }

                byte bValue = InErroreRetail;
                InErroreRetail = 0x00;

                return bValue;
            }

            internal int RetailedTime;
        } ;

        [StructLayout(LayoutKind.Sequential)]
        public struct SDSA
        // Struttura generale
        { 
            private byte _NAssi;			// Numero assi;
            internal byte NAssi
            {
                get { return _NAssi; }
                set
                {
                    if (_NAssi == value)
                        return;

                    _NAssi = value;
                    Assi = new ASSE[MAXASS];
                }
            }

            internal byte CPolling;		// Ciclo di polling attivo
            internal byte SendW;			// Impossibile spedire dati con protocollo W
            internal byte AskStart;		// Richiesto START
            /// <summary>
            /// Emergenza != 0 OK.
            /// </summary>
            internal byte Emergenza;		// Nessuna emergenza 
            internal byte ErrSlave;		// Errori master/slave
            internal ASSE[] Assi;     	// Stato degli assi

            internal void ActiveAllRetail()
            {
                if (Assi == null)
                    return;

                foreach (ASSE Axe in Assi)
                    Axe.SetRetailDataValue(true);
            }

            internal void DeactiveAllRetail()
            {
                if (Assi == null)
                    return;

                foreach (ASSE Axe in Assi)
                    Axe.SetRetailDataValue(false);
            }

            internal bool AssiInQuota()
            {
                if (Assi == null)
                    return true;

                foreach (ASSE Axe in Assi)
                    if (Axe.GetInQuote() > 0)
                        return false;

                return true;
            }

            internal bool AssiInErrore()
            {
                if (Assi == null)
                    return true;

                foreach (ASSE Axe in Assi)
                    if (Axe.GetInErrore() > 0)
                        return false;

                return true;
            }

            internal void Initialize()
            { 
                NAssi = DeviceConstants.NUM_ASSI; 
            }
        };

        #endregion

        #region Define

        private const int TIMEOUTDSA = 3; 
        //
        internal const byte TIMEOUT = 0X61;	// a Errore di timeout					
        internal const byte ERRTX = 0X62;    	// b Errore di trasmissione
        internal const byte ERRCOM = 0X63;		// c Errore di comunicazione
        internal const byte ERRCHKSUM = 0X64;	// d Checksum errato
        internal const byte NOCHAR = 0X65;		// e Nessun carattere letto
        internal const byte NOHOST = 0X66;		// f Host non collegato
        internal const byte COMUBRK = 0X67;		// g Comunicazione interrotta dall'utente
        internal const byte COMFAULT = 0x68;	// h Errore porta di comunicazione

        internal const int MAXSERTASK = 23;		// Numero massimo di richieste al protocollo

        //TASTI DSA ---------------------------------------//
        internal const byte TAST_FRECCIA_ALTO = 0x80; //  1
        internal const byte TAST_FRECCIA_BASSO = 0x81; // 2
        internal const byte TAST_FRECCIA_SX = 0x82; //    3
        internal const byte TAST_FRECCIA_DX = 0x83; //    4
        internal const byte TAST_F1 = 0x01; //            5
        internal const byte TAST_F2 = 0x02; //            6
        internal const byte TAST_F3 = 0x03; //            7
        internal const byte TAST_F4 = 0x04; //            8
        internal const byte TAST_ENTER = 0x0D; //         9
        internal const byte TAST_PIU = 0x2B; //           10
        internal const byte TAST_MENO = 0x2D; //          11

        //1 e 2 li uso per la sincronizzazione del ciclo di spostamento a quota incontro su telaio.

        //-------------------------------------------------//

        private const int SIZEBUF_MSG_PLC = 128;
        private const int SIZEBUF_SPEC_PLC = 8;
        private const int SIZEBUF_QUOTE = 128;
        private const int SIZEBUF_IMPUL = 128;
        private const int SIZEBUF_INSEG = 128;
        private const int SIZEBUF_INPUT = 24;
        private const int SIZEBUF_OUTPUT = 24;
        private const int SIZEBUF_MEMIF = 128;
        private const int SIZEBUF_MEMUF = 128;
        private const int SIZEBUF_TIMER = 32;
        private const int SIZEBUF_MONOS = 32;
        private const int SIZEBUF_CONTA = 16;
        private const int SIZEBUF_PAR = 32;
        private const int SIZEBUF_SETRSET = 128;
        private const int SIZEBUF_VERSIONE = 128;
        private const int SIZEBUF_STATO_DSA = 128;
        private const int SIZEBUF_CHKSUM = 128;
        private const int SIZEBUF_VAR_PLC = 128;
        private const int SIZEBUF_VAR_QUO = 128 * 4;
        private const int SIZEBUF_MAPPATURA = 128;
        private const int SIZEBUF_READ_ADC = 128;
        private const int SIZEBUF_STRUTTURE = 1024 * 4;
        private const int SIZEBUF_WRITE_PVM = 64;
        private const int SIZEBUF_SENDEFFE = 24;
        private const int SIZEBUF_SENDCHAR = 6;
        private const int SIZEBUF_WRITE_BIT = 32;
        private const int MAXSPAK = 0X20;
        private const int SIZEBUF_WRITE_OUT = 12;
        private const int SIZEBUF_GET_CNT = 2;

        internal const byte MAXASS = 8;      // Numero massimo di assi suportati
        private const byte TOTIN = 24;		 // Numero bit ingressi
        private const byte TOTOU = 24;		 // Numero bit uscite 
        private const int TOTUIF = 256;		 // Numero bit di finti ingressi e uscite
        private const byte TOTTIM = 26;		 // Numero bit timer sia set che reset
        private const byte TOTSRE = 26;      // Numero bit Set/Reset
        private const byte TOTCNT = 8;		 // Numero bit Contatori
        private const byte TOTMON = 30;		 // Numero bit Monostabili
        private const byte TOTSHFIF = 1;     // Numero massimo shift reg
        private const byte NMSGPLC = 128;
        private const int SPECPLC = 512;
        private const byte MAXADC = 12;
        private const byte MAX_VAR_QUOTE = 100;
        private const byte MAX_VAR_VALORI = 100;
        private const byte MAX_VAR_MEMORIE = 100;

        // Ricezione -------------------------------------------------------------------------------
        //
        private const int SLEEP_TIME_INTERVAL = 1; 
        //
        // Comandi F 
        private const int STOP_PLC = 50;
        private const int START_PLC = 51;  
        //
        // Buffer per il protocollo 
        private static byte[] SerBuf_CNT_PLC = new byte[SIZEBUF_GET_CNT];
        private static byte[] SerBuf_MSG_PLC = new byte[SIZEBUF_MSG_PLC];
        private static byte[] SerBuf_SPEC_PLC = new byte[SIZEBUF_SPEC_PLC];
        private static byte[] SerBuf_QUOTE = new byte[SIZEBUF_QUOTE];
        private static byte[] SerBuf_IMPUL = new byte[SIZEBUF_IMPUL];
        private static byte[] SerBuf_INSEG = new byte[SIZEBUF_INSEG];
        private static byte[] SerBuf_INPUT = new byte[SIZEBUF_INPUT];
        private static byte[] SerBuf_OUTPUT = new byte[SIZEBUF_OUTPUT];
        private static byte[] SerBuf_MEMIF = new byte[SIZEBUF_MEMIF];
        private static byte[] SerBuf_MEMUF = new byte[SIZEBUF_MEMUF];
        private static byte[] SerBuf_TIMER = new byte[SIZEBUF_TIMER];
        private static byte[] SerBuf_MONOS = new byte[SIZEBUF_MONOS];
        private static byte[] SerBuf_CONTA = new byte[SIZEBUF_CONTA];
        private static byte[] SerBuf_SETRSET = new byte[SIZEBUF_SETRSET];
        private static byte[] SerBuf_VERSIONE = new byte[SIZEBUF_VERSIONE];
        private static byte[] SerBuf_STATO_DSA = new byte[SIZEBUF_STATO_DSA];
        private static byte[] SerBuf_CHKSUM = new byte[SIZEBUF_CHKSUM];
        private static byte[] SerBuf_VAR_PLC = new byte[SIZEBUF_VAR_PLC];
        private static byte[] SerBuf_VAR_QUO = new byte[SIZEBUF_VAR_QUO];
        private static byte[] SerBuf_MAPPATURA = new byte[SIZEBUF_MAPPATURA];
        private static byte[] SerBuf_READ_ADC = new byte[SIZEBUF_READ_ADC];
        private static byte[] SerBuf_STRUTTURE = new byte[SIZEBUF_STRUTTURE];
        private static byte[] SerBuf_WRITE_PVM = new byte[SIZEBUF_WRITE_PVM];
        private static byte[] SerBuf_SENDEFFE = new byte[SIZEBUF_SENDEFFE];
        private static byte[] SerBuf_SENDCHAR = new byte[SIZEBUF_SENDCHAR];
        private static byte[] SerBuf_WRITE_BIT = new byte[SIZEBUF_WRITE_BIT];
        private static byte[] SerBuf_WRITE_OUT = new byte[SIZEBUF_WRITE_OUT];

        //variabili iSendData
        private static byte iSend_ch, iSend_ch1, iSend_ch2;	// appoggio per carattere
        private static byte iSend_Stato;		// segmento da eseguire al giro attuale
        private static byte iSend_Conta;  		// Contatore errori di protocollo
        private static byte iSend_cSerBuf;		// Puntatore al buffer dati
        private static long iSend_Clock;		// Contatore per timeout

        //variabili iRecData
        private static byte iRec_ch;			// Appoggio per carattere letto
        private static byte iRec_PrecChar;		// Carattere letto precedentemente
        private static byte iRec_Stato;		// Punto in cui si trova la ricezione
        private static byte iRec_Conta;  		// Contatore di passaggi (per gestire gli errori)
        private static byte iRec_cSerBuf;		// Contatore per puntatore buffer dati
        private static byte iRec_iDato;		// Appoggio per primo BYTE (la lettera di richiesta del protocollo) 
        private static long iRec_Clock;		// Contatore di passaggi per timeout 

        private static SERSTRU pSerTask;
        internal static SERSTRU SerBack
        {
            get { return pSerTask; }
            set { pSerTask = value; }
        }

        private static LINKSTRU pDataLink;
        internal static LINKSTRU SerDataLink
        {
            get { return pDataLink; }
            set { pDataLink = value; }
        }

        private static SDSA pSDsa;
        internal static SDSA SerSDsa
        {
            get { return pSDsa; }
            set { pSDsa = value; }
        }

        private static SERPAR pSPar; 
        internal static SERPAR ParDataBase
        {
            get { return pSPar; }
        }

        #endregion 

        #region Esecuzione

        private static bool comunicationOn = false;
        private static bool exitRequested = false;

        internal static void StartComunication()
        {
            if (comunicationOn)
                return;

            DeviceEvents.invokeDeviceConnectionStarted();

            if (!ComManager.openComPort())
            {
                DeviceEvents.invokeDeviceErrorEvent(new DeviceError("Impossibile aprire la porta COM", new Exception(), 101));
                return;
            }

            initComunication();
        }

        internal static void CloseComunication()
        {
            exitRequested = true;
            //Global.ComStatus = Global.ComunicationStatusFlag.Paused;
        }

        internal static bool TaskAttivo(Tasks task)
        {
            return pSerTask.Task[(byte)task].Dato != 0;
        }

        public static int loopCounter = 0;
        private static int timeOutCounts = 0;
        private static Exception lastEx;

        private static void initComunication()
        { 
            if (testDevice())
            {
                comunicationOn = true;
                Global.ComStatus = Global.ComunicationStatusFlag.Running;

                DeviceData.startDataManager(); 

                DeviceEvents.invokeDeviceConnected();

                DeviceInterface.AttivaTask(Tasks.TASK_STATO_DSA);
                DeviceInterface.AttivaTask(Tasks.TASK_READ_ADC);
                DeviceInterface.AttivaTask(Tasks.TASK_MSG_PLC); 

                while (timeOutCounts < 3)
                    try
                    {
                        while (!exitRequested) { LoopSer(); timeOutCounts = 0; Global.Breathe(); }
                    }
                    catch (TimeoutException tEx)
                    {
                        timeOutCounts++;
                        lastEx = tEx;
                    }
                    catch (Exception ex)
                    {
                        lastEx = ex;
                        break;
                    } 

                DeviceInterface.DisattivaTask(Tasks.TASK_STATO_DSA);
                DeviceInterface.DisattivaTask(Tasks.TASK_READ_ADC);
                DeviceInterface.DisattivaTask(Tasks.TASK_MSG_PLC);

                if (!exitRequested) // Sono uscito dopo un errore.
                {
                    comunicationOn = false; 
                    ComManager.closeComPort();
                    Global.ComStatus = Global.ComunicationStatusFlag.Off;

                    if (timeOutCounts == 3)
                        DeviceEvents.invokeDeviceErrorEvent(new DeviceError(string.Empty, lastEx, 200)); // Errore TimeOut
                    else
                        DeviceEvents.invokeDeviceErrorEvent(new DeviceError(string.Empty, lastEx, 205)); // Errore generico 

                    return;
                }
            }
            else
            {
                //ComManager.clearBuffers();
                ComManager.closeComPort();
                Global.ComStatus = Global.ComunicationStatusFlag.Off;  
                return;
            }

            //ComManager.clearBuffers();
            ComManager.closeComPort();
            Global.ComStatus = Global.ComunicationStatusFlag.Off;
            DeviceEvents.invokeDeviceDisconnected();
        }

        ////////////////////////////////////////////////////////////////
        // Gestione protocollo a basso livello -----------------------------------------------------------------------------
        // Scandisce la lista dei pacchetti da ricevere o inviare ed esegue le funzioni
        // iRecData per ricevere o iSendData per inviare
        // NOTA: la posizione 0 della struttura è riservata ai pacchetti da spedire, quindi quando ci si trova in ricezione
        // pSerTask->Numero ciclo con valori da 1 a MAXSERTASK, se c'è qualcosa da spedire pSerTask->Numero viene forzato a 0
        internal static void LoopSer()
        { 
            if (pSerTask.Attivo == 0) return;  	// Se non attivo (SerTask=0) non esegue routine ed esce   

            // Guarda se c'è qualcosa da spedire, se si dagli la precedenza
            if ((pSerTask.SerFlag != 0) & (pSerTask.Task[(byte)Tasks.TASK_SEND].Dato != 0))  //SerFlag = 1: non ho nulla da fare, SerFlag = 0: sono occupato
                pSerTask.Numero = 0;
            if ((pSerTask.Task[pSerTask.Numero].Dato != 0) || (pSerTask.SerFlag == 0)) // Se c'è una richiesta, o se ne stavi processando una
            {
                if (pSerTask.Task[pSerTask.Numero].Tipo != 0)		  // Se il tipo e Receive ricevi
                {
                    if (iRecData(pSerTask.Numero))		// spedisci pacchetto
                        pSerTask.Numero++;            	// quando hai finito incrementa contatore lista
                }
                else // Se c'è una richiesta di trasmissione
                {
                    if (iSendData(pSerTask.Numero)) 	// invia pacchetto
                        pSerTask.Numero++;		        // incrementa contatore lista
                }
            }
            else
            {
                pSerTask.Numero++;		// se non hai niente da fare 
                pSerTask.SerFlag = 1; 	// Incrementa contatore lista alla ricerca di qualcosa da fare
            }

            if (pSerTask.Numero > MAXSERTASK - 1) pSerTask.Numero = 1; // quando il contatore della lista arriva in fondo, ricomincia
        }

        // gestisce le stringhe di protocollo in trasmissione (formato <lettera><dati>) 
        // la variabile Stato definisce quale segmento della routine deve essere eseguito al giro attuale
        // NOTA: il buffer da spedire deve essere gia del formato del protocollo, con la lettera di richiesta
        // come primo carattere e n.byte da spedire in .Dimens
        private static bool iSendData(int Num)
        {
            byte sendchar = 0;
            if (pSerTask.SerFlag != 0)		// Inizializzazione variabili statiche
            {
                iSend_ch = 0;					// la prima volta che esegui questa richiesta
                iSend_Stato = 0;
                iSend_Conta = 0;
                iSend_cSerBuf = 0;
                iSend_Clock = 0L;
                pSerTask.SerFlag = 0;
            }
            if (iSend_Conta > 10)			  // Se si è verificato un errore di protocollo (non timeout) per la decima volta consecutiva
            {
                pSerTask.SerErr = ERRCOM;		// invia un '#' ed esci segnalando un errore di protocollo ERRCOM
                pSerTask.SerFlag = 1;
                sendchar = 0x23;  

                ComManager.sendData(sendchar); 

                pSerTask.Send = 0;
                return false;
            }
            if (iSend_ch == '#')						// Se ricevi un '#' resetta tutto ed esci 
            {
                pSerTask.SerErr = ERRCOM;
                pSerTask.SerFlag = 1;
                pSerTask.Send = 0;
                return false;
            }
            switch (iSend_Stato)
            {
                case 0:

                    try
                    {
                        iSend_ch = pSerTask.Task[Num].Buf[iSend_cSerBuf];    // invia valore letto da buffer
                        ComManager.sendData(iSend_ch);  
                        iSend_Stato = 1;
                    }
                    catch { }

                    break;

                case 1:
                    iSend_ch1 = ComManager.reciveByte();  
                    iSend_Clock = 0L;
                    if (iSend_ch == iSend_ch1)			// se l'eco è giusto
                    {
                        pSerTask.SerErr = 0;			// setta a NOERR lo stato degli errori
                        if (iSend_ch == '%')			// se il carattere inviato è un '%'
                        {
                            pSerTask.Task[Num].Dato = 0;						// metti a 0 la richiesta (così non la ripeti)
                            pSerTask.SerFlag = 1;								// setta flag linea libera
                            pSerTask.Task[Num].BufSize = iSend_cSerBuf;			// setta lunghezza buffer nella variabile apposita
                            pSerTask.Send = 0;								// resetta flag di spedizione in corso
                            return true;
                        }
                        iSend_Stato = 0;											// torna al punto 2
                        iSend_cSerBuf++;										// e incrementa puntatore al buffer dei dati
                        break;
                    }
                    else															// se l'eco è sbagliato	  
                    {
                        sendchar = 0x24;  //'$' 
                        ComManager.sendData(sendchar);  
                        iSend_Stato = 2;
                        break;
                    }

                case 2:
                    iSend_ch2 = ComManager.reciveByte();   

                    iSend_Clock = 0L;
                    if (iSend_ch2 != '$')				// se l'eco non era un '$'
                    {
                        iSend_Conta++;				// incrementa contatore errori di protocollo
                        sendchar = 0x24;  //'$'
                        ComManager.sendData(sendchar);  
                        break;
                    }
                    iSend_Stato = 1;					// se eco = '$' torna al punto 1
                    break;
            }

            if (iSend_Clock >= 300)			    // se timeout
            {
                pSerTask.SerErr = TIMEOUT;			// setta errore come TIMEOUT
                pSerTask.SerFlag = 1;			    	// setta flag di linea libera 
                pSerTask.Task[Num].BufSize = 0;      // dimensioni buffer =0;
                pSerTask.Send = 0;				    // resetta stato trasmissione 
                sendchar = 0x23; //'#'
                ComManager.sendData(sendchar);  
                return true; 
            }

            return false; 
        }

        /// <summary>
        /// 28-05-2011 
        /// </summary>
        internal static void DisattivaLoopSer()
        {
            pSerTask.Attivo = 0;
        }

        internal static void AttivaLoopSer()
        {
            pSerTask.Attivo = 1;
        }

        // gestisce le stringhe di protocollo in ricezione (formato <lettera>&<dati>&) 
        // la variabile Stato definisce quale segmento della routine deve essere eseguito al giro attuale
        private static bool iRecData(int Num)
        {
            byte sendchar = 0;

            if (pSerTask.SerFlag != 0)		// Inizializzazione variabili statiche quando 
            {
                iRec_ch = 0;					// è la prima volta che esegui un nuovo pacchetto
                iRec_Stato = 0;
                iRec_Conta = 0;
                iRec_cSerBuf = 0;
                iRec_Clock = 0L;
                pSerTask.SerFlag = 0;
                iRec_iDato = pSerTask.Task[Num].Dato;
                iRec_PrecChar = 0;
            }

            if (iRec_Conta > 10)						// Se è la decima volta consecutiva che c'è uno scambio di $
            {
                pSerTask.SerErr = ERRCOM;            // esce dal ciclo con un errore (ERRCOM)
                pSerTask.SerFlag = 1;    			// e invia un '#' al DSA per annullare
                pSerTask.Task[Num].BufSize = 0;
                sendchar = 0x23;  //'#'

                ComManager.sendData(sendchar); 
                return false;
            }

            if (iRec_ch == '#')
            {
                pSerTask.SerErr = ERRCOM;			// Se ricevi un '#' dal DSA 
                pSerTask.SerFlag = 1;				// Resetta questa richiesta ed esci
                return true;						// con un codice d'errore
            }

            switch (iRec_Stato)
            {
                case 0:
                    if (iRec_iDato == 0)					// se la richiesta è nulla 
                    {
                        pSerTask.SerFlag = 1;		// esci come niente sia successo
                        return true;
                    }

                    ComManager.sendData(iRec_iDato); 
                    iRec_Stato = 1;						// Predisponiti per la ricezione dell'echo
                    break;

                case 1:

                    iRec_ch = ComManager.reciveByte();  

                    if (iRec_ch != iRec_iDato)					// Se l'echo è arrivato me è sbagliato
                    {
                        sendchar = 0x24;  //'$' 
                        ComManager.sendData(sendchar);  
                        iRec_Stato = 3;					// e al prossimo giro esegui la procedura d'errore 
                        iRec_Conta++;					// per il $
                        iRec_Clock = 0L;
                        break;
                    }

                    sendchar = 0x26; 
                    ComManager.sendData(sendchar);   

                    iRec_Clock = 0L;
                    iRec_Stato = 2;						// e predisponiti a ricevere i dati	  
                    break;

                case 2:

                    iRec_ch = ComManager.reciveByte();   
                    iRec_Clock = 0;
                    if (iRec_ch == '$')					// Se ricevi un '$'
                    {
                        sendchar = 0x24;  //'$' 
                        ComManager.sendData(sendchar);  
                        iRec_PrecChar = 0; 
                        iRec_Conta++;					// incrementa contatore errore 
                        break;
                    }

                    if (iRec_ch == '&')					// se come dato arriva un '&'
                    { 
                        pSerTask.Task[Num].Buf[iRec_cSerBuf++] = iRec_PrecChar;
                        pSerTask.SerFlag = 1;									// setta flag di fine stringa
                        pSerTask.Task[Num].BufSize = iRec_cSerBuf;       // carica variabile con lunghezza buffer
                    
                        pSerTask.Task[Num].Buf[iRec_cSerBuf++] = 0;
                      									// elabora stringa ricevuta (forsa lo farà altrove)
                        if (pSerTask.Task[Num].Repeat == 0)							// se il flag Repeat è falso metti a 0 la richiesta
                            pSerTask.Task[Num].Dato = 0;

                        pSerTask.SerErr = 0;	//noerr // setta stato errori con NOERR (nessun errore)
                        return true;										// esci con TRUE per avvisare LoopSer che hai finito
                    }
                    if (iRec_cSerBuf + 1 == pSerTask.Task[Num].BufMax)				// Se il numero di caratteri eccede le dimensioni del buffer
                    {
                        pSerTask.SerErr = ERRCOM;            					// esce dal ciclo con un errore (ERRCOM)
                        pSerTask.SerFlag = 1;    								// e invia un '#' al DSA per darglela sù
                        pSerTask.Task[Num].BufSize = 0;
                        sendchar = 0x23; //'#

                        ComManager.sendData(sendchar); 
                        return false;
                    }

                    if (iRec_PrecChar != 0) 
                        pSerTask.Task[Num].Buf[iRec_cSerBuf++] = iRec_PrecChar;

                    iRec_PrecChar = iRec_ch;					// metti il carattere letto nella variabile d'appoggio

                    ComManager.sendData(iRec_ch);  

                    iRec_Conta = 0; 			// resetta contatore errori
                    iRec_Clock = 0L;			// resetta contatore timeout
                    pSerTask.SerErr = 0;		// set stato errori con NOERR (nessun errore)
                    break;

                case 3:
                    iRec_ch = ComManager.reciveByte();    
                    if (iRec_ch != '$')					// se il carattere che ricevi è diverso da '$'
                    {
                        iRec_Conta++;					// incrementa contatore errori 
                        sendchar = 0x24;  //'$

                        ComManager.sendData(iRec_ch);  
                        break;
                    } 
                    iRec_Stato = 0;						// se l'eco ricevuto è un '$' riprendi dal punto 0
                    break;

                case 4:
                    // se avevi ricevuto un dollaro al punto 2 reinvia l'eco 
                    ComManager.sendData(iRec_ch);   
                    iRec_Stato = 2;						// e torna al punto 2
                    break;
            }

            if (iRec_Clock >= 15) 	// se si è verificato un timeout
            {
                if ((iRec_PrecChar != 0) | (iRec_Clock >= 15))
                {
                    pSerTask.SerErr = TIMEOUT;				// esci segnalando l'errore
                    pSerTask.SerFlag = 1;
                    pSerTask.Task[Num].BufSize = 0;
                    iRec_Clock = 0L;
                    sendchar = 0x23; //#
                    ComManager.sendData(sendchar);    
                }
            }
            return false;	// esce con FALSE per indicare a LoopSer che non ha finito di ricevere il pacchetto
        }
        //fatto
         
        internal static void Calcola(Tasks tag)
        {  
            switch (tag)
            {
                case Tasks.TASK_MSG_PLC: //testato 17/05/11
                    iReadBit(pDataLink.Val_Msg_PLC, SerBuf_MSG_PLC, 7, NMSGPLC);
                    break;

                case Tasks.TASK_QUOTE:       //testato 17/05/11
                    iGetAbsVal(pDataLink.Val_Quote, SerBuf_QUOTE);
                    break;

                case Tasks.TASK_IMPUL:
                    iGetAbsVal(pDataLink.Val_Impul, SerBuf_IMPUL);
                    break;

                case Tasks.TASK_INSEG:
                    iGetAbsVal(pDataLink.Val_Inseg, SerBuf_INSEG);
                    break;

                case Tasks.TASK_INPUT:
                    iReadBit(pDataLink.Val_Input, SerBuf_INPUT, 7, TOTIN);
                    break;

                case Tasks.TASK_OUTPUT:
                    iReadBit(pDataLink.Val_Output, SerBuf_OUTPUT, 7, TOTOU);
                    break;

                case Tasks.TASK_MEMIF:
                    iReadBit(pDataLink.Val_MemIF, SerBuf_MEMIF, 7, TOTUIF);
                    break;

                case Tasks.TASK_MEMUF:
                    iReadBit(pDataLink.Val_MemUF, SerBuf_MEMUF, 7, TOTUIF);
                    break;

                case Tasks.TASK_TIMER:
                    iReadBit(pDataLink.Val_Timer, SerBuf_TIMER, 6, TOTTIM);
                    break;

                case Tasks.TASK_MONOS:
                    iReadBit(pDataLink.Val_Monos, SerBuf_MONOS, 6, TOTMON);
                    break;

                case Tasks.TASK_CONTA:
                    iReadBit(pDataLink.Val_Conta, SerBuf_CONTA, 6, TOTCNT);
                    break;

                case Tasks.TASK_SETRSET:
                    iReadBit(pDataLink.Val_SetRset, SerBuf_SETRSET, 6, TOTSRE);
                    break;

                case Tasks.TASK_VERSIONE:
                    break;

                case Tasks.TASK_STATO_DSA:  //testato 17/05/11
                    iGetStatoDSA(SerBuf_STATO_DSA);
                    break;

                case Tasks.TASK_SPEC_PLC:
                    iGetAbsVal(pDataLink.Val_Spec_PLC, SerBuf_SPEC_PLC);
                    break;

                case Tasks.TASK_VAR_PLC:
                    iReadBit(pDataLink.Val_Var_PLC, SerBuf_VAR_PLC, 7, MAX_VAR_VALORI);
                    break;

                case Tasks.TASK_VAR_QUO:
                    iGetValue(pDataLink.Val_Var, SerBuf_VAR_QUO);
                    break;

                case Tasks.TASK_READ_ADC:
                    iGetAbsVal(pDataLink.Val_Read_ADC, SerBuf_READ_ADC);
                    break;

                default:
                    break;
            } 
        }

        //fatto
        // Legge le stringhe in formato bit 7bit (ogni byte e' mascherato con 0x80 mp1 e' il bit 7(0x40)) 
        private static void iReadBit(byte[] Buf, byte[] SerBuf, byte NumBits, int NumDispositivi)
        {
            int ch = 1;		// variabile d'appoggio per carattere buffer
            int j;    		// contatore che funge da maschera per gli END
            int Cnt = 0;		// contatore buffer dei BYTE relativi ai singoli bit
            int Inc = 0;		// contatore buffer seriale
            int ch1;

            while (ch != 0)
            { 
                ch = SerBuf[Inc++]; 

                if (ch > 0x7F)   						// se un '_' lo salta
                {
                    switch (NumBits)
                    {
                        case 7: j = 0x40; break;
                        case 6: j = 0x20; break;
                        case 5: j = 0x10; break;
                        case 4: j = 0x08; break;
                        case 3: j = 0x04; break;
                        case 2: j = 0x02; break;
                        default:
                        case 1: j = 0x01; break; 
                    } 

                    while (j != 0)						// loop fino a quando j > 0
                    { 
                        ch1 = ch & j; 
                        Buf[Cnt++] = (byte)(ch1 != 0 ? 1 : 0); // se bit alto setta BYTE relativo nel buffer 
                        j >>= 1;				// incrementa contatore e shifta j di un bit a destra
                        if (Cnt >= NumDispositivi) //faccio attenzione a non superare la dimensione del buffer
                        { 
                            j = 0; 
                            ch = 0; 
                        }
                    }
                }
            } 
        }
        // Interpreta le quote 
        private static bool iGetValue(int[] Qu, byte[] SerBuf)
        {
            byte ch; 			// variabile d'appoggio per carattere buffer
            byte i = 0;   		// contatore per array delle quote *Qu[]
            byte Cnt = 0;			// contatore per sottostringhe delle quote all'interno del buffer
            byte Sng = 0;		// flag per il segno
            int Inc = 0;			// contatore generale per il buffer
            int quota = 0;
 
            while (true)
            {
                Global.Breathe();

                ch = SerBuf[Inc++]; // legge un carattere dal buffer

                if (ch != 0 && ch != '_' && ch != '&') 			// se diverso da 0 (fine stringa) e da '_' (separatore tra quote)
                {
                    if (Cnt != 0)						// se non è il primo carattere del buffer (che è il segno)
                    {
                        quota <<= 4;
                        quota += (ch & 0x0F);
                    }
                    else
                        if (ch != 0x8B)
                            Sng = 1;			// se era il primo carattere (cioè il segno) e non è positivo, setta Sng
                    Cnt++;						// incrementa contatore allinterno di una singola quota
                }
                else 							// se è cambiata la quota o è finita la stringa
                {
                    if (Sng != 0)
                        quota *= -1;			// se segno negativo, moltiplica per -1

                    Qu[i] = quota;
                    if (ch == 0)
                        break;					// se ch=0 allora hai finito ed esci
                    Cnt = 0;						// azzera contatore all'interno dei una quota
                    Sng = 0;					// resetta segno
                    quota = 0;
                    i++;						// vai alla quota successiva
                }
            }

            return true;
        }
         
        // interpreta lo stato del DSA letto da un comando di protocollo 'E' e lo scrive in una struttura
        private static bool iGetStatoDSA(byte[] SerBuf)
        {
            byte ch = 1;
            byte[] Buf;
            byte i = 0; 
            byte masch = 0x7f; 

            Buf = new byte[10];

            for (; i < Buf.Length; i++)
                Buf[i] = 0; 

            i = 0; 
            while (true)
            { 
                if (SerBuf[i] == 0)
                    break;

                ch = (byte)(SerBuf[i] & masch); // legge un carattere dal buffer  
                Buf[i] = ch; 
                i++;
            }

            /*
            1-1: teleruttore generale
            1-2: RFID
            1-3: out motoruote
            1-4: out solleva pinze
            1-5: out chiusura pinze
            1-6: emergenza

            2-1: abiliata asse X  --> Se sto muovendo (4.1 - 4.2 per direzione)
            2-2: msg errore X1
            2-3: msg errore X2
            2-4: abiliata asse Y
            2-5: msg errore Y1
            2-6: msg errore Y2
            2-7: (velocità lenta = 1)

            3-1: sensore presenza letto
            3-2: f.c. pinza chiusa    --> Stato pinza
            3-3: alimentazione da rete
            3-4: presenza mano dx
            3-5: presenza mano sx
            3-6: movimento libero
            3-7: movimento una mano

            4-1: marcia avanti  
            4-2: marcia indietro
            4-3: chiusura pinza pulsante
            4-4: apertura pinza pulsante
            4-5: salita pinza pulsante
            4-6: discesa pinza pulsante
            */

            DeviceStatusFlag.Teleruttore = ((Buf[0] & (byte)1) != 0);
            DeviceStatusFlag.RFID = ((Buf[0] & (byte)2) != 0);
            DeviceStatusFlag.OutMotoruote = ((Buf[0] & (byte)4) != 0);
            DeviceStatusFlag.OutSollevaPinze = ((Buf[0] & (byte)8) != 0);
            DeviceStatusFlag.OutChiusuraPinze = ((Buf[0] & (byte)16) != 0);
            DeviceStatusFlag.Emergenza = ((Buf[0] & (byte)32) != 0);

            DeviceStatusFlag.AsseXAbilitato = ((Buf[1] & (byte)1) != 0);
            DeviceStatusFlag.ErroreAsseX1 = ((Buf[1] & (byte)2) != 0);
            DeviceStatusFlag.ErroreAsseX2 = ((Buf[1] & (byte)4) != 0);
            DeviceStatusFlag.AsseYAbilitato = ((Buf[1] & (byte)8) != 0);
            DeviceStatusFlag.ErroreAsseY1 = ((Buf[1] & (byte)16) != 0);
            DeviceStatusFlag.ErroreAsseY2 = ((Buf[1] & (byte)32) != 0);
            DeviceStatusFlag.MuoviInLento = ((Buf[1] & (byte)64) != 0);

            DeviceStatusFlag.LettoPresente = ((Buf[2] & (byte)1) != 0);
            DeviceStatusFlag.FcPinza = ((Buf[2] & (byte)2) != 0);
            DeviceStatusFlag.AlimRete = ((Buf[2] & (byte)4) != 0);
            DeviceStatusFlag.PresenzaManoDx = ((Buf[2] & (byte)8) != 0);
            DeviceStatusFlag.PresenzaManoSx = ((Buf[2] & (byte)16) != 0);
            DeviceStatusFlag.MovimentoLibero = ((Buf[2] & (byte)32) != 0);
            DeviceStatusFlag.UnaMano = ((Buf[2] & (byte)64) != 0);

            DeviceStatusFlag.MarciaAvanti = ((Buf[3] & (byte)1) != 0);
            DeviceStatusFlag.MarciaIndietro = ((Buf[3] & (byte)2) != 0);
            DeviceStatusFlag.ChiusuraPinzaInput = ((Buf[3] & (byte)4) != 0);
            DeviceStatusFlag.AperturaPinzaInput = ((Buf[3] & (byte)8) != 0);
            DeviceStatusFlag.SalitaPinzaInput = ((Buf[3] & (byte)16) != 0);
            DeviceStatusFlag.DiscesaPinzaInput = ((Buf[3] & (byte)32) != 0);

            PorterFunctions.setPresenzaLetto(DeviceStatusFlag.LettoPresente);
              
            return true;
        }

        //fatto
        // Legge un valore senza segno
        private static bool iGetAbsVal(int[] Qu, byte[] SerBuf)
        {
            int Inc = 0;
            int i = 0; 
            int Value = 0;
            byte ch = 0; 

            while (true)
            {
                //Thread.Sleep(Constants.THREAD_SLEEP_SHORT_INTERVAL); 

                ch = SerBuf[Inc++]; // legge un carattere dal buffer

                if (ch != 0 && ch != '_' && ch != '&') 			// se diverso da 0 (fine stringa) e da '_' (separatore tra valori)
                { 
                    Value <<= 4;
                    Value += (ch & 0x0F); 
                }
                else 							// se è cambiato il valore o è finita la stringa
                { 
                    Qu[i] = Value;

                    if (ch == 0)
                        break;					// se ch=0 allora hai finito ed esci

                    Value = 0;
                    i++;						// vai al valore successivo
                }
            }

            return true;
        }

        //fatto
        // ----------------------------------------------------------------------------------------
        internal static void InsTaskDSA(Tasks Task)
        {
            switch (Task)
            {
                case Tasks.TASK_MSG_PLC:
                    InsSerTask(Tasks.TASK_MSG_PLC, 1, TaskTags.TAG_MSG_PLC, SerBuf_MSG_PLC, SIZEBUF_MSG_PLC, 1); 
                    break;
                case Tasks.TASK_SPEC_PLC:
                    InsSerTask(Tasks.TASK_SPEC_PLC, 1, TaskTags.TAG_SPEC_PLC, SerBuf_SPEC_PLC, SIZEBUF_SPEC_PLC, 1);
                    break;
                case Tasks.TASK_QUOTE:
                    InsSerTask(Tasks.TASK_QUOTE, 1, TaskTags.TAG_QUOTE, SerBuf_QUOTE, SIZEBUF_QUOTE, 1);
                    break;
                case Tasks.TASK_IMPUL:
                    InsSerTask(Tasks.TASK_IMPUL, 1, TaskTags.TAG_IMPUL, SerBuf_IMPUL, SIZEBUF_IMPUL, 1);
                    break;
                case Tasks.TASK_INSEG:
                    InsSerTask(Tasks.TASK_INSEG, 1, TaskTags.TAG_INSEG, SerBuf_INSEG, SIZEBUF_INSEG, 1);
                    break;
                case Tasks.TASK_READ_ADC:
                    InsSerTask(Tasks.TASK_READ_ADC, 1, TaskTags.TAG_READ_ADC, SerBuf_READ_ADC, SIZEBUF_READ_ADC, 1);
                    break;
                case Tasks.TASK_INPUT:
                    InsSerTask(Tasks.TASK_INPUT, 1, TaskTags.TAG_INPUT, SerBuf_INPUT, SIZEBUF_INPUT, 1);
                    break;
                case Tasks.TASK_OUTPUT:
                    InsSerTask(Tasks.TASK_OUTPUT, 1, TaskTags.TAG_OUTPUT, SerBuf_OUTPUT, SIZEBUF_OUTPUT, 1);
                    break;
                case Tasks.TASK_MEMIF:
                    InsSerTask(Tasks.TASK_MEMIF, 1, TaskTags.TAG_MEMIF, SerBuf_MEMIF, SIZEBUF_MEMIF, 1);
                    break;
                case Tasks.TASK_MEMUF:
                    InsSerTask(Tasks.TASK_MEMUF, 1, TaskTags.TAG_MEMUF, SerBuf_MEMUF, SIZEBUF_MEMUF, 1);
                    break;
                case Tasks.TASK_TIMER:
                    InsSerTask(Tasks.TASK_TIMER, 1, TaskTags.TAG_TIMER, SerBuf_TIMER, SIZEBUF_TIMER, 1);
                    break;
                case Tasks.TASK_MONOS:
                    InsSerTask(Tasks.TASK_MONOS, 1, TaskTags.TAG_MONOS, SerBuf_MONOS, SIZEBUF_MONOS, 1);
                    break;
                case Tasks.TASK_CONTA:
                    InsSerTask(Tasks.TASK_CONTA, 1, TaskTags.TAG_CONTA, SerBuf_CONTA, SIZEBUF_CONTA, 1);
                    break;
                case Tasks.TASK_SETRSET:
                    InsSerTask(Tasks.TASK_SETRSET, 1, TaskTags.TAG_SETRSET, SerBuf_SETRSET, SIZEBUF_SETRSET, 1);
                    break;
                case Tasks.TASK_VERSIONE:
                    InsSerTask(Tasks.TASK_VERSIONE, 1, TaskTags.TAG_VERSIONE, SerBuf_VERSIONE, SIZEBUF_VERSIONE, 0);
                    break;
                case Tasks.TASK_STATO_DSA:
                    InsSerTask(Tasks.TASK_STATO_DSA, 1, TaskTags.TAG_STATO_DSA, SerBuf_STATO_DSA, SIZEBUF_STATO_DSA, 1);
                    break;
                case Tasks.TASK_CHKSUM:
                    InsSerTask(Tasks.TASK_CHKSUM, 1, TaskTags.TAG_CHKSUM, SerBuf_CHKSUM, SIZEBUF_CHKSUM, 1);
                    break;
                case Tasks.TASK_VAR_PLC:
                    InsSerTask(Tasks.TASK_VAR_PLC, 1, TaskTags.TAG_VAR_PLC, SerBuf_VAR_PLC, SIZEBUF_VAR_PLC, 1);
                    break;
                case Tasks.TASK_VAR_QUO:
                    InsSerTask(Tasks.TASK_VAR_QUO, 1, TaskTags.TAG_VAR_QUO, SerBuf_VAR_QUO, SIZEBUF_VAR_QUO, 1);
                    break;
                case Tasks.TASK_MAPPATURA:
                    InsSerTask(Tasks.TASK_MAPPATURA, 1, TaskTags.TAG_MAPPATURA, SerBuf_MAPPATURA, SIZEBUF_MAPPATURA, 1);
                    break;
            } 
        }
        //fatto
        private static void InsSerTask(Tasks Task, byte Tipo, TaskTags Dato, IntPtr Buf, short BufMax, byte Repeat)
        {
            if (pSerTask.Task == null)
                pSerTask.Initialize();

            pSerTask.Attivo = 0;					    // Sospendi il task
            pSerTask.Task[(byte)Task].Tipo = Tipo;			// inserisci tipo (TRUE ricevi, FALSE invia)
            pSerTask.Task[(byte)Task].Dato = (byte)Dato;			// inserisci la lettera del protocollo
            //pSerTask.Task[Task].Buf=Buf;			    // inserisci l'indirizzo del buffer
            pSerTask.Task[(byte)Task].BufMax = BufMax;		// Inserisci le dimensioni massime del buffer
            pSerTask.Task[(byte)Task].Repeat = Repeat;		// TRUE ripete la richiesta continuamente, FALSE fai la richiesta una sola volta

            if (Tipo == 0) 
                pSerTask.Send = 1;		        	// se tipo invia (Tipo=FALSE) setta flag invio dati 

            pSerTask.Attivo = 1;					// Riavvia il task
        }

        private static void InsSerTask(Tasks Task, byte Tipo, TaskTags Dato, byte[] Buf, short BufMax, byte Repeat)
        {
            if (pSerTask.Task == null)
                pSerTask.Initialize();

            pSerTask.Attivo = 0;					    // Sospendi il task
            pSerTask.Task[(byte)Task].Tipo = Tipo;			// inserisci tipo (1 ricevi, 0 invia)
            pSerTask.Task[(byte)Task].Dato = (byte)Dato;			// inserisci la lettera del protocollo
            pSerTask.Task[(byte)Task].Buf = Buf;			    // inserisci l'indirizzo del buffer
            pSerTask.Task[(byte)Task].BufMax = BufMax;		// Inserisci le dimensioni massime del buffer
            pSerTask.Task[(byte)Task].Repeat = Repeat;		// TRUE ripete la richiesta continuamente, FALSE fai la richiesta una sola volta

            if (Tipo == 0)
            {
                pSerTask.Send = 1;		        	// se tipo invia (Tipo=FALSE) setta flag invio dati
                iSend_Stato = 0;
            }

            pSerTask.Attivo = 1;					// Riavvia il task
        }

        //fatto
        internal static void SerTaskResBuf(byte Task) { pSerTask.Task[Task].BufSize = 0; }

        //fatto
        internal static void DelSerTask(Tasks Task) 
        {
            pSerTask.Task[(byte)Task].Dato = 0;

            for (int i = 0; i< pSerTask.Task[(byte)Task].Buf.Length ; i++)
                pSerTask.Task[(byte)Task].Buf[i] = 0; 
        }

        //fatto
        internal static void SendSerTask(byte[] SerBuf)
        {
            InsSerTask(Tasks.TASK_SEND, 0, TaskTags.TAG_SEND, SerBuf, 0, 0);	// Inserisce richiesta di spedizione
        }

        //fatto
        ///////////////////////////////////////////////////////////////////////
        // PREPARA NEL BUFFER LA STRINGA X DSA Fnnh_nnh_nnh_nnh_nnh_nnh_nnh_nnh_nnh%
        internal static bool SendEffe(byte Val, byte Pos)  //Val = n.FUNZIONE RICHIESTA (80..FF )
        {
            while (pSerTask.Send != 0)  //attesa di liberazione task 
            {
                if (pSerTask.Attivo == 0) return false;  //se loopser disattivo esco
                if (pSerTask.SerErr == ERRCOM) return false;  //se ho errore seriale esco
                Global.Sleep(10);
            }

            iSendEffe(SerBuf_SENDEFFE, Val, Pos);		//Pos = 0..8 (DOVE METTERE LA FUNZIONE vAL)
            SendSerTask(SerBuf_SENDEFFE);	//INDIRIZZA SerBuf_SENDEFFE
            return true;
        } 

        private static void iSendEffe(byte[] SerBuf, byte Val, byte Pos)
        {
            int i;             //SCRIVE NEL BUFFER INDIRIZZATO 'F' ,
            int Inc = 1;         //SCRIVE 80h SULLE POSIZIONI ESCLUSE
            //SCRIVE vAL NELLA POSIZIONE RICHIESTA
            //METTE '%' IN FONDO

            for (i = 0; i < SerBuf.Length; i++)
                SerBuf[i] = 0x00;

            SerBuf[0] = (byte)'F';
            if (Pos == 0)
                SerBuf[Inc++] = (byte)(Val + 0x80);
            else
            {
                for (i = 0; i <= Pos; i++)
                {
                    if (i == Pos)
                        SerBuf[Inc] = (byte)(Val + 0x80);
                    else
                        SerBuf[Inc] = (byte)(SerBuf[Inc] | 0x80);
                    Inc++;
                }
            }
            SerBuf[Inc++] = (byte)'%';
            return;
        }

        /// <summary>
        /// Invio del carattere j al DSA (Richiesta di start)
        /// </summary>
        /// <returns>Torna true se OK, false se KO.</returns>
        internal static bool SendStart()
        {
            SerBuf_SENDCHAR = new byte[SIZEBUF_SENDCHAR];

            //Creo il buffer
            SerBuf_SENDCHAR[0] = (byte)'j';
            SerBuf_SENDCHAR[1] = 0x84;
            SerBuf_SENDCHAR[2] = (byte)'%';

            while (pSerTask.Send != 0)  //attesa di liberazione task 
            {
                if (pSerTask.Attivo == 0) return false;  //se loopser disattivo esco
                if (pSerTask.SerErr == ERRCOM) return false;  //se ho errore seriale esco
                Global.Sleep(10);
                if (LINKSTRU.Connesso == 0) return false;
            }

            SendSerTask(SerBuf_SENDCHAR);

            return true;
        }

        /// <summary>
        /// //////////////////////
        /// </summary>
        /// <returns></returns>
        internal static bool SendStop()
        {
            SerBuf_SENDCHAR = new byte[SIZEBUF_SENDCHAR];

            //Creo il buffer
            SerBuf_SENDCHAR[0] = (byte)'j';
            SerBuf_SENDCHAR[1] = 0x85;
            SerBuf_SENDCHAR[2] = (byte)'%';

            while (pSerTask.Send != 0)  //attesa di liberazione task 
            {
                if (pSerTask.Attivo == 0) return false;  //se loopser disattivo esco
                if (pSerTask.SerErr == ERRCOM) return false;  //se ho errore seriale esco
                Global.Sleep(10);
                if (LINKSTRU.Connesso == 0) return false;
            }
            SendSerTask(SerBuf_SENDCHAR);

            return true;
        }

        /// <summary>
        /// Esce da tutti i cicli in corso.
        /// </summary>
        /// <returns></returns>
        internal static bool SendEscEsci()
        {
            SerBuf_SENDCHAR = new byte[SIZEBUF_SENDCHAR];

            //Creo il buffer
            SerBuf_SENDCHAR[0] = (byte)'j';
            SerBuf_SENDCHAR[1] = 0x1B;
            SerBuf_SENDCHAR[2] = (byte)'%';

            int Count = 0;
            while (pSerTask.Send != 0)  //attesa di liberazione task 
            {
                if (pSerTask.Attivo == 0) 
                    return false;  //se loopser disattivo esco
                if (pSerTask.SerErr == ERRCOM) 
                    return false;  //se ho errore seriale esco

                Global.Sleep(10);

                if (Count > 500)
                    return false;
                else
                    Count++;

                if (LINKSTRU.Connesso == 0) 
                    return false;
            }

            SendSerTask(SerBuf_SENDCHAR);

            if (SendEffe(0, 0))  //fermo i cicli di polling generici 
                for (int IndiceAsse = 1; IndiceAsse <= MAXASS; IndiceAsse++)
                    if (!SendEffe(0, (byte)IndiceAsse))  // ciclo di polling specifico x primo asse
                        return false;  

            return true;
        } 

        internal static bool ChiediVer()
        {   
            if (DevProto.SerSDsa.CPolling != 0)
                if (!SendEscEsci())
                    return false;

            int Tmr = 0;
            while (pSerTask.SerFlag == 0)
            {
                Global.Sleep(10);
                Tmr++;
                if (Tmr > 50) 
                    return false; 
            }

            pDataLink.LastErr = eComError.NOERR;
            pSerTask.Attivo = 0;
            pSerTask.Send = 1;  

            byte[] SendBuff = new byte[2];

            //Creo il buffer di scrittura
            SendBuff[0] = (byte)'V';
            SendBuff[1] = (byte)'&';

            ComManager.sendData(SendBuff[0]); 
            byte ReadEcho = 0x00;

            ReadEcho = ComManager.reciveByte(); 

            if (ReadEcho != (byte)'V')
                return false;

            ComManager.sendData(SendBuff[1]); 

            byte Readed = 0;
            //Preparo il buffer di ricezione
            byte[] VerBuff = new byte[500];

            //Azzero i valori
            for (int i = 0; i < 500; i++)
                VerBuff[i] = 0;

            int count = 0;
            Readed = ComManager.reciveByte();  

            //Leggo la versione
            while ((Readed != (byte)'&') && count < 500)
            {
                if (Readed == (byte)'#')
                    return false;

                if (Readed == (byte)'$')
                    return false;

                VerBuff[count] = Readed;

                ComManager.sendData(Readed);  

                count++;

                Readed = ComManager.reciveByte();   
            }

            string VerApp = string.Empty;

            for (int i = 0; i < 500; i++)
                if (VerBuff[i] != 0)
                    VerApp += ((char)VerBuff[i]).ToString();

            VerApp = VerApp.Replace('_', '.');

            //Aggiorno la stringa di versione
            LINKSTRU.Version = VerApp;  

            pSerTask.Attivo = 1;
            pSerTask.Send = 0;
            return true;
        } 

        internal static bool SendTasto(byte Tasto)
        {
            SerBuf_SENDCHAR = new byte[SIZEBUF_SENDCHAR];

            //Creo il buffer
            SerBuf_SENDCHAR[0] = (byte)'j';
            SerBuf_SENDCHAR[1] = Tasto;
            SerBuf_SENDCHAR[2] = (byte)'%';

            while (pSerTask.Send != 0)  //attesa di liberazione task 
            {
                if (pSerTask.Attivo == 0) return false;  //se loopser disattivo esco
                if (pSerTask.SerErr == ERRCOM) return false;  //se ho errore seriale esco
                Global.Sleep(10);
                if (LINKSTRU.Connesso == 0) return false;
            }

            SendSerTask(SerBuf_SENDCHAR); 
            return true;
        }  

        internal static bool SendStruttura(int strut, int[] values)
        {
            if (pSDsa.Emergenza == 0) return false;
            SendStru((byte)strut, CreaBufferStruttura(values)); //Mando la quota
            return true;
        } 

        internal static bool SendStopPLC()
        { 
            return SendEffe(STOP_PLC, 0);
        }

        internal static bool SendStartPLC()
        { 
            return SendEffe(START_PLC, 0);
        }

        /// <summary>
        /// Metodo di invio uscite al DSA.
        /// Formato: Oxxxxxxxxxx%
        /// Prima si dovrà inviare, con una F, la disabilitazione del PLC.
        /// Ogni x corrisponde a 7 uscite ed assume quindi il valore da 80 a FF.
        /// </summary>
        /// <param name="Uscite"></param>
        /// <returns></returns>
        internal static bool SendUscite(bool[] Uscite)
        {
            byte[] BuffUSCITE = new byte[12];

            BuffUSCITE[0] = (byte)TaskTags.TAG_SETOUT;

            int i = 0;
            int c = 1;

            byte Current = 0x80;

            //Calcolo dei byte
            foreach (bool O in Uscite)
            {
                byte b = 0x00;
                if (i == 0)
                    Current = 0x80;

                if (O)
                {
                    b = 0x01;
                    Current += (byte)(b << i);
                }

                if (i + 1 >= 7)
                {
                    BuffUSCITE[c] = Current;
                    i = 0;
                    c++;
                }
                else
                    i++;
            }

            //Scrivo l'ultimo byte calcolato
            BuffUSCITE[c] = Current;

            //Azzero i byte rimasti
            for (int cc = c + 1; cc <= 10; cc++)
                BuffUSCITE[cc] = 0x80;

            //Aggiungo il carattere '%'
            BuffUSCITE[BuffUSCITE.Length - 1] = (byte)'%';

            SerBuf_WRITE_OUT = BuffUSCITE;

            while (pSerTask.Send != 0)  //attesa di liberazione task 
            {
                if (pSerTask.Attivo == 0) return false;  //se loopser disattivo esco
                if (pSerTask.SerErr == ERRCOM) return false;  //se ho errore seriale esco
                Global.Sleep(10);
                if (LINKSTRU.Connesso == 0) return false;
            }

            SendSerTask(SerBuf_WRITE_OUT); 
            return true;
        }

        internal static bool SendGetContRequest(byte Cont, out int[] Values)
        {
            byte[] Buff = new byte[3];
            Values = new int[SIZEBUF_GET_CNT];

            Buff[0] = (byte)TaskTags.TAG_CNT_PLC;
            Buff[1] = (byte)(Cont + 0x80);
            Buff[2] = (byte)'&';

            int Tmr = 0;

            while (pSerTask.SerFlag == 0)
            {
                Global.Sleep(10);
                Tmr++;
                if (Tmr > 500)
                    return false;
            }
             
            //Sospendo il LoopSer
            pSerTask.Attivo = 0;
            pSerTask.Send = 1;

            Global.Sleep(100);

            ComManager.sendData(Buff[0]); 

            byte Readed = 0x00;

            Readed = ComManager.reciveByte();
            ComManager.sendData(Buff[1]);
            Readed = ComManager.reciveByte();
            ComManager.sendData(Buff[2]);

            byte[] ReaderBuff = new byte[128];
            bool iRet = false;

            for (int Index = 0; Index < 128; Index++)
            {
                Readed = ComManager.reciveByte();
                if (Readed != (byte)'&')
                    ReaderBuff[Index] = Readed;
                else
                {
                    iRet = true;
                    break;
                }
            } 

            Values = new int[2];

            //Riattivo il LoopSer
            pSerTask.Attivo = 1;
            pSerTask.Send = 0;

            if (!iRet)
                return false;

            try { return iGetAbsVal(Values, ReaderBuff); }
            catch
            { 
                return false; 
            } 
            finally
            {
                //Riattivo il LoopSer 
                pSerTask.Attivo = 1;
                pSerTask.Send = 0;
            } 
        }

        private static byte[] CreaBufferStruttura(int[] values)
        {
            byte[] BufferQ = new byte[128];
            int Index = 0;

            for (; Index < 128; Index++)
                BufferQ[Index] = 0x00;

            int IBuffer = 0;
            for (int index = 0; index < values.Length; index++) 
            {
                foreach (byte Bq in CreaBufferQuota(values[index]))
                    BufferQ[IBuffer++] = Bq;

                if (index < values.Length - 1)
                    BufferQ[IBuffer++] = (byte)'_';
            } 

            byte[] iRetBuffer = new byte[IBuffer];

            for (Index = 0; Index < IBuffer; Index++)
                if (BufferQ[Index] != 0x00)
                    iRetBuffer[Index] = BufferQ[Index];
                else
                    break;

            return iRetBuffer;
        }

        private static byte[] CreaBufferQuota(int[] Quote, bool[] ToMove)
        {
            byte[] BufferQ = new byte[128];
            int Index = 0;

            for (; Index < 128; Index++)
                BufferQ[Index] = 0x00;

            int IBuffer = 0;
            for (int IAsse = 0; IAsse < SerSDsa.NAssi; IAsse++)
                if (ToMove[IAsse])
                {
                    foreach (byte Bq in CreaBufferQuota(Quote[IAsse]))
                        BufferQ[IBuffer++] = Bq;

                    if (IAsse < SerSDsa.NAssi - 1)
                        BufferQ[IBuffer++] = (byte)'_';
                }
                else
                {
                    foreach (byte Bq in CreaBufferQuota(SerDataLink.Val_Quote[IAsse]))
                        BufferQ[IBuffer++] = Bq;

                    if (IAsse < SerSDsa.NAssi - 1)
                        BufferQ[IBuffer++] = (byte)'_';
                }

            byte[] iRetBuffer = new byte[IBuffer];

            for (Index = 0; Index < IBuffer; Index++)
                if (BufferQ[Index] != 0x00)
                    iRetBuffer[Index] = BufferQ[Index];
                else
                    break;

            return iRetBuffer;
        }

        private static byte[] CreaWBuffer(int[] Values)
        {
            byte[] BufferQ = new byte[128];
            int Index = 0;

            for (; Index < 128; Index++)
                BufferQ[Index] = 0x00;

            int IBuffer = 0;
            for (int IValue = 0; IValue < Values.Length; IValue++) 
            {
                foreach (byte Bq in CreaBufferQuota(Values[IValue]))
                    BufferQ[IBuffer++] = Bq;

                if (IValue < Values.Length - 1)
                    BufferQ[IBuffer++] = (byte)'_';
            }

            byte[] iRetBuffer = new byte[IBuffer];

            for (Index = 0; Index < IBuffer; Index++)
                if (BufferQ[Index] != 0x00)
                    iRetBuffer[Index] = BufferQ[Index];
                else
                    break;

            return iRetBuffer;
        }

        private static byte[] CreaBufferQuota(int value, int IndiceAsse)
        {
            byte[] BufferQ = new byte[256];
            int Index = 0;

            for (; Index < BufferQ.Length; Index++)
                BufferQ[Index] = 0x00;

            int IBuffer = 0;
            for (int IAsse = 0; IAsse < SerSDsa.NAssi; IAsse++)
                if (IndiceAsse == IAsse)
                {
                    foreach (byte Bq in CreaBufferQuota(value))
                        BufferQ[IBuffer++] = Bq;

                    if (IAsse < SerSDsa.NAssi - 1)
                        BufferQ[IBuffer++] = (byte)'_';
                }
                else
                {
                    foreach (byte Bq in CreaBufferQuota(SerDataLink.Val_Quote[IAsse]))
                        BufferQ[IBuffer++] = Bq;

                    if (IAsse < SerSDsa.NAssi - 1)
                        BufferQ[IBuffer++] = (byte)'_';
                }

            byte[] iRetBuffer = new byte[IBuffer];

            for (Index = 0; Index < IBuffer; Index++)
                if (BufferQ[Index] != 0x00)
                    iRetBuffer[Index] = BufferQ[Index];
                else
                    break;

            return iRetBuffer;
        }

        private static byte[] CreaBufferQuota(int value)
        { 
            int i = 0;
            byte[] Q = new byte[8];

            if (value == 0)
                return new byte[1] { 0x80 };

            while ((value >> (i * 4)) > 0)
            {
                Q[i] = (byte)(((byte)(value >> (i * 4)) & 0x0F) + 0x80);
                i++;
            }

            if (i == 0 && value < 0)
            {
                value *= -1;
                while ((value >> (i * 4) > 0))
                {
                    Q[i] = (byte)(((byte)(value >> (i * 4)) & 0x0F) + 0x80);
                    i++;
                }

                Q[i - 1] += 0x40;
            }

            byte[] QBuff = new byte[i];

            for (int c = i - 1, d = 0; d < QBuff.Length; c--, d++)
                QBuff[d] = Q[c];

            return QBuff;
        }

        /// <summary>
        /// ///////////
        /// </summary>
        /// <param name="Tipo">Numero della struttura</param>
        /// <param name="XBuf">Buffer contenente i valori da mettere nella struttura</param>
        private static void SendStru(byte Tipo, byte[] XBuf)  //W
        {
            while (pSerTask.Send != 0)  //attesa di liberazione task 
            {
                if (pSerTask.Attivo == 0) return;  //se loopser disattivo esco
                if (pSerTask.SerErr == ERRCOM) return;  //se ho errore seriale esco
                Global.Sleep(10);
                if (LINKSTRU.Connesso == 0) return;
            }

            //Creo il buffer
            SerBuf_STRUTTURE = new byte[SIZEBUF_STRUTTURE];

            SerBuf_STRUTTURE[0] = (byte)'W';
            SerBuf_STRUTTURE[1] = (byte)(Tipo + 0x80);
            SerBuf_STRUTTURE[2] = (byte)'_';

            int inc = 3;
            int i = 0;
            for (; i < XBuf.Length; inc++, i++) //Da sistemare 
                if (XBuf[i] == 0x00)
                    break;
                else
                    SerBuf_STRUTTURE[inc] = XBuf[i];  

            SerBuf_STRUTTURE[inc] = (byte)'%'; 

            SendSerTask(SerBuf_STRUTTURE);
        }

        internal static bool SendW(byte Type, int[] Args)
        {
            SendStru(Type, CreaWBuffer(Args));
            return true;
        }

        internal static byte _LastError; 
        /// <summary>
        /// Errori:
        /// 
        /// 0x01: Invio Parametri: Errore creazione struttura dati. 
        /// 0x02: Invio Parametri: Valore del parametro oltre i limiti consentiti.
        /// 0x03: Errore richiesta Versione.
        /// </summary>
        public static byte LastError
        {
            get
            {
                byte pError = _LastError;
                _LastError = 0x00;

                return pError;
            }

            internal set { _LastError = value; }
        } 

        internal static bool testDevice()
        { 
            ComManager.sendData((byte)'#');
            ComManager.sendData((byte)'#');
            ComManager.sendData((byte)'#');
            ComManager.sendData((byte)'#'); 

            try
            {
                if (!DevProto.ChiediVer())
                {
                    ComManager.sendData((byte)'#');

                    if (!DevProto.ChiediVer())
                    {
                        LastError = (byte)0x03;
                        DevProto.LINKSTRU.SetConctStat(0);
                        return false;
                    }
                }
            }
            catch (TimeoutException ex)
            {
                DeviceEvents.invokeDeviceErrorEvent(new DeviceError("", ex, 200));
                DevProto.LINKSTRU.SetConctStat(0);
                return false;
            }
            catch (Exception ex)
            {
                DeviceEvents.invokeDeviceErrorEvent(new DeviceError("", ex, 202));
                DevProto.LINKSTRU.SetConctStat(0);
                return false;
            }

            DevProto.LINKSTRU.SetConctStat(1);
            return true;
        }

        internal static void GetPar()
        { 
            byte[] parAll = new byte[DeviceConstants.PAR_SIZE];

            byte ch = 0;

            DeviceEvents.invokeDeviceParsDownloading();

            if (LINKSTRU.Connesso == 0)
                return;
         
            if (DevProto.SerSDsa.CPolling != 0)
                if (!SendEscEsci())
                    return;

            int Tmr = 0;
            while (pSerTask.SerFlag == 0)
            {
                Global.Sleep(10);
                Tmr++;
                if (Tmr > 500)
                    return;
            }

            DeviceInterface.SetCurrentOperation(CurrentOperation.ReceivingParameters);

            pDataLink.LastErr = eComError.NOERR;
            pSerTask.Attivo = 0;
            pSerTask.Send = 1;

            ComManager.sendData((byte)'L');
            ch = ComManager.reciveByte();

            ComManager.sendData((byte)'&');  

            try
            {
                if (GetPack(parAll)) 
                    DeviceData.setDeviceParameters(parAll); 

                ch = ComManager.reciveByte(); 

                bool iRet = ch == (byte)'&'; 
            }
            catch
            {
                pSerTask.Attivo = 1;
                pSerTask.Send = 0;
                //return false;
            }
            finally
            {
                pSerTask.Attivo = 1;
                pSerTask.Send = 0;
                DeviceEvents.invokeDeviceParsDownloaded();
                DeviceInterface.ClearCurrentOperation();
            } 
        }

        /// <summary>
        ///  Invia parametri
        /// </summary>
        ///         
        internal static void SendPar()
        {
            DeviceEvents.invokeDeviceParsUploading();
            if (LINKSTRU.Connesso == 0)
                return;
             
                if (DevProto.SerSDsa.CPolling != 0)
                    if (!SendEscEsci())
                        return; 

            int Tmr = 0;
            while (pSerTask.SerFlag == 0)
            {
                Global.Sleep(10);
                Tmr++;
                if (Tmr > 500)
                    return;
            }

            DeviceInterface.SetCurrentOperation(CurrentOperation.SendingParameters);

            pDataLink.LastErr = eComError.NOERR;
            pSerTask.Attivo = 0;
            pSerTask.Send = 1; 

            //if (!CreaStrutturaParametri())
            //{
            //    LastError = 0x01;
            //    return;
            //} 
             
            char tipch = 'S';

            bool iRet = false;
            iRet = SendDSA(ALLPARBUFF_SIZE, tipch); 

            pSerTask.Attivo = 1;
            pSerTask.Send = 0;

            DeviceInterface.ClearCurrentOperation();
            DeviceEvents.invokeDeviceParsUploaded(); 
        }

        private static bool SendDSA(int NBYTE, char Tag)
        {
            SERPAR Buf = pSPar;
            int sendedBytes = 0;

            SendTag(Tag);

            if (!SendPack(ParManager.LocalParsDataBase.GetParList(TipoParametro.Timer).ToArray(), DeviceConstants.PAR_TIMER, ref sendedBytes))
                goto ERRORTAG;

            if (!SendPack(ParManager.LocalParsDataBase.GetParList(TipoParametro.Contatori).ToArray(), DeviceConstants.PAR_CONTATORI, ref sendedBytes))
                goto ERRORTAG;

            if (!SendPack(ParManager.LocalParsDataBase.GetParList(TipoParametro.Monostabili).ToArray(), DeviceConstants.PAR_MONOSTABILI, ref sendedBytes))
                goto ERRORTAG;

            if (!SendPack(ParManager.LocalParsDataBase.GetParList(TipoParametro.Macchina).ToArray(), DeviceConstants.PAR_MACCHINA, ref sendedBytes))
                goto ERRORTAG;

            for (int IAsse = 0; IAsse < DeviceConstants.NUM_ASSI; IAsse++)
                if (!SendPack(ParManager.LocalParsDataBase.GetParList(TipoParametro.Asse, IAsse).ToArray(), DeviceConstants.PAR_ASSE, ref sendedBytes))
                    goto ERRORTAG; 

            ComManager.sendData((byte)0x00); 

            byte Readed = 0x00;
            Readed = ComManager.reciveByte(); 

            if (Readed != 0x00) goto ERRORTAG;

            Global.Sleep(1000);

            if (pDataLink.LastErr == eComError.NOCHAR) goto ERRORTAG;  
            return true;

        ERRORTAG:

            ComManager.sendData((byte)'#');
            return false;
        }

        private static bool SendTag(char XTag)
        {

            byte Readed = 0x00;

            ComManager.sendData((byte)XTag);
            Readed = ComManager.reciveByte();  

            if (Readed != XTag)
                return false;

            ComManager.sendData((byte)'%');
            Readed = ComManager.reciveByte();  

            if (Readed != (byte)'%')
                return false;

            return true;
        }

        private static bool SendPack(short[] XBuf, int NBYTE, ref int sendedBytes)
        { 
            byte Readed = 0x00;

            byte ChkSum = 0;
            byte[] Buf = new byte[XBuf.Length * 2];
            int f = 0;

            for (int c = 0; c < XBuf.Length; c++)
            {
                Buf[f] = (byte)(XBuf[c] >> 8 /*/ (byte)0xFF*/);
                Buf[f + 1] = (byte)XBuf[c];
                f += 2;
            }

            int NumPacchetti = 0;
            NBYTE *= 2;

            if (NBYTE > MAXSPAK) 
                NumPacchetti = NBYTE / MAXSPAK; 

            int i = 0;
            while (NBYTE > MAXSPAK)
            {
                ComManager.sendData((byte)MAXSPAK);
                Readed = ComManager.reciveByte();   

                if (Readed != (byte)0x20)
                    return false;

                byte[] Pacchetto = new byte[MAXSPAK];
                Array.Copy(Buf, MAXSPAK * i, Pacchetto, 0, MAXSPAK);
                
                //Calcolo il ChekSum
                ChkSum += (byte)MAXSPAK;

                for (int j = 0; j < 0x20; j++)
                {
                    ComManager.sendData((byte)Pacchetto[j]);
                    Readed = ComManager.reciveByte();

                    if (Readed != Pacchetto[j])
                    {
                        DeviceEvents.invokeDeviceErrorEvent(new DeviceError("Errore: ECO errato!", null, 58));
                        return false;
                    }

                    sendedBytes++;
                    // x: 100 = sended : all
                    DeviceInterface.SetOperationPercentage((sendedBytes * 100) / DeviceConstants.PAR_SIZE); 

                    ChkSum += (byte)Pacchetto[j];
                }

                NBYTE -= MAXSPAK;
                i++;

                ComManager.sendData((byte)(ChkSum * (-1)));
                Readed = ComManager.reciveByte();

                if (Readed != (byte)(ChkSum * (-1)))
                {
                    DeviceEvents.invokeDeviceErrorEvent(new DeviceError("Errore: Checksum errato!", null, 54));
                    return false;
                }

                ChkSum = 0;
            }

            //Mando la parte restante dei parametri
            if (NBYTE > 0)
            {
                ComManager.sendData((byte)NBYTE);
                Readed = ComManager.reciveByte(); 

                if (Readed != (byte)NBYTE)
                    return false;

                ChkSum += (byte)NBYTE;
                for (int j = NBYTE; j > 0; j--)
                {
                    ComManager.sendData((byte)Buf[Buf.Length - j]);
                    Readed = ComManager.reciveByte();

                    if (Readed != Buf[Buf.Length - j])
                    {
                        DeviceEvents.invokeDeviceErrorEvent(new DeviceError("Errore: ECO errato!", null, 58));
                        return false;
                    }

                    sendedBytes++;
                    // x: 100 = sended : all
                    DeviceInterface.SetOperationPercentage((sendedBytes * 100) / DeviceConstants.PAR_SIZE); 

                    ChkSum += (byte)Buf[Buf.Length - j];
                }
            }

            ComManager.sendData((byte)(ChkSum * (-1))); 
            Readed = ComManager.reciveByte();

            if (Readed != (byte)(ChkSum * (-1)))
            {
                DeviceEvents.invokeDeviceErrorEvent(new DeviceError("Errore: Checksum errato!", null, 54));
                return false;
            }

            return true;
        }

        private static bool GetPack(byte[] intBuf)
        {
            byte packLenght, readed, chkSum = 0;
            int bufferIndex = 0x00;  
            bool PackPresent = true; 

            while (PackPresent)
            {
                // Ricevo la lunghezza del pacchetto 
                readed = ComManager.reciveByte();
                ComManager.sendData((byte)readed);  

                packLenght = readed;

                switch (packLenght)
                {
                    case 0x00:
                        PackPresent = false;
                        break;

                    case 0x24: 
                        return false;

                    default: 
                        chkSum += packLenght; 
                         
                        while (packLenght > 0)
                        {
                            // Ricevo dati del pacchetto
                            readed = ComManager.reciveByte();
                            ComManager.sendData((byte)readed);   

                            intBuf[bufferIndex++] = readed;

                            // x: 100 = bufferIndex : allPar
                            DeviceInterface.SetOperationPercentage((bufferIndex * 100) / intBuf.Length);

                            chkSum += readed;

                            packLenght--;
                        }

                        chkSum = (byte)(((int)chkSum) * (-1));

                        // Ricevo il checkSum del DSA
                        readed = ComManager.reciveByte();

                        // Invio il checkSum calcolato
                        ComManager.sendData((byte)readed);   

                        chkSum = 0;  
                        break;
                } 
            }

            DeviceInterface.SetOperationPercentage(100);
            return true;
        }
         
        /// <summary>
        /// Costruisco la struttura dati dei paramentri da inviare al DSA.
        /// </summary> 
        private static bool CreaStrutturaParametri()
        {
            pSPar = new SERPAR();
            pSPar.Initialize();

            try
            {  
                pSPar.TerminalParTimer = ParManager.LocalParsDataBase.GetParList(TipoParametro.Timer).ToArray();  
                pSPar.TerminalParContatori = ParManager.LocalParsDataBase.GetParList(TipoParametro.Contatori).ToArray();  
                pSPar.TerminalParMonostabili = ParManager.LocalParsDataBase.GetParList(TipoParametro.Monostabili).ToArray();  
                pSPar.TerminalParMacchina = ParManager.LocalParsDataBase.GetParList(TipoParametro.Macchina).ToArray();

                for (int iAsse = 0; iAsse < DeviceConstants.NUM_ASSI; iAsse++) 
                    Array.Copy(ParManager.LocalParsDataBase.GetParList(TipoParametro.Asse, iAsse).ToArray(), 0, pSPar.TerminalParAsse, (DeviceConstants.PAR_ASSE * iAsse), DeviceConstants.PAR_ASSE); 

                return true;
            }
            catch
            { return false; }
        }

        // Mette il segno secondo le modalitè DSA
        private static int MettiSegno(int Valori)  //cambia segno poiche' dsa vede il + da 80000000h in su
        {
            uint seg = 0x80000000;

            if (Valori < 0) Valori = Valori * -1;
            else Valori |= (int)seg;

            return (int)Valori;
        }

        // Ripristina il segno secondo le modalità standard
        private static int TogliSegno(int Val)
        {
            uint seg = 0x80000000;
            uint segmen = 0x7FFFFFFF;
            int Vall = Val & (int)seg;
            if (Vall != 0)
                Val &= (int)segmen;
            else Val = Val * -1;
            return Val;
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
         
        #endregion 

        #region Init 

        internal static void InitDevProto()
        { 
            _LastError = 0x00;

            pSerTask = new SERSTRU();
            pSerTask.Initialize();

            pDataLink = new LINKSTRU();
            pDataLink.Initialize();

            pSDsa = new SDSA();
            pSDsa.Initialize();  
        }

        #endregion   
    }  
}
