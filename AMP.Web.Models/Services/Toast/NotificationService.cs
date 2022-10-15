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
        public void ShowSignupComplete() 
            => _toastService.ShowSuccess("Signup completed. Please log in");

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
        
        public void ShowSetCostFailed() 
            => _toastService.ShowSuccess("Cost set operation failed");

        public void DeleteFailed() 
            => _toastService.ShowError("Delete failed");

        public void ShowAssignArtisanFailure() 
            => _toastService.ShowError("Assignment failed");

        public void LoginFailure() =>
            _toastService.ShowError("Invalid credentials");

        public void SignupFailure() =>
            _toastService.ShowError("Registration failed. Please try again");

        public void PhoneExists() =>
            _toastService.ShowInfo("User with given Phone number exists. Please log in");
        public void ShowInvalidPhone() =>
            _toastService.ShowError("Please enter a valid phone number");

        public void ShowInvalidAmountSent() =>
            _toastService.ShowWarning("Invalid amount sent");
        
        public void CostNotSet() =>
            _toastService.ShowInfo("Cost not set on this order by assigned artisan");

        public void ShowImageUploadStartup() => _toastService.ShowInfo("Image upload starting... Changes will be reflected on next login");

        public void ShowInvalidFile() => _toastService.ShowError("Input file is invalid!");
        
        public void ShowArtisanNotComplete()
            => _toastService.ShowError("The artisan has not completed the order!");

        public void CodeSendSuccess() 
            => _toastService.ShowSuccess("Code send success!");
        
        public void CodeSendFailure() 
            => _toastService.ShowError("Code send failure!");

        public void SendPassResetSuccess()
            => _toastService.ShowSuccess("Please check your sms for a link to reset your password");
        
        public void SendPassResetFailed()
            => _toastService.ShowError("Phone entered was not found");

        public void PassResetSuccess()            
            => _toastService.ShowSuccess("Password has been reset successfully");
        
        public void PassResetFailed()            
            => _toastService.ShowError("Password reset failed");

        public void SendInviteSuccess()
            => _toastService.ShowSuccess("Invite has been sent successfully");
        
        public void SendInviteFailed()
            => _toastService.ShowError("Invite send failed");
    }
}
