
using System.IO;

namespace FerPROJ.Design.Class
{
    public static class CStaticVariable
    {
        private static string filePath = "connString.txt";
        private static string filePathEntity = "entityConnString.txt";
        private static string defaultString = "Server=localhost;Port=3309;Database=schoolmanagement;Uid=adminserver;Pwd=admin123!@#;";
        public static string Username { get; set; } = "";
        public static string UserLevel { get; set; }
        public static string UserID { get; set; }
        public static string Name { get; set; }
        public static string Version { get; set; } = "";
        public static string mainConnection = File.Exists(filePath) ? CEnryption.Decrypt(File.ReadAllText(filePath)) : defaultString;
        public static string connString1;
        public static string connString2;
        public static string entityConnString { get; set; } = File.Exists(filePathEntity) ? CEnryption.Decrypt(File.ReadAllText(filePathEntity)) : defaultString;
    }
    
}
