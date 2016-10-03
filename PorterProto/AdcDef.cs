using System;
using System.Collections.Generic; 
using System.Text;
using System.Reflection;
using System.Xml;

namespace PorterProto
{
    public class AdcList : List<Adc>
    { 
        internal static AdcList loadAdcList()
        {
            AdcList adcList = new AdcList();

            XmlDocument xDocAdc = new XmlDocument();
            xDocAdc.Load(Assembly.GetExecutingAssembly().GetManifestResourceStream(Global.ADC_DEF_ASSEMBLY_NAME));

            foreach (XmlNode xNodeAdcDef in xDocAdc["ADC"])
            {
                string name = xNodeAdcDef.Attributes["name"].Value;
                int index = int.Parse(xNodeAdcDef.Attributes["id"].Value);
                int maxValue = int.Parse(xNodeAdcDef.Attributes["maxValue"].Value);
                int minValue = int.Parse(xNodeAdcDef.Attributes["minValue"].Value);

                adcList.Add(new Adc(name, index, maxValue, minValue));
            }

            return adcList;
        }
    }

    public class Adc
    {
        private string name;
        public string Name
        {
            get { return name; }
        }

        private int index;
        public int Index
        {
            get { return index; }
        }

        private int maxValue;
        public int MaxValue
        {
            get { return maxValue; }
        }

        private int minValue;
        public int MinValue
        {
            get { return minValue; }
        }

        private int value;
        public int Value
        {
            get { return this.value; }
            internal set { this.value = value; }
        }

        public Adc(string adcName, int adcIndex, int adcMaxValue, int adcMinValue)
        {
            name = adcName;
            index = adcIndex;
            maxValue = adcMaxValue;
            minValue = adcMinValue;
        }
    }
}
