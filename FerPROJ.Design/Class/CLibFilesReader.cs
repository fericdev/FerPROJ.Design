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
        public static string GetValue(string key, string path = null) {
            if (path == null) {
                path = CGet.GetEnvironmentPath("LibFiles.xml", "LibFiles");
            }
            if (!string.IsNullOrEmpty(path)) {
                // Load the XML document
                var doc = XDocument.Load(path);

                // Search for the key in the XML
                var valueElement = doc.Descendants().FirstOrDefault(e => e.Name.LocalName == key);

                // Return the value if found, or null if not found
                return valueElement?.Value;
            }
            return string.Empty;
        }

        public static void ValidateRememberMe(this CheckBox checkBox, CTextBoxKrypton usernameTextBox, out string usernameValue) {
            // Retrieve status and username from the XML using CLibFilesReader
            usernameValue = GetValue("username");
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
            checkBox.CheckedChanged += (sender, e) =>
            {
                // Update the "status" value based on CheckBox state
                CLibFilesWriter.SetValue("status", checkBox.Checked ? "true" : "false");

                // If unchecked, clear the username in XML
                if (!checkBox.Checked) {
                    CLibFilesWriter.SetValue("username", string.Empty);
                }
            };

            // Event handler for TextBox TextChanged
            usernameTextBox.TextChanged += (sender, e) =>
            {
                // Update the "username" value in XML whenever the text changes
                CLibFilesWriter.SetValue("username", usernameTextBox.Text);
            };
        }

    }
}
