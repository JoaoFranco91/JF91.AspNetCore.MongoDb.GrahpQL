using HotChocolate.Subscriptions;
using JF91.Net8.MongoDb.GraphQl.WithMutations.Core.Entities;
using JF91.Net8.MongoDb.GraphQl.WithMutations.Core.Repositories;

namespace JF91.Net8.MongoDb.GraphQl.WithMutations.Api.Mutations;

[ExtendObjectType(Name = "Mutation")]
public class MovieMutation
{
    public async Task<Movie> CreateMovieAsync(Movie product, [Service] IMovieRepo movieRepo, 
        [Service] ITopicEventSender eventSender)
    {
        var result = await movieRepo.InsertAsync(product);

        await eventSender.SendAsync(nameof(Subscriptions.MovieSubscription.OnCreateAsync), result);

        return result;
    }

    public async Task<bool> RemoveMovieAsync(string id, [Service] IMovieRepo movieRepo, [Service] ITopicEventSender
        eventSender)
    {
        var result = await movieRepo.RemoveAsync(id);

        if (result)
        {
            await eventSender.SendAsync(nameof(Subscriptions.MovieSubscription.OnRemoveAsync), id);
        }

        return result;
    }
}