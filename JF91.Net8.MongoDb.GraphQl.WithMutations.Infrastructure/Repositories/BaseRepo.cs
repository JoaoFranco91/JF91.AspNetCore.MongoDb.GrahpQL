using JF91.Net8.MongoDb.GraphQl.WithMutations.Core.Entities;
using JF91.Net8.MongoDb.GraphQl.WithMutations.Core.Helpers;
using JF91.Net8.MongoDb.GraphQl.WithMutations.Core.Repositories;
using JF91.Net8.MongoDb.GraphQl.WithMutations.Infrastructure.Data;
using MongoDB.Driver;

namespace JF91.Net8.MongoDb.GraphQl.WithMutations.Infrastructure.Repositories;

public class BaseRepo<T> : IBaseRepo<T> where T : BaseEntity
{
    private readonly IMongoCollection<T> _collection;

    public BaseRepo(IDbContext dbContext)
    {
        if (dbContext == null)
        {
            throw new ArgumentNullException(nameof(dbContext));
        }

        _collection = dbContext.GetCollection<T>((typeof(T)
                .GetCustomAttributes(typeof(BsonCollectionAttribute), true)
                .FirstOrDefault() as BsonCollectionAttribute).CollectionName
        );
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        var data = await _collection.Find(_ => true).ToListAsync();
        return data;
    }

    public async Task<T> GetByIdAsync(string id)
    {
        var filter = Builders<T>.Filter.Eq(_ => _.Id, id);

        return await _collection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<T> InsertAsync(T entity)
    {
        await _collection.InsertOneAsync(entity);

        return entity;
    }

    public async Task<bool> RemoveAsync(string id)
    {
        var result = await _collection.DeleteOneAsync(Builders<T>.Filter.Eq(_ => _.Id, id));

        return result.DeletedCount > 0;
    }
}