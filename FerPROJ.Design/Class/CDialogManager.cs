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
        public static bool IsDialogOpened = false;
        public static bool Ask(string message, string caption, bool topMost) {
            if (IsDialogOpened) {
                return false;
            }

            Form mainForm = Application.OpenForms
                .Cast<Form>()
                .FirstOrDefault(f => f.IsHandleCreated);

            if (mainForm != null && mainForm.InvokeRequired) {
                return (bool)mainForm.Invoke(new Func<bool>(() =>
                    Ask(message, caption, topMost)
                ));
            }

            try {
                IsDialogOpened = true; // ✅ SET when dialog starts

                if (topMost) {
                    using (Form top = new Form() {
                        TopMost = true,
                        ShowInTaskbar = false,
                        WindowState = FormWindowState.Minimized,
                        FormBorderStyle = FormBorderStyle.None,
                        Opacity = 0
                    }) {
                        DialogResult result = DialogResult.None;

                        top.Load += (s, e) => {
                            result = MessageBox.Show(
                                top,
                                message,
                                caption,
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question
                            );

                            top.Close();
                        };

                        top.ShowDialog();

                        return result == DialogResult.Yes;
                    }
                }
                else {
                    return Ask(message, caption);
                }
            }
            finally {
                IsDialogOpened = false; // ✅ ALWAYS reset even if exception occurs
            }
        }
        public static bool Ask(string message, string caption) {
            if (MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                return true;
            }
            return false;
        }
        public static bool Ask(string message) {
            return Ask(message, CAssembly.SystemNameFull);
        }
        public static void Warning(string message, string caption) {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static void Warning(string message) {
            Warning(message, CAssembly.SystemNameFull);
        }
        public static void Info(string message, string caption) {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void Info(string message) {
            Info(message, CAssembly.SystemNameFull);
        }
        public static void Custom(string message, string caption, MessageBoxIcon msgIcon, bool topMost = false) {
            Form mainForm = Application.OpenForms.Cast<Form>().FirstOrDefault(f => f.IsHandleCreated);

            if (mainForm != null && mainForm.InvokeRequired) {
                mainForm.BeginInvoke(new Action(() =>
                    Custom(message, caption, msgIcon, topMost)
                ));
                return;
            }

            if (topMost) {
                Form top = new Form() {
                    TopMost = true,
                    ShowInTaskbar = false,
                    WindowState = FormWindowState.Minimized,
                    FormBorderStyle = FormBorderStyle.None,
                    Opacity = 0
                };

                top.Load += (s, e) => {
                    MessageBox.Show(top, message, caption, MessageBoxButtons.OK, msgIcon);
                    top.Close();
                };

                top.Show();
            }
            else {
                MessageBox.Show(message, caption, MessageBoxButtons.OK, msgIcon);
            }
        }
    }
}
