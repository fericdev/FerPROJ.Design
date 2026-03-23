using FerPROJ.Design.BaseModels;
using FerPROJ.Design.Forms;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static FerPROJ.Design.Class.CBaseEnums;

namespace FerPROJ.Design.Class {
    public class CFormLayer {
        public static Task<bool> ManageAddressAsync(FormMode formMode, AddressModel addressDTO, Guid id) {
            using (var frm = new FrmAddressDetail(addressDTO)) {
                frm.CurrentFormMode = formMode;
                frm.Manage_IdTrack = id;
                frm.ShowDialog();
                addressDTO = frm.Address;
                return frm.CurrentFormResult;
            }
        }
        public static Task<bool> ManageAsync<TForm>(Action<TForm> parameters = null) where TForm : FrmManageKrypton {
            using (var frm = Activator.CreateInstance<TForm>()) {
                if (parameters.IsNullOrEmpty()) {
                    parameters = new Action<TForm>(c => c.CurrentFormMode = FormMode.Add);
                }
                parameters?.Invoke(frm);
                frm.ShowDialog();
                return frm.CurrentFormResult;
            }
        }
        public static Task<bool> ManageAsync<TForm>(FormMode formMode, Guid id, List<(string PropertyName, object PropertyValue)> parameters = null) where TForm : FrmManageKrypton {
            using (var frm = (FrmManageKrypton)Activator.CreateInstance(typeof(TForm))) {
                return frm.CurrentFormResultAsync(formMode, id, parameters);
            }
        }
        public static Task<bool> ListAsync<TModel, TEntity, TRepository>(CrudOptions crudoptions, Expression<Func<TEntity, bool>> searchParameter = null) where TModel : BaseModel {
            using (var frm = new FrmListGridKryptonLoad<TModel, TEntity>(typeof(TRepository), crudoptions, searchParameter)) {
                frm.ShowDialog();
                return Task.FromResult(true);
            }
        }

        public static Task<bool> SelectAsync<TModel, TEntity, TRepository>(out Guid id, Expression<Func<TEntity, bool>> searchParameter = null) where TModel : BaseModel {
            using (var frm = new FrmListGridKryptonLoad<TModel, TEntity>(typeof(TRepository), new CrudOptions(), searchParameter)) {
                frm.CurrentManageMode = false;
                frm.ShowDialog();
                id = frm.Form_IdTracks.Select(c => c.To<Guid>()).FirstOrDefault();
                return Task.FromResult(!id.IsNullOrEmpty());
            }
        }

        public static Task<bool> SelectsAsync<TModel, TEntity, TRepository>(out List<Guid> ids, Expression<Func<TEntity, bool>> searchParameter = null) where TModel : BaseModel {
            using (var frm = new FrmListGridKryptonLoad<TModel, TEntity>(typeof(TRepository), new CrudOptions(), searchParameter)) {
                frm.CurrentManageMode = false;
                frm.ShowDialog();
                ids = frm.Form_IdTracks.Select(c => c.To<Guid>()).ToList();
                return Task.FromResult(!ids.IsNullOrEmpty());
            }
        }

    }
}
