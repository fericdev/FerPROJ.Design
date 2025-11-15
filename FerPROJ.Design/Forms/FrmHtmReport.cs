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
    public partial class FrmHtmReport : Form {
        private readonly WebView2 _webView;
        public FrmHtmReport(string reportFilePath) {
            InitializeComponent();

            // Set basic form properties
            this.Text = "Report Viewer";
            this.Width = 800;
            this.Height = 600;

            // Create WebView2 instance
            _webView = new WebView2 {
                Dock = DockStyle.Fill // Fill the entire form
            };

            // Add WebView2 to the form
            this.Controls.Add(_webView);

            // Initialize and load HTML
            InitializeAsync(reportFilePath);
        }

        private async void InitializeAsync(string htmlFilePath) {
            // Initialize WebView2 environment
            await _webView.EnsureCoreWebView2Async(null);

            // Load the HTML file
            _webView.CoreWebView2.Navigate(htmlFilePath);
        }
    }
}
