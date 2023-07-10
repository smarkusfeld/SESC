using StudentService.Application.Interfaces.Repositories.TypeRepositories;
using StudentService.Domain.Entities;
using StudentService.Infastructure.Context;



namespace StudentService.Infastructure.Repositories.TypeRepositories
{
    public class AwardRepository : GenericRepository<Award>, IAwardRepository
    {
        public AwardRepository(DataContext dbContext) : base(dbContext)
        {

        }
    }
}
