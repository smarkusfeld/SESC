

using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryService.Domain.Entities
{
    [Table("booksubject")]
    public class BookSubject 
    {

        public string ISBN { get; private set; }
        public int SubjectId { get; private set; }
        public string SubjectName { get; private set; }
        public Book? Book { get; set; } 
        public Subject Subject { get; private set; } 
        public BookSubject(string isbn, int subjectId, string name)
        {
            ISBN = isbn;
            SubjectId = subjectId;
            SubjectName = name;
        }
    }
}
