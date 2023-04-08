
namespace Cosmic.Playground.Core.Models;

public record TemperatureRecord(DateTime Time, double Temperature)
{
    public Guid Id { get; init; }
}

