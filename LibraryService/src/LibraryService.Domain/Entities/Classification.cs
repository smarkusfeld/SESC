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
    [Table("classification")]
    public class Classification :BaseEntity
    {
        
        public string Label { get; set; }
        public string Name { get; set; }
        public ICollection<BookClassification> BookClassifications { get; set; }

    }
   
}
