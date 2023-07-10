using StudentService.Application.Interfaces.Repositories.TypeRepositories;
using StudentService.Domain.Entities;
using StudentService.Infastructure.Context;



namespace StudentService.Infastructure.Repositories.TypeRepositories
{
    public class EnrolmentRepository : GenericRepository<Enrolment>, IEnrolmentRepository
    {
        public EnrolmentRepository(DataContext dbContext) : base(dbContext)
        {

        }
    }
}
