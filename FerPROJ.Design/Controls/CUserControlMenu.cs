using FerPROJ.Design.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FerPROJ.Design.Controls {
    public partial class CUserControlMenu : UserControl {
        protected Timer baseTimer = new Timer { Interval = 10 };
        protected FlowLayoutPanel basePanel = new FlowLayoutPanel();
        protected List<BaseMenuButtonModel> baseMenuButtonModels = new List<BaseMenuButtonModel>();
        protected int basePanelTargetHeight;
        protected int baseStep;
        public CUserControlMenu() {
            InitializeComponent();
            InitializeSideMenu();
            LoadSideMenu();
            baseTimer.Tick += Timer_Tick;
        }
        /// <summary>
        /// Initializes the side menu with menu buttons and their corresponding submenus.
        /// This method is intended to be overridden in derived classes to define
        /// the specific menu structure.
        /// </summary>
        protected virtual void InitializeSideMenu() {

        }

        #region Logic
        private void LoadSideMenu() {
            foreach (var menu in baseMenuButtonModels) {
                AddMenuSection(menu);
            }
        }
        private void Timer_Tick(object sender, EventArgs e) {
            int currentHeight = basePanel.Height;
            if ((baseStep > 0 && currentHeight >= basePanelTargetHeight) || (baseStep < 0 && currentHeight <= basePanelTargetHeight)) {
                baseTimer.Stop();
                basePanel.Height = basePanelTargetHeight;
            }
            else {
                basePanel.Height += baseStep;
            }
        }
        private void ChangeHeight(FlowLayoutPanel panel, int buttonCount = 3) {
            int currentHeight = panel.Height;
            var backColor = panel.BackColor;
            if (currentHeight == 54) {
                basePanelTargetHeight = 54 * buttonCount;
                baseStep = 5;
            }
            else {
                basePanelTargetHeight = 54;
                baseStep = -5;
            }
            basePanel = panel;
            baseTimer.Start();
        }
        protected void AddMenuSection(BaseMenuButtonModel menu) {
            // Parent panel (group)
            var groupPanel = new FlowLayoutPanel {
                Name = $"{menu.Title.Replace(" ", "")}GroupPanel",
                Width = 269,
                Height = 54,
                BorderStyle = BorderStyle.None,
                AutoSize = false,
                AutoSizeMode = AutoSizeMode.GrowOnly,
                FlowDirection = FlowDirection.TopDown,
            };
            // Main button panel
            var mainMenuButtonPanel = new Panel {
                Name = $"{menu.Title.Replace(" ", "")}MainButtonPanel",
                Dock = DockStyle.None,
                AutoSize = false,
                AutoSizeMode = AutoSizeMode.GrowOnly,
                Height = 44,
                Width = 260,
                BackColor = menu.ButtonColor,
                BorderStyle = BorderStyle.FixedSingle,
            };
            // Main button
            var mainMenuButton = new CButton {
                Name = $"{menu.Title.Replace(" ", "")}MainButton",
                Text = menu.Title,
                Font = new Font("Verdana", 16, FontStyle.Bold),
                Dock = DockStyle.Fill,
                Height = 44,
                Width = 260,
                TextAlign = ContentAlignment.MiddleLeft,
                BackColor = menu.ButtonColor,
                ForeColor = menu.ForeColor,
                Cursor = Cursors.Hand,
                BorderRadius = 1,
            };
            // Add main button to its panel
            mainMenuButtonPanel.Controls.Add(mainMenuButton);
            // Add main button panel to group panel
            groupPanel.Controls.Add(mainMenuButtonPanel);
            // Submenu buttons
            if (menu.SubMenus != null && menu.SubMenus.Count > 0) {
                // Iterate through each submenu and create buttons
                foreach (var sub in menu.SubMenus) {
                    // Submenu button panel
                    var submenuButtonPanel = new Panel {
                        Name = $"{sub.Title.Replace(" ", "")}SubmenuButtonPanel",
                        Dock = DockStyle.None,
                        AutoSize = false,
                        AutoSizeMode = AutoSizeMode.GrowOnly,
                        Height = 44,
                        Width = 238,
                        BackColor = sub.ButtonColor,
                        BorderStyle = BorderStyle.FixedSingle,
                    };
                    // Submenu button
                    var submenuButton = new CButton {
                        Name = $"{sub.Title.Replace(" ", "")}SubmenuButton",
                        Text = sub.Title,
                        Font = new Font("Verdana", 14, FontStyle.Bold),
                        Dock = DockStyle.Fill,
                        Height = 44,
                        Width = 238,
                        TextAlign = ContentAlignment.MiddleLeft,
                        BackColor = sub.ButtonColor,
                        ForeColor = sub.ForeColor,
                        Cursor = Cursors.Hand,
                        BorderRadius = 1,
                    };
                    // Add submenu button to its panel
                    submenuButtonPanel.Controls.Add(submenuButton);
                    // Assign ClickActionAsync if provided
                    if (sub.ClickActionAsync != null) {
                        // You need to create a new method that wraps the Action
                        // to avoid issues with event handlers.
                        submenuButton.Click += async (sender, e) => await sub.ClickActionAsync();
                    }
                    // Add submenu button panel to group panel
                    groupPanel.Controls.Add(submenuButtonPanel);
                }
            }
            // Add the complete group panel to the main flow layout panel
            baseFlowLayoutPanel.Controls.Add(groupPanel);
            // Configure main button click event
            mainMenuButton.Tag = new MenuButtonTag { GroupPanel = groupPanel, SubMenuCount = menu.SubMenus.Count + 1 };
            // Assign ClickActionAsync if provided
            if (menu.ClickActionAsync != null) {
                mainMenuButton.Click += async (sender, e) => await menu.ClickActionAsync();
            }
            // Only add the toggle functionality if there are submenus
            if (menu.SubMenus.Count > 0) {
                mainMenuButton.Click += mainButtonClicked;
            }
        }

        private void mainButtonClicked(object sender, EventArgs e) {
            if (sender is Button btn && btn.Tag is MenuButtonTag info) {
                ChangeHeight(info.GroupPanel, info.SubMenuCount);
            }
        }
        #endregion

    }
}
