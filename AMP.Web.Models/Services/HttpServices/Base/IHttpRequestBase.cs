using System.Threading;
using System.Threading.Tasks;
using AMP.Web.Models.Commands;
using AMP.Web.Models.Dtos;
using Kessewa.Extension.Shared.HttpServices.Models;

namespace AMP.Web.Models.Services.HttpServices.Base
{
    public interface IHttpRequestBase
    {
        Task<T> GetRequestAsync<T>(string path, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteRequestAsync(string path, CancellationToken cancellationToken);
        Task<RequestResponse> PutRequestAsync<TPayload>(string path, TPayload payload,
            CancellationToken cancellationToken);
        Task<RequestResponse> PostRequestAsync<TPayload>(string path, TPayload payload,
            CancellationToken cancellationToken);
        Task<PaginatedList<T>> GetPageRequestAsync<T>(string path, PaginatedQuery payload,
            CancellationToken cancellationToken);
        Task<SigninResponse?> PostLoginAsync(SigninCommand command, CancellationToken cancellationToken);
        //Task<IAuthorityClaims> GetClaimsAsync();
        Task<InsertOrderResponse> PostOrderAsync(string path, OrderCommand command, CancellationToken cancellationToken);
        Task<bool> UploadImageAsync(string filePath, string token, CancellationToken cancellationToken);
    }
}

