using System.Threading.Tasks;
using AMP.Web.Models.Services.Extensions;
using Microsoft.AspNetCore.Components.Authorization;

namespace AMP.Web.Models.Services
{
    public class AuthService
    {
        private readonly AuthenticationStateProvider _provider;
        private readonly NavigationService _navigation;

        public AuthService(AuthenticationStateProvider provider,
            NavigationService navigation)
        {
            _provider = provider;
            _navigation = navigation;
        }

        public async Task<bool> CheckAuthStatus()
        {
            var authState = await _provider.GetAuthenticationStateAsync();
            if (!authState.User.HasClaim(x => x.Value == "AmpWebPlatform"))
            {
                _navigation.NavigateToLogin();
                return false;
            }
            return true;
        }

        public async Task<string?> GetClaim(string claim)
        {
            var authState = await _provider.GetAuthenticationStateAsync();
            return authState.User.FindFirst(claim)?.Value;
        }

    }
}

