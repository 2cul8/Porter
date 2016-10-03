using System;
using System.Collections.Generic; 
using System.Text;
using System.IO;
using System.Xml;
using System.Reflection;

namespace PorterProto
{
    internal static class ParManager
    {
        private static DataBaseParametri localParsDataBase;
        public static DataBaseParametri LocalParsDataBase
        {
            get { return localParsDataBase; }
        }

        internal static bool initParManager()
        {
            localParsDataBase = new DataBaseParametri();

            XmlDocument xDocParsDef = new XmlDocument();
            xDocParsDef.Load(Assembly.GetExecutingAssembly().GetManifestResourceStream(Global.PARS_DEFINITION_ASSEMBLY_NAME));

            foreach (XmlNode xNodeListDef in xDocParsDef["PARS_DEF"])
            {
                int parType = int.Parse(xNodeListDef.Attributes["Tipo"].Value);
                int parId = int.Parse(xNodeListDef.Attributes["Id"].Value);

                switch (parType)
                {
                    case 1: // Parametro asse, devo guardare anche l'id.
                        switch (parId)
                        {
                            case 0: localParsDataBase[DataBaseParametri.INDICE_PAR_ASSE_1].Name = xNodeListDef.Attributes["Name"].Value; break;
                            case 1: localParsDataBase[DataBaseParametri.INDICE_PAR_ASSE_2].Name = xNodeListDef.Attributes["Name"].Value; break;
                            case 2: localParsDataBase[DataBaseParametri.INDICE_PAR_ASSE_3].Name = xNodeListDef.Attributes["Name"].Value; break;
                            case 3: localParsDataBase[DataBaseParametri.INDICE_PAR_ASSE_4].Name = xNodeListDef.Attributes["Name"].Value; break; 
                        }
                        break;

                    case 2: localParsDataBase[DataBaseParametri.INDICE_PAR_MACCHINA].Name = xNodeListDef.Attributes["Name"].Value; break;
                    case 3: localParsDataBase[DataBaseParametri.INDICE_PAR_TIMER].Name = xNodeListDef.Attributes["Name"].Value; break;
                    case 4: localParsDataBase[DataBaseParametri.INDICE_PAR_CONTATORI].Name = xNodeListDef.Attributes["Name"].Value; break;
                    case 5: localParsDataBase[DataBaseParametri.INDICE_PAR_MONOSTABILI].Name = xNodeListDef.Attributes["Name"].Value; break;

                    default: return false;
                }

                foreach (XmlNode xNodeParDef in xNodeListDef)
                {
                    string parName = xNodeParDef.Attributes["Name"].Value;
                    int parMin = int.Parse(xNodeParDef.Attributes["Min"].Value);
                    int parMax = int.Parse(xNodeParDef.Attributes["Max"].Value);
                    bool active = bool.Parse(xNodeParDef.Attributes["active"].Value);
                    string parDesc = xNodeParDef.InnerText; 

                    switch (parType)
                    {
                        case 1: // Parametro asse, devo guardare anche l'id.
                            switch (parId)
                            {
                                case 0: localParsDataBase[DataBaseParametri.INDICE_PAR_ASSE_1].Add(new Parametro(parName, parDesc, parMin, parMax, 0, active, TipoParametro.Asse)); break;
                                case 1: localParsDataBase[DataBaseParametri.INDICE_PAR_ASSE_2].Add(new Parametro(parName, parDesc, parMin, parMax, 0, active, TipoParametro.Asse)); break;
                                case 2: localParsDataBase[DataBaseParametri.INDICE_PAR_ASSE_3].Add(new Parametro(parName, parDesc, parMin, parMax, 0, active, TipoParametro.Asse)); break;
                                case 3: localParsDataBase[DataBaseParametri.INDICE_PAR_ASSE_4].Add(new Parametro(parName, parDesc, parMin, parMax, 0, active, TipoParametro.Asse)); break; 
                            }
                            break;

                        case 2:
                            localParsDataBase[DataBaseParametri.INDICE_PAR_MACCHINA].Add(new Parametro(parName, parDesc, parMin, parMax, 0, active, TipoParametro.Macchina));
                            break;
                        case 3:
                            localParsDataBase[DataBaseParametri.INDICE_PAR_TIMER].Add(new Parametro(parName, parDesc, parMin, parMax, 0, active, TipoParametro.Timer));
                            break;
                        case 4: localParsDataBase[DataBaseParametri.INDICE_PAR_CONTATORI].Add(new Parametro(parName, parDesc, parMin, parMax, 0, active, TipoParametro.Contatori)); break;
                        case 5: localParsDataBase[DataBaseParametri.INDICE_PAR_MONOSTABILI].Add(new Parametro(parName, parDesc, parMin, parMax, 0, active, TipoParametro.Monostabili)); break;

                        default: return false;
                    }
                }
            }

            //return loadParFile(Assembly.GetExecutingAssembly().GetManifestResourceStream(Global.PARS_DEFAULT_ASSEMBLY_NAME));

            string parsFile = (string)Global.getConfigurationValue(Global.PARS_FILE_PROPERTY);

            if (!File.Exists(parsFile))
            { 
                DeviceEvents.invokeDeviceMessageEvent(Resources.Resources.GetString("ParManager.Messages.1"));
                return loadParFile(Assembly.GetExecutingAssembly().GetManifestResourceStream(Global.PARS_DEFAULT_ASSEMBLY_NAME));
            }
            else 
            {
                DeviceEvents.invokeDeviceMessageEvent(string.Format(Resources.Resources.GetString("ParManager.Messages.2"), Path.GetFileName(parsFile)));
                if (!loadParFile(File.OpenRead(parsFile)))
                {
                    DeviceEvents.invokeDeviceErrorEvent(new DeviceError("DeviceError.1", null, 252));
                    return loadParFile(Assembly.GetExecutingAssembly().GetManifestResourceStream(Global.PARS_DEFAULT_ASSEMBLY_NAME));
                }
            }

            return true;
        }

