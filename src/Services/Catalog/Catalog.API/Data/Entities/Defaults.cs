using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Catalog.API.Data.Entities
{
    public interface IEntitiy
    {
        public string Id { get; }
    }

    public class Entity : IEntitiy
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }

    public class NamedEntity : Entity
    {
        [BsonElement("Name")]
        public string Name { get; set; }
    }
}
