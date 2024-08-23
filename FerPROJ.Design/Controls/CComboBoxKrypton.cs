using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComponentFactory.Krypton.Toolkit;
using CrystalDecisions.CrystalReports.ViewerObjectModel;

namespace FerPROJ.Design.Controls {
    public class CComboBoxKrypton : KryptonComboBox {
        private Color enterColor = Color.WhiteSmoke;
        private Color leaveColor = Color.WhiteSmoke;
        private Color borderColor = Color.White;
        private Color foreColor = Color.Black;
        private Font font = new Font("Tahoma", 10, FontStyle.Regular);

        public CComboBoxKrypton() {
            StateIsActive();
            StateIsCommon();
            StateIsNormal();
            Text = "";
        }
        private void StateIsActive() {

            StateActive.ComboBox.Border.Color1 = enterColor;
            StateActive.ComboBox.Border.Color1 = borderColor;
            StateActive.ComboBox.Border.Color2 = borderColor;
            //
            StateActive.ComboBox.Border.Rounding = 10;
            StateActive.ComboBox.Content.Color1 = foreColor;
        }
        private void StateIsCommon() {
            StateActive.ComboBox.Border.Color1 = enterColor;
            StateActive.ComboBox.Border.Color1 = borderColor;
            StateActive.ComboBox.Border.Color2 = borderColor;
            //
            StateActive.ComboBox.Border.Rounding = 10;
            StateActive.ComboBox.Content.Color1 = foreColor;
        }

        private void StateIsNormal() {
            //
            StateActive.ComboBox.Border.Color1 = enterColor;
            StateActive.ComboBox.Border.Color1 = borderColor;
            StateActive.ComboBox.Border.Color2 = borderColor;
            //
            StateActive.ComboBox.Border.Rounding = 10;
            StateActive.ComboBox.Content.Color1 = foreColor;
        }
    }
}
