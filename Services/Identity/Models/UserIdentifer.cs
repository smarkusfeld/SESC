using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing.Printing;

namespace IdentityService.Models
{
    
    public class UserIdentifer
    {
        private UserIdentifer() { }
        public UserIdentifer(Char prefix) 
        {
            Prefix = prefix;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserNumber { get; set; }
        public User? User { get; private set; } // Reference navigation
          

        private char _prefix;
        public Char Prefix { get => _prefix; init => _prefix = value; }

        [NotMapped]
        public string? Identifer { get => "_prefix" + UserNumber; }

        [NotMapped]
        public bool InUse { get => User != null; }
    }
}
