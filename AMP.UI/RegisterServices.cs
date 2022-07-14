namespace AMP.UI;

public static class RegisterServices
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.RegisterAutoMapper()
            .AddScoped<NavigationService>()
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