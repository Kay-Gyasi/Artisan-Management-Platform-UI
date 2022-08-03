using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace AMP.UI.Authentication;

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

    public async Task SetTokenAsync(string token)
    {
        if (token is null)
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
        var token = await GetTokenAsync();
        IEnumerable<Claim> claims = new List<Claim>();
        if (!string.IsNullOrEmpty(token))
        {
            claims = ServiceExtensions.ParseClaimsFromJwt(token);
            var role = claims.FirstOrDefault(x =>
                x.Value is "Administrator" or "Artisan" or "Customer");
            claims = claims.Append(new Claim(ClaimTypes.Role, role.Value));
        }
        var identity = string.IsNullOrEmpty(token)
            ? new ClaimsIdentity()
            : new ClaimsIdentity(claims, "jwt");
        return new AuthenticationState(new ClaimsPrincipal(identity));
    }
}