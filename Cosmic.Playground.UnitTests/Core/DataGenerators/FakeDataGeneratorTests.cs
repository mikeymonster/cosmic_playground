using Cosmic.Playground.UnitTests.Core.Builders;
using Cosmic.Playground.Core.Interfaces;
using Cosmic.Playground.Core.DataGenerators;

namespace Cosmic.Playground.UnitTests.Core.DataGenerators;
public class FakeDataGeneratorTests
{
    [Fact]
    public void Push_String_Queues_Message_Successfully()
    {
        var newId = (new Guid("b16c3792-f259-4065-90b0-d962f05a55da"));
        var currentTime =
            new DateTime(2023, 04, 8, 16, 12, 30, 333,
                DateTimeKind.Utc);

        var dateTimeProvider = Substitute.For<IDateTimeProvider>();
        dateTimeProvider.UtcNow
            .Returns(currentTime);

        var guidProvider = Substitute.For<IGuidProvider>();
        guidProvider.NewGuid()
            .Returns(newId);

        var service = FakeDataGeneratorBuilder.Build(dateTimeProvider);

        var temperature = service.GenerateTemperatureRecord();

        temperature.Id.Should().Be(newId);

        temperature.Time.Should().Be(currentTime);
        temperature.Time.Kind.Should().Be(DateTimeKind.Utc);

        temperature.Temperature.Should().BeGreaterOrEqualTo(FakeDataGenerator.MinimumTemperature);
        temperature.Temperature.Should().BeLessThanOrEqualTo(FakeDataGenerator.MaximumTemperature);
    }
}
