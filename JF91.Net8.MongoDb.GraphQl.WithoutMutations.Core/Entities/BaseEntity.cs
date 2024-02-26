using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace JF91.Net8.MongoDb.GraphQl.WithoutMutations.Core.Entities;

public class BaseEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
}