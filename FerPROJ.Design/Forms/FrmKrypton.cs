using FerPROJ.Design.Class;
using Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FerPROJ.Design.Forms {
    public partial class FrmKrypton : KryptonForm {

        #region General form fields
        public bool IsDesignMode => LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode;
        #endregion

        #region Keyboard Shortcuts Fields
        /// <summary>
        /// Usage: keyboardShortcuts[Keys.F1] = Function Name;
        /// </summary>
        public Dictionary<Keys, Func<Task>> KeyboardShortcuts = new Dictionary<Keys, Func<Task>>();
        public Dictionary<Keys, Func<Task<bool>>> BoolKeyboardShortcuts = new Dictionary<Keys, Func<Task<bool>>>();
        #endregion

        #region ctor and Load
        public FrmKrypton() {
            InitializeComponent();
        }

        private void FrmKrypton_Load(object sender, EventArgs e) {
            if (IsDesignMode)
                return;

            LoadKeyboardShortcut();
        }
        #endregion

        #region Keyboard methods
        private async void FrmKrypton_KeyDown(object sender, KeyEventArgs e) {
            // Build combined key (Ctrl/Shift/Alt + main key)
            var key = BuildShortcutKey(e);

            // 1️⃣ Async shortcuts dictionary
            if (KeyboardShortcuts.TryGetValue(key, out var asyncAction)) {
                await asyncAction();
                e.SuppressKeyPress = true;
                return;
            }

            if (BoolKeyboardShortcuts.TryGetValue(e.KeyCode, out var boolAsyncAction)) {
                if (await boolAsyncAction()) {
                    this.Close();
                }
                return;
            }
        }
        private static Keys BuildShortcutKey(KeyEventArgs e) {
            Keys key = e.KeyCode;

            if (e.Control) key |= Keys.Control;
            if (e.Shift) key |= Keys.Shift;
            if (e.Alt) key |= Keys.Alt;

            return key;
        }
        private void LoadKeyboardShortcut() {
            KeyPreview = true;
            KeyDown += FrmKrypton_KeyDown;
            KeyboardShortcuts[Keys.Escape] = async () => {
                CloseForm();
                await Task.CompletedTask;
            };
        }
        #endregion

        #region Form closing
        private void CloseForm() {
            if (CDialogManager.Ask("Are you sure to close?")) {
                this.Close();
            }
        }
        #endregion

    }
}
