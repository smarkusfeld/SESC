using RegistrarService.Application.Interfaces.Repositories.TypeRepositories;
using RegistrarService.Domain.Entities;
using RegistrarService.Infastructure.Context;



namespace RegistrarService.Infastructure.Repositories.TypeRepositories
{
    public class SchoolRepository : GenericRepository<School>, ISchoolRepository
    {
        public SchoolRepository(DataContext dbContext) : base(dbContext)
        {

        }
    }
}
