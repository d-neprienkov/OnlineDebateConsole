using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OnlineDebateConsole.Models
{
    public class Comment
    {
        [BsonId]
        public ObjectId Id { get; set; }
        
        [BsonElement("debate")]
        public ObjectId Debate { get; set; }
        
        [BsonElement("user")]
        public ObjectId User { get; set; }
        
        [BsonElement("text")]
        public string Text { get; set; }
        
        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }
    }
}
