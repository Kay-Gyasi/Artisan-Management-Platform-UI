using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AMP.Web.Models.Services.Extensions;
using Microsoft.AspNetCore.Components.Authorization;

namespace AMP.Web.Models.Authentication
{
    public class TokenServerAuthenticationStateProvider :
        AuthenticationStateProvider
    {
        private readonly LocalStorageService _localStorage;
        private const string AuthKey = "authKey";

        public TokenServerAuthenticationStateProvider(LocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public async Task<string> GetTokenAsync()
            => await _localStorage.Get(AuthKey);

        public async Task SetTokenAsync(string? token)
        {
            if (string.IsNullOrEmpty(token))
            {
                await _localStorage.Remove(AuthKey);
                NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
                return;
            }

            await _localStorage.Set(AuthKey, token);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }


        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var token = await GetTokenAsync();
                IEnumerable<Claim> claims = new List<Claim>();
                if (!string.IsNullOrEmpty(token))
                {
                    claims = ServiceExtensions.ParseClaimsFromJwt(token);
                    var enumerable = claims as Claim[] ?? claims.ToArray();
                    var role = enumerable?.FirstOrDefault(x =>
                        x.Value is "Administrator" or "Artisan" or "Customer" or "Developer");
                    claims = enumerable?.Append(new Claim(ClaimTypes.Role, role?.Value ?? ""));
                }
                var identity = string.IsNullOrEmpty(token)
                    ? new ClaimsIdentity()
                    : new ClaimsIdentity(claims, "jwt");

                return new AuthenticationState(new ClaimsPrincipal(identity));
            }
            catch (InvalidOperationException ex)
            {
                return null;
            }            
        }

        
    }
}