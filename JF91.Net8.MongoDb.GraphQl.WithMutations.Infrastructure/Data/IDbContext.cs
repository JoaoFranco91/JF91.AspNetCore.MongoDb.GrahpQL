using MongoDB.Driver;

namespace JF91.Net8.MongoDb.GraphQl.WithMutations.Infrastructure.Data;

public interface IDbContext
{
    IMongoCollection<T> GetCollection<T>(string name);
}