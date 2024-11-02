using FerPROJ.DBHelper.Class;
using FerPROJ.Design.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FerPROJ.Design.Class {
    public static class CLibFilesReader {

        public static void ValidateRememberMe(this CheckBox checkBox, CTextBoxKrypton usernameTextBox, out string usernameValue) {
            // Path to the XML file
            string path = CGet.GetEnvironmentPath("LibFiles.xml", "LibFiles");

            if (string.IsNullOrEmpty(path)) {
                usernameValue = string.Empty;
                return;
            }

            // Load the XML document
            var doc = XDocument.Load(path);
            var statusElement = doc.Root.Element("status");
            var usernameElement = doc.Root.Element("username");

            // Set initial usernameValue and check box state based on XML content
            if (statusElement != null && statusElement.Value.ToBool()) {
                checkBox.Checked = true;

                // Preload the username if status is true
                usernameValue = usernameElement != null ? usernameElement.Value : string.Empty;
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
                if (statusElement != null) statusElement.Value = checkBox.Checked ? "true" : "false";

                // If unchecked, clear the username in XML
                if (!checkBox.Checked && usernameElement != null) {
                    usernameElement.Value = string.Empty;
                }

                // Save changes to the XML file
                doc.Save(path);
            };

            // Event handler for TextBox TextChanged
            usernameTextBox.TextChanged += (sender, e) =>
            {
                // Update the "username" value in XML whenever the text changes
                if (usernameElement != null) {
                    usernameElement.Value = usernameTextBox.Text;

                    // Save changes to the XML file
                    doc.Save(path);
                }
            };
        }

    }
}
