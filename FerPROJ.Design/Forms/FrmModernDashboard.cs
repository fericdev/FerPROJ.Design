using FerPROJ.Design.Class;
using FerPROJ.Design.Controls;
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
    public partial class FrmModernDashboard : FrmKrypton {
        public ToolStrip ParentToolStrip { get; set; } = new ToolStrip();
        public ToolStripDropDownButton ParentToolStripDropDown { get; set; } = new ToolStripDropDownButton();
        public List<MenuItemModel> NavigationMenuItems { get; set; } = new List<MenuItemModel>();
        public List<MenuItemModel> ReportMenuItems { get; set; } = new List<MenuItemModel>();
        public FrmModernDashboard() {
            InitializeComponent();
            if (IsDesignMode) {
                return;
            }
            ParentToolStrip = tsMainSettings;
            ParentToolStripDropDown = tsMainDropDown;
            InitializeToolStripButtons();
        }

        private void FrmDashboard3_Load(object sender, EventArgs e) {
            if (IsDesignMode) {
                return;
            }
            try {
                timerMain.Start();
                LoadToolStripButtons();
                LoadVar();
                LoadComponent();
                InitializeMenuButtons();
                InitializeDashboardButtons();
            }
            catch (Exception ex) {
                // catch exception here
                CDialogManager.Warning(ex.Message);
            }
        }
        protected virtual void LoadComponent() {

        }
        protected virtual void InitializeToolStripButtons() {

        }
        protected virtual void InitializeMenuButtons() {

        }
        protected void ApplyTheme(Color themeColor) {
            systemNameCLabelTitle.BackColor = themeColor;
            menuCUserControlMenuModern.ApplyTheme(themeColor);
            reportCUserControlMenuModern.ApplyTheme(themeColor);
        }
        private void InitializeDashboardButtons() {
            menuCUserControlMenuModern.Initialize(NavigationMenuItems);
            reportCUserControlMenuModern.Initialize(ReportMenuItems);
        }
        private void timerMain_Tick(object sender, EventArgs e) {
            lblMainDateValue.Text = CAccessManager.CurrentDate();
            lblMainTimeValue.Text = CAccessManager.CurrentTime();
        }
        private void LoadVar() {
            userNameCLabelDesc.Text = CAppConstants.NAME;
            lblMainVersionValue.Text = CAssembly.SystemVersion;
            systemNameCLabelTitle.Text = CAssembly.SystemNameFull + " Management System";
            Text = CAssembly.SystemNameFull + " Management System";
        }
        private void LoadToolStripButtons() {
            ParentToolStripDropDown.DropDownItems.Add(new ToolStripMenuItem("Application", CAppIcons.EmojiToImage(CAppIcons.Settings), OnSettingsClick));
        }
        private async void OnSettingsClick(object sender, EventArgs e) {
            await CFormLayer.ManageSystemSettings();
        }
    }
}
