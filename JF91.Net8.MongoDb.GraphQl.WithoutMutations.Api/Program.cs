using JF91.Net8.MongoDb.GraphQl.WithoutMutations.Api.Queries;
using JF91.Net8.MongoDb.GraphQl.WithoutMutations.Api.Resolvers;
using JF91.Net8.MongoDb.GraphQl.WithoutMutations.Api.Types;
using JF91.Net8.MongoDb.GraphQl.WithoutMutations.Core.Repositories;
using JF91.Net8.MongoDb.GraphQl.WithoutMutations.Infrastructure.Configurations;
using JF91.Net8.MongoDb.GraphQl.WithoutMutations.Infrastructure.Data;
using JF91.Net8.MongoDb.GraphQl.WithoutMutations.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configurations
var apiConfiguration = new MongoDbConfiguration();
builder.Configuration.GetSection(nameof(MongoDbConfiguration)).Bind(apiConfiguration);
builder.Services.AddSingleton(apiConfiguration);

// Repositories
builder.Services.AddSingleton<IDbContext, DbContext>();
builder.Services.AddScoped(typeof(IBaseRepo<>), typeof(BaseRepo<>));
builder.Services.AddScoped<IGenreRepo, GenreRepo>();
builder.Services.AddScoped<IMovieRepo, MovieRepo>();

builder.Services
    .AddGraphQLServer()
    .AddQueryType(d => d.Name("Query"))
    .AddTypeExtension<MovieQuery>()
    .AddTypeExtension<GenreQuery>()
    .AddType<MovieType>()
    .AddType<GenreResolver>();


var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL("/api/graphql");
});

app.Run();