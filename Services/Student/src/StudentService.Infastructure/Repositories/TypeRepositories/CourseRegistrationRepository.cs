using StudentService.Application.Interfaces.Repositories.TypeRepositories;
using StudentService.Domain.Entities;
using StudentService.Infastructure.Context;



namespace StudentService.Infastructure.Repositories.TypeRepositories
{
    public class CourseRegistrationRepository : GenericRepository<CourseRegistration>, ICourseRegistrationRepository
    {
        public CourseRegistrationRepository(DataContext dbContext) : base(dbContext)
        {

        }
    }
}
