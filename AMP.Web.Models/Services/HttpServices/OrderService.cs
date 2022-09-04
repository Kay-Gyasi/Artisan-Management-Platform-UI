using System.Threading;
using System.Threading.Tasks;
using AMP.Web.Models.Commands;
using AMP.Web.Models.Dtos;
using AMP.Web.Models.PageDtos;
using AMP.Web.Models.Services.HttpServices.Base;
using Kessewa.Extension.Shared.HttpServices.Models;
using Newtonsoft.Json;

namespace AMP.Web.Models.Services.HttpServices
{
    [Service]
    public class OrderService
    {
        private readonly IHttpRequestBase _http;

        public OrderService(IHttpRequestBase http)
        {
            _http = http;
        }

        public async Task<PaginatedList<OrderPageDto>> GetPage(PaginatedQuery query) 
            => await _http.GetPageRequestAsync<OrderPageDto>
                ("order/GetPage", query, new CancellationToken());

        public async Task<PaginatedList<OrderPageDto>> GetSchedulePage(PaginatedQuery query) 
            => await _http.GetPageRequestAsync<OrderPageDto>
                ("order/GetSchedulePage", query, new CancellationToken());
        
        public async Task<PaginatedList<OrderPageDto>> GetRequestPage(PaginatedQuery query) 
            => await _http.GetPageRequestAsync<OrderPageDto>
                ("order/GetRequestPage", query, new CancellationToken());

        public async Task<PaginatedList<OrderPageDto>> GetHistoryPage(PaginatedQuery query) 
            => await _http.GetPageRequestAsync<OrderPageDto>
                ("order/GetHistoryPage", query, new CancellationToken());

        public async Task<PaginatedList<OrderPageDto>> GetOrderHistoryPage(PaginatedQuery query) 
            => await _http.GetPageRequestAsync<OrderPageDto>
                ("order/GetOrderHistoryPage", query, new CancellationToken());

        public async Task<PaginatedList<OrderPageDto>> GetCustomerOrderPage(PaginatedQuery query)
            => await _http.GetPageRequestAsync<OrderPageDto>
                ($"order/GetCustomerOrderPage", query, new CancellationToken());

        public async Task<OrderDto> GetAsync(string id) 
            => await _http.GetRequestAsync<OrderDto>($"order/get/{id}",
                new CancellationToken());
        public async Task<InsertOrderResponse> Insert(OrderCommand command)
        {
            var serializedCommand = JsonConvert.SerializeObject(command);
            return await _http.GetRequestAsync<InsertOrderResponse>($"order/insert/{serializedCommand}",
                new CancellationToken());
        }

        public async Task<RequestResponse> Save(OrderCommand command) 
            => await _http.PostRequestAsync("order/save", command, new CancellationToken());

        public async Task<RequestResponse> UnassignArtisan(string orderId) 
            => await _http.PutRequestAsync("order/unassignArtisan", orderId, new CancellationToken());

        public async Task<RequestResponse> Complete(string orderId) 
            => await _http.PutRequestAsync("order/complete", orderId, new CancellationToken());
        
        public async Task<RequestResponse> ArtisanComplete(string orderId) 
            => await _http.PutRequestAsync("order/artisancomplete", orderId, new CancellationToken());

        public async Task<RequestResponse> Accept(string orderId) 
            => await _http.PutRequestAsync("order/accept", orderId, new CancellationToken());
        
        public async Task<RequestResponse> Cancel(string orderId) 
            => await _http.PutRequestAsync("order/cancel", orderId, new CancellationToken());

        public async Task<RequestResponse> AssignArtisan(string orderId, string artisanId) 
            => await _http.PutRequestAsync($"order/assignArtisan/{artisanId}", orderId, new CancellationToken());

        public async Task<RequestResponse> SoftDelete(string id)
            => await _http.DeleteRequestAsync($"order/delete/{id}", new CancellationToken());
        
        public async Task<RequestResponse> SetCost(SetCostCommand command)
            => await _http.PutRequestAsync("order/setcost", command, new CancellationToken());
    }
}

