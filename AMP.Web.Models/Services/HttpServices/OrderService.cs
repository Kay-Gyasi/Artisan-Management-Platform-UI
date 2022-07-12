using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AMP.Web.Models.Dtos;
using AMP.Web.Models.Services.HttpServices.Base;

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

        public async Task<List<OrderDto?>> GetAllAsync()
        {
            var orders = await _http.GetRequestAsync<List<OrderDto?>>("order.json",
                new CancellationToken());
            return orders.Result;
        }

        public async Task<OrderDto?> GetAsync(int orderId)
        {
            var orders = await _http.GetRequestAsync<List<OrderDto>>("order.json",
                new CancellationToken());
            return orders.Result.FirstOrDefault(a => a.Id == orderId);
        }
    }
}

