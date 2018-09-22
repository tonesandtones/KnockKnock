using KnockKnock.Api.Commands.Config;
using Microsoft.Extensions.DependencyInjection;

namespace KnockKnock.Api.Function
{
    public static class ConfigurationExtensions
    {
        public static void AddConfiguration(this IServiceCollection services)
        {
            services.AddSingleton<IConfigurationProvider, ConfigurationProvider>();
            
            services.AddTransient(x => x.GetService<IConfigurationProvider>().AppConfig);
        }
    }
}