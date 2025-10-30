using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FerPROJ.Design.Class {
    public static class CNotificationManager {
        public static async Task CreateNotificationAndDisplayAsync(NotificationModel notification, Func<Task> runTaskWhenClick) {
            if (notification == null) {
                return;
            }
            await DisplayNotification(notification, runTaskWhenClick);
        }
        private static async Task DisplayNotification(NotificationModel notification, Func<Task> action) {
            var notifyIcon = new NotifyIcon();
            //
            notifyIcon.Icon = new Icon(SystemIcons.Information, 50, 50);
            notifyIcon.Visible = true;
            notifyIcon.BalloonTipTitle = notification.Title;
            notifyIcon.BalloonTipText = notification.Description;
            notifyIcon.BalloonTipClicked += async (sender, e) => {
                await action();
            };
            //
            if (notification.DelayTimeSeconds > 0) {
                await Task.Delay(notification.DelayTimeSeconds * 1000);
                await ShowBalloonTip();
            }
            if (notification.IntervalTimeSeconds > 0) {
                var timer = new Timer { Interval = notification.IntervalTimeSeconds * 1000 };
                timer.Tick += async (sender, e) => {
                    await ShowBalloonTip();
                };
                timer.Start();
            }
            //
            async Task ShowBalloonTip() {
                await Task.Run(() => {
                    notifyIcon.ShowBalloonTip(notification.DisplayTimeSeconds * 1000, notification.Title, notification.Description, ToolTipIcon.Info);
                });
            }
        }

    }
    public class NotificationModel {
        public string Title { get; set; }
        public string Description { get; set; }
        public int DisplayTimeSeconds { get; set; }
        public int DelayTimeSeconds { get; set; }
        public int IntervalTimeSeconds { get; set; }
    }
}
