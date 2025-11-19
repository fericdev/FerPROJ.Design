using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerPROJ.Design.Class {
    public class CEventManager {

        public static Func<Task> OnRefreshTaskMethod;

        public static Task RaiseRefreshTaskMethodAsync() {
            return OnRefreshTaskMethod?.Invoke() ?? Task.CompletedTask;
        }

    }
}
