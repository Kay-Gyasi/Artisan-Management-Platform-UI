namespace AMP.Web.Services.HttpServices;

[Service]
public class ScheduleService
{
    private readonly IHttpRequestBase _http;

    public ScheduleService(IHttpRequestBase http)
    {
        _http = http;
    }
}