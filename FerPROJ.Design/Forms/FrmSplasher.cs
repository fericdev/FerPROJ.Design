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
    public partial class FrmSplasher: Form
    {
        private static FrmSplasher instance; // Singleton instance
        public FrmSplasher()
        {
            InitializeComponent();
            systemVersionLbl.Text = CStaticVariable.Version.ToString();
        }
        public void SetLoadingPerc(int perc)
        {
            pbLoadingPercent.Value = perc;
        }
        public void SetStatus(string txt)
        {
            LblLoadingMessage.Text = txt;
        }
        public static void ShowSplash()
        {
            instance = new FrmSplasher();
            instance.Show();
        }

        public static void CloseSplash()
        {
            instance.Close();
            instance.Dispose();
        }
    }
}
