using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Reflection;
using System.IO;
using System.Drawing;
using System.Xml;
using System.Threading;

using LogManagement;

namespace Resources
{
    public enum ResourceType
    {
        String = 0,
        Image = 1
    }

    public static class ResourcesManager
    {
        private const string BASE_IMAGE_URL = "Resources.Images.";
        private const string STRINGS_BASE_XML_URL = "Resources.Strings.";
        private const string LANGUAGES_XML_URL = "Resources.Strings.Languages.xml";

        private static TaggedBitmapsList bitmaps;
        private static StringLanguageList stringDb;
        private static XmlDocument stringsXml;
        private static Assembly baseAssembly;  

        public static ReadOnlyCollection<StringLanguage> Languages
        {
            get { return stringDb.AsReadOnly(); }
        }

        private static readonly Bitmap emptyBitmap = new Bitmap(42, 42);

        private static string[] allResource;

        public static void LoadAllResources()
        {
            baseAssembly = Assembly.GetExecutingAssembly();
            allResource = baseAssembly.GetManifestResourceNames();
            bitmaps = new TaggedBitmapsList();
            stringDb = new StringLanguageList();
            Stream resourceStream; 

            foreach (string resource in allResource)
                    if (resource.StartsWith(BASE_IMAGE_URL))
                    {
                        resourceStream = baseAssembly.GetManifestResourceStream(resource);

                        Bitmap newBmp = new Bitmap(resourceStream);

                        resourceStream.Close();
                        resourceStream = null;

                        bitmaps.Add(new TaggedBitmap(resource, newBmp));
                    }
                    else if (string.Compare(resource, LANGUAGES_XML_URL) == 0)
                    {
                        resourceStream = baseAssembly.GetManifestResourceStream(resource);
                        XmlDocument xDocLanguages = new XmlDocument();
                        xDocLanguages.Load(resourceStream);
                        resourceStream.Close();

                        foreach (XmlNode node in xDocLanguages["Languages"])
                        {
                            StringLanguage sl;

                            string name = node.Attributes["text"].Value;
                            int id = int.Parse(node.Attributes["id"].Value);
                            string xml = node.Attributes["string_xml"].Value;
                            string bmp = node.Attributes["bitmap_flag"].Value;

                            XmlDocument xmlDoc = new XmlDocument();
                             
                            resourceStream = baseAssembly.GetManifestResourceStream(string.Format("{0}{1}", STRINGS_BASE_XML_URL, xml));
                            xmlDoc.Load(resourceStream);
                            resourceStream.Close(); 

                            sl = new StringLanguage(id, name, xmlDoc, bmp);

                            stringDb.Add(sl);
                        }
                    }
             
            Settings.LoadSettings();

            stringsXml = stringDb[(int)Settings.GetSetting(SettingOptions.Language)].XmlData;
        }

        public static string GetString(string resourceName)
        {
            return (string)GetResource(resourceName, ResourceType.String);
        }

        public static object GetResource(string resourceName, ResourceType type)
        {
            if (type == ResourceType.Image)
            {
                if (bitmaps == null) 
                    return emptyBitmap;

                return bitmaps.getBitmapFromTag(BASE_IMAGE_URL + resourceName);
            }
            else if (type == ResourceType.String)
            { 
                try
                {

                    XmlNodeList nodes = stringsXml["strings"].SelectNodes(string.Format("//label[@name='{0}']", resourceName));

                    if (nodes.Count > 0)
                        return nodes[0].InnerText;

                    return string.Empty;
                }
                catch (Exception ex)
                { 
                    return ex.Message; 
                }
            }

            return null;
        }

        public static void Dispose()
        {
            for (int i = 0; i < bitmaps.Count; i++) 
                bitmaps[i].Dispose(); 

            bitmaps = null;
        }

        internal static void manageLanguageChanged()
        {
            stringsXml = stringDb[(int)Settings.GetSetting(SettingOptions.Language)].XmlData;
        }
    }

    public enum SettingOptions
    {
        None = 0,

        Language = 1,
        RemotingBridgeIp = 2,
        RemotingBridePort = 3,
        RemotingUpdateInterval = 4,
        RemotingEnable = 5
    }

    public static class Settings
    { 
        public static event SettingChangedEventHandler SettingChanged;

        public static event EventHandler LoadingTextOn;
        public static event EventHandler LoadingTextDone;

        private const string LOG_NAME = "Settings";

        private static readonly string SETTINGS_PATH = Path.Combine(Utils.GetApplicationPath(), "Settings.xml");
        private const string SETTINGS_ROOT_NODE = "settings";

        public const string LANGUAGE_SETTINGS_GROUP = "language";  
        public const string REMOTING_SETTINGS_GROUP = "remoting"; 
         
        private static XmlDocument xDocSettings;

