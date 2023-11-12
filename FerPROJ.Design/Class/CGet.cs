using FerPROJ.Design.Class;
using Microsoft.Office.Interop.Word;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FerPROJ.DBHelper.Class
{
    public static class CGet
    {
        public static string RandomString(int length)
        {
            Random random = new Random();

            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] boldLetters = new char[length];

            for (int i = 0; i < length; i++)
            {
                char randomLetter = letters[random.Next(letters.Length)];
                boldLetters[i] = randomLetter;
            }

            string boldString = new string(boldLetters);
            return boldString;
        }
        public static string CurrentDate()
        {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }
        public static string CurrentDateTime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        }
        public static string CurrentTime()
        {
            return DateTime.Now.ToString("hh:mm:ss tt");
        }
        public static System.Version GetCurrentVersion()
        {
            System.Version version = Assembly.GetExecutingAssembly().GetName().Version;
            return version;
        }
        public static string DateAgo(int years)
        {
            DateTime currentDate = DateTime.Now;
            DateTime previousDate = currentDate.AddYears(-years);

            string formattedDate = previousDate.ToString("MM-dd-yyyy");
            return formattedDate;
        }
        public static string DateLater(int years)
        {
            DateTime currentDate = DateTime.Now;
            DateTime previousDate = currentDate.AddYears(years);

            string formattedDate = previousDate.ToString("MM-dd-yyyy");
            return formattedDate;
        }
        public static void ExportToExcel<T>(List<T> dto, string fileName, string[] excludeName = null)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            if (excludeName == null) excludeName = new string[0];
            using (var pack = new ExcelPackage())
            {
                var worksheet = pack.Workbook.Worksheets.Add("Data");
                var properties = typeof(T).GetProperties();
                int col = 1;
                int row = 2;

                foreach (var property in properties)
                {
                    if (!excludeName.Contains(property.Name))
                    {
                        if (property.Name == "Item" || property.Name == "Error" || property.Name == "IsValid")
                        {
                            continue; // Skip the loop iteration
                        }
                        //
                        worksheet.Cells[1, col].Value = property.Name;
                        col++;

                    }
                }

                foreach (var data in dto)
                {
                    col = 1;

                    foreach (var property in properties)
                    {
                        if (!excludeName.Contains(property.Name))
                        {
                            if (property.Name == "Item" || property.Name == "Error" || property.Name == "IsValid")
                            {
                                continue; // Skip the loop iteration
                            }
                            else
                            {
                                if (property.PropertyType == typeof(DateTime))
                                {
                                    var value = property.GetValue(data, null);
                                    var convertedDate = Convert.ToDateTime(value).ToString();
                                    worksheet.Cells[row, col].Value = convertedDate;
                                }
                                else
                                {
                                    var value = property.GetValue(data, null);
                                    worksheet.Cells[row, col].Value = value;
                                }
                                col++;
                            }
                        }
                    }
                    row++;
                }

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel Files|*.xlsx"; // Filter for Excel files
                    saveFileDialog.Title = "Save Excel File";
                    saveFileDialog.FileName = fileName; // Set the default file name

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string selectedFilePath = saveFileDialog.FileName;
                        using (var fileStream = new FileStream(selectedFilePath, FileMode.Create))
                        {
                            pack.SaveAs(fileStream);
                        }
                        if (CShowMessage.Ask("Data Exported Successfully.\nDo you want to open the file?", "Confirmation"))
                        {
                            Process.Start(selectedFilePath);
                        }
                    }


                }
            }
        }
        public static bool ImportFromExcel<T>(out List<T> listValue, string[] excludeName = null) where T : new()
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            if (excludeName == null) excludeName = new string[0]; 
            listValue = new List<T>(); // Initialize listValue

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xlsx;*.xls"; // Filter for Excel files
                openFileDialog.Title = "Select an Excel File";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;
                    using (var pack = new ExcelPackage(new FileInfo(selectedFilePath)))
                    {
                        var worksheet = pack.Workbook.Worksheets[0];
                        int rowCount = worksheet.Dimension.Rows;
                        var headers = worksheet.Cells[1, 1, 1, worksheet.Dimension.Columns].Select(cell => cell.Text).ToArray();

                        for (int row = 2; row <= rowCount; row++)
                        {
                            var item = new T();

                            foreach (var header in headers)
                            {
                                if (!excludeName.Contains(header))
                                {
                                    int col = Array.IndexOf(headers, header) + 1;

                                    var cellValue = worksheet.Cells[row, col].Value;

                                    if (cellValue != null)
                                    {
                                        var property = typeof(T).GetProperty(header);
                                        if (property != null && property.CanWrite)
                                        {
                                            if (property.PropertyType == typeof(DateTime))
                                            {
                                                var convertedValue = Convert.ToDateTime(cellValue);
                                                property.SetValue(item, convertedValue);
                                            }
                                            else
                                            {
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
        public static void ExportToDocs<T>(List<T> dto, string fileName, string fileOrientation, string gridStyle, string[] excludeName = null)
        {
            if (excludeName == null)excludeName = new string[0];

            // Create a new Word application
            var wordApp = new Microsoft.Office.Interop.Word.Application();

            try
            {
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
                foreach (var property in typeof(T).GetProperties())
                {
                    if (!excludeName.Contains(property.Name))
                    {
                        if (property.Name == "Item" || property.Name == "Error" || property.Name == "IsValid")
                        {
                            continue; // Skip the loop iteration
                        }
                        table.Cell(1, headerIndex).Range.Text = property.Name;
                        headerIndex++;
                    }
                }

                // Populate the table with data
                var rowIndex = 2;
                foreach (var item in dto)
                {
                    var colIndex = 1;
                    foreach (var property in typeof(T).GetProperties())
                    {
                        if (!excludeName.Contains(property.Name))
                        {
                            if (property.Name == "Item" || property.Name == "Error" || property.Name == "IsValid")
                            {
                                continue; // Skip the loop iteration
                            }
                            var value = property.GetValue(item, null)?.ToString() ?? "";
                            table.Cell(rowIndex, colIndex).Range.Text = value;
                            colIndex++;
                        }
                    }
                    rowIndex++;
                }

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Word Documents|*.docx"; // Filter for Word files
                    saveFileDialog.Title = "Save Word Document";
                    saveFileDialog.FileName = fileName; // Set the default file name

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
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
                        if (CShowMessage.Ask("Data Exported Successfully.\nDo you want to open the file?", "Confirmation"))
                        {
                            Process.Start(selectedFilePath);
                        }
                    }


                }
            }
            finally
            {
                // Quit the Word application
                wordApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
            }
        }
    }
}
