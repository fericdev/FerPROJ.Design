using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FerPROJ.Design.UC
{
    public partial class UCReportMain : UserControl
    {
        public UCReportMain() {
            InitializeComponent();
        }

        private void UCReportMain_Load(object sender, EventArgs e) {
            LoadComponents();
        }
        protected virtual void LoadComponents() {

        }
    }
}
