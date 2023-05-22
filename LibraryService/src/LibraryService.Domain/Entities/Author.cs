using FinanceService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Domain.Entities
{
    [Table("Authors")]
    public class Author : IEntity
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
