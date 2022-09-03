using AMP.Web.Models.Dtos;
using AMP.Web.Models.Services.HttpServices;
using AMP.Web.Models.Stores.Base;
using System.Threading.Tasks;

namespace AMP.Web.Models.Stores.Artisan
{
    public class ArtisanState
    {
        public ArtisanDto Artisan { get; }

        public ArtisanState(ArtisanDto artisan)
        {
            Artisan = artisan;
        }
    }

    public class ArtisanStore : StoreBase
    {
        private readonly ArtisanService _artisanService;
        private ArtisanState _state;

        public ArtisanStore(IActionDispatcher actionDispatcher, ArtisanService artisanService)
        {
            _state = new ArtisanState(new ArtisanDto());            
            _artisanService = artisanService;
            actionDispatcher.Subscribe(HandleActions);
        }

        public ArtisanState GetState()
        {
            return _state;
        }

        private async Task HandleActions(IAction action)
        {
            switch (action.NameOfAction)
            {
                case GetByUserIdAction.GETBYUSERID:
                    await GetArtisanByUserId();
                    break;
                case ResetArtisanAction.RESET:
                    await Task.Run(() => Reset());
                    break;               
                default:
                    break;
            }
        }

        private async Task GetArtisanByUserId()
        {
            if (_state.Artisan.Id > 0) return;
            var artisan = await _artisanService.GetByUserId();
            _state = new ArtisanState(artisan);
            BroadcastStateChange();
        }

        private void Reset()
        {
            _state = new ArtisanState(new ArtisanDto());
        }
    }
}
