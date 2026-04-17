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
        public static bool Ask(string message, string caption, bool topMost) {
            Form mainForm = Application.OpenForms.Cast<Form>().FirstOrDefault(f => f.IsHandleCreated);

            if (mainForm != null && mainForm.InvokeRequired) {
                return (bool)mainForm.Invoke(new Func<bool>(() =>
                    Ask(message, caption, topMost)
                ));
            }

            if (topMost) {
                using (Form top = new Form() {
                    TopMost = true,
                    ShowInTaskbar = false,
                    WindowState = FormWindowState.Minimized,
                    FormBorderStyle = FormBorderStyle.None,
                    Opacity = 0
                }) {
                    DialogResult result = DialogResult.None;

                    top.Load += (s, e) =>
                    {
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
                return MessageBox.Show(
                    message,
                    caption,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                ) == DialogResult.Yes;
            }
        }
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

                top.Load += (s, e) =>
                {
                    MessageBox.Show(top, message, caption, MessageBoxButtons.OK, msgIcon);
                    top.Close();
                };

                top.Show();
            }
            else {
                MessageBox.Show(message, caption, MessageBoxButtons.OK, msgIcon);
            }
        }


        private static string GetCallerTypeName(Type type) {
            if (type == null) {
                return CAssembly.SystemName;
            }

            return type?.Name.ToStringNormalize().ToStringWithSpaces().ToStringRemoveEndWith("Async");
        }
    }
}
