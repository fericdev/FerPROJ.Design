using FerPROJ.Design.BaseModels;
using FerPROJ.Design.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerPROJ.Design.FormModels {
    public class CompanyModel : BaseModel {
        public override string Name { get; set; } = CConfigurationManager.GetValue("CompanyName", "CompanyConfig");
        public string CompanyAddress { get; set; } = CConfigurationManager.GetValue("CompanyAddress", "CompanyConfig");
        public string CompanyContactNo { get; set; } = CConfigurationManager.GetValue("CompanyContactNo", "CompanyConfig");
        public string CompanyEmail { get; set; } = CConfigurationManager.GetValue("CompanyEmail", "CompanyConfig");
        public string CompanyLogoUrl { get; set; } = CConfigurationManager.GetValue("CompanyLogoUrl", "CompanyConfig");
        public string CompanyDefaultLogoUrl { get; set; } = CAccessManager.GetOrCreateEnvironmentPath("default.webp", "Assets/Img");

        public override bool DataValidation() {
            throw new NotImplementedException();
        }
    }
}
