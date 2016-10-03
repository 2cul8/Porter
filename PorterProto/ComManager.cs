using System;
using System.Collections.Generic; 
using System.Text;
using System.IO.Ports;
using System.Diagnostics;

namespace PorterProto
{
    internal static class ComManager
    {
        private static SerialPort comPort;
        private static bool comOpen = false;
        private static bool watchDogEnable = false;

        public static bool initComManager()
        {
            try
            { 
                comPort = new SerialPort(Global.COM_NAME);

                comPort.BaudRate = 19200;
                comPort.Parity = Parity.None;
                comPort.DataBits = 8;
                comPort.StopBits = StopBits.One;
                 
                comPort.DiscardNull = false;

                comOpen = false;
            }
            catch (Exception ex)
            {
                DeviceEvents.invokeDeviceErrorEvent(new DeviceError("Errore inizializzazione porta COM.", ex, 102));
                return false;
            }

            DeviceEvents.invokeDeviceMessageEvent("Porta " + Global.COM_NAME + " inizializzata.");
            return true;
        } 

        public static bool openComPort()
        {
            try
            {
                comPort.Open();
                DeviceEvents.invokeDeviceMessageEvent("Apertura porta " + comPort.PortName + " ok."); 
                Global.portStatus = PortStatus.Open;

                comOpen = true;
            }
            catch (Exception ex)
            {
                DeviceEvents.invokeDeviceErrorEvent(new DeviceError("Impossibile aprire la porta COM scelta.", ex, 101));
                return false;
            }

            Global.CreateThread(watchDogThread).Start();

            comPort.DiscardInBuffer();
            comPort.DiscardOutBuffer();

            DeviceEvents.invokeDeviceMessageEvent("Porta " + Global.COM_NAME + " aperta.");
            return true;
        } 

        private static void watchDogThread()
        {
            while (comOpen)
            {
                Global.Sleep(100);
                Global.lagMilliseconds = (watchDogEnable ? Global.lagMilliseconds + 100 : 0); 
            }
        }

        public static bool closeComPort()
        {
            try
            {
                if (comPort.IsOpen)
                { 
                    comPort.DiscardInBuffer();
                    comPort.DiscardOutBuffer();
                    comPort.Close();
                    Global.portStatus = PortStatus.Closed;

                    comOpen = false;
                }
            }
            catch (Exception ex)
            {
                DeviceEvents.invokeDeviceErrorEvent(new DeviceError("Errore durante la chiusura della porta COM.", ex, 103));
                return false;
            }

            return true;
        }  

        public static void sendData(byte toSend)
        {
            Global.portStatus = PortStatus.Sending;
            comPort.Write(new byte[] { toSend }, 0, 1); Global.Sleep(10); 
            Global.portStatus = PortStatus.Open; 
        }

        public static byte reciveByte()
        {
            Global.portStatus = PortStatus.Receiving;
            watchDogEnable = true;

            while (comPort.BytesToRead == 0)
            {
                if (Global.lagMilliseconds >= Global.TIME_OUT_INT)
                {
                    Global.portStatus = PortStatus.Open;
                    watchDogEnable = false;
                    throw new TimeoutException("Nessuna risposta dal dispositivo.");
                }
                 
                Global.Sleep(1);
            }

            watchDogEnable = false;
            Global.portStatus = PortStatus.Open;
            byte readed = (byte)comPort.ReadByte();  
            return readed;
        }

        public static void clearBuffers()
        {
            comPort.DiscardInBuffer();
            comPort.DiscardOutBuffer();
        }
    }
}
