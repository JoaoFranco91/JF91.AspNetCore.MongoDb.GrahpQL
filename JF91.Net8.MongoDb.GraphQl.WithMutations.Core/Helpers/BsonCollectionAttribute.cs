namespace JF91.Net8.MongoDb.GraphQl.WithMutations.Core.Helpers;

public class BsonCollectionAttribute : Attribute
{
    private string _collectionName;
    public BsonCollectionAttribute(string collectionName)
    {
        _collectionName = collectionName;
    }
    public string CollectionName => _collectionName;
}