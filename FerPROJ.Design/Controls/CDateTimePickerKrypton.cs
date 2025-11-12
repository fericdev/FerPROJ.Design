using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FerPROJ.Design.Controls {
    public class CDateTimePickerKrypton : KryptonDateTimePicker {
        private Color borderColor = Color.White;
        private Color foreColor = Color.Black;

        public CDateTimePickerKrypton() {
            StateIsActive();
            StateIsCommon();
            StateIsNormal();
            Format = DateTimePickerFormat.Long;
            ShowUpDown = false;
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

    public class CDateTimePickerKrypton2 : KryptonDateTimePicker {
        private Color borderColor = Color.White;
        private Color foreColor = Color.Black;

        public CDateTimePickerKrypton2() {
            StateIsActive();
            StateIsCommon();
            StateIsNormal();
            Format = DateTimePickerFormat.Custom;
            CustomFormat = "MM/dd/yyyy hh:mm tt";
            ShowUpDown = false;
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
