using AMP.Web.Models.Services.Extensions;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace AMP.Web.Models
{
    public static class DependencyInjection
    {
        
        public static IServiceCollection AddStorage(this IServiceCollection services)
        {
            services.AddScoped<LocalStorageService>();
            return services;
        }
    }
}