using RegistrarService.Application.Interfaces.Repositories.TypeRepositories;
using RegistrarService.Domain.Entities;
using RegistrarService.Infastructure.Context;



namespace RegistrarService.Infastructure.Repositories.TypeRepositories
{
    public class SubjectRepository : GenericRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(DataContext dbContext) : base(dbContext)
        {

        }
    }
}
