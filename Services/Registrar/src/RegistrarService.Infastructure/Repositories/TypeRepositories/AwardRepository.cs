using RegistrarService.Application.Interfaces.Repositories.TypeRepositories;
using RegistrarService.Domain.Entities;
using RegistrarService.Infastructure.Context;



namespace RegistrarService.Infastructure.Repositories.TypeRepositories
{
    public class AwardRepository : GenericRepository<Award>, IAwardRepository
    {
        public AwardRepository(DataContext dbContext) : base(dbContext)
        {

        }
    }
}
