using FinanceService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Domain.Entities
{
    [Table("TitleAuthor")]
    public class TitleAuthor : IEntity
    {
        public Book Book { get; set; }
        public Author Author { get; set; }
    }
}
