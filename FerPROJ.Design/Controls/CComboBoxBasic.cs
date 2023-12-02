using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FerPROJ.Design.Controls
{
    public class CComboBoxBasic : ComboBox
    {
        private Color enterColor = Color.LightGray;
        private Color leaveColor = Color.WhiteSmoke;
        private Color foreColor = Color.Black;
        private string properText = "";
        private string properTextValue = "";
        private string propTxt = "";
        private string propVal = "";


        public CComboBoxBasic()
        {
            MouseLeave += CComboBoxBasic_MouseLeave;
            MouseEnter += CComboBoxBasic_MouseEnter;
            SelectedIndexChanged += CComboBoxBasic_SelectedIndexChanged;
            ForeColor = foreColor;
            DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void CComboBoxBasic_MouseLeave(object sender, EventArgs e)
        {           
            this.BackColor = leaveColor;
        }

        private void CComboBoxBasic_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = enterColor;
        }
        protected override void OnLeave(EventArgs e)
        {
            this.BackColor = leaveColor;
            base.OnLeave(e);
        }
        protected override void OnEnter(EventArgs e)
        {
            this.BackColor = enterColor;
            base.OnEnter(e);
        }
        [Browsable(true)]
        [Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string PropertyTextValue
        {
            get
            {
                return properTextValue;
            }
            set
            {
                propVal = value;
            }
        }
        [Browsable(true)]
        [Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string PropertyText
        {
            get
            {
                return properText;
            }
            set
            {
                propTxt = value;
            }
        }
        private void CComboBoxBasic_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedIndex > -1)
            {
                properText = Text;
                properTextValue = SelectedValue.ToString();
                //
            }
        }
    }
}
