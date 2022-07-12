using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace AMP.Web;

public static class RegisterServices
{
    public static WebAssemblyHostBuilder RegisterDefaults(this WebAssemblyHostBuilder builder)
    {
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");
        builder.Services.AddScoped(sp => new HttpClient {BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)});

        builder.Services
            .AddServices();
        return builder;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.RegisterAutoMapper()
            .AddSingleton<NavigationService>()
            .AddHttpContextAccessor()
            .AddHttpClient()
            .RegisterHttpServices();
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
        Parallel.ForEach(httpServices, new ParallelOptions() { MaxDegreeOfParallelism = 10 }, service =>
        {
            services.AddScoped(service);
        });

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
}