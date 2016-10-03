using System;
using System.Collections.Generic; 
using System.Text;

namespace PorterProto
{ 
    public enum CurrentOperation
    {
        None = 0,
        SendingParameters = 1,
        ReceivingParameters = 2,
        Connecting = 3
    }

    public static class DeviceInterface
    {
        internal static int COUNTER = 0; 

        public static bool DeviceConnected
        {
            get { return ((int)Global.ComStatus) > (int)Global.ComunicationStatusFlag.Connecting; }
        }

        public static bool Connecting
        {
            get { return (Global.ComStatus & Global.ComunicationStatusFlag.Connecting) > 0; }
        }

        public static PortStatus PortStatus
        {
            get { return Global.portStatus; }
        }

        private static CurrentOperation currentOperation = CurrentOperation.None;
        private static int percentageValue = 0;
        public static CurrentOperation CurrentOperation
        {
            get { return currentOperation; } 
        }

        public static bool initDevice()
        { 
            DeviceEvents.initLog();
            DeviceData.initDataManager();

            Global.COM_NAME = "COM1"; 

            if (ParManager.initParManager())
                if (ComManager.initComManager())
                {
                    DevProto.InitDevProto();
                    return true; 
                }
            
            return false;
        }

        public static void AvviaComunicazione()
        { 
            Global.CreateThread(DevProto.StartComunication, System.Threading.ThreadPriority.AboveNormal).Start();
        }

        public static void SospendiComunicazione()
        {
            Global.ComStatus = Global.ComunicationStatusFlag.Paused;
        }

        public static void ChiudiComunicazione()
        {
            if (!DeviceConnected) 
                return;

            DevProto.CloseComunication();
        }

        public static void AttivaTask(Tasks task)
        {
            DevProto.InsTaskDSA(task); 
        }

        public static void DisattivaTask(Tasks task)
        {
            DevProto.DelSerTask(task);
        }

        public static bool LeggiStatoTask(Tasks task)
        {
            return DevProto.TaskAttivo(task);
        }

        public static void InviaParametriLocali()
        {
            if (!DeviceConnected)
                return;

            SetOperationPercentage(0);
            Global.CreateThread(DevProto.SendPar, System.Threading.ThreadPriority.Normal).Start();  
        }

        public static void RichiediParametriDispositivo()
        {
            if (!DeviceConnected)
                return;

            SetOperationPercentage(0);
            Global.CreateThread(DevProto.GetPar, System.Threading.ThreadPriority.Normal).Start(); 
        }

        public static bool InviaFunzione(byte funzione)
        {
            return DevProto.SendEffe(funzione, 0);
        }

        public static void InviaUscite(byte[] outputs)
        { } 

        public static int GetOperationPercentage()
        {
            return percentageValue;
        }

        internal static void SetOperationPercentage(int percentage)
        {
            percentageValue = percentage;
        }

        internal static void SetCurrentOperation(CurrentOperation operation)
        { 
            currentOperation = operation;
        }

        internal static void ClearCurrentOperation()
        {
            percentageValue = 0;
            currentOperation = CurrentOperation.None;
        } 
    }
}
