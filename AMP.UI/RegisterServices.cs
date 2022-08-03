using AMP.UI.Authentication;
using AMP.Web.Models;
using AMP.Web.Models.Services;
using AMP.Web.Models.Services.Toast;
using Blazored.LocalStorage;
using Blazored.Modal;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.Authorization;

namespace AMP.UI;

public static class RegisterServices
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.RegisterAutoMapper()
            .AddScoped<NavigationService>()
            .AddHttpContextAccessor()
            .AddBlazoredModal()
            .AddBlazoredToast()
            .AddBlazoredLocalStorage()
            .AddScoped<NotificationService>()
            .RegisterHttpServices()
            .AddStorage()
            .AddAuthentication()
            .AddHttpClient("AmpDevApi", options =>
            {
                options.BaseAddress = new Uri("https://localhost:7149/api/v1/");
            });
        return services;
    }

    private static IServiceCollection RegisterHttpServices(this IServiceCollection services)
    {
        var assembly = typeof(ServiceAttribute).Assembly;
        var definedTypes = assembly.DefinedTypes;
        var httpServices = definedTypes.Where(x =>
            x.IsClass && x.CustomAttributes.FirstOrDefault(a => a.AttributeType == typeof(ServiceAttribute)) !=
            null);

        services.AddScoped<IHttpRequestBase, HttpRequestBase>();

        foreach (var service in httpServices)
        {
            services.AddScoped(service);
        }
        
        return services;
    }

    private static IServiceCollection RegisterAutoMapper(this IServiceCollection services)
    {
        //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        var mapperConfig = new MapperConfiguration(a =>
        {
            a.AddProfile<MapperProfile>();
        });
        var mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);
        return services;
    }

    private static IServiceCollection AddAuthentication(this IServiceCollection services)
    {
        services.AddScoped<TokenServerAuthenticationStateProvider>();
        services.AddScoped<AuthenticationStateProvider>(provider 
            => provider.GetRequiredService<TokenServerAuthenticationStateProvider>());
        services.AddScoped<AuthStateService>();
        return services;
    }
}