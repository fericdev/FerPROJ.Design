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
    public partial class FrmSplasherReport : Form
    {
        private static FrmSplasherReport splashForm;
        public FrmSplasherReport()
        {
            InitializeComponent();
        }
        public static void ShowSplash()
        {
            splashForm = new FrmSplasherReport();
            splashForm.Show();
        }
        public static void CloseSplash()
        {
            if (splashForm != null)
            {
                splashForm.Close();
                splashForm.Dispose();
                splashForm = null;
            }
        }
    }
}
