using System;
using System.Collections.Generic; 
using System.Text;
using System.Threading;
using System.IO;
using LogManagement;

namespace PorterProto
{
    public enum DeviceDataDef
    {
        DeviceDownloadedPars = 1,
        localPars = 2,
        AdcValues = 3,
        Version = 4,
        FileParametriLocale = 5,
        LagMilliseconds = 6,
        ComPortName = 7,
        Inputs = 8,
        Outputs = 9,
        LogFilePath = 10,
        Quote = 11,
        Encoder = 12,
        BatteryPercentage = 13,
        Messages = 14,
        Distance = 15,
        DistanceStored = 16,
    }

    public static class DeviceData
    {
        //private static System.Threading.Timer refreshTimer;  

        private const int ADC_CAMP_COUNT = 1; 

        private static bool dataRefresherOn = false;

        private static string deviceVersion;
        private static int[] deviceStatus; 
        private static byte[] deviceInput;
        private static AdcList deviceAdc;
        private static int[] deviceEncoders;
        private static byte[] deviceOutput;
        private static int[] deviceQuote;
        private static DataBaseParametri deviceParameters;
        private static MessageList deviceMessages;
        private static int deviceDistance;

        private static List<List<int>> adcValueList;

        public static void initDataManager()
        { 
            deviceVersion = string.Empty;
            deviceStatus = new int[0]; 
            deviceEncoders = new int[DeviceConstants.NUM_ASSI];
            deviceInput = new byte[DeviceConstants.INPUT_COUNT];
            deviceAdc = AdcList.loadAdcList();
            deviceMessages = MessageList.LoadMessageList();
            deviceOutput = new byte[DeviceConstants.OUTPUT_COUNT];
            deviceQuote = new int[DeviceConstants.NUM_ASSI];
            adcValueList = new List<List<int>>();
            for (int index = 0; index < DeviceConstants.ADC_COUNT; index++) adcValueList.Add(new List<int>()); 
        }

        public static void startDataManager()
        { 
            if (dataRefresherOn) 
                return;

            Global.CreateThread(dataRefresher, System.Threading.ThreadPriority.AboveNormal).Start(); 
        }

        private static void dataRefresher()
        {
            byte currentTask = (byte)0;
            int i = 0;

            while (Global.ComStatus > Global.ComunicationStatusFlag.Off)
            {
                if (DevProto.TaskAttivo((Tasks)currentTask)) 
                    DevProto.Calcola((Tasks)currentTask);

                switch ((Tasks)currentTask)
                {
                    case Tasks.TASK_READ_ADC:
                        DeviceEvents.invokeDeviceDataRefreshed(DeviceDataDef.AdcValues);
                        break;

                    default:
                        break;
                }

                currentTask++;
                if (currentTask == DevProto.MAXSERTASK)
                    currentTask = 0;

                Global.Sleep(10); 
            } 
        }

        public static object GetDeviceData(DeviceDataDef dataType)
        {
            switch (dataType)
            {
                case DeviceDataDef.DeviceDownloadedPars: return deviceParameters == null ? null : (object)deviceParameters.Clone();

                case DeviceDataDef.localPars: return ParManager.LocalParsDataBase;

                case DeviceDataDef.AdcValues: 
                     
                    for (int i = 0; i < deviceAdc.Count; i++)
                        deviceAdc[i].Value = DevProto.SerDataLink.Val_Read_ADC[i];

                    return deviceAdc;

                case DeviceDataDef.Encoder:
                     
                    for (int i = 0; i < deviceEncoders.Length; i++)
                        deviceEncoders[i] = DevProto.SerDataLink.Val_Impul[i];

                    return deviceEncoders;

                case DeviceDataDef.Version: 
                    return DevProto.LINKSTRU.Version;

                case DeviceDataDef.FileParametriLocale:
                    string localParFile = (string)Global.getConfigurationValue(Global.PARS_FILE_PROPERTY);

                    if (localParFile == null || string.IsNullOrEmpty(localParFile))
                        return "DEFAULT";

                    return Path.GetFileName(localParFile);

                case DeviceDataDef.ComPortName:
                    string comPortName = (string)Global.getConfigurationValue(Global.COM_NAME_PPROPERTY);

                    if (comPortName == null || string.IsNullOrEmpty(comPortName))
                        return "COM2";
                    return comPortName;

                case DeviceDataDef.LagMilliseconds: return Global.lagMilliseconds;

                case DeviceDataDef.Inputs: return deviceInput;

                case DeviceDataDef.Outputs: return deviceOutput; 

                case DeviceDataDef.Quote: return deviceQuote; 

                case DeviceDataDef.Messages:

                    for (int i = 0; i < deviceMessages.Count; i++)
                        deviceMessages.setMessageStatus(i, DevProto.SerDataLink.Val_Msg_PLC[i] != 0);

                    return deviceMessages;

                case DeviceDataDef.Distance:
                    return DevProto.SerDataLink.Val_Inseg[0];

                case DeviceDataDef.DistanceStored:
                    LogManager.WriteLog("PorterProto", DevProto.SerDataLink.Val_Spec_PLC[0].ToString() + " - " + DevProto.SerDataLink.Val_Spec_PLC[1].ToString());
                    return DevProto.SerDataLink.Val_Spec_PLC[0];

                default: return null;
            }
        } 

