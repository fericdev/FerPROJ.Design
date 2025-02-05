using CrystalDecisions.CrystalReports.Engine;
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
    public partial class FrmReport : Form {
        public FrmReport() {
            InitializeComponent();
        }
        public async Task SetDataSource(ReportDocument rpt) {
            crystalReportViewer1.ReportSource = rpt;
            await Task.CompletedTask;
        }
    }
}
