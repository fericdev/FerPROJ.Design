namespace FerPROJ.Design.Class
{
    public static class CSet
    {
        public static void SetConnectionString(string Hostname, string Username, string Password, int Port, string Database) {
            CStaticVariable.connString1 = $"Server={Hostname};Port={Port};Database={Database};Uid={Username};Pwd={Password};";
        }
        public static void SetConnectionString2(string Hostname, string Username, string Password, int Port, string Database) {
            CStaticVariable.connString2 = $"Server={Hostname};Port={Port};Database={Database};Uid={Username};Pwd={Password};";
        }
        public static void SetEntityConnectionString(string Hostname, string Username, string Password, string Port, string Database, string sslMode) {
            CStaticVariable.entityConnString = $"server={Hostname};user id={Username};port={Port};persistsecurityinfo=True;database={Database};password={Password};{sslMode}";
        }
    }
}
