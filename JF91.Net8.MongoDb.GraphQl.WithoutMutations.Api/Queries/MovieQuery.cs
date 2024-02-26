using JF91.Net8.MongoDb.GraphQl.WithoutMutations.Core.Entities;
using JF91.Net8.MongoDb.GraphQl.WithoutMutations.Core.Repositories;

namespace JF91.Net8.MongoDb.GraphQl.WithoutMutations.Api.Queries;

[ExtendObjectType(Name = "Query")]
public class MovieQuery
{
    public Task<IEnumerable<Movie>> GetMoviesAsync([Service] IMovieRepo movieRepo) =>
        movieRepo.GetAllAsync();

    public Task<Movie> GetMovieById(string id, [Service] IMovieRepo movieRepo) =>
        movieRepo.GetByIdAsync(id);
}