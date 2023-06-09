using LibraryService.Domain.Common;
using LibraryService.Domain.DataModels;

namespace LibraryService.Domain.Entities
{
    public class Author : BaseAuditableEntity
    {
        public override object Key { get => Id; }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
