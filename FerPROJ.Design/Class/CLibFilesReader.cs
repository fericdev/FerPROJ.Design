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
    public static class CLibFilesReader {
        public static string GetValue(string key, string parent = null, bool encrypt = true, string path = null) {
            //
            if (path == null) {
                path = CGet.GetEnvironmentPath("LibFiles.xml", "LibFiles");
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
                CLibFilesWriter.CreateOrSetValue("status", checkBox.Checked ? "true" : "false", parent: "rememberme");

                // If unchecked, clear the username in XML
                if (!checkBox.Checked) {
                    CLibFilesWriter.CreateOrSetValue("username", string.Empty, parent: "rememberme");
                }
            };

            // Event handler for TextBox TextChanged
            usernameTextBox.TextChanged += (sender, e) => {
                // Update the "username" value in XML whenever the text changes
                CLibFilesWriter.CreateOrSetValue("username", usernameTextBox.Text, parent: "rememberme");
            };

            //
            return usernameValue;
        }

    }
}
