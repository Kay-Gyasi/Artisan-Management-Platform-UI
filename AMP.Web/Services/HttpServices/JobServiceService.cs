namespace AMP.Web.Services.HttpServices;

[Service]
public class JobServiceService
{
    private readonly IHttpRequestBase _http;

    public JobServiceService(IHttpRequestBase http)
    {
        _http = http;
    }
}