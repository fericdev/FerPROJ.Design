
using System.IO;

namespace FerPROJ.Design.Class
{
    public static class CStaticVariable
    {
        private static string DefaultString = $"Server={CLibFilesReader.GetValue("Server", "DatabaseConfig")};" +
                                              $"Port={CLibFilesReader.GetValue("Port", "DatabaseConfig")};" +
                                              $"Database={CLibFilesReader.GetValue("DatabaseName", "DatabaseConfig")};" +
                                              $"Uid={CLibFilesReader.GetValue("Uid", "DatabaseConfig")};" +
                                              $"Pwd={CLibFilesReader.GetValue("Pwd", "DatabaseConfig")};" +
                                              $"SslMode={CLibFilesReader.GetValue("SslMode", "DatabaseConfig")};";
        public static string USERNAME { get; set; } = "";
        public static string USER_LEVEL { get; set; }
        public static string USER_ID { get; set; }
        public static string NAME { get; set; }
        public static string CONN_STRING_1;
        public static string CONN_STRING_2;
        public static string ENTITY_CONNECTION_STRING { get; set; } = DefaultString;
        public static bool ENTITY_CONNECTION_STATUS { get; set; }
        public static string ACTIVE_STATUS = "ACTIVE";
        public static string IN_ACTIVE_STATUS = "IN-ACTIVE";
    }
    
}
