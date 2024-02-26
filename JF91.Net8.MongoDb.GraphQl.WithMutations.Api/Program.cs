using JF91.Net8.MongoDb.GraphQl.WithMutations.Api.Mutations;
using JF91.Net8.MongoDb.GraphQl.WithMutations.Api.Queries;
using JF91.Net8.MongoDb.GraphQl.WithMutations.Api.Resolvers;
using JF91.Net8.MongoDb.GraphQl.WithMutations.Api.Subscriptions;
using JF91.Net8.MongoDb.GraphQl.WithMutations.Api.Types;
using JF91.Net8.MongoDb.GraphQl.WithMutations.Core.Repositories;
using JF91.Net8.MongoDb.GraphQl.WithMutations.Infrastructure.Configurations;
using JF91.Net8.MongoDb.GraphQl.WithMutations.Infrastructure.Data;
using JF91.Net8.MongoDb.GraphQl.WithMutations.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configurations
var apiConfiguration = new MongoDbConfiguration();
builder.Configuration.GetSection(nameof(MongoDbConfiguration)).Bind(apiConfiguration);
builder.Services.AddSingleton(apiConfiguration);

// Repositories
builder.Services.AddSingleton<IDbContext, DbContext>();
builder.Services.AddScoped(typeof(IBaseRepo<>), typeof(BaseRepo<>));
builder.Services.AddScoped<IMovieRepo, MovieRepo>();

builder.Services
    .AddGraphQLServer()
    .AddQueryType(d => d.Name("Query"))
    .AddTypeExtension<MovieQuery>()
    .AddTypeExtension<GenreQuery>()
    .AddMutationType(d => d.Name("Mutation"))
    .AddTypeExtension<MovieMutation>()
    .AddTypeExtension<GenreMutation>()
    .AddSubscriptionType(d => d.Name("Subscription"))
    .AddTypeExtension<MovieSubscription>()
    .AddType<MovieType>()
    .AddType<GenreResolver>()
    .AddInMemorySubscriptions();

var app = builder.Build();

app.UseWebSockets();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL("/api/graphql");
});

app.Run();