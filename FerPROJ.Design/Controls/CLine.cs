using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FerPROJ.Design.Controls {
    public class CLine : Label {
        public CLine()
        {
            this.BorderStyle = BorderStyle.Fixed3D;
            this.AutoSize = false;
            this.Height = 3; 
            this.Width = 50;
            this.Text = "";
        }
    }
}
