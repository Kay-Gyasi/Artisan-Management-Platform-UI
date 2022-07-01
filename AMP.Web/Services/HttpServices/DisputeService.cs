namespace AMP.Web.Services.HttpServices;

[Service]
public class DisputeService
{
    private readonly IHttpRequestBase _http;

    public DisputeService(IHttpRequestBase http)
    {
        _http = http;
    }
}