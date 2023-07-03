using System.ComponentModel.DataAnnotations;

namespace IdentityService.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Surname")]
        public string? Surname { get; set; }
        
        public string? MiddleName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
