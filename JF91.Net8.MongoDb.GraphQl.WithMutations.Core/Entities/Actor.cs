using MongoDB.Bson.Serialization.Attributes;

namespace JF91.Net8.MongoDb.GraphQl.WithMutations.Core.Entities;

public class Actor
{
    [BsonElement("firstName")]
    public string FirstName { get; set; }
    
    [BsonElement("lastName")]
    public string LastName { get; set; }
    
    [BsonElement("roles")]
    public IEnumerable<Role> Roles { get; set; }
}