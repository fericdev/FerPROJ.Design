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
        public FrmListGridKryptonLoad(Type repoType, CrudOptions crudOptions = null) : base(repoType, crudOptions) {
        }

        protected override async Task RefreshAsync() {
            if (_repositoryType == null)
                return;

            var method = _repositoryType.GetMethod("GetViewModelWithSearchAsync",
                new Type[] { typeof(string), typeof(DateTime?), typeof(DateTime?), typeof(int) }
            );

            if (method == null)
                return;

            using (var freshDbContext = (DbContext)Activator.CreateInstance(CAppConstants.DbContextType)) {

                var instance = Activator.CreateInstance(_repositoryType, freshDbContext);

                object[] parameters = new object[]
                {
                    searchValue,
                    dateFrom,
                    dateTo,
                    int.MaxValue
                };

                // Invoke method
                var taskObject = method.Invoke(instance, parameters);

                var taskType = taskObject.GetType();
                var enumerableType = taskType.GetGenericArguments()[0];
                var modelType = enumerableType.GetGenericArguments()[0];

                if (_baseDatagridview != null) {
                    _baseDatagridview?.ApplyCustomAttribute(modelType);
                }

                var task = (Task)taskObject;

                await task;

                var resultProperty = task.GetType().GetProperty("Result");

                var result = resultProperty.GetValue(task);

                var baseModels = ((IEnumerable)result).Cast<TModel>();

                var taskBaseModels = Task.FromResult(baseModels);

                await _baseBindingSource.LoadDataAsync(
                    taskBaseModels,
                    ComboBoxKryptonPage,
                    ComboBoxKryptonDataLimit,
                    dataPage,
                    dataLimit
                );

            }
        }
    }
}
