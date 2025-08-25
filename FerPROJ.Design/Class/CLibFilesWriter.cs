using FerPROJ.DBHelper.Class;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FerPROJ.Design.Class {
    public static class CLibFilesWriter {
        public static void CreateOrSetValue(string key, string value, string parent = null, bool encrypt = true, string path = null) {

            // Determine the path to the XML file
            if (string.IsNullOrEmpty(path)) {
                path = CGet.GetEnvironmentPath("LibFiles.xml", "LibFiles");
            }

            // Ensure key and value are valid XML names
            key = MakeValidXmlName(key);

            // Load the XML document or create a new one if it doesn’t exist
            XDocument doc;
            if (File.Exists(path)) {
                doc = XDocument.Load(path);
            }
            else {
                doc = new XDocument(new XElement("LibFilesRoot")); // Adjust "Root" to your XML's root element name
            }

            // Find or create the parent element
            XElement parentElement;
            if (!string.IsNullOrEmpty(parent)) {
                // Attempt to find the parent element with a case-insensitive comparison
                parentElement = doc.Root.Elements()
                                        .FirstOrDefault(e => string.Equals(e.Name.LocalName, parent, StringComparison.OrdinalIgnoreCase));

                // If the parent element was not found, create it under the root
                if (parentElement == null) {
                    parentElement = new XElement(parent);
                    doc.Root.Add(parentElement);
                }
            }
            else {
                parentElement = doc.Root;
            }

            // Find or create the key element with case-insensitive comparison
            XElement keyElement = parentElement.Elements()
                                               .FirstOrDefault(e => string.Equals(e.Name.LocalName, key, StringComparison.OrdinalIgnoreCase));

            if (keyElement == null) {
                keyElement = new XElement(key);
                parentElement.Add(keyElement);
            }

            // Set the value
            keyElement.Value = encrypt ? CEncryption.Encrypt(value) : value;

            // Save changes to the XML file
            doc.Save(path);
        }
        private static string MakeValidXmlName(string name) {
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
    }
}
