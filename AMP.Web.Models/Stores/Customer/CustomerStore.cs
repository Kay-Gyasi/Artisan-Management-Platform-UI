using AMP.Web.Models.Dtos;
using AMP.Web.Models.Services.HttpServices;
using AMP.Web.Models.Stores.Base;
using System.Threading.Tasks;

namespace AMP.Web.Models.Stores.Customer
{
    public class CustomerState
    {
        public CustomerDto Customer { get; }

        public CustomerState(CustomerDto customer)
        {
            Customer = customer;
        }
    }

    public class CustomerStore : StoreBase
    {
        private readonly CustomerService _customerService;
        private CustomerState _state;

        public CustomerStore(IActionDispatcher actionDispatcher, CustomerService customerService)
        {
            _state = new CustomerState(new CustomerDto());
            _customerService = customerService;
            actionDispatcher.Subscribe(HandleActions);
        }

        public CustomerState GetState()
        {
            return _state;
        }

        private async Task HandleActions(IAction action)
        {
            switch (action.NameOfAction)
            {
                case GetCustomerByUserIdAction.GETBYUSERID:
                    await GetCustomerByUserId();
                    break;
                case ResetCustomerAction.RESET:
                    await Task.Run(() => Reset());
                    break;
                default:
                    break;
            }
        }

        private async Task GetCustomerByUserId()
        {
            if (!string.IsNullOrEmpty(_state.Customer?.Id)) return;
            var customer = await _customerService.GetByUserId();
            _state = new CustomerState(customer);
            BroadcastStateChange();
        }

        private void Reset()
        {
            _state = new CustomerState(new CustomerDto());
        }
    }
}
