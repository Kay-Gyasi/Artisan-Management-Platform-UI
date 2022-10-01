using System.Linq;
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

        public string GetBaseAddress() => _navManager.BaseUri;

        public void NavigateToLanding() => _navManager.NavigateTo(_navManager.BaseUri);

        public string IsActive(string keyword) 
            => _navManager.Uri == $"{_navManager.BaseUri}{keyword}" ? "active" : "";

        public void NavigateToArtisanProfileOverview() => _navManager.NavigateTo("/account/artisan/overview");
        public void NavigateToCustomerViewArtisanProfile(string artisanId) => _navManager.NavigateTo($"/customers/view-artisan/{artisanId}");
        public void NavigateToCustomerViewArtisanForOrder(string artisanId, string orderId) => _navManager.NavigateTo($"/customers/view-artisan/{artisanId}/{orderId}");
        public void NavigateToCustomerViewArtisanRating(string artisanId, string orderId) => _navManager.NavigateTo($"/customers/view-artisan/reviews/{artisanId}/{orderId}");
        public void NavigateToCustomerProfileOverview() => _navManager.NavigateTo("/account/customer/overview");
        public void NavigateToArtisanProfileSettings() => _navManager.NavigateTo("/account/artisan/settings");
        public void NavigateToArtisanBusinessSettings() => _navManager.NavigateTo("/account/artisan/business");
        public void NavigateToArtisanReviews() => _navManager.NavigateTo("/account/artisan/reviews");
        public void NavigateToCustomerProfileSettings() => _navManager.NavigateTo("/account/customer/settings");
        public void NavigateToCustomerProposals() => _navManager.NavigateTo("/customers/proposals");
        public void NavigateToViewArtisans() => _navManager.NavigateTo("/users/artisans");
        public void NavigateToViewCustomers() => _navManager.NavigateTo("/users/customers");
        public void NavigateToSearchUser() => _navManager.NavigateTo("/users/search");
        public void NavigateToApprovalWaitlist() => _navManager.NavigateTo("/users/artisans/waitlist");
        public void NavigateToOrderList() => _navManager.NavigateTo("/orders");
        public void NavigateToReviews() => _navManager.NavigateTo("/customer/reviews");
        public void NavigateToAddReview() => _navManager.NavigateTo("/customer/add-review");
        public void NavigateToEditReview(string id) => _navManager.NavigateTo($"/customer/edit-review/{id}");
        public void NavigateToCustomerDisputes() => _navManager.NavigateTo("/customer/disputes");
        public void NavigateToOrderDetail(string orderId) => _navManager.NavigateTo($"/orders/{orderId}");
        public void NavigateToScheduleDetail(string orderId) => _navManager.NavigateTo($"/artisan/schedule/{orderId}");
        public void NavigateToScheduleDetailForceLoad(string orderId) => _navManager.NavigateTo($"/artisan/schedule/{orderId}", true);
        public void NavigateToRequestDetail(string orderId) => _navManager.NavigateTo($"/artisans/requests/{orderId}");
        public void NavigateToProposalDetail(string orderId) => _navManager.NavigateTo($"/artisan/proposals/{orderId}");
        public void NavigateToOrderRequests() => _navManager.NavigateTo("/artisans/requests");
        public void NavigateToArtisanSchedule() => _navManager.NavigateTo("/artisan/schedule");
        public void NavigateToArtisanImage() => _navManager.NavigateTo("/artisan/image");
        public void NavigateToCustomerImage() => _navManager.NavigateTo("/customer/image");
        public void NavigateToArtisanHistory() => _navManager.NavigateTo("/artisan/work-history");
        public void NavigateToCustomerOrderList() => _navManager.NavigateTo("customers/orders");
        public void NavigateToCustomerOrderListForceLoad() => _navManager.NavigateTo("customers/orders", true);
        public void NavigateToCustomerOrderHistory() => _navManager.NavigateTo("customers/orders/history");
        public void NavigateToViewOrderDetail(string orderId) => _navManager.NavigateTo($"customers/orders/{orderId}");
        public void NavigateToViewOrderDetailForceLoad(string orderId) => _navManager.NavigateTo($"customers/orders/{orderId}", true);
        public void NavigateToAddOrder() => _navManager.NavigateTo("customers/add-order");
        public void NavigateToDashboard() => _navManager.NavigateTo("dashboard");
        public void NavigateToLogin() => _navManager.NavigateTo("login");
        public void NavigateToLoginForceLoad() => _navManager.NavigateTo("login", true);
        public void NavigateToSignup() => _navManager.NavigateTo("signup");
        public void NavigateToPayments() => _navManager.NavigateTo("payments");
        public void NavigateToArtisanPayments() => _navManager.NavigateTo("artisan/payments");
        public void NavigateToPaymentAuthorizationUrl(string authUrl) => _navManager.NavigateTo(authUrl, true);
        public void NavigateToAssignOrderToArtisan(string id, string service) 
            => _navManager.NavigateTo($"customers/assign-order/{id}/{service}");
    }
}

