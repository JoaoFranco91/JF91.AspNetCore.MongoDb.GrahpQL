using JF91.Net8.MongoDb.GraphQl.WithoutMutations.Core.Entities;
using JF91.Net8.MongoDb.GraphQl.WithoutMutations.Core.Repositories;
using JF91.Net8.MongoDb.GraphQl.WithoutMutations.Infrastructure.Data;

namespace JF91.Net8.MongoDb.GraphQl.WithoutMutations.Infrastructure.Repositories;

public class GenreRepo : BaseRepo<Genre>, IGenreRepo
{
    public GenreRepo(IDbContext catalogContext) : base(catalogContext)
    {
    }
}