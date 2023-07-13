using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Models
{
    public class UserRegistrationModel
    {
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        public string? SchoolEmail { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        public string Surname { get; set; }

        public string MiddleName { get; set; } = string.Empty;
        public string Roles { get; set; } 
    }
}
