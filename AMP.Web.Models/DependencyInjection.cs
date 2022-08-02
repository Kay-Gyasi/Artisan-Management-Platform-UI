using AMP.Web.Models.Services.Extensions;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace AMP.Web.Models
{
    //https://stackoverflow.com/questions/62529029/customizing-the-authenticationstateprovider-in-blazor-server-app-with-jwt-token
    public static class DependencyInjection
    {
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
}