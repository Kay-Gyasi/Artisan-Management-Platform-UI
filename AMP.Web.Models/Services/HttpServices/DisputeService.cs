using System.Threading;
using System.Threading.Tasks;
using AMP.Web.Models.Commands;
using AMP.Web.Models.Dtos;
using AMP.Web.Models.PageDtos;
using AMP.Web.Models.Services.HttpServices.Base;
using Kessewa.Extension.Shared.HttpServices.Models;

namespace AMP.Web.Models.Services.HttpServices
{
    [Service]
    public class DisputeService
    {
        private readonly IHttpRequestBase _http;

        public DisputeService(IHttpRequestBase http)
        {
            _http = http;
        }

        public async Task<RequestResponse> Save(DisputeCommand command)
            => await _http.PostRequestAsync("dispute/save", command, new CancellationToken());
        
        public async Task<DisputeCount> GetOpenDisputeCount()
            => await _http.GetRequestAsync<DisputeCount>("dispute/GetOpenDisputeCount", new CancellationToken());

        public async Task<PaginatedList<DisputePageDto>> GetPage(PaginatedQuery paginated)
            => await _http.GetPageRequestAsync<DisputePageDto>("dispute/getPage", paginated, new CancellationToken());

        public async Task<DisputeDto> GetAsync(string disputeId)
            => await _http.GetRequestAsync<DisputeDto>($"dispute/get/{disputeId}",
                new CancellationToken());
    }
}

