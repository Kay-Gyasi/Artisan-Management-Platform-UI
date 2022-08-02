using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AMP.Web.Models.Commands;
using AMP.Web.Models.Dtos;
using AMP.Web.Models.Services.HttpServices.Base;
using Kessewa.Extension.Shared.HttpServices.Models;

namespace AMP.Web.Models.Services.HttpServices
{
    [Service]
    public class UserService
    {
        private readonly IHttpRequestBase _http;

        public UserService(IHttpRequestBase http)
        {
            _http = http;
        }


        public async Task<UserDto> GetAsync(int userId)
        {
            return await _http.GetRequestAsync<UserDto>($"user/get/{userId}", new CancellationToken());
        }

        public async Task<RequestResponse> Save(UserCommand command)
        {
            return await _http.PostRequestAsync("user/save", command, new CancellationToken());
        }

        public async Task<RequestResponse> Delete(int id)
        {
            return await _http.DeleteRequestAsync($"user/delete/{id}", new CancellationToken());
        }
    }
}

