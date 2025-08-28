
using System;
using System.IO;

namespace FerPROJ.Design.Class
{
    public static class CAppConstants
    {
        private static string DefaultString = $"Server={CConfigurationManager.GetValue("Server", "DatabaseConfig")};" +
                                              $"Port={CConfigurationManager.GetValue("Port", "DatabaseConfig")};" +
                                              $"Database={CConfigurationManager.GetValue("DatabaseName", "DatabaseConfig")};" +
                                              $"Uid={CConfigurationManager.GetValue("Uid", "DatabaseConfig")};" +
                                              $"Pwd={CConfigurationManager.GetValue("Pwd", "DatabaseConfig")};" +
                                              $"SslMode={CConfigurationManager.GetValue("SslMode", "DatabaseConfig")};";
        public static string USERNAME { get; set; } = "";
        public static string USER_LEVEL { get; set; }
        public static Guid USER_ID { get; set; }
        public static string NAME { get; set; }
        public static string CONN_STRING_1;
        public static string CONN_STRING_2;
        public static string ENTITY_CONNECTION_STRING { get; set; } = DefaultString;
        public static bool DATABASE_CONNECTION_SUCCESS { get; set; }
        public static string ACTIVE_STATUS = "ACTIVE";
        public static string IN_ACTIVE_STATUS = "IN-ACTIVE";
    }
    
}
