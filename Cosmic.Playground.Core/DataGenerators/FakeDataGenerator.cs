using Bogus;
using Cosmic.Playground.Core.Interfaces;
using Cosmic.Playground.Core.Models;

namespace Cosmic.Playground.Core.DataGenerators;
public class FakeDataGenerator : IDataGenerator
{
    private readonly Faker<TemperatureRecord> _temperatureFaker;

    public const double MinimumTemperature = -10.0;
    public const double MaximumTemperature = 35.0;

    public FakeDataGenerator(IDateTimeProvider dateTimeProvider)
    {
        //_dateTimeProvider = dateTimeProvider ?? throw new ArgumentNullException(nameof(dateTimeProvider));
        var randomizer = new Randomizer();

        _temperatureFaker = new Faker<TemperatureRecord>()
                .CustomInstantiator(t =>
                    new TemperatureRecord(
                        dateTimeProvider.UtcNow,
                        randomizer.Double(MinimumTemperature, MaximumTemperature)))
                //.RuleFor(t => t.Temperature, _ =>
                //    _random.NextDouble() * (MaximumTemperature - MinimumTemperature) + MinimumTemperature)
                //.RuleFor(t => t.Time, f => _dateTimeProvider.UtcNow)
                ;
    }

    public TemperatureRecord GenerateTemperatureRecord()
    {
        return _temperatureFaker.Generate();
    }
}
