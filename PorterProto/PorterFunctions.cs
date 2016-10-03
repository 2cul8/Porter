using System;
using System.Collections.Generic;
using System.Text;

namespace PorterProto
{
    public static class PorterFunctions
    {
        public static event EventHandler LettoSganciato;

        public enum Comandi
        {
            none = 0,

            Chiudi = 1,
            Apri = 2,
            Solleva = 3,
            Abbassa = 4,
        }

        private const byte TASTO_CHIUDI_PINZA = 0x43;
        private const byte TASTO_APRI_PINZA = 0x44;
        private const byte TASTO_SOLLEVA_PINZA = 0x45;
        private const byte TASTO_ABBASSA_PINZA = 0x46;
        private const byte TASTO_MOVIMENTO_LIBERO = 0x47;
        private const byte TASTO_MOVIMENTO_UNA_MANO = 0x48;
        private const byte TASTO_RESET_UNA_MANO = 0x49;
        private const byte TASTO_RESET_RALL_BATT = 0x4A;
        private const byte TASTO_MOVE_FAST = 0x4B;
        private const byte TASTO_MOVE_SLOW = 0x4C;
        private const byte TASTO_STOP = 0x1B;

        private const byte FUNCT_RFID_ON = 53;
        private const byte FUNCT_RFID_OFF = 54;

        private static Comandi comandoInEsecuzione = Comandi.none;
        private static bool presenzaLetto = false;

        public static bool GetPinzaChiusa()
        {
            return DeviceStatusFlag.FcPinza;
        }

        public static void ChiudiPinza()
        {
            if (!DeviceInterface.DeviceConnected) return;

            comandoInEsecuzione = Comandi.Chiudi;
            DeviceInterface.DisattivaTask(Tasks.TASK_STATO_DSA); 
            DevProto.SendTasto(TASTO_CHIUDI_PINZA);
        }

        public static void ApriPinza()
        {
            if (!DeviceInterface.DeviceConnected) return;

            comandoInEsecuzione = Comandi.Apri;
            DeviceInterface.DisattivaTask(Tasks.TASK_STATO_DSA); 
            DevProto.SendTasto(TASTO_APRI_PINZA);
        }

        public static void SollevaPinza()
        {
            if (!DeviceInterface.DeviceConnected) return;

            comandoInEsecuzione = Comandi.Solleva;
            DeviceInterface.DisattivaTask(Tasks.TASK_STATO_DSA); 
            DevProto.SendTasto(TASTO_SOLLEVA_PINZA);
        }

        public static void AbbassaPinza()
        {
            if (!DeviceInterface.DeviceConnected) return;

            comandoInEsecuzione = Comandi.Abbassa;
            DeviceInterface.DisattivaTask(Tasks.TASK_STATO_DSA); 
            DevProto.SendTasto(TASTO_ABBASSA_PINZA);
        }

        public static void StopComando()
        {
            if (!DeviceInterface.DeviceConnected) return;

            DevProto.SendTasto(TASTO_STOP);
            DeviceInterface.AttivaTask(Tasks.TASK_STATO_DSA); 
            comandoInEsecuzione = Comandi.none;
        }

        public static void FreeMovingSwitch()
        {
            if (DeviceStatusFlag.MovimentoLibero)
                DevProto.SendTasto(TASTO_STOP);
            else
                DevProto.SendTasto(TASTO_MOVIMENTO_LIBERO);
        }  

        public static void UnaManoSwitch()
        { 
            if (DeviceStatusFlag.UnaMano)
                DevProto.SendTasto(TASTO_RESET_UNA_MANO);
            else 
                DevProto.SendTasto(TASTO_MOVIMENTO_UNA_MANO);
        }

        public static void MoveFast()
        {
            DevProto.SendTasto(TASTO_MOVE_FAST);
        }

        public static void MoveSlow()
        {
            DevProto.SendTasto(TASTO_MOVE_SLOW);
        }

        internal static void setPresenzaLetto(bool stato)
        {
            if (presenzaLetto & !stato) // Letto appena sganciato. 
                if (LettoSganciato != null)
                    LettoSganciato.Invoke(new object(), EventArgs.Empty);

            presenzaLetto = stato;
        }

        public static void SendRfidOn()
        {
            DeviceInterface.InviaFunzione(FUNCT_RFID_ON);
        }

        public static void SendRfidOff()
        {
            DeviceInterface.InviaFunzione(FUNCT_RFID_OFF);
        }
    }

    public enum BatteryEnum
    {
        Batteria1 = 0,
        Batteria2 = 1,
        Generale = 2
    }

    public static class BatteryStatusManager
    {
        private const int ADC_FILTER_COUNT = 1;

        private const int ADC_BATTERIA_1_INDEX = 3; // 12.5 V = 100%, 11.5 V = 50 %
        private const int ADC_BATTERIA_2_INDEX = 4;

        private const int ADC_BATTERIA_1_100 = 656;
        private const int ADC_BATTERIA_1_0 = 510;
        private const int ADC_BATTERIA_1_VALUES = 100;

        private const int ADC_BATTERIA_2_100 = 656;
        private const int ADC_BATTERIA_2_0 = 510;
        private const int ADC_BATTERIA_2_VALUES = 100;

        private const int MAX_WORK_TIME = 300; // 300 minuti

        private static List<int> bufferBatteria1;
        private static List<int> bufferBatteria2;

