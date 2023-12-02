using CrystalDecisions.CrystalReports.Engine;
using FerPROJ.Design.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerPROJ.Design.Class {
    public static class CReport {
        public static void GenerateReport(ReportDocument rpt) {
            FrmSplasherReport.ShowSplash();
            var frm = new FrmReport();
            FrmSplasherReport.CloseSplash();
            frm.Text = "Preview Report";
            frm.SetDataSource(rpt);
            frm.Show();
        }
        public static void PrintToPrinter(ReportDocument rpt) {
            rpt.PrintToPrinter(1, false, 0, 0);
        }
    }
}
