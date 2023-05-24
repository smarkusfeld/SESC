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
    [Table("classifier")]
    public class Classifier :IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Label { get; set; }
        public string Name { get; set; }
        public ICollection<BookClassifier> BookClassifiers { get; set; }

    }
    [Table("bookclassifier")]
    [PrimaryKey(nameof(Classifier), nameof(Book))]
    public class BookClassifier : IEntity
    {
        public Classifier Classifier { get; set; }
        public Book Book { get; set; }
    }
}
