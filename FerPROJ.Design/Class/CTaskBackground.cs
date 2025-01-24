using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerPROJ.Design.Class {
    public static class CTaskBackground {
        public static void RunTaskInBackground(this Task task) {
            Task.Run(async () =>
            {
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

        /// <summary>
        /// Runs a single task in a background thread.
        /// </summary>
        /// <param name="taskFunc">The function that creates the task.</param>
        public static void RunInBackground(Func<Task> taskFunc) {
            Task.Run(async () =>
            {
                try {
                    await taskFunc();
                }
                catch (Exception ex) {
                    LogError(ex);
                }
            });
        }

        private static void LogError(Exception ex) {
            // Replace with your logging framework or custom logic
            //CShowMessage.Warning($"Error: {ex.Message}");
        }
    }
}
