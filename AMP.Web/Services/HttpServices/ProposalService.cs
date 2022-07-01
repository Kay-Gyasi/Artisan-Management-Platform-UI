namespace AMP.Web.Services.HttpServices;

[Service]
public class ProposalService
{
    private readonly IHttpRequestBase _http;

    public ProposalService(IHttpRequestBase http)
    {
        _http = http;
    }
}