using FerPROJ.Design.FormModels;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FerPROJ.Design.Class {
    public static class CGoogleDriveManager {

        #region Services
        private static DriveService _service;
        private static bool _isServiceAccount;

        private static void Initialize() {
            if (_service != null) return;

            var credentialPath = CConfigurationManager.GetOrCreateJsonFromModel(new OAuthCredentialModel(), "gdrivecredentials.json", false);

            if (_isServiceAccount) {
                var credential = CredentialFactory.FromFile<ServiceAccountCredential>(credentialPath)
                                                  .ToGoogleCredential()
                                                  .CreateScoped(DriveService.Scope.Drive);

                _service = new DriveService(new BaseClientService.Initializer() {
                    HttpClientInitializer = credential,
                    ApplicationName = "MySQL Backup System"
                });
            }
            else {
                UserCredential credential;

                using (var stream = new FileStream(credentialPath, FileMode.Open, FileAccess.Read)) {
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.FromStream(stream).Secrets,
                        new[] { DriveService.Scope.Drive },
                        "user",
                        CancellationToken.None,
                        new FileDataStore("token.json", true)
                    ).Result;
                }

                _service = new DriveService(new BaseClientService.Initializer() {
                    HttpClientInitializer = credential,
                    ApplicationName = "MySQL Backup System"
                });
            }

        }

        public static DriveService Service {
            get {
                if (_service == null) {
                    Initialize();
                }

                return _service;
            }
        }
        #endregion

        #region Upload 
        public static async Task UploadAsync(this string filePath, string folderNameOrId) {
            try {
                var service = Service;

                string folderId = await GetOrCreateFolderAsync(service, folderNameOrId);

                var fileMetadata = new Google.Apis.Drive.v3.Data.File() {
                    Name = Path.GetFileName(filePath),
                    Parents = new List<string> { folderId }
                };

                using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read)) {
                    var request = service.Files.Create(fileMetadata, stream, "application/octet-stream");
                    request.Fields = "id";
                    request.SupportsAllDrives = true;
                    var result = await request.UploadAsync();
                }
            }
            catch {
                CDialogManager.Warning("Error occurred while uploading the file to Google Drive.");
            }
        }
        private static async Task<string> GetOrCreateFolderAsync(DriveService service, string folderName) {
            try {
                var listRequest = service.Files.List();

                listRequest.Q = $"mimeType='application/vnd.google-apps.folder' and name='{folderName}' and trashed=false";
                listRequest.Fields = "files(id, name)";

                // IMPORTANT for service accounts / shared drives
                listRequest.SupportsAllDrives = true;
                listRequest.IncludeItemsFromAllDrives = true;

                var result = await listRequest.ExecuteAsync();

                var folder = result.Files.FirstOrDefault();
                if (folder != null)
                    return folder.Id;

                var folderMetadata = new Google.Apis.Drive.v3.Data.File() {
                    Name = folderName,
                    MimeType = "application/vnd.google-apps.folder",
                    Parents = new List<string> { "1sPAKa9x0yqphr-3hXbNp8DOULjDx8ML5" }
                };

                var createRequest = service.Files.Create(folderMetadata);
                createRequest.Fields = "id";

                // IMPORTANT for shared drives / service accounts
                createRequest.SupportsAllDrives = true;

                var createdFolder = await createRequest.ExecuteAsync();

                return createdFolder.Id;
            }
            catch {
                CDialogManager.Warning("Error occurred while accessing or creating the folder on Google Drive.");
                return string.Empty;
            }
        }
        #endregion

        #region Get
        public static async Task GetAsync(this string fileId, string savePath) {
            var service = Service;

            var request = service.Files.Get(fileId);

            using (var stream = new FileStream(savePath, FileMode.Create, FileAccess.Write)) {
                await request.DownloadAsync(stream);
            }
        }
        #endregion
    }
}
