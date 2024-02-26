using JF91.Net8.MongoDb.GraphQl.WithoutMutations.Core.Helpers;
using MongoDB.Bson.Serialization.Attributes;

namespace JF91.Net8.MongoDb.GraphQl.WithoutMutations.Core.Entities;

[BsonCollection("genres")]
public class Genre : BaseEntity
{
    [BsonElement("name")]
    public string Name { get; set; }
}