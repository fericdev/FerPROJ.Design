using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerPROJ.Design.Class {
    public class CEventManager {

        public static Func<Task> OnListFormButtonClosedAsync;
        public static Func<Task> OnManageFormButtonClosedAsync;

        public static async Task RaiseMethodsOnListFormButtonClosedAsync() {
            if (OnListFormButtonClosedAsync != null) {
                await OnListFormButtonClosedAsync();
            }
        }
        public static async Task RaiseMethodsOnManageFormButtonClosedAsync() {
            if (OnManageFormButtonClosedAsync != null) {
                await OnManageFormButtonClosedAsync();
            }
        }


    }
}
