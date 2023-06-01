using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Domain.Entities
{
    [Table("subject")]
    public class Subject : BaseEntity
    {
   
        public string Name { get; set; }
        public ICollection<BookSubject> BookSubjects { get; set; }
    }

   
}
