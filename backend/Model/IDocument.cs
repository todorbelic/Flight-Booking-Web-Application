using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace XMLApp.Model
{
    public interface IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        ObjectId Id { get; set; }
    }
}
