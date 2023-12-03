using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FerPROJ.Design.Class {
    public static class CConvert {

        public static string GetDate(DateTime dtp) {
            return dtp.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
