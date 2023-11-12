using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerPROJ.Design.Class
{
    public static class CSet
    {
        public static void SetConnectionString(string Hostname, string Username, string Password, int Port, string Database)
        {
            CStaticVariable.connString1 = $"Server={Hostname};Port={Port};Database={Database};Uid={Username};Pwd={Password};";
        }
        public static void SetConnectionString2(string Hostname, string Username, string Password, int Port, string Database)
        {
            CStaticVariable.connString2 = $"Server={Hostname};Port={Port};Database={Database};Uid={Username};Pwd={Password};";
        }
    }
}
