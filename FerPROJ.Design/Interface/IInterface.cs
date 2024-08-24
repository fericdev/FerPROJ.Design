using FerPROJ.Design.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FerPROJ.Design.Interface
{
    public interface IData<DTO, DTODetails>
    {
        IQueryable<DTO> GetAll();
        IQueryable<DTODetails> GetDetailsAll();
        DTO GetById(string id);
        List<DTODetails> GetListById(string id);
        string GetNewID();
        bool SaveData(DTO myDTO);
        bool UpdateData(DTO myDTO);
        bool DeleteData(string id);
        void LoadList(DataGridView dgv, string SearchValue = null);
        void LoadList(DataGridView dgv, string id, string SearchValue = null);
        void LoadList(DataGridView dgv, DateTime dateFrom, DateTime dateTo, string SearchValue = null);
        void LoadList(DataGridView dgv, string id, DateTime dateFrom, DateTime dateTo, string SearchValue = null);
        void LoadComboBox(ComboBox cmb);

    }
    public interface IEntityData<TDestination, TType> : IDisposable
    {
        IEnumerable<TDestination> GetAll();
        TDestination GetById(TType id);
        string GetNewID();

    }
    public interface IEntityDataAsync<TDestination, TType> : IDisposable {
        Task<IEnumerable<TDestination>> GetAllAsync();
        Task<IEnumerable<TDestination>> GetAllAsync(string searchText = "", DateTime? dateFrom = null, DateTime? dateTo = null);
        Task<TDestination> GetByIdAsync(TType id);
        Task<string> GetNewIDAsync();
        Task LoadComboBoxAsync(CComboBoxKrypton cmb);
    }
    public interface IEntityLoadlist
    {
        void LoadList(DataGridView dgv, DateTime dateFrom, DateTime dateTo);
        void LoadList(DataGridView dgv, string SearchValue = "%");
        void LoadList(DataGridView dgv, string id, string SearchValue = "%");
        void LoadList(DataGridView dgv, DateTime dateFrom, DateTime dateTo, string SearchValue = "%");
        void LoadList(DataGridView dgv, string id, DateTime dateFrom, DateTime dateTo, string SearchValue = "%");
    }
    public interface IEntityComboBox
    {
        void LoadComboBox(ComboBox cmb);
        void LoadComboBox(CComboBox cmb);
    }

}
