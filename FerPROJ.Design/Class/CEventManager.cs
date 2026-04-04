using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerPROJ.Design.Class {
    public class CEventManager {

        public static Func<Task> OnListFormClosedAsync;
        public static Func<Task> OnListFormDeleteAsync;
        public static Func<Task> OnListFormRefreshAsync;
        public static Func<Task> OnManageFormClosedAsync;

        public static async Task RaiseMethodsOnListFormClosedAsync() {
            if (OnListFormClosedAsync != null) {
                OnListFormClosedAsync().RunTask();
            }
        }
        public static async Task RaiseMethodsOnListFormDeleteAsync() {
            if (OnListFormDeleteAsync != null) {
                OnListFormDeleteAsync().RunTask();
            }
        }
        public static async Task RaiseMethodsOnManageFormClosedAsync() {
            if (OnManageFormClosedAsync != null) {
                OnManageFormClosedAsync().RunTask();
            }
        }
        public static async Task RaiseMethodsOnListFormRefreshAsync() {
            if (OnListFormRefreshAsync != null) {
                OnListFormRefreshAsync().RunTask();
            }
        }
    }
    public static class CEventManager<T> {
        private static event Func<Task> OnListFormRefreshAsync;
        public static void RegisterRefresh(Func<Task> handler) {
            OnListFormRefreshAsync += handler;
        }
        public static void UnregisterRefresh(Func<Task> handler) {
            OnListFormRefreshAsync -= handler;
        }
        public static async Task RaiseOnListFormRefreshAsync() {

            if (OnListFormRefreshAsync == null) {
                return;
            }

            foreach (var handler in OnListFormRefreshAsync.GetInvocationList().Cast<Func<Task>>()) {
                await handler();
            }
        }
    }
}
