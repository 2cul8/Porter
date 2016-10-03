using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

using LogManagement;

namespace LocationManagement
{
    public static class LocationManager
    {
        private const string LOG_FILE_NAME = "LocationManagement";

        private static LocationsList locations;
        public static LocationsList Locations
        {
            get { return locations; }
        }

        public static void SetLocationsList(XmlDocument doc)
        {
            try
            {
                LogManager.WriteLog(LOG_FILE_NAME, "Aggiornamento lista delle locazioni in corso...");
                locations = new LocationsList();

                foreach (XmlNode xNode in doc["Locations"])
                {
                    string id = xNode.Attributes["id"].Value;
                    string name = xNode.Attributes["name"].Value;

                    locations.Add(new Location(id, name));
                    LogManager.WriteLog(LOG_FILE_NAME, string.Format("{0}[{1}] Aggiunto.", name, id));
                }
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(LOG_FILE_NAME, ex.Message);
                LogManager.WriteLog(LOG_FILE_NAME, ex.StackTrace);
            }

            LogManager.WriteLog(LOG_FILE_NAME, "Aggiornamento lista delle locazioni concluso.");
        }
    }

    public class LocationsList : List<Location>
    { }

    public class Location
    {
        private string id = string.Empty;
        public string Id
        {
            get { return id; }
        }

        private string name = string.Empty;
        public string LocationName
        {
            get { return name; }
        }

        public Location(string locId, string locName)
        {
            id = locId;
            name = locName;
        }
    }
}
