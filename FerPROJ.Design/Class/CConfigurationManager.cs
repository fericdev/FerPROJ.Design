using FerPROJ.DBHelper.Class;
using FerPROJ.Design.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FerPROJ.Design.Class {
    public static class CConfigurationManager {

        #region Writer
        public static void CreateOrSetValue(string key, string value, string parent = null, bool encrypt = true, string path = null) {

            // Determine the path to the XML file
            if (string.IsNullOrEmpty(path)) {
                path = CGet.GetEnvironmentPath("AppSettings.xml", "Config");
            }

            // Ensure key and value are valid XML names
            key = GetValidName(key);

            // Load the XML document or create a new one if it doesn’t exist
            XDocument doc;
            if (File.Exists(path)) {
                doc = XDocument.Load(path);
            }
            else {
                doc = new XDocument(new XElement("Configuration")); // Adjust "Root" to your XML's root element name
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
        #endregion

        #region Reader
        public static string GetValue(string key, string parent = null, bool encrypt = true, string path = null) {
            //
            if (path == null) {
                path = CGet.GetEnvironmentPath("AppSettings.xml", "Config");
            }

            // Load the XML document
            var doc = XDocument.Load(path);

            XElement parentElement;

            if (!string.IsNullOrEmpty(parent)) {
                // Search for the parent element with case-insensitive comparison
                parentElement = doc.Root.Descendants()
                                        .FirstOrDefault(e => string.Equals(e.Name.LocalName, parent, StringComparison.OrdinalIgnoreCase));

                if (parentElement == null) {
                    // If specified parent is not found, return an empty string or handle as needed
                    return string.Empty;
                }
            }
            else {
                // If no parent specified, search within the entire document
                parentElement = doc.Root;
            }

            // Search for the key element within the specified parent or root
            var valueElement = parentElement.Descendants()
                                            .FirstOrDefault(e => string.Equals(e.Name.LocalName, key, StringComparison.OrdinalIgnoreCase));

            // Return the value if found, applying decryption if needed
            if (encrypt) {
                return valueElement != null ? CEncryption.Decrypt(valueElement.Value) : string.Empty;
            }
            else {
                return valueElement?.Value;
            }
        }
        #endregion

        #region Utilities
        public static string GetRememberedPassword() {
            return GetValue("status").ToBool() ? GetValue("password") : string.Empty;
        }
        public static string GetRememberedUsername(CheckBox checkBox, CTextBoxKrypton usernameTextBox) {
            // Retrieve status and username from the XML using CLibFilesReader
            var usernameValue = GetValue("username", "rememberme");
            var statusValue = GetValue("status");

            // Set initial checkbox state and username text based on XML content
            if (statusValue == "true") {
                checkBox.Checked = true;
                usernameTextBox.Text = usernameValue;
            }
            else {
                checkBox.Checked = false;
                usernameValue = string.Empty;
            }

            // Event handler for CheckBox CheckedChanged
            checkBox.CheckedChanged += (sender, e) => {
                // Update the "status" value based on CheckBox state
                CreateOrSetValue("status", checkBox.Checked ? "true" : "false", parent: "rememberme");

                // If unchecked, clear the username in XML
                if (!checkBox.Checked) {
                    CreateOrSetValue("username", string.Empty, parent: "rememberme");
                }
            };

            // Event handler for TextBox TextChanged
            usernameTextBox.TextChanged += (sender, e) => {
                // Update the "username" value in XML whenever the text changes
                CreateOrSetValue("username", usernameTextBox.Text, parent: "rememberme");
            };

            //
            return usernameValue;
        }
        #endregion

        #region Private Methods
        private static string GetValidName(string name) {
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

    }
}
