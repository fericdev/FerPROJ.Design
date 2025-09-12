using FerPROJ.Design.Class;
using FerPROJ.Design.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using System.Threading.Tasks;
using FerPROJ.Design.BaseModels;

namespace FerPROJ.Design.Forms {
    public partial class FrmManageKrypton : KryptonForm {

        #region Task and Guid
        public Task<bool> CurrentFormResult { get; set; }
        public Guid Manage_IdTrack { get; set; }
        #endregion

        #region FormMode
        private FormMode? _currentFormMode;
        public event EventHandler FormModeChanged;
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
        #endregion

        #region Hide/Show Flags
        private bool hideFunctionOnUpdate = true;
        private bool hideFunction;
        private bool hideHeader;
        private bool hideFooter;
        #endregion

        #region Button Names
        private string onSaveNewName = "Save and New";
        private string onSaveName = "Save";
        private string onUpdateName = "Update";
        private string onCloseName = "Cancel";
        #endregion

        #region Form Title/Description/Icon
        private string titleText = "Management Hub";
        private string descText = "Centralized control and insights for efficient operations.";
        private Image formIcon = null;
        #endregion

        #region Keyboard Shortcuts
        /// <summary>
        /// Usage: keyboardShortcuts[Keys.F1] = Function Name;
        /// </summary>
        public Dictionary<Keys, Action> keyboardShortcuts = new Dictionary<Keys, Action>();
        public Dictionary<Keys, Func<bool>> boolKeyboardShortcuts = new Dictionary<Keys, Func<bool>>();
        #endregion

        #region Binding Sources and DataGridViews
        protected BindingSource MainModelBindingSource { get; set; }
        protected BindingSource ItemModelBindingSource { get; set; }
        protected CDatagridview MainModelDataGridView { get; set; }
        protected CDatagridview ItemModelDataGridView { get; set; }
        #endregion

        #region Constructor and OnLoad
        public FrmManageKrypton() {
            InitializeComponent();
            this.DoubleBuffered = true;
            FormModeChanged += FrmManageMain_FormModeChanged;
            this.KeyPreview = true;
            this.KeyDown += OnKeyDown;
            ConstantShortcuts();
            InitializeKeyboardShortcuts();

        }
        protected virtual void OnFormModeChanged() {
            FormModeChanged?.Invoke(this, EventArgs.Empty);
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            if (!_currentFormMode.HasValue) {
                CurrentFormMode = FormMode.Add;
            }
        }
        private async void FrmManageKrypton_Load(object sender, EventArgs e) {
            await InitializeFormPropertiesAsync();
            LoadFormEventHandler();
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
            await LoadComponentsAsync();
        }
        protected virtual void LoadFormEventHandler() {
        }
        protected virtual async Task InitializeFormPropertiesAsync() {
            await RefreshDataSourceAsync();
        }
        protected virtual async Task RefreshDataSourceAsync() {
            if (MainModelBindingSource != null) {
                MainModelBindingSource?.ResetBindings(false);
            }
            if (ItemModelBindingSource != null) {
                ItemModelBindingSource?.ResetBindings(false);
            }
            if (MainModelDataGridView != null) {
                MainModelDataGridView?.ApplyCustomAttribute();
            }
            if (ItemModelDataGridView != null) {
                ItemModelDataGridView?.ApplyCustomAttribute();
            }
            await Task.CompletedTask;
        }
        #endregion

        #region Keyboard Shortcuts Methods
        private void ConstantShortcuts() {
            keyboardShortcuts[Keys.Escape] = CloseForm;
        }

        protected virtual void InitializeKeyboardShortcuts() {

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
                var result = await OnSaveNewDataAsync();
                if (result) {
                    CurrentFormResult = Task.FromResult(true);
                }
            }
        }
        #endregion

        #region CRUD and Form Control Button Methods

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
                var result = await OnSaveDataAsync();
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
                var result = await OnUpdateDataAsync();
                if (result) {
                    CurrentFormResult = Task.FromResult(true);
                    this.Close();
                }
            }
            catch (Exception ex) {
                CDialogManager.Warning(ex.Message);

            }
        }
        protected async virtual Task<bool> OnSaveDataAsync() {
            return await CurrentFormResult;
        }
        protected async virtual Task<bool> OnUpdateDataAsync() {
            return await CurrentFormResult;
        }
        protected async virtual Task<bool> OnSaveNewDataAsync() {
            return await OnSaveDataAsync();
        }
        protected async virtual Task LoadComponentsAsync() {
            await Task.CompletedTask;
        }

        private async void baseButtonAddNew_Click(object sender, EventArgs e) {
            try {
                var result = await OnSaveNewDataAsync();
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
        #endregion

        #region Hide/Show Properties
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
        #endregion

        #region Button Name Properties
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
        #endregion

        #region Form Title/Description/Icon Properties
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
        #endregion

        #region Hide/Show Methods
        private void HideSaveNewFunctionOnUpdate() {
            baseButtonAddNew.Visible = !hideFunctionOnUpdate;
        }
        private void HideSaveNewFunction() {
            baseButtonAddNew.Visible = !hideFunction;
        }
        #endregion

        #region Extension
        protected async Task<TModelItem> GetDataGridViewModelItemAsync<TModelItem>() where TModelItem : BaseModelItem {

            var dgv = ItemModelDataGridView;

            await Task.CompletedTask;

            return dgv.GetItemDTO<TModelItem>();
        }
        #endregion
    }
}