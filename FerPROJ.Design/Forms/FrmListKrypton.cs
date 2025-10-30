﻿using ComponentFactory.Krypton.Toolkit;
using FerPROJ.Design.Class;
using FerPROJ.Design.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Windows.Forms;

namespace FerPROJ.Design.Forms {
    public partial class FrmListKrypton : KryptonForm {

        #region Fields

        private Timer _debounceTimer;
        public DateTime? dateFrom = null;
        public DateTime? dateTo = null;
        public string searchValue;
        public int dataLimit = 100;
        private bool? _currentManageMode;
        public event EventHandler ManageModeChanged;
        public string Form_IdTrack;
        private bool hideFunction;
        private bool hideFunctionAdd;
        private bool hideFunctionEdit;
        private bool hideFunctionDelete;
        private bool hideFunctionView;
        private bool hideButtonSelect;
        private bool hideFunctionOther1 = true;
        private bool hideFunctionOther2 = true;
        private bool hideDateSearch;
        private bool hideHeader;
        private string titleText = "Management Hub";
        private string descText = "Centralized control and insights for efficient operations.";
        private Image formIcon = null;
        private Image other1Icon = null;
        public Dictionary<Keys, Action> keyboardShortcuts = new Dictionary<Keys, Action>();
        public Dictionary<Keys, Func<bool>> boolKeyboardShortcuts = new Dictionary<Keys, Func<bool>>();

        #endregion

        #region Properties

        public bool CurrentManageMode {
            get {
                return _currentManageMode.Value;
            }
            set {
                _currentManageMode = value;
                OnManageModeChanged();
            }
        }

        public bool HideHeader {
            get {
                return hideHeader;
            }
            set {
                hideHeader = value;
                panelMain11.Visible = !hideHeader;
            }
        }

        public bool HideFunctionAll {
            get { return hideFunction; }
            set {
                hideFunction = value;
                HideFunctions();
            }
        }

        public bool HideSearchDate {
            get {
                return hideDateSearch;
            }
            set {
                hideDateSearch = value;
                customLabelDescMain2.Visible = !hideDateSearch;
                customLabelDescMain3.Visible = !hideDateSearch;
                baseDateFromDateTimePicker.Visible = !hideDateSearch;
                baseDateToDateTimePicker.Visible = !hideDateSearch;
            }
        }

        public bool HideFunctionAdd {
            get { return hideFunctionAdd; }
            set {
                hideFunctionAdd = value;
                tsbMainAddItem.Visible = !hideFunctionAdd;
                toolStripSeparator1.Visible = !hideFunctionAdd;
            }
        }

        public bool HideButtonSelect {
            get { return hideButtonSelect; }
            set {
                hideButtonSelect = value;
                baseButtonSelect.Visible = !hideButtonSelect;
            }
        }

        public bool HideFunctionEdit {
            get { return hideFunctionEdit; }
            set {
                hideFunctionEdit = value;
                tsbMainEditItem.Visible = !hideFunctionEdit;
                toolStripSeparator2.Visible = !hideFunctionEdit;
            }
        }

        public bool HideFunctionDelete {
            get { return hideFunctionDelete; }
            set {
                hideFunctionDelete = value;
                tsbMainDeleteItem.Visible = !hideFunctionDelete;
                toolStripSeparator3.Visible = !hideFunctionDelete;
            }
        }

        public bool HideFunctionView {
            get { return hideFunctionView; }
            set {
                hideFunctionView = value;
                tsbMainViewItem.Visible = !hideFunctionView;
            }
        }

        public bool HideFunctionOther1 {
            get { return hideFunctionOther1; }
            set {
                hideFunctionOther1 = value;
                tsbOther1.Visible = !hideFunctionOther1;
                toolStripSeparator5.Visible = !hideFunctionOther1;
            }
        }

        public bool HideFunctionOther2 {
            get { return hideFunctionOther2; }
            set {
                hideFunctionOther2 = value;
                tsbOther2.Visible = !hideFunctionOther2;
                toolStripSeparator6.Visible = !hideFunctionOther2;
            }
        }

        public string FormTitle {
            get { return titleText; }
            set {
                titleText = value;
                customLabelDescMain10.Text = titleText;
            }
        }

