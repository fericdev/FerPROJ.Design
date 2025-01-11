using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerPROJ.Design.Class
{
    public abstract class BaseDTO : PropertyValidator 
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime? DateModified { get; set; } = null;
        public string CreatedBy { get; set; } = CStaticVariable.USERNAME;
        public string ModifiedBy { get; set; }  = string.Empty;
        public string Status { get; set; } = CStaticVariable.ACTIVE_STATUS;
    }
}
