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
        [CAttributes(IsVisible = false, DisplayOrder = 1)]
        public Guid Id { get; set; } = Guid.NewGuid();
        [CAttributes(IsVisible = false, DisplayOrder = 2)]
        public virtual string FormId { get; set; }
        [CAttributes(IsVisible = true, DisplayOrder = 3)]
        public virtual string Name { get; set; }
        [CAttributes(IsVisible = false)]
        public DateTime DateCreated { get; set; } = DateTime.Now;
        [CAttributes(HeaderText = "Date Created")]
        public virtual string DateCreatedString => DateCreated.ToString("MMMM dd, yyyy hh:mm tt");
        [CAttributes(IsVisible = false)]
        public virtual string DateModifiedString => !DateModified.HasValue  ? string.Empty : DateModified.Value.ToString("MMMM dd, yyyy hh:mm tt");
        [CAttributes(IsVisible = false)]
        public DateTime? DateModified { get; set; } = null;
        [CAttributes(HeaderText = "Created By", IsVisible = false)]
        public virtual string CreatedBy { get; set; } = CAppConstants.USERNAME;
        [CAttributes(IsVisible = false)]
        public Guid CreatedById { get; set; } = CAppConstants.USER_ID;
        [CAttributes(IsVisible = false)]
        public virtual string ModifiedBy { get; set; }  = string.Empty;
        [CAttributes(IsVisible = false)]
        public Guid? ModifiedById { get; set; } = null;
        [CAttributes(IsVisible = false)]
        public virtual string Status { get; set; } = CAppConstants.ACTIVE_STATUS;
    }
    public abstract class BaseModelItem : CPropertyValidator 
    {
        [CAttributes(IsVisible = false)]
        public Guid Id { get; set; } = Guid.NewGuid();
        [CAttributes(IsVisible = false)]
        public Guid? ParentId { get; set; }
        [CAttributes(IsEditable = true)]
        public virtual string Description { get; set; }
    }
}
