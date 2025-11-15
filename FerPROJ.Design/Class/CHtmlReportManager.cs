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
            if (model.ReportCss.IsNullOrEmpty()) {
                model.ReportCss = @"
                    body { 
                        font-family: Arial; 
                        padding: 20px; 
                    }
                    h1 { 
                        color: #333; 
                    }
                    table { 
                        width: 100%; 
                        border-collapse: collapse; 
                        margin-top: 20px; 
                    }
                    th, td { 
                        border: 1px solid #ccc; 
                        padding: 8px; 
                        text-align: left; 
                    }
                    th { 
                        background: #f5f5f5; 
                    }
                ";
            }

            if (model.ReportBody.IsNullOrEmpty()) {
                model.ReportBody = $@"
                    <h1>{model.ReportTitle}</h1>
                    <p>Generated on: {model.GeneratedOn}</p>
                    <p>No report content available.</p>";
            }

            if (model.ReportHtml.IsNullOrEmpty()) {
                model.ReportHtml = $@"
                    <html>
                    <head>
                        <title>{model.ReportTitle}</title>
                        <style>{model.ReportCss}</style>
                    </head>
                    <body>
                        {model.ReportBody}
                    </body>
                    </html>";
            }

            var filePath = CAccessManager.GetOrCreateEnvironmentPath($"{model.ReportTitle}_{DateTime.Now}_report.html", "Reports");

            File.WriteAllText(filePath, model.ReportHtml);

            Process.Start(new ProcessStartInfo() {
                FileName = filePath,
                UseShellExecute = true
            });

            await Task.CompletedTask;
        }

    }
    public class HtmlReportModel {
        public string ReportTitle { get; set; }
        public DateTime GeneratedOn { get; set; }
        public string ReportCss { get; set; }
        public string ReportHtml { get; set; }
        public string ReportBody { get; set; }
        
    }
}
