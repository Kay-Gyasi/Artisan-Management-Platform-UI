using AMP.Web.Models.Services.HttpServices.Base;

namespace AMP.Web.Models.Services.HttpServices
{
    [Service]
    public class RatingService
    {
        private readonly IHttpRequestBase _http;

        public RatingService(IHttpRequestBase http)
        {
            _http = http;
        }
    }
}

