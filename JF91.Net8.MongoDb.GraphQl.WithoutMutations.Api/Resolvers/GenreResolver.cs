using JF91.Net8.MongoDb.GraphQl.WithoutMutations.Core.Entities;
using JF91.Net8.MongoDb.GraphQl.WithoutMutations.Core.Repositories;

namespace JF91.Net8.MongoDb.GraphQl.WithoutMutations.Api.Resolvers;

[ExtendObjectType(Name = "Genre")]
public class GenreResolver
{
    public Task<Genre> GetGenreAsync(
        [Parent] Movie movie,
        [Service] IGenreRepo genreRepo) => genreRepo.GetByIdAsync(movie.GenreId);
}