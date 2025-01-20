using AutoMapper;
using FerPROJ.Design.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace FerPROJ.Design.Class {
    public static class CExtension {

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

        public static TEnum ToEnum<TEnum>(this string value, bool ignoreCase = true) where TEnum : struct, Enum {
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
        public static async Task<DataTable> ToDataTableList<T>(this List<T> items) {
            // Create a new DataTable with the name of the type T
            var dataTable = new DataTable(typeof(T).Name);

            // Cache property info to avoid repeated reflection calls
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                      .Where(prop => prop.CanRead)  // Only consider readable properties
                                      .ToArray();

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
        public static async Task<DataTable> ToDataTable<T>(this IEnumerable<T> items) {
            // Create a new DataTable with the name of the type T
            var dataTable = new DataTable(typeof(T).Name);

            // Cache property info to avoid repeated reflection calls
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                      .Where(prop => prop.CanRead)  // Only consider readable properties
                                      .ToArray();

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
        public static async Task<DataTable> ToDataTable<T>(this T item) {
            // Create a new DataTable with the name of the type T
            var dataTable = new DataTable(typeof(T).Name);

            // Cache property info to avoid repeated reflection calls
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                      .Where(prop => prop.CanRead)  // Only consider readable properties
                                      .ToArray();

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
            label.ForeColor = Color.Blue;
        }
        public static void SetLabelColorDanger(this Label label) {
            label.ForeColor = Color.Red;
        }
        public static void SetLabelColorWarning(this Label label) {
            label.ForeColor = Color.Orange;
        }
        public static void SetLabelColorSuccess(this Label label) {
            label.ForeColor = Color.Green;
        }
        #endregion

        #region Task
        public static T AwaitValue<T>(this Task<T> task) {
            return task.GetAwaiter().GetResult(); // Synchronously waits and retrieves the result.
        }
        public static void AwaitValue(this Task task) {
            task.GetAwaiter().GetResult(); // Synchronously waits for the task to complete.
        }
        #endregion

    }
}
