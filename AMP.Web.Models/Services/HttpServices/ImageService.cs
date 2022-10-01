using System.Threading;
using System.Threading.Tasks;
using AMP.Web.Models.Services.HttpServices.Base;

namespace AMP.Web.Models.Services.HttpServices
{
    [Service]
    public class ImageService
    {
        private readonly IHttpRequestBase _http;

        public ImageService(IHttpRequestBase http)
        {
            _http = http;
        }

        public async Task<bool> UploadAsync(string path, string token)
        {
            return await _http.UploadImageAsync(path, token, new CancellationToken());
        }
    }
}