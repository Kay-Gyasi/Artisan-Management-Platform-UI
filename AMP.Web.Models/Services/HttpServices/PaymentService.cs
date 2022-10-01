using System.Threading;
using System.Threading.Tasks;
using AMP.Web.Models.Commands;
using AMP.Web.Models.PageDtos;
using AMP.Web.Models.Services.HttpServices.Base;
using Kessewa.Extension.Shared.HttpServices.Models;

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

        public async Task<RequestResponse> Save(PaymentCommand command)
            => await _http.PostRequestAsync("payment/save", command, new CancellationToken());

        public async Task<RequestResponse> Verify(VerifyPaymentCommand command)
            => await _http.PutRequestAsync("payment/verify", command, new CancellationToken());

        public async Task<PaginatedList<PaymentPageDto>> GetPage(PaginatedQuery paginated)
            => await _http.GetPageRequestAsync<PaymentPageDto>("payment/getPage", paginated, new CancellationToken());
    }
}

