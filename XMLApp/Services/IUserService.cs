using XMLApp.DTO;
using XMLApp.Model;

namespace XMLApp.Services
{
    public interface IUserService
    {
        public List<User> Get();
        public Task<User> GetById(string id);

        Task RegisterUser(RegisterDTO dto);

        Task<bool> CheckIfEmailExistsAsync(string email);

        Task<bool> EmailMatchesPasswordAsync(LogInDTO dto);

        Task<string> LogInUserAsync(LogInDTO dto);
    }
}
