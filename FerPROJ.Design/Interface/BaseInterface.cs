using FerPROJ.Design.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FerPROJ.Design.Interface
{
    public interface IEntityDataAsync<TEntity> : IDisposable {
        Task<IEnumerable<TEntity>> GetAllAsync(string searchText, DateTime? dateFrom , DateTime? dateTo);
        Task<string> GetNewIDAsync();
        Task LoadComboBoxAsync(CComboBoxKrypton cmb);
    }
    public interface IDbContextMigration<DbContext> : IDisposable {
        Task RunMigrationAsync(DbContext dbContext);
    }
    public interface IModelViewAsync<TViewModel> : IDisposable {
        Task<IEnumerable<TViewModel>> GetViewAsync(string searchText = "", DateTime? dateFrom = null, DateTime? dateTo = null, int dataLimit = 100);
    }
    public interface IEntityDTOAsync<TModel> : IDisposable {
        Task<IEnumerable<TModel>> GetDTOAsync(string searchText = "", int dataLimit = 100, DateTime? dateFrom = null, DateTime? dateTo = null);
    }

}
