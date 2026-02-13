using FerPROJ.Design.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerPROJ.Design.Class {
    public static class CHtmlReportManager {

        public static async Task ExportToHtmlAsync(HtmlReportModel model) {

            #region css
            if (model.ReportCss.IsNullOrEmpty()) {
                model.ReportCss = @"
                    body {
                        font-family: Arial, sans-serif;
                        margin: 20px;
                        color: #222;
                    }

                    .report-header {
                        display: flex;
                        justify-content: space-between;
                        align-items: flex-start;
                        width: 100%;
                        margin-bottom: 15px;              
                    }

                    .header-left,
                    .header-right {
                        font-size: 14px;
                        width: 48%;
                    }

                    .info-row {
                        display: grid;
                        grid-template-columns: 140px 1fr;
                        margin-bottom: 4px;
                    }

                    .label {
                        font-weight: 600;
                    }

                    .value {
                        word-break: break-word;
                    }

                    .report-paper {
                        width: 210mm;
                        min-height: 297mm;
                        margin: 20px auto;        
                        padding: 20mm;
                        box-shadow: 0 0 30px rgba(0,0,0,0.6);
                        border: 1px solid #ccc;
                        border-radius: 4px;
                        position: relative;
                        box-sizing: border-box;
                    }

                    .report-paper.landscape {
                        width: 297mm;
                        min-height: 210mm;
                    }

                    .report-paper.portrait {
                        width: 210mm;
                        min-height: 297mm;
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
                        body {
                            margin: 20mm 15mm 20mm 15mm; /* simulate bond paper margin */
                        }

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

                    }
                ";
            }
            #endregion

            #region page setup
            if (model.IsLandscape) {
                model.ReportCss += @"
                    @page {
                        size: A4 landscape;
                        margin: 15mm;
                    }";
            }
            else {
                model.ReportCss += @"
                    @page {
                        size: A4 portrait;
                        margin: 20mm;
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
                rowCells += "<tr class='table-row-summary'>" + string.Join("", model.ReportBodyRowsSummary.Select(col => $"<td>{col}</td>")) + "</tr>";
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
                                <h1><strong>{model.ReportTitle}</strong> </h1> <hr /> <br />
                                <div class='report-header'>
                                    <div class='header-left'>
                                        {reportHeaderLeft}
                                    </div>
                                    <div class='header-right'>
                                        {reportHeaderRight}
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
                            </div>
                        </body>
                    </html>";
            }
            #endregion

            #region Write to File and Open
            var filePath = CAccessManager.GetOrCreateEnvironmentPath($"{model.ReportTitle}_{DateTime.Now.ToShortTimeString()}_report.html", "Reports");

            File.WriteAllText(filePath, model.ReportHtml);

            using (var frm = new FrmHtmReport(filePath)) {
                frm.ShowDialog();
            }

            File.Delete(filePath);

            await Task.CompletedTask;
            #endregion

        }

    }

    #region model
    public class HtmlReportModel {
        public bool IsLandscape { get; set; }
        public string ReportTitle { get; set; }
        public string ReportCss { get; set; }
        public string ReportHtml { get; set; }
        public List<string> ReportBodyColumns { get; set; } = new List<string>();
        public List<List<object>> ReportBodyRows { get; set; } = new List<List<object>>();
        public List<object> ReportBodyRowsSummary { get; set; } = new List<object>();
        public List<(string Label, object Value)> ReportHeaderLeft { get; set; } = new List<(string Label, object Value)>();
        public List<(string Label, object Value)> ReportHeaderRight { get; set; } = new List<(string Label, object Value)>();
        public string GeneratedOn => $"<strong>Print Date:</strong> {DateTime.Now.ToDateAndTime()} <br />";

    }
    #endregion

}
