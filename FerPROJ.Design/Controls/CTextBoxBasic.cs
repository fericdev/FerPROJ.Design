using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FerPROJ.Design.Controls
{
    public class CTextBoxBasic : TextBox
    {
        private Color enterColor = Color.LightGray;
        private Color leaveColor = Color.WhiteSmoke;
        private Color foreColor = Color.Black;
        private Font font = new Font("Tahoma", 10, FontStyle.Regular);

        public CTextBoxBasic()
        {
            BackColor = leaveColor; // Set default leave color
            ForeColor = foreColor;
            Font      = font;
        }

        protected override void OnEnter(EventArgs e)
        {
            BackColor = enterColor; // Change to enter color on focus
            ForeColor = foreColor;
            base.OnEnter(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            BackColor = leaveColor; // Change to leave color when focus is lost
            ForeColor = foreColor;
            base.OnLeave(e);
        }

        public Color EnterColor
        {
            get { 
                return enterColor; 
            }
            set { 
                enterColor = value; 
            }
        }

        public Color LeaveColor
        {
            get { 
                return leaveColor; 
            }
            set { 
                leaveColor = value; 
            }
        }
        public new Color DefaultForeColor
        {
            get
            {
                return foreColor;
            }
            set
            {
                foreColor = value;
            }
        }
    }
}
