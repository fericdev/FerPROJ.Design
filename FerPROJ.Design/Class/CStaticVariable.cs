
using System.IO;

namespace FerPROJ.Design.Class
{
    public static class CStaticVariable
    {
        private static string filePath = "connString.txt";
        private static string defaultString = "Server=localhost;Port=3309;Database=schoolmanagement;Uid=adminserver;Pwd=admin123!@#;";
        public static string Username;
        public static string UserLevel;
        public static string UserID;
        public static string Name;
        public static string Version { get; set; } = "";
        public static string mainConnection = File.Exists(filePath) ? CEnryption.Decrypt(File.ReadAllText(filePath)) : defaultString;
        public static string connString1;
        public static string connString2;
    }
    
}
