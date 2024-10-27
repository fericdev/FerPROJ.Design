using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FerPROJ.Design.UC {
    public partial class UCMenuMain : UserControl {
        private Timer timer;
        private int targetHeight;
        private int step;
        private Panel _panel = new Panel();
        public UCMenuMain() {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 10; 
            timer.Tick += Timer_Tick;
        }
        private void Timer_Tick(object sender, EventArgs e) {
            int currentHeight = _panel.Height;
            if ((step > 0 && currentHeight >= targetHeight) || (step < 0 && currentHeight <= targetHeight)) {
                timer.Stop();
                _panel.Height = targetHeight;
            }
            else {
                _panel.Height += step;
            }
        }
        protected async Task ChangeHeight(Panel panel, int buttonCount = 3) {
            int currentHeight = panel.Height;
            var backColor = panel.BackColor;
            if (currentHeight == 54) {
                targetHeight = 54 * buttonCount;
                step = 5; // Increase height
            }
            else {
                targetHeight = 54;
                step = -5; // Decrease height
            }
            _panel = panel;
            timer.Start();
            await Task.CompletedTask;
        }
        protected virtual async Task ShowControl(UserControl userControl) {
            await HideControl();
            userControl.Visible = true;
        }
        protected virtual async Task HideControl() {
            await Task.CompletedTask;
        } 
    }
}
