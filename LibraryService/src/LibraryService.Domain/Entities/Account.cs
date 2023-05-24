using LibraryService.Domain.Entities;
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
    public class Account : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string StudentID { get; set; }

        public int Pin { get; set; } = 000000;

        public ICollection<Loan> Loans { get; set; }
    }
}
