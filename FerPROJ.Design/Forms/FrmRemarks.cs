using FerPROJ.DBHelper.DBCrud;
using FerPROJ.Design.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FerPROJ.Design.Class.CBaseEnums;

namespace FerPROJ.Design.Forms {
    public partial class FrmRemarks : FrmManageKrypton {
        public RemarksModel model { get; set; }
        public FrmRemarks() {
            InitializeComponent();
        }
        protected override Task LoadComponentsAsync() {
            baseRemarksModelBindingSource.DataSource = model;
            return Task.CompletedTask;
        }
        protected override async Task<bool> OnSaveDataAsync() {
            return await CRepositoryManager.ExecuteMethodAsync<bool>(model.RepositoryType, "SaveRemarksDTOAsync", model);
        }
    }
}
