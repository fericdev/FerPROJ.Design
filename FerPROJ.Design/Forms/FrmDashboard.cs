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

namespace FerPROJ.Design.Forms
{
    public partial class FrmDashboard : Form
    {
        public FrmDashboard()
        {
            InitializeComponent();
        }

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            try
            {
                FrmSplasher.CloseSplash();
                LoadComponent();
                dbTimer.Tick += dbTimer_Tick;
                dbTimer.Start();
            }
            catch (Exception ex)
            {
                CShowMessage.Warning(ex.Message, "Warning");
            }

        }
        protected virtual void LoadComponent()
        {
            
        }

        protected virtual void dbTimer_Tick(object sender, EventArgs e)
        {
            Username.Text = CStaticVariable.USERNAME;
            CurrentDate.Text = CGet.CurrentDate();
            CurrentTime.Text = CGet.CurrentTime();
        }
    }
}
