using Microsoft.AspNetCore.Identity;

namespace IdentityService.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; } = string.Empty;

        public string[] Scopes { get; set; } = Array.Empty<string>();
    }
}
