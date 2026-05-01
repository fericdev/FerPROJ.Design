
using System;
using System.IO;

namespace FerPROJ.Design.Class
{
    public static class CAppConstants
    {
        #region Db Constants
        private static string DefaultString = $"Server={CConfigurationManager.GetValue("Server", "DatabaseConfig")};" +
                                              $"Port={CConfigurationManager.GetValue("Port", "DatabaseConfig")};" +
                                              $"Database={CConfigurationManager.GetValue("DatabaseName", "DatabaseConfig")};" +
                                              $"Uid={CConfigurationManager.GetValue("Uid", "DatabaseConfig")};" +
                                              $"Pwd={CConfigurationManager.GetValue("Pwd", "DatabaseConfig")};" +
                                              $"SslMode={CConfigurationManager.GetValue("SslMode", "DatabaseConfig")};";

        public static string CONN_STRING_1;
        public static string CONN_STRING_2;
        public static string ENTITY_CONNECTION_STRING { get; set; } = DefaultString;
        public static string BASE_CONNECTION_STRING_NAME { get; set; }
        public static bool DATABASE_CONNECTION_SUCCESS { get; set; }
        public static string API_BASE_URL { get; set; }
        #endregion

        #region User Constants
        public static string USERNAME { get; set; } = "";
        public static string USER_LEVEL { get; set; }
        public static Guid USER_ID { get; set; }
        public static string NAME { get; set; }
        #endregion

        #region Status Constants
        public static string ACTIVE_STATUS = "ACTIVE";
        public static string IN_ACTIVE_STATUS = "IN-ACTIVE";
        public static string APPLLICATION_ID = CConfigurationManager.GetValue("ApplicationId", "DatabaseConfig");
        #endregion

        #region Type Contants
        public static Type DB_CONTEXT_TYPE { get; set; }
        #endregion

        #region Splash tracker
        public static DateTime SPLASHER_LAST_SHOWN { get; set; }
        #endregion
    }

}
