using FerPROJ.Design.BaseModels;
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
    public partial class FrmContextMenu : Form {
        private List<BaseMenuButtonModel> baseMenuButtonModels;
        private static FrmContextMenu frmInstance;
        public FrmContextMenu() {
            InitializeComponent();
        }
        private async void FrmContextMenu_Load(object sender, EventArgs e) {
            if (baseMenuButtonModels != null && baseMenuButtonModels.Count > 0) {
                await LoadButtonsAsync();
            }
        }
        private void RefreshLayout() {
            this.Height = baseMenuButtonModels.Count * 40 + 42;
        }
        private async Task LoadButtonsAsync() {
            flowLayoutPanelContextMenu.Controls.Clear();
            //
            foreach (var menu in baseMenuButtonModels) {
                AddButtonSection(menu);
            }
            //
            RefreshLayout();
            await Task.CompletedTask;
        }
        private void AddButtonSection(BaseMenuButtonModel menu) {
            var mainMenuButtonPanel = new Panel {
                Name = $"{menu.Title.Replace(" ", "")}MainButtonPanel",
                Dock = DockStyle.None,
                AutoSize = false,
                AutoSizeMode = AutoSizeMode.GrowOnly,
                Height = 30,
                Width = flowLayoutPanelContextMenu.Width - 10,
                BackColor = Color.LightGray,
                Margin = new Padding(3),
            };
            var mainButton = new CButton {
                Name = $"{menu.Title.Replace(" ", "")}MainButton",
                Text = menu.Title,
                Font = new Font("Verdana", 12, FontStyle.Bold),
                Dock = DockStyle.Fill,
                Height = 25,
                Width = flowLayoutPanelContextMenu.Width - 10,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = menu.ButtonColor,
                ForeColor = menu.ForeColor,
                Cursor = Cursors.Hand,
                Margin = new Padding(3),
                BorderRadius = 5,
            };
            // Add main button to its panel
            mainMenuButtonPanel.Controls.Add(mainButton);
            flowLayoutPanelContextMenu.Controls.Add(mainMenuButtonPanel);

            if (menu.ClickActionAsync != null) {
                mainButton.Click += async (sender, e) => {
                    CloseInstance();
                    await menu.ClickActionAsync();
                };
            }
        }
        public static async Task ShowContextMenuAsync(List<BaseMenuButtonModel> baseMenus) {
            if (frmInstance == null) {
                frmInstance = new FrmContextMenu();
                frmInstance.baseMenuButtonModels = baseMenus;
                frmInstance.StartPosition = FormStartPosition.Manual;
                frmInstance.Location = Cursor.Position;

                // Don’t call LoadButtonsAsync() here!
                frmInstance.ShowDialog();
                frmInstance = null;
            }

            await Task.CompletedTask;
        }
        private void FrmContextMenu_FormClosed(object sender, FormClosedEventArgs e) {
            CloseInstance();
        }

        private static void CloseInstance() {
            if (frmInstance != null) {
                frmInstance.Invoke((Action)(() => {
                    frmInstance.Close();
                    frmInstance.Dispose();
                    frmInstance = null;
                }));
            }
        }
    }
}