        internal static void setDefault()
        {
            loadParFile(Assembly.GetExecutingAssembly().GetManifestResourceStream(Global.PARS_DEFAULT_ASSEMBLY_NAME));
        }

        internal static bool loadParFile(string parFileName)
        {
            if (!File.Exists(parFileName))
            {
                DeviceEvents.invokeDeviceErrorEvent(new DeviceError("DeviceError.2", null, 254));
                return false;
            } 

            return loadParFile(File.OpenRead(parFileName));
        }

        internal static bool loadParFile(Stream parStream)
        {
            XmlDocument xDocPars = new XmlDocument();
            //ListaParametri tempParsList = getEmptyParsList(); 
            DataBaseParametri tempDataBase = localParsDataBase.Clone();

            try
            {
                xDocPars.Load(parStream);

                foreach (XmlNode xNodeParList in xDocPars["PARAMETRI"])
                {
                    int parType = int.Parse(xNodeParList.Attributes["Tipo"].Value);
                    int parId = int.Parse(xNodeParList.Attributes["Id"].Value);
                    int index = 0;

                    foreach (XmlNode xNodePar in xNodeParList)
                        switch (parType)
                        {
                            case 1:
                                switch (parId)
                                {
                                    case 0: tempDataBase[DataBaseParametri.INDICE_PAR_ASSE_1][index++].setParValue(int.Parse(xNodePar.Attributes["value"].Value)); break;
                                    case 1: tempDataBase[DataBaseParametri.INDICE_PAR_ASSE_2][index++].setParValue(int.Parse(xNodePar.Attributes["value"].Value)); break;
                                    case 2: tempDataBase[DataBaseParametri.INDICE_PAR_ASSE_3][index++].setParValue(int.Parse(xNodePar.Attributes["value"].Value)); break;
                                    case 3: tempDataBase[DataBaseParametri.INDICE_PAR_ASSE_4][index++].setParValue(int.Parse(xNodePar.Attributes["value"].Value)); break; 
                                }
                                break;
                            case 2: tempDataBase[DataBaseParametri.INDICE_PAR_MACCHINA][index++].setParValue(int.Parse(xNodePar.Attributes["value"].Value)); break;
                            case 3: tempDataBase[DataBaseParametri.INDICE_PAR_TIMER][index++].setParValue(int.Parse(xNodePar.Attributes["value"].Value)); break;
                            case 4: tempDataBase[DataBaseParametri.INDICE_PAR_CONTATORI][index++].setParValue(int.Parse(xNodePar.Attributes["value"].Value)); break;
                            case 5: tempDataBase[DataBaseParametri.INDICE_PAR_MONOSTABILI][index++].setParValue(int.Parse(xNodePar.Attributes["value"].Value)); break;
                        }

                }
            }
            catch (Exception ex)
            {
                DeviceEvents.invokeDeviceErrorEvent(new DeviceError("DeviceError.3", ex, 253));
                return false;
            }

            localParsDataBase = tempDataBase;
            DeviceEvents.invokeDeviceMessageEvent(Resources.Resources.GetString("ParManager.Messages.5"));
            DeviceEvents.invokeLocalParsLoaded();
            return true;
        }

