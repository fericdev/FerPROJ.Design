using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace FerPROJ.Design.Controls {
    public class CButtonKrypton : KryptonButton {


        private Font font = new Font("Tahoma", 10, FontStyle.Regular);

        public CButtonKrypton() { 
        
            PaletteMode = PaletteMode.Office2007Black;
            StateCommon.Border.Rounding = 15;
            StateCommon.Content.ShortText.Color1 = Color.White;
            StateCommon.Content.ShortText.Color2 = Color.White;
            StateCommon.Content.ShortText.Font = font;

            StateNormal.Border.Rounding = 15;
            StateNormal.Content.ShortText.Color1 = Color.White;
            StateNormal.Content.ShortText.Color2 = Color.White;
            StateNormal.Content.ShortText.Font = font;



        }
    }
}
