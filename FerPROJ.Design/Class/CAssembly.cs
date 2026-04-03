using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            CheckVersionAsync().RunTask();
        }
        private static async Task CheckVersionAsync() {
            var data = await CApiManager.GetDataAsync<VersionModel>("https://fericdev.github.io/version-control/lms_version.json");
            if (data.IsNullOrEmpty())
                return;

            if (!data.SystemVersion.Equals(SystemVersion) && data.SystemName.Equals(SystemName)) {
                CDialogManager.Warning(
                    $"A new version of {SystemName} is available: {data.SystemVersion}. " +
                    $"You are currently using version {SystemVersion}. Please update to the latest version for the best experience.", "Update Available");
                Application.Exit();
            }
        }
    }
    public class VersionModel {
        public string SystemName { get; set; }
        public string SystemVersion { get; set; }
        public string DateUpdated { get; set; }
    }
}
