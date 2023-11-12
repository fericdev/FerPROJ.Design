using FerPROJ.Design.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FerPROJ.Design.Interface
{
    public interface IManageForm<myDTO>
    {
        myDTO MyDTO { get; set; }
    }
    public interface IRepo<DTO, DTODetails>
    {
        IQueryable<DTO> GetAll();
        IQueryable<DTODetails> GetDetailsAll();
        DTO GetById(string id);
        List<DTODetails> GetListById(string id);
        string GetNewID();
        bool SaveData(DTO sDTO);
        bool UpdateData(DTO sDTO);
        bool DeleteData(string id);
        void LoadList(DataGridView dgv, string SearchValue = null);
        void LoadList(DataGridView dgv, string id, string SearchValue = null);
        void LoadList(DataGridView dgv, DateTime dateFrom, DateTime dateTo, string SearchValue = null);
        void LoadList(DataGridView dgv, string id, DateTime dateFrom, DateTime dateTo, string SearchValue = null);
        void LoadComboBox(ComboBox cmb);

    }
    public interface IBL : ICloneable
    {
        int IdTrack { get; set; }
        string DateReference { get; set; }

    }

}
