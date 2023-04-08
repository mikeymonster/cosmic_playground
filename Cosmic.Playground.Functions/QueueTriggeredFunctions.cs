using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Cosmic.Playground.Core.Constants;
using Cosmic.Playground.Core.Models;

namespace Cosmic.Playground.Functions;

public class QueueTriggeredFunctions
{
    private readonly ILogger _logger;

    public QueueTriggeredFunctions(ILoggerFactory loggerFactory)
    {
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
        _logger.LogInformation($"{Queues.TemperatureItemsQueue} trigger function processed: {item}");
    }
}