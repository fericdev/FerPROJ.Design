using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FerPROJ.Design.Controls {
    public partial class CUserControl : UserControl {
        public CUserControl() {
            InitializeComponent();
        }
        protected virtual void LoadComponents() {

        }
        protected virtual async Task LoadDataAsync() {
        
        }

        private async void CUserControl_Load(object sender, EventArgs e) {
            await Task.Delay(100);
            LoadComponents();
            await LoadDataAsync();
        }
    }
}

