using FerPROJ.Design.Class;
using FerPROJ.Design.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using System.Threading.Tasks;

namespace FerPROJ.Design.Forms {
    public partial class FrmManageKrypton : KryptonForm {
        public Task<bool> CurrentFormResult { get; set; }
        public Guid Manage_IdTrack { get; set; }
        private FormMode? _currentFormMode;
        public event EventHandler FormModeChanged;
        private bool hideFunctionOnUpdate = true;
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
        /// <summary>
        /// Usage: keyboardShortcuts[Keys.F1] = Function Name;
        /// </summary>
        public Dictionary<Keys, Action> keyboardShortcuts = new Dictionary<Keys, Action>();
        public Dictionary<Keys, Func<bool>> boolKeyboardShortcuts = new Dictionary<Keys, Func<bool>>();

        public enum FormMode {
            Add,
            Update,
            ReadOnly
        }
        public FormMode CurrentFormMode {
            get {
                return _currentFormMode.Value;
            }
            set {
                _currentFormMode = value;
                OnFormModeChanged();
            }
        }
        protected virtual void OnFormModeChanged() {
            FormModeChanged?.Invoke(this, EventArgs.Empty);
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            InitializeFormProperties();
            if (!_currentFormMode.HasValue) {
                CurrentFormMode = FormMode.Add;
            }
        }
        public FrmManageKrypton() {
            InitializeComponent();
            this.DoubleBuffered = true;
            FormModeChanged += FrmManageMain_FormModeChanged;
            this.KeyPreview = true;
            this.KeyDown += OnKeyDown;
            ConstantShortcuts();
            InitializeKeyboardShortcuts();
        }

        private void ConstantShortcuts() {
            keyboardShortcuts[Keys.Escape] = CloseForm;
        }

        protected virtual void InitializeKeyboardShortcuts() {

        }
        protected virtual void InitializeFormProperties() {
        }
        private async void OnKeyDown(object sender, KeyEventArgs e) {
            if (keyboardShortcuts.ContainsKey(e.KeyCode)) {
                keyboardShortcuts[e.KeyCode]?.Invoke();
            }
            else if (boolKeyboardShortcuts.ContainsKey(e.KeyCode)) {
                if (boolKeyboardShortcuts[e.KeyCode]()) {
                    CurrentFormResult = Task.FromResult(true);
                    this.Close();
                }
            }
            if (e.Control && e.KeyCode == Keys.Enter) {
                var result = await OnSaveNewData();
                if (result) {
                    CurrentFormResult = Task.FromResult(true);
                }
            }
        }
        private async void FrmManageMain_FormModeChanged(object sender, EventArgs e) {
            // Update button visibility based on the new CurrentFormMode
            if (CurrentFormMode == FormMode.Add) {
                baseButtonSave.Visible = true;
                baseButtonUpdate.Visible = false;
            }
            else if (CurrentFormMode == FormMode.Update) {
                baseButtonSave.Visible = false;
                baseButtonUpdate.Visible = true;
                baseButtonAddNew.Visible = !hideFunctionOnUpdate;
            }
            else {
                baseButtonSave.Visible = false;
                baseButtonUpdate.Visible = false;
                baseButtonAddNew.Visible = false;
            }
            await LoadComponents();
        }
        private void CloseForm() {
            if (CDialogManager.Ask("Are you sure to close?", "Confirmation")) {
                CurrentFormResult = Task.FromResult(false);
                this.Close();
            }
        }
        private void baseButtonCancel_Click(object sender, EventArgs e) {
            CloseForm();
        }
        private async void btnSaveMain_Click(object sender, EventArgs e) {
            try {
                var result = await OnSaveData();
                if (result) {
                    CurrentFormResult = Task.FromResult(true);
                    this.Close();
                }
            }
            catch (Exception ex) {
                CDialogManager.Warning(ex.Message);

            }

        }
        private async void btnUpdateMain_Click(object sender, EventArgs e) {
            try {
                var result = await OnUpdateData();
                if (result) {
                    CurrentFormResult = Task.FromResult(true);
                    this.Close();
                }
            }
            catch (Exception ex) {
                CDialogManager.Warning(ex.Message);

            }
        }
        protected async virtual Task<bool> OnSaveData() {
            return await CurrentFormResult;
        }
        protected async virtual Task<bool> OnUpdateData() {
            return await CurrentFormResult;
        }
        protected async virtual Task<bool> OnSaveNewData() {
            return await OnSaveData();
        }
        protected async virtual Task LoadComponents() {
            await Task.CompletedTask;
        }

        private async void baseButtonAddNew_Click(object sender, EventArgs e) {
            try {
                var result = await OnSaveNewData();
                if (result) {
                    CurrentFormResult = Task.FromResult(true);
                    ClearAllTextBoxes(this);
                }
            }
            catch (Exception ex) {
                CDialogManager.Warning(ex.Message);

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
        public bool HideSaveNewOnUpdate {
            get { return hideFunctionOnUpdate; }
            set {
                hideFunctionOnUpdate = value;
                HideSaveNewFunctionOnUpdate();
            }
        }
        public string OnSaveName {
            get {
                return onSaveName;
            }
            set {
                onSaveName = value;
                baseButtonSave.Text = onSaveName;
            }
        }
        public string OnUpdateName {
            get {
                return onUpdateName;
            }
            set {
                onUpdateName = value;
                baseButtonUpdate.Text = onUpdateName;
            }
        }
        public string OnSaveNewName {
            get {
                return onSaveNewName;
            }
            set {
                onSaveNewName = value;
                baseButtonAddNew.Text = onSaveNewName;
            }
        }
        public string OnCloseName {
            get {
                return onCloseName;
            }
            set {
                onCloseName = value;
                baseButtonCancel.Text = onCloseName;
            }
        }
        public bool HideHeader {
            get {
                return hideHeader;
            }
            set {
                hideHeader = value;
                panelMain1.Visible = !hideHeader;
            }
        }
        public bool HideFooter {
            get {
                return hideFooter;
            }
            set {
                hideFooter = value;
                basePnl1.Visible = !hideFooter;
            }
        }
        private void HideSaveNewFunctionOnUpdate() {
            baseButtonAddNew.Visible = !hideFunctionOnUpdate;
        }
        private void HideSaveNewFunction() {
            baseButtonAddNew.Visible = !hideFunction;
        }
        public string FormTitle {
            get { return titleText; }
            set {
                titleText = value;
                customLabelDescMain1.Text = titleText;
            }
        }
        public string FormDescription {
            get { return descText; }
            set {
                descText = value;
                customLabelDescMain2.Text = descText;
            }
        }
        public Image FormIcon {
            get { return formIcon; }
            set {
                formIcon = value;
                pictureBoxMain1.BackgroundImage = formIcon;
                pictureBoxMain1.BackgroundImageLayout = ImageLayout.Zoom;
            }
        }
    }
}
