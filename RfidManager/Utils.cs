using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace RfidManager
{
    internal static class Utils
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
