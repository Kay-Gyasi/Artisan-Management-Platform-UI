using Microsoft.AspNetCore.Components;

namespace AMP.Web.Services.Extensions;

public class NavigationService
{
    // TODO:: Change all IDs to Guids for security reasons
    private readonly NavigationManager _navManager;
    public NavigationService(NavigationManager navManager)
    {
        _navManager = navManager;
    }

    public string GetBaseAddress()
    {
        return _navManager.BaseUri + "sample-data/";
    }

    public void NavigateToDashboard()
    {
        _navManager.NavigateTo(_navManager.BaseUri);
    }
    public string IsActive(string keyword) => _navManager.Uri.Contains(keyword) ? "active" : "";

    public string IsDashboard()
    {
        return _navManager.ToAbsoluteUri(_navManager.Uri).ToString() == _navManager.BaseUri ? "active" : "";
    }

    public void NavigateToArtisanProfileOverview() => _navManager.NavigateTo("/account/artisan/overview");
    public void NavigateToCustomerProfileOverview() => _navManager.NavigateTo("/account/customer/overview");
    public void NavigateToArtisanProfileSettings() => _navManager.NavigateTo("/account/artisan/settings");
    public void NavigateToArtisanBusinessSettings() => _navManager.NavigateTo("/account/artisan/business");
    public void NavigateToCustomerProfileSettings() => _navManager.NavigateTo("/account/customer/settings");
    public void NavigateToViewArtisans() => _navManager.NavigateTo("/users/artisans");
    public void NavigateToViewCustomers() => _navManager.NavigateTo("/users/customers");
    public void NavigateToSearchUser() => _navManager.NavigateTo("/users/search");
    public void NavigateToApprovalWaitlist() => _navManager.NavigateTo("/users/artisans/waitlist");
    public void NavigateToOrderList() => _navManager.NavigateTo("/orders");
    public void NavigateToOrderDetail(int orderId) => _navManager.NavigateTo($"/orders/{orderId}");
    public void NavigateToScheduleDetail(int orderId) => _navManager.NavigateTo($"/schedule/{orderId}");
    public void NavigateToProposalDetail(int orderId) => _navManager.NavigateTo($"/proposals/{orderId}");
    public void NavigateToArtisanOrderList() => _navManager.NavigateTo("/proposals");
    public void NavigateToArtisanSchedule() => _navManager.NavigateTo("/schedule");
    public void NavigateToCustomerOrderList() => _navManager.NavigateTo("customers/orders");
    public void NavigateToViewOrderDetail(int orderId) => _navManager.NavigateTo($"customers/orders/{orderId}");
    public void NavigateToAddOrder() => _navManager.NavigateTo("customers/add-order");
}