using IdentityService.Models.ValueObjects;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityService.Models
{
    public class User : IdentityUser
    {
        public User() { }
        public User(UserIdentifer userId)
        {
            UserName = userId.Identifer;
            UserIdentifier = userId;
        }
       

        [Column(TypeName = "varchar(255)")]
        public string FirstName { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Surname { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string MiddleName { get; set; } = string.Empty;

        [Column(TypeName = "varchar(255)")]
        public string? SchoolEmail { get; set; }

        public int UserIdentifierId { get; set; }
        public UserIdentifer? UserIdentifier { get; set; }
        public Address? Address { get; set; }
        public Address? TermAddress { get; set; }
        
    }
}
