using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API.Model

{
    public class User
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string Username { get; set; }
        public string PasswordHash { get; set; }
        
        public string Email { get; set; }
    }
}