using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LogManagement
{
    public static class LogManager
    {
        private const string LOG_DIR = "Logs";
        private const string LOG_EXTENSION = ".log";
        private const string LOG_MANAGER_LOG_FILE_NAME = "LogManager";

        private static string logsDirectory = string.Empty;

        public static void SetDirectory(string dir)
        {
            if (string.IsNullOrEmpty(dir))
                return;
            
            try
            {
                string logDir = Path.Combine(dir, LOG_DIR);

                if (!Directory.Exists(logDir))
                    Directory.CreateDirectory(logDir);

                foreach (string file in Directory.GetFiles(logDir))
                    File.Delete(file);

                logsDirectory = logDir;
            }
            catch
            { }
        }

        public static void WriteLog(string logName, string toWrite)
        {
            StreamWriter sw;
            string logFileName = string.Concat(logName, ".log");
            string logFilePath = Path.Combine(logsDirectory, string.Format("{0}{1}", logName, LOG_EXTENSION));

            try
            {
                sw = !File.Exists(logFilePath) ? File.CreateText(logFilePath) : new StreamWriter(File.Open(logFilePath, FileMode.Append)); 
                sw.WriteLine(string.Format("- ({0}) {1}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), toWrite));
                sw.Flush();
                sw.Close();
            }
            catch (Exception ex)
            {
                WriteLog(LOG_MANAGER_LOG_FILE_NAME,string.Format("Errore: {0} [mess= {1}]", ex.Message, toWrite));
            }
        }
    }
}