        internal static void setLocalParsValues(DataBaseParametri dbDispositivo)
        {
            if (dbDispositivo == null)
                throw new ArgumentException("Parametri passati non validi.");

            for (int parIndex = 0; parIndex < DeviceConstants.PAR_ASSE; parIndex++)
                localParsDataBase[DataBaseParametri.INDICE_PAR_ASSE_1][parIndex].setParValue(dbDispositivo[DataBaseParametri.INDICE_PAR_ASSE_1][parIndex].ParValue);

            for (int parIndex = 0; parIndex < DeviceConstants.PAR_ASSE; parIndex++)
                localParsDataBase[DataBaseParametri.INDICE_PAR_ASSE_2][parIndex].setParValue(dbDispositivo[DataBaseParametri.INDICE_PAR_ASSE_2][parIndex].ParValue);

            for (int parIndex = 0; parIndex < DeviceConstants.PAR_ASSE; parIndex++)
                localParsDataBase[DataBaseParametri.INDICE_PAR_ASSE_3][parIndex].setParValue(dbDispositivo[DataBaseParametri.INDICE_PAR_ASSE_3][parIndex].ParValue);

            for (int parIndex = 0; parIndex < DeviceConstants.PAR_ASSE; parIndex++)
                localParsDataBase[DataBaseParametri.INDICE_PAR_ASSE_4][parIndex].setParValue(dbDispositivo[DataBaseParametri.INDICE_PAR_ASSE_4][parIndex].ParValue); 

            for (int parIndex = 0; parIndex < DeviceConstants.PAR_MACCHINA; parIndex++)
                localParsDataBase[DataBaseParametri.INDICE_PAR_MACCHINA][parIndex].setParValue(dbDispositivo[DataBaseParametri.INDICE_PAR_MACCHINA][parIndex].ParValue);

            for (int parIndex = 0; parIndex < DeviceConstants.PAR_TIMER; parIndex++)
                localParsDataBase[DataBaseParametri.INDICE_PAR_TIMER][parIndex].setParValue(dbDispositivo[DataBaseParametri.INDICE_PAR_TIMER][parIndex].ParValue);

            for (int parIndex = 0; parIndex < DeviceConstants.PAR_CONTATORI; parIndex++)
                localParsDataBase[DataBaseParametri.INDICE_PAR_CONTATORI][parIndex].setParValue(dbDispositivo[DataBaseParametri.INDICE_PAR_CONTATORI][parIndex].ParValue);

            for (int parIndex = 0; parIndex < DeviceConstants.PAR_MONOSTABILI; parIndex++)
                localParsDataBase[DataBaseParametri.INDICE_PAR_MONOSTABILI][parIndex].setParValue(dbDispositivo[DataBaseParametri.INDICE_PAR_MONOSTABILI][parIndex].ParValue);

            DeviceEvents.invokeLocalParsLoaded();
        }