        public string FormDescription {
            get { return descText; }
            set {
                descText = value;
                customLabelDescMain11.Text = descText;
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

        public Image Other1Icon {
            get {
                return other1Icon;
            }
            set {
                other1Icon = value;
                tsbOther1.Image = other1Icon;
            }
        }

        public string ButtonNameAdd {
            get {
                return tsbMainAddItem.Text;
            }
            set {
                tsbMainAddItem.Text = value;
            }
        }

        public string ButtonNameEdit {
            get {
                return tsbMainEditItem.Text;
            }
            set {
                tsbMainEditItem.Text = value;
            }
        }

        public string ButtonNameDelete {
            get {
                return tsbMainDeleteItem.Text;
            }
            set {
                tsbMainDeleteItem.Text = value;
            }
        }

        public string ButtonNameView {
            get {
                return tsbMainViewItem.Text;
            }
            set {
                tsbMainViewItem.Text = value;
            }
        }

        public string ButtonNameOther1 {
            get {
                return tsbOther1.Text;
            }
            set {
                tsbOther1.Text = value;
            }
        }

        public string ButtonNameOther2 {
            get {
                return tsbOther2.Text;
            }
            set {
                tsbOther2.Text = value;
            }
        }

        #endregion

        #region Constructor

        public FrmListKrypton() {
            InitializeComponent();
            _debounceTimer = new Timer();
            _debounceTimer.Interval = 500; // Set delay to 100 milliseconds
            _debounceTimer.Tick += _debounceTimer_Tick;
            this.DoubleBuffered = true;
            ManageModeChanged += FrmListMain_ManageModeChanged;
            this.KeyPreview = true;
            this.KeyDown += OnKeyDown;
            ConstantShortcuts();
            InitializeKeyboardShortcuts();
        }

        #endregion

        #region Binding Sources and DataGridViews
        protected CDatagridview MainModelDataGridView { get; set; }
        #endregion

        #region Event Handlers

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            if (!_currentManageMode.HasValue) {
                CurrentManageMode = true;
            }
        }

        private async void FrmListMain_Load(object sender, EventArgs e) {
            try {
                await RefreshAsync();
                await InitializeFormPropertiesAsync();
            }
            catch (Exception ex) {
                CDialogManager.Warning(ex.Message, "Error");
            }
        }

        private async void _debounceTimer_Tick(object sender, EventArgs e) {
            _debounceTimer.Stop();
            searchValue = SearchTextBox.Text;
            dateFrom = baseDateFromDateTimePicker.Value;
            dateTo = baseDateToDateTimePicker.Value;

            if (!checkBoxDGVSearch.Checked) {
                await RefreshAsync();
            }
            else {
                RefreshDataGridViewAsync().RunTask();
            }
        }

        private void baseDateFromDateTimePicker_ValueChanged(object sender, EventArgs e) {
            // Restart the timer every time the text changes
            _debounceTimer.Stop();
            _debounceTimer.Start();
        }

        private void SearchTextBox__TextChanged(object sender, EventArgs e) {
            // Restart the timer every time the text changes
            _debounceTimer.Stop();
            _debounceTimer.Start();
        }

        private async void ComboBoxKryptonDataLimit_SelectedIndexChanged(object sender, EventArgs e) {
            if (ComboBoxKryptonDataLimit.SelectedIndex != -1) {
                dataLimit = ComboBoxKryptonDataLimit.Text.ToInt();
                await RefreshAsync();
            }
        }

        private void baseButtonCancel_Click(object sender, EventArgs e) {
            CloseForm();
        }

        private async void baseButtonSelect_Click(object sender, EventArgs e) {
            await SelectDataAsync();
        }

        private async void tsbMainAddItem_Click(object sender, EventArgs e) {
            try {
                var result = await AddNewItemAsync();
                if (result) {
                    await RefreshAsync();
                }
            }
            catch (Exception ex) {
                CDialogManager.Warning(ex.Message, "Error");
            }
        }

        private async void tsbMainEditItem_Click(object sender, EventArgs e) {
            try {
                var result = await UpdateItemAsync();
                if (result) {
                    await RefreshAsync();
                }
            }
            catch (Exception ex) {
                CDialogManager.Warning(ex.Message, "Error");
            }
        }

        private async void tsbMainDeleteItem_Click(object sender, EventArgs e) {
            try {
                var result = await DeleteItemAsync();
                if (result) {
                    await RefreshAsync();
                }
            }
            catch (Exception ex) {
                CDialogManager.Warning(ex.Message, "Error");
            }
        }

        private async void tsbMainViewItem_Click(object sender, EventArgs e) {
            try {
                var result = await ViewItemAsync();
                if (result) {
                    await RefreshAsync();
                }
            }
            catch (Exception ex) {
                CDialogManager.Warning(ex.Message, "Error");
            }
        }

        private async void tsbMainRefresh_Click(object sender, EventArgs e) {
            try {
                await RefreshAsync();
            }
            catch (Exception ex) {
                CDialogManager.Warning(ex.Message, "Error");
            }
        }

        private async void tsbOther1_Click(object sender, EventArgs e) {
            try {
                var result = await Other1Async();
                if (result) {
                    await RefreshAsync();
                }
            }
            catch (Exception ex) {
                CDialogManager.Warning(ex.Message, "Error");
            }
        }

        private async void tsbOther2_Click(object sender, EventArgs e) {
            try {
                var result = await Other2Async();
                if (result) {
                    await RefreshAsync();
                }
            }
            catch (Exception ex) {
                CDialogManager.Warning(ex.Message, "Error");
            }
        }

        private async void OnKeyDown(object sender, KeyEventArgs e) {
            if (keyboardShortcuts.ContainsKey(e.KeyCode)) {
                keyboardShortcuts[e.KeyCode]?.Invoke();
            }
            else if (boolKeyboardShortcuts.ContainsKey(e.KeyCode)) {
                if (boolKeyboardShortcuts[e.KeyCode]()) {
                    await RefreshAsync();
                }
            }
        }

        private async void FrmListMain_ManageModeChanged(object sender, EventArgs e) {
            if (CurrentManageMode) {
                baseButtonSelect.Visible = false;
            }
            else {
                baseButtonSelect.Visible = true;
                HideFunctionAll = true;
            }
            await LoadComponentsAsync();
        }

        #endregion

        #region Methods

        protected virtual void OnManageModeChanged() {
            ManageModeChanged?.Invoke(this, EventArgs.Empty);
        }

        private void ConstantShortcuts() {
            keyboardShortcuts[Keys.Escape] = CloseForm;
        }

        protected virtual void InitializeKeyboardShortcuts() {

        }

        private void CloseForm() {
            if (CDialogManager.Ask("Are you sure to close?", "Confirmation")) {
                this.Close();
            }
        }

        private void HideFunctions() {
            tsbMainAddItem.Visible = !hideFunction;
            tsbMainDeleteItem.Visible = !hideFunction;
            tsbMainEditItem.Visible = !hideFunction;
            tsbMainViewItem.Visible = !hideFunction;
            tsbOther1.Visible = !hideFunction;
            tsbOther2.Visible = !hideFunction;
            toolStripSeparator1.Visible = !hideFunction;
            toolStripSeparator2.Visible = !hideFunction;
            toolStripSeparator3.Visible = !hideFunction;
            toolStripSeparator5.Visible = !hideFunction;
            toolStripSeparator6.Visible = !hideFunction;
        }

        private async Task RefreshAsync() {
            await RefreshDataAsync();
        }
        private async Task SelectDataAsync() {
            if (await GetSelectedDataAsync()) {
                this.Close();
            }
        }

        protected virtual async Task InitializeFormPropertiesAsync() {
            await RefreshDataSourceAsync();
        }
        protected virtual async Task RefreshDataSourceAsync() {
            if (MainModelDataGridView != null) {
                MainModelDataGridView?.ApplyCustomAttribute();
            }
            await Task.CompletedTask;
        }

        #endregion

        #region Data Methods

        protected async virtual Task LoadComponentsAsync() {
            await Task.CompletedTask;
        }

        protected async virtual Task RefreshDataAsync() {
            await Task.CompletedTask;
        }

        protected virtual async Task RefreshDataGridViewAsync() {
            await Task.CompletedTask;
        }

        protected async virtual Task<bool> GetSelectedDataAsync() {
            return await Task.FromResult(MainModelDataGridView.GetSelectedValue(0, out Form_IdTrack));
        }

        protected async virtual Task<bool> AddNewItemAsync() {
            return await Task.FromResult(true);
        }

        protected async virtual Task<bool> UpdateItemAsync() {
            return await Task.FromResult(true);
        }

        protected async virtual Task<bool> DeleteItemAsync() {
            return await Task.FromResult(true);
        }

        protected async virtual Task<bool> ViewItemAsync() {
            return await Task.FromResult(true);
        }

        protected async virtual Task<bool> Other1Async() {
            return await Task.FromResult(true);
        }

        protected async virtual Task<bool> Other2Async() {
            return await Task.FromResult(true);
        }

        #endregion
    }
}