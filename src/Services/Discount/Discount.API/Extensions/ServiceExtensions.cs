using Discount.API.Health;
using Discount.API.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Discount.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void ProjectSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDiscountRepository, DiscountRepository>();

            // Health Checks Configuration
            services
                .AddHealthChecks()
                .AddCheck<NpgSqlHealthCheck>("PostgreHealthCheck");
            // OR
            //services
            //    .AddHealthChecks()
            //    .AddNpgSql(configuration.GetConnectionString("ConnectionString"));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Discount.API", Version = "v1" });
            });
        }
    }
}
