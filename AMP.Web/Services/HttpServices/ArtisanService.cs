using AMP.Web.Models.Dtos;
using AMP.Web.Services.HttpServices.Base;

namespace AMP.Web.Services.HttpServices;

[Service]
public class ArtisanService
{
    private readonly IHttpRequestBase _http;

    public ArtisanService(IHttpRequestBase http)
    {
        _http = http;
    }

    // NOTE:: When registering users save first in the application database and use the Id of the inserted user as a claim
    // in the identity server
    public async Task<ArtisanDto> GetAsync(int loggedInUserId)
    {
        var user = await _http.GetRequestAsync<List<ArtisanDto>>("artisan.json", new CancellationToken());
        return user.Result.FirstOrDefault(x => x.UserId == loggedInUserId);
    }
}