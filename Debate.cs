using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace OnlineDebateConsole.Models
{
    public class Debate
    {
        [BsonId]
        public ObjectId Id { get; set; }
        
        [BsonElement("topic")]
        public string Topic { get; set; }
        
        [BsonElement("description")]
        public string Description { get; set; }
        
        [BsonElement("createdBy")]
        public ObjectId CreatedBy { get; set; }
        
        [BsonElement("sides")]
        public List<Side> Sides { get; set; }
        
        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }
    }

    public class Side
    {
        [BsonElement("name")]
        public string Name { get; set; }
        
        [BsonElement("arguments")]
        public List<string> Arguments { get; set; }
    }
}
