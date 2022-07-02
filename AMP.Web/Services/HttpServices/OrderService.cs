using AMP.Web.Models.Dtos;
using Kessewa.Extension.Shared.HttpServices.Models;

namespace AMP.Web.Services.HttpServices;

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
}