using JF91.Net8.MongoDb.GraphQl.WithoutMutations.Api.Resolvers;
using JF91.Net8.MongoDb.GraphQl.WithoutMutations.Core.Entities;

namespace JF91.Net8.MongoDb.GraphQl.WithoutMutations.Api.Types;

public class MovieType : ObjectType<Movie>
{
    protected override void Configure(IObjectTypeDescriptor<Movie> descriptor)
    {
        descriptor.Field(_ => _.Id);
        descriptor.Field(_ => _.Name);
        descriptor.Field(_ => _.Year);
        descriptor.Field(_ => _.GenreId);
        descriptor.Field(_ => _.Actors);
        
        // Creates the relationship between Product x Category
        descriptor.Field<GenreResolver>(_ => _.GetGenreAsync(default, default));
    }
}