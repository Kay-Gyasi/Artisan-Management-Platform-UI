namespace AMP.Web.Services.HttpServices;

[Service]
public class OrderService
{
    private readonly IHttpRequestBase _http;

    public OrderService(IHttpRequestBase http)
    {
        _http = http;
    }
}