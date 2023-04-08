
namespace Cosmic.Playground.Core.Models;

//public readonly record struct DailyTemperature(double HighTemp, double LowTemp);
public record TemperatureRecord(DateTime Time, double Temperature)
{
}

