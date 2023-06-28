using LibraryService.Domain.Entities;

namespace LibraryService.Application.Interfaces.Repositories
{

    public interface IAuthorRepository : IGenericRepository<Author>
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
