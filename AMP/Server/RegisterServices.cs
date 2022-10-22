﻿using AMP.Web.Models;
using AMP.Web.Models.Authentication;
using AMP.Web.Models.Services;
using AMP.Web.Models.Services.Extensions;
using AMP.Web.Models.Services.HttpServices;
using AMP.Web.Models.Services.HttpServices.Base;
using AMP.Web.Models.Services.Toast;
using AMP.Web.Models.Services.Workers;
using AutoMapper;
using Blazored.LocalStorage;
using Blazored.Modal;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.Authorization;

namespace AMP.Server;

public static class RegisterServices
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
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
            .AddPaymentService()
            .AddStores()
            .AddAuthentication()
            //.AddWorkers()
            .AddHttpClient("AmpClient", options =>
            {
                 options.BaseAddress = new Uri(configuration["DevApiUrl"] ?? string.Empty);
                 //options.BaseAddress = new Uri(configuration["ProdApiUrl"] ?? string.Empty);
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
        services.AddAuthorizationCore();
        services.AddScoped<TokenServerAuthenticationStateProvider>();
        services.AddScoped<AuthenticationStateProvider>(provider 
            => provider.GetRequiredService<TokenServerAuthenticationStateProvider>());
        services.AddScoped<AuthService>();
        return services;
    }

    private static IServiceCollection AddWorkers(this IServiceCollection services)
    {
        services.AddHostedService<FileToServerUpload>();
        // services.Configure<HostOptions>(options =>
        // {
        //     options.BackgroundServiceExceptionBehavior = BackgroundServiceExceptionBehavior.StopHost;
        // });
        return services;
    }
}