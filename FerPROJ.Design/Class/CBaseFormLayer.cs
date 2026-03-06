using FerPROJ.Design.BaseModels;
using FerPROJ.Design.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static FerPROJ.Design.Class.CBaseEnums;

namespace FerPROJ.Design.Class {
    public class CBaseFormLayer {
        public static class BaseManageForm {
            public static async Task<bool> ManageBaseAddressDetail(FormMode formMode, AddressModel addressDTO, Guid id) {
                using (var frm = new FrmAddressDetail(addressDTO)) {
                    frm.CurrentFormMode = formMode;
                    frm.Manage_IdTrack = id;
                    frm.ShowDialog();
                    addressDTO = frm.Address;
                    return await frm.CurrentFormResult;
                }
            }
        }
        public static class BaseListForm {
            public async static Task<bool> ListBaseGrid<TModel, TEntity>(Type repositoryType, CrudOptions crudoptions, Expression<Func<TEntity, bool>> searchParameter = null) where TModel : BaseModel {
                using (var frm = new FrmListGridKryptonLoad<TModel, TEntity>(repositoryType, crudoptions, searchParameter)) {
                    frm.ShowDialog();
                    return await Task.FromResult(true);
                }
            }
        }
        public static class BaseSelectListForm {
            public static Task<bool> ListBaseGrid<TModel, TEntity>(Type repositoryType, Expression<Func<TEntity, bool>> searchParameter, out Guid id) where TModel : BaseModel {
                using (var frm = new FrmListGridKryptonLoad<TModel, TEntity>(repositoryType, new CrudOptions(), searchParameter)) {
                    frm.CurrentManageMode = false;
                    frm.ShowDialog();
                    id = frm.Form_IdTrack.ToGuid();
                    return Task.FromResult(!id.IsNullOrEmpty());
                }
            }
        }
    }
}
