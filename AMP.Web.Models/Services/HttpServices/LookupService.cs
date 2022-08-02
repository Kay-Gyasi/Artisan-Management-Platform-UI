using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AMP.Web.Models.Enums;
using AMP.Web.Models.Services.HttpServices.Base;
using AMP.Web.Models.ViewModels;

namespace AMP.Web.Models.Services.HttpServices
{
    [Service]
    public class LookupService
    {
        private readonly IHttpRequestBase _http;

        public LookupService(IHttpRequestBase http)
        {
            _http = http;
        }

        public async Task<List<Lookup>> Get(LookupType type)
        {
            return await _http.GetRequestAsync<List<Lookup>>($"lookup/get/{type}", new CancellationToken());
        }

    }
}