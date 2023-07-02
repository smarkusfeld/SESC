using LibraryService.Application.Interfaces.Repositories;
using LibraryService.Domain.Entities;
using LibraryService.Infastructure.Context;

namespace LibraryService.Infastructure.Repositories
{
    public class SubjectRepository : GenericRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(DataContext dbContext) : base(dbContext)
        {
           
        }
        
    }
}