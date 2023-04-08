using System.Text.Json;
using Azure.Storage.Queues;
using Cosmic.Playground.Core.Constants;
using Cosmic.Playground.Core.Models;
using Cosmic.Playground.UnitTests.Core.Builders;

namespace Cosmic.Playground.UnitTests.Core.Services;
public class MessageQueueServiceTests
{
    [Fact]
    public async Task Push_String_Queues_Message_Successfully()
    {
        var queueServiceClient = Substitute.For<QueueServiceClient>();
        var queueClient = Substitute.For<QueueClient>();

        queueServiceClient
            .GetQueueClient(Arg.Any<string>())
            .Returns(queueClient);

        var service = MessageQueueServiceBuilder.Build(queueServiceClient);

        const string message = "Test message";

        await service.Push(message);

        await queueClient
            .Received(1)
            .CreateIfNotExistsAsync();

        await queueClient
            .Received(1)
            .SendMessageAsync(message);
    }

    [Fact]
    public async Task Push_Object_Queues_Message_Successfully()
    {
        var time = DateTime.UtcNow;
        const double temperature = 21.3;
        var temperatureRecord = new TemperatureRecord(time, temperature);
        var serializedTemperatureRecord = JsonSerializer.Serialize(
            temperatureRecord,
            new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

        var queueServiceClient = Substitute.For<QueueServiceClient>();
        var queueClient = Substitute.For<QueueClient>();

        queueServiceClient
            .GetQueueClient(Arg.Any<string>())
            .Returns(queueClient);

        var service = MessageQueueServiceBuilder.Build(queueServiceClient);

        await service.Push(temperatureRecord, Queues.StringItemsQueue);

        await queueClient
            .Received(1)
            .CreateIfNotExistsAsync();

        await queueClient
            .Received(1)
            .SendMessageAsync(serializedTemperatureRecord);
    }
}
