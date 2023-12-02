using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FerPROJ.Design.Class
{
    public static class CExtension
    {
        public static void FillComboBoxEnum<TEnum>(this ComboBox cmb) where TEnum : Enum {
            if (!typeof(TEnum).IsEnum) {
                throw new ArgumentException("TEnum must be an enumeration type.");
            }
            //
            var enumValues = Enum.GetValues(typeof(TEnum)).Cast<TEnum>().ToList();
            cmb.DataSource = new BindingList<TEnum>(enumValues);
        }
        public static void FillComboBox(this ComboBox cmb, string cmbText, string cmbValue, IEnumerable<object> dataSource) {
            cmb.DisplayMember = cmbText;
            cmb.ValueMember = cmbValue;
            cmb.DataSource = dataSource.ToList();
        }
    }
}
