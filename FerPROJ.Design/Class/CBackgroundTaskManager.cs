using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FerPROJ.Design.Class {
    public static class CBackgroundTaskManager {
        /// <summary>
        /// var doWorkAsync = async (worker, e) => { worker.ReportProgress(percentage, userState); };<br />
        /// var progressChangedAsync = async (e) => { var userStateValue = (cast)e.UserState; var percentage = e.ProgressPercentage; };<br />
        /// var runWorkerCompletedAsync = async (e) => { var resultValue = (cast)e.Result; };
        /// </summary>
        /// <param name="doWorkAsync">The function that performs the asynchronous work and reports progress.</param>
        /// <param name="progressChangedAsync">Handles progress changes by capturing the percentage and user state.</param>
        /// <param name="runWorkerCompletedAsync">Handles the completion of the asynchronous task and retrieves the result.</param>
        /// <returns>Returns the result of the completed worker task.</returns>
        public static async Task RunWithProgressAsync(
            Func<BackgroundWorker, DoWorkEventArgs, Task> doWorkAsync,
            Func<ProgressChangedEventArgs, Task> progressChangedAsync,
            Func<RunWorkerCompletedEventArgs, Task> runWorkerCompletedAsync) {
            var backgroundWorker = new BackgroundWorker {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };

            backgroundWorker.DoWork += (sender, e) =>
            {
                var worker = sender as BackgroundWorker;
                var task = doWorkAsync(worker, e);
                task.Wait(); // Ensure the async work completes before moving on
            };

            backgroundWorker.ProgressChanged += async (sender, e) =>
            {
                await progressChangedAsync(e);
            };

            backgroundWorker.RunWorkerCompleted += async (sender, e) =>
            {
                await runWorkerCompletedAsync(e);
            };

            backgroundWorker.RunWorkerAsync();

            // Wait until the background worker has completed
            while (backgroundWorker.IsBusy) {
                await Task.Delay(1);
            }
        }

        public static void RunTaskAsync(this Task task) {

            _ = Task.Run(async () =>
            {
                try {
                    await task.ConfigureAwait(false);
                }
                catch (Exception ex) {
                    // Log the exception to avoid unobserved exceptions
                    Console.WriteLine($"Task error: {ex.Message}");
                    // You can also integrate logging frameworks here
                }
            });
        
        }

        /// <summary>
        /// Runs a single task in a background thread.
        /// </summary>
        /// <param name="task"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static async Task RunTaskInBackground(this Task task, int seconds = 5, CancellationToken cancellationToken = default) {
            // Run the task periodically without overlapping executions.
            while (!cancellationToken.IsCancellationRequested) {

                await Task.Delay(1000 * seconds);  // Wait for the specified interval before the next run

                try {
                    await task; // Execute the task asynchronously
                }
                catch (Exception ex) {
                    LogError(ex); // Log any errors that occur during task execution
                }

            }
        }
        /// <summary>
        /// Runs a single task in a background thread.
        /// </summary>
        /// <param name="taskFunc">The function that creates the task.</param>
        // This will run a task periodically in the background every X seconds.
        public static async Task RunTasksInBackground(
            this IEnumerable<Func<Task>> tasksFunc,
            int seconds = 3,
            CancellationToken cancellationToken = default) {
            while (!cancellationToken.IsCancellationRequested) {

                // Create tasks and run them
                //var tasks = tasksFunc.Select(taskFunc => Task.Run(taskFunc)).ToList();
                var tasks = tasksFunc.Select(taskFunc => taskFunc()).ToList();

                // Use a delay task to enforce the timeout
                var timeoutTask = Task.Delay(TimeSpan.FromSeconds(seconds), cancellationToken);

                // Wait for either all tasks to complete or the timeout to occur
                var completedTask = await Task.WhenAny(Task.WhenAll(tasks), timeoutTask);

                if (completedTask == timeoutTask)
                    Console.WriteLine("Warning: Tasks are taking longer than expected but will continue in the background.");
                else
                    await Task.WhenAll(tasks); // Ensure exceptions are observed

                // Wait for the interval before the next iteration
                await Task.Delay(TimeSpan.FromSeconds(seconds), cancellationToken);
            }
        }


        private static void LogError(Exception ex) {
            // Replace with your logging framework or custom logic
            //CShowMessage.Warning($"Error: {ex.Message}");
            //Console.WriteLine("Background Error:" + ex.Message);
        }
    }
}
