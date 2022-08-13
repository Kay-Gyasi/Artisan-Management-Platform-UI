using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Kessewa.Extension.Shared.HttpServices.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using RestSharp;

namespace Kessewa.Extension.Shared.HttpServices
{

    // TODO:: Change implementations
    public class HttpRequestService : IHttpRequestService
	{


		private readonly IHttpContextAccessor _httpContextAccessor;

		public HttpRequestService(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;

		}

		public async Task<T> GetRequestAsync<T>(string path, CancellationToken cancellationToken)
		{
			var client = new RestClient();
			var request = new RestRequest(path, Method.GET);
			var claims = await GetClaimsAsync();
			request.AddHeader("Authorization", "Bearer " + claims.Token);
			var response = await client.ExecuteAsync<T>(request, cancellationToken);

			if (response.IsSuccessful)
			{
				return response.Data;
			}


			var error = response.ErrorMessage;

			if (string.IsNullOrEmpty(error))
				error = response.Content.ToString();


			throw new Exception(error);

		}
		//public async Task<(T Data, RequestResponse Error)> GetRequestTupleAsync<T>(string path, CancellationToken cancellationToken)
		//{
		//	var client = new RestClient();
		//	var request = new RestRequest(path, Method.GET);
		//	var claims = await GetClaimsAsync();
		//	request.AddHeader("Authorization", "Bearer " + claims.Token);
		//	var response = await client.ExecuteAsync<T>(request, cancellationToken);

		//	if (response.IsSuccessful)
		//	{
		//		return (response.Data, null);
		//	}


		//	var error = response.ErrorMessage;

		//	if (string.IsNullOrEmpty(error))
		//		error = response.Content.ToString();


		//	return (default, RequestResponse.Error(response.ErrorMessage, response.Content));

		//}

		public async Task<RequestResponse> DeleteRequestAsync(string path, CancellationToken cancellationToken)
		{
			try
			{

				var client = new RestClient();
				var request = new RestRequest(path, Method.DELETE);

				var claims = await GetClaimsAsync();
				request.AddHeader("Authorization", "Bearer " + claims.Token);
				IRestResponse<object> response = await client.ExecuteAsync<object>(request, cancellationToken);
				if (response.IsSuccessful)
				{
					return RequestResponse.Done("Deleted Successfully");
				}
				else
				{
					if (response.StatusCode == HttpStatusCode.BadRequest)
					{
						return RequestResponse.BadRequest(response.Content.Replace("\\", " "));
					}
					else
					{
						return RequestResponse.Error(response.ErrorMessage, response.Content);
					}
				}
			}
			catch (Exception ex)
			{
				return RequestResponse.Error(ex);
			}
		}
		public async Task<RequestResponse> PutRequestAsync<TPayload>(string path, TPayload payload,
			CancellationToken cancellationToken)
		{
			try
			{
				var client = new RestClient();
				var request = new RestRequest(path, Method.PUT);
				request.AddJsonBody(payload);
				var claims = await GetClaimsAsync();
				request.AddHeader("Authorization", "Bearer " + claims.Token);
				IRestResponse<object> response = await client.ExecuteAsync<object>(request, cancellationToken);
				if (response.IsSuccessful)
				{
					return RequestResponse.Done("Updated Successfully");
				}
				else
				{
					if (response.StatusCode == HttpStatusCode.BadRequest)
					{
						return RequestResponse.BadRequest(response.Content.Replace("\\", " "));
					}
					else
					{
						return RequestResponse.Error(response.ErrorMessage, response.Content);
					}
				}
			}
			catch (Exception ex)
			{
				return RequestResponse.Error(ex);
			}
		}

		public async Task<RequestResponse> PostRequestAsync<TPayload>(string path, TPayload payload, CancellationToken cancellationToken)
		{
			try
			{
				var client = new RestClient();
				var request = new RestRequest(path, Method.POST);
				request.AddJsonBody(payload);
				var claims = await GetClaimsAsync();
				request.AddHeader("Authorization", "Bearer " + claims.Token);
				IRestResponse<object> response = await client.ExecuteAsync<object>(request, cancellationToken);
				if (response.IsSuccessful)
				{
					return RequestResponse.Done("Added Successfully");
				}
				else
				{
					if (response.StatusCode == HttpStatusCode.BadRequest)
					{
						return RequestResponse.BadRequest(response.Content.Replace("\\", " "));
					}
					else
					{
						return RequestResponse.Error(response.ErrorMessage, response.Content);
					}
				}
			}
			catch (Exception ex)
			{
				return RequestResponse.Error(ex);
			}
		}
		public async Task<PaginatedList<T>> GetPageRequestAsync<T>(string path, PaginatedQuery payload, CancellationToken cancellationToken)
		{
			var client = new RestClient();
			var request = new RestRequest(path, Method.POST);
			request.AddJsonBody(payload);
			var claims = await GetClaimsAsync();
			request.AddHeader("Authorization", "Bearer " + claims.Token);
			var paged = await client.ExecuteAsync<PaginatedList<T>>(request, cancellationToken);

			if (paged.IsSuccessful)
			{
				return paged.Data;
			}
			throw new Exception(paged.Content);

		}

		public async Task<IAuthorityClaims> GetClaimsAsync()
		{
			return new IAuthorityClaims
			{
				Token = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token")
			};
		}


	}


}


