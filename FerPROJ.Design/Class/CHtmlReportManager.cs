using FerPROJ.Design.FormModels;
using FerPROJ.Design.Forms;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FerPROJ.Design.Class {
    public static class CHtmlReportManager {

        public static async Task ExportToHtmlAsync(HtmlReportModel model) {

            #region css
            if (model.ReportCss.IsNullOrEmpty()) {
                model.ReportCss = @"
                    body {
                        font-family: Arial, sans-serif;
                        margin: 0.5in;
                        color: #222;
                    }

                    .report-header {
                        display: flex;
                        justify-content: space-between;
                        align-items: flex-start;
                        width: 100%;
                        margin-bottom: 15px;              
                    }
                    .report-footer {
                        display: flex;
                        justify-content: space-between;
                        width: 100%;
                        margin-top: 15px;              
                    }

                    .report-header .header-left,
                    .report-header .header-right {
                        font-size: 14px;
                        width: 48%;
                    }

                    .report-footer .footer-left, {
                        font-size: 14px;
                        width: 48%;
                        align-items: flex-start;
                    }
                    .report-footer .footer-right {
                        font-size: 14px;
                        align-items: flex-end;
                        margin-right: 40px;
                    }

                    .report-title-container {
                        display: flex;
                        align-items: center; 
                        gap: 20px;
                        margin-bottom: 20px;
                    }

                    .company-info {
                        display: flex;
                        flex-direction: column;
                        justify-content: center;
                    }

                    .company-info h1 {
                        margin: 0;
                        font-size: 24px;
                        line-height: 1.2;
                    }

                    .company-details {
                        font-size: 13px;
                        color: #555;
                        margin-top: 5px;
                        line-height: 1.4;
                    }

                    .report-logo {
                        width: 120px; 
                        height: 120px;
                        object-fit: contain;
                    }

                    .info-container {
                        display: grid;
                        grid-template-columns: max-content 1fr;
                        column-gap: 12px;
                        row-gap: 4px;
                    }
                    .info-row {
                        display: contents;
                    }

                    .label {
                        font-weight: 600;
                    }

                    .value {
                        word-break: break-word;
                    }

                    .report-paper {
                        width: 8.5in;
                        min-height: 11.5in;
                        margin: 0.2in auto;        
                        padding: 0.2in;
                        box-shadow: 0 0 30px rgba(0,0,0,0.6);
                        border: 1px solid #ccc;
                        border-radius: 4px;
                        position: relative;
                        box-sizing: border-box;
                    }

                    .report-paper.landscape {
                        width: 16in;                  
                        min-height: 8.5in;
                    }

                    .report-paper.portrait {
                        width: 8.5in;
                        min-height: 11in;
                    }

                    hr {
                        border: 0;
                        height: 1px;
                        background: #444;
                        margin: 15px 0;
                    }

                    h1, h2, h3 {
                        margin-bottom: 10px;
                        color: #333;
                    }

                    table {
                        width: 100%;
                        border-collapse: collapse;
                        margin-top: 20px;
                        font-size: 14px;
                    }

                    .table-header {
                        background: #1E3A8A;
                        font-weight: bold;
                        color: white;
                    }

                    .table-row {
                        font-weight: normal;
                    }

                    .table-row-summary {
                        font-weight: bold;
                    }

                    th, td {
                        border: 1px solid #444;
                        padding: 8px 10px;
                        text-align: left;
                    }

                    th {
                        background: #eaeaea;
                        font-weight: bold;
                    }

                    /* Zebra stripes */
                    tr:nth-child(even) {
                        background: #f8f8f8;
                    }

                    /* Improve look when printed */
                    @media print {
                        table {
                            page-break-inside: avoid;
                        }

                        tr {
                            page-break-inside: avoid;
                            page-break-after: auto;
                        }

                        body {
                            background: white !important;
                        }

                        .report-paper {
                            box-shadow: none !important;
                            margin: 0;
                            border: none;
                            border-radius: 0;
                            width: auto;
                            min-height: auto;
                        }
                        * {
                            -webkit-print-color-adjust: exact !important;
                            print-color-adjust: exact !important;
                        }

                    }
                ";
            }
            #endregion

            #region page setup
            if (model.IsLandscape) {
                model.ReportCss += @"
                    @page {
                        size: A4 landscape;
                        margin: 0.2in;
                    }";
            }
            else {
                model.ReportCss += @"
                    @page {
                        size: A4 portrait;
                        margin: 0.2in;
                    }";
            }
            #endregion

            #region report cells
            var headerCells = string.Empty;
            var rowCells = string.Empty;
            if (model.ReportBodyColumns.Count > 0) {
                headerCells = string.Join("",
                    model.ReportBodyColumns.Select(c =>
                        $"<th class='table-header'>{c}</th>"
                    )
                );
            }
            if (model.ReportBodyRows.Count > 0) {
                rowCells = string.Join("",
                    model.ReportBodyRows.Select(row =>
                        "<tr class='table-row'>" + string.Join("", row.Select(col => $"<td>{col}</td>")) + "</tr>"
                    )
                );
            }
            if (model.ReportBodyRowsSummary.Count > 0) {
                rowCells += string.Join("",
                    model.ReportBodyRowsSummary.Select(row =>
                        "<tr class='table-row-summary'>" + string.Join("", row.Select(col => $"<td>{col}</td>")) + "</tr>"
                        )
                    );
            }
            #endregion

            #region report header
            var reportHeaderLeft = new StringBuilder();
            foreach (var item in model.ReportHeaderLeft) {
                reportHeaderLeft.AppendLine(
                    $"<div class='info-row'>" +
                    $"   <span class='label'>{item.Label}:</span>" +
                    $"   <span class='value'>{item.Value}</span>" +
                    $"</div>"
                );
            }

            var reportHeaderRight = new StringBuilder();
            foreach (var item in model.ReportHeaderRight) {
                reportHeaderRight.AppendLine(
                    $"<div class='info-row'>" +
                    $"   <span class='label'>{item.Label}:</span>" +
                    $"   <span class='value'>{item.Value}</span>" +
                    $"</div>"
                );
            }
            var reportFooterLeft = new StringBuilder();
            foreach (var item in model.ReportFooterLeft) {
                reportFooterLeft.AppendLine(
                    $"<div class='info-row'>" +
                    $"   <span class='label'>{item.Label}:</span>" +
                    $"   <span class='value'>{item.Value}</span>" +
                    $"</div>"
                );
            }
            var reportFooterRight = new StringBuilder();
            foreach (var item in model.ReportFooterRight) {
                reportFooterRight.AppendLine(
                    $"<div class='info-row'>" +
                    $"   <span class='label'>{item.Label}:</span>" +
                    $"   <span class='value'>{item.Value}</span>" +
                    $"</div>"
                );
            }
            #endregion

            #region Html Template
            if (model.ReportHtml.IsNullOrEmpty()) {
                model.ReportHtml = $@"
                    <html>
                        <head>
                            <title>{model.ReportTitle}</title>
                            <style>{model.ReportCss}</style>
                        </head>
                        <body>
                            <div class='report-paper {(model.IsLandscape ? "landscape" : "portrait")}'>
                                <div class='report-title-container'>
                                    <img src='{model.Company.CompanyLogoUrl}' class='report-logo' />
                                    <div class='company-info'>
                                        <h1><strong>{model.ReportTitle}</strong></h1>
                                        <div class='company-details'>
                                            <div>Contact: {model.Company.CompanyContactNo}</div>
                                            <div>Email: {model.Company.CompanyEmail}</div>
                                            <div>Address: {model.Company.CompanyAddress}</div>
                                        </div>
                                    </div>
                                </div>
                                <div class='report-header'>
                                    <div class='header-left'>
                                        <div class='info-container'>
                                            {reportHeaderLeft}
                                        </div>
                                    </div>
                                    <div class='header-right'>
                                        <div class='info-container'>
                                            {reportHeaderRight}
                                        </div>
                                    </div>
                                </div>
                                <div class ='report-body'>
                                    <table>
                                        <thead>
                                            {headerCells}
                                        </thead>
                                        <tbody>
                                            {rowCells}
                                        </tbody>       
                                    </table>
                                </div>
                                <div class='report-footer'>
                                    <div class='footer-left'>
                                        <div class='info-container'>
                                            {reportFooterLeft}
                                        </div>
                                    </div>
                                    <div class='footer-right'>
                                        <div class='info-container'>
                                            {reportFooterRight}
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </body>
                    </html>";
            }
            #endregion

            #region Write to File and Open
            var filePath = CAccessManager.GetOrCreateEnvironmentPath($"{model.ReportTitle}_{DateTime.Now.ToShortTimeString()}_report.html", "Reports");

            File.WriteAllText(filePath, model.ReportHtml);

            FrmHtmlViewer.ShowReport(filePath, model);

            await Task.CompletedTask;
            #endregion

        }
        public static void ExportReportToExcel(HtmlReportModel model) {

            #region Content 
            //
            var columns = model.ReportBodyColumns;
            var rows = model.ReportBodyRows;
            var summary = model.ReportBodyRowsSummary;
            var fileName = $"{model.ReportTitle.ToStringNormalize()}_{DateTime.Now.ToString("ddd_MMM_dd")}_{DateTime.Now.ToString("hh_mm_tt")}";
            //
            ExcelPackage.License.SetNonCommercialPersonal("FericDev");
            using (var pack = new ExcelPackage()) {
                var worksheet = pack.Workbook.Worksheets.Add("Report");

                int rowIndex = 1;
                int colCount = columns.Count;

                // =========================
                // HEADER
                // =========================
                for (int col = 0; col < colCount; col++) {
                    worksheet.Cells[rowIndex, col + 1].Value = columns[col];
                }

                using (var range = worksheet.Cells[rowIndex, 1, rowIndex, colCount]) {
                    range.Style.Font.Bold = true;
                }

                rowIndex++;

                // =========================
                // BODY
                // =========================
                foreach (var row in rows) {
                    for (int col = 0; col < row.Count; col++) {
                        SetExcelCellValue(worksheet.Cells[rowIndex, col + 1], row[col]);
                    }

                    rowIndex++;
                }

                // =========================
                // SUMMARY
                // =========================
                if (summary != null && summary.Any()) {
                    rowIndex++; // space before summary

                    foreach (var sumRow in summary) {
                        for (int col = 0; col < sumRow.Count; col++) {
                            SetExcelCellValue(worksheet.Cells[rowIndex, col + 1], sumRow[col]);
                        }

                        using (var range = worksheet.Cells[rowIndex, 1, rowIndex, colCount]) {
                            range.Style.Font.Bold = true;
                        }

                        rowIndex++;
                    }
                }

                // =========================
                // FINAL FORMATTING
                // =========================
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
                worksheet.View.FreezePanes(2, 1);

                // =========================
                // SAVE FILE
                // =========================
                using (SaveFileDialog saveFileDialog = new SaveFileDialog()) {
                    saveFileDialog.Filter = "Excel Files|*.xlsx";
                    saveFileDialog.Title = "Save Excel File";
                    saveFileDialog.FileName = fileName;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                        using (var fs = new FileStream(saveFileDialog.FileName, FileMode.Create)) {
                            pack.SaveAs(fs);
                        }

                        if (CDialogManager.Ask("Data Exported Successfully.\nDo you want to open the file?", "Confirmation")) {
                            Process.Start(saveFileDialog.FileName);
                        }
                    }
                }
            }
            #endregion

            #region Utilities
            void SetExcelCellValue(ExcelRange cell, object value) {
                var text = value?.ToString();

                if (decimal.TryParse(
                        text?.Replace("₱", "")
                             .Replace("PHP", "")
                             .Replace("P", "")
                             .Replace(",", "")
                             .Trim(),
                        out decimal num)) {
                    cell.Value = num;
                    cell.Style.Numberformat.Format = "#,##0.00";
                }
                else {
                    cell.Value = value;
                }
            }
            #endregion

        }

    }

    #region model
    public class HtmlReportModel {
        public bool IsLandscape { get; set; }
        public string ReportTitle { get; set; }
        public string ReportCss { get; set; }
        public string ReportHtml { get; set; }
        public CompanyModel Company { get; set; } = new CompanyModel();
        public List<string> ReportBodyColumns { get; set; } = new List<string>();
        public List<List<object>> ReportBodyRows { get; set; } = new List<List<object>>();
        public List<List<object>> ReportBodyRowsSummary { get; set; } = new List<List<object>>();
        public List<(string Label, object Value)> ReportHeaderLeft { get; set; } = new List<(string Label, object Value)>();
        public List<(string Label, object Value)> ReportHeaderRight { get; set; } = new List<(string Label, object Value)>();
        public List<(string Label, object Value)> ReportFooterRight { get; set; } = new List<(string Label, object Value)>();
        public List<(string Label, object Value)> ReportFooterLeft { get; set; } = new List<(string Label, object Value)>();
        public string GeneratedOn => $"<strong>Print Date:</strong> {DateTime.Now.ToDateAndTime()} <br />";

    }
    #endregion

}
