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
        public static async Task RunTasksInBackground(this IEnumerable<Func<Task>> tasksFunc, int seconds = 3, CancellationToken cancellationToken = default) {
            while (!cancellationToken.IsCancellationRequested) {
                // Create tasks
                var tasks = tasksFunc.Select(taskFunc => taskFunc()).ToList();

                // Create a cancellation token for the timeout
                using (var timeoutCancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(seconds))) {
                    var combinedToken = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, timeoutCancellationTokenSource.Token).Token;

                    try {
                        // Await tasks with combined cancellation token
                        await Task.WhenAll(tasks.Select(task => task.WithCancellation(combinedToken)));
                    }
                    catch (OperationCanceledException) {
                        Console.WriteLine("Warning: Some tasks timed out or were canceled.");
                    }
                }

                // Optionally delay before running the next set of tasks
                await Task.Delay(1000 * seconds, cancellationToken);
            }
        }

        // Extension method for supporting cancellation on individual tasks
        private static async Task WithCancellation(this Task task, CancellationToken cancellationToken) {
            var completedTask = await Task.WhenAny(task, Task.Delay(Timeout.Infinite, cancellationToken));
            if (completedTask != task) {
                throw new OperationCanceledException(cancellationToken);
            }
            await task;  // Ensure the task completes
        }

        private static void LogError(Exception ex) {
            // Replace with your logging framework or custom logic
            //CShowMessage.Warning($"Error: {ex.Message}");
            //Console.WriteLine("Background Error:" + ex.Message);
        }
    }
}
