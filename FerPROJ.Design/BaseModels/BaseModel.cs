using FerPROJ.Design.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerPROJ.Design.BaseModels {
    public abstract class BaseModel : PropertyValidator {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FormId { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public string DateCreatedString => DateCreated.ToString("MMMM dd, yyyy hh:mm tt");
        public DateTime? DateModified { get; set; }
        public string DateModifiedString => !DateModified.HasValue ? string.Empty : DateModified.Value.ToString("MMMM dd, yyyy hh:mm tt");
        public DateTime? DateDeleted { get; set; }
        public string DateDeletedString => !DateDeleted.HasValue ? string.Empty : DateDeleted.Value.ToString("MMMM dd, yyyy hh:mm tt");
        public string CreatedBy { get; set; } = CStaticVariable.USERNAME;
        public string ModifiedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
