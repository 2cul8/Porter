using System;
using System.Collections.Generic; 
using System.Text;
using System.Threading;
using System.Configuration;
using System.Reflection;
using System.IO;

using Microsoft.Win32;

namespace PorterProto
{
    public enum PortStatus
    {
        Closed = 0,
        Open = 1,
        Receiving = 2,
        Sending = 3,
    }

    public static class Costanti
    {
        public const int UM = 10;
    }

    public static class DeviceConstants
    { 
        #region Definizione costanti Dispositivo

        public const int NUM_ASSI = 4;
        public const int PAR_ASSE = 20;
        public const int PAR_MACCHINA = 20;
        public const int PAR_TIMER = 6;
        public const int PAR_CONTATORI = 6;
        public const int PAR_MONOSTABILI = 6;
        public const int PAR_SIZE = ((PAR_ASSE * NUM_ASSI) * 2) + (PAR_MACCHINA * 2) + (PAR_TIMER * 2) + (PAR_CONTATORI * 2) + (PAR_MONOSTABILI * 2);
        public const int PAR_COUNT = (PAR_ASSE * NUM_ASSI) + PAR_MACCHINA + PAR_TIMER + PAR_CONTATORI + PAR_MONOSTABILI;
        public const int ADC_COUNT = 12;
        public const int ENCODER = 2;  
        public const int INPUT_COUNT = 24;
        public const int OUTPUT_COUNT = 24;
 
        #endregion
    } 

    static class Global
    {
        #region Definizione dati porta COM

        public static string COM_NAME = string.Empty;

        #endregion 

        #region Gestione comunicazione

        internal const int TIME_OUT_INT = 2000;

        internal static long lagMilliseconds = 0;

        internal static PortStatus portStatus = PortStatus.Closed;

        [Flags]
        internal enum ComunicationStatusFlag
        {
            Off = 0,        // Comunicazione chiusa
            Open = 1,       // Comunicazione aperta
            Connecting = 2,
            TasksOn = 4,    // Gestione dei task attiva
            Running = 5,    // Comunicazione attiva
            Paused = 21,     // Comunicazione sospesa
        }

        private static ComunicationStatusFlag comStatus = ComunicationStatusFlag.Off;
        public static ComunicationStatusFlag ComStatus
        {
            get { return comStatus; }
            set { comStatus = value; }
        }
         
        internal enum TaskExecutorStatus
        {
            Off = 0,        // Comunicazione chiusa 
            TasksOn = 1,    // Gestione dei task attiva
            Paused = 2,     // Comunicazione sospesa 
        }
        public static Thread TaskExecutorThread;
        private static TaskExecutorStatus taskExecutorThreadStatus;  

        internal static TaskExecutorStatus TaskExecutorThreadStatus
        {
            get { return taskExecutorThreadStatus; }
            set { taskExecutorThreadStatus = value; }
        }

        public static void GestTimeOut(TimeoutException timeOutEx)
        {
            DeviceEvents.invokeDeviceErrorEvent(new DeviceError("Timeout.", timeOutEx, 200));
            DeviceInterface.ChiudiComunicazione(); 
        }

        #endregion

        #region Gestione generica 

        public static void Sleep(int toSleep)
        { 
            Thread.Sleep(toSleep);
        }

        public static void Breathe()
        {
            Sleep(1);
        }

        public static Thread CreateThread(ThreadStart method)
        {
            return new Thread(method);
        }

        public static Thread CreateThread(ThreadStart method, ThreadPriority priority)
        {
            Thread tRet = CreateThread(method);
            tRet.Priority = priority;
            return tRet;
        }

        #endregion

        #region Gestione Errori
        
        private static int errorCounter = 0;
        public static int ErrorCounter
        {
            get { return errorCounter; }
        }

        internal static void incErrorCounter()
        {
            errorCounter++;
        }

        #endregion

        #region Configuration FILE

        internal const string PARS_FILE_PROPERTY = "ParsFile";
        internal const string COM_NAME_PPROPERTY = "ComName"; 

        public static object getConfigurationValue(string name)
        {
            string returnValue;

            switch (name)
            {
                case PARS_FILE_PROPERTY:
                    returnValue = Path.Combine(GetApplicationPath(), FILE_PARS_DEFAULT_NAME + FILE_PARS_EXTENSION);
                    break;

                case COM_NAME_PPROPERTY:
                    returnValue = "COM2";
                    break;

                default:
                    returnValue = string.Empty;
                    break;
            }
             
            return returnValue;
        } 

