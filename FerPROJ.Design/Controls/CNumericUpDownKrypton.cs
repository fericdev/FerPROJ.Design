using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerPROJ.Design.Controls {
    public class CNumericUpDownKrypton : KryptonNumericUpDown {
        private Color borderColor = Color.White;
        private Color foreColor = Color.Black;
        private Font font = new Font("Tahoma", 10, FontStyle.Regular);

        public CNumericUpDownKrypton() {
            StateIsActive();
            StateIsCommon();
            StateIsNormal();
        }
        private void StateIsActive() {

            StateActive.Border.Color1 = Color.DarkGray;
            StateActive.Border.Color2 = borderColor;
            //
            StateActive.Border.Rounding = 10;
            StateActive.Content.Color1 = foreColor;
        }
        private void StateIsCommon() {

            StateCommon.Border.Color1 = Color.DarkGray;
            StateCommon.Border.Color2 = borderColor;
            //
            StateCommon.Border.Rounding = 10;
            StateCommon.Content.Color1 = foreColor;
        }
        private void StateIsNormal() {

            StateNormal.Border.Color1 = Color.DarkGray;
            StateNormal.Border.Color2 = borderColor;
            //
            StateCommon.Border.Rounding = 10;
            StateCommon.Content.Color1 = foreColor;
        }
    }
}
