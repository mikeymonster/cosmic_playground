using System.Text.Json;
using Azure.Storage.Queues;
using Cosmic.Playground.Core.Constants;
using Cosmic.Playground.Core.Interfaces;

namespace Cosmic.Playground.Core.Services;
public class MessageQueueService : IMessageQueueService
{
    private readonly QueueServiceClient _queueServiceClient;

    public MessageQueueService(QueueServiceClient queueServiceClient)
    {
        _queueServiceClient = queueServiceClient;
    }

    public async Task Push(string message)
    {
        try
        {
            var client = await GetOrCreateQueueClient(Queues.StringItemsQueue);

            await client
                .SendMessageAsync(message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task Push<T>(T item, string queueName)
    {
        try
        {
            var client = await GetOrCreateQueueClient(queueName);

            var message = JsonSerializer.Serialize(item, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            await client
                .SendMessageAsync(message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private async Task<QueueClient> GetOrCreateQueueClient(string queueName)
    {
        var queueClient = _queueServiceClient.GetQueueClient(queueName);
        await queueClient.CreateIfNotExistsAsync();

        return queueClient;
    }
}
