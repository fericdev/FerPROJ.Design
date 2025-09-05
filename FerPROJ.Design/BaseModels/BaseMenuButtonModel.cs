using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FerPROJ.Design.BaseModels {
    public class BaseMenuButtonModel {
        public string Title { get; set; }
        public List<BaseMenuButtonModel> SubMenus { get; set; } = new List<BaseMenuButtonModel>();
        public Func<Task> ClickActionAsync { get; set; }
        public Color ButtonColor { get; set; } = Color.WhiteSmoke;
        public Color ForeColor { get; set; } = Color.Black;
    }
    public class MenuButtonTag {
        public FlowLayoutPanel GroupPanel { get; set; }
        public int SubMenuCount { get; set; }
    }
}
