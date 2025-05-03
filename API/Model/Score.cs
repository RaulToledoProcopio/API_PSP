using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API.Model

{
    public class Score
    {
        [BsonId] 
        public ObjectId Id { get; set; }

        public string Username { get; set; }

        // Tiempo en segundos
        public double TimeSeconds { get; set; }

        // Marca de tiempo
        public DateTime PlayedAt { get; set; } = DateTime.UtcNow;
    }
}