        /// <summary>
        /// Recupera il Path di applicazione.
        /// </summary>
        /// <returns></returns>
        public static string GetApplicationPath()
        {
            try
            {
                try
                {
                    Assembly asm = Assembly.GetExecutingAssembly();
                    return asm.GetName().CodeBase.Substring(0, asm.GetName().CodeBase.LastIndexOf(@"\", StringComparison.Ordinal) + 1);
                }
                catch (Exception ex)
                { 
                    string msg = ex.Message;
                    return string.Empty;
                }
            }
            catch (Exception ex)
            { 
                return null;
            }
        }

        #endregion

        #region File incorporati

        internal const string TASKS_ASSEMBLY_NAME = "PorterProto.EmbeddedResources.Tasks.xml";
        internal const string PARS_DEFAULT_ASSEMBLY_NAME = "PorterProto.EmbeddedResources.ParsDefault.xml";
        internal const string PARS_DEFINITION_ASSEMBLY_NAME = "PorterProto.EmbeddedResources.ParsDef.xml";
        internal const string ADC_DEF_ASSEMBLY_NAME = "PorterProto.EmbeddedResources.AdcDef.xml";
        internal const string MESSAGES_DEF_ASSEMBLY_NAME = "PorterProto.EmbeddedResources.MessagesDef.xml"; 

        #endregion

        #region FileLocali

        public const string FILE_PARS_EXTENSION = ".dat";
        public const string FILE_PARS_DEFAULT_NAME = "PorterPar";

        #endregion
    } 

    public static class DeviceStatusFlag
    {
        /*
        1-1: teleruttore generale
        1-2: RFID
        1-3: out motoruote
        1-4: out solleva pinze
        1-5: out chiusura pinze
        1-6: emergenza

        2-1: abiliata asse X
        2-2: msg errore X1
        2-3: msg errore X2
        2-4: abiliata asse Y
        2-5: msg errore Y1
        2-6: msg errore Y2

        3-1: sensore presenza letto
        3-2: f.c. pinza chiusa
        3-3: alimentazione da rete
        3-4: presenza mano dx
        3-5: presenza mano sx
        3-6: none

        4-1: marcia avanti
        4-2: marcia indietro
        4-3: chiusura pinza pulsante
        4-4: apertura pinza pulsante
        4-5: salita pinza pulsante
        4-6: discesa pinza pulsante
        */

        private static bool teleruttore;
        public static bool Teleruttore
        {
            get { return teleruttore; }
            internal set { teleruttore = value; }
        }

        private static bool emergenza;
        public static bool Emergenza
        {
            get { return emergenza; }
            internal set { emergenza = value; }
        }

        private static bool rfid;
        public static bool RFID
        {
            get { return rfid; }
            internal set { rfid = value; }
        }

        private static bool outMotoruote;
        public static bool OutMotoruote
        {
            get { return outMotoruote; }
            internal set { outMotoruote = value; }
        }

        private static bool outSollevaPinze;
        public static bool OutSollevaPinze
        {
            get { return outSollevaPinze; }
            internal set { outSollevaPinze = value; }
        }

        private static bool outChiusuraPinze;
        public static bool OutChiusuraPinze
        {
            get { return outChiusuraPinze; }
            internal set { outChiusuraPinze = value; }
        }

        private static bool asseXAbilitato;
        public static bool AsseXAbilitato
        {
            get { return asseXAbilitato; }
            internal set { asseXAbilitato = value; }
        } 

        private static bool erroreAsseX1;
        public static bool ErroreAsseX1
        {
            get { return erroreAsseX1; }
            internal set { erroreAsseX1 = value; }
        }

        private static bool erroreAsseX2;
        public static bool ErroreAsseX2
        {
            get { return erroreAsseX2; }
            internal set { erroreAsseX2 = value; }
        }

        private static bool asseYAbilitato;
        public static bool AsseYAbilitato
        {
            get { return asseXAbilitato; }
            internal set { asseXAbilitato = value; }
        }

        private static bool erroreAsseY1;
        public static bool ErroreAsseY1
        {
            get { return erroreAsseY1; }
            internal set { erroreAsseY1 = value; }
        }

        private static bool erroreAsseY2;
        public static bool ErroreAsseY2
        {
            get { return erroreAsseY2; }
            internal set { erroreAsseY2 = value; }
        }

        private static bool lettoPresente;
        public static bool LettoPresente
        {
            get { return lettoPresente; }
            internal set { lettoPresente = value; }
        }

        private static bool fcPinza;
        public static bool FcPinza
        {
            get { return fcPinza; }
            internal set { fcPinza = value; }
        }

        private static bool alimRete;
        public static bool AlimRete
        {
            get { return alimRete; }
            internal set { alimRete = value; }
        }

        private static bool presenzaManoDx;
        public static bool PresenzaManoDx
        {
            get { return presenzaManoDx; }
            internal set { presenzaManoDx = value; }
        }

        private static bool presenzaManoSx;
        public static bool PresenzaManoSx
        {
            get { return presenzaManoSx; }
            internal set { presenzaManoSx = value; }
        }

        private static bool muoviInLento;
        public static bool MuoviInLento
        {
            get { return muoviInLento; }
            internal set { muoviInLento = value; }
        } 

        private static bool movimentoLibero;
        public static bool MovimentoLibero
        {
            get { return movimentoLibero; }
            internal set { movimentoLibero = value; }
        }

        private static bool unaMano;
        public static bool UnaMano
        {
            get { return unaMano; }
            internal set { unaMano = value; }
        }

        private static bool marciaAvanti;
        public static bool MarciaAvanti
        {
            get { return marciaAvanti; }
            internal set { marciaAvanti = value; }
        }

        private static bool marciaIndietro;
        public static bool MarciaIndietro
        {
            get { return marciaIndietro; }
            internal set { marciaIndietro = value; }
        }

        private static bool chiusuraPinzaInput;
        public static bool ChiusuraPinzaInput
        {
            get { return chiusuraPinzaInput; }
            internal set { chiusuraPinzaInput = value; }
        }

        private static bool aperturaPinzaInput;
        public static bool AperturaPinzaInput
        {
            get { return aperturaPinzaInput; }
            internal set { aperturaPinzaInput = value; }
        }

        private static bool salitaPinzaInput;
        public static bool SalitaPinzaInput
        {
            get { return salitaPinzaInput; }
            internal set { salitaPinzaInput = value; }
        }

        private static bool discesaPinzaInput;
        public static bool DiscesaPinzaInput
        {
            get { return discesaPinzaInput; }
            internal set { discesaPinzaInput = value; }
        }
    }

    public static class DeviceEvents
    {
        /// <summary>
        /// Errori:
        /// 0-50: Errori di protocollo.
        /// 0: Errore sul check sum ricevuto da dispositivo.
        /// 1: Errore sul check sum.
        /// 2: Comando non riconosciuto dal dispositivo.
        /// 3: Errore non riconosciuto durante la ricezione dei dati. 
        /// 4: Errore caricamento inizializzazioni.
        /// 
        /// 51-100: Errore invio parametri.
        /// 51: Time OUT.
        /// 52: Indice del pacchetto ricevuto errato.
        /// 53: Lunghezza pacchetto non valida.
        /// 54: Errore sul check sum.
        /// 55: Risposta del dispositivo non valida.
        /// 56: Dispositivo non allineato.
        /// 57: Risposta di salvataggio parametri errata.
        /// 58: Errore ECO errato.
        /// 99: Errore non riconosciuto.
        /// 
        /// 101-120: Errore gestione COM.
        /// 101: Impossibile aprire la porta COM scelta.
        /// 102: Errore durante l'inizializzazione della porta COM.
        /// 103: Errore durante la chiusura della porta COM.
        /// 
        /// 121-150: Errore ricezione parametri.
        /// 121: Errore durante  la ricezione dei parametri.
        /// 
        /// 200-250: Errori di comunicazione.
        /// 200: Timeout.
        /// 201: Dispositivo non trovato.
        /// 202: Errore durante il tentativo di connessione.
        /// 203: Risposta del dispositivo non valida.
        /// 204: Timeout da dispositivo.
        /// 205: Errore di comunicazione.
        /// 
        /// 251- 300 Errori gestione parametri locali.
        /// 251: Valore scelto fuori dal range consentito.
        /// 252: Errore durante la lettura dei parametri locali.
        /// 253: File parametri non valido.
        /// 254: File non trovato.
        /// 255: Errore durante il salvataggio del File.
        /// 256: Impossibile modificare il parametro scelto.
        /// 
        /// 301 - 350 Errori gestione Log.
        /// 301: Errore durante la creazione del file di log.
        /// </summary>
        public static event DeviceErrorEventHandler OnDeviceError;
        internal static void invokeDeviceErrorEvent(DeviceError error) 
        {
            if (OnDeviceError != null)
                Global.CreateThread((ThreadStart)delegate { OnDeviceError.Invoke(new object(), new DeviceErrorEventArgs(error)); }).Start();

            Global.incErrorCounter(); 
        }

        public static event DeviceMessageEventHandler OnDeviceMessage;
        internal static void invokeDeviceMessageEvent(string msg) 
        {
            if (OnDeviceMessage != null)
                Global.CreateThread((ThreadStart)delegate { OnDeviceMessage.Invoke(new object(), new DeviceMessageEventArgs(msg)); }).Start(); 
        }

        public static event EventHandler OnDeviceConnectionStarted;
        internal static void invokeDeviceConnectionStarted()
        {
            if (OnDeviceConnectionStarted != null)
                Global.CreateThread((ThreadStart)delegate { OnDeviceConnectionStarted.Invoke(new object(), new EventArgs()); }).Start();
        }

        public static event EventHandler OnDeviceConnected;
        internal static void invokeDeviceConnected() 
        {
            if (OnDeviceConnected != null)
                Global.CreateThread((ThreadStart)delegate { OnDeviceConnected.Invoke(new object(), new EventArgs()); }).Start();
        }

        public static event EventHandler OnDeviceDisconnected;
        internal static void invokeDeviceDisconnected() 
        {
            if (OnDeviceDisconnected != null)
                Global.CreateThread((ThreadStart)delegate { OnDeviceDisconnected.Invoke(new object(), new EventArgs()); }).Start();
        }

        public static event EventHandler OnDeviceParsDownloading;
        internal static void invokeDeviceParsDownloading()
        {
            if (OnDeviceParsDownloading != null)
                Global.CreateThread((ThreadStart)delegate { OnDeviceParsDownloading.Invoke(new object(), new EventArgs()); }).Start();
        }

        public static event EventHandler OnDeviceParsDownloaded;
        internal static void invokeDeviceParsDownloaded() 
        {
            if (OnDeviceParsDownloaded != null) OnDeviceParsDownloaded.Invoke(new object(), new EventArgs());
        }

        public static event EventHandler OnDeviceParsUploading;
        internal static void invokeDeviceParsUploading()
        {
            if (OnDeviceParsUploading != null)
                Global.CreateThread((ThreadStart)delegate { OnDeviceParsUploading.Invoke(new object(), new EventArgs()); }).Start();
        }

        public static event EventHandler OnDeviceParsUploaded;
        internal static void invokeDeviceParsUploaded()
        {
            if (OnDeviceParsUploaded != null) OnDeviceParsUploaded.Invoke(new object(), new EventArgs());
        }

        public static event EventHandler OnLocalParsLoaded;
        internal static void invokeLocalParsLoaded() 
        {
            if (OnLocalParsLoaded != null) 
                OnLocalParsLoaded.Invoke(new object(), new EventArgs()); 
        }

        public static event DeviceDataRefreshedEventHandler OnDeviceDataRefreshed;
        internal static void invokeDeviceDataRefreshed(DeviceDataDef data)
        {
            if (OnDeviceDataRefreshed != null)
                OnDeviceDataRefreshed.Invoke(new object(), new DeviceDataRefreshedEventArgs(data));
        }

        internal static void initLog()
        { }

        public static class EventsLog
        { }
    }

    public delegate void DeviceDataRefreshedEventHandler(object sender, DeviceDataRefreshedEventArgs e);

    public class DeviceDataRefreshedEventArgs : EventArgs
    {
        private DeviceDataDef dataRefreshed;
        public DeviceDataDef DataRefreshed
        {
            get { return dataRefreshed; }
        }

        public DeviceDataRefreshedEventArgs(DeviceDataDef data)
            : base()
        {
            dataRefreshed = data;
        }
    }

    public delegate void DeviceMessageEventHandler(object sender, DeviceMessageEventArgs e);

    public class DeviceMessageEventArgs : EventArgs
    {
        private string msg = string.Empty;
        public string Message
        {
            get { return msg; }
            private set { msg = value; }
        }

        internal DeviceMessageEventArgs(string message)
        {
            msg = message;
        }
    }

    public delegate void DeviceErrorEventHandler(object sender, DeviceErrorEventArgs e);

    public class DeviceErrorEventArgs : EventArgs
    {
        private DeviceError error;
        public DeviceError Error
        {
            get { return error; }
        }

        public DeviceErrorEventArgs(DeviceError devError)
             
        {
            error = devError;
        }
    }

    public class DeviceError
    {
        private string errorDesc;
        public string ErrorDesc
        {
            get { return errorDesc; }
        } 

        private Exception errorException;
        public Exception ErrorException
        {
            get { return errorException; } 
        }

        private int id = -1;
        public int Id
        {
            get { return id; }
        }

        internal DeviceError(string eDesc, Exception eException, int ident)
        {
            errorDesc = Resources.ResourcesManager.GetString(eDesc);
            errorException = eException;
            id = ident;
        }
    }
}