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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FerPROJ.Design.Forms {
    public partial class FrmDashboard2 : Form {
        public FrmDashboard2() {
            InitializeComponent();
        }

        private void FrmDashboard2_Load(object sender, EventArgs e) {
            try {
                FrmSplasher.CloseSplash();
                mainTimer.Start();
                LoadComponent();
            } catch (Exception ex) {
                CShowMessage.Warning(ex.Message, "Warning");
            }
        }
        protected virtual void LoadComponent() {
        }

        private void mainTimer_Tick(object sender, EventArgs e) {
            lblMainUserValue.Text = CStaticVariable.USERNAME;
            lblMainDateValue.Text = CGet.CurrentDate();
            lblMainTimeValue.Text = CGet.CurrentTime();
            lblMainVersionValue.Text = CAssembly.SystemVersion;
        }
    }
}
