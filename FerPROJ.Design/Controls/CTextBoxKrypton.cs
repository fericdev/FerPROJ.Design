using FerPROJ.Design.Class;
using Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FerPROJ.Design.Controls {
    public class CTextBoxKrypton : KryptonTextBox {
        private Color enterColor = Color.WhiteSmoke;
        private Color leaveColor = Color.WhiteSmoke;
        private Color borderColor = Color.White;
        private Color foreColor = Color.Black;
        private Font font = new Font("Tahoma", 10, FontStyle.Regular);
        private Timer debounceTimer;

        public CTextBoxKrypton() {
            StateIsActive();
            StateIsCommon();
            StateIsNormal();
            StateIsDisabled();
            InitializeTimer();
            Text = "";
            TextChanged += CTextBoxKrypton_TextChanged;
        }

        private void StateIsActive() {

            StateActive.Back.Color1 = enterColor;
            StateActive.Border.Color1 = Color.DarkGray;
            StateActive.Border.Color2 = borderColor;
            //
            StateActive.Border.Rounding = 10;
            StateActive.Content.Color1 = foreColor;
        }
        private void StateIsCommon() {
            StateCommon.Back.Color1 = enterColor;
            StateCommon.Border.Color1 = borderColor;
            StateCommon.Border.Color2 = borderColor;
            //
            StateCommon.Border.Rounding = 10;
            StateCommon.Content.Color1 = foreColor;
        }

        private void StateIsNormal() {
            //
            StateNormal.Back.Color1 = leaveColor;
            StateNormal.Border.Color1 = borderColor;
            StateNormal.Border.Color2 = borderColor;
            //
            StateNormal.Border.Rounding = 10;
            StateNormal.Content.Color1 = foreColor;
        }
        private void StateIsDisabled() {
            //
            StateDisabled.Back.Color1 = leaveColor;
            StateDisabled.Border.Color1 = borderColor;
            StateDisabled.Border.Color2 = borderColor;
            //
            StateDisabled.Border.Rounding = 10;
            StateDisabled.Content.Color1 = foreColor;
        }
        private void CTextBoxKrypton_TextChanged(object sender, EventArgs e) {
            debounceTimer.Stop();
            debounceTimer.Start();
        }
        private void InitializeTimer() {
            debounceTimer = new Timer { Interval = 100 };
            debounceTimer.Tick += (s, e) => {
                debounceTimer.Stop();
                DataBindings[nameof(Text)]?.WriteValue();
            };
        }
    }
}
