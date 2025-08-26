namespace FerPROJ.Design.Class
{
    public static class CSet
    {
        public static void SetConnectionString(string Hostname, string Username, string Password, int Port, string Database) {
            CStaticVariable.CONN_STRING_1 = $"Server={Hostname};Port={Port};Database={Database};Uid={Username};Pwd={Password};";
        }
        public static void SetConnectionString2(string Hostname, string Username, string Password, int Port, string Database) {
            CStaticVariable.CONN_STRING_2 = $"Server={Hostname};Port={Port};Database={Database};Uid={Username};Pwd={Password};";
        }
        public static void SetEntityConnectionString(string Hostname, string Username, string Password, string Port, string Database, string sslMode) {
            CStaticVariable.ENTITY_CONNECTION_STRING = $"server={Hostname};port={Port};database={Database};uid={Username};pwd={Password};{sslMode}";
        }
    }
}
