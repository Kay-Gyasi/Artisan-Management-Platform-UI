using AMP.Web.Models.Dtos;

namespace AMP.Web.Services.HttpServices;

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