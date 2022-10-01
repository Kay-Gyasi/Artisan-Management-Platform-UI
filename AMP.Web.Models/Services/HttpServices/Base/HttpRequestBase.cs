using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AMP.Web.Models.Authentication;
using AMP.Web.Models.Commands;
using AMP.Web.Models.Dtos;
using AMP.Web.Models.Services.Extensions;
using Kessewa.Extension.Shared.HttpServices.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace AMP.Web.Models.Services.HttpServices.Base
{
    public class HttpRequestBase : IHttpRequestBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly TokenServerAuthenticationStateProvider _auth;
        private readonly NavigationService _navigationService;
        private readonly ILogger<HttpRequestBase> _logger;

        public HttpRequestBase(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor,
            TokenServerAuthenticationStateProvider auth, NavigationService navigationService,
            ILogger<HttpRequestBase> logger)
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
            _auth = auth;
            _navigationService = navigationService;
            _logger = logger;
        }

        public async Task<T> GetRequestAsync<T>(string path, CancellationToken cancellationToken)
        {
            try
            {
                using var client = await CreateClient();
                var request = await client.GetAsync(path, cancellationToken);
                if (request.ReasonPhrase == "Unauthorized")
                {
                    _navigationService.NavigateToLoginForceLoad();
                    await _auth.SetTokenAsync(null);
                    return default;
                }
                if (request.IsSuccessStatusCode)
                    return await request.Content.ReadFromJsonAsync<T>(cancellationToken: cancellationToken);

                throw new HttpRequestFailedException($"{nameof(GetRequestAsync)} for {nameof(T)} failed!");
            }
            catch (Exception e)
            {
                _logger.LogError(nameof(GetRequestAsync) + "failed!");
                throw;
            }
        }
        
        public async Task<InsertOrderResponse> PostOrderAsync(string path, OrderCommand command, CancellationToken cancellationToken)
        {
            try
            {
                using var client = await CreateClient();
                var request = await client.PostAsJsonAsync(path, command, cancellationToken);
                if (request.ReasonPhrase == "Unauthorized")
                {
                    _navigationService.NavigateToLoginForceLoad();
                    await _auth.SetTokenAsync(null);
                    return default;
                }
                if (request.IsSuccessStatusCode)
                    return await request.Content.ReadFromJsonAsync<InsertOrderResponse>(cancellationToken: cancellationToken);

                throw new HttpRequestFailedException($"{nameof(GetRequestAsync)} for {nameof(InsertOrderResponse)} failed!");
            }
            catch (Exception e)
            {
                _logger.LogError(nameof(PostOrderAsync) + "failed!");
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
                    _navigationService.NavigateToLoginForceLoad();
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
                _logger.LogError(nameof(DeleteRequestAsync) + "failed!");;
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
                    _navigationService.NavigateToLoginForceLoad();
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
                _logger.LogError(nameof(PutRequestAsync) + "failed!");
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
                    return await request.Content.ReadFromJsonAsync<SigninResponse>(cancellationToken: cancellationToken);
                return null;
            }
            catch (Exception e)
            {
                _logger.LogError(nameof(PostLoginAsync) + "failed!");
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
                    _navigationService.NavigateToLoginForceLoad();
                    await _auth.SetTokenAsync(null);
                    return default;
                }

                if(request.StatusCode == HttpStatusCode.Conflict)
                    return RequestResponse.Error("Phone number already exists");
                if (request.IsSuccessStatusCode)
                    return RequestResponse.Done("Deleted Successfully");

                return request.StatusCode == HttpStatusCode.BadRequest
                    ? RequestResponse.BadRequest(request.ReasonPhrase)
                    : RequestResponse.Error(request.ReasonPhrase);
            }
            catch (Exception e)
            {
                _logger.LogError(nameof(PostRequestAsync) + "failed!");
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
                    _navigationService.NavigateToLoginForceLoad();
                    await _auth.SetTokenAsync(null);
                    return default;
                }
                if (request.IsSuccessStatusCode)
                    return await request.Content.ReadFromJsonAsync<PaginatedList<T>>(cancellationToken: cancellationToken);

                throw new HttpRequestFailedException($"{nameof(GetPageRequestAsync)} for {nameof(T)} failed!");
            }
            catch (Exception e)
            {
                _logger.LogError(nameof(GetPageRequestAsync) + "failed!");
                throw;
            }
        }

        public async Task<bool> UploadImageAsync(string filePath, string token,  CancellationToken cancellationToken)
        {
            try
            {
                var client = new RestClient("http://kofigyasi-001-site2.btempurl.com/api/v1/image/upload")
                {
                    Timeout = -1
                };
                filePath = filePath.Replace(@"\", "/");
                _logger.LogInformation($"FilePath: {filePath}");
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", $"Bearer {token}");
                request.AddFile("file", filePath);
                
                _logger.LogInformation("Beginning upload to API...");
                var response = await client.ExecuteAsync(request, cancellationToken);

                if (!response.IsSuccessful)
                {
                    _logger.LogError($"Error: {response.ErrorMessage ?? ""}");
                    return response.IsSuccessful;
                }
                
                _logger.LogInformation("Upload completed successfully!");
                return response.IsSuccessful;
            }
            catch (Exception e)
            {
                _logger.LogError(nameof(UploadImageAsync) + "failed!");
                throw;
            }
        }

        private async Task<HttpClient> CreateClient()
        {
            var client = _httpClientFactory.CreateClient("AmpDevApi");
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {await _auth.GetTokenAsync()}");
            return client;
        }
    }
}

