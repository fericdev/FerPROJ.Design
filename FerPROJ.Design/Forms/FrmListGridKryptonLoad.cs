using FerPROJ.DBHelper.DBCrud;
using FerPROJ.Design.BaseModels;
using FerPROJ.Design.Class;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
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

            _baseDatagridview?.ApplyCustomAttribute(typeof(TModel));

            if (_crudOptions?.OnRefreshSearchParameter != null) {
                var result = CRepositoryManager.ExecuteMethodAsync<IEnumerable<TModel>>(
                    _repositoryType,
                    "GetViewModelWithSearchAsync",
                    _crudOptions?.OnRefreshSearchParameter,
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

            if (_crudOptions.RowColorOnRefreshEnabled) {
                _baseDatagridview.SetRowColorOfColumnValue(
                    _crudOptions.RowColorOnRefreshParameters.ColumnName,
                    _crudOptions.RowColorOnRefreshParameters.ColumnValue,
                    _crudOptions.RowColorOnRefreshParameters.RowColor,
                    Color.White
                );
            }

        }
    }
}
