using Microsoft.AspNetCore.Identity;
#nullable disable
namespace Core.Entities.Identity;

 public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public Address Address { get; set; }
    }