        public static void SetDefaultPars()
        {
            ParManager.setDefault();
        }

        public static bool SetParValue(TipoParametro tipo, int id, int index, int value)
        {
            return ParManager.setLocalParValue(tipo, id, index, value);
        }

        public static bool SetParValue(TipoParametro tipo, int index, int value)
        {
            return ParManager.setLocalParValue(tipo, index, value);
        }

        public static bool LoadParFile(string fileName)
        {
            return ParManager.loadParFile(fileName);
        }

        public static bool SaveLocalPars(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return ParManager.saveLocalPars();
            else
                return ParManager.saveLocalPars(fileName);
        }

        public static void SynchParsWithDevice()
        {
            if (deviceParameters != null)
                ParManager.setLocalParsValues(deviceParameters);
        }

        internal static void sendPars()
        {
            new Thread(DevProto.SendPar).Start();
        }

        internal static void setDeviceParameters(byte[] buffer)
        {
            int parIndex = 0;
            int byteIndex = 0;
            int value;
            deviceParameters = ParManager.LocalParsDataBase.Clone();

            for (parIndex = 0; parIndex < DeviceConstants.PAR_TIMER; parIndex++)
            {
                value = buffer[byteIndex++] << 8;
                value += buffer[byteIndex++];
                deviceParameters[DataBaseParametri.INDICE_PAR_TIMER][parIndex].setParValue(value); 
            }

            for (parIndex = 0; parIndex < DeviceConstants.PAR_CONTATORI; parIndex++)
            {
                value = buffer[byteIndex++] << 8;
                value += buffer[byteIndex++];
                deviceParameters[DataBaseParametri.INDICE_PAR_CONTATORI][parIndex].setParValue(value); 
            }

            for (parIndex = 0; parIndex < DeviceConstants.PAR_MONOSTABILI; parIndex++)
            {
                value = buffer[byteIndex++] << 8;
                value += buffer[byteIndex++];
                deviceParameters[DataBaseParametri.INDICE_PAR_MONOSTABILI][parIndex].setParValue(value); 
            }

            for (parIndex = 0; parIndex < DeviceConstants.PAR_MACCHINA; parIndex++)
            {
                value = buffer[byteIndex++] << 8;
                value += buffer[byteIndex++];
                deviceParameters[DataBaseParametri.INDICE_PAR_MACCHINA][parIndex].setParValue(value); 
            }

            for (int i = 0; i < DeviceConstants.NUM_ASSI; i++)
                for (parIndex = 0; parIndex < DeviceConstants.PAR_ASSE; parIndex++)
                {
                    value = buffer[byteIndex++] << 8;
                    value += buffer[byteIndex++];
                    deviceParameters.GetParList(TipoParametro.Asse, i)[parIndex].setParValue(value); 
                } 
        }

        public static float getRealCorrValue(int val)
        {
            float value = (float)val;
            value = ((value / 86f) * 10f);
            value /= (float)Costanti.UM;
            return value;
        }
    }
}
