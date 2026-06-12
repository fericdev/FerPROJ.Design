using FerPROJ.Design.BaseModels;
using FerPROJ.Design.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerPROJ.Design.FormModels {
    public class SystemCompanyModel : BaseModel {
        [CAttributes]
        public override string Name { get; set; } 
        public override string ApplicationId { get; set; }  
        [CAttributes]
        public string CompanyAddress { get; set; }
        [CAttributes]
        public string CompanyContactNo { get; set; }
        [CAttributes]
        public string CompanyEmail { get; set; } 
        public string CompanyLogoUrl { get; set; } 
        public string CompanyDefaultLogoUrl { get; set; }
        [CAttributes]
        public bool CompanyEnabled { get; set; }

        public override bool DataValidation() {
            return true;
        }
    }
}
