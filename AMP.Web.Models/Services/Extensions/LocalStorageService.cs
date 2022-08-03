using System.Threading;
using System.Threading.Tasks;
using Blazored.LocalStorage;

namespace AMP.Web.Models.Services.Extensions
{
    public class LocalStorageService
    {
        private readonly ILocalStorageService _localStorage;

        public LocalStorageService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public async Task<string> Get(string key) =>
            await _localStorage.GetItemAsStringAsync(key, new CancellationToken());

        public async Task Remove(string key) => await _localStorage.RemoveItemAsync(key);

        public async Task Set(string key, string value) =>
            await _localStorage.SetItemAsStringAsync(key, value, new CancellationToken());
    }
}