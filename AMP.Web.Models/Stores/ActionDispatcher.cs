using AMP.Web.Models.Stores.Artisan;
using AMP.Web.Models.Stores.Order;
using System;
using System.Threading.Tasks;

namespace AMP.Web.Models.Stores
{
    public class ActionDispatcher : IActionDispatcher
    {

        private Func<IAction, Task> _registeredActionHandlers;
        private Func<IOrderAction, Task> _registeredOrderActionHandlers;

        public void Unsubscribe(Func<IAction, Task> actionHandler)
        {
            _registeredActionHandlers -= actionHandler;
        }
        public void Unsubscribe(Func<IOrderAction, Task> actionHandler)
        {
            _registeredOrderActionHandlers -= actionHandler;
        }

        public async Task Dispatch(IOrderAction action)
        {
            await _registeredOrderActionHandlers?.Invoke(action);
        }
        public async Task Dispatch(IAction action)
        {
            await _registeredActionHandlers?.Invoke(action);
        }

        public void Subscribe(Func<IAction, Task> actionHandler)
        {
            _registeredActionHandlers += actionHandler;
        }
        
        public void Subscribe(Func<IOrderAction, Task> actionHandler)
        {
            _registeredOrderActionHandlers += actionHandler;
        }
    }
}
