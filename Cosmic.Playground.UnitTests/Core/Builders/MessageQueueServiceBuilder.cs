using Azure.Storage.Queues;
using Cosmic.Playground.Core.Services;

namespace Cosmic.Playground.UnitTests.Core.Builders;
public static class MessageQueueServiceBuilder
{
    public static MessageQueueService Build(
        QueueServiceClient? queueServiceClient = null)
    {
        queueServiceClient ??= Substitute.For<QueueServiceClient>();

        return new MessageQueueService(queueServiceClient);
    }
}
