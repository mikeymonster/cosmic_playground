using Cosmic.Playground.Core.Services;
using Microsoft.Azure.Cosmos;

namespace Cosmic.Playground.UnitTests.Core.Builders;
public static class CosmosDbServiceBuilder
{
    public static CosmosDbService Build(
        CosmosClient? cosmosDbClient = null,
        string databaseName = "test_db",
        string containerName = "test_container")
    {
        cosmosDbClient ??= Substitute.For<CosmosClient>();

        return new CosmosDbService(cosmosDbClient, databaseName, containerName);
    }
}
