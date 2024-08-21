using FerPROJ.Design.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace FerPROJ.Design.Forms
{
    public partial class FrmListKrypton : KryptonForm {

        public DateTime dateFrom = DateTime.Now;
        public DateTime dateTo = DateTime.Now;
        public string searchValue;
        private bool _currentManageMode;
        public event EventHandler ManageModeChanged;
        public string Form_IdTrack;
        private bool hideFunction;
        private bool hideFunctionAdd;
        private bool hideFunctionEdit;
        private bool hideFunctionDelete;
        private bool hideFunctionView;
        private bool hideDateSearch;
        private bool hideHeader;
        private string titleText = "Management Hub";
        private string descText = "Centralized control and insights for efficient operations.";
        private Image formIcon = null;
        public Dictionary<Keys, Action> keyboardShortcuts = new Dictionary<Keys, Action>();
        public Dictionary<Keys, Func<bool>> boolKeyboardShortcuts = new Dictionary<Keys, Func<bool>>();
        public bool CurrentManageMode {
            get { return _currentManageMode; }
            set {
                _currentManageMode = value;
                OnManageModeChanged();
            }
        }
        protected virtual void OnManageModeChanged() {
            ManageModeChanged?.Invoke(this, EventArgs.Empty);
        }

        public FrmListKrypton() {
            InitializeComponent();
            this.DoubleBuffered = true;
            CurrentManageMode = false;
            ManageModeChanged += FrmListMain_ManageModeChanged;
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
        private async void OnKeyDown(object sender, KeyEventArgs e) {
            if (keyboardShortcuts.ContainsKey(e.KeyCode)) {
                keyboardShortcuts[e.KeyCode]?.Invoke();
            } else if (boolKeyboardShortcuts.ContainsKey(e.KeyCode)) {
                if (boolKeyboardShortcuts[e.KeyCode]()) {
                    await RefreshData();
                }
            }
        }
        private void FrmListMain_ManageModeChanged(object sender, EventArgs e) {
            if (!CurrentManageMode) {
                baseButtonSelect.Visible = false;
            }
        }
        private async Task SelectData() {
            if (await GetSelectedData()) {
                this.Close();
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

        private async void baseButtonSelect_Click(object sender, EventArgs e) {
            await SelectData();
        }
        protected async virtual Task RefreshData() {
            await Task.CompletedTask;
        }

        private async void FrmListMain_Load(object sender, EventArgs e) {
            try {
                await RefreshData();
            } catch (Exception ex) {
                CShowMessage.Warning(ex.Message, "Error");
            }
        }
        private async void tsbMainAddItem_Click(object sender, EventArgs e) {
            try {
                if (await AddNewItem()) {
                    await RefreshData();
                }
            } catch (Exception ex) {
                CShowMessage.Warning(ex.Message, "Error");
            }
        }

        private async void tsbMainEditItem_Click(object sender, EventArgs e) {
            try {
                if (await UpdateItem()) {
                    await RefreshData();
                }
            } catch (Exception ex) {
                CShowMessage.Warning(ex.Message, "Error");
            }
        }

        private async void tsbMainDeleteItem_Click(object sender, EventArgs e) {
            try {
                if (await DeleteItem()) {
                    await RefreshData();
                }
            } catch (Exception ex) {
                CShowMessage.Warning(ex.Message, "Error");
            }
        }

        private async void tsbMainViewItem_Click(object sender, EventArgs e) {
            try {
                await ViewItem();
            } catch (Exception ex) {
                CShowMessage.Warning(ex.Message, "Error");
            }
        }

        private async void tsbMainRefresh_Click(object sender, EventArgs e) {
            try {
                await RefreshData();
            } catch (Exception ex) {
                CShowMessage.Warning(ex.Message, "Error");
            }
        }
        protected async virtual Task<bool> GetSelectedData() {
            return await Task.FromResult(true);
        }
        protected async virtual Task<bool> AddNewItem() {
            return await Task.FromResult(true);
        }
        protected async virtual Task<bool> UpdateItem() {
            return await Task.FromResult(true);
        }
        protected async virtual Task<bool> DeleteItem() {
            return await Task.FromResult(true);
        }
        protected async virtual Task ViewItem() {
            await Task.CompletedTask;
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

        private void HideFunctions() {
            tsbMainAddItem.Visible = !hideFunction;
            tsbMainDeleteItem.Visible = !hideFunction;
            tsbMainEditItem.Visible = !hideFunction;
            tsbMainViewItem.Visible = !hideFunction;
            toolStripSeparator1.Visible = !hideFunction;
            toolStripSeparator2.Visible = !hideFunction;
            toolStripSeparator3.Visible = !hideFunction;
        }

        private async void SearchTextValue__TextChanged(object sender, EventArgs e) {
            searchValue = SearchTextBox.Text;
            dateFrom = baseDateFromDateTimePicker.Value;
            dateTo = baseDateToDateTimePicker.Value;
            await RefreshData();
        }

        private async void baseDateFromDateTimePicker_ValueChanged(object sender, EventArgs e) {
            searchValue = SearchTextBox.Text;
            dateFrom = baseDateFromDateTimePicker.Value;
            dateTo = baseDateToDateTimePicker.Value;
            await RefreshData();
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
    }
}
