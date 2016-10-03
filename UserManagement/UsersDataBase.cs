using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using Resources;

namespace UserManagement
{
    public static class UsersDataBase
    {
        internal static void InitDataBase(UserList userList)
        {
            string dbDir = Path.Combine(Utils.GetApplicationPath(), Constants.USERS_DIR_NAME);

            // Controllo che esista la cartella.
            if (!Directory.Exists(dbDir))
                Directory.CreateDirectory(dbDir);

            // Il file delle statistiche è dato da 'ID_User'.sts 
            // Controllo i file di statistiche per ogni utente. Lo creo se non esiste.
            foreach (User user in userList)
            {
                string statsFile = Path.Combine(dbDir, user.Id + Constants.USERS_STATISTICS_EXTENSION);

                try
                {
                    if (!File.Exists(statsFile))
                    {
                        StreamWriter sw = File.CreateText(statsFile);

                        StringBuilder sb = new StringBuilder();
                        sb.Append(Constants.DISTANCE_FIELD);
                        sb.Append(":");
                        sb.Append("0");

                        sw.WriteLine(sb.ToString());

                        sw.Flush();
                        sw.Close();
                    }

                    user.StatisticFilePath = statsFile;
                }
                catch (Exception ex)
                {
                    user.StatisticFilePath = ex.Message;
                }
            }
        }
    } 
}
