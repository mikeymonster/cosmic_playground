using Cosmic.Playground.Core.Configuration;
using Cosmic.Playground.Core.Constants;
using Cosmic.Playground.Core.Interfaces;
using Cosmic.Playground.Core.Providers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Cosmic.Playground.Core.Extensions;

namespace Cosmic.Playground.Functions;
public class Program
{
    public static void Main()
    {
        var host = new HostBuilder()
            .ConfigureFunctionsWorkerDefaults()
            .ConfigureServices((hostContext, services) =>
            {
                //var appSettings = hostContext.Configuration.GetSection(Settings.AppSettingsSection);
                var cosmosConfiguration = new CosmosDbConfiguration
                {
                    ConnectionString = Environment.GetEnvironmentVariable("CosmosConfiguration_ConnectionString"),
                    Account = Environment.GetEnvironmentVariable("CosmosConfiguration_Account"),
                    Key = Environment.GetEnvironmentVariable("CosmosConfiguration_Key"),
                    DatabaseName = Environment.GetEnvironmentVariable("CosmosConfiguration_DatabaseName"),
                    ContainerName = Environment.GetEnvironmentVariable("CosmosConfiguration_ContainerName")
                };

                services
                    .AddSingleton<IDateTimeProvider, DateTimeProvider>()
                    .AddSingleton<IGuidProvider, GuidProvider>();

                services.AddSingleton<ICosmosDbService>(
                    CosmosDbInitializationExtensions
                        .InitializeCosmosClientInstance(cosmosConfiguration)
                        .GetAwaiter()
                        .GetResult());
            })
            .Build();

        host.Run();
    }
}