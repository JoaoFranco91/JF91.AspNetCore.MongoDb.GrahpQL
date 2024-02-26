using MongoDB.Bson.Serialization.Attributes;

namespace JF91.Net8.MongoDb.GraphQl.WithoutMutations.Core.Entities;

public class Role
{
    [BsonElement("name")]
    public string Name { get; set; }
    
    [BsonElement("year")]
    public int Year { get; set; }
}