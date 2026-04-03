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
        public static bool SetAssemblyAndCheckVersion(Assembly assembly) {
            //
            SystemName = assembly.GetName().Name.Replace(".", "");
            SystemVersion = assembly.GetName().Version.ToString();
            //
            return CheckVersionAsync().RunTask();
        }
        private static async Task<bool> CheckVersionAsync() {
            // "LMSMain/LMSMain_version"
            var versionUrl = $"{SystemName}/{SystemName}_version";

            // Fetch version data from the specified URL
            var data = await CApiManager.GetDataAsync<VersionModel>($"https://fericdev.github.io/version-control/{versionUrl}.json");

            // Check if the data is null or empty
            if (data.IsNullOrEmpty()) {
                CDialogManager.Warning(
                    $"There is a problem with the system version. Please contact the system administrator.", "Version Error");
                return false;
            }

            // Compare the fetched version with the current system version
            if (!data.SystemVersion.Equals(SystemVersion) && data.SystemName.Equals(SystemName)) {
                CDialogManager.Warning(
                    $"A new version of {SystemName} is available: {data.SystemVersion}. " +
                    $"\nYou are currently using version {SystemVersion}. " +
                    $"\nPlease update to the latest version for the best experience.", "Update Available");
                return false;
            }
            return true;
        }
    }
    public class VersionModel {
        public string SystemName { get; set; }
        public string SystemVersion { get; set; }
        public string DateUpdated { get; set; }
    }
}
