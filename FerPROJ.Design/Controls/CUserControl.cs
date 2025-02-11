using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FerPROJ.Design.Controls
{
    public partial class CUserControl : UserControl
    {
        private Color _borderColor = Color.Black;
        private int _borderSize = 3;
        public CUserControl()
        {
            InitializeComponent();
        }
        protected virtual async Task RefreshData()
        {
            await Task.CompletedTask;
        }
        protected virtual async Task LoadComponents()
        {
            await Task.CompletedTask;
        }

        public Color BorderColor
        {
            get
            {
                return _borderColor;
            }
            set
            {
                _borderColor = value;
                SetColor();
            }
        }
        public int BorderSize
        {
            get
            {
                return _borderSize;
            }
            set
            {
                _borderSize = value;
                SetSize();
            }
        }
        private void SetColor()
        {
            ucLabelMain1.BackColor = _borderColor;
            ucLabelMain2.BackColor = _borderColor;
            ucLabelMain3.BackColor = _borderColor;
            ucLabelMain4.BackColor = _borderColor;
        }
        private void SetSize()
        {
            ucLabelMain1.Width = _borderSize;
            ucLabelMain2.Width = _borderSize;
            ucLabelMain3.Height = _borderSize;
            ucLabelMain4.Height = _borderSize;
        }


        private async void ucCustom_Load(object sender, EventArgs e)
        {
            await LoadComponents();
            await RefreshData();
        }
    }
}
