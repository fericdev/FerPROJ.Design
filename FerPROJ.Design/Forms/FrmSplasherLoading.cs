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
    public partial class FrmSplasherLoading : Form
    {
        private static FrmSplasherLoading splashForm;

        public FrmSplasherLoading() {
            InitializeComponent();
            // Enable double buffering
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
        }
        public static void SetLoadingPerc(int perc) {
            // Check if splashForm is initialized and not disposed
            if (splashForm != null && !splashForm.IsDisposed) {
                splashForm.UpdateLoadingLabel(perc);
            }
        }
        public static async Task ShowSplashAsync() {
            if (splashForm == null) {
                splashForm = new FrmSplasherLoading();
                // Show the form asynchronously to ensure it's fully loaded
                splashForm.Shown += async (s, e) =>
                {
                    await Task.Delay(100); // Optional: delay to simulate loading time
                };
                await Task.CompletedTask;
                splashForm.Show();
                splashForm.Update();
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
        private void UpdateLoadingLabel(int perc) {
            try {
                // Check if the form or label is disposed
                if (this.IsDisposed || customLabelTitleLoading.IsDisposed) {
                    return; // Prevent updating if the form or label is disposed
                }

                var percText = $"Loading. . . {perc}%";
                if (customLabelTitleLoading.InvokeRequired) {
                    customLabelTitleLoading.Invoke(new Action<int>(UpdateLoadingLabel), perc);
                }
                else {
                    customLabelTitleLoading.Text = percText;
                }
            }
            catch (Exception) { 
                // do nothing, is disposed
            }
        }
    }
}
