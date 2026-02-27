using FerPROJ.Design.BaseModels;
using FerPROJ.Design.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
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
            public async static Task<bool> ListBaseGrid<TModel>(Type repositoryType, CrudOptions crudoptions) where TModel : BaseModel {
                using (var frm = new FrmListGridKryptonLoad<TModel>(repositoryType, crudoptions)) {
                    frm.ShowDialog();
                    return await Task.FromResult(true);
                }
            }
        }
        public static class BaseSelectListForm {
            public static Task<bool> ListBaseGrid<TModel>(Type repositoryType, out Guid id) where TModel : BaseModel {
                using (var frm = new FrmListGridKryptonLoad<TModel>(repositoryType)) {
                    frm.CurrentManageMode = false;
                    frm.ShowDialog();
                    id = frm.Form_IdTrack.ToGuid();
                    return Task.FromResult(true);
                }
            }
        }
    }
}
