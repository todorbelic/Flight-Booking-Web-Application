using XMLApp.DTOs;
using XMLApp.Model;

namespace XMLApp.Services
{
    public interface IUserService
    {
        Task<User> GetById(int id);

        Task RegisterUser(RegisterDTO dto);

        Task<bool> CheckIfEmailExistsAsync(string email);
    }
}
