using MongoDB.Driver;

namespace XMLApp.Services
{
    public class AuthService
    {
     //   private readonly IMongoCollection<User> _games;

        public AuthService()
        {

            var settings = MongoClientSettings.FromConnectionString("mongodb://xws:gKz8dx3HFljTqsee@ac-bxlowrt-shard-00-00.jzm0jin.mongodb.net:27017,ac-bxlowrt-shard-00-01.jzm0jin.mongodb.net:27017,ac-bxlowrt-shard-00-02.jzm0jin.mongodb.net:27017/?ssl=true&replicaSet=atlas-8liqmh-shard-0&authSource=admin&retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            var database = client.GetDatabase("UserDB");
        }
    }
}
