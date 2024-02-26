using JF91.Net8.MongoDb.GraphQl.WithMutations.Core.Entities;

namespace JF91.Net8.MongoDb.GraphQl.WithMutations.Api.Subscriptions;

[ExtendObjectType(Name = "Subscription")]
public class MovieSubscription
{
    [Subscribe]
    [Topic]
    public Task<Movie> OnCreateAsync([EventMessage] Movie movie) =>
        Task.FromResult(movie);

    [Subscribe]
    [Topic]
    public Task<string> OnRemoveAsync([EventMessage] string movieId) =>
        Task.FromResult(movieId);
}