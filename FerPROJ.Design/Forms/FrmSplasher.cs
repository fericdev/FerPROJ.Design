using FerPROJ.Design.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FerPROJ.Design.Forms
{
    public partial class FrmSplasher : Form
    {
        private static FrmSplasher instance; // Singleton instance
        public FrmSplasher() {
            InitializeComponent();
            systemVersionLbl.Text = CStaticVariable.Version.ToString();
        }
        public void SetLoadingPerc(int perc) {
            pbLoadingPercent.Value = perc;
        }
        public void SetStatus(string txt) {
            LblLoadingMessage.Text = txt;
        }
        public static void ShowSplash() {
            int currentPercentage = 5;
            instance = new FrmSplasher();
            instance.Show();
            instance.Update();
            //
            instance.SetStatus("Loading . . .");
            Application.DoEvents();
            //
            Thread.Sleep(1000);
            while (currentPercentage <= 100) {
                instance.SetLoadingPerc(currentPercentage);
                if (currentPercentage == 10) {
                    instance.SetStatus("Initializing Components . . .");
                } else if (currentPercentage == 50) {
                    instance.SetStatus("Connecting to Database . . .");
                } else if (currentPercentage == 80) {
                    instance.SetStatus("Done . . .");
                }
                Application.DoEvents();
                Thread.Sleep(20);
                currentPercentage++;
            }
        }

        public static void CloseSplash() {
            instance.Close();
            instance.Dispose();
        }
    }
}
