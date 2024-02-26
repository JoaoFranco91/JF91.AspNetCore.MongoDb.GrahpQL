using JF91.Net8.MongoDb.GraphQl.WithoutMutations.Core.Entities;
using JF91.Net8.MongoDb.GraphQl.WithoutMutations.Core.Helpers;
using JF91.Net8.MongoDb.GraphQl.WithoutMutations.Core.Repositories;
using JF91.Net8.MongoDb.GraphQl.WithoutMutations.Infrastructure.Data;
using MongoDB.Driver;

namespace JF91.Net8.MongoDb.GraphQl.WithoutMutations.Infrastructure.Repositories;

public class BaseRepo<T> : IBaseRepo<T> where T : BaseEntity
{
    private readonly IMongoCollection<T> _collection;

    public BaseRepo(IDbContext dbContext)
    {
        if (dbContext == null)
        {
            throw new ArgumentNullException(nameof(dbContext));
        }

        var collectionName = (typeof(T)
            .GetCustomAttributes(typeof(BsonCollectionAttribute), true)
            .FirstOrDefault() as BsonCollectionAttribute).CollectionName;
        
        _collection = dbContext.GetCollection<T>(collectionName);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        var data = await this._collection.Find(_ => true).ToListAsync();
        return data;
    }

    public async Task<T> GetByIdAsync(string id)
    {
        var filter = Builders<T>.Filter.Eq(_ => _.Id, id);

        return await this._collection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<T> InsertAsync(T entity)
    {
        await this._collection.InsertOneAsync(entity);

        return entity;
    }

    public async Task<bool> RemoveAsync(string id)
    {
        var result = await this._collection.DeleteOneAsync(Builders<T>.Filter.Eq(_ => _.Id, id));

        return result.DeletedCount > 0;
    }
    
}