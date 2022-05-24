using Microsoft.AspNetCore.Identity;

namespace DomainLayer.Entities
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