        internal static int[] getLocalParsValues()
        {
            int[] PARAM = new int[DeviceConstants.PAR_COUNT];

            int i = 0;
            foreach (ListaParametri parList in localParsDataBase)
                foreach (Parametro par in parList)
                    PARAM[i] = par.ParValue;

            return PARAM;
        }

        internal static bool saveLocalPars()
        {
            string parsFile = (string)Global.getConfigurationValue(Global.PARS_FILE_PROPERTY);

            if (!Path.GetFileName(parsFile).EndsWith(Global.FILE_PARS_EXTENSION)) 
                return saveLocalPars(Path.Combine(Global.GetApplicationPath(), Global.FILE_PARS_DEFAULT_NAME + Global.FILE_PARS_EXTENSION));  

            return saveLocalPars(parsFile);
        }

        internal static bool saveLocalPars(string fileName)
        {
            XmlDocument xDocPars = new XmlDocument();

            xDocPars.AppendChild(xDocPars.CreateNode(XmlNodeType.XmlDeclaration, string.Empty, string.Empty));

            XmlNode xNodeRoot = xDocPars.CreateNode(XmlNodeType.Element, "PARAMETRI", string.Empty);
            XmlAttribute xAttribute = xDocPars.CreateAttribute("Dispositivo");
            xAttribute.Value = "PORTER";
            xNodeRoot.Attributes.Append(xAttribute);

            foreach (ListaParametri parList in localParsDataBase)
            {
                XmlNode xNodeParList = xDocPars.CreateNode(XmlNodeType.Element, "PAR_LIST", string.Empty);
                xAttribute = xDocPars.CreateAttribute("Tipo");
                switch (parList.ListType)
                {
                    case TipoParametro.Asse:
                        xAttribute.Value = "1";
                        break;

                    case TipoParametro.Macchina:
                        xAttribute.Value = "2";
                        break;

                    case TipoParametro.Timer:
                        xAttribute.Value = "3";
                        break;

                    case TipoParametro.Contatori:
                        xAttribute.Value = "4";
                        break;

                    case TipoParametro.Monostabili:
                        xAttribute.Value = "5";
                        break;

                    case TipoParametro.none:
                        throw new ArgumentException("DataBase non valido!");
                }

                xNodeParList.Attributes.Append(xAttribute);
                xAttribute = xDocPars.CreateAttribute("Id");
                xAttribute.Value = parList.Id.ToString();
                xNodeParList.Attributes.Append(xAttribute);

                foreach (Parametro p in parList)
                {
                    XmlNode xNodePar = xDocPars.CreateNode(XmlNodeType.Element, "PAR", string.Empty);
                    xAttribute = xDocPars.CreateAttribute("value");
                    xAttribute.Value = p.ParValue.ToString();
                    xNodePar.Attributes.Append(xAttribute);

                    xNodeParList.AppendChild(xNodePar);
                }

                xNodeRoot.AppendChild(xNodeParList);
            }

            xDocPars.AppendChild(xNodeRoot);

            try
            {
                xDocPars.Save(fileName);
            }
            catch (Exception ex)
            {
                DeviceEvents.invokeDeviceErrorEvent(new DeviceError("DeviceError.5", ex, 255));
                return false;
            }

            return true;
        }

