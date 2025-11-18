using FerPROJ.Design.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerPROJ.Design.BaseModels {
    public abstract class BaseModel : CPropertyValidator 
    {
        [CAttributes(IsVisible = false)]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FormId { get; set; }
        public string Name { get; set; }
        [CAttributes(IsVisible = false)]
        public DateTime DateCreated { get; set; } = DateTime.Now;
        [CAttributes(IsVisible = false)]
        public string DateCreatedString => DateCreated.ToString("MMMM dd, yyyy hh:mm tt");
        [CAttributes(IsVisible = false)]
        public string DateModifiedString => !DateModified.HasValue  ? string.Empty : DateModified.Value.ToString("MMMM dd, yyyy hh:mm tt");
        [CAttributes(IsVisible = false)]
        public DateTime? DateModified { get; set; } = null;
        [CAttributes(IsVisible = false)]
        public string CreatedBy { get; set; } = CAppConstants.USERNAME;
        [CAttributes(IsVisible = false)]
        public Guid CreatedById { get; set; } = CAppConstants.USER_ID;
        [CAttributes(IsVisible = false)]
        public string ModifiedBy { get; set; }  = string.Empty;
        [CAttributes(IsVisible = false)]
        public Guid? ModifiedById { get; set; } = null;
        [CAttributes(IsVisible = false)]
        public string Status { get; set; } = CAppConstants.ACTIVE_STATUS;
    }
    public abstract class BaseModelItem : CPropertyValidator 
    {
        [CAttributes(IsVisible = false)]
        public Guid Id { get; set; } = Guid.NewGuid();
        [CAttributes(IsVisible = false)]
        public Guid? ParentId { get; set; }
        [CAttributes(IsEditable = true)]
        public string Description { get; set; }
    }
}
