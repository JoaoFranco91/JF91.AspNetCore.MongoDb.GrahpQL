using JF91.Net8.MongoDb.GraphQl.WithoutMutations.Core.Entities;
using JF91.Net8.MongoDb.GraphQl.WithoutMutations.Core.Repositories;
using JF91.Net8.MongoDb.GraphQl.WithoutMutations.Infrastructure.Data;

namespace JF91.Net8.MongoDb.GraphQl.WithoutMutations.Infrastructure.Repositories;

public class MovieRepo : BaseRepo<Movie>, IMovieRepo
{
    public MovieRepo(IDbContext dbContext) : base(dbContext)
    {
    }
}