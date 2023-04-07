using Cosmic.Playground.ConsoleApp;
using Cosmic.Playground.Core;
using Cosmic.Playground.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddTransient<ICallingThing, SomeClass>();
        services.AddTransient<ICallableThing, SomeClass2>();
        //services.AddHttpClient();
        //services.AddDbContext<MyDbContext>();
        services.AddHostedService<Worker>();

    })
    .Build();

await host.RunAsync();