using LibraryService.Application.Interfaces.Repositories;
using LibraryService.Domain.Entities;
using LibraryService.Infastructure.Context;

namespace LibraryService.Infastructure.Repositories
{
    public class PublisherRepository : GenericRepository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(DataContext dbContext) : base(dbContext)
        {

        }
        
    }
}
