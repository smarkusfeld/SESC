using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityService.Models
{
    public class RegistrationModel
    {        

        public string? Email { get; private set; }

        public string? Password { get; private set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string MiddleName { get; set; } = string.Empty;
        public string? SchoolEmail { get; set; } = string.Empty;
        public string Roles { get; set; }


    }
}
