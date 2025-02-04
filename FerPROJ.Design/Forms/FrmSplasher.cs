using FerPROJ.Design.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FerPROJ.Design.Forms {
    public partial class FrmSplasher : Form {
        private static FrmSplasher instance; // Singleton instance
        public FrmSplasher() {
            InitializeComponent();
            systemVersionLbl.Text = CAssembly.SystemVersion;
            // Attach the MouseDown event for the panel
            this.basePnl2.MouseDown += panel_MouseDown;
        }
        public void SetLoadingPerc(int perc) {
            if (pbLoadingPercent.InvokeRequired) {
                pbLoadingPercent.Invoke(new Action<int>(SetLoadingPerc), perc);
            }
            else {
                pbLoadingPercent.Value = perc;
            }
        }

        public void SetStatus(string txt) {
            if (LblLoadingMessage.InvokeRequired) {
                LblLoadingMessage.Invoke(new Action<string>(SetStatus), txt);
            }
            else {
                LblLoadingMessage.Text = txt;
            }
        }
        public static void ShowSplash() {
            int currentPercentage = 5;
            instance = new FrmSplasher();
            instance.Show();
            instance.Update();
            //
            instance.SetStatus("Loading . . .");
            Application.DoEvents();
            //
            Thread.Sleep(1000);
            while (currentPercentage <= 100) {
                instance.SetLoadingPerc(currentPercentage);
                if (currentPercentage == 10) {
                    instance.SetStatus("Initializing Components . . .");
                }
                else if (currentPercentage == 50) {
                    instance.SetStatus("Connecting to Database . . .");
                }
                else if (currentPercentage == 80) {
                    instance.SetStatus("Done . . .");
                }
                Application.DoEvents();
                Thread.Sleep(20);
                currentPercentage++;
            }
        }
        public static async Task ShowSplashAsync(List<Func<Task>> tasks) {
            int currentPercentage = 5;
            instance = new FrmSplasher();
            instance.Show();
            instance.Update();

            instance.SetStatus("Loading . . .");
            Application.DoEvents();

            List<Task> runningTasks = null;

            Task backgroundTask = null;

            // Start the progress update loop
            while (currentPercentage <= 100) {

                instance.SetLoadingPerc(currentPercentage);
                Application.DoEvents();

                if (currentPercentage == 5) {
                    runningTasks = tasks.Select(taskFunc => Task.Run(taskFunc)).ToList();
                }

                if (currentPercentage == 10) {
                    instance.SetStatus("Initializing Components . . .");
                    Application.DoEvents();
                }
                else if (currentPercentage == 50) {
                    instance.SetStatus("Connecting to Database . . .");
                    Application.DoEvents();
                }
                else if (currentPercentage == 80) {
                    instance.SetStatus("Loading cached for better experience . . .");
                    Application.DoEvents();
                    await PauseAsync();

                    // Await all running tasks to complete before continuing
                    if (runningTasks != null) {
                        await Task.WhenAll(runningTasks); // Ensure all tasks are completed
                        currentPercentage = 100;
                    }
                }
                else if (currentPercentage == 100) {
                    instance.SetLoadingPerc(currentPercentage);
                    instance.SetStatus("Done . . .");
                    Application.DoEvents();
                    // After the delay, run the long-running tasks asynchronously
                    backgroundTask = Task.Run(async () => {
                        await tasks.RunTasksInBackground();
                    });
                    await PauseAsync();

                    break; // Exit the loop when the splash screen is closed
                }

                // Continue updating progress even while the tasks are running
                await Task.Delay(10); // Async delay for smooth UI updates

                if (currentPercentage < 80) {
                    currentPercentage++; // Increment percentage unless we're waiting for task completion
                }
            }

            // Close the splash screen after all tasks are completed
            CloseSplash();

            // Await the background task after closing the splash
            if (backgroundTask != null) {
                await backgroundTask;
            }
        }

        public static void CloseSplash() {
            if (instance.InvokeRequired) {
                // If called from a different thread, use Invoke to call Close on the UI thread
                instance.Invoke(new Action(() => {
                    instance.Close();
                    instance.Dispose();
                }));
            }
            else {
                // If already on the UI thread, directly close and dispose
                instance.Close();
                instance.Dispose();
            }
        }
        // This method introduces a pause without blocking the UI thread
        private static async Task PauseAsync() {
            // Pause for 5 seconds but don't block the UI thread
            var startTime = DateTime.UtcNow;
            var delayTime = TimeSpan.FromSeconds(1);

            // Continue updating progress while we wait
            while (DateTime.UtcNow - startTime < delayTime) {
                // Allow progress bar to keep moving
                await Task.Delay(100); // Small delay to allow UI thread to update
            }
        }

        // Override WndProc to handle messages from Win32
        protected override void WndProc(ref Message m) {
            if (m.Msg == CWindows32DLL.WM_NCHITTEST) {
                base.WndProc(ref m);
                // Check if the mouse is over a draggable area (e.g., Panel)
                if (this.basePnl2.ClientRectangle.Contains(this.basePnl2.PointToClient(Cursor.Position))) {
                    m.Result = (IntPtr)CWindows32DLL.HTCAPTION;
                    return;
                }
            }

            base.WndProc(ref m);
        }

        // Mouse down event to start dragging the form
        private void panel_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                // Start dragging
                CWindows32DLL.ReleaseCapture();
                CWindows32DLL.SendMessage(this.Handle, 0x112, 0xF012, 0);
            }
        }
    }
}
