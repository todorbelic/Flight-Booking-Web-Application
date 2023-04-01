using AutoMapper;
using MongoDB.Driver;
using XMLApp.DTO;
using XMLApp.Model;
using XMLApp.Repository;

namespace XMLApp.Services
{
    public class UserService : IUserService
    {
        private IMapper _mapper;
        private readonly IRepository<User> _userRepository;
        public UserService(IMapper mapper, IRepository<User> userRepository)
        {
            _mapper = mapper;
            _userRepository= userRepository;
        }

        public async Task<User> GetById(string id) => await _userRepository.FindByIdAsync(id);
        
        public async Task<bool> CheckIfEmailExistsAsync(string email)
        {
            User user = await GetUserByEmailAsync(email);
            if (user != null) return true;
            return false;
        }


        private async Task<User> GetUserByEmailAsync(string email) => await _userRepository.FindOneAsync(user => user.Email.Equals(email));
      

        public async Task RegisterUser(RegisterDTO dto)
        {
            dto.Password = HashPassword(dto.Password);
            User user = _mapper.Map<User>(dto);
            await _userRepository.InsertOneAsync(user);


        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);

        }

        public List<User> Get()
        {
            return _userRepository.AsQueryable().ToList();
        }

    }
}
