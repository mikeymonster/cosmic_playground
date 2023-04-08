using Cosmic.Playground.UnitTests.Core.Builders;
using Cosmic.Playground.Core.Interfaces;
using Cosmic.Playground.Core.DataGenerators;

namespace Cosmic.Playground.UnitTests.Core.DataGenerators;
public class FakeDataGeneratorTests
{
    [Fact]
    public void Push_String_Queues_Message_Successfully()
    {
        var currentTime =
            new DateTime(2023, 04, 8, 16, 12, 30, 333,
                DateTimeKind.Utc);

        var dateTimeProvider = Substitute.For<IDateTimeProvider>();
        dateTimeProvider.UtcNow
            .Returns(currentTime);

        var service = FakeDataGeneratorBuilder.Build(dateTimeProvider);

        var temperature = service.GenerateTemperatureRecord();

        temperature.Time.Should().Be(currentTime);
        temperature.Time.Kind.Should().Be(DateTimeKind.Utc);

        temperature.Temperature.Should().BeGreaterOrEqualTo(FakeDataGenerator.MinimumTemperature);
        temperature.Temperature.Should().BeLessThanOrEqualTo(FakeDataGenerator.MaximumTemperature);
    }
}
