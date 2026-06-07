using FerPROJ.Design.Class;
using FerPROJ.Design.Forms;
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
using static FerPROJ.Design.Class.CBaseEnums;

namespace FerPROJ.Design.Controls {
    public partial class CUserControlMenuModern : UserControl {

        private readonly FlowLayoutPanel menuPanel = new FlowLayoutPanel();
        private readonly List<Button> menuButtons = new List<Button>();
        private bool collapsed = false;
        private Color themeColor = Color.DarkSlateBlue;
        private Color lightThemeColor = Color.LightSteelBlue;

        public CUserControlMenuModern() {
            InitializeComponent();
            InitializeMenuComponents();
        }
        public void SetCollapsed(bool value) {
            collapsed = value;

            foreach (var button in menuButtons) {
                if (button.Tag is MenuItemInfo item) {
                    button.Text = collapsed ? item.Icon : $"{item.Icon}  {item.Title}";
                    button.TextAlign = collapsed ? ContentAlignment.MiddleCenter : ContentAlignment.MiddleLeft;
                    button.Width = collapsed ? 54 : 244;
                }
            }
        }
        protected virtual void Initialize(List<MenuItemModel> menuItems, Color theme = default(Color), Color lightTheme = default(Color)) {
            if (theme == default(Color)) {
                theme = themeColor;
            }
            if (lightTheme == default(Color)) {
                lightTheme = lightThemeColor;
            }
            ApplyTheme();
            InitializeMenuItems(menuItems);
        }
        private void InitializeMenuItems(List<MenuItemModel> menuItems) {
            menuPanel.Controls.Clear();
            menuButtons.Clear();
            foreach (var section in menuItems) {
                if (section.IsAdminOnly && CAppConstants.USER_ROLE != Role.Administrator) {
                    continue;
                }
                AddSection(section.SectionTitle);
                foreach (var item in section.ButtonItems) {
                    AddMenu(item.Icon, item.Title, item.Action);
                }
            }
        }
        public void ApplyTheme() {
            BackColor = themeColor;
            menuPanel.BackColor = themeColor;

            foreach (var button in menuButtons) {
                button.BackColor = themeColor;
                button.ForeColor = Color.White;
            }
        }
        private void InitializeMenuComponents() {
            Dock = DockStyle.Fill;
            BackColor = themeColor;

            menuPanel.Dock = DockStyle.Fill;
            menuPanel.FlowDirection = FlowDirection.TopDown;
            menuPanel.WrapContents = false;
            menuPanel.AutoScroll = true;
            menuPanel.BackColor = themeColor;
            menuPanel.Padding = new Padding(0, 8, 0, 0);

            Controls.Add(menuPanel);
        }

        private void AddSection(string title) {
            var label = new Label {
                Text = collapsed ? "" : title.ToUpper(),
                Width = 244,
                Height = 32,
                ForeColor = Color.FromArgb(190, 235, 220),
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                TextAlign = ContentAlignment.BottomLeft,
                Padding = new Padding(8, 0, 0, 4),
                Margin = new Padding(0, 12, 0, 2)
            };

            menuPanel.Controls.Add(label);
        }

        private void AddMenu(string icon, string title, Func<Task> action) {
            var button = new Button {
                Width = collapsed ? 54 : 244,
                Height = 44,
                Text = collapsed ? icon : $"{icon}  {title}",
                TextAlign = collapsed ? ContentAlignment.MiddleCenter : ContentAlignment.MiddleLeft,
                FlatStyle = FlatStyle.Flat,
                BackColor = themeColor,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F, FontStyle.Regular),
                Cursor = Cursors.Hand,
                Margin = new Padding(0, 3, 0, 3),
                Padding = new Padding(12, 0, 0, 0),
                Tag = new MenuItemInfo {
                    Icon = icon,
                    Title = title,
                    Action = action
                }
            };

            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseOverBackColor = lightThemeColor;
            button.FlatAppearance.MouseDownBackColor = lightThemeColor;

            button.Click += async (s, e) => {
                SetActiveButton(button);

                if (action != null) {
                    await action();
                }
            };

            menuButtons.Add(button);
            menuPanel.Controls.Add(button);
        }

        private void SetActiveButton(Button selectedButton) {
            foreach (var button in menuButtons) {
                button.BackColor = Color.DarkGreen;
                button.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            }

            selectedButton.BackColor = Color.LightSeaGreen;
            selectedButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        }
    }
    public class MenuItemInfo {
        public string Icon { get; set; }
        public string Title { get; set; }
        public Func<Task> Action { get; set; }
    }

    public class MenuItemModel {
        public string SectionTitle { get; set; }
        public bool IsAdminOnly { get; set; } = false;
        public List<MenuItemInfo> ButtonItems { get; set; }
    }
}
