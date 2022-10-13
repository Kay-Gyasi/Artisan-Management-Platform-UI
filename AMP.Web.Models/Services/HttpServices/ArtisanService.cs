using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AMP.Web.Models.Commands;
using AMP.Web.Models.Dtos;
using AMP.Web.Models.PageDtos;
using AMP.Web.Models.Services.HttpServices.Base;
using AMP.Web.Models.ViewModels;
using Kessewa.Extension.Shared.HttpServices.Models;

namespace AMP.Web.Models.Services.HttpServices
{
    [Service]
    public class ArtisanService
    {
        private readonly IHttpRequestBase _http;

        public ArtisanService(IHttpRequestBase http)
        {
            _http = http;
        }

        public async Task<ArtisanDto> GetAsync(string id) =>
            await _http.GetRequestAsync<ArtisanDto>($"artisan/get/{id}",
                new CancellationToken());


        public async Task<ArtisanDto> GetByUserId() =>
            await _http.GetRequestAsync<ArtisanDto>($"artisan/GetByUser",
                new CancellationToken());

        public async Task<List<Lookup>> GetArtisansWorkedForCustomer() =>
            await _http.GetRequestAsync<List<Lookup>>($"artisan/GetArtisansWorkedForCustomer",
                new CancellationToken());

        public async Task<PaginatedList<ArtisanPageDto>> GetPage(PaginatedQuery query) =>
            await _http.GetPageRequestAsync<ArtisanPageDto>
                ("artisan/GetPage", query, new CancellationToken());

        public async Task<RequestResponse> Save(ArtisanCommand command) 
            => await _http.PostRequestAsync("artisan/save", command, new CancellationToken());

        public async Task<RequestResponse> Delete(string id) 
            => await _http.DeleteRequestAsync($"artisan/delete/{id}", new CancellationToken());
    }
}

