using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComponentFactory.Krypton.Toolkit;
using System.Windows.Forms;
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
            StateIsDisabled();
            Text = "";
            //
            AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void StateIsActive() {

            StateActive.ComboBox.Border.Color1 = Color.DarkGray;
            StateActive.ComboBox.Border.Color2 = borderColor;
            //
            StateActive.ComboBox.Border.Rounding = 10;
            StateActive.ComboBox.Content.Color1 = foreColor;
        }
        private void StateIsCommon() {
            StateActive.ComboBox.Border.Color1 = Color.DarkGray;
            StateActive.ComboBox.Border.Color2 = borderColor;
            //
            StateActive.ComboBox.Border.Rounding = 10;
            StateActive.ComboBox.Content.Color1 = foreColor;
        }

        private void StateIsNormal() {
            //
            StateActive.ComboBox.Border.Color1 = Color.DarkGray;
            StateActive.ComboBox.Border.Color2 = borderColor;
            //
            StateActive.ComboBox.Border.Rounding = 10;
            StateActive.ComboBox.Content.Color1 = foreColor;
        }
        private void StateIsDisabled() {
            //
            StateDisabled.ComboBox.Border.Color1 = Color.DarkGray;
            StateDisabled.ComboBox.Border.Color2 = borderColor;
            //
            StateDisabled.ComboBox.Border.Rounding = 10;
            StateDisabled.ComboBox.Content.Color1 = foreColor;
        }
    }
}
