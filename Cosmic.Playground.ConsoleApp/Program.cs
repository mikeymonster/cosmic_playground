using Cosmic.Playground.Core;
using Cosmic.Playground.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddTransient<ICallingThing, SomeClass>();
        services.AddTransient<ICallableThing, SomeClass2>();
        //services.AddHttpClient();
        //services.AddDbContext<MyDbContext>();
    })
    .Build();

// code
var myClass = host.Services.GetService<ICallingThing>();
await myClass!.CallSomething();

await host.RunAsync();