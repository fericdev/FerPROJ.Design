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
        [GridColumnAttributes(IsVisible = false)]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FormId { get; set; }
        public string Name { get; set; }
        [GridColumnAttributes(IsVisible = false)]
        public DateTime DateCreated { get; set; } = DateTime.Now;
        [GridColumnAttributes(IsVisible = false)]
        public string DateCreatedString => DateCreated.ToString("MMMM dd, yyyy hh:mm tt");
        [GridColumnAttributes(IsVisible = false)]
        public string DateModifiedString => !DateModified.HasValue  ? string.Empty : DateModified.Value.ToString("MMMM dd, yyyy hh:mm tt");
        [GridColumnAttributes(IsVisible = false)]
        public DateTime? DateModified { get; set; } = null;
        [GridColumnAttributes(IsVisible = false)]
        public string CreatedBy { get; set; } = CAppConstants.USERNAME;
        [GridColumnAttributes(IsVisible = false)]
        public Guid CreatedById { get; set; } = CAppConstants.USER_ID;
        [GridColumnAttributes(IsVisible = false)]
        public string ModifiedBy { get; set; }  = string.Empty;
        [GridColumnAttributes(IsVisible = false)]
        public Guid? ModifiedById { get; set; } = null;
        [GridColumnAttributes(IsVisible = false)]
        public string Status { get; set; } = CAppConstants.ACTIVE_STATUS;
    }
    public abstract class BaseModelItem : PropertyValidator 
    {
        [GridColumnAttributes(IsVisible = false)]
        public Guid Id { get; set; } = Guid.NewGuid();
        [GridColumnAttributes(IsVisible = false)]
        public Guid? ParentId { get; set; }
        [GridColumnAttributes(IsEditable = true)]
        public string Description { get; set; }
    }
}
