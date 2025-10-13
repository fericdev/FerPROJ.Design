using FerPROJ.Design.BaseModels;
using FerPROJ.Design.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerPROJ.Design.Models {
    public partial class UserModel : BaseModel {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }
        public override bool DataValidation() {
            Password = CEncryptionManager.EncryptText(Password);
            return true;
        }
    }
}
