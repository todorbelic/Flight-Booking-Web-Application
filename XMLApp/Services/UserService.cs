using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using XMLApp.DTO;
using XMLApp.Model;
using XMLApp.Repository;
using XMLApp.Settings;

namespace XMLApp.Services
{
    public class UserService : IUserService
    {
        private IMapper _mapper;
        private readonly IRepository<User> _userRepository;
        private readonly IConfiguration _configuration;
        public JwtOptions? _jwtOptions { get; private set; }
        public object JwtHelper { get; private set; }

        public UserService(IMapper mapper, IRepository<User> userRepository, IConfiguration configuration)
        {
            _mapper = mapper;
            _userRepository= userRepository;
            _configuration = configuration;
        }

        public async Task<User> GetById(string id) => await _userRepository.FindByIdAsync(id);
        public List<User> Get() => _userRepository.AsQueryable().ToList();

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

        public async Task<bool> EmailMatchesPasswordAsync(LogInDTO dto)
        {
            User userByEmail = await GetUserByEmailAsync(dto.Email);
            if (userByEmail != null)
            {
                return BCrypt.Net.BCrypt.Verify(dto.Password, userByEmail.Password);
            }

            return false;
        }

        public async Task<string> LogInUserAsync(LogInDTO dto)
        {
            User user = await GetUserByEmailAsync(dto.Email);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.PrimarySid, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email)
            };
            return GenerateToken(claims);

        }

        private string GenerateToken(IEnumerable<Claim> claims)
        {
            _jwtOptions = _configuration.GetSection(JwtOptions.Jwt).Get<JwtOptions>();
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityTokenHandler().WriteToken(

                new JwtSecurityToken(
                    _jwtOptions.Issuer,
                    _jwtOptions.Audience,
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(15),
                    signingCredentials: credentials
                    ));

            return token;
        }

    }
}
