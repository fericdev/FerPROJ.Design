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
            //
            SystemName = assembly.GetName().Name.Replace(".", "");
            SystemVersion = assembly.GetName().Version.ToString();
            //
        }
        private static async Task CheckVersionAsync() {
            // "LMSMain/LMSMain_version"
            var versionUrl = $"{SystemName}/{SystemName}_version";

            // Fetch version data from the specified URL
            var data = await CApiManager.GetDataAsync<VersionModel>($"https://fericdev.github.io/version-control/{versionUrl}.json");

            if (data.IsNullOrEmpty()) {
                return;
            }

            if (data.SystemVersion.Equals(SystemVersion)) {
                return;
            }

            await CNotificationManager.CreateNotificationAndDisplayAsync(
                new NotificationModel {
                    Title = $"New update available. {data.SystemVersion}",
                    Description = "Please contact the administrator to update your system " +
                                  "to the latest version.",
                    DisplayTimeSeconds = 5,
                    DelayTimeSeconds = 5,
                }, null);
        }
        public static async Task RunVersionCheckerAsync() {
            await CBackgroundTaskManager.RunTaskInBackgroundAsync(CheckVersionAsync, 60);
        }
    }
    public class VersionModel {
        public string SystemName { get; set; }
        public string SystemVersion { get; set; }
        public string DateUpdated { get; set; }
    }
}
