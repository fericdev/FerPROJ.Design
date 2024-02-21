using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FerPROJ.Design.Class {
    public static class CConvert {

        public static string GetDate(this DateTime dtp) {
            return dtp.ToString("yyyy-MM-dd HH:mm:ss");
        }
        public static TEnum GetEnum<TEnum>(this string text) where TEnum : Enum {
            return (TEnum)Enum.Parse(typeof(TEnum), text);
        }
    }
}
