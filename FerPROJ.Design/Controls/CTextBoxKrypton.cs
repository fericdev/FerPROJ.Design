using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComponentFactory.Krypton.Toolkit;

namespace FerPROJ.Design.Controls {
    public class CTextBoxKrypton : KryptonTextBox {
        private Color enterColor = Color.LightGray;
        private Color leaveColor = Color.WhiteSmoke;
        private Color foreColor = Color.Black;
        private Font font = new Font("Tahoma", 10, FontStyle.Regular);


        public CTextBoxKrypton() {
            StateIsActive();
            StateIsCommon();
            StateIsNormal();
            Text = "";
        
        }
        private void StateIsActive() {

            StateActive.Back.Color1 = enterColor;
            StateActive.Border.Color1 = foreColor;
            StateActive.Border.Color2 = foreColor;
            //
            StateActive.Border.Rounding = 10;
            StateActive.Content.Color1 = foreColor;
        }
        private void StateIsCommon() {
            StateCommon.Back.Color1 = enterColor;
            StateCommon.Border.Color1 = enterColor;
            StateCommon.Border.Color2 = enterColor;
            //
            StateCommon.Border.Rounding = 10;
            StateCommon.Content.Color1 = foreColor;
        }

        private void StateIsNormal() {
            //
            StateNormal.Back.Color1 = leaveColor;
            StateNormal.Border.Color1 = leaveColor;
            StateNormal.Border.Color2 = leaveColor;
            //
            StateNormal.Border.Rounding = 10;
            StateNormal.Content.Color1 = foreColor;
        }

    }
}
