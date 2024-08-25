using AutoMapper;
using FerPROJ.Design.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace FerPROJ.Design.Class
{
    public static class CExtension
    {
        public static void FillComboBoxEnum<TEnum>(this ComboBox cmb) where TEnum : Enum {
            if (!typeof(TEnum).IsEnum) {
                throw new ArgumentException("TEnum must be an enumeration type.");
            }
            //
            var enumValues = Enum.GetValues(typeof(TEnum)).Cast<TEnum>().ToList();
            cmb.DataSource = new BindingList<TEnum>(enumValues);
        }
        public static void FillComboBoxEnum<TEnum>(this CComboBoxKrypton cmb) where TEnum : Enum {
            if (!typeof(TEnum).IsEnum) {
                throw new ArgumentException("TEnum must be an enumeration type.");
            }
            //
            var enumValues = Enum.GetValues(typeof(TEnum)).Cast<TEnum>().ToList();
            cmb.DataSource = new BindingList<TEnum>(enumValues);
        }
        public static void FillComboBox(this ComboBox cmb, string cmbText, string cmbValue, IEnumerable<object> dataSource) {
            cmb.DisplayMember = cmbText;
            cmb.ValueMember = cmbValue;
            cmb.DataSource = dataSource.ToList();
        }
        public static void FillComboBox(this CComboBoxKrypton cmb, string cmbText, string cmbValue, IEnumerable<object> dataSource) {
            cmb.DisplayMember = cmbText;
            cmb.ValueMember = cmbValue;
            cmb.DataSource = dataSource.ToList();
        }
        public static byte[] ToByte(this HttpPostedFileBase file) {
            if (file != null && file.ContentLength > 0) {
                using (var binaryReader = new BinaryReader(file.InputStream)) {
                    return binaryReader.ReadBytes(file.ContentLength);
                }
            }
            return null;
        }
        public static string ToImage(this byte[] file) {
            return Convert.ToBase64String(file);
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
            }return 0;
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
        public static DataTable ToDataTable<T>(this IEnumerable<T> items) {
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
    }
}
