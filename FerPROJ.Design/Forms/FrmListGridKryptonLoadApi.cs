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
    public class FrmListGridKryptonLoadApi<TModel, TEntity> : FrmListGridKrypton where TModel : BaseModel {
        private readonly Expression<Func<TEntity, bool>> _searchParameter;
        public FrmListGridKryptonLoadApi(Type repoType, CrudOptions crudOptions, Expression<Func<TEntity, bool>> searchParameter = null) : base(repoType, crudOptions) {
            _searchParameter = searchParameter;
        }
        protected override async void tsbMainRefresh_Click(object sender, EventArgs e) {
            if (CEventManager<TEntity>.OnListFormRefreshNotNull) {
                await FrmSplasherLoading.ShowSplashAsync(true);
                await CEventManager<TEntity>.RaiseOnListFormRefreshAsync();
                FrmSplasherLoading.CloseSplash();
            }

            base.tsbMainRefresh_Click(sender, e);
        }
        protected override async void baseButtonCancel_Click(object sender, EventArgs e) {
            if (CEventManager<TEntity>.OnListFormClosedNotNull) {
                await FrmSplasherLoading.ShowSplashAsync(true);
                await CEventManager<TEntity>.RaiseOnListFormClosedAsync();
                FrmSplasherLoading.CloseSplash();
            }

            base.baseButtonCancel_Click(sender, e);
        }
        protected override async Task RefreshAsync() {

            if (_repositoryType.IsNullOrEmpty()) {
                return;
            }

            await FrmSplasherLoading.ShowSplashAsync();

            _baseDatagridview?.ApplyCustomAttribute(typeof(TModel));

            if (!_crudOptions.HideColumnOnRefreshParameters.IsNullOrEmpty()) {
                _baseDatagridview.HideColumns(_crudOptions.HideColumnOnRefreshParameters, typeof(TModel));
            }

            if (!_searchParameter.IsNullOrEmpty()) {
                var result = await CRepositoryManager.ExecuteApiMethodAsync<(IEnumerable<TModel> ModelItems, int TotalCount)>(
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
                var result = await CRepositoryManager.ExecuteApiMethodAsync<(IEnumerable<TModel> ModelItems, int TotalCount)>(
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

            if (!_crudOptions.RowColorOnRefreshParameters.ColumnName.IsNullOrEmpty()) {
                _baseDatagridview.SetRowColorOfColumnValue(
                    _crudOptions.RowColorOnRefreshParameters.ColumnName,
                    _crudOptions.RowColorOnRefreshParameters.ColumnValue,
                    _crudOptions.RowColorOnRefreshParameters.RowColor,
                    Color.White
                );
            }

            if (!_crudOptions.RowContextMenuButtons.IsNullOrEmpty()) {
                _baseDatagridview.OpenContextMenu(_crudOptions.RowContextMenuButtons);
            }

            _baseDatagridview?.ApplyRowValueFormatting(typeof(TModel));

            FrmSplasherLoading.CloseSplash();

        }
    }
}
