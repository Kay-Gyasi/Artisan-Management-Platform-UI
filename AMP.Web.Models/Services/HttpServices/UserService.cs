using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AMP.Web.Models.Dtos;
using AMP.Web.Models.Services.HttpServices.Base;

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


        public async Task<UserDto> GetAsync(int loggedInUserId)
        {
            var user = await _http.GetRequestAsync<List<UserDto>>("user.json", new CancellationToken());
            return user.Result.FirstOrDefault(x => x.Id == loggedInUserId);
        }
    }
}

