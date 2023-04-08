using Microsoft.Extensions.Logging;
using Cosmic.Playground.Functions;

namespace Cosmic.Playground.UnitTests.Functions.Builders;
public static class QueueTriggeredFunctionsBuilder
{
    public static QueueTriggeredFunctions Build(
        ILoggerFactory? loggerFactory = null)
    {
        loggerFactory ??= Substitute.For<ILoggerFactory>();

        return new QueueTriggeredFunctions(loggerFactory);
    }
}
