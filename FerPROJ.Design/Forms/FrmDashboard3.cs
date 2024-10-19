using ComponentFactory.Krypton.Toolkit;
using FerPROJ.DBHelper.Class;
using FerPROJ.Design.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FerPROJ.Design.Forms {
    public partial class FrmDashboard3 : KryptonForm {
        public FrmDashboard3() {
            InitializeComponent();
        }

        private void FrmDashboard3_Load(object sender, EventArgs e) {
            try {
                FrmSplasher.CloseSplash();
                timerMain.Start();
                LoadVar();
                LoadComponent();
            }
            catch (Exception ex) {
                // catch exception here
            }
        }
        protected virtual void LoadComponent() {
        }

        private void timerMain_Tick(object sender, EventArgs e) {
            lblMainDateValue.Text = CGet.CurrentDate();
            lblMainTimeValue.Text = CGet.CurrentTime();
        }
        private void LoadVar() {
            lblMainUserValue.Text = CStaticVariable.Username;
            lblMainVersionValue.Text = CAssembly.SystemVersion;
        }
    }
}
