using FerPROJ.DBHelper.DBCrud;
using FerPROJ.Design.BaseModels;
using FerPROJ.Design.Class;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerPROJ.Design.Forms {
    public class FrmListGridKryptonLoad<TModel> : FrmListGridKrypton where TModel : BaseModel {
        public FrmListGridKryptonLoad(Type repoType, CrudOptions crudOptions) : base(repoType, crudOptions) {
        }
        protected override async Task RefreshAsync() {
            if (_repositoryType == null)
                return;

            if (_baseDatagridview != null) {
                _baseDatagridview?.ApplyCustomAttribute(typeof(TModel));
            }

            if (_crudOptions?.OnViewSearchParameter != null) {
                var result = CRepositoryManager.ExecuteMethodAsync<IEnumerable<TModel>>(
                    _repositoryType,
                    "GetViewModelWithSearchAsync",
                    _crudOptions?.OnViewSearchParameter,
                    searchValue,
                    dateFrom,
                    dateTo,
                    int.MaxValue
                );
                await _baseBindingSource.LoadDataAsync(
                    result,
                    ComboBoxKryptonPage,
                    ComboBoxKryptonDataLimit,
                    dataPage,
                    dataLimit
                );
            }
            else {
                var result = CRepositoryManager.ExecuteMethodAsync<IEnumerable<TModel>>(
                    _repositoryType,
                    "GetViewModelWithSearchAsync",
                    searchValue,
                    dateFrom,
                    dateTo,
                    int.MaxValue
                );
                await _baseBindingSource.LoadDataAsync(
                    result,
                    ComboBoxKryptonPage,
                    ComboBoxKryptonDataLimit,
                    dataPage,
                    dataLimit
                );
            }
        }
    }
}
