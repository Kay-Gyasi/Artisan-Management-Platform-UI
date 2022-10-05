using AMP.Web.Models.Commands;
using AMP.Web.Models.Dtos;
using AMP.Web.Models.PageDtos;
using AMP.Web.Models.Services.HttpServices.Base;
using Kessewa.Extension.Shared.HttpServices.Models;
using System.Threading;
using System.Threading.Tasks;

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

        public async Task<PaginatedList<RatingPageDto>> GetCustomerPage(PaginatedQuery paginated)
            => await _http.GetPageRequestAsync<RatingPageDto>("rating/GetCustomerPage", paginated, new CancellationToken());
        
        public async Task<PaginatedList<RatingPageDto>> GetArtisanRatingPage(PaginatedQuery paginated)
            => await _http.GetPageRequestAsync<RatingPageDto>("rating/GetArtisanRatingPage", paginated, new CancellationToken());

        public async Task<RatingDto> Get(string id)
            => await _http.GetRequestAsync<RatingDto>($"rating/get/{id}", new CancellationToken());

        public async Task<RequestResponse> Save(RatingCommand command)
            => await _http.PostRequestAsync("rating/save", command, new CancellationToken());

        public async Task<RequestResponse> Delete(string id)
            => await _http.DeleteRequestAsync($"rating/delete/{id}", new CancellationToken());
    }
}

