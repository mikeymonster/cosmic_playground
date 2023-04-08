using Cosmic.Playground.Core.Models;

namespace Cosmic.Playground.UnitTests.Core.Models;
public class TemperatureRecordTests
{
    [Fact]
    public void TemperatureRecord_Constructor_Sets_Expected_Properties()
    {
        var time = DateTime.UtcNow;
        const double temperature = 21.3;
        var temperatureRecord = new TemperatureRecord(time, temperature);

        temperatureRecord.Time.Should().Be(time);
        temperatureRecord.Time.Kind.Should().Be(DateTimeKind.Utc);

        temperatureRecord.Temperature.Should().Be(temperature);
    }
}
