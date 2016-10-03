using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO.Ports;

using PorterProto;

namespace RfidManager
{
    internal static class RfidManager
    {
        // Evento pinza chiusa con letto presente -> Attivo uscita Rfid
        // Aspetto 0x00 dalla seriale (lettore acceso)
        // Aspetto il codice del letto se presente (avrò un timeout).
        // Reset quando non ho più il letto presente.

        private const int HIDLE = 0;
        private const int START_RFID_DEVICE = 1; 

        private const string RFID_PORT_NAME = "COM2";

        private const int RFID_TAG_LENGHT = 21;

        public const int RFID_OPENING_PORT_ERROR = 1;
        public const int RFID_CLOSING_PORT_ERROR = 8;
        public const int RFID_TIME_OUT_ERROR = 2;
        public const int RFID_CLOSE_PORT_ERROR = 3;
        public const int RFID_READ_PORT_ERROR = 4;
        public const int RFID_OUT_ON_ERROR = 5;
        public const int RFID_OUT_OFF_ERROR = 7;
        public const int RFID_READER_NOT_FOUNDED = 6;


        public const int STATUS_NEXT_STEP = 0; 
        public const int STATUS_ERROR_NEXT_STEP = 1;
        public const int STATUS_LAST_ERROR = 2;  
        public const int STATUS_TIMEOUT_COUNT = 3; 

        private static SerialPort rfidPort;
        private static bool stopRfidDaemon = false;
        private static bool daemonRunning = false;
        private static int[] rfidDaemonStatus;

        internal static int daemonStatus
        {
            get { return rfidDaemonStatus[0]; }
        }
         
        public static int LastError
        {
            get { return rfidDaemonStatus[2]; }
        }

        public static void InitManager()
        { 
            rfidPort = new SerialPort();

            rfidPort.PortName = RFID_PORT_NAME;
            rfidPort.BaudRate = 19200;
            rfidPort.Parity = Parity.None;
            rfidPort.DataBits = 8;
            rfidPort.StopBits = StopBits.One;

            rfidDaemonStatus = new int[] { 0, 0, 0, 0 };
        }

        public static void StartRfidDaemon()
        {
            if (daemonRunning) return;

            stopRfidDaemon = false;

            (new Thread(rfidDaemon)).Start();
        }

        public static void StopRfidDaemon()
        {
            stopRfidDaemon = true;
        }

        private static void rfidDaemon()
        { 
            daemonRunning = true;
            byte[] recivedData;

            while (!stopRfidDaemon)
            {
                switch (rfidDaemonStatus[0])
                {
                    case 0: // Attesa aggancio letto. (pinze chiuse e letto presente)
                        if (DeviceStatusFlag.FcPinza & DeviceStatusFlag.LettoPresente) 
                            SetNewStatus(10, 0, 0, 0); 
                        break;

                    case 10: // Apro porta seriale

                        try
                        {
                            rfidPort.Open();
                            SetNewStatus(20, 0, 0, 0);  
                        }
                        catch
                        {
                            SetNewStatus(65535, 80, RFID_OPENING_PORT_ERROR, 0);   
                        }

                        break;

                    case 20: // Attivo uscita rfid
                        PorterFunctions.SendRfidOn();
                        SetNewStatus(21, 0, 0, 50);  
                        break;

                    case 21: // Aspetto uscita rfid attiva

                        if (DeviceStatusFlag.RFID) 
                            SetNewStatus(30, 0, 0, 50);
                        else if (!timeTick()) 
                            SetNewStatus(65535, 60, RFID_OUT_ON_ERROR, 0); 

                        break;

                    case 30: // dispositivo rfid presente

                        if (rfidPort.BytesToRead > 0)
                        {
                            recivedData = new byte[1];
                            rfidPort.Read(recivedData, 0, 1); // Quando acceso il lettore invia 0x00 che devo scartare.

                            SetNewStatus(31, 0, 0, 50); 
                        }
                        else if (!timeTick()) 
                            SetNewStatus(65535, 60, RFID_READER_NOT_FOUNDED, 0);  

                        break;

                    case 31: // attesa ricezione tag

                        if (rfidPort.BytesToRead > 0)
                            SetNewStatus(32, 0, 0, 0); 
                        else if (!timeTick()) 
                            SetNewStatus(65535, 60, RFID_TIME_OUT_ERROR, 0);   
 
                        break;

                    case 32: // attesa ricezione tag
                        SetNewStatus(33, 0, 0, 0); 
                        break;

                    case 33: // dovrei aver ricevuto tutto il tag.
                        SetNewStatus(40, 0, 0, 0); 
                        break;

                    case 40: // leggo tag rfid
                        try
                        {
                            recivedData = new byte[rfidPort.BytesToRead];
                            rfidPort.Read(recivedData, 0, recivedData.Length); // Quando acceso il lettore invia 0x00 che devo scartare.

                            LettoManager.NotifyNewTag(recivedData); // Notifico il nuovo tag.
                            SetNewStatus(60, 0, 0, 0);  
                        }
                        catch
                        {
                            rfidDaemonStatus[STATUS_NEXT_STEP] = 65535;
                            rfidDaemonStatus[STATUS_ERROR_NEXT_STEP] = 60;
                            rfidDaemonStatus[STATUS_LAST_ERROR] = RFID_READ_PORT_ERROR;
                            rfidDaemonStatus[STATUS_TIMEOUT_COUNT] = 0;    
                        }
                        break; 

                    case 60: // Tolgo uscita rfid
                        PorterFunctions.SendRfidOff();

                        SetNewStatus(61, 0, 0, 50);   
                        break;

                    case 61: // Attesa disattivazione uscita RFID
                        if (!DeviceStatusFlag.RFID)
                            SetNewStatus(70, 0, 0, 0);  
                        else if (!timeTick()) 
                            SetNewStatus(65535, 70, RFID_OUT_OFF_ERROR, 0);  
                        break;

                    case 70: // chiudo porta seriale.
                        try
                        {
                            rfidPort.DiscardInBuffer();
                            rfidPort.Close();

                            SetNewStatus(80, 0, 0, 0);   
                        }
                        catch
                        {
                            SetNewStatus(65535, 80, RFID_CLOSING_PORT_ERROR, 0);   
                        }
                        break; 

                    case 80: // attesa letto sganciato. 
                        if (!DeviceStatusFlag.FcPinza & !DeviceStatusFlag.LettoPresente) 
                            SetNewStatus(0, 0, 0, 0); 
                        break; 

                    case 65535: // notifica errore.  
                        LettoManager.NotifyRfidError(rfidDaemonStatus[STATUS_LAST_ERROR]);
                        rfidDaemonStatus[STATUS_NEXT_STEP] = rfidDaemonStatus[STATUS_ERROR_NEXT_STEP]; // vado allo step sucessivo.
                        break;
                }

                Thread.Sleep(100);
            }

            daemonRunning = false;
        }

        private static void SetNewStatus(int nextStep, int errorNextStep, int lastError, int timeOutCounter)
        {
            rfidDaemonStatus[STATUS_NEXT_STEP] = nextStep;
            rfidDaemonStatus[STATUS_ERROR_NEXT_STEP] = errorNextStep;
            rfidDaemonStatus[STATUS_LAST_ERROR] = lastError;
            rfidDaemonStatus[STATUS_TIMEOUT_COUNT] = timeOutCounter;  
        }

        private static bool timeTick()
        {
            if (rfidDaemonStatus[STATUS_TIMEOUT_COUNT] > 0)
            {
                rfidDaemonStatus[STATUS_TIMEOUT_COUNT]--;
                return true;
            }

            return false;
        }
    }
}
