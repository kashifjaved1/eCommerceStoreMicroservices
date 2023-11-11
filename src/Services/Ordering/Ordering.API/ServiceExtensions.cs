using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Ordering.Application;
using Ordering.Infrastructure;

namespace Ordering.API
{
    public static class ServiceExtensions
    {
        public static void ProjectSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ordering.API", Version = "v1" });
            });

            services.AddApplicationServices();
            services.AddInfrastructureServices(configuration);
        }
    }
}
