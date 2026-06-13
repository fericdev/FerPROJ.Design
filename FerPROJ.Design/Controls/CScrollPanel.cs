using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FerPROJ.Design.Controls {
    public class CScrollPanel : Panel {
        private Control _content;

        private int _currentOffset = 0;
        private int _targetOffset = 0;

        private readonly Timer _timer;

        public int ScrollSpeed { get; set; } = 60;   // wheel step size
        public int Smoothness { get; set; } = 6;     // higher = smoother/slower

        public CScrollPanel() {
            AutoScroll = false;
            Dock = DockStyle.Fill;

            _timer = new Timer();
            _timer.Interval = 15; // ~60 FPS
            _timer.Tick += AnimateScroll;
            _timer.Start();
        }

        public void SetContent(Control content) {
            _content = content;
            Controls.Add(content);

            content.Location = new Point(0, 0);
            content.AutoSize = true;
        }

        protected override void OnMouseWheel(MouseEventArgs e) {
            base.OnMouseWheel(e);

            if (_content == null) return;

            int direction = e.Delta > 0 ? -1 : 1;

            _targetOffset += direction * ScrollSpeed;

            ClampTarget();
        }

        private void ClampTarget() {
            if (_content == null) return;

            int maxScroll = Math.Max(0, _content.Height - this.Height);

            if (_targetOffset < 0)
                _targetOffset = 0;

            if (_targetOffset > maxScroll)
                _targetOffset = maxScroll;
        }

        private void AnimateScroll(object sender, EventArgs e) {
            if (_content == null) return;

            int diff = _targetOffset - _currentOffset;

            if (Math.Abs(diff) <= 0)
                return;

            _currentOffset += diff / Smoothness;

            _content.Location = new Point(0, -_currentOffset);
        }

        protected override void OnResize(EventArgs e) {
            base.OnResize(e);
            ClampTarget();
        }
    }
}
