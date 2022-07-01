using Kessewa.Extension.Shared.HttpServices.Models;
using Qface.Extension.Shared.HttpServices;

namespace AMP.Web.Services.HttpServices.Base;

public interface IHttpRequestBase
{
    Task<ApiResultModel<T>> GetRequestAsync<T>(string path, CancellationToken cancellationToken);
    Task<RequestResponse> DeleteRequestAsync(string path, CancellationToken cancellationToken);
    Task<RequestResponse> PutRequestAsync<TPayload>(string path, TPayload payload,
        CancellationToken cancellationToken);
    Task<RequestResponse> PostRequestAsync<TPayload>(string path, TPayload payload,
        CancellationToken cancellationToken);
    Task<PaginatedList<ApiResultModel<T>>> GetPageRequestAsync<T>(string path, PaginatedQuery payload,
        CancellationToken cancellationToken);
    Task<IAuthorityClaims> GetClaimsAsync();
}