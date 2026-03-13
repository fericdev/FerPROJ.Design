using FerPROJ.DBHelper.DBCrud;
using FerPROJ.Design.BaseModels;
using FerPROJ.Design.Class;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FerPROJ.Design.Forms {
    public class FrmListGridKryptonLoad<TModel, TEntity> : FrmListGridKrypton where TModel : BaseModel {
        private readonly Expression<Func<TEntity, bool>> _searchParameter;
        public FrmListGridKryptonLoad(Type repoType, CrudOptions crudOptions, Expression<Func<TEntity, bool>> searchParameter = null) : base(repoType, crudOptions) {
            _searchParameter = searchParameter;
        }
        protected override async Task RefreshAsync() {
            if (_repositoryType == null)
                return;

            _baseDatagridview?.ApplyCustomAttribute(typeof(TModel));

            if (!_searchParameter.IsNullOrEmpty()) {
                var result = await CRepositoryManager.ExecuteMethodAsync<(IEnumerable<TModel> ModelItems, int TotalCount)>(
                    _repositoryType,
                    "GetViewModelWithSearchAsync",
                    _searchParameter,
                    searchValue,
                    dateFrom,
                    dateTo,
                    dataPage,
                    dataLimit
                );
                await _baseBindingSource.LoadDataAsync(
                    result.ModelItems,
                    ComboBoxKryptonPage,
                    ComboBoxKryptonDataLimit,
                    result.TotalCount,
                    dataPage,
                    dataLimit
                );
            }
            else {
                var result = await CRepositoryManager.ExecuteMethodAsync<(IEnumerable<TModel> ModelItems, int TotalCount)>(
                    _repositoryType,
                    "GetViewModelWithSearchAsync",
                    searchValue,
                    dateFrom,
                    dateTo,
                    dataPage,
                    dataLimit
                );
                await _baseBindingSource.LoadDataAsync(
                    result.ModelItems,
                    ComboBoxKryptonPage,
                    ComboBoxKryptonDataLimit,
                    result.TotalCount,
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
