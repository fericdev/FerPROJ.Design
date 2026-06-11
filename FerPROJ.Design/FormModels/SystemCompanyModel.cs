using FerPROJ.Design.BaseModels;
using FerPROJ.Design.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerPROJ.Design.FormModels {
    public class SystemCompanyModel : BaseModel {
        public override string Name { get; set; } 
        public override string ApplicationId { get; set; } 
        public string CompanyAddress { get; set; } 
        public string CompanyContactNo { get; set; } 
        public string CompanyEmail { get; set; } 
        public string CompanyLogoUrl { get; set; } 
        public string CompanyDefaultLogoUrl { get; set; }
        public bool CompanyEnabled { get; set; }

        public override bool DataValidation() {
            return true;
        }
    }
}
