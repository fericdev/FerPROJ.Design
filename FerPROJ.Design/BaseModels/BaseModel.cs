using FerPROJ.Design.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FerPROJ.Design.Class.CBaseEnums;

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
        [CAttributes(Header = "Date Created", Order = 2003)]
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
        [CAttributes(Visible = true, Order = 2001)]
        public virtual string Remarks { get; set; }
    }
    public abstract class BaseFormModel<TItem> : BaseModel where TItem : BaseModelItem
    {
        [CAttributes(Visible = false)]
        public override string Name { get => base.Name; set => base.Name = value; }
        [CAttributes(Visible = false)]
        public DateTime? DateMarked { get; set; } = DateTime.Now;
        [CAttributes(Header = "Date Marked", Order = 2002)]
        public virtual string DateMarkedString => !DateMarked.HasValue ? string.Empty : DateMarked.Value.ToDateAndTime();
        [CAttributes(Header = "Transaction Status", Order = 2000)]
        public string FinalizeStatus { get; set; } = FinalizeStatusTypes.Processing.ToString();
        public virtual List<TItem> Items { get; set; } = new List<TItem>();
        public override bool DataValidation() {
            if (Items.IsNullOrEmpty()) {
                return AddErrorMessage("Please add at least one item.");
            }
            return true;
        }
        public virtual void AddItem(TItem item) {
            if (Items.Contains(item))
                return;

            Items.Add(item);
        }
    }
    public abstract class BaseModelItem : CPropertyValidator 
    {
        [CAttributes(Visible = false)]
        public Guid Id { get; set; } = Guid.NewGuid();
        [CAttributes(Visible = false)]
        public Guid? ParentId { get; set; }
        [CAttributes(Visible = false)]
        public virtual string Description { get; set; }
    }
    public class RemarksModel : BaseModel {
        public Type RepositoryType { get; set; }

        public override bool DataValidation() {
            if (RepositoryType.IsNullOrEmpty()) {
                return AddErrorMessage("Repository Type is required.");
            }
            if (Remarks.IsNullOrEmpty()) {
                return AddErrorMessage("Remarks is required.");
            }
            return true;
        }
    }
}
