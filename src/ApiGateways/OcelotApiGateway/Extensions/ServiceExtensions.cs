using Microsoft.Extensions.DependencyInjection;
using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;

namespace OcelotApiGateway.Extensions
{
    public static class ServiceExtensions
    {
        public static void ProjectSettings(this IServiceCollection services)
        {
            // Ocelot Configuration
            services
                .AddOcelot()
                .AddCacheManager(settings => settings.WithDictionaryHandle());

        }
    }
}
