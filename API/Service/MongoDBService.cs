using MongoDB.Driver;
using API.Model;

namespace API.Service
{
    public class MongoDBService
    {
        private readonly IMongoDatabase _database;

        public MongoDBService()
        {
            var client = new MongoClient("mongodb+srv://rtolpro:AwKrhMbmPYJbrgnf@cluster0.rdgdl.mongodb.net/Godot?retryWrites=true&w=majority&appName=Cluster0");
            _database = client.GetDatabase("Godot");
        }

        public IMongoCollection<User> Users => _database.GetCollection<User>("User");

        // Método para obtener un usuario por su username
        public User GetUserByUsername(string username)
        {
            return Users.Find(u => u.Username == username).FirstOrDefault();
        }

        // Método para registrar un nuevo usuario
        public void RegisterUser(User user)
        {
            // MongoDB insertará automáticamente el campo _id
            Users.InsertOne(user);
        }
    }
}