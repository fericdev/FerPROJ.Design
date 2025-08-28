using FerPROJ.Design.BaseModels;
using FerPROJ.Design.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FerPROJ.Design.Forms.FrmManageKrypton;

namespace FerPROJ.Design.Class {
    public class CBaseFormLayer {
        public static class BaseManageForm {
            public static bool ManageBaseAddressDetail(FormMode formMode, BaseAddressModel addressDTO, Guid id) {
                using (var frm = new FrmAddressDetail(addressDTO)) {
                    frm.CurrentFormMode = formMode;
                    frm.Manage_IdTrack = id;
                    frm.ShowDialog();
                    addressDTO = frm.Address;
                    return frm.CurrentFormResult.Result;
                }
            }
        }
    }
}
