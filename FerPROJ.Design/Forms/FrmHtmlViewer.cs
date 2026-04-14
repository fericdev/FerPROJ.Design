using FerPROJ.Design.Class;
using FerPROJ.Design.Controls;
using Microsoft.Web.WebView2.WinForms;
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
    public partial class FrmHtmlViewer : FrmKrypton {
        private readonly WebView2 _webView;
        private readonly HtmlReportModel _model;
        public FrmHtmlViewer(string reportFilePath, HtmlReportModel model) {
            InitializeComponent();

            // Set basic form properties
            this.Text = "Report Viewer";
            this.Width = 800;
            this.Height = 600;
            this.ShowInTaskbar = true;

            // Create WebView2 instance
            _webView = new WebView2 {
                Dock = DockStyle.Fill // Fill the entire form
            };
            _model = model;

            var btnExportExcel = new Button {
                Text = "Export to Excel",
                Height = 35,
                Dock = DockStyle.Top
            };

            btnExportExcel.Click += BtnExportExcel_Click;

            // Add WebView2 to the form
            this.baseKryptonPanel.Controls.Add(_webView);
            this.baseKryptonPanel.Controls.Add(btnExportExcel);
            this.baseKryptonPanel.Controls.SetChildIndex(btnExportExcel, 0);

            // Initialize and load HTML
            InitializeAsync(reportFilePath);
        }

        private async void InitializeAsync(string htmlFilePath) {
            // Initialize WebView2 environment
            await _webView.EnsureCoreWebView2Async(null);

            // Load the HTML file
            _webView.CoreWebView2.Navigate(htmlFilePath);
        }
        private void BtnExportExcel_Click(object sender, EventArgs e) {
            CHtmlReportManager.ExportReportToExcel(_model.ReportBodyColumns, _model.ReportBodyRows, _model.ReportBodyRowsSummary, $"{_model.ReportTitle.ToStringNormalize()}_{DateTime.Now.ToString("dd_hh_mm_ss")}");
        }
    }
}
