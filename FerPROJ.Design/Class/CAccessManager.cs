using Microsoft.Office.Interop.Word;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FerPROJ.Design.Class {
    public static class CAccessManager {

        #region Getters
        public static string RandomBankNo() {
            var r1 = RandomNumber(4);
            var r2 = RandomNumber(4);
            var r3 = RandomNumber(4);
            var r4 = RandomNumber(4);
            return $"{r1} {r2} {r3} {r4}";
        }
        public static int RandomNumber(int length) {
            var randomExt = new RNGCryptoServiceProvider();

            char[] randomNumber = new char[length];
            byte[] randomBytes = new byte[length];

            randomExt.GetBytes(randomBytes);

            for (int i = 0; i < length; i++) {
                int randomNumberIndex = randomBytes[i] % 10;
                randomNumber[i] = (char)('0' + randomNumberIndex);
            }
            return Convert.ToInt32(new string(randomNumber));
        }
        public static string RandomString(int length) {
            Random random = new Random();

            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] boldLetters = new char[length];

            for (int i = 0; i < length; i++) {
                char randomLetter = letters[random.Next(letters.Length)];
                boldLetters[i] = randomLetter;
            }

            string boldString = new string(boldLetters);
            return boldString;
        }
        public static string CurrentDate() {
            return DateTime.Now.ToString("MM/dd/yyyy");
        }
        public static string CurrentDateTime(bool isFormatted = false) {

            return isFormatted ? $"{DateTime.Now.ToString("MMM dd, yyyy hh:mm:ss tt")}" : DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
        }
        public static string CurrentTime() {
            return DateTime.Now.ToString("hh:mm:ss tt");
        }
        public static System.Version GetCurrentVersion() {
            System.Version version = Assembly.GetExecutingAssembly().GetName().Version;
            return version;
        }
        public static string DateAgo(int years) {
            DateTime currentDate = DateTime.Now;
            DateTime previousDate = currentDate.AddYears(-years);

            string formattedDate = previousDate.ToString("MM/dd/yyyy");
            return formattedDate;
        }
        public static string DateLater(int years) {
            DateTime currentDate = DateTime.Now;
            DateTime previousDate = currentDate.AddYears(years);

            string formattedDate = previousDate.ToString("MM/dd/yyyy");
            return formattedDate;
        }
        public static void ExportToExcel<T>(List<T> dto, string fileName, string[] excludeName = null) {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            if (excludeName == null)
                excludeName = new string[0];
            using (var pack = new ExcelPackage()) {
                var worksheet = pack.Workbook.Worksheets.Add("Data");
                var properties = typeof(T).GetProperties();
                int col = 1;
                int row = 2;

                foreach (var property in properties) {
                    if (!excludeName.Contains(property.Name)) {
                        if (property.Name == "Item" || property.Name == "Error" || property.Name == "IsValid") {
                            continue; // Skip the loop iteration
                        }
                        //
                        worksheet.Cells[1, col].Value = property.Name;
                        col++;

                    }
                }

                foreach (var data in dto) {
                    col = 1;

                    foreach (var property in properties) {
                        if (!excludeName.Contains(property.Name)) {
                            if (property.Name == "Item" || property.Name == "Error" || property.Name == "IsValid") {
                                continue; // Skip the loop iteration
                            }
                            else {
                                if (property.PropertyType == typeof(DateTime)) {
                                    var value = property.GetValue(data, null);
                                    var convertedDate = Convert.ToDateTime(value).ToString();
                                    worksheet.Cells[row, col].Value = convertedDate;
                                }
                                else {
                                    var value = property.GetValue(data, null);
                                    worksheet.Cells[row, col].Value = value;
                                }
                                col++;
                            }
                        }
                    }
                    row++;
                }

                using (SaveFileDialog saveFileDialog = new SaveFileDialog()) {
                    saveFileDialog.Filter = "Excel Files|*.xlsx"; // Filter for Excel files
                    saveFileDialog.Title = "Save Excel File";
                    saveFileDialog.FileName = fileName; // Set the default file name

                    if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                        string selectedFilePath = saveFileDialog.FileName;
                        using (var fileStream = new FileStream(selectedFilePath, FileMode.Create)) {
                            pack.SaveAs(fileStream);
                        }
                        if (CDialogManager.Ask("Data Exported Successfully.\nDo you want to open the file?", "Confirmation")) {
                            Process.Start(selectedFilePath);
                        }
                    }


                }
            }
        }
        public static bool ImportFromExcel<T>(out List<T> listValue, string[] excludeName = null) where T : new() {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            if (excludeName == null)
                excludeName = new string[0];
            listValue = new List<T>(); // Initialize listValue

            using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
                openFileDialog.Filter = "Excel Files|*.xlsx;*.xls"; // Filter for Excel files
                openFileDialog.Title = "Select an Excel File";
                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    string selectedFilePath = openFileDialog.FileName;
                    using (var pack = new ExcelPackage(new FileInfo(selectedFilePath))) {
                        var worksheet = pack.Workbook.Worksheets[0];
                        int rowCount = worksheet.Dimension.Rows;
                        var headers = worksheet.Cells[1, 1, 1, worksheet.Dimension.Columns].Select(cell => cell.Text).ToArray();

                        for (int row = 2; row <= rowCount; row++) {
                            var item = new T();

                            foreach (var header in headers) {
                                if (!excludeName.Contains(header)) {
                                    int col = Array.IndexOf(headers, header) + 1;

                                    var cellValue = worksheet.Cells[row, col].Value;

                                    if (cellValue != null) {
                                        var property = typeof(T).GetProperty(header);
                                        if (property != null && property.CanWrite) {
                                            if (property.PropertyType == typeof(DateTime)) {
                                                var convertedValue = Convert.ToDateTime(cellValue);
                                                property.SetValue(item, convertedValue);
                                            }
                                            else {
                                                var convertedValue = Convert.ChangeType(cellValue, property.PropertyType);
                                                property.SetValue(item, convertedValue);
                                            }
                                        }
                                    }
                                }
                            }
                            listValue.Add(item);
                        }
                        return true;
                    }
                }
                return false;
            }
        }
        public static void ExportToDocs<T>(List<T> dto, string fileName, string fileOrientation, string gridStyle, string[] excludeName = null) {
            if (excludeName == null)
                excludeName = new string[0];

            // Create a new Word application
            var wordApp = new Microsoft.Office.Interop.Word.Application();

            try {
                // Create a new document
                var doc = wordApp.Documents.Add();

                //Orientation
                doc.PageSetup.Orientation = fileOrientation == "OP" ? WdOrientation.wdOrientPortrait : WdOrientation.wdOrientLandscape;

                // Create a table to display the data
                var table = doc.Tables.Add(doc.Range(), dto.Count, typeof(T).GetProperties().Length - excludeName.Length);

                // Set table style (optional)
                table.set_Style(gridStyle);

                // Add headers to the table
                var headerIndex = 1;
                foreach (var property in typeof(T).GetProperties()) {
                    if (!excludeName.Contains(property.Name)) {
                        if (property.Name == "Item" || property.Name == "Error" || property.Name == "IsValid") {
                            continue; // Skip the loop iteration
                        }
                        table.Cell(1, headerIndex).Range.Text = property.Name;
                        headerIndex++;
                    }
                }

                // Populate the table with data
                var rowIndex = 2;
                foreach (var item in dto) {
                    var colIndex = 1;
                    foreach (var property in typeof(T).GetProperties()) {
                        if (!excludeName.Contains(property.Name)) {
                            if (property.Name == "Item" || property.Name == "Error" || property.Name == "IsValid") {
                                continue; // Skip the loop iteration
                            }
                            var value = property.GetValue(item, null)?.ToString() ?? "";
                            table.Cell(rowIndex, colIndex).Range.Text = value;
                            colIndex++;
                        }
                    }
                    rowIndex++;
                }

                using (SaveFileDialog saveFileDialog = new SaveFileDialog()) {
                    saveFileDialog.Filter = "Word Documents|*.docx"; // Filter for Word files
                    saveFileDialog.Title = "Save Word Document";
                    saveFileDialog.FileName = fileName; // Set the default file name

                    if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                        string selectedFilePath = saveFileDialog.FileName;
                        string tempFilePath = Path.GetTempFileName();
                        // Save the document to a temporary file
                        doc.SaveAs2(tempFilePath);

                        // Close the document
                        doc.Close();

                        // Copy the temporary file to the selected file path
                        File.Copy(tempFilePath, selectedFilePath, true);

                        // Delete the temporary file
                        File.Delete(tempFilePath);
                        if (CDialogManager.Ask("Data Exported Successfully.\nDo you want to open the file?", "Confirmation")) {
                            Process.Start(selectedFilePath);
                        }
                    }


                }
            }
            finally {
                // Quit the Word application
                wordApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
            }
        }
        public static List<string> GetMemberName<T>() where T : new() {
            List<string> columns = new List<string>();
            List<string> excludedProperties = new List<string> { "Success", "List", "tableName", "IdTrack", "Details", "Item", "Error", "IsValid", "DataValidation" };
            var TType = typeof(T);
            PropertyInfo[] properties = TType.GetProperties();
            foreach (PropertyInfo prop in properties) {
                if (!excludedProperties.Any(c => prop.Name.Contains(c))) {
                    columns.Add(prop.Name);
                }
            }
            return columns;
        }
        public static string GetOrCreateEnvironmentPath(string fileName, params string[] folders) {

            // Ensure the filename is valid
            fileName = GetValidFileName(fileName);

            // Combine the base directory with the folder hierarchy and filename
            string path;

            // If folders have values, combine them with the base directory; otherwise, use only the filename
            if (folders != null && folders.Length > 0) {
                string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Path.Combine(folders));
                Directory.CreateDirectory(folderPath); // ✅ Ensure folder exists
                path = Path.Combine(folderPath, fileName);
            }
            else {
                string folderPath = AppDomain.CurrentDomain.BaseDirectory;
                Directory.CreateDirectory(folderPath); // ✅ Ensure base folder exists
                path = Path.Combine(folderPath, fileName);
            }

            // If file does not exist, create it
            if (!File.Exists(path)) {
                using (File.Create(path)) { } // creates and closes immediately
            }

            return path;
        }
        public static Image GetEnvironmentPathImage(string fileName, params string[] folders) {
            // Combine the base directory with the folder hierarchy and filename
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Path.Combine(folders), fileName);

            // Check if the file exists
            return Image.FromFile(path);
        }
        public static string GetValidFileName(string name) {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or empty.");

            // Replace spaces with underscore
            string validName = name.Replace(" ", "_");

            // Remove any other invalid characters for XML names
            validName = System.Text.RegularExpressions.Regex.Replace(validName, @"[^A-Za-z0-9_\-\.]", "");

            // Ensure the first character is a letter or underscore
            if (!char.IsLetter(validName[0]) && validName[0] != '_')
                validName = "_" + validName;

            return validName;
        }
        #endregion

        #region Setters
        public static void SetConnectionString(string Hostname, string Username, string Password, int Port, string Database) {
            CAppConstants.CONN_STRING_1 = $"Server={Hostname};Port={Port};Database={Database};Uid={Username};Pwd={Password};";
        }
        public static void SetConnectionString2(string Hostname, string Username, string Password, int Port, string Database) {
            CAppConstants.CONN_STRING_2 = $"Server={Hostname};Port={Port};Database={Database};Uid={Username};Pwd={Password};";
        }
        public static void SetEntityConnectionString(string Hostname, string Username, string Password, string Port, string Database, string sslMode) {
            CAppConstants.ENTITY_CONNECTION_STRING = $"server={Hostname};port={Port};database={Database};uid={Username};pwd={Password};{sslMode}";
        }
        #endregion

    }
}
