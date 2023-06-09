using LibraryService.Domain.Common;

namespace LibraryService.Domain.Entities
{
    public class Publisher :BaseAuditableEntity
    {
        public override object Key { get => Id; }
        public int Id { get; set; }
        public string Name { get; set; }


        public ICollection<BookAuthor> BookPublishers { get; set; }
    }
}
