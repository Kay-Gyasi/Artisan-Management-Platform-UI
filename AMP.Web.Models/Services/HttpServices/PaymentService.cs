using AMP.Web.Models.Services.HttpServices.Base;

namespace AMP.Web.Models.Services.HttpServices
{
    [Service]
    public class PaymentService
    {
        private readonly IHttpRequestBase _http;

        public PaymentService(IHttpRequestBase http)
        {
            _http = http;
        }
    }
}

