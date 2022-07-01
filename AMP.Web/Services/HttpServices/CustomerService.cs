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
}