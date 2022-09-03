using AMP.Web.Models.Payments;
using AMP.Web.Models.Services.Extensions;
using AMP.Web.Models.Stores;
using AMP.Web.Models.Stores.Artisan;
using AMP.Web.Models.Stores.Customer;
using AMP.Web.Models.Stores.Order;
using Microsoft.Extensions.DependencyInjection;

namespace AMP.Web.Models
{
    public static class DependencyInjection
    {
        
        public static IServiceCollection AddStorage(this IServiceCollection services)
        {
            services.AddScoped<LocalStorageService>()
                .AddScoped<IPaymentService, PaymentsService>();
            return services;
        }

        public static IServiceCollection AddStores(this IServiceCollection services)
        {
            services.AddScoped<ArtisanStore>()
                .AddScoped<CustomerStore>()
                .AddScoped<CustomerStore>()
                .AddScoped<OrderStore>()
                .AddScoped<IActionDispatcher, ActionDispatcher>();
            return services;
        }
    }
}