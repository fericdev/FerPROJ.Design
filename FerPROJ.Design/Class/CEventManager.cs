using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerPROJ.Design.Class {
    public class CEventManager {

        public static Func<Task> OnListFormClosedAsync;
        public static Func<Task> OnManageFormClosedAsync;

        public static async Task RaiseMethodsOnListFormClosedAsync() {
            if (OnListFormClosedAsync != null) {
                await OnListFormClosedAsync();
            }
        }
        public static async Task RaiseMethodsOnManageFormClosedAsync() {
            if (OnManageFormClosedAsync != null) {
                await OnManageFormClosedAsync();
            }
        }


    }
}
