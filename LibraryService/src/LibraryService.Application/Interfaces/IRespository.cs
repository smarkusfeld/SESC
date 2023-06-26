using LibraryService.Domain.Entities;

namespace LibraryService.Application.Interfaces
{
    public interface IAccountRepository : IGenericRepository<Account>
    {

    }    
    public interface IAuthorRepository : IGenericRepository<Author>
    {

    }

    public interface IBookCopyRepository : IGenericRepository<BookCopy>
    {

    }
    
    public interface ISubjectRepository : IGenericRepository<Subject>
    {

    }
    public interface IPublisherRepository : IGenericRepository<Publisher>
    {

    }
    public interface IReservationRepository : IGenericRepository<Reservation>
    {

    }
}
