using Cosmic.Playground.Core.Interfaces;
using Humanizer;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Cosmic.Playground.ConsoleApp;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly ICallableThing _thing;

    public Worker(
        ICallableThing thing, 
        ILogger<Worker> logger)
    {
        _logger = logger;
        _thing = thing ?? throw new ArgumentNullException(nameof(thing));
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        int counter = 0;
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await Task.Delay(1000, stoppingToken);
           _thing.DisplayMessage($"This is the {(++counter).ToOrdinalWords()} time through the loop");

           
        }
    }
}
