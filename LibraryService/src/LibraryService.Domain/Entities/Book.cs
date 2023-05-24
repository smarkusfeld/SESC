using LibraryService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Domain.Entities
{
    [Table("book")]
    public class Book :IEntity
    {
        [Key]
        public int ISBN { get; set; }
        public string Title { get; set; }
        public string Weight { get; set; }
        public int PageCount { get; set; }
        public string Pagination { get; set; }
        public int Year { get; set; }    
        public int Copies { get; set; }
        public List<string> PlaceofPublication { get; set; }
        public ICollection<BookSubject> BookSubjects { get; set; }
        public ICollection<BookPublisher> BookPublishers { get; set; }
        public ICollection<BookIdentifier> BookIdentifiers { get; set; }
        public ICollection<BookClassifier> BookClassifiers { get; set; }
        public ICollection<BookAuthor>BookAuthors { get; set; }
        public ICollection<BookCopy> BookCopys { get; set; }

       
    }
}
