using System.Threading.Tasks;
using AMP.Web.Models.Services.Extensions;
using Microsoft.AspNetCore.Components.Authorization;

namespace AMP.Web.Models.Services
{
    public class AuthStateService
    {
        private readonly AuthenticationStateProvider _provider;
        private readonly NavigationService _navigation;

        public AuthStateService(AuthenticationStateProvider provider,
            NavigationService navigation)
        {
            _provider = provider;
            _navigation = navigation;
        }

        public async Task CheckAuthStatus()
        {
            var authState = await _provider.GetAuthenticationStateAsync();
            if (!authState.User.HasClaim(x => x.Value == "AmpWebPlatform")) _navigation.NavigateToLogin();
        }
    }
}

