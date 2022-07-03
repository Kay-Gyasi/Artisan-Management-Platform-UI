using AMP.Web.Services.HttpServices.Base;

namespace AMP.Web.Services.HttpServices;

[Service]
public class CustomerService
{
    private readonly IHttpRequestBase _http;

    public CustomerService(IHttpRequestBase http)
    {
        _http = http;
    }

    public async Task<CustomerDto?> GetAsync(int loggedInUserId)
    {
        var user = await _http.GetRequestAsync<List<CustomerDto?>>("customer.json", new CancellationToken());
        return user.Result.FirstOrDefault(x => x?.UserId == loggedInUserId) ?? null;
    }
}