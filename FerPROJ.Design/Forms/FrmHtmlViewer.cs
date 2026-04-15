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

            // Create WebView2 instance
            _webView = new WebView2 {
                Dock = DockStyle.Fill // Fill the entire form
            };

            // Model
            _model = model;

            // Set basic form properties
            this.Text = "Report Viewer";
            this.Width = 800;
            this.Height = 600;
            this.ShowInTaskbar = true;

            // Initialize components
            Initialize();

            // Initialize and load HTML
            InitializeAsync(reportFilePath);
        }

        private async void InitializeAsync(string htmlFilePath) {
            // Initialize WebView2 environment
            await _webView.EnsureCoreWebView2Async(null);

            // Load the HTML file
            _webView.CoreWebView2.Navigate(htmlFilePath);
        }

        private void Initialize() {
            var toolStrip = new ToolStrip {
                Dock = DockStyle.Top,
                GripStyle = ToolStripGripStyle.Hidden,
                GripMargin = new Padding(2, 2, 2, 2),
            };

            // Create dropdown button
            var exportDropDown = new ToolStripDropDownButton("Export Options", Properties.Resources.icon_settings);

            // Create menu items
            var excelItem = new ToolStripMenuItem("Excel", Properties.Resources.Custom_Icon_Design_Flatastic_9_Login_512);
            var pdfItem = new ToolStripMenuItem("PDF", Properties.Resources.Custom_Icon_Design_Flatastic_9_Login_512);
            var printItem = new ToolStripMenuItem("PRINT TO PRINTER", Properties.Resources.Custom_Icon_Design_Flatastic_9_Login_512);

            // Reuse your existing logic
            excelItem.Click += ExportExcel_Click;
            pdfItem.Click += ExportPDF_Click;
            printItem.Click += ExportPrintToPrinter_Click;

            // Add items to dropdown
            exportDropDown.DropDownItems.Add(excelItem);
            exportDropDown.DropDownItems.Add(pdfItem);
            exportDropDown.DropDownItems.Add(printItem);

            // Add dropdown to toolstrip
            toolStrip.Items.Add(exportDropDown);

            // Add controls to form
            this.baseKryptonPanel.Controls.Add(_webView);
            this.baseKryptonPanel.Controls.Add(toolStrip);

            // Ensure ToolStrip is on top
            this.baseKryptonPanel.Controls.SetChildIndex(toolStrip, 0);

            // Add WebView2 to the form
            this.baseKryptonPanel.Controls.Add(_webView);
        }
        private void ExportExcel_Click(object sender, EventArgs e) {
            CHtmlReportManager.ExportReportToExcel(_model);
        }
        private void ExportPDF_Click(object sender, EventArgs e) {
            CDialogManager.Info("Please right-click and select 'Print' to generate a PDF.");
        }
        private void ExportPrintToPrinter_Click(object sender, EventArgs e) {
            CDialogManager.Info("Please right-click and select 'Print'.");
        }
    }
}
