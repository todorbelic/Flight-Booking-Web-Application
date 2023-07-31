using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;
using XMLApp.Model;

namespace XMLApp.DTO
{
    public class RegisterDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Address Address { get; set; }
        public string Role { get; set; }
    }

}
