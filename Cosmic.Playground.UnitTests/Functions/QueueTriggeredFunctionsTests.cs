using Cosmic.Playground.UnitTests.Functions.Builders;
using Cosmic.Playground.Core.Models;

namespace Cosmic.Playground.UnitTests.Functions;
public class QueueTriggeredFunctionsTests
{
    [Fact]
    public void Process_String_Queue_Runs_Successfully()
    {
        var functions = QueueTriggeredFunctionsBuilder.Build();

        const string message = "Test message";

        functions.ProcessStringQueue(message);
    }

    [Fact]
    public async Task Process_Temperature_Queue_Runs_Successfully()

    {
        var functions = QueueTriggeredFunctionsBuilder.Build();

        var time = DateTime.UtcNow;
        const double temperature = 21.3;
        var temperatureRecord = new TemperatureRecord(time, temperature);

        await functions.ProcessTemperatureQueue(temperatureRecord);

    }
}
