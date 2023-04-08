using Azure.Identity;
using Azure.Storage.Queues;
using Cosmic.Playground.ConsoleApp;
using Cosmic.Playground.Core.Configuration;
using Cosmic.Playground.Core.Constants;
using Cosmic.Playground.Core.DataGenerators;
using Cosmic.Playground.Core.Extensions;
using Cosmic.Playground.Core.Interfaces;
using Cosmic.Playground.Core.Providers;
using Cosmic.Playground.Core.Services;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;

IConfigurationRoot _configuration = null;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(config =>
        {
            // ReSharper disable StringLiteralTypo
            config.AddJsonFile("appsettings.json", false)
                .AddJsonFile("appsettings.Development.json", true)
                //.Build()
                ;
            // ReSharper restore StringLiteralTypo

            _configuration = config.Build();
        }
    )
    .ConfigureServices((hostContext, services) =>
    {
        var appSettings = hostContext.Configuration.GetSection(Settings.AppSettingsSection);
        //var cosmosConfiguration = hostContext
        //    .Configuration
        //    .GetSection(Settings.CosmosConfiguration)
        //    //.Bind<CosmosDbConfiguration>()
        //    ;
        // services.Configure(cosmosConfiguration);
        var cosmosConfiguration = new CosmosDbConfiguration();
        hostContext.Configuration.Bind("CosmosConfiguration", cosmosConfiguration);      //  <--- This

        services
            .AddSingleton<IDateTimeProvider, DateTimeProvider>()
            .AddSingleton<IGuidProvider, GuidProvider>()
            .AddSingleton<IDataGenerator, FakeDataGenerator>()
            .AddTransient<ICallingThing, SomeClass>()
            .AddTransient<ICallableThing, SomeClass2>()
            .AddTransient<IMessageQueueService, MessageQueueService>();

        //services.AddSingleton<ICosmosDbService>(
        //    CosmosDbInitializationExtensions
        //        .InitializeCosmosClientInstance(cosmosConfiguration)
        //        .GetAwaiter()
        //        .GetResult());

        //https://stackoverflow.com/questions/68931330/use-azure-storage-queues-in-asp-net-configure-for-di
        services.AddAzureClients(builder =>
        {
            // Use the environment credential by default
            builder.UseCredential(new DefaultAzureCredential());

            var storageQueueConnectionString = appSettings[Settings.StorageQueueConnectionString];

            builder.AddQueueServiceClient(storageQueueConnectionString)
                .ConfigureOptions(c =>
                    c.MessageEncoding = QueueMessageEncoding.Base64);
        });
        
        //services.AddHttpClient();
        //services.AddDbContext<MyDbContext>();
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();