        internal static bool setLocalParValue(TipoParametro tipo, int id, int index, int value)
        {
            ListaParametri localParsList = new ListaParametri(TipoParametro.none);

            switch (tipo)
            {
                case TipoParametro.Asse:
                    switch (id)
                    {
                        case 0: localParsList = localParsDataBase[DataBaseParametri.INDICE_PAR_ASSE_1]; break;
                        case 1: localParsList = localParsDataBase[DataBaseParametri.INDICE_PAR_ASSE_2]; break;
                        case 2: localParsList = localParsDataBase[DataBaseParametri.INDICE_PAR_ASSE_3]; break;
                        case 3: localParsList = localParsDataBase[DataBaseParametri.INDICE_PAR_ASSE_4]; break; 
                    }
                    break;

                case TipoParametro.Macchina:    localParsList = localParsDataBase[DataBaseParametri.INDICE_PAR_MACCHINA];       break;
                case TipoParametro.Timer:       localParsList = localParsDataBase[DataBaseParametri.INDICE_PAR_TIMER];          break;
                case TipoParametro.Contatori:   localParsList = localParsDataBase[DataBaseParametri.INDICE_PAR_CONTATORI];      break;
                case TipoParametro.Monostabili: localParsList = localParsDataBase[DataBaseParametri.INDICE_PAR_MONOSTABILI];    break;

                case TipoParametro.none:
                    throw new ArgumentException("Tipo di parametro non valido!");
            }

            if (index >= 0 && index < localParsList.Count)
                return localParsList[index].setParValue(value);

            return false;
        }

        internal static bool setLocalParValue(TipoParametro tipo, int index, int value)
        {
            return setLocalParValue(tipo, 0, index, value);
        }
    }

    public class DataBaseParametri : List<ListaParametri>
    {
        internal const int INDICE_PAR_ASSE_1 = 0;
        internal const int INDICE_PAR_ASSE_2 = 1;
        internal const int INDICE_PAR_ASSE_3 = 2;
        internal const int INDICE_PAR_ASSE_4 = 3; 
        internal const int INDICE_PAR_MACCHINA = 4;
        internal const int INDICE_PAR_TIMER = 5;
        internal const int INDICE_PAR_CONTATORI = 6;
        internal const int INDICE_PAR_MONOSTABILI = 7;

        public DataBaseParametri()
        {
            Add(new ListaParametri(TipoParametro.Asse, 0));
            Add(new ListaParametri(TipoParametro.Asse, 1));
            Add(new ListaParametri(TipoParametro.Asse, 2));
            Add(new ListaParametri(TipoParametro.Asse, 3)); 
            Add(new ListaParametri(TipoParametro.Macchina));
            Add(new ListaParametri(TipoParametro.Timer));
            Add(new ListaParametri(TipoParametro.Contatori));
            Add(new ListaParametri(TipoParametro.Monostabili));
        }

        public DataBaseParametri Clone()
        {
            DataBaseParametri db = new DataBaseParametri();
            ListaParametri currentList;
            db.Clear();

            foreach (ListaParametri lp in this)
            {
                db.Add(currentList = new ListaParametri(lp.ListType, lp.Id, lp.Name));

                foreach (Parametro p in lp)
                    currentList.Add(new Parametro(p));
            }

            return db;
        }

        public ListaParametri GetParList(TipoParametro tipo)
        {
            switch (tipo)
            {
                case TipoParametro.Asse:
                    throw new ArgumentException("Per i parametri asse è richiesto anche l'indice.");

                case TipoParametro.Macchina:
                    return this[INDICE_PAR_MACCHINA];

                case TipoParametro.Timer:
                    return this[INDICE_PAR_TIMER];

                case TipoParametro.Contatori:
                    return this[INDICE_PAR_CONTATORI];

                case TipoParametro.Monostabili:
                    return this[INDICE_PAR_MONOSTABILI];

                case TipoParametro.none:
                default:
                    throw new ArgumentException("Tipo di parametri richiesto non valido.");
            }
        }

        public ListaParametri GetParList(TipoParametro tipo, int index)
        {
            switch (tipo)
            {
                case TipoParametro.Asse:
                    switch (index)
                    {
                        case 0:
                            return this[INDICE_PAR_ASSE_1];
                        case 1:
                            return this[INDICE_PAR_ASSE_2];
                        case 2:
                            return this[INDICE_PAR_ASSE_3];
                        case 3:
                            return this[INDICE_PAR_ASSE_4]; 
                    }

                    throw new ArgumentException("Indice parametri ASSE non valido.");

                default:
                    return GetParList(tipo);
            }
        }
    }

