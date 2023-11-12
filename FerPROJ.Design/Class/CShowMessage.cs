using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FerPROJ.Design.Class
{
    public static class CShowMessage
    {
        public static bool Ask(string message, string caption)
        {
            if(MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                return true;
            }
            return false;
        }
        public static void Warning(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static void Info(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void Create(string message, string caption, MessageBoxIcon msgIcon)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, msgIcon);
        }
    }
}
