namespace Cosmic.Playground.Core.Interfaces;
public interface IMessageQueueService
{
    Task Push(string message);

    Task Push<T>(T item, string queueName);
}
