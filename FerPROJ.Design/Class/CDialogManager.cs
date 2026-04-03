using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FerPROJ.Design.Class {
    public static class CDialogManager {
        public static bool Ask(string message, string caption) {
            if (MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                return true;
            }
            return false;
        }
        public static bool Ask(string message) {
            var callerType = new StackTrace().GetFrame(1).GetMethod().DeclaringType;
            return Ask(message, GetCallerTypeName(callerType));
        }
        public static void Warning(string message, string caption) {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static void Warning(string message) {
            var callerType = new StackTrace().GetFrame(1).GetMethod().DeclaringType;
            Warning(message, GetCallerTypeName(callerType));
        }
        public static void Info(string message, string caption) {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void Info(string message) {
            var callerType = new StackTrace().GetFrame(1).GetMethod().DeclaringType;
            Info(message, GetCallerTypeName(callerType));
        }
        public static void Custom(string message, string caption, MessageBoxIcon msgIcon) {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, msgIcon);
        }


        private static string GetCallerTypeName(Type type) {
            if (type == null) {
                return CAssembly.SystemName;
            }

            // Remove compiler async parts first
            var cleaned = Regex.Replace(type?.Name, @"\<.*\>d__\d+", "");

            // Remove any non-alphanumeric character (keep _ if desired)
            cleaned = Regex.Replace(cleaned, @"[^a-zA-Z0-9_]", "");

            return cleaned;
        }
    }
}
