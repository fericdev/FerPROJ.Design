using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FerPROJ.Design.Class {
    public static class CTaskBackground {
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
        public static async Task RunTasksInBackground(this IEnumerable<Func<Task>> tasksFunc, int seconds = 5, CancellationToken cancellationToken = default) {
            // Run the task periodically without overlapping executions.
            while (!cancellationToken.IsCancellationRequested) {
                foreach (var taskFunc in tasksFunc) {
                    var task = taskFunc();  // Start the task

                    // Wait for either task completion or timeout
                    var completedTask = await Task.WhenAny(task, Task.Delay(1000 * seconds, cancellationToken));

                    if (completedTask == task) {
                        // Task completed within the timeout, await its completion
                        await task;
                    }
                    else {
                        // Task didn't complete in time
                        Console.WriteLine("Warning: Task timed out.");
                    }

                    // Optionally delay before running the next task
                    await Task.Delay(1000 * seconds, cancellationToken);
                }
            }
        }

        private static void LogError(Exception ex) {
            // Replace with your logging framework or custom logic
            //CShowMessage.Warning($"Error: {ex.Message}");
            //Console.WriteLine("Background Error:" + ex.Message);
        }
    }
}
