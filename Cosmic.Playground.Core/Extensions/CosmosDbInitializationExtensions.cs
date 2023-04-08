using Cosmic.Playground.Core.Configuration;
using Cosmic.Playground.Core.Services;
using Microsoft.Azure.Cosmos;
using System.Net;

namespace Cosmic.Playground.Core.Extensions;
public static class CosmosDbInitializationExtensions
{
    public static async Task<CosmosDbService> InitializeCosmosClientInstance(CosmosDbConfiguration configuration)
    {
        var client = new CosmosClient(
            //account, key
            configuration.ConnectionString,
            new CosmosClientOptions
            {
                SerializerOptions = new CosmosSerializationOptions()
                {
                    PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase,
                }
            });
        
        var database = await client.CreateDatabaseIfNotExistsAsync(configuration.DatabaseName);

        Console.WriteLine($@"Cosmos DB '{configuration.DatabaseName} {(database.StatusCode == HttpStatusCode.Created ? "created" : "retrieved")}");
        Console.WriteLine($@"    - Etag '{database.ETag}");
        Console.WriteLine($@"    - ActivityId {database.ActivityId}");
        Console.WriteLine($@"    - Charge {database.RequestCharge:#.00}");

        var partitionKey = "/temperatures/id";
        var container = await database.Database.CreateContainerIfNotExistsAsync(configuration.ContainerName, partitionKey);

        Console.WriteLine($@"Cosmos container '{configuration.ContainerName} {(container.StatusCode == HttpStatusCode.Created ? "created" : "retrieved")}");
        Console.WriteLine($@"    - Etag '{container.ETag}");
        Console.WriteLine($@"    - ActivityId {container.ActivityId}");
        Console.WriteLine($@"    - Charge {container.RequestCharge:#.00}");

        var cosmosDbService = new CosmosDbService(client, configuration.DatabaseName, configuration.ContainerName);
        return cosmosDbService;
    }
}
