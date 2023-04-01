using AutoMapper;
using MongoDB.Driver;
using XMLApp.DTOs;
using XMLApp.Model;

namespace XMLApp.Services
{
    public class UserService : IUserService
    {
        private IMapper _mapper;
        private IMongoCollection<User> _users;
        public UserService(IMapper mapper)
        {
            _mapper = mapper;
            var settings = MongoClientSettings.FromConnectionString("mongodb://xws:gKz8dx3HFljTqsee@ac-bxlowrt-shard-00-00.jzm0jin.mongodb.net:27017,ac-bxlowrt-shard-00-01.jzm0jin.mongodb.net:27017,ac-bxlowrt-shard-00-02.jzm0jin.mongodb.net:27017/?ssl=true&replicaSet=atlas-8liqmh-shard-0&authSource=admin&retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            var database = client.GetDatabase("UserDB");
            _users = database.GetCollection<User>("Users");
        }

        public Task<User> GetById(int id) => _users.Find(user => user.Id.Equals(id)).FirstOrDefaultAsync();
        
        public async Task<bool> CheckIfEmailExistsAsync(string email)
        {
            if ( GetUserByEmailAsync(email) != null)
            {
                return true;
            }
            return false;
        }


        private Task<User> GetUserByEmailAsync(string email) => _users.Find(user => user.Email.Equals(email)).FirstOrDefaultAsync();
      

        public async Task RegisterUser(RegisterDTO dto)
        {
            dto.Password = HashPassword(dto.Password);
            User user = _mapper.Map<User>(dto);
            _users.InsertOne(user);


        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);

        }


    }
}
