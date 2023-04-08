using Cosmic.Playground.Core.Constants;
using Cosmic.Playground.Core.Interfaces;
using Cosmic.Playground.Core.Models;
using Humanizer;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Cosmic.Playground.ConsoleApp;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IMessageQueueService _messageQueueService;
    private readonly ICallableThing _thing;

    public Worker(
        ICallableThing thing,
        IMessageQueueService messageQueueService,
        ILogger<Worker> logger)
    {
        _logger = logger;
        _messageQueueService = messageQueueService ?? throw new ArgumentNullException(nameof(messageQueueService));
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

           await _messageQueueService.Push("Well hello there");

           var temperature = new TemperatureRecord(DateTime.UtcNow, 101);
           await _messageQueueService.Push(temperature, Queues.TemperatureItemsQueue);
        }
    }
}
