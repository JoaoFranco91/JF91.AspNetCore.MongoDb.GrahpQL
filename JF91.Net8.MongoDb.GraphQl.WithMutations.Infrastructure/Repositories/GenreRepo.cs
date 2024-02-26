﻿using JF91.Net8.MongoDb.GraphQl.WithMutations.Core.Entities;
using JF91.Net8.MongoDb.GraphQl.WithMutations.Core.Repositories;
using JF91.Net8.MongoDb.GraphQl.WithMutations.Infrastructure.Data;

namespace JF91.Net8.MongoDb.GraphQl.WithMutations.Infrastructure.Repositories;

public class GenreRepo : BaseRepo<Genre>, IGenreRepo
{
    public GenreRepo(IDbContext catalogContext) : base(catalogContext)
    {
    }
}