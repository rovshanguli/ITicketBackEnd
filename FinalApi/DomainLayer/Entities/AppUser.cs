using Microsoft.AspNetCore.Identity;

namespace DomainLayer.Entities
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
