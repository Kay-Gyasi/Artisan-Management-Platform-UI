using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AMP.Web.Models.Dtos;
using AMP.Web.Models.Services.HttpServices.Base;

namespace AMP.Web.Models.Services.HttpServices
{
    [Service]
    public class CustomerService
    {
        private readonly IHttpRequestBase _http;

        public CustomerService(IHttpRequestBase http)
        {
            _http = http;
        }

        public async Task<CustomerDto> GetAsync(string id)
        {
            return await _http.GetRequestAsync<CustomerDto>
                ($"customer/get/{id}", new CancellationToken());
        }

        public async Task<CustomerDto> GetByUserId()
        {
            return await _http.GetRequestAsync<CustomerDto>("customer/GetByUser",
                new CancellationToken());
        }
    }
}

