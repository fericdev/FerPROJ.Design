using CrystalDecisions.CrystalReports.Engine;
using FerPROJ.Design.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerPROJ.Design.Class {
    public static class CBaseReportLayer {
        public static async Task GenerateReport(ReportDocument rpt) {
            var frm = new FrmReport();
            frm.Text = "Preview Report";
            await frm.SetDataSource(rpt);
            frm.Show();
        }
        public static void PrintToPrinter(ReportDocument rpt) {
            rpt.PrintToPrinter(1, false, 0, 0);
        }
    }
}