        internal static void LoadSettings()
        {
            if (!File.Exists(SETTINGS_PATH))
            {
                createSettignsXml(); // Se non esiste lo creo con i valori di default.
                return;
            }

            try
            {
                xDocSettings = new XmlDocument();
                xDocSettings.Load(SETTINGS_PATH);

                if (!checkSettingsIntegrity())
                {
                    LogManager.WriteLog(LOG_NAME, "Integrità dei dati compromessa. Ritorno alle impostazioni di default.");
                    createSettignsXml(); // Ricreo l'xml con i settaggi di default.
                    return;
                }
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(LOG_NAME, ex.Message);
                LogManager.WriteLog(LOG_NAME, ex.StackTrace);
                createSettignsXml(); // Ricreo l'xml con i settaggi di default.
            }
        }

        private static void createSettignsXml()
        {
            xDocSettings = new XmlDocument();
            xDocSettings.AppendChild(xDocSettings.CreateNode(XmlNodeType.XmlDeclaration, string.Empty, string.Empty));

            XmlNode xNodeRoot = xDocSettings.CreateNode(XmlNodeType.Element, "settings", string.Empty);

            XmlNode xNode = xDocSettings.CreateNode(XmlNodeType.Element, "language", string.Empty);
            XmlAttribute xAtt = xDocSettings.CreateAttribute("selected");
            xAtt.Value = StringLanguageList.DEFAULT_LANGUAGE.ToString();
            xNode.Attributes.Append(xAtt);

            xNodeRoot.AppendChild(xNode);

            xNode = xDocSettings.CreateNode(XmlNodeType.Element, "remoting", string.Empty);
            xAtt = xDocSettings.CreateAttribute("enable");
            xAtt.Value = false.ToString();
            xNode.Attributes.Append(xAtt);

            xNodeRoot.AppendChild(xNode);

            xNode = xDocSettings.CreateNode(XmlNodeType.Element, "network_bridge", string.Empty);
            xAtt = xDocSettings.CreateAttribute("ip");
            xAtt.Value = "0.0.0.0";
            xNode.Attributes.Append(xAtt);
            xAtt = xDocSettings.CreateAttribute("port");
            xAtt.Value = "0";
            xNode.Attributes.Append(xAtt);

            xNodeRoot["remoting"].AppendChild(xNode);

            xNode = xDocSettings.CreateNode(XmlNodeType.Element, "remote_update", string.Empty);
            xAtt = xDocSettings.CreateAttribute("interval");
            xAtt.Value = "5000";

            xNodeRoot["remoting"].AppendChild(xNode);

            xDocSettings.AppendChild(xNodeRoot);
              
            saveSettings();

        } 

        private static void saveSettings()
        {
            addHashKey();
            xDocSettings.Save(SETTINGS_PATH);

            if (!checkSettingsIntegrity())
                LogManager.WriteLog(LOG_NAME, "ERRORE! Salvataggio delle impostazioni non riuscita. Integrità compromessa.");
        }

        public static object GetSetting(SettingOptions option)
        {
            try
            {
                switch (option)
                {
                    case SettingOptions.Language:
                        return int.Parse(xDocSettings[SETTINGS_ROOT_NODE][LANGUAGE_SETTINGS_GROUP].Attributes["selected"].Value);

                    case SettingOptions.RemotingBridePort:
                        return xDocSettings[SETTINGS_ROOT_NODE][REMOTING_SETTINGS_GROUP]["network_bridge"].Attributes["ip"].Value;

                    case SettingOptions.RemotingBridgeIp:
                        return int.Parse(xDocSettings[SETTINGS_ROOT_NODE][REMOTING_SETTINGS_GROUP]["network_bridge"].Attributes["port"].Value);

                    case SettingOptions.RemotingEnable:
                        return bool.Parse(xDocSettings[SETTINGS_ROOT_NODE][REMOTING_SETTINGS_GROUP].Attributes["enable"].Value);

                    case SettingOptions.RemotingUpdateInterval:
                        return int.Parse(xDocSettings[SETTINGS_ROOT_NODE][REMOTING_SETTINGS_GROUP]["remote_update"].Attributes["ip"].Value); 

                    default:
                        return string.Empty;
                } 
            }
            catch
            {
                return string.Empty;
            }
        }

        public static void SetSetting(SettingOptions option, string value)
        {
            try
            {
                switch (option)
                {
                    case SettingOptions.Language: 
                        xDocSettings[SETTINGS_ROOT_NODE][LANGUAGE_SETTINGS_GROUP].Attributes["selected"].Value = value;
                        ResourcesManager.manageLanguageChanged();
                        break;

                    case SettingOptions.RemotingBridePort:
                        xDocSettings[SETTINGS_ROOT_NODE][REMOTING_SETTINGS_GROUP]["network_bridge"].Attributes["ip"].Value = value;
                        break;

                    case SettingOptions.RemotingBridgeIp:
                        xDocSettings[SETTINGS_ROOT_NODE][REMOTING_SETTINGS_GROUP]["network_bridge"].Attributes["port"].Value = value;
                        break;

                    case SettingOptions.RemotingEnable:
                        xDocSettings[SETTINGS_ROOT_NODE][REMOTING_SETTINGS_GROUP].Attributes["enable"].Value = value;
                        break;

                    case SettingOptions.RemotingUpdateInterval:
                        xDocSettings[SETTINGS_ROOT_NODE][REMOTING_SETTINGS_GROUP]["remote_update"].Attributes["ip"].Value = value;
                        break;
                }

                saveSettings();

                invokeSettingsChanged(option, value);
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(LOG_NAME, ex.Message);
                LogManager.WriteLog(LOG_NAME, ex.StackTrace);
                return;
            } 
        }

