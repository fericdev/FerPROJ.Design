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
        [CDGVAttr(IsVisible = false)]
        public Guid Id { get; set; } = Guid.NewGuid();
        [CDGVAttr(IsVisible = false)]
        public DateTime DateCreated { get; set; } = DateTime.Now;
        [CDGVAttr(IsVisible = false)]
        public DateTime? DateModified { get; set; } = null;
        public string CreatedBy { get; set; } = CStaticVariable.USERNAME;
        [CDGVAttr(IsVisible = false)]
        public string ModifiedBy { get; set; }  = string.Empty;
        [CDGVAttr(IsVisible = false)]
        public string Status { get; set; } = CStaticVariable.ACTIVE_STATUS;
    }
}
