using JF91.Net8.MongoDb.GraphQl.WithoutMutations.Core.Entities;

namespace JF91.Net8.MongoDb.GraphQl.WithoutMutations.Core.Repositories;

public interface IBaseRepo<T> where T : BaseEntity
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(string id);
}