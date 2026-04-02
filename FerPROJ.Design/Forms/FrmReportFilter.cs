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
    public partial class FrmReportFilter : FrmManageKrypton {
        public DateTime DateFrom = DateTime.Now;
        public DateTime DateTo = DateTime.Now;
        public FrmReportFilter() {
            InitializeComponent();
        }
        protected override async Task<bool> OnSaveDataAsync() {
            DateFrom = cDateTimePickerKryptonDateFrom.Value;
            DateTo = cDateTimePickerKryptonDateTo.Value;
            return true;
        }
    }
}
