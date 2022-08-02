using Blazored.Toast.Services;

namespace AMP.Web.Models.Services.Toast
{
    public class NotificationService
    {
        private readonly IToastService _toastService;

        public NotificationService(IToastService toastService)
        {
            _toastService = toastService;
        }

        public void SaveSuccess() 
            => _toastService.ShowSuccess("Save completed");

        public void SaveFailure() 
            => _toastService.ShowError("Save failed");

        public void ShowUnassignArtisanSuccess()
            => _toastService.ShowSuccess("Unassigned successfully");

        public void ShowUnassignArtisanFailure() 
            => _toastService.ShowError("Unassign failed");

        public void ShowOrderCompleted() 
            => _toastService.ShowSuccess("Order has been completed");

        public void ShowOrderCompleteFailed() 
            => _toastService.ShowSuccess("Order completion failed");

        public void DeleteFailed() 
            => _toastService.ShowError("Delete failed");

        public void ShowAssignArtisanFailure() 
            => _toastService.ShowError("Assignment failed");
    }
}
