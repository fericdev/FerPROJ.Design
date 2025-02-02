using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerPROJ.Design.Class {
    public static class CTaskBackground {
        public static void RunTaskInBackground(this Task task) {
            Task.Run(async () => {
                try {
                    await task;
                }
                catch (Exception ex) {
                    LogError(ex);
                }
            });
        }
        /// <summary>
        /// Runs multiple tasks in parallel and waits for their completion.
        /// </summary>
        /// <param name="tasks">The tasks to run.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public static async Task RunTasksAsync(IEnumerable<Task> tasks) {
            try {
                await Task.WhenAll(tasks);
            }
            catch (Exception ex) {
                LogError(ex);
            }
        }
        public static async Task RunTasksAsync(IEnumerable<Func<Task>> taskFuncs) {
            var tasks = new List<Task>();

            foreach (var taskFunc in taskFuncs) {
                // Create a task for each Func<Task> and add it to the list
                tasks.Add(ExecuteTaskWithErrorHandling(taskFunc));
            }

            try {
                // Wait for all tasks to complete
                await Task.WhenAll(tasks);
            }
            catch (Exception ex) {
                LogError(ex);  // Handle any errors that occurred during the execution of the tasks
            }
        }

        private static async Task ExecuteTaskWithErrorHandling(Func<Task> taskFunc) {
            try {
                // Execute the task and await it
                await taskFunc();
            }
            catch (Exception ex) {
                LogError(ex);  // Log errors specific to this individual task
            }
        }

        /// <summary>
        /// Runs a single task in a background thread.
        /// </summary>
        /// <param name="taskFunc">The function that creates the task.</param>
        // This will run a task periodically in the background every X seconds.
        public static async Task RunTaskPeriodically(Func<Task> taskFunc, TimeSpan interval) {
            // Run the task periodically with async/await handling.
            while (true) {
                try {
                    await taskFunc(); // Run the task asynchronously
                }
                catch (Exception ex) {
                    LogError(ex); // Handle any errors (for logging, etc.)
                }

                await Task.Delay(interval); // Wait for the specified interval before running again
            }
        }

        private static void LogError(Exception ex) {
            // Replace with your logging framework or custom logic
            //CShowMessage.Warning($"Error: {ex.Message}");
            Console.WriteLine("Background Error:" + ex.Message);
        }
    }
}
