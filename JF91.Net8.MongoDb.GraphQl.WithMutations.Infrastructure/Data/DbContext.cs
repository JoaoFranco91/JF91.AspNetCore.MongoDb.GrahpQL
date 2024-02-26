using JF91.Net8.MongoDb.GraphQl.WithMutations.Infrastructure.Configurations;
using MongoDB.Driver;

namespace JF91.Net8.MongoDb.GraphQl.WithMutations.Infrastructure.Data;

public class DbContext : IDbContext
{
    private readonly IMongoDatabase _database;

    public DbContext(MongoDbConfiguration mongoDbConfiguration)
    {
        var client = new MongoClient(mongoDbConfiguration.ConnectionString);

        _database = client.GetDatabase(mongoDbConfiguration.Database);
    }

    public IMongoCollection<T> GetCollection<T>(string name)
    {
        return _database.GetCollection<T>(name);
    }
}