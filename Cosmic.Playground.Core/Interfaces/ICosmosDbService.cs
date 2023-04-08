using Cosmic.Playground.Core.Models;

namespace Cosmic.Playground.Core.Interfaces;
public interface ICosmosDbService
{
    Task Add(TemperatureRecord item);
}
