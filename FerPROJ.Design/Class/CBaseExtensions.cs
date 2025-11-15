using AutoMapper;
using FerPROJ.Design.Controls;
using FerPROJ.Design.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace FerPROJ.Design.Class {
    public static class CBaseExtensions {

        #region FillComboBox
        public static void FillComboBoxEnum<TEnum>(this ComboBox cmb) where TEnum : Enum {
            if (!typeof(TEnum).IsEnum) {
                throw new ArgumentException("TEnum must be an enumeration type.");
            }
            //
            var enumValues = Enum.GetValues(typeof(TEnum)).Cast<TEnum>().ToList();
            cmb.DataSource = new BindingList<TEnum>(enumValues);
        }
        public static void FillComboBoxEnum<TEnum>(this CComboBoxKrypton cmb, List<TEnum> excluded = null) where TEnum : Enum {
            if (!typeof(TEnum).IsEnum) {
                throw new ArgumentException("TEnum must be an enumeration type.");
            }
            //
            var enumValues = Enum.GetValues(typeof(TEnum)).Cast<TEnum>().ToList();

            // Filter out excluded values, if any
            if (excluded != null) {
                enumValues = enumValues.Where(value => !excluded.Contains(value)).ToList();
            }
            cmb.DataSource = new BindingList<TEnum>(enumValues);
        }
        public static void FillComboBox(this ComboBox cmb, string cmbText, string cmbValue, IEnumerable<object> dataSource) {
            var uniqueData = dataSource
                .GroupBy(item => item.GetType().GetProperty(cmbText).GetValue(item))
                .Select(group => group.First())
                .ToList();

            cmb.DisplayMember = cmbText;
            cmb.ValueMember = cmbValue;
            cmb.DataSource = uniqueData;
        }
        public static void FillComboBox(this CComboBoxKrypton cmb, string cmbText, string cmbValue, IEnumerable<object> dataSource) {
            var uniqueData = dataSource
                .GroupBy(item => item.GetType().GetProperty(cmbText).GetValue(item))
                .Select(group => group.First())
                .ToList();

            cmb.DisplayMember = cmbText;
            cmb.ValueMember = cmbValue;
            cmb.DataSource = uniqueData;
        }
        public static void FillComboBox<T>(this CComboBoxKrypton cmb, Func<T, string> cmbText, string cmbValue, IEnumerable<T> dataSource) {
            var uniqueData = dataSource
                .GroupBy(cmbText)
                .Select(group => group.First())
                .Select(item => new {
                    Display = cmbText(item),
                    Value = item.GetType().GetProperty(cmbValue).GetValue(item),
                    Original = item
                })
                .ToList();

            cmb.DisplayMember = "Display";
            cmb.ValueMember = "Value";
            cmb.DataSource = uniqueData;
        }
        #endregion

        #region Conversion
        public static Guid ToGuid(this string value) {
            return value.To<Guid>();
        }

        public static TEnum ToEnum<TEnum>(this string value, bool ignoreCase = true) where TEnum : struct, Enum {

            if (string.IsNullOrEmpty(value)) {
                return default;
            }

            if (Enum.TryParse(value, ignoreCase, out TEnum result)) {
                return result;
            }
            throw new ArgumentException($"Cannot convert '{value}' to {typeof(TEnum).Name}");
        }
        public static bool ToBool(this string value) {
            if (!string.IsNullOrEmpty(value)) {
                return Convert.ToBoolean(value);
            }
            return false;
        }

        //
        public static byte[] ToByte(this HttpPostedFileBase file) {
            if (file != null && file.ContentLength > 0) {
                using (var binaryReader = new BinaryReader(file.InputStream)) {
                    return binaryReader.ReadBytes(file.ContentLength);
                }
            }
            return null;
        }
        public static string ToImageString(this byte[] file) {
            return Convert.ToBase64String(file);
        }
        public static Image ToImage(this byte[] file) {
            if (file == null || file.Length == 0) {
                return null; // Handle null or empty byte array
            }
            //
            using (MemoryStream ms = new MemoryStream(file)) {
                return Image.FromStream(ms);
            }
        }
        public static DateTime ToDateTime(this string stringValue) {
            return Convert.ToDateTime(stringValue);
        }
        public static string ToTime12(this string stringValue) {
            if (DateTime.TryParse(stringValue, out DateTime dateTime)) {
                return dateTime.ToString("hh:mm tt");
            }
            return null;
        }
        public static string ToTime24(this string stringValue) {
            if (DateTime.TryParse(stringValue, out DateTime dateTime)) {
                return dateTime.ToString("HH:mm");
            }
            return null;
        }
        public static decimal ToDecimal(this int intValue) {
            return Convert.ToDecimal(intValue);
        }
        public static decimal ToDecimal(this string stringValue) {
            return Convert.ToDecimal(stringValue);
        }
        public static int ToInt(this long longValue) {
            return (int)Convert.ToInt64(longValue);
        }
        public static int ToInt(this string stringValue) {
            if (!string.IsNullOrEmpty(stringValue)) {
                return int.Parse(stringValue);
            }
            return 0;
        }
        public static int ToInt(this decimal decimalValue) {
            return Convert.ToInt32(decimalValue);
        }
        public static float ToFloat(this string stringValue) {
            return float.Parse(stringValue);
        }
        public static TEnum GetEnum<TEnum>(this string text) where TEnum : Enum {
            return (TEnum)Enum.Parse(typeof(TEnum), text);
        }
        public static string ToDateAndTime(this DateTime dateTime) {
            return dateTime.ToString("MMMM dd, yyyy hh:mm tt", CultureInfo.InvariantCulture);
        }
        public static string ToDateAndTime(this DateTime? dateTime) {
            if (!dateTime.HasValue) {
                return string.Empty;
            }
            return dateTime.Value.ToString("MMMM dd, yyyy hh:mm tt", CultureInfo.InvariantCulture);
        }

        public static List<T> ToListOf<T>(this List<object> values) where T : struct {
            List<T> result = new List<T>();

            foreach (var value in values) {
                if (value is T) {
                    result.Add((T)value);
                    continue;
                }

                Type targetType = typeof(T);

                // Check if the target type has a public static Parse method
                MethodInfo parseMethod = targetType.GetMethod("Parse", new[] { typeof(string) });
                if (parseMethod != null && parseMethod.IsStatic && parseMethod.ReturnType == targetType) {
                    result.Add((T)parseMethod.Invoke(null, new[] { value.ToString() }));
                    continue;
                }

                // Additional conversion logic
                if (targetType == typeof(int)) {
                    result.Add((T)(object)int.Parse(value.ToString(), CultureInfo.InvariantCulture));
                    continue;
                }

                if (targetType == typeof(long)) {
                    result.Add((T)(object)long.Parse(value.ToString(), CultureInfo.InvariantCulture));
                    continue;
                }

                if (targetType == typeof(float)) {
                    result.Add((T)(object)float.Parse(value.ToString(), CultureInfo.InvariantCulture));
                    continue;
                }

                if (targetType == typeof(double)) {
                    result.Add((T)(object)double.Parse(value.ToString(), CultureInfo.InvariantCulture));
                    continue;
                }

                if (targetType == typeof(char)) {
                    if (value.ToString().Length == 1) {
                        result.Add((T)(object)value.ToString()[0]);
                        continue;
                    }
                }

                if (targetType == typeof(Guid)) {
                    result.Add((T)(object)Guid.Parse(value.ToString()));
                    continue;
                }

                if (targetType == typeof(bool)) {
                    result.Add((T)(object)bool.Parse(value.ToString()));
                    continue;
                }

                if (targetType == typeof(string)) {
                    result.Add((T)(object)value.ToString());
                    continue;
                }

                throw new InvalidCastException($"Cannot convert {value.GetType().Name} to {typeof(T).Name}");
            }

            return result;
        }
        public static T To<T>(this object value) where T : struct {
            
            if (value == null) {
                return (T)default;
            }

            if (value is T) {
                return (T)value;
            }

            Type targetType = typeof(T);

            // Check if the target type has a public static Parse method
            MethodInfo parseMethod = targetType.GetMethod("Parse", new[] { typeof(string) });
            if (parseMethod != null && parseMethod.IsStatic && parseMethod.ReturnType == targetType) {
                return (T)parseMethod.Invoke(null, new[] { value.ToString() });
            }

            // Additional conversion logic
            if (targetType == typeof(int)) {
                return (T)(object)int.Parse(value.ToString(), CultureInfo.InvariantCulture);
            }

            if (targetType == typeof(long)) {
                return (T)(object)long.Parse(value.ToString(), CultureInfo.InvariantCulture);
            }

            if (targetType == typeof(float)) {
                return (T)(object)float.Parse(value.ToString(), CultureInfo.InvariantCulture);
            }

            if (targetType == typeof(double)) {
                return (T)(object)double.Parse(value.ToString(), CultureInfo.InvariantCulture);
            }

            if (targetType == typeof(char)) {
                if (value.ToString().Length == 1) {
                    return (T)(object)value.ToString()[0];
                }
            }

            if (targetType == typeof(Guid)) {
                return (T)(object)Guid.Parse(value.ToString());
            }

            if (targetType == typeof(bool)) {
                return (T)(object)bool.Parse(value.ToString());
            }

            if (targetType == typeof(string)) {
                return (T)(object)value.ToString();
            }

            throw new InvalidCastException($"Cannot convert {value.GetType().Name} to {typeof(T).Name}");
        }

        #endregion

        #region Null Check
        public static bool IsNullOrEmpty(this Guid? value) {
            try {
                return value == null || value.Value == Guid.Empty;
            }
            catch {
                return false;
            }
        }
        public static bool IsNullOrEmpty(this Guid value) {
            try {
                return value == null || value == Guid.Empty;
            }
            catch {
                return false;
            }
        }
        public static bool IsNullOrEmpty(this string value) {
            try {
                return string.IsNullOrEmpty(value);
            }
            catch {
                return false;
            }
        }
        #endregion

        #region Datatable Conversion

        public static DataTable ToDataTable<T>(this List<T> items) {
            DataTable dataTable = new DataTable(typeof(T).Name);

            // Get all the properties of the class T
            PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            // Create columns in the DataTable based on the properties
            foreach (PropertyInfo prop in properties) {
                dataTable.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            // Add rows to the DataTable
            foreach (T item in items) {
                var values = new object[properties.Length];
                for (int i = 0; i < properties.Length; i++) {
                    values[i] = properties[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }
        public static async Task<DataTable> ToDataTableListAsync<T>(this List<T> items) {
            var invalidTypes = new[] { typeof(List<>), typeof(ICollection<>), typeof(IEnumerable<>) };
            // Create a new DataTable with the name of the type T
            var dataTable = new DataTable(typeof(T).Name);

            // Cache property info to avoid repeated reflection calls
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                      .Where(prop => prop.CanRead) // Only consider readable properties
                                      .Where(prop => typeof(T).IsSubclassOf(typeof(PropertyValidator))
                                             ? prop.DeclaringType.IsSubclassOf(typeof(PropertyValidator))
                                             : true)
                                      .ToArray();

            properties = properties.Where(c => !IsInvalidType(c.PropertyType, invalidTypes)).ToArray();

            // Create columns in the DataTable based on the properties
            foreach (var prop in properties) {
                var columnType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                dataTable.Columns.Add(prop.Name, columnType);
            }

            // Add rows to the DataTable asynchronously
            await Task.Run(() => {
                foreach (var item in items) {
                    var values = properties.Select(prop => prop.GetValue(item, null)).ToArray();
                    dataTable.Rows.Add(values);
                }
            });

            return dataTable;
        }
        public static async Task<DataTable> ToDataTableAsync<T>(this IEnumerable<T> items) {
            var invalidTypes = new[] { typeof(List<>), typeof(ICollection<>), typeof(IEnumerable<>) };
            // Create a new DataTable with the name of the type T
            var dataTable = new DataTable(typeof(T).Name);

            // Cache property info to avoid repeated reflection calls
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                      .Where(prop => prop.CanRead) // Only consider readable properties
                                      .Where(prop => typeof(T).IsSubclassOf(typeof(PropertyValidator))
                                             ? prop.DeclaringType.IsSubclassOf(typeof(PropertyValidator))
                                             : true)
                                      .ToArray();

            properties = properties.Where(c => !IsInvalidType(c.PropertyType, invalidTypes)).ToArray();

            // Create columns in the DataTable based on the properties
            foreach (var prop in properties) {
                var columnType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                dataTable.Columns.Add(prop.Name, columnType);
            }

            // Add rows to the DataTable asynchronously
            await Task.Run(() => {
                foreach (var item in items) {
                    var values = properties.Select(prop => prop.GetValue(item, null)).ToArray();
                    dataTable.Rows.Add(values);
                }
            });

            return dataTable;
        }
        public static async Task<DataTable> ToDataTableAsync<T>(this T item) {

            var invalidTypes = new[] { typeof(List<>), typeof(ICollection<>), typeof(IEnumerable<>) };
            // Create a new DataTable with the name of the type T
            var dataTable = new DataTable(typeof(T).Name);

            // Cache property info to avoid repeated reflection calls
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                      .Where(prop => prop.CanRead) // Only consider readable properties
                                      .Where(prop => typeof(T).IsSubclassOf(typeof(PropertyValidator))
                                             ? prop.DeclaringType.IsSubclassOf(typeof(PropertyValidator))
                                             : true)
                                      .ToArray();

            properties = properties.Where(c => !IsInvalidType(c.PropertyType, invalidTypes)).ToArray();

            // Create columns in the DataTable based on the properties
            foreach (var prop in properties) {
                var columnType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                dataTable.Columns.Add(prop.Name, columnType);
            }

            // Add a row to the DataTable asynchronously
            await Task.Run(() => {
                var values = properties.Select(prop => prop.GetValue(item, null)).ToArray();
                dataTable.Rows.Add(values);
            });

            return dataTable;
        }

        private static bool IsInvalidType(Type type, Type[] invalidTypes) {
            return type.IsGenericType && invalidTypes.Any(invalidType =>
                type.GetGenericTypeDefinition() == invalidType);
        }

        #endregion

        #region Searh
        //string extensions
        public static bool SearchContains(this string source, string searchText) {

            if (source == null || searchText == null)
                return false;

            source = source.ToLower();
            searchText = searchText.ToLower();

            return source.Contains(searchText);
        }
        public static bool SearchFor(this string source, string searchText) {
            if (source == null || searchText == null)
                return false;

            return source.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0;
        }
        public static bool SearchFor(this string[] source, string searchText) {
            // Check for null or empty source array and null search text
            if (source == null || source.Length == 0 || string.IsNullOrWhiteSpace(searchText))
                return false;

            // Use LINQ to check for a match
            return source.Any(s => s.Trim().Equals(searchText.Trim(), StringComparison.OrdinalIgnoreCase));
        }
        public static bool SearchFor(this object source, string searchText, DateTime? dateFrom, DateTime? dateTo, string datePropertyName) {
            return source.SearchForText(searchText) && source.SearchForDate(dateFrom, dateTo, datePropertyName);
        }

        public static bool SearchForDate(this object source, DateTime? dateFrom, DateTime? dateTo, string propertyName = "") {
            if (source == null)
                return false;

            if (!dateFrom.HasValue && !dateTo.HasValue) {
                return true;
            }

            var properties = source.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy)
                          .Where(p => p.PropertyType == typeof(DateTime) || p.PropertyType == typeof(DateTime?))
                          .ToList();

            properties = properties.Where(p => string.IsNullOrEmpty(propertyName) || p.Name.Equals(propertyName, StringComparison.OrdinalIgnoreCase)).ToList();

            foreach (var property in properties) {
                // Skip properties with index parameters
                if (property.GetIndexParameters().Length > 0)
                    continue;

                // Get the property value
                var value = (DateTime?)property.GetValue(source);

                // If the value is null, skip this property
                if (!value.HasValue)
                    continue;

                bool isAfterStart = !dateFrom.HasValue || value > dateFrom.Value.AddDays(-1);
                bool isBeforeEnd = !dateTo.HasValue || value < dateTo.Value.AddDays(1);

                if (isAfterStart && isBeforeEnd) {
                    return true; // Property is within range
                }

            }

            return false; // No match found

        }

        public static bool SearchForText(this object source, string searchText) {
            if (source == null)
                return false;

            if (string.IsNullOrEmpty(searchText)) {
                return true;
            }

            // Get all public instance properties of the object
            var properties = source.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties) {
                // Skip properties with index parameters
                if (property.GetIndexParameters().Length > 0)
                    continue;

                // Get the property value
                var value = property.GetValue(source);

                // If the value is null, skip this property
                if (value == null)
                    continue;

                // Convert the value to a string and compare it to the searchText
                if (value.ToString().SearchContains(searchText)) {
                    return true; // Match found in the text
                }
            }

            return false; // No match found
        }
        #endregion

        #region Get
        public static int GetAge(this DateTime birthDate) {
            var currentDate = DateTime.Today;
            int age = currentDate.Year - birthDate.Year;
            if (birthDate > currentDate.AddYears(-age)) {
                age--;
            }
            return age;
        }
        public static string GetFirstLetter(this string text, bool isLower = false) {
            if (string.IsNullOrEmpty(text)) {
                return string.Empty;
            }
            return isLower ? text[0].ToString().ToLower() : text[0].ToString();
        }
        public static string GetFirstLetters(this string text, int length) {
            if (string.IsNullOrEmpty(text)) {
                return string.Empty;
            }
            return text.Substring(0, length);
        }
        public static string GetLastLetter(this string text) {
            if (string.IsNullOrEmpty(text)) {
                return string.Empty;
            }
            return text[text.Length - 1].ToString();
        }
        #endregion

        #region Search Date
        public static bool DateFrom(this DateTime? date, DateTime? dateFrom) {
            return date?.Date >= dateFrom?.Date;
        }
        public static bool DateTo(this DateTime? date, DateTime? dateTo) {
            return date?.Date <= dateTo?.Date;
        }
        public static bool DateFrom(this DateTime date, DateTime? dateFrom) {
            return date.Date >= dateFrom?.Date;
        }
        public static bool DateTo(this DateTime date, DateTime? dateTo) {
            return date.Date <= dateTo?.Date;
        }
        #endregion

        #region Label
        public static void SetLabelColorInfo(this Label label) {
            if (label == null) {
                return;
            }
            label.ForeColor = Color.Blue;
        }
        public static void SetLabelColorDanger(this Label label) {
            if (label == null) {
                return;
            }
            label.ForeColor = Color.Red;
        }
        public static void SetLabelColorWarning(this Label label) {
            if (label == null) {
                return;
            }
            label.ForeColor = Color.Orange;
        }
        public static void SetLabelColorSuccess(this Label label) {
            if (label == null) {
                return;
            }
            label.ForeColor = Color.Green;
        }
        #endregion

        #region Binding Class 
        public static async Task LoadDataAsync<T>(
            this BindingSource bindingSource,
            Task<IEnumerable<T>> dataFetchTask) {
            await FrmSplasherLoading.ShowSplashAsync();

            // Fetch all data asynchronously
            var allData = (await dataFetchTask).ToList();

            // Clear
            bindingSource.Clear();

            Func<BackgroundWorker, DoWorkEventArgs, Task> doWorkAsync = async (worker, e) => {
                int batchSize = 100;
                int total = allData.Count;
                int currentIndex = 0;

                // Check if total data is less than batch size
                if (total <= batchSize) {
                    // Load all data at once if less than batch size
                    worker.ReportProgress(100, allData);
                    FrmSplasherLoading.SetLoadingText(100);
                }
                else {
                    // Load data in batches
                    while (currentIndex < total) {
                        var batch = allData.Skip(currentIndex).Take(batchSize).ToList();
                        currentIndex += batchSize;

                        int progress = (int)((double)currentIndex / total * 100);
                        // Report progress to the UI thread to append the batch
                        worker.ReportProgress(progress, batch);
                        FrmSplasherLoading.SetLoadingText(progress);

                        // Optional delay to smoothen UI load (tweak as needed)
                        await Task.Delay(10);
                    }
                }
            };

            Func<ProgressChangedEventArgs, Task> progressChangedAsync = async (e) => {
                var batch = (List<T>)e.UserState;

                // Suspend updates for smoother performance
                bindingSource.SuspendBinding();

                if (bindingSource.DataSource is List<T> currentData) {
                    currentData.AddRange(batch);  // Add new batch
                }
                else {
                    // First batch initialization
                    bindingSource.DataSource = new List<T>(batch);
                }

                bindingSource.ResumeBinding();

                // Offload UI updates
                if (e.ProgressPercentage == 100) {
                    bindingSource.ResetBindings(false);
                }

                Console.WriteLine($"{batch.Count} items added to DataSource.");
                await Task.CompletedTask;

            };

            Func<RunWorkerCompletedEventArgs, Task> workerCompletedAsync = async (e) => {
                FrmSplasherLoading.SetLoadingText(100);
                FrmSplasherLoading.CloseSplash();
                Console.WriteLine("All data loaded without freezing the UI.");
                await Task.CompletedTask;
            };

            await CBackgroundTaskManager.RunWithProgressAsync(doWorkAsync, progressChangedAsync, workerCompletedAsync);

        }

        #region Control 
        private static Control FindControlByBindingSource(BindingSource bindingSource) {
            foreach (Form form in Application.OpenForms) {
                var control = FindControlRecursive(form, bindingSource);
                if (control != null) {
                    return control;
                }
            }
            return null;
        }

        private static Control FindControlRecursive(Control parent, BindingSource bindingSource) {
            foreach (Control control in parent.Controls) {
                // Check if this control is bound to the BindingSource
                if ((control is DataGridView dgv && dgv.DataSource == bindingSource) ||
                    (control is CDatagridview cdgv && cdgv.DataSource == bindingSource)) {
                    return control;
                }

                // Recursively search in child controls
                var result = FindControlRecursive(control, bindingSource);
                if (result != null) {
                    return result;
                }
            }
            return null;
        }
        private static DataGridView GetBoundDataGridView(Control control, BindingSource bindingSource) {
            // Check if the current control is the target DataGridView and its DataSource matches
            if ((control is CDatagridview cdgv && cdgv.DataSource == bindingSource) ||
                (control is DataGridView dgv && dgv.DataSource == bindingSource)) {
                return control as DataGridView;
            }

            return null; // No bound DataGridView found
        }
        #endregion

        #endregion

    }
}
