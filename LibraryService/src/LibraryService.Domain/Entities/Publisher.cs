using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LibraryService.Domain.Entities
{
    [Table("publisher")]
    public class Publisher : IEntity
    {
        
        public string Name { get; set; }
        public ICollection<BookPublisher> BookPublishers { get; set; }
    }

   
}
