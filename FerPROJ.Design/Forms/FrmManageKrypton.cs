using ComponentFactory.Krypton.Toolkit;
using FerPROJ.Design.BaseModels;
using FerPROJ.Design.Class;
using FerPROJ.Design.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FerPROJ.Design.Class.CBaseEnums;

namespace FerPROJ.Design.Forms {
    public partial class FrmManageKrypton : KryptonForm {

        #region Task and Guid
        public Task<bool> CurrentFormResult { get; set; }
        public Guid Manage_IdTrack { get; set; }
        #endregion

        #region FormMode
        private FormMode? _currentFormMode;
        public event EventHandler FormModeChanged;
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
        private bool hideSave;
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
        public Dictionary<Keys, Func<Task>> keyboardShortcuts = new Dictionary<Keys, Func<Task>>();
        public Dictionary<Keys, Func<Task<bool>>> boolKeyboardShortcuts = new Dictionary<Keys, Func<Task<bool>>>();
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
            if (!_currentFormMode.HasValue) {
                CurrentFormMode = FormMode.Add;
            }
            base.OnLoad(e);
        }
        private async void FrmManageKrypton_Load(object sender, EventArgs e) {
            await InitializeFormPropertiesAsync();
            LoadFormEventHandler();
        }
        private async void FrmManageMain_FormModeChanged(object sender, EventArgs e) {
            // Update button visibility based on the new CurrentFormMode
            if (CurrentFormMode == FormMode.Add) {
                if (!hideSave) {
                    baseButtonSave.Visible = true;
                    baseButtonUpdate.Visible = false;
                    keyboardShortcuts[Keys.Control | Keys.S] = () => { baseButtonSave.PerformClick(); return Task.CompletedTask; };
                }
            }
            else if (CurrentFormMode == FormMode.Update) {
                if (!hideSave) {
                    baseButtonSave.Visible = false;
                    baseButtonUpdate.Visible = true;
                    keyboardShortcuts[Keys.Control | Keys.S] = () => { baseButtonUpdate.PerformClick(); return Task.CompletedTask; };
                }
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
                ItemModelDataGridView?.TrackChangesAndCallMethod(RefreshDataSourceAsync);
                ItemModelDataGridView?.ApplyRowValueFormatting();
            }
            await Task.CompletedTask;
        }
        #endregion

        #region Keyboard Shortcuts Methods
        private void ConstantShortcuts() {
            keyboardShortcuts[Keys.Escape] = () => { baseButtonCancel.PerformClick(); return Task.CompletedTask; };
        }

        protected virtual void InitializeKeyboardShortcuts() {

        }

        private async void OnKeyDown(object sender, KeyEventArgs e) {

            // Build combined key (Ctrl/Shift/Alt + main key)
            var key = BuildShortcutKey(e);

            // 1️⃣ Async shortcuts dictionary
            if (keyboardShortcuts.TryGetValue(key, out var asyncAction)) {
                await asyncAction();
                e.SuppressKeyPress = true;
                return;
            }

            if (boolKeyboardShortcuts.TryGetValue(e.KeyCode, out var boolAsyncAction)) {
                if (await boolAsyncAction()) {
                    CurrentFormResult = Task.FromResult(true);
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
        #endregion

        #region CRUD and Form Control Button Methods

        private async void CloseForm() {
            if (CDialogManager.Ask("Are you sure to close?", "Confirmation")) {
                CurrentFormResult = Task.FromResult(false);
                this.Close();
                await CEventManager.RaiseMethodsOnManageFormClosedAsync();
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
                    await CEventManager.RaiseMethodsOnManageFormClosedAsync();
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
                    await CEventManager.RaiseMethodsOnManageFormClosedAsync();
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
        public async Task<bool> CurrentFormResultAsync(FormMode formMode, Guid id, List<(string PropertyName, object PropertyValue)> parameters = null) {
            BuildParameter(parameters);
            this.Manage_IdTrack = id;
            this.CurrentFormMode = formMode;
            this.ShowDialog();
            return await CurrentFormResult;
        }
        public async Task<bool> CurrentNewFormResultAsync<TForm>(FormMode formMode = FormMode.Add, Guid? id = null, Action<TForm> parameters = null) where TForm : FrmManageKrypton {
            if (!parameters.IsNullOrEmpty()) {
                Action<object> parameterWrapper  = o => parameters((TForm)o);
                parameterWrapper?.Invoke(this);
            }
            if (!id.IsNullOrEmpty()) {
                this.Manage_IdTrack = id.Value;
            }
            this.CurrentFormMode = formMode;
            this.ShowDialog();
            return await CurrentFormResult;
        }

        #region Set parameter
        private void BuildParameter(List<(string PropertyName, object PropertyValue)> parameters = null) {
            if (parameters.IsNullOrEmpty())
                return;

            var formType = this.GetType();

            foreach (var parameter in parameters) {
                var value = parameter.PropertyValue;

                // Try property first
                var property = formType.GetProperty(parameter.PropertyName, BindingFlags.Public | BindingFlags.Instance);
                if (property != null && property.CanWrite) {
                    SetMemberValue(property.PropertyType, v => property.SetValue(this, v), value);
                    continue;
                }

                // Try field next
                var field = formType.GetField(parameter.PropertyName, BindingFlags.Public | BindingFlags.Instance);
                if (field != null) {
                    SetMemberValue(field.FieldType, v => field.SetValue(this, v), value);
                }
            }
        }
        private void SetMemberValue(Type targetType, Action<object> setter, object value) {
            if (value == null) {
                if (!targetType.IsValueType || Nullable.GetUnderlyingType(targetType) != null) {
                    setter(null);
                }
                return;
            }

            var actualTargetType = Nullable.GetUnderlyingType(targetType) ?? targetType;

            try {
                if (actualTargetType == typeof(Guid)) {
                    if (value is Guid guidValue) {
                        setter(guidValue);
                    }
                    else if (Guid.TryParse(value.ToString(), out var parsedGuid)) {
                        setter(parsedGuid);
                    }
                }
                else if (actualTargetType.IsAssignableFrom(value.GetType())) {
                    setter(value);
                }
                else {
                    var convertedValue = Convert.ChangeType(value, actualTargetType);
                    setter(convertedValue);
                }
            }
            catch {
                // ignore invalid assignment
            }
        }
        #endregion

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
        public bool HideSave {
            get {
                return hideSave;
            }
            set {
                hideSave = value;
                baseButtonSave.Visible = !hideSave;
                baseButtonUpdate.Visible = !hideSave;
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