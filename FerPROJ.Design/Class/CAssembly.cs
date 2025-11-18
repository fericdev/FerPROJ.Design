using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FerPROJ.Design.Class {
    public static class CAssembly {
        // Static properties to get the assembly name and version
        public static string SystemName { get; private set; }
        public static string SystemVersion { get; private set; }

        // Static constructor to initialize the properties
        public static void SetAssembly(Assembly assembly) {
            if (assembly == null) {
                throw new ArgumentNullException(nameof(assembly));
            }

            SystemName = assembly.GetName().Name;
            SystemVersion = assembly.GetName().Version.ToString();
        }
    }
}
