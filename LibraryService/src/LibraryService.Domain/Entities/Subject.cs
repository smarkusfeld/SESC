using LibraryService.Domain.Common;

namespace LibraryService.Domain.Entities
{
    public class Subject : BaseAuditableEntity
    {
        public override object Key { get => Id; }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<BookSubject> BookSubjects { get; set; }

    }
}
