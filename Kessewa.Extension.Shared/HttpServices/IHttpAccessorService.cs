using System.Threading;
using System.Threading.Tasks;
using Kessewa.Extension.Shared.HttpServices.Models;
using Qface.Extension.Shared.HttpServices;

namespace Kessewa.Extension.Shared.HttpServices
{
	public interface IHttpRequestService
	{
		Task<RequestResponse> DeleteRequestAsync(string path, CancellationToken cancellationToken);
		Task<PaginatedList<T>> GetPageRequestAsync<T>(string path, PaginatedQuery payload, CancellationToken cancellationToken);
		Task<T> GetRequestAsync<T>(string path, CancellationToken cancellationToken);
		Task<RequestResponse> PostRequestAsync<TPayload>(string path, TPayload payload, CancellationToken cancellationToken);
		Task<RequestResponse> PutRequestAsync<TPayload>(string path, TPayload payload, CancellationToken cancellationToken);
		Task<IAuthorityClaims> GetClaimsAsync();
	}

}
