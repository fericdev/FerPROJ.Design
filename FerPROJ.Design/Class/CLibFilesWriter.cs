using FerPROJ.DBHelper.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FerPROJ.Design.Class {
    public static class CLibFilesWriter {
        public static void SetValue(string key, string value, string path = null, string parent = null) {
            // Define the path to your XML file
            if (path == null) {
                path = CGet.GetEnvironmentPath("LibFiles.xml", "LibFiles");
            }

            if (string.IsNullOrEmpty(path)) {
                return;
            }

            // Load the XML document
            var doc = XDocument.Load(path);

            // Find the element with the specified key
            var element = doc.Descendants().FirstOrDefault(e => e.Name.LocalName == key);

            if (element != null) {
                // If the element exists, update its value
                element.Value = value;
            }
            else {
                // Determine the parent element to insert under
                XElement parentElement;

                if (string.IsNullOrEmpty(parent)) {
                    // If parent is null, use the root or specific element (like RememberMe)
                    parentElement = doc.Root.Element("RememberMe");
                }
                else {
                    // If a parent is specified, find it in the document
                    parentElement = doc.Descendants().FirstOrDefault(e => e.Name.LocalName == parent);
                }

                if (parentElement != null) {
                    // Add a new element under the determined parent
                    parentElement.Add(new XElement(key, value));
                }
            }
            // Save changes to the XML file
            doc.Save(path);
        }
    }
}
