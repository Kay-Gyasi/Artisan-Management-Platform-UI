using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AMP.Web.Models.Dtos;
using AMP.Web.Models.Services.HttpServices.Base;
namespace AMP.Web.Models.Services.HttpServices
{
    [Service]
    public class ProposalService
    {
        private readonly IHttpRequestBase _http;

        public ProposalService(IHttpRequestBase http)
        {
            _http = http;
        }

        public async Task<List<ProposalDto?>> GetAllAsync()
        {
            var orders = await _http.GetRequestAsync<List<ProposalDto?>>("proposal.json",
                new CancellationToken());
            return orders.Result;
        }
    }
}

