using StudentService.Application.Interfaces.Repositories.TypeRepositories;
using StudentService.Domain.Entities;
using StudentService.Infastructure.Context;



namespace StudentService.Infastructure.Repositories.TypeRepositories
{
    public class StudentResultRepository : GenericRepository<StudentResult>, IStudentResultRepository
    {
        public StudentResultRepository(DataContext dbContext) : base(dbContext)
        {

        }
    }
}
