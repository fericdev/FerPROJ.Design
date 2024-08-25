using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FerPROJ.Design.Forms
{
    public partial class FrmSplasherReport : Form
    {
        private static FrmSplasherReport splashForm;

        public FrmSplasherReport() {
            InitializeComponent();
            // Enable double buffering
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
        }

        public static async Task ShowSplashAsync() {
            if (splashForm == null) {
                splashForm = new FrmSplasherReport();
                // Show the form asynchronously to ensure it's fully loaded
                splashForm.Shown += async (s, e) =>
                {
                    await Task.Delay(500); // Optional: delay to simulate loading time
                };
                await Task.CompletedTask;
                splashForm.Show();
            }
        }

        public static void CloseSplash() {
            if (splashForm != null) {
                splashForm.Invoke((Action)(() =>
                {
                    splashForm.Close();
                    splashForm.Dispose();
                    splashForm = null;
                }));
            }
        }
    }
}
