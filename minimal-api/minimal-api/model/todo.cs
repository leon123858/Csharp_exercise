using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace minimal_api.Model
{
    public class TodoDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string TodoCollectionName { get; set; } = null!;
    }

    public class TodoItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Name { get; set; } = "";
        public bool IsComplete { get; set; } = false;

        public TodoItem(string name)
        {
            Name = name;
        }

        public TodoItem setComplete()
        {
            IsComplete = true;
            return this;
        }
    }
}
