using System.IO;
using KnockKnock.Api.Commands.Config;
using Microsoft.Extensions.Configuration;

namespace KnockKnock.Api.Function
{
    public interface IConfigurationProvider
    {
        IAppConfig AppConfig { get; }
    }
    
    public class ConfigurationProvider : IConfigurationProvider
    {
        public IAppConfig AppConfig { get; }

        public ConfigurationProvider()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            var configuration = builder.Build();

            var appConfig = new AppConfig();
            configuration.Bind(appConfig);
            AppConfig = appConfig;
        }
    }
}