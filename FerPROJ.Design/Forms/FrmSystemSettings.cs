using FerPROJ.Design.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FerPROJ.Design.Forms {
    public partial class FrmSystemSettings : FrmManageKrypton {
        public FrmSystemSettings() {
            InitializeComponent();
        }
        protected override Task LoadComponentsAsync() {
            applicationIdCTextBoxKrypton.Text = CAppConstants.APPLICATION_ID;
            return base.LoadComponentsAsync();
        }
        protected override Task InitializeFormPropertiesAsync() {
            HideSaveNewOnUpdate = true;
            HideSaveNew = true;
            return base.InitializeFormPropertiesAsync();
        }
        protected override async Task<bool> OnSaveDataAsync() {
            CConfigurationManager.CreateOrSetValue("ApplicationId", applicationIdCTextBoxKrypton.Text, "SystemCompanyConfig");
            CAppConstants.APPLICATION_ID = applicationIdCTextBoxKrypton.Text;
            return true;
        }
    }
}
