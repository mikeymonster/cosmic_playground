using Cosmic.Playground.Core.Constants;
using Cosmic.Playground.Core.Interfaces;
using Cosmic.Playground.Core.Providers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Cosmic.Playground.Functions;
public class Program
{
    public static void Main()
    {
        var host = new HostBuilder()
            .ConfigureFunctionsWorkerDefaults()
            .ConfigureServices((hostContext, services) =>
            {
                var appSettings = hostContext.Configuration.GetSection(Settings.AppSettingsSection);

                services
                    .AddSingleton<IDateTimeProvider, DateTimeProvider>()
                    .AddSingleton<IGuidProvider, GuidProvider>();


            })
            .Build();

        host.Run();
    }
}