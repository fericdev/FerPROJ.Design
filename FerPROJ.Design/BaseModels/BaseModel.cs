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
        [CAttributes(Visible = false, Order = 1)]
        public Guid Id { get; set; } = Guid.NewGuid();
        [CAttributes(Visible = false, Order = 2)]
        public virtual string FormId { get; set; }
        [CAttributes(Visible = true, Order = 3)]
        public virtual string Name { get; set; }
        [CAttributes(Visible = false)]
        public DateTime DateCreated { get; set; } = DateTime.Now;
        [CAttributes(Header = "Date Created")]
        public virtual string DateCreatedString => DateCreated.ToDateAndTime();
        [CAttributes(Visible = false)]
        public virtual string DateModifiedString => !DateModified.HasValue  ? string.Empty : DateModified.Value.ToDateAndTime();
        [CAttributes(Visible = false)]
        public DateTime? DateModified { get; set; } = null;
        [CAttributes(Header = "Created By", Visible = false)]
        public virtual string CreatedBy { get; set; } = CAppConstants.USERNAME;
        [CAttributes(Visible = false)]
        public Guid CreatedById { get; set; } = CAppConstants.USER_ID;
        [CAttributes(Visible = false)]
        public virtual string ModifiedBy { get; set; }  = string.Empty;
        [CAttributes(Visible = false)]
        public Guid? ModifiedById { get; set; } = null;
        [CAttributes(Visible = false)]
        public virtual string Status { get; set; } = CAppConstants.ACTIVE_STATUS;
    }
    public abstract class BaseModel<TItem> : BaseModel where TItem : BaseModelItem
    {
        public virtual List<TItem> Items { get; set; } = new List<TItem>();
    }
    public abstract class BaseModelItem : CPropertyValidator 
    {
        [CAttributes(Visible = false)]
        public Guid Id { get; set; } = Guid.NewGuid();
        [CAttributes(Visible = false)]
        public Guid? ParentId { get; set; }
        [CAttributes(Editable = true)]
        public virtual string Description { get; set; }
    }
}
