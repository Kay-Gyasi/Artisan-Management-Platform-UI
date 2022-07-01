namespace AMP.Web.Services.HttpServices;

[Service]
public class PaymentService
{
    private readonly IHttpRequestBase _http;

    public PaymentService(IHttpRequestBase http)
    {
        _http = http;
    }
}