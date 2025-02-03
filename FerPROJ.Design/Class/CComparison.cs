using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FerPROJ.Design.Class {
    public class CComparison {
        // Compare two objects by their properties
        public static bool AreObjectsEqual<T>(T obj1, T obj2) {
            // Ensure both objects are not null
            // If both are the same object (reference equality)
            if (ReferenceEquals(obj1, obj2))
                return true;

            // If one is null and the other is not, they are not equal
            if (obj1 == null || obj2 == null)
                return false;

            // Get all public properties of the type
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            // Compare all properties
            foreach (var property in properties) {
                // Skip comparison if the property is not readable
                if (!property.CanRead)
                    continue;
                try {
                    var value1 = property.GetValue(obj1);
                    var value2 = property.GetValue(obj2);

                    // If the values are not equal, return false
                    if (!Equals(value1, value2)) {
                        return false;
                    }
                }
                catch (Exception) {
                    continue;
                }
            }

            // If no mismatches found, return true
            return true;
        }

        // Compare two lists based on their object properties
        public static List<T> CompareLists<T>(List<T> list1, List<T> list2) {
            // Initialize a list to store new or modified items
            var result = new List<T>();

            // Compare each item in list1 with list2
            foreach (var item1 in list1) {
                // Check if the item is in list2 and matches all properties
                bool matchFound = list2.Any(item2 => AreObjectsEqual(item1, item2));

                if (!matchFound) {
                    // Add to result if no match found
                    result.Add(item1);
                }
            }

            return result;
        }
    }
}