        public static int FilteredAdc1;
        public static int FilteredAdc2;

        /*
         * ADC 1 : STERZO
         * ADC 2 : POTENZIOMENTRO VELOCITA'
         * ADC 3 : INCLINOMETRO
         * ADC 4 : BATTERIA 1
         * ADC 5 : BATTERIA 2
         * ADC 6 : ARMATURA AZ 1
         * ADC 7 : CORR AZ 1
         * ADC 8 : ARMATURA AZ 2
         * ADC 9 : CORR AZ 2
         */

        public static void InitializeManager()
        {
            bufferBatteria1 = new List<int>();
            bufferBatteria2 = new List<int>();

            DeviceEvents.OnDeviceDataRefreshed += new DeviceDataRefreshedEventHandler(onDeviceDataRefreshed);
        }

        private static void onDeviceDataRefreshed(object sender, DeviceDataRefreshedEventArgs e)
        {
            switch (e.DataRefreshed)
            {
                case DeviceDataDef.AdcValues:
                    break;

                default:
                    return;
            }

            AdcList adcValues = (AdcList)DeviceData.GetDeviceData(DeviceDataDef.AdcValues);

            if (bufferBatteria1.Count >= ADC_FILTER_COUNT)
                bufferBatteria1.RemoveAt(0);

            bufferBatteria1.Add(adcValues[ADC_BATTERIA_1_INDEX].Value);

            if (bufferBatteria2.Count >= ADC_FILTER_COUNT)
                bufferBatteria2.RemoveAt(0);

            bufferBatteria2.Add(adcValues[ADC_BATTERIA_2_INDEX].Value);

            FilteredAdc1 = MathHelper.CalcMedia(bufferBatteria1);
            FilteredAdc2 = MathHelper.CalcMedia(bufferBatteria2);
        }

        public static int GetBatteryPercentage(BatteryEnum target)
        {
            if (!DeviceInterface.DeviceConnected)
                return -1;

            switch (target)
            {
                case BatteryEnum.Batteria1:
                    int percentage = (int)(((float)(FilteredAdc1 - ADC_BATTERIA_1_0) * 100f) / ADC_BATTERIA_1_VALUES);
                    return percentage < 0 ? 0 : (percentage > 100 ? 100 : percentage);

                case BatteryEnum.Batteria2:
                    percentage = (int)(((float)(FilteredAdc2 - ADC_BATTERIA_2_0) * 100f) / ADC_BATTERIA_2_VALUES);
                    return percentage < 0 ? 0 : (percentage > 100 ? 100 : percentage);

                case BatteryEnum.Generale:
                    return (GetBatteryPercentage(BatteryEnum.Batteria1) + GetBatteryPercentage(BatteryEnum.Batteria2)) / 2;
            }

            throw new Exception("Target non valido!");
        }

        public static int GetWorkTime()
        {
            float battPercentage = (float)GetBatteryPercentage(BatteryEnum.Generale);
            return (int)((battPercentage / 100f) * ((float)MAX_WORK_TIME));
        }

        public static float GetBatteryVoltage(BatteryEnum target)
        {
            if (!DeviceInterface.DeviceConnected)
                return -1;

            AdcList adcValues = (AdcList)DeviceData.GetDeviceData(DeviceDataDef.AdcValues);

            switch (target)
            {
                case BatteryEnum.Batteria1:
                    float voltage = (((float)(FilteredAdc1 - ADC_BATTERIA_1_0) * 2.5f) / ADC_BATTERIA_1_VALUES);
                    voltage += 10.5f;
                    return voltage < 10.5f ? 10.5f : (voltage > 12.5f ? 12.5f : voltage);

                case BatteryEnum.Batteria2:
                    voltage = (((float)(FilteredAdc2 - ADC_BATTERIA_2_0) * 2.5f) / ADC_BATTERIA_2_VALUES);
                    voltage += 10.5f;
                    return voltage < 10.5f ? 10.5f : (voltage > 12.5f ? 12.5f : voltage); 

                case BatteryEnum.Generale:
                    return GetBatteryVoltage(BatteryEnum.Batteria1) + GetBatteryVoltage(BatteryEnum.Batteria2);
            }

            throw new Exception("Target non valido!");
        }
    }

    internal static class MathHelper
    {
        public static int GetMaxItemIndex(List<int> values)
        {
            int currentMaxIndex = 0;

            for (int i = 1; i < values.Count; i++)
                currentMaxIndex = (values[i] > values[currentMaxIndex] ? i : currentMaxIndex);

            return currentMaxIndex;
        }

        public static int GetMinItemIndex(List<int> values)
        {
            int currentMinIndex = 0;

            for (int i = 1; i < values.Count; i++)
                currentMinIndex = (values[i] < values[currentMinIndex] ? i : currentMinIndex);

            return currentMinIndex;
        }

        public static int CalcMedia(List<int> buffer)
        {
            if (buffer == null)
                return 0;

            switch (buffer.Count)
            {
                case 0: return 0;
                case 1: return buffer[0];
                case 2: return (buffer[0] + buffer[1]) / 2;

                default:
                    int summ = 0;

                    for (int i = 0; i < buffer.Count; i++)
                        summ += buffer[i];
                    return (int)(((float)summ) / ((float)(buffer.Count)));
            }
        }
    }
}
