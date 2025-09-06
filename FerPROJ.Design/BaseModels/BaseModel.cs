using FerPROJ.Design.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerPROJ.Design.BaseModels {
    public abstract class BaseModel : PropertyValidator 
    {
        [CDGVAttributes(IsVisible = false)]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FormId { get; set; }
        public string Name { get; set; }
        [CDGVAttributes(IsVisible = false)]
        public DateTime DateCreated { get; set; } = DateTime.Now;
        [CDGVAttributes(IsVisible = false)]
        public string DateCreatedString => DateCreated.ToString("MMMM dd, yyyy hh:mm tt");
        [CDGVAttributes(IsVisible = false)]
        public string DateModifiedString => !DateModified.HasValue  ? string.Empty : DateModified.Value.ToString("MMMM dd, yyyy hh:mm tt");
        [CDGVAttributes(IsVisible = false)]
        public DateTime? DateModified { get; set; } = null;
        [CDGVAttributes(IsVisible = false)]
        public string CreatedBy { get; set; } = CAppConstants.USERNAME;
        [CDGVAttributes(IsVisible = false)]
        public Guid CreatedById { get; set; } = CAppConstants.USER_ID;
        [CDGVAttributes(IsVisible = false)]
        public string ModifiedBy { get; set; }  = string.Empty;
        [CDGVAttributes(IsVisible = false)]
        public Guid? ModifiedById { get; set; } = null;
        [CDGVAttributes(IsVisible = false)]
        public string Status { get; set; } = CAppConstants.ACTIVE_STATUS;
    }
    public abstract class BaseModelItem : PropertyValidator 
    {
        [CDGVAttributes(IsVisible = false)]
        public Guid Id { get; set; } = Guid.NewGuid();
        [CDGVAttributes(IsVisible = false)]
        public Guid? ParentId { get; set; }
        [CDGVAttributes(IsEditable = true)]
        public string Description { get; set; }
    }
}
