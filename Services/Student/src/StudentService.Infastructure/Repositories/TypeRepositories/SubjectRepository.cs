using StudentService.Application.Interfaces.Repositories.TypeRepositories;
using StudentService.Domain.Entities;
using StudentService.Infastructure.Context;



namespace StudentService.Infastructure.Repositories.TypeRepositories
{
    public class SubjectRepository : GenericRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(DataContext dbContext) : base(dbContext)
        {

        }
    }
}
