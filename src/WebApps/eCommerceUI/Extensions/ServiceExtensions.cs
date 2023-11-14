using eCommerceUI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace eCommerceUI.Extensions
{
    public static class ServiceExtensions
    {
        public static void ProjectSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<ICatalogService, CatalogService>(c =>
                c.BaseAddress = new Uri(configuration["ApiSettings:GatewayAddress"]));
            services.AddHttpClient<IBasketService, BasketService>(c =>
                c.BaseAddress = new Uri(configuration["ApiSettings:GatewayAddress"]));
            services.AddHttpClient<IOrderService, OrderService>(c =>
                c.BaseAddress = new Uri(configuration["ApiSettings:GatewayAddress"]));

            services.AddRazorPages();
        }
    }
}