        private static void invokeSettingsChanged(SettingOptions option, string value)
        { 
            new Thread((ThreadStart)delegate
            {
                Thread.Sleep(1000);

                LogManager.WriteLog(LOG_NAME, "Start appling.");

                try
                {
                    if (SettingChanged != null)
                        SettingChanged.Invoke(new object(), new SettingChangedEventArgs(option, value));
                }
                catch (Exception ex)
                {
                    LogManager.WriteLog(LOG_NAME, "Settings changed handlers error.");
                    LogManager.WriteLog(LOG_NAME, ex.Message);
                    LogManager.WriteLog(LOG_NAME, ex.StackTrace);
                }

                LogManager.WriteLog(LOG_NAME, "Appling done.");

                if (LoadingTextDone != null)
                    LoadingTextDone.Invoke(new object(), EventArgs.Empty);

                LogManager.WriteLog(LOG_NAME, "Event raised.");

            }).Start();

            if (LoadingTextOn != null)
                LoadingTextOn.Invoke(new object(), EventArgs.Empty);
        }

        // Aggiungo un hash per controllare l'integrità dei dati.
        private static void addHashKey()
        {
            string docText = xDocSettings.OuterXml;
            int hash = docText.GetHashCode();

            XmlNode nodeData = xDocSettings.CreateNode(XmlNodeType.Element, "data", string.Empty);
            XmlAttribute checkAtt = xDocSettings.CreateAttribute("check_key");
            checkAtt.Value = hash.ToString();

            nodeData.Attributes.Append(checkAtt);
            xDocSettings[SETTINGS_ROOT_NODE].AppendChild(nodeData);
        } 

        // Controllo hash per l'integrità.
        private static bool checkSettingsIntegrity()
        {
            try
            {
                int savedHash = int.Parse(xDocSettings["settings"]["data"].Attributes["check_key"].Value); 
                 
                //Remove the data element.
                xDocSettings["settings"].RemoveChild(xDocSettings["settings"]["data"]);

                LogManager.WriteLog(LOG_NAME, xDocSettings.OuterXml);

                int calculatedHash = xDocSettings.OuterXml.GetHashCode();

                return savedHash == calculatedHash;
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(LOG_NAME, ex.Message);
                LogManager.WriteLog(LOG_NAME, ex.StackTrace);
                LogManager.WriteLog(LOG_NAME, ex.GetType().FullName);
                return false;
            }
        }
    }

    public class StringLanguageList : List<StringLanguage>
    {
        internal const int DEFAULT_LANGUAGE = 1;

        internal StringLanguageList()
            : base()
        { }

        internal new void Add(StringLanguage toAdd)
        {
            base.Add(toAdd);
        }

        internal new void AddRange(IEnumerable<StringLanguage> toAdd)
        {
            base.AddRange(toAdd);
        }

        internal new void Remove(StringLanguage toRemove)
        {
            base.Remove(toRemove);
        }

        internal StringLanguage GetLanguageInfo(int id)
        {
            if (id < 0 || id >= Count)
                return this[DEFAULT_LANGUAGE];

            return this[id];
        }
    }

    public class StringLanguage
    {
        private string text = string.Empty;
        public string Text
        {
            get { return text; }
        }

        private int id = -1;
        internal int Id
        {
            get { return id; }
        }

        private XmlDocument xmlData;
        internal XmlDocument XmlData
        {
            get { return xmlData; }
        }

        private string bitmapName = string.Empty;
        public string BitmapName
        {
            get { return bitmapName; }
        }

        internal StringLanguage(int languageId, string languageName, XmlDocument xml, string bmp)
        {
            id = languageId;
            text = languageName;
            xmlData = xml;
            bitmapName = bmp;
        }
    }

    class TaggedBitmapsList : List<TaggedBitmap>
    {
        public Bitmap getBitmapFromTag(string tag)
        {
            foreach (TaggedBitmap bmp in this)
                if (string.Compare(tag, bmp.Name) == 0)
                    return bmp.Bmp;

            return null;
        } 
    }

    class TaggedBitmap
    {
        string name = string.Empty;
        public string Name
        {
            get { return name; }
        }

        Bitmap bmp;
        public Bitmap Bmp
        {
            get { return bmp; }
        }

        public TaggedBitmap(string bitmapName, Bitmap taggedBmp)
        {
            name = bitmapName;
            bmp = taggedBmp;
        }

        internal void Dispose()
        {
            Bmp.Dispose();
            bmp = null;
        }
    }

    public static class Utils
    { 
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
    }
}
