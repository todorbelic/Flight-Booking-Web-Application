using Microsoft.AspNetCore.Identity;
using XMLApp.Attributes;

namespace XMLApp.Model
{
    [BsonCollection("users")]
    public class User: Document
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Address Address { get; set; }
        public Roles Role { get; set; }
    }
}
