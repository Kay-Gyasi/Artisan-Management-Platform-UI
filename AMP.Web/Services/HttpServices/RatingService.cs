namespace AMP.Web.Services.HttpServices;

[Service]
public class RatingService
{
    private readonly IHttpRequestBase _http;

    public RatingService(IHttpRequestBase http)
    {
        _http = http;
    }
}