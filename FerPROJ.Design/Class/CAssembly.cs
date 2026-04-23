using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
        public static string SystemNameFull { get; private set; }

        // Static constructor to initialize the properties
        public static void SetAssembly<DbContext>(Assembly assembly) {
            //
            SystemName = assembly.GetName().Name.Replace(".", "");
            SystemNameFull = assembly.GetName().Name;
            SystemVersion = assembly.GetName().Version.ToString();
            //
            CAppConstants.DB_CONTEXT_TYPE = typeof(DbContext);
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
                    Title = $"System Update Required v{data.SystemVersion}",
                    Description = "A newer version of the system is available." +
                                "\nDo you want to proceed with the update now?",
                    DisplayTimeSeconds = 5,
                    DelayTimeSeconds = 5,
                    ShowInAlert = true,
                }, RunUpdaterAsync);
        }
        public static async Task RunVersionCheckerAsync() {
            await CBackgroundTaskManager.RunTaskInBackgroundAsync(CheckVersionAsync, 60);
        }
        private static async Task RunUpdaterAsync() {
            // "LMSMain/LMSMain_version"
            var zip = $"{SystemName}/output.zip";

            var zipFileUrl = $"https://fericdev.github.io/version-control/{zip}";

            LaunchUpdater(AppDomain.CurrentDomain.BaseDirectory, zipFileUrl);
        }
        private static void LaunchUpdater(string appPath, string downloadUrl) {

            string updaterPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Updater", "UpdaterManagementSystem.exe");

            if (!File.Exists(updaterPath)) {
                MessageBox.Show("Updater not found.");
                return;
            }

            var args = $"{Quote(appPath)} {Quote(downloadUrl)} {Quote(SystemNameFull + ".exe")}";

            Process.Start(new ProcessStartInfo {
                FileName = updaterPath,
                Arguments = args,
                UseShellExecute = true,
                
            });

            Application.Exit(); // important: close main app
        }
        private static string Quote(string value) {
            if (string.IsNullOrEmpty(value)) return "\"\"";
            // If the path ends in a backslash, the " at the end gets escaped. 
            // We add an extra backslash to prevent that.
            if (value.EndsWith("\\")) {
                return $"\"{value}\\\"";
            }
            return $"\"{value}\"";
        }
    }
    public class VersionModel {
        public string SystemName { get; set; }
        public string SystemVersion { get; set; }
        public string DateUpdated { get; set; }
    }
}
