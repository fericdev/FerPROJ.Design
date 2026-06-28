using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerPROJ.Design.Class {
    public static class CAppIcons {
        public const string Dashboard = "🏠";
        public const string User = "👤";
        public const string Users = "👥";
        public const string Settings = "⚙️";
        public const string Reports = "📊";
        public const string Analytics = "📈";
        public const string Sales = "💰";
        public const string Inventory = "📦";
        public const string Product = "🏷️";
        public const string Customer = "🤝";
        public const string Employee = "🧑‍💼";
        public const string Payroll = "💵";
        public const string Attendance = "🕒";
        public const string Calendar = "📅";
        public const string Department = "🏢";
        public const string Course = "📚";
        public const string Student = "🎓";
        public const string Teacher = "👨‍🏫";
        public const string Grade = "📝";
        public const string Message = "💬";
        public const string Notification = "🔔";
        public const string Search = "🔍";
        public const string Add = "➕";
        public const string Edit = "✏️";
        public const string Delete = "🗑️";
        public const string Save = "💾";
        public const string Print = "🖨️";
        public const string Upload = "⬆️";
        public const string Download = "⬇️";
        public const string Refresh = "🔄";
        public const string Lock = "🔒";
        public const string Unlock = "🔓";
        public const string Login = "🔑";
        public const string Logout = "🚪";
        public const string Home = "🏡";
        public const string Folder = "📁";
        public const string File = "📄";
        public const string Database = "🗄️";
        public const string Server = "🖥️";
        public const string Network = "🌐";
        public const string Help = "❓";
        public const string Info = "ℹ️";
        public const string Warning = "⚠️";
        public const string Success = "✅";
        public const string Error = "❌";
        public const string ShippingBox = "📦";

        public const string MoveArrowRight = "➡️";
        public const string MoveArrowLeft = "⬅️";


        // --- Added New General Icons Below ---
        public const string Report = "📋";
        public const string PriceTag = "🏷️";
        public const string CalendarDaily = "☀️";
        public const string CalendarMonthly = "🗓️";
        public const string Tools = "🛠️";
        public const string MoneyBag = "💰";
        public const string CashFlow = "💸";




        //
        public static Image EmojiToImage(string emoji, Color color = default, Font font = null) {

            if (font == null) {
                font = new Font("Segoe UI Emoji", 16);
            }

            if (color == default) {
                color = Color.White;
            }

            Bitmap bmp = new Bitmap(32, 32);
            using (Graphics g = Graphics.FromImage(bmp)) {
                g.Clear(Color.Transparent);
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                using (Brush brush = new SolidBrush(color)) {
                    g.DrawString(emoji, font, brush, new PointF(0, 0));
                }
            }
            return bmp;
        }
    }
}
