using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Cosmic.Playground.Core.Constants;
using Cosmic.Playground.Core.Models;
using Cosmic.Playground.Core.Interfaces;

namespace Cosmic.Playground.Functions;

public class QueueTriggeredFunctions
{
    private readonly ICosmosDbService _cosmosDbService;
    private readonly ILogger<QueueTriggeredFunctions> _logger;

    public QueueTriggeredFunctions(
        ICosmosDbService cosmosDbService,
        ILoggerFactory loggerFactory)
    {
        _cosmosDbService = cosmosDbService ?? throw new ArgumentNullException(nameof(cosmosDbService));

        if (loggerFactory is null) throw new ArgumentNullException(nameof(loggerFactory));
        _logger = loggerFactory.CreateLogger<QueueTriggeredFunctions>();
    }

    [Function("StringQueueFunction")]
    public void ProcessStringQueue(
        [QueueTrigger(Queues.StringItemsQueue, Connection = Settings.StorageQueueConnectionString)] string message)
    {
        _logger.LogInformation($"{Queues.StringItemsQueue} trigger function processed: {message}");
    }

    [Function("TemperatureQueueFunction")]
    public async Task ProcessTemperatureQueue(
        [QueueTrigger(Queues.TemperatureItemsQueue, Connection = Settings.StorageQueueConnectionString)] TemperatureRecord item)
    {
        try
        {
            await _cosmosDbService.Add(item);
            _logger.LogInformation($"{Queues.TemperatureItemsQueue} trigger function processed: {item}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to add item to Cosmos");
        }
    }
}