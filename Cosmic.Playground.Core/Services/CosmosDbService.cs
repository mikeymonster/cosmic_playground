using Cosmic.Playground.Core.Interfaces;
using Cosmic.Playground.Core.Models;
using Microsoft.Azure.Cosmos;

namespace Cosmic.Playground.Core.Services;
public class CosmosDbService : ICosmosDbService
{
    private readonly Container _container;

    public CosmosDbService(
        CosmosClient cosmosDbClient,
        string databaseName,
        string containerName)
    {
        if (cosmosDbClient is null) throw new ArgumentNullException(nameof(cosmosDbClient));
        if (databaseName is null) throw new ArgumentNullException(nameof(databaseName));
        if (containerName is null) throw new ArgumentNullException(nameof(containerName));

        _container = cosmosDbClient.GetContainer(databaseName, containerName);
    }

    public async Task Add(TemperatureRecord item)
    {
        await _container.CreateItemAsync(item);
    }
}
