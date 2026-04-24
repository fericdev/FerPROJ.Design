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
                OnListFormClosedAsync().RunTaskAndForget();
            }
        }
        public static async Task RaiseMethodsOnListFormDeleteAsync() {
            if (OnListFormDeleteAsync != null) {
                OnListFormDeleteAsync().RunTaskAndForget();
            }
        }
        public static async Task RaiseMethodsOnManageFormClosedAsync() {
            if (OnManageFormClosedAsync != null) {
                OnManageFormClosedAsync().RunTaskAndForget();
            }
        }
        public static async Task RaiseMethodsOnListFormRefreshAsync() {
            if (OnListFormRefreshAsync != null) {
                OnListFormRefreshAsync().RunTaskAndForget();
            }
        }
    }
    public static class CEventManager<T> {
        private static event Func<Task> OnListFormRefreshAsync;
        private static event Func<Task> OnListFormClosedAsync;
        public static void Register(Func<Task> handler, EventTypes type) {
            switch(type) {
                case EventTypes.ListFormRefresh:
                    OnListFormRefreshAsync -= handler;
                    OnListFormRefreshAsync += handler;
                    break;
                case EventTypes.ListFormClosed:
                    OnListFormClosedAsync -= handler;
                    OnListFormClosedAsync += handler;
                    break;
                case EventTypes.ListFormDelete:
                    break;
                case EventTypes.ManageFormClosed:
                    break;
            }
        }
        public static void Unregister(Func<Task> handler, EventTypes type) {
            switch (type) {
                case EventTypes.ListFormRefresh:
                    OnListFormRefreshAsync -= handler;
                    break;
                case EventTypes.ListFormClosed:
                    OnListFormClosedAsync -= handler;
                    break;
                case EventTypes.ListFormDelete:
                    break;
                case EventTypes.ManageFormClosed:
                    break;
            }
        }
        public static async Task RaiseOnListFormRefreshAsync() {

            if (OnListFormRefreshAsync == null) {
                return;
            }

            foreach (var handler in OnListFormRefreshAsync.GetInvocationList().Cast<Func<Task>>()) {
                await handler();
            }
        }
        public static async Task RaiseOnListFormClosedAsync() {

            if (OnListFormClosedAsync == null) {
                return;
            }

            foreach (var handler in OnListFormClosedAsync.GetInvocationList().Cast<Func<Task>>()) {
                await handler();
            }
        }
    }
    public enum EventTypes {
        ListFormClosed,
        ListFormDelete,
        ListFormRefresh,
        ManageFormClosed
    }
}
