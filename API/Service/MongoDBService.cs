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

        // Colecciones
        public IMongoCollection<User> Users => _database.GetCollection<User>("User");
        public IMongoCollection<Score> Scores => _database.GetCollection<Score>("Score");

        // Método para obtener un usuario por su username
        public User GetUserByUsername(string username)
        {
            return Users.Find(u => u.Username == username).FirstOrDefault();
        }
        
        // Método para obtener un usuario por su email
        public User GetUserByEmail(string email)
        {
            return Users.Find(u => u.Email == email).FirstOrDefault();
        }
        
        // Método para registrar un nuevo usuario
        public void RegisterUser(User user)
        {
            Users.InsertOne(user);
        }
        
        // Método para añadir una puntuación
        public void AddScore(Score score)
        {
            Scores.InsertOne(score);
        }
        
        // Método para obtener las puntuaciones ordenadas
        public List<Score> GetTopScores(int limit)
        {
            return Scores
                .Find(_ => true)
                .SortBy(s => s.TimeSeconds)
                .Limit(limit)
                .ToList();
        }
    }
}