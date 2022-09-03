using AMP.Web.Models.PageDtos;
using AMP.Web.Models.Services.HttpServices;
using AMP.Web.Models.Stores.Base;
using Kessewa.Extension.Shared.HttpServices.Models;
using System.Threading.Tasks;

namespace AMP.Web.Models.Stores.Order
{
    public class OrderState
    {
        public PaginatedList<OrderPageDto> Orders { get; }

        public OrderState(PaginatedList<OrderPageDto> orders)
        {
            Orders = orders;
        }
    }

    public class OrderStore : StoreBase
    {
        private readonly OrderService _orderService;
        private OrderState _state;

        public OrderStore(IActionDispatcher actionDispatcher, OrderService orderService)
        {
            _state = new OrderState(new PaginatedList<OrderPageDto>());
            _orderService = orderService;
            actionDispatcher.Subscribe(HandleActions);
        }

        public OrderState GetState()
        {
            return _state;
        }

        private async Task HandleActions(IOrderAction action)
        {
            switch (action.NameOfAction)
            {
                case GetOrderPageAction.GETORDERPAGE:
                    await GetPage(action.Payload);
                    break;
                case ResetOrderPageAction.RESET:
                    await Task.Run(() => Reset());
                    break;
                default:
                    break;
            }
        }

        private async Task GetPage(PaginatedQuery query)
        {
            if (string.IsNullOrEmpty(query.Search) && _state.Orders.Data.Count != 0) return;
            var orders = await _orderService.GetCustomerOrderPage(query);
            _state = new OrderState(orders);
            BroadcastStateChange();
        }

        private void Reset()
        {
            _state = new OrderState(new PaginatedList<OrderPageDto>());
        }
    }

}

