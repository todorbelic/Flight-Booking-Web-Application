using MongoDB.Bson;

namespace XMLApp.Model
{
    public abstract class Document : IDocument
    {
        public ObjectId Id { get; set; }
    }
}
