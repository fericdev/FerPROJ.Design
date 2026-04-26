using FerPROJ.Design.Class;
using FerPROJ.Design.Controls;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using PdfiumViewer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FerPROJ.Design.Forms {
    public partial class FrmHtmlViewer : FrmKrypton {
        private static FrmHtmlViewer _instance;
        private readonly WebView2 _webView;
        private readonly HtmlReportModel _model;
        private readonly string _reportFilePath;
        public FrmHtmlViewer(string reportFilePath, HtmlReportModel model) {
            InitializeComponent();

            // Create WebView2 instance
            _webView = new WebView2 {
                Dock = DockStyle.Fill // Fill the entire form
            };

            // Model
            _model = model;
            _reportFilePath = reportFilePath;

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
        public static void ShowReport(string reportFilePath, HtmlReportModel model) {
            //
            if (_instance == null) {
                _instance = new FrmHtmlViewer(reportFilePath, model);
            }

            // Show the form asynchronously to ensure it's fully loaded
            _instance.Shown += async (s, e) => {
                await Task.Delay(100); // Optional: delay to simulate loading time
            };

            //
            _instance.Show();
            _instance.BringToFront();
            _instance.Update();
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
            var imgItem = new ToolStripMenuItem("IMG", Properties.Resources.Custom_Icon_Design_Flatastic_9_Login_512);
            var imageItem = new ToolStripMenuItem("SCREENSHOT", Properties.Resources.Custom_Icon_Design_Flatastic_9_Login_512);
            var printItem = new ToolStripMenuItem("PRINT TO PRINTER", Properties.Resources.Custom_Icon_Design_Flatastic_9_Login_512);

            // Reuse your existing logic
            excelItem.Click += ExportExcel_Click;
            pdfItem.Click += ExportPDF_Click;
            printItem.Click += ExportPrintToPrinter_Click;
            imageItem.Click += ExportImage_Click;
            imgItem.Click += ExportImg_Click;

            // Add items to dropdown
            exportDropDown.DropDownItems.Add(excelItem);
            exportDropDown.DropDownItems.Add(pdfItem);
            exportDropDown.DropDownItems.Add(imgItem);
            exportDropDown.DropDownItems.Add(imageItem);
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
        private async void ExportPDF_Click(object sender, EventArgs e) {
            if (_webView.CoreWebView2 == null) {
                CDialogManager.Info("Browser not ready.");
                return;
            }

            var fileName = $"{_model.ReportTitle.ToStringNormalize()}_{DateTime.Now.ToString("ddd_MMM_dd")}_{DateTime.Now.ToString("hh_mm_tt")}";

            using (SaveFileDialog dlg = new SaveFileDialog()) {
                dlg.Filter = "PDF Files (*.pdf)|*.pdf";
                dlg.FileName = $"{fileName}.pdf";

                if (dlg.ShowDialog() != DialogResult.OK) {
                    return;
                }

                var printSettings = _webView.CoreWebView2.Environment.CreatePrintSettings();

                printSettings.Orientation = _model.IsLandscape ? CoreWebView2PrintOrientation.Landscape :
                                                                 CoreWebView2PrintOrientation.Portrait;

                var result = await _webView.CoreWebView2.PrintToPdfAsync(dlg.FileName, printSettings);

                if (result) {
                    if (CDialogManager.Ask("Data Exported Successfully.\nDo you want to open the file?", "Confirmation")) {
                        Process.Start(dlg.FileName);
                    }
                }
                else {
                    CDialogManager.Info("PDF export failed.");
                }
            }
        }
        private void ExportPrintToPrinter_Click(object sender, EventArgs e) {
            if (_webView.CoreWebView2 == null) {
                CDialogManager.Info("Browser is not ready yet.");
                return;
            }

            _webView.CoreWebView2.ShowPrintUI(CoreWebView2PrintDialogKind.Browser);
        }
        private async void ExportImage_Click(object sender, EventArgs e) {
            if (_webView.CoreWebView2 == null) {
                CDialogManager.Info("Browser not ready.");
                return;
            }

            var fileName = $"{_model.ReportTitle.ToStringNormalize()}_{DateTime.Now.ToString("ddd_MMM_dd")}_{DateTime.Now.ToString("hh_mm_tt")}";

            using (SaveFileDialog dlg = new SaveFileDialog()) {
                dlg.Filter = "PNG Image (*.png)|*.png";
                dlg.FileName = $"{fileName}.png";

                if (dlg.ShowDialog() != DialogResult.OK) {
                    return;
                }

                // small delay ensures rendering is applied
                await Task.Delay(200);


                using (var stream = new FileStream(dlg.FileName, FileMode.Create)) {
                    await _webView.CoreWebView2.CapturePreviewAsync(
                        CoreWebView2CapturePreviewImageFormat.Png,
                        stream);
                }

                if (CDialogManager.Ask("Image Exported Successfully.\nDo you want to open the file?", "Confirmation")) {
                    Process.Start(dlg.FileName);
                }
            }

        }
        private async void ExportImg_Click(object sender, EventArgs e) {
            if (_webView.CoreWebView2 == null) {
                CDialogManager.Info("Browser not ready.");
                return;
            }

            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog()) {
                if (folderDialog.ShowDialog() != DialogResult.OK)
                    return;

                string basePath = folderDialog.SelectedPath;

                // folder name you want
                var folderName = $"{_model.ReportTitle.ToStringNormalize()}_{DateTime.Now.ToString("ddd_MMM_dd")}_{DateTime.Now.ToString("hh_mm_tt")}";

                // combine path
                string outputFolder = Path.Combine(basePath, folderName);

                string tempPdfPath = Path.Combine(Path.GetTempPath(), "report_temp.pdf");

                // STEP 1: Export PDF first
                bool success = await _webView.CoreWebView2.PrintToPdfAsync(tempPdfPath);

                if (!success) {
                    CDialogManager.Info("Failed to generate PDF.");
                    return;
                }

                // STEP 2: Convert PDF → Images
                var images = ConvertPdfToImages(tempPdfPath, outputFolder);

                // OPTIONAL: cleanup temp pdf
                if (File.Exists(tempPdfPath)) {
                    File.Delete(tempPdfPath);
                }

                CDialogManager.Info($"Done! {images.Count} images created.");
            }

        }
        public List<string> ConvertPdfToImages(string pdfPath, string outputFolder) {
            if (!Directory.Exists(outputFolder)) {
                Directory.CreateDirectory(outputFolder);
            }

            var outputFiles = new List<string>();

            using (var document = PdfDocument.Load(pdfPath)) {
                const float dpi = 600f; // change to 600f if needed
                float scale = dpi / 72f;

                for (int i = 0; i < document.PageCount; i++) {
                    var pageSize = document.PageSizes[i];

                    int width = (int)(pageSize.Width * scale);
                    int height = (int)(pageSize.Height * scale);

                    using (var image = document.Render(i, width, height, true)) {
                        string filePath = Path.Combine(outputFolder, $"page_{i + 1}.png");

                        image.Save(filePath, ImageFormat.Png);

                        outputFiles.Add(filePath);
                    }
                }
            }

            return outputFiles;
        }

        private void FrmHtmlViewer_FormClosing(object sender, FormClosingEventArgs e) {
            _instance = null;

            if (File.Exists(_reportFilePath)) {
                File.Delete(_reportFilePath);
            }
        }
    }
}
