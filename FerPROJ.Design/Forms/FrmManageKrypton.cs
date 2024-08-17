using ComponentFactory.Krypton.Toolkit;
using FerPROJ.Design.Class;
using FerPROJ.Design.Controls;
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
    public partial class FrmManageKrypton : KryptonForm {
        public bool BaseFormResult { get; set; }
        public string Manage_IdTrack { get; set; }
        private BaseFormMode _currentFormMode = BaseFormMode.Add;
        public event EventHandler FormModeChanged;
        private bool hideFunction;
        private bool hideHeader;
        private bool hideFooter;
        private string onSaveNewName = "Save and New";
        private string onSaveName = "Save";
        private string onUpdateName = "Update";
        private string onCloseName = "Cancel";
        private string titleText = "Management Hub";
        private string descText = "Centralized control and insights for efficient operations.";
        private Image formIcon = null;
        public Dictionary<Keys, Action> keyboardShortcuts = new Dictionary<Keys, Action>();
        public Dictionary<Keys, Func<bool>> boolKeyboardShortcuts = new Dictionary<Keys, Func<bool>>();

        public enum BaseFormMode {
            Add,
            Update,
            ReadOnly
        }
        public BaseFormMode FormMode {
            get { return _currentFormMode; }
            set {
                _currentFormMode = value;
                OnFormModeChanged();
            }
        }
        protected virtual void OnFormModeChanged() {
            FormModeChanged?.Invoke(this, EventArgs.Empty);
        }

        public FrmManageKrypton() {
            InitializeComponent();

            this.DoubleBuffered = true;
            FormMode = BaseFormMode.Add; // Default to ReadOnly mode
            FormModeChanged += FrmManageMain_FormModeChanged;
            this.KeyPreview = true;
            this.KeyDown += OnKeyDown;
            ConstantShortcuts();
            InitializeKeyboardShortcuts();

        }
        private void ConstantShortcuts() {
            boolKeyboardShortcuts[Keys.Enter] = OnSaveData;
            keyboardShortcuts[Keys.Escape] = CloseForm;
        }
        protected virtual void InitializeKeyboardShortcuts() {

        }
        private void OnKeyDown(object sender, KeyEventArgs e) {
            if (keyboardShortcuts.ContainsKey(e.KeyCode)) {
                keyboardShortcuts[e.KeyCode]?.Invoke();
            }
            else if (boolKeyboardShortcuts.ContainsKey(e.KeyCode)) {
                if (boolKeyboardShortcuts[e.KeyCode]()) {
                    BaseFormResult = true;
                    this.Close();
                }
            }
            if (e.Control && e.KeyCode == Keys.Enter) {
                if (OnSaveNewData()) {
                    BaseFormResult = true;
                }
            }
        }
        private void FrmManageMain_FormModeChanged(object sender, EventArgs e) {
            // Update button visibility based on the new CurrentFormMode
            if (FormMode == BaseFormMode.Add) {
                kryptonBaseButtonSave.Visible = true;
                kryptonBaseButtonUpdate.Visible = false;
                LoadComponents();
            }
            else if (FormMode == BaseFormMode.Update) {
                kryptonBaseButtonSave.Visible = false;
                kryptonBaseButtonUpdate.Visible = true;
                kryptonBaseButtonSaveNew.Visible = false;
                LoadComponents();
            }
            else {
                kryptonBaseButtonSave.Visible = false;
                kryptonBaseButtonUpdate.Visible = false;
                kryptonBaseButtonSaveNew.Visible = false;
                LoadComponents();
            }
        }
        private void CloseForm() {
            if (CShowMessage.Ask("Are you sure to close?", "Confirmation")) {
                this.Close();
            }
        }
        private void baseButtonCancel_Click(object sender, EventArgs e) {
            CloseForm();
        }
        private void btnSaveMain_Click(object sender, EventArgs e) {
            try {
                if (OnSaveData()) {
                    BaseFormResult = true;
                    this.Close();
                }
            }
            catch (Exception ex) {
                CShowMessage.Warning(ex.Message, "Error");

            }

        }
        private void btnUpdateMain_Click(object sender, EventArgs e) {
            try {
                if (OnUpdateData()) {
                    BaseFormResult = true;
                    this.Close();
                }
            }
            catch (Exception ex) {
                CShowMessage.Warning(ex.Message, "Error");

            }
        }
        protected virtual bool OnSaveData() {
            return BaseFormResult;
        }
        protected virtual bool OnUpdateData() {
            return BaseFormResult;
        }
        protected virtual bool OnSaveNewData() {
            return OnSaveData();
        }
        protected virtual void LoadComponents() {


        }
        private void baseButtonAddNew_Click(object sender, EventArgs e) {
            try {
                if (OnSaveNewData()) {
                    BaseFormResult = true;
                    ClearAllTextBoxes(this);
                }
            }
            catch (Exception ex) {
                CShowMessage.Warning(ex.Message, "Error");

            }
        }
        private void ClearAllTextBoxes(Control control) {
            foreach (Control childControl in control.Controls) {
                if (childControl is CTextBox textBox) {
                    textBox.TextProperty = null;
                }
                else if (childControl.HasChildren) {
                    ClearAllTextBoxes(childControl);
                }
            }
        }
        public bool HideSaveNew {
            get { return hideFunction; }
            set {
                hideFunction = value;
                HideSaveNewFunction();
            }
        }
        private void HideSaveNewFunction() {
            kryptonBaseButtonSaveNew.Visible = !hideFunction;
        }
        public string OnSaveName {
            get {
                return onSaveName;
            }
            set {
                onSaveName = value;
                kryptonBaseButtonSave.Text = onSaveName;
            }
        }
        public string OnUpdateName {
            get {
                return onUpdateName;
            }
            set {
                onUpdateName = value;
                kryptonBaseButtonUpdate.Text = onUpdateName;
            }
        }
        public string OnSaveNewName {
            get {
                return onSaveNewName;
            }
            set {
                onSaveNewName = value;
                kryptonBaseButtonSaveNew.Text = onSaveNewName;
            }
        }
        public string OnCloseName {
            get {
                return onCloseName;
            }
            set {
                onCloseName = value;
                kryptonBaseButtonCancel.Text = onCloseName;
            }
        }
        public bool HideHeader {
            get {
                return hideHeader;
            }
            set {
                hideHeader = value;
                kryptonBasePanelTop.Visible = !hideHeader;
            }
        }
        public bool HideFooter {
            get {
                return hideFooter;
            }
            set {
                hideFooter = value;
                kryptonBasePanelBottom.Visible = !hideFooter;
            }
        }
        public string FormTitle {
            get { return titleText; }
            set {
                titleText = value;
                kryptonBaseLabelTitle.Text = titleText;
            }
        }
        public string FormDescription {
            get { return descText; }
            set {
                descText = value;
                kryptonBaseLabelDescription.Text = descText;
            }
        }
        public Image FormIcon {
            get { return formIcon; }
            set {
                formIcon = value;
                pictureBaseBoxIcon.BackgroundImage = formIcon;
                pictureBaseBoxIcon.BackgroundImageLayout = ImageLayout.Zoom;
            }
        }
    }
}
