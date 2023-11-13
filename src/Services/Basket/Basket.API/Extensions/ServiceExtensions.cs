using Basket.API.Repositories;
using Basket.API.Services;
using Discount.Grpc.Protos;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace Basket.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void ProjectSettings(this IServiceCollection services, IConfiguration configuration)
        {
            // left hand side == right hand side.
            //configuration["some_key"] == configuration.GetValue<string>("some_key");
            //configuration["some:key"] == configuration.GetValue<string>("some:key");

            // Redis Configuration
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetValue<string>("CacheSettings:ConnectionString");
            });

            // General Configuration
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped<EventService>();
            services.AddAutoMapper(typeof(Startup));

            // Grpc Configuration
            services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>(
                options => options.Address = new Uri(configuration["GrpcSettings:DiscountGrpcServerUrl"]) // grpc server url for client to communicate with it.
            );
            services.AddScoped<DiscountGrpcService>();

            // MassTransit-RabbitMQ Configuration
            services.AddMassTransit(config =>
            {
                config.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(configuration["EventBusSettings:HostAddress"]);
                });
            });
            services.AddMassTransitHostedService();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Basket.API", Version = "v1" });
            });
        }
    }
}
