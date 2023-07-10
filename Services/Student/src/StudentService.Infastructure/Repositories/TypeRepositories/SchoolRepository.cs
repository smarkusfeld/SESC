using StudentService.Application.Interfaces.Repositories.TypeRepositories;
using StudentService.Domain.Entities;
using StudentService.Infastructure.Context;



namespace StudentService.Infastructure.Repositories.TypeRepositories
{
    public class SchoolRepository : GenericRepository<School>, ISchoolRepository
    {
        public SchoolRepository(DataContext dbContext) : base(dbContext)
        {

        }
    }
}
