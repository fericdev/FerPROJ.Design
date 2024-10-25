using FerPROJ.Design.BaseDTO;
using FerPROJ.Design.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FerPROJ.Design.Forms.FrmManageKrypton;

namespace FerPROJ.Design.Class {
    public static class CFormLayer {
        public static class ManageForm {
            public static bool ManageBaseAddressDetail(FormMode formMode, BaseAddressDTO addressDTO, string id = "") {
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
