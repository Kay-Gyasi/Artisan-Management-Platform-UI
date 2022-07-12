using AMP.Web.Models.Services.HttpServices.Base;

namespace AMP.Web.Models.Services.HttpServices
{
    [Service]
    public class JobServiceService
    {
        private readonly IHttpRequestBase _http;

        public JobServiceService(IHttpRequestBase http)
        {
            _http = http;
        }
    }
}

