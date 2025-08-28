using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FerPROJ.Design.Class {
    public static class CNotificationManager {
        public static async Task CreateNotificationAndDisplayAsync(NotificationDTO notification, Func<Task> runTaskWhenClick) {
            if(notification == null) {
                return;
            }
            await DisplayNotification(notification, runTaskWhenClick);
        }
        private static async Task DisplayNotification(NotificationDTO notification, Func<Task> action) {
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
            if (notification.IntervalTimeSeconds <= 0) {
                await ShowBalloonTip();
            }
            else {
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
    public class NotificationDTO {
        public string Title { get; set; }   
        public string Description { get; set; }
        public int DisplayTimeSeconds { get; set; }
        public int IntervalTimeSeconds { get; set; }
    }
}