    public class ListaParametri : List<Parametro>
    {
        #region Costanti

        public const int PAR_UNITA_MISURA_INDEX = 10;

        private TipoParametro listType = TipoParametro.none;
        public TipoParametro ListType
        {
            get { return listType; }
        }

        private string name = string.Empty;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int id = 0;
        public int Id
        {
            get { return id; }
        }

        public ListaParametri(TipoParametro listType, int id)
            : base()
        { this.listType = listType; this.id = id; }

        public ListaParametri(TipoParametro listType, int id, string listName)
            : this(listType, id)
        { this.name = listName; }

        public ListaParametri(TipoParametro listType)
            : base()
        { this.listType = listType; }

        public ListaParametri(ListaParametri collection, TipoParametro listType, int id)
            : base((IEnumerable<Parametro>)collection)
        { this.listType = listType; this.id = id; this.name = collection.name; }

        public new void Add(Parametro toAdd)
        {
            if (toAdd.ParTipo != listType)
                throw new ArgumentException("Tipo di parametro non compatibile.");

            toAdd.ParIndex = Count;
            base.Add(toAdd);
        }

        public new short[] ToArray()
        {
            short[] allValues = new short[Count];

            for (int i = 0; i < allValues.Length; i++)
                allValues[i] = (Int16)this[i].ParValue;

            return allValues;
        }

        #endregion
    }

    public enum TipoParametro
    {
        none = 0,
        Asse,
        Macchina,
        Timer,
        Contatori,
        Monostabili
    }

    public class Parametro
    {
        private string parName = string.Empty;
        private string parNameResource = string.Empty;
        public string ParName
        {
            get { return parName; }
        }

        private string parDesc = string.Empty;
        private string parDescResource = string.Empty;
        public string ParDesc
        {
            get { return parDesc; }
        }

        private int parMaxValue = 0;
        public int ParMaxValue
        {
            get { return parMaxValue; }
        }

        private int parMinValue = 0;
        public int ParMinValue
        {
            get { return parMinValue; }
        }

        private int parValue = 0;
        public int ParValue
        {
            get { return parValue; }
        }

        private int parIndex = 0;
        public int ParIndex
        {
            get { return parIndex; }
            internal set { parIndex = value; }
        }

        private bool active;
        public bool IsActive
        {
            get { return active; }
        }

        private TipoParametro parTipo = TipoParametro.none;
        public TipoParametro ParTipo
        {
            get { return parTipo; }
        }

        internal Parametro(string name, string desc, int minValue, int maxValue, int value, bool isActive, TipoParametro tipo)
        {
            Resources.Settings.SettingChanged += onSettingChanged;

            parName = Resources.Resources.GetString(parNameResource = name);
            parDesc = Resources.Resources.GetString(parDescResource = desc);
            parMinValue = minValue;
            parMaxValue = maxValue;
            parValue = value;
            active = isActive;
            parTipo = tipo;
        }

        internal Parametro(Parametro source)
            : this(source.parName, source.parDesc, source.parMinValue, source.parMaxValue, source.parValue, source.active, source.parTipo)
        { }

        public bool setParValue(int value)
        {
            if (!active)
            {
                return true;
            }

            if (value > parMaxValue || value < parMinValue)
            {
                DeviceEvents.invokeDeviceErrorEvent(new DeviceError("DeviceError.6", null, 251));
                return false;
            }

            parValue = value;
            return true;
        }

        private void onSettingChanged(object sender, Resources.SettingChangedEventArgs e)
        {
            if (e.ChangedOption == Resources.SettingOptions.Language)
            {
                parName = Resources.Resources.GetString(parNameResource);
                parDesc = Resources.Resources.GetString(parDescResource);
            }
        }
    }
}
