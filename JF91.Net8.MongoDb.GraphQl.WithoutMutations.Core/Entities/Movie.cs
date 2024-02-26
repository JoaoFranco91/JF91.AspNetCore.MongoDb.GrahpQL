using JF91.Net8.MongoDb.GraphQl.WithoutMutations.Core.Helpers;
using MongoDB.Bson.Serialization.Attributes;

namespace JF91.Net8.MongoDb.GraphQl.WithoutMutations.Core.Entities;

[BsonCollection("movies")]
public class Movie : BaseEntity
{
    [BsonElement("name")]
    public string Name { get; set; }
    
    [BsonElement("year")]
    public int Year { get; set; }
    
    [BsonElement("genreId")]
    public string GenreId { get; set; }
    
    [BsonElement("actors")]
    public IEnumerable<Actor> Actors { get; set; }
}