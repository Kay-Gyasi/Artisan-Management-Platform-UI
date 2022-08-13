using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using AMP.Web.Models.Authentication;
using AMP.Web.Models.Commands;
using AMP.Web.Models.Services.Extensions;
using Kessewa.Extension.Shared.HttpServices.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace AMP.Web.Models.Services.HttpServices.Base
{
    public class HttpRequestBase : IHttpRequestBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly TokenServerAuthenticationStateProvider _auth;
        private readonly NavigationService _navigationService;

        public HttpRequestBase(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor,
            TokenServerAuthenticationStateProvider auth, NavigationService navigationService)
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
            _auth = auth;
            _navigationService = navigationService;
        }

        public async Task<T> GetRequestAsync<T>(string path, CancellationToken cancellationToken)
        {
            try
            {
                using var client = await CreateClient();
                var request = await client.GetAsync(path, cancellationToken);
                if (request.ReasonPhrase == "Unauthorized")
                {
                    _navigationService.NavigateToLogin();
                    await _auth.SetTokenAsync(null);
                    return default;
                }
                if (request.IsSuccessStatusCode)
                    return await request.Content.ReadFromJsonAsync<T>(cancellationToken: cancellationToken);

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
                using var client = await CreateClient();
                var request = await client.DeleteAsync(path, cancellationToken);
                if (request.ReasonPhrase == "Unauthorized")
                {
                    _navigationService.NavigateToLogin();
                    await _auth.SetTokenAsync(null);
                    return default;
                }
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

        public async Task<RequestResponse> PutRequestAsync<TPayload>(string path, TPayload payload, CancellationToken cancellationToken)
        {
            try
            {
                using var client = await CreateClient();
                var request = await client.PutAsJsonAsync(path, payload, cancellationToken);
                if (request.ReasonPhrase == "Unauthorized")
                {
                    _navigationService.NavigateToLogin();
                    await _auth.SetTokenAsync(null);
                    return default;
                }
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

        public async Task<SigninResponse?> PostLoginAsync(SigninCommand command, CancellationToken cancellationToken)
        {
            try
            {
                using var client = await CreateClient();
                var request = await client.PostAsJsonAsync("user/login", command, cancellationToken);
                if (request.StatusCode == HttpStatusCode.NoContent)
                    return null;
                if (request.IsSuccessStatusCode)
                    return await request.Content.ReadFromJsonAsync<SigninResponse>();
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<RequestResponse> PostRequestAsync<TPayload>(string path, TPayload payload, CancellationToken cancellationToken)
        {
            try
            {
                using var client = await CreateClient();
                var request = await client.PostAsJsonAsync(path, payload, cancellationToken);
                if (request.ReasonPhrase == "Unauthorized")
                {
                    _navigationService.NavigateToLogin();
                    await _auth.SetTokenAsync(null);
                    return default;
                }
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

        public async Task<PaginatedList<T>> GetPageRequestAsync<T>(string path, PaginatedQuery payload, CancellationToken cancellationToken)
        {
            try
            {
                using var client = await CreateClient();
                var request = await client.PostAsJsonAsync(path, payload, cancellationToken);
                if (request.ReasonPhrase == "Unauthorized")
                {
                    _navigationService.NavigateToLogin();
                    await _auth.SetTokenAsync(null);
                    return default;
                }
                if (request.IsSuccessStatusCode)
                    return await request.Content.ReadFromJsonAsync<PaginatedList<T>>(cancellationToken: cancellationToken);

                throw new HttpRequestFailedException($"{nameof(GetPageRequestAsync)} for {nameof(T)} failed!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        //public async Task<IAuthorityClaims> GetClaimsAsync()
        //{
        //    return new IAuthorityClaims
        //    {
        //        Token = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token")
        //    };
        //}

        private async Task<HttpClient> CreateClient()
        {
            var client = _httpClientFactory.CreateClient("AmpDevApi");
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {await _auth.GetTokenAsync()}");
            return client;
        }
    }
}

