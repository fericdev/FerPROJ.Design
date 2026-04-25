using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FerPROJ.Design.Controls {
    public class CTabControl : TabControl {
        public CTabControl() {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);
            SizeMode = TabSizeMode.Fixed;
            ItemSize = new Size(44, 136);
            Alignment = TabAlignment.Left;
            SelectedIndex = 0;
        }

        public void Initialize(TabAlignment tabAlignment) {        
            switch (tabAlignment) {
                case TabAlignment.Top:
                    ItemSize = new Size(136, 44);
                    Alignment = TabAlignment.Top;
                    break;

                default:
                case TabAlignment.Left:
                    ItemSize = new Size(44, 136);
                    Alignment = TabAlignment.Left;
                    break;
            }
            Refresh();
        }

        #region Paint

        protected override void OnPaint(PaintEventArgs e) {
            using (Bitmap b = new Bitmap(Width, Height))
            using (Graphics g = Graphics.FromImage(b)) {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.Clear(Color.White); // Modern dashboards usually use a clean white background

                bool isLeft = Alignment == TabAlignment.Left;
                Color accentColor = Color.FromArgb(0, 120, 215); // A nice professional blue
                Color borderColor = Color.FromArgb(220, 220, 220); // Softer border

                // ===== Header Background & Border =====
                if (isLeft) {
                    g.DrawLine(new Pen(borderColor), ItemSize.Height + 1, 0, ItemSize.Height + 1, Height);
                }
                else {
                    g.DrawLine(new Pen(borderColor), 0, ItemSize.Height + 1, Width, ItemSize.Height + 1);
                }

                // ===== Draw Tabs =====
                for (int i = 0; i < TabCount; i++) {
                    Rectangle tabRect = GetTabRect(i);
                    bool isSelected = (i == SelectedIndex);

                    // Draw Tab Content
                    DrawTabTextAndImage(g, tabRect, i, isSelected);

                    if (isSelected) {
                        // Draw the "Elegant" Indicator Bar
                        using (SolidBrush accentBrush = new SolidBrush(accentColor)) {
                            if (isLeft) {
                                // Vertical bar on the left
                                g.FillRectangle(accentBrush, new Rectangle(0, tabRect.Y + 4, 3, tabRect.Height - 8));
                            }
                            else {
                                // Horizontal bar at the bottom
                                g.FillRectangle(accentBrush, new Rectangle(tabRect.X + 10, tabRect.Bottom - 2, tabRect.Width - 20, 3));
                            }
                        }
                    }
                }

                e.Graphics.DrawImage(b, 0, 0);
            }
        }

        private void DrawTabTextAndImage(Graphics g, Rectangle rect, int index, bool selected) {
            // 1. Force High Quality Text Rendering
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            // 2. Use Tahoma to match your header
            // We use 9pt or 9.5pt Tahoma for that professional "clean" look
            float fontSize = 12f;
            Color textColor = selected ? Color.FromArgb(33, 33, 33) : Color.FromArgb(120, 120, 120);

            using (Font textFont = new Font("Tahoma", fontSize, selected ? FontStyle.Bold : FontStyle.Regular))
            using (SolidBrush textBrush = new SolidBrush(textColor)) {
                StringFormat sf = new StringFormat {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                // Shift the text rect slightly to ensure it's not cutting off
                Rectangle textRect = rect;
                if (Alignment == TabAlignment.Top) textRect.Y -= 1;

                g.DrawString(TabPages[index].Text, textFont, textBrush, textRect, sf);
            }
        }

        #endregion
    }
    public static class CTabControlExtensions {
        public static void TrackIndexChangedAndCallMethod(this TabPage tabPage, Func<Task> action) {
            if (tabPage == null)
                throw new ArgumentNullException(nameof(tabPage));

            if (action == null)
                throw new ArgumentNullException(nameof(action));

            var tabControl = tabPage.Parent as CTabControl;

            if (tabControl == null)
                throw new InvalidOperationException("TabPage must be added to a TabControl before calling this.");

            tabControl.SelectedIndexChanged += async (s, e) => {
                if (tabControl.SelectedTab == tabPage) {
                    await action();
                }
            };
        }
    }
}

