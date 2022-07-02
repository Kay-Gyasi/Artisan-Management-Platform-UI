using System.Net;
using System.Net.Http.Json;
using AMP.Web.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using System.Net.Http;
using Kessewa.Extension.Shared.HttpServices.Models;
using Qface.Extension.Shared.HttpServices;
using AMP.Web.Services.Extensions;

namespace AMP.Web.Services.HttpServices.Base;

public class HttpRequestBase : IHttpRequestBase
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly NavigationService _navigator;

    public HttpRequestBase(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor,
        NavigationService navigator)
    {
        _httpClientFactory = httpClientFactory;
        _httpContextAccessor = httpContextAccessor;
        _navigator = navigator;
    }

    public async Task<ApiResultModel<T>> GetRequestAsync<T>(string path, CancellationToken cancellationToken)
    {
        try
        {
            using var client = CreateClient();
            var request = await client.GetAsync(path, cancellationToken);
            if (request.IsSuccessStatusCode)
                return await request.Content.ReadFromJsonAsync<ApiResultModel<T>>(cancellationToken: cancellationToken);

            throw new HttpRequestFailedException($"{nameof(GetRequestAsync)} for {nameof(T)} failed!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<RequestResponse> DeleteRequestAsync(string path, CancellationToken cancellationToken)
    {
        try
        {
            using var client = CreateClient();
            var request = await client.DeleteAsync(path, cancellationToken);
            if(request.IsSuccessStatusCode)
                return RequestResponse.Done("Deleted Successfully");

            return request.StatusCode == HttpStatusCode.BadRequest
                ? RequestResponse.BadRequest(request.ReasonPhrase)
                : RequestResponse.Error(request.ReasonPhrase);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<RequestResponse> PutRequestAsync<TPayload>(string path, TPayload payload, CancellationToken cancellationToken)
    {
        try
        {
            using var client = CreateClient();
            var request = await client.PutAsJsonAsync(path, payload, cancellationToken);
            if (request.IsSuccessStatusCode)
                return RequestResponse.Done("Deleted Successfully");

            return request.StatusCode == HttpStatusCode.BadRequest
                ? RequestResponse.BadRequest(request.ReasonPhrase)
                : RequestResponse.Error(request.ReasonPhrase);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<RequestResponse> PostRequestAsync<TPayload>(string path, TPayload payload, CancellationToken cancellationToken)
    {
        try
        {
            using var client = CreateClient();
            var request = await client.PostAsJsonAsync(path, payload, cancellationToken);
            if (request.IsSuccessStatusCode)
                return RequestResponse.Done("Deleted Successfully");

            return request.StatusCode == HttpStatusCode.BadRequest
                ? RequestResponse.BadRequest(request.ReasonPhrase)
                : RequestResponse.Error(request.ReasonPhrase);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<PaginatedList<ApiResultModel<T>>> GetPageRequestAsync<T>(string path, PaginatedQuery payload, CancellationToken cancellationToken)
    {
        try
        {
            using var client = CreateClient();
            var request = await client.PostAsJsonAsync(path, payload, cancellationToken);
            if (request.IsSuccessStatusCode)
                return await request.Content.ReadFromJsonAsync<PaginatedList<ApiResultModel<T>>>(cancellationToken: cancellationToken);

            throw new HttpRequestFailedException($"{nameof(GetPageRequestAsync)} for {nameof(T)} failed!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IAuthorityClaims> GetClaimsAsync()
    {
        return new IAuthorityClaims
        {
            Token = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token")
        };
    }

    private HttpClient CreateClient()
    {
        var client = _httpClientFactory.CreateClient();
        client.BaseAddress = new Uri(_navigator.GetBaseAddress());
        return client;
    }
}