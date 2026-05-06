using FerPROJ.Design.Class;
using FerPROJ.Design.FormModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FerPROJ.Design.Class.CBaseEnums;

namespace FerPROJ.Design.Forms {
    public partial class FrmCompany : FrmManageKrypton {
        CompanyModel model = new CompanyModel();
        public FrmCompany() {
            InitializeComponent();
        }
        protected override async Task LoadComponentsAsync() {
            switch (CurrentFormMode) {
                case FormMode.Add:
                    break;

            }
            companyModelBindingSource.DataSource = model;
        }
        protected override async Task<bool> OnSaveDataAsync() {
            CConfigurationManager.CreateOrSetValue(nameof(model.CompanyAddress), model.CompanyAddress, "CompanyConfig");
            CConfigurationManager.CreateOrSetValue(nameof(model.CompanyContactNo), model.CompanyContactNo, "CompanyConfig");
            CConfigurationManager.CreateOrSetValue(nameof(model.CompanyEmail), model.CompanyEmail, "CompanyConfig");
            CConfigurationManager.CreateOrSetValue("CompanyName", model.Name, "CompanyConfig");
            CDialogManager.Info("Company Configuration Updated Successfully!", "Info");
            return true;
        }
    }
}
