using JF91.Net8.MongoDb.GraphQl.WithMutations.Core.Entities;
using JF91.Net8.MongoDb.GraphQl.WithMutations.Core.Repositories;

namespace JF91.Net8.MongoDb.GraphQl.WithMutations.Api.Queries;

[ExtendObjectType(Name = "Query")]
public class MovieQuery
{
    public Task<IEnumerable<Movie>> GetMoviesAsync([Service] IMovieRepo movieRepo) =>
        movieRepo.GetAllAsync();

    public Task<Movie> GetMovieAsync(string id, [Service] IMovieRepo movieRepo) =>
        movieRepo.GetByIdAsync(id);
}