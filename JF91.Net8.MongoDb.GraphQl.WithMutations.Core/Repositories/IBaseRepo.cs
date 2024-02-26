using JF91.Net8.MongoDb.GraphQl.WithMutations.Core.Entities;

namespace JF91.Net8.MongoDb.GraphQl.WithMutations.Core.Repositories;

public interface IBaseRepo<T> where T : BaseEntity
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(string id);
    Task<T> InsertAsync(T entity);
    Task<bool> RemoveAsync(string id);
}