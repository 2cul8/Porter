using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement
{
    internal static class Constants
    {
        // FILES
        internal const string USERS_DIR_NAME = "users";
        internal const string USERS_STATISTICS_EXTENSION = ".sts";

        // STATISTICHE FIELDS
        internal const string DISTANCE_FIELD = "distance"; 

        // STATISTICS CMD
        internal const byte RESET_STORICO_PARZIALI = 50;
        internal const byte RESET_STORICO = 51;
        internal const byte RESET_PARZIALI = 52;
        internal const byte RESET_ENCODER = 53;
    }
}
