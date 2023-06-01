using LibraryService.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Domain.Entities
{
    [Table("account")]
    public class Account : BaseEntity
    {
       
        public string? StudentId { get; set; }
        public string? EmployeeId { get; set; }       

        [Required]
        public int Pin { get; set; } = 000000;
        public ICollection<Loan>? Loans { get; set; }
        
        public User User { get; set; }

        
    }
}
