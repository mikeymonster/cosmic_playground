using Microsoft.Extensions.Logging;
using Cosmic.Playground.Functions;
using Cosmic.Playground.Core.Interfaces;
using NSubstitute;

namespace Cosmic.Playground.UnitTests.Functions.Builders;
public static class QueueTriggeredFunctionsBuilder
{
    public static QueueTriggeredFunctions Build(
        ICosmosDbService? cosmosDbService = null,
        ILoggerFactory? loggerFactory = null)
    {
        cosmosDbService ??= Substitute.For<ICosmosDbService>();
        if (loggerFactory is null)
        {
            loggerFactory = Substitute.For<ILoggerFactory>();
            //loggerFactory
            //    .CreateLogger<QueueTriggeredFunctions>()
            //    .Returns(Substitute.For<ILogger<QueueTriggeredFunctions>>());
        }

        return new QueueTriggeredFunctions(
            cosmosDbService,
            loggerFactory);
    }
}
