using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using AMP.Web.Models.Commands;
using AMP.Web.Models.Services.HttpServices.Base;
using Kessewa.Extension.Shared.HttpServices.Models;

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

        public async Task<RequestResponse> Upload(MultipartFormDataContent command)
        {
            return await _http.PostRequestAsync("image/upload", command, new CancellationToken());
        }
    }
}