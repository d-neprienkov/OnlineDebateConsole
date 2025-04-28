using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OnlineDebateConsole.Models
{
    public class Vote
    {
        [BsonId]
        public ObjectId Id { get; set; }
        
        [BsonElement("debate")]
        public ObjectId Debate { get; set; }
        
        [BsonElement("user")]
        public ObjectId User { get; set; }
        
        [BsonElement("side")]
        public string Side { get; set; }
        
        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }
    }
}
