using AMP.Web.Models.Stores.Order;
using System;
using System.Threading.Tasks;

namespace AMP.Web.Models.Stores
{
    public interface IActionDispatcher
    {
        Task Dispatch(IAction action);
        void Unsubscribe(Func<IAction, Task> actionHandler);
        void Subscribe(Func<IAction, Task> handleActions);
        
        Task Dispatch(IOrderAction action);
        void Unsubscribe(Func<IOrderAction, Task> actionHandler);
        void Subscribe(Func<IOrderAction, Task> handleActions);
    }
}
