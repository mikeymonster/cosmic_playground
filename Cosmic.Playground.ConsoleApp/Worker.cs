using Cosmic.Playground.Core.Constants;
using Cosmic.Playground.Core.Interfaces;
using Humanizer;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Cosmic.Playground.ConsoleApp;

public class Worker : BackgroundService
{
    private readonly ICallableThing _thing;
    private readonly IDataGenerator _dataGenerator;
    private readonly IMessageQueueService _messageQueueService;
    private readonly ILogger<Worker> _logger;

    public Worker(
        ICallableThing thing,
        IDataGenerator dataGenerator,
        IMessageQueueService messageQueueService,
        ILogger<Worker> logger)
    {
        _messageQueueService = messageQueueService ?? throw new ArgumentNullException(nameof(messageQueueService));
        _dataGenerator = dataGenerator ?? throw new ArgumentNullException(nameof(dataGenerator));
        _thing = thing ?? throw new ArgumentNullException(nameof(thing));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var counter = 0;
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await Task.Delay(1000, stoppingToken);
            _thing.DisplayMessage($"This is the {(++counter).ToOrdinalWords()} time through the loop");

            await _messageQueueService.Push("Well hello there");

            var temperature = _dataGenerator.GenerateTemperatureRecord();
            await _messageQueueService.Push(temperature, Queues.TemperatureItemsQueue);
        }
    }
}
