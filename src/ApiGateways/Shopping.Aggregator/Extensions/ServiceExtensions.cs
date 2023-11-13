using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Shopping.Aggregator.Services;
using System;

namespace Shopping.Aggregator.Extensions
{
    public static class ServiceExtensions
    {
        public static void ProjectSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Shopping.Aggregator", Version = "v1" });
            });

            // IHttpClientFactory TypedClients consumption pattern. Read more at: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-5.0
            services.AddHttpClient<ICatalogService, CatalogService>(c =>
            {
                c.BaseAddress = new Uri(configuration["ApiSettings:CatalogUrl"]);
            });

            services.AddHttpClient<IBasketService, BasketService>(c =>
                c.BaseAddress = new Uri(configuration["ApiSettings:BasketUrl"]));

            services.AddHttpClient<IOrderService, OrderService>(c =>
                c.BaseAddress = new Uri(configuration["ApiSettings:OrderingUrl"]));
        }
    }
}
