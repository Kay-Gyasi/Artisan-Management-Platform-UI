using Microsoft.AspNetCore.Components;

namespace AMP.Web.Models.Services.Extensions
{
    public class NavigationService
    {
        private readonly NavigationManager _navManager;
        public NavigationService(NavigationManager navManager)
        {
            _navManager = navManager;
        }

        public string GetBaseAddress()
        {
            return _navManager.BaseUri + "sample-data/";
        }

        public void NavigateToLanding() => _navManager.NavigateTo(_navManager.BaseUri);

        public string IsActive(string keyword) => _navManager.Uri.Contains(keyword) ? "active" : "";

        public string IsDashboard()
        {
            return _navManager.ToAbsoluteUri(_navManager.Uri).ToString() == _navManager.BaseUri ? "active" : "";
        }

        public void NavigateToArtisanProfileOverview() => _navManager.NavigateTo("/account/artisan/overview");
        public void NavigateToCustomerViewArtisanProfile(int artisanId) => _navManager.NavigateTo($"/customers/view-artisan/{artisanId}");
        public void NavigateToCustomerViewArtisanForOrder(int artisanId, int orderId) => _navManager.NavigateTo($"/customers/view-artisan/{artisanId}/{orderId}");
        public void NavigateToCustomerProfileOverview() => _navManager.NavigateTo("/account/customer/overview");
        public void NavigateToArtisanProfileSettings() => _navManager.NavigateTo("/account/artisan/settings");
        public void NavigateToArtisanBusinessSettings() => _navManager.NavigateTo("/account/artisan/business");
        public void NavigateToCustomerProfileSettings() => _navManager.NavigateTo("/account/customer/settings");
        public void NavigateToCustomerProposals() => _navManager.NavigateTo("/customers/proposals");
        public void NavigateToViewArtisans() => _navManager.NavigateTo("/users/artisans");
        public void NavigateToViewCustomers() => _navManager.NavigateTo("/users/customers");
        public void NavigateToSearchUser() => _navManager.NavigateTo("/users/search");
        public void NavigateToApprovalWaitlist() => _navManager.NavigateTo("/users/artisans/waitlist");
        public void NavigateToOrderList() => _navManager.NavigateTo("/orders");
        public void NavigateToAddReview() => _navManager.NavigateTo("/customer/review");
        public void NavigateToCustomerDisputes() => _navManager.NavigateTo("/customer/disputes");
        public void NavigateToOrderDetail(int orderId) => _navManager.NavigateTo($"/orders/{orderId}");
        public void NavigateToScheduleDetail(int orderId) => _navManager.NavigateTo($"/artisan/schedule/{orderId}");
        public void NavigateToProposalDetail(int orderId) => _navManager.NavigateTo($"/artisan/proposals/{orderId}");
        public void NavigateToArtisanOrderList() => _navManager.NavigateTo("/artisan/proposals");
        public void NavigateToArtisanSchedule() => _navManager.NavigateTo("/artisan/schedule");
        public void NavigateToCustomerOrderList() => _navManager.NavigateTo("customers/orders");
        public void NavigateToViewOrderDetail(int orderId) => _navManager.NavigateTo($"customers/orders/{orderId}");
        public void NavigateToAddOrder() => _navManager.NavigateTo("customers/add-order");
        public void NavigateToDashboard() => _navManager.NavigateTo("dashboard");
        public void NavigateToAssignOrderToArtisan(int id) => _navManager.NavigateTo($"customers/assign-order/{id}");
    }
